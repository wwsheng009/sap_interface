using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Text.RegularExpressions;
namespace SAPINTGUI
{
    public static class CDataGridViewUtils
    {
        public static void SearchDataGridView(this DataGridView dgv, string searchString = null)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                FormSearchText form = new FormSearchText();
                form.ShowDialog();
                searchString = form.Result;
            }
            if (string.IsNullOrEmpty(searchString))
            {
                return;
            }
            if (dgv.Rows.Count == 0 || dgv.ColumnCount == 0)
            {
                return;
            }
            bool rowFound = false;

            if (dgv.DataSource is DataTable)
            {
                var dt = dgv.DataSource as DataTable;
                if (!dt.Columns.Contains("Match_Result"))
                {
                    dt.Columns.Add("Match_Result", typeof(String));
                    dt.Columns["Match_Result"].SetOrdinal(0);
                    dgv.DataSource = null;
                    dgv.DataSource = dt;
                }

            }
            else
            {
                if (!dgv.Columns.Contains("Match_Result"))
                {
                    DataGridViewCell cell = new DataGridViewTextBoxCell();
                    DataGridViewColumn column = new DataGridViewColumn();
                    column.CellTemplate = cell;
                    column.Name = "Match_Result";
                    column.ValueType = typeof(bool);

                    dgv.Columns.Add(column);
                    column.DisplayIndex = 0;

                }

            }

            foreach (DataGridViewRow row in dgv.Rows)
            {
                rowFound = false;
                row.Cells["Match_Result"].Value = "";
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (rowFound == true)
                    {
                        continue;
                    }
                    if (cell.Value == null)
                    {
                        continue;
                    }
                    var value = cell.Value.ToString();

                    if (Regex.IsMatch(value, searchString))
                    {
                        // cell.Style.ForeColor = System.Drawing.Color.Blue;
                        rowFound = true;
                        //cell.Style.BackColor = System.Drawing.Color.Black;
                        break;
                    }
                    else
                    {
                        //  cell.Style.ForeColor = System.Drawing.Color.Black;
                    }

                }


                if (rowFound == true)
                {

                    row.Cells["Match_Result"].Value = "match";

                    row.Selected = true;
                }
                //else
                //{
                //    row.Cells["Match_Result"].Value = "";
                //    //row.Cells["SearchResult"].Value = "UnMatch";
                //}
                // dgv.Sort(dgv.Columns["SearchResult"],System.ComponentModel.ListSortDirection.Ascending);
            }
            dgv.Refresh();
        }

        public static void CopyPasteDataGridView(DataGridView dgv)
        {

            dgv.KeyDown += dgv_KeyDown;
        }

        static void dgv_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.Modifiers == Keys.Control)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.C:
                            //  CDataGridViewUtils.CopyToClipboard(dataGridView2);
                            break;
                        case Keys.V:
                            // PasteClipboardValue(dgvBatchInput  ,false);
                            Paste((DataGridView)sender, "", 0, false);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Copy/paste operation failed. " + ex.Message, "Copy/Paste", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public static void UnSelectRows(DataGridView dgv)
        {
            //this.dataGridView1.Rows.Clear();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Selected == true)
                {
                    if (row.Cells[1].Value != null)
                    {
                        if (row.Cells[0].Value == DBNull.Value)
                        {
                            row.Cells[0].Value = false;
                            continue;
                        }
                        if ((bool)row.Cells[0].Value == true)
                        {
                            row.Cells[0].Value = false;
                        }
                    }
                }
            }
        }
        public static void SelectRows(DataGridView dgv)
        {

            //this.dataGridView1.Rows.Clear();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Selected == true)
                {
                    if (row.Cells[1].Value != null)
                    {
                        var value = row.Cells[0].Value;

                        if (String.IsNullOrEmpty(value.ToString()))
                        {
                            row.Cells[0].Value = false;
                        }
                        if (value==DBNull.Value)
                        {
                            row.Cells[0].Value = true;
                            continue;
                        }
                        if ((bool)value == false)
                        {
                            row.Cells[0].Value = true;
                        }
                    }
                }
            }
        }
        public static void CopyToClipboard(DataGridView dgv)
        {
            //Copy to clipboard
            DataObject dataObj = dgv.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
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
        public static int Paste(DataGridView dgv, string pasteText, int kind, bool b_cut)
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
                        else
                        {
                            dgv.Rows.Add();
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
