using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAPINT;
using SAPINT.Function;
using SAPINT.Function.Meta;

namespace SAPINT.Gui.Functions
{
    public partial class FormFunctionMetaEx : DockWindow
    {
        string _funcName = "";  //当前的函数名
        private string _systemName;//连接的SAP系统的配置名称
        private FunctionField selectedField = null;
        SAPFunctionEx function = null;
        public FormFunctionMetaEx()
        {
            InitializeComponent();
            new DgvFilterPopup.DgvFilterManager(this.dgvDetail);
            new DgvFilterPopup.DgvFilterManager(this.dgvTableContent);
            this.cbx_SystemList.DataSource = ConfigFileTool.SAPGlobalSettings.GetSAPClientList();
            this.cbx_SystemList.Text = ConfigFileTool.SAPGlobalSettings.GetDefaultSapCient();

            CDataGridViewUtils.CopyPasteDataGridView(this.dgvTableContent);

        }

        /// <summary>
        /// //从服务器加载函数的具体信息,包括每个参数的名称，数据类型
        /// 如果是结构体，还显示它的字段列表。
        /// </summary>
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
                    function = new SAPFunctionEx(_systemName, _funcName);

                    if (function.FunctionMeta == null)
                    {
                        MessageBox.Show("无法找到函数信息！！");
                        return;
                    }
                    ParseMetaData();
                    this.button2.Enabled = true;
                    this.Text = "RFC函数:" + _funcName;
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
        }
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            CleanAll();
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
        private void CleanAll()
        {
            dgvImport.DataSource = null;
            dgvExport.DataSource = null;
            dgvChanging.DataSource = null;
            dgvTables.DataSource = null;
        }
        private void ParseMetaData()
        {
            dgvImport.DataSource = function.FunctionMeta.Import;
            dgvExport.DataSource = function.FunctionMeta.Export;
            dgvChanging.DataSource = function.FunctionMeta.Changing;
            dgvTables.DataSource = function.FunctionMeta.Tables;

            dgvImport.AutoResizeColumns();
            dgvExport.AutoResizeColumns();
            dgvChanging.AutoResizeColumns();
            dgvTables.AutoResizeColumns();
            tabPage2.BringToFront();
        }
        /// <summary>
        /// //选择字段时，显示它们的具体信息
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="e"></param>
        private void SetDgvSource(ref DataGridView dgv, DataGridViewCellEventArgs e)
        {
            dgvDetail.DataSource = null;
            dgvTableContent.DataSource = null;
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            String name = dgv.Rows[e.RowIndex].Cells[FuncFieldText.Name].Value.ToString();
            String dataType = dgv.Rows[e.RowIndex].Cells[FuncFieldText.DataType].Value.ToString();
            String dataTypeName = dgv.Rows[e.RowIndex].Cells[FuncFieldText.DataTypeName].Value.ToString();
            String defaultValue = dgv.Rows[e.RowIndex].Cells[FuncFieldText.DefaultValue].Value.ToString();
            selectedField = new FunctionField(name, dataType, dataTypeName, defaultValue);
            if (String.IsNullOrEmpty(selectedField.Name))
            {
                MessageBox.Show("点击选择参数");
                return;
            }
            if (dataType == SAPDataType.STRUCTURE.ToString() || dataType == SAPDataType.TABLE.ToString())
            {
                DataTable dt = function.FunctionMeta.StructureDetail[dataTypeName];
                dgvDetail.DataSource = dt;
                dgvDetail.AutoResizeColumns();
                if (function.TableValueList.Keys.Contains(selectedField.Name))
                {
                    DataTable dtResult = function.TableValueList[selectedField.Name];
                    if (dtResult != null)
                    {
                        dgvTableContent.DataSource = dtResult;
                        dgvTableContent.AutoResizeColumns();
                    }
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
        //填充结构或表数据
        private void InputSomethingIntoTable()
        {
            if (selectedField==null)
            {
                return;
            }
            if (String.IsNullOrEmpty(selectedField.Name))
            {
                return;
            }
            DataTable dtInput = null;
            if (function.TableValueList.Keys.Contains(selectedField.Name))
            {
                dtInput = function.TableValueList[selectedField.Name];
            }
            else
            {
                if (!String.IsNullOrWhiteSpace(selectedField.DataTypeName))
                {
                    dtInput = function.TableValueList[selectedField.DataTypeName];
                }
            }
            if (dtInput == null)
            {
                MessageBox.Show("无法创建数据输入视图!");
                return;
            }
            FormTableInput formInput = new FormTableInput();
            if (selectedField.DataType == SAPDataType.STRUCTURE.ToString())
            {
                formInput.DataType = SAPDataType.STRUCTURE.ToString();
            }
            else if (selectedField.DataType == SAPDataType.TABLE.ToString())
            {
                formInput.DataType = SAPDataType.TABLE.ToString();
            }
            formInput.DgvSource = dtInput;
            formInput.InitializeDataSource();
            formInput.ShowDialog();
            function.TableValueList[selectedField.Name] = formInput.DgvSource;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            InputSomethingIntoTable();
        }
        private void doSomethingWhenSuccess()
        {
            //根据返回的结果处理控件
            foreach (var item in function.TableValueList)
            {
                if (item.Value.Rows.Count >= 0)
                {
                    foreach (DataGridViewRow row in dgvTables.Rows)
                    {
                        if (row.Cells[FuncFieldText.Name].Value.ToString() == item.Key)
                        {
                            row.Cells[FuncFieldText.DataTypeName].Style.BackColor = Color.Green;
                            row.Cells[FuncFieldText.DefaultValue].Value = "一共有" + item.Value.Rows.Count + "行数据";
                            break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 执行函数
        /// </summary>
        private void ExcuteFunction()
        {
            if (function.FunctionMeta == null)
            {
                MessageBox.Show("请先获取函数信息！！");
                return;
            }
            try
            {
                function.Excute();
                doSomethingWhenSuccess();
                MessageBox.Show("成功调用！！！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ExcuteFunction();
        }

        private void btnSaveToDb_Click(object sender, EventArgs e)
        {
            if (this.selectedField == null)
            {
                return;
            }
            if (dgvTableContent.DataSource != null)
            {
                var dt = dgvTableContent.DataSource as DataTable;
                if (dt != null)
                {
                    SAPINT.Gui.DataBase.FormSaveDataTable formSaveDt = new DataBase.FormSaveDataTable();
                    formSaveDt.Dt = dt;
                    formSaveDt.SapSystemName = this._systemName;
                    formSaveDt.SapTableName = selectedField.Name;
                    formSaveDt.SapStrutureName = selectedField.DataTypeName;

                    formSaveDt.Show();
                }
            }

        }

    }
}
