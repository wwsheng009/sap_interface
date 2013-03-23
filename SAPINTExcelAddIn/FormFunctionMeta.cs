using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAPINT;
using Microsoft.Office.Tools.Excel;
using SAPINT.Function;
using SAPINT.Function.Meta;

namespace ExcelAddIn1
{
    public partial class FormFunctionMeta : Form
    {

        private string _funcName = "";  //当前的函数名

        private string _systemName;//连接的SAP系统的配置名称

        RfcFunctionMetaAsDataTable _metaList = null;
        Worksheet ws = null;
        Microsoft.Office.Interop.Excel.Range range = null;

        List<String> _parsedStructure = null;
        List<String> _parsedTable = null;

        DataTable dtBatchInput = null;

        public FormFunctionMeta()
        {
            InitializeComponent();
            _parsedStructure = new List<string>();
            _parsedTable = new List<string>();

            InitializeBatchTable();
        }

        private void LoadFunctionMetaData()
        {
            if (!check())
            {
                return;
            }
            else
            {
                try
                {

                    _metaList = SAPFunctionMeta.GetFuncMetaAsDataTable(_systemName, _funcName);

                    if (_metaList == null)
                    {
                        MessageBox.Show("无法找到函数信息！！");
                    }
                    ParseMetaData();

                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                    //throw;
                }

            }
        }
        private void btnDisplay_Click(object sender, EventArgs e)
        {

            LoadFunctionMetaData();
        }
        private bool check()
        {
            this._systemName = this.cbx_SystemList.Text.ToUpper().Trim();
            this._funcName = this.txtFunctionName.Text.Trim().ToUpper();
            if (string.IsNullOrEmpty(_systemName))
            {
                MessageBox.Show("请选择系统");
                return false;
            }


            if (string.IsNullOrEmpty(this._funcName))
            {
                MessageBox.Show("请指定表名");
                return false;
            }

            return true;
        }

        private void ParseMetaData()
        {
            //_funcMeta.Import.Count

            dgvImport.DataSource = _metaList.Import;
            dgvExport.DataSource = _metaList.Export;
            dgvChanging.DataSource = _metaList.Changing;
            dgvTables.DataSource = _metaList.Tables;
            dgvImport.AutoResizeColumns();
            dgvExport.AutoResizeColumns();
            dgvChanging.AutoResizeColumns();
            dgvTables.AutoResizeColumns();
            tabPage2.BringToFront();
        }

        public void ParseMetaDataToExcel()
        {
            if (_metaList == null)
            {
                LoadFunctionMetaData();

            }
            if (_metaList == null)
            {
                MessageBox.Show("请先查找函数信息！！");
                return;
            }
            Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets.Add();
            ws = Globals.Factory.GetVstoObject(Globals.ThisAddIn.Application.ActiveWorkbook.ActiveSheet);

            try
            {
                ws.Name = _funcName;
            }
            catch (Exception)
            {

                // throw;
            }

            DataTable dtImport = _metaList.Import;
            DataTable dtExport = _metaList.Export;
            DataTable dtChange = _metaList.Changing;
            DataTable dtTables = _metaList.Tables;

            int rowsOffset = 0;
            int colsOffset = 0;

            rowsOffset = 4; //从第4行开始
            colsOffset = 2; //从第2行开始

            ParseParameterList(dtExport, "输入参数", rowsOffset, colsOffset);
            rowsOffset += dtImport.Rows.Count + 5;

            ParseParameterList(dtExport, "输出参数", rowsOffset, colsOffset);
            rowsOffset += dtExport.Rows.Count + 5;

            ParseParameterList(dtChange, "修改参数", rowsOffset, colsOffset);
            rowsOffset += dtChange.Rows.Count + 5;

            ParseParameterList(dtTables, "表参数", rowsOffset, colsOffset);
            rowsOffset += dtTables.Rows.Count + 5;


            if (true)
            {
                //从新的列开始存放结构或表定义 
                //  rowsOffset = 6;//不能小于4
                //  colsOffset += 12;   //注意不要覆盖前面的列。
            }
            else
            {
                //在同一列开始存放结构的定义
                //  rowsOffset += dtTables.Rows.Count + 8;
                // colsOffset += 9;
            }
            rowsOffset += 5;
            colsOffset += 12;

            ParseStructToExcel(dtImport, ref rowsOffset, colsOffset);
            ParseStructToExcel(dtExport, ref rowsOffset, colsOffset);
            ParseStructToExcel(dtChange, ref rowsOffset, colsOffset);
            ParseStructToExcel(dtTables, ref rowsOffset, colsOffset);

            _parsedStructure.Clear();
            _parsedTable.Clear();


        }
        /// <summary>
        /// 处理固定的4个参数表
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="name"></param>
        /// <param name="rowsOffset"></param>
        /// <param name="colsOffset"></param>
        private void ParseParameterList(DataTable dt, String name, int rowsOffset, int colsOffset)
        {
            range = (Microsoft.Office.Interop.Excel.Range)ws.get_Range(ws.Cells[rowsOffset - 2, colsOffset + 1], ws.Cells[rowsOffset - 2, colsOffset + 8]);
            range.Select();
            range.Merge(false);
            ws.Cells.set_Item(rowsOffset - 2, colsOffset - 1, "PARAMETERLIST");
            ws.Cells.set_Item(rowsOffset - 2, colsOffset, name);
            ws.Cells.set_Item(rowsOffset - 1, colsOffset + 0, "字段编号");
            ws.Cells.set_Item(rowsOffset - 1, colsOffset + 1, "字段");
            ws.Cells.set_Item(rowsOffset - 1, colsOffset + 2, "数据类型");
            ws.Cells.set_Item(rowsOffset - 1, colsOffset + 3, "类型名称");
            ws.Cells.set_Item(rowsOffset - 1, colsOffset + 4, "长度");
            ws.Cells.set_Item(rowsOffset - 1, colsOffset + 5, "小数位");
            ws.Cells.set_Item(rowsOffset - 1, colsOffset + 6, "默认值");
            ws.Cells.set_Item(rowsOffset - 1, colsOffset + 7, "必输");
            ws.Cells.set_Item(rowsOffset - 1, colsOffset + 8, "短文本");
            if (dt.Rows.Count > 0)
            {
                ParseParameterlistToExcel(dt, rowsOffset, colsOffset);
            }
        }
        /// <summary>
        /// 如果字段的类型是结构体，则需要分开处理
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="rowsOffset"></param>
        /// <param name="colsOffset"></param>
        private void ParseStructToExcel(DataTable dt, ref int rowsOffset, int colsOffset)
        {

            foreach (DataRow row in dt.Rows)
            {
                if (row["DataType"].ToString() == "STRUCTURE")
                {
                    String structurName = row["DataTypeName"].ToString();
                    String Documentation = row[FuncFieldText.Documentation].ToString();
                    if (_parsedStructure.Contains(structurName))
                    {
                        return;
                    }
                    DataTable dt2 = _metaList.StructureDetail[structurName];
                    if (dt2 != null)
                    {

                        if (dt2.Rows.Count > 0)
                        {
                            _parsedStructure.Add(structurName);
                            range = (Microsoft.Office.Interop.Excel.Range)ws.get_Range(ws.Cells[rowsOffset - 4, colsOffset + 1], ws.Cells[rowsOffset - 4, colsOffset + 5]);
                            range.Select();
                            range.Merge(false);

                            range = (Microsoft.Office.Interop.Excel.Range)ws.get_Range(ws.Cells[rowsOffset - 3, colsOffset + 1], ws.Cells[rowsOffset - 3, colsOffset + 5]);
                            range.Select();
                            range.Merge(false);

                            range = (Microsoft.Office.Interop.Excel.Range)ws.get_Range(ws.Cells[rowsOffset - 2, colsOffset + 1], ws.Cells[rowsOffset - 2, colsOffset + 5]);
                            range.Select();
                            range.Merge(false);

                            ws.Cells.set_Item(rowsOffset - 4, colsOffset - 1, "STRUCTURE");
                            ws.Cells.set_Item(rowsOffset - 4, colsOffset, "结构");
                            ws.Cells.set_Item(rowsOffset - 3, colsOffset, "名称");
                            ws.Cells.set_Item(rowsOffset - 2, colsOffset, "备注");
                            ws.Cells.set_Item(rowsOffset - 4, colsOffset + 1, structurName);
                            ws.Cells.set_Item(rowsOffset - 3, colsOffset + 1, Documentation);
                            ws.Cells.set_Item(rowsOffset - 1, colsOffset + 0, "字段编号");
                            ws.Cells.set_Item(rowsOffset - 1, colsOffset + 1, "字段");
                            ws.Cells.set_Item(rowsOffset - 1, colsOffset + 2, "数据类型");
                            ws.Cells.set_Item(rowsOffset - 1, colsOffset + 3, "长度");
                            ws.Cells.set_Item(rowsOffset - 1, colsOffset + 4, "小数位");
                            ws.Cells.set_Item(rowsOffset - 1, colsOffset + 5, "短文本");
                            ParseTypeDefinitionToExcel(dt2, rowsOffset, colsOffset);
                            rowsOffset += dt2.Rows.Count + 7;
                        }

                    }

                }
                else if (row["DataType"].ToString() == "TABLE")
                {
                    String tableName = row["DataTypeName"].ToString();
                    String Documentation = row[FuncFieldText.Documentation].ToString();
                    if (_parsedTable.Contains(tableName))
                    {
                        return;
                    }
                    DataTable dt2 = _metaList.StructureDetail[tableName];
                    if (dt2 != null)
                    {

                        if (dt2.Rows.Count > 0)
                        {
                            _parsedTable.Add(tableName);
                            range = (Microsoft.Office.Interop.Excel.Range)ws.get_Range(ws.Cells[rowsOffset - 4, colsOffset + 1], ws.Cells[rowsOffset - 4, colsOffset + 5]);
                            range.Select();
                            range.Merge(false);

                            range = (Microsoft.Office.Interop.Excel.Range)ws.get_Range(ws.Cells[rowsOffset - 3, colsOffset + 1], ws.Cells[rowsOffset - 3, colsOffset + 5]);
                            range.Select();
                            range.Merge(false);

                            range = (Microsoft.Office.Interop.Excel.Range)ws.get_Range(ws.Cells[rowsOffset - 2, colsOffset + 1], ws.Cells[rowsOffset - 2, colsOffset + 5]);
                            range.Select();
                            range.Merge(false);
                            ws.Cells.set_Item(rowsOffset - 4, colsOffset - 1, "TABLE");
                            ws.Cells.set_Item(rowsOffset - 4, colsOffset, "表");
                            ws.Cells.set_Item(rowsOffset - 3, colsOffset, "名称");
                            ws.Cells.set_Item(rowsOffset - 2, colsOffset, "备注");
                            ws.Cells.set_Item(rowsOffset - 4, colsOffset + 1, tableName);
                            ws.Cells.set_Item(rowsOffset - 3, colsOffset + 1, Documentation);
                            ws.Cells.set_Item(rowsOffset - 1, colsOffset + 0, "字段编号");
                            ws.Cells.set_Item(rowsOffset - 1, colsOffset + 1, "字段");
                            ws.Cells.set_Item(rowsOffset - 1, colsOffset + 2, "数据类型");
                            ws.Cells.set_Item(rowsOffset - 1, colsOffset + 3, "长度");
                            ws.Cells.set_Item(rowsOffset - 1, colsOffset + 4, "小数位");
                            ws.Cells.set_Item(rowsOffset - 1, colsOffset + 5, "短文本");
                            ParseTypeDefinitionToExcel(dt2, rowsOffset, colsOffset);
                            rowsOffset += dt2.Rows.Count + 7;

                        }
                    }
                }
            }
        }



        /// <summary>
        /// 把一个DataTable映射到Excel表
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        private void ParseParameterlistToExcel(DataTable dt, int row, int col)
        {
            int rowOffset = 1;
            int colOffset = 1;

            rowOffset = row;
            colOffset = col;

            ws = Globals.Factory.GetVstoObject(Globals.ThisAddIn.Application.ActiveWorkbook.ActiveSheet);


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ws.Cells.set_Item(rowOffset + i, colOffset, i + 1);

                String FieldName = dt.Rows[i][FuncFieldText.Name].ToString();
                String DataType = dt.Rows[i][FuncFieldText.DataType].ToString();
                String DataTypeName = dt.Rows[i][FuncFieldText.DataTypeName].ToString();
                String Length = dt.Rows[i][FuncFieldText.Length].ToString();
                String Decimals = dt.Rows[i][FuncFieldText.Decimals].ToString();
                String DefaultValue = dt.Rows[i][FuncFieldText.DefaultValue].ToString();
                String Optional = dt.Rows[i][FuncFieldText.Optional].ToString();
                String Documentation = dt.Rows[i][FuncFieldText.Documentation].ToString();

                if (DataType.Trim().ToUpper() == SAPDataType.STRUCTURE.ToString())
                {
                    DataType = "结构";
                }
                else if (DataType.Trim().ToUpper() == SAPDataType.TABLE.ToString())
                {
                    DataType = "表";
                }

                if (Optional.Trim().ToUpper() == "TRUE")
                {
                    Optional = "";
                }
                else if (Optional.Trim().ToUpper() == "FALSE")
                {
                    Optional = "X";
                }
                ws.Cells.set_Item(rowOffset + i, colOffset + 1, FieldName);
                ws.Cells.set_Item(rowOffset + i, colOffset + 2, DataType);
                ws.Cells.set_Item(rowOffset + i, colOffset + 3, DataTypeName);
                ws.Cells.set_Item(rowOffset + i, colOffset + 4, Length);
                ws.Cells.set_Item(rowOffset + i, colOffset + 5, Decimals);
                ws.Cells.set_Item(rowOffset + i, colOffset + 6, DefaultValue);
                ws.Cells.set_Item(rowOffset + i, colOffset + 7, Optional);
                ws.Cells.set_Item(rowOffset + i, colOffset + 8, Documentation);
                //for (int j = 0; j < dt.Columns.Count; j++)
                //{
                //    //第1列是序列号，内容再偏移1列。
                //    ws.Cells.set_Item(rowOffset + i, colOffset + j + 1, dt.Rows[i][j].ToString());

                //}
            }
        }


        /// <summary>
        /// 把一个DataTable映射到Excel表
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        private void ParseTypeDefinitionToExcel(DataTable dt, int row, int col)
        {
            int rowOffset = 1;
            int colOffset = 1;

            rowOffset = row;
            colOffset = col;

            ws = Globals.Factory.GetVstoObject(Globals.ThisAddIn.Application.ActiveWorkbook.ActiveSheet);


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ws.Cells.set_Item(rowOffset + i, colOffset, i + 1);

                String FieldName = dt.Rows[i][FuncFieldText.Name].ToString();
                String DataType = dt.Rows[i][FuncFieldText.DataType].ToString();
                // String DataTypeName = dt.Rows[i][FuncFieldText.DataTypeName].ToString();
                String Length = dt.Rows[i][FuncFieldText.Length].ToString();
                String Decimals = dt.Rows[i][FuncFieldText.Decimals].ToString();
                // String DefaultValue = dt.Rows[i][FuncFieldText.DefaultValue].ToString();
                // String Optional = dt.Rows[i][FuncFieldText.Optional].ToString();
                String Documentation = dt.Rows[i][FuncFieldText.Documentation].ToString();

                ws.Cells.set_Item(rowOffset + i, colOffset + 1, FieldName);
                ws.Cells.set_Item(rowOffset + i, colOffset + 2, DataType);
                ws.Cells.set_Item(rowOffset + i, colOffset + 3, Length);
                ws.Cells.set_Item(rowOffset + i, colOffset + 4, Decimals);
                ws.Cells.set_Item(rowOffset + i, colOffset + 5, Documentation);
                //for (int j = 0; j < dt.Columns.Count; j++)
                //{
                //    //第1列是序列号，内容再偏移1列。
                //    ws.Cells.set_Item(rowOffset + i, colOffset + j + 1, dt.Rows[i][j].ToString());

                //}
            }
        }

        private void SetDgvSource(ref DataGridView dgv, DataGridViewCellEventArgs e)
        {
            if (dgv.Columns[e.ColumnIndex].Name == "DataTypeName")
            {
                if (dgv.Rows[e.RowIndex].Cells["DataType"].Value.ToString() == "STRUCTURE")
                {
                    DataTable dt = _metaList.StructureDetail[dgvExport.Rows[e.RowIndex].Cells["DataTypeName"].Value.ToString()];
                    dgvDetail.DataSource = dt;
                    dgvDetail.AutoResizeColumns();
                }
            }
        }
        private void dgvExport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SetDgvSource(ref dgvExport, e);


        }

        private void dgvChanging_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SetDgvSource(ref dgvChanging, e);

        }

        private void dgvTables_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SetDgvSource(ref dgvTables, e);

        }


        private void dgvImport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SetDgvSource(ref dgvImport, e);

        }

        private void btnParseToExcel_Click(object sender, EventArgs e)
        {
            ParseMetaDataToExcel();
        }

        private void InitializeBatchTable()
        {
            dtBatchInput = new DataTable();
            DataColumn dc = new DataColumn("systemName", Type.GetType("System.String"));

            dtBatchInput.Columns.Add(dc);
            dc = new DataColumn("FunctionName", Type.GetType("System.String"));
            dtBatchInput.Columns.Add(dc);
            dgvBatchInput.DataSource = dtBatchInput;

        }
        private void btnBatchInput_Click(object sender, EventArgs e)
        {
            if (dtBatchInput.Rows.Count > 0)
            {
                foreach (DataRow item in dtBatchInput.Rows)
                {
                    String systemName = item["systemName"].ToString().Trim();
                    String functionName = item["FunctionName"].ToString().Trim();
                    if (!String.IsNullOrWhiteSpace(systemName) && !String.IsNullOrWhiteSpace(functionName))
                    {
                        _metaList = SAPFunctionMeta.GetFuncMetaAsDataTable(systemName, functionName);
                        this._funcName = functionName;
                        ParseMetaDataToExcel();
                    }
                }
            }
        }

        private void dgvBatchInput_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Modifiers == Keys.Control)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.C:
                            CopyToClipboard(dgvBatchInput);
                            break;

                        case Keys.V:
                           // PasteClipboardValue(dgvBatchInput  ,false);
                            Paste(dgvBatchInput, "", 0, false);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Copy/paste operation failed. " + ex.Message, "Copy/Paste", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void CopyToClipboard(DataGridView dgv)
        {
            //Copy to clipboard
            DataObject dataObj = dgv.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void PasteClipboardValue(DataGridView dgv, Boolean boolPasteToSelectedCells)
        {
            //Show Error if no cell is selected
            if (dgv.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select a cell", "Paste", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Get the satring Cell
            DataGridViewCell startCell = GetStartCell(dgv);
            //Get the clipboard value in a dictionary
            Dictionary<int, Dictionary<int, string>> cbValue = ClipBoardValues(Clipboard.GetText());

            int iRowIndex = startCell.RowIndex;
            foreach (int rowKey in cbValue.Keys)
            {
                int iColIndex = startCell.ColumnIndex;
                foreach (int cellKey in cbValue[rowKey].Keys)
                {
                    //Check if the index is with in the limit
                    if (iColIndex <= dgv.Columns.Count - 1 && iRowIndex <= dgv.Rows.Count - 1)
                    {
                        DataGridViewCell cell = dgv[iColIndex, iRowIndex];

                        //Copy to selected cells if 'chkPasteToSelectedCells' is checked
                        if ((boolPasteToSelectedCells && cell.Selected) ||
                            (!boolPasteToSelectedCells))
                            cell.Value = cbValue[rowKey][cellKey];
                    }
                    iColIndex++;
                }
                iRowIndex++;
            }
        }

        private DataGridViewCell GetStartCell(DataGridView dgView)
        {
            //get the smallest row,column index
            if (dgView.SelectedCells.Count == 0)
                return null;

            int rowIndex = dgView.Rows.Count - 1;
            int colIndex = dgView.Columns.Count - 1;

            foreach (DataGridViewCell dgvCell in dgView.SelectedCells)
            {
                if (dgvCell.RowIndex < rowIndex)
                    rowIndex = dgvCell.RowIndex;
                if (dgvCell.ColumnIndex < colIndex)
                    colIndex = dgvCell.ColumnIndex;
            }

            return dgView[colIndex, rowIndex];
        }

        private Dictionary<int, Dictionary<int, string>> ClipBoardValues(string clipboardValue)
        {
            Dictionary<int, Dictionary<int, string>> copyValues = new Dictionary<int, Dictionary<int, string>>();

            String[] lines = clipboardValue.Split('\n');

            for (int i = 0; i <= lines.Length - 1; i++)
            {
                copyValues[i] = new Dictionary<int, string>();
                String[] lineContent = lines[i].Split('\t');

                //if an empty cell value copied, then set the dictionay with an empty string
                //else Set value to dictionary
                if (lineContent.Length == 0)
                    copyValues[i][0] = string.Empty;
                else
                {
                    for (int j = 0; j <= lineContent.Length - 1; j++)
                        copyValues[i][j] = lineContent[j];
                }
            }
            return copyValues;
        }


        #region 粘贴
        /// <summary>
        /// 粘贴到DataGridView里
        /// </summary>
        /// <param name="dgv">DataGridView控件</param>
        /// <param name="pasteText">需要粘贴的文字</param>
        /// <param name="kind">如果设置为0，直接从粘贴板上获取</param>
        /// <param name="b_cut">是否粘贴后把粘贴板清空</param>
        /// <returns></returns>
        public int Paste(DataGridView dgv, string pasteText, int kind, bool b_cut)
        {
            try
            {
                if (kind == 0)
                {
                    pasteText = Clipboard.GetText();
                }
                if (string.IsNullOrEmpty(pasteText))
                    return -1;
                int rowNum = 0;
                int columnNum = 0;
                //获得当前剪贴板内容的行、列数
                for (int i = 0; i < pasteText.Length; i++)
                {
                    if (pasteText.Substring(i, 1) == "\t")
                    {
                        columnNum++;
                    }
                    if (pasteText.Substring(i, 1) == "\n")
                    {
                        rowNum++;
                    }
                }
                Object[,] data;
                //粘贴板上的数据来自于EXCEL时，每行末都有\n，在DATAGRIDVIEW内复制时，最后一行末没有\n
                if (pasteText.Substring(pasteText.Length - 1, 1) == "\n")
                {
                    rowNum = rowNum - 1;
                }
                columnNum = columnNum / (rowNum + 1);
                data = new object[rowNum + 1, columnNum + 1];

                String rowStr;
                //对数组赋值
                for (int i = 0; i < (rowNum + 1); i++)
                {
                    for (int colIndex = 0; colIndex < (columnNum + 1); colIndex++)
                    {
                        rowStr = null;
                        //一行中的最后一列
                        if (colIndex == columnNum && pasteText.IndexOf("\r") != -1)
                        {
                            rowStr = pasteText.Substring(0, pasteText.IndexOf("\r"));
                        }
                        //最后一行的最后一列
                        if (colIndex == columnNum && pasteText.IndexOf("\r") == -1)
                        {
                            rowStr = pasteText.Substring(0);
                        }
                        //其他行列
                        if (colIndex != columnNum)
                        {
                            rowStr = pasteText.Substring(0, pasteText.IndexOf("\t"));
                            pasteText = pasteText.Substring(pasteText.IndexOf("\t") + 1);
                        }
                        if (rowStr == string.Empty)
                            rowStr = null;
                        data[i, colIndex] = rowStr;
                    }
                    //截取下一行数据
                    pasteText = pasteText.Substring(pasteText.IndexOf("\n") + 1);
                }
                /*检测值是否是列头*/
                /*
                //获取当前选中单元格所在的列序号
                int columnindex = dgv.CurrentRow.Cells.IndexOf(dgv.CurrentCell);
                //获取获取当前选中单元格所在的行序号
                int rowindex = dgv.CurrentRow.Index;*/
                int columnindex = -1, rowindex = -1;
                int columnindextmp = -1, rowindextmp = -1;
                if (dgv.SelectedCells.Count != 0)
                {
                    columnindextmp = dgv.SelectedCells[0].ColumnIndex;
                    rowindextmp = dgv.SelectedCells[0].RowIndex;
                }
                //取到最左上角的 单元格编号
                foreach (DataGridViewCell cell in dgv.SelectedCells)
                {
                    //dgv.Rows[cell.RowIndex].Selected = true;
                    columnindex = cell.ColumnIndex;
                    if (columnindex > columnindextmp)
                    {
                        //交换
                        columnindex = columnindextmp;
                    }
                    else
                        columnindextmp = columnindex;
                    rowindex = cell.RowIndex;
                    if (rowindex > rowindextmp)
                    {
                        rowindex = rowindextmp;
                        rowindextmp = rowindex;
                    }
                    else
                        rowindextmp = rowindex;
                }
                if (kind == -1)
                {
                    columnindex = 0;
                    rowindex = 0;
                }

                //如果行数超过当前列表行数
                if (rowindex + rowNum + 1 > dgv.RowCount)
                {
                    int mm = rowNum + rowindex + 1 - dgv.RowCount;
                    for (int ii = 0; ii < mm + 1; ii++)
                    {
                        //dgv.DataBindings.Clear();
                        DataTable dt = (DataTable)dgv.DataSource;
                        if (dt != null)
                        {
                            DataRow row = row = dt.NewRow();
                            dt.Rows.InsertAt(row, ii + rowindex + 1);
                        }

                    }
                }

                //如果列数超过当前列表列数
                if (columnindex + columnNum + 1 > dgv.ColumnCount)
                {
                    int mmm = columnNum + columnindex + 1 - dgv.ColumnCount;
                    for (int iii = 0; iii < mmm; iii++)
                    {
                       // dgv.DataBindings.Clear();
                        DataGridViewTextBoxColumn colum = new DataGridViewTextBoxColumn();
                        dgv.Columns.Insert(columnindex + 1, colum);
                    }
                }

                //增加超过的行列
                for (int j = 0; j < (rowNum + 1); j++)
                {
                    for (int colIndex = 0; colIndex < (columnNum + 1); colIndex++)
                    {
                        if (colIndex + columnindex < dgv.Columns.Count)
                        {
                            if (dgv.Columns[colIndex + columnindex].CellType.Name == "DataGridViewTextBoxCell")
                            {
                                if (dgv.Rows[j + rowindex].Cells[colIndex + columnindex].ReadOnly == false)
                                {
                                    dgv.Rows[j + rowindex].Cells[colIndex + columnindex].Value = data[j, colIndex];
                                    dgv.Rows[j + rowindex].Cells[colIndex + columnindex].Selected = true;
                                }
                            }
                        }
                    }
                }
                //清空剪切板内容
                if (b_cut)
                    Clipboard.Clear();
                return 1;
            }
            catch
            {
                return -1;
            }
        }
        #endregion
    }
}
