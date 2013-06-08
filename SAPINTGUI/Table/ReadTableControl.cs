using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAPINT.Utils;
using System.Xml.Serialization;
using System.IO;
using SAPINT;
using System.Threading;
namespace SAPINTGUI
{
    public delegate void EventGetSAPTable(ReadTableControl sender, DataTable resultdt);
    public partial class ReadTableControl : UserControl
    {
        public event EventGetSAPTable EventGetTable;//当读取到数据时，通过监视者。

        private ReadTable dt;           //读取实例
        string _tableName = "";  //当前的表名
        List<TableInfo> tablelist;  //缓存列表
        private string _systemName;//连接的SAP系统的配置名称
        string filepath = @"C:\ReadTable.xml"; //配置文件的路径。
        public event DelegateMessage EventMessage;
        public String TableName
        {
            get
            {
                return _tableName;
            }
        }
        public String SystemName
        {
            get
            {
                return _systemName;
            }
        }
        public DataTable ResultAsTable
        {
            private set;
            get;
        }
        public void SendMessage(String message)
        {
            if (this.EventMessage != null)
            {
                EventMessage(message);
            }
        }
        public ReadTableControl()
        {
            InitializeComponent();
            rowNum.Text = "500";
            tablelist = new List<TableInfo>();
            this.cbx_systemlist.DataSource = null;
            this.cbx_systemlist.DataSource = ConfigFileTool.SAPGlobalSettings.GetSAPClientList();
            cbx_systemlist.Text = ConfigFileTool.SAPGlobalSettings.GetDefaultSapCient();
            new DgvFilterPopup.DgvFilterManager(this.dataGridView1);
            new DgvFilterPopup.DgvFilterManager(this.dataGridView2);
            CDataGridViewUtils.CopyPasteDataGridView(this.dataGridView1);
            CDataGridViewUtils.CopyPasteDataGridView(this.dataGridView2);
        }
        private bool check()
        {
            this._systemName = this.cbx_systemlist.Text.ToUpper().Trim();
            this._delimiter = this.txtDelimiter.Text.Trim();
            if (string.IsNullOrEmpty(_systemName))
            {
                MessageBox.Show("请选择系统");
                return false;
            }
            this._tableName = this.txtTableName.Text.Trim().ToUpper();
            if (string.IsNullOrEmpty(this._tableName))
            {
                MessageBox.Show("请指定表名");
                return false;
            }
            if (!String.IsNullOrEmpty(rowNum.Text))
            {

                if (Convert.ToInt32(rowNum.Text) <= 0)
                {
                    MessageBox.Show("指定行数量");
                    return false;
                }

            }
            else
            {
                MessageBox.Show("指定行数量");
                return false;
            }
            return true;
        }
        //运行按钮
        private void button1_Click(object sender, EventArgs e)
        {
            loadTable();
        }

        private void loadTable()
        {
            if (!check())
            {
                return;
            }
            Parent.Text = _tableName;
            try
            {

                loadTableData();
                SaveFieldsAndOptiontoMemory(this.txtTableName.Text.Trim().ToUpper());
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        //加载表数据
        void loadTableData()
        {
            try
            {
                SendMessage("开始");
                dt = new ReadTable(_systemName);
                dt.EventMessage += dt_eventMessage;
                // dt.SetCustomFunctionName("Z_XTRACT_IS_TABLE");
                dt.SetCustomFunctionName("Z_SAPINT_READ_TABLE2");
                dt.TableName = _tableName;
                dt.Delimiter = _delimiter;
                //  dt.Fields.Clear();
                // dt.Options.Clear();
                //从界面上加载条件与字段列表
                SendMessage("加载字段列表");
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells["FieldName"].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells[0].Value != null)
                        {
                            if ((bool)dataGridView1.Rows[i].Cells[0].Value == true)
                            {
                                string s = dataGridView1.Rows[i].Cells["FieldName"].Value.ToString();
                                if (!string.IsNullOrEmpty(s))
                                {
                                    dt.AddField(s);
                                }
                            }
                        }
                    }
                }
                SendMessage("加载条件");
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (dataGridView2[0, i].Value != null)
                    {
                        string s = dataGridView2[0, i].Value.ToString();
                        if (!string.IsNullOrEmpty(s))
                        {
                            dt.AddCriteria(s);
                        }
                    }
                }
                dt.RowCount = Convert.ToInt32(rowNum.Text);
                SendMessage("开始异步调用");
                try
                {
                    Thread thread = new Thread(new ThreadStart(excute));
                    thread.Start();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void excute()
        {

            dt.Run();
            ResultAsTable = dt.Result;
            if (EventGetTable != null)
            {
                EventGetTable(this, ResultAsTable);
            }

        }
        void dt_eventMessage(string message)
        {
            SendMessage(message);
        }
        //保存当前的字段与条件到内存中。
        bool SaveFieldsAndOptiontoMemory(string TableName)
        {
            // dt.Fields.Cast<ReadTableField>().ToList().ForEach(I=> info.Fields.Add(I));
            //在当前激活的工作表上存放数据
            if (string.IsNullOrEmpty(TableName))
            {
                return false;
            }
            TableInfo info = new TableInfo();
            info.Name = TableName;
            foreach (DataGridViewRow item in this.dataGridView1.Rows)
            {
                if (item.Cells["FieldName"].Value != null)
                {
                    info.Fields.Add(new ReadTableField
            {
                FieldName = item.Cells["FieldName"].Value == null ? "" : item.Cells["FieldName"].Value.ToString(),
                FieldText = item.Cells["FieldText"].Value == null ? "" : item.Cells["FieldText"].Value.ToString(),
                CheckTable = item.Cells["CheckTable"].Value == null ? "" : item.Cells["CheckTable"].Value.ToString(),
                Active = item.Cells[0].Value == null ? false : (bool)item.Cells[0].Value
            });
                }
            }
            foreach (DataGridViewRow item in this.dataGridView2.Rows)
            {
                if (item.Cells["Option"].Value != null)
                {
                    info.Options.Add(item.Cells["Option"].Value.ToString());
                }
            }
            TableInfo info1 = tablelist.Find(X => X.Name == _tableName);
            if (info1 != null)
            {
                tablelist.Remove(info1);
            }
            tablelist.Add(info);
            return true;
        }
        bool loadFieldsAndOptionFromMemory(string tableName)
        {
            tableName = tableName.ToUpper();
            //按照表名加载字段列表与条件列表
            TableInfo info = tablelist.Find(x => x.Name == tableName);
            if (info != null)
            {
                this.dataGridView1.Rows.Clear();
                this.dataGridView2.Rows.Clear();
                foreach (SAPINT.Utils.ReadTableField item in info.Fields)
                {
                    this.dataGridView1.Rows.Add(item.Active, item.FieldName, item.FieldText, item.CheckTable);
                }
                foreach (var item in info.Options)
                {
                    this.dataGridView2.Rows.Add(item.ToString());
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        void ws_Deactivate()
        {
            //if (ws!=null)
            //{
            //        SaveFieldsAndOptiontoMemory(_tableName);
            //}

        }
        ////工作表激活时加载内存中的条件与字段列表
        //void ws_ActivateEvent()
        //{
        //    if (ws!=null)
        //    {
        //        _tableName = Globals.ThisAddIn.Application.ActiveSheet.Name;
        //        this.txtTableName.Text = _tableName;
        //        this.loadFieldsAndOptionFromMemory(_tableName);
        //    }

        //}

        //加载字段列表
        private void loadFields_Click(object sender, EventArgs e)
        {
            try
            {
                if (!check())
                {
                    return;
                }
                dt = new ReadTable(_systemName.ToUpper().Trim());
                dt.TableName = _tableName;
                ReadTableFieldCollection fields = dt.GetAllFieldsOfTable();
                if (fields == null || fields.Count == 0)
                {
                    return;
                }
                this.dataGridView1.Rows.Clear();
                for (int i = 0; i < fields.Count; i++)
                {
                    this.dataGridView1.Rows.Add(fields[i].Active, fields[i].FieldName, fields[i].FieldText, fields[i].CheckTable);
                }
                dataGridView1.AutoResizeColumns();
                //  saveContext();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        //把字段与列表保存到本地
        private void btn_saveInfo_Click(object sender, EventArgs e)
        {
            if (tablelist == null)
            {
                return;
            }
            //if (string.IsNullOrEmpty(Globals.ThisAddIn.Application.ActiveWorkbook.Path))
            //{
            //    MessageBox.Show("先保存工作薄");
            //    return;
            //}
            //if (!System.IO.File.Exists(Globals.ThisAddIn.Application.ActiveWorkbook.FullName))
            //{
            //    MessageBox.Show("无法找到工作薄");
            //    return;
            //}
            //filepath =  @"C:\ReadTable.xml";
            try
            {
                XmlSerializer ser = new XmlSerializer(tablelist.GetType());
                ser.Serialize(new FileStream(filepath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite), tablelist);
                MessageBox.Show("保存成功");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        private void btn_loadInfo_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(Globals.ThisAddIn.Application.ActiveWorkbook.Path))
            //{
            //    MessageBox.Show("工作薄未保存");
            //    return;
            //}
            //if (!System.IO.File.Exists(Globals.ThisAddIn.Application.ActiveWorkbook.FullName))
            //{
            //    MessageBox.Show("无法找到工作薄");
            //    return;
            //}
            //filepath = Globals.ThisAddIn.Application.ActiveWorkbook.FullName + ".xml";
            if (!System.IO.File.Exists(filepath))
            {
                MessageBox.Show("未有配置文件");
                return;
            }
            try
            {
                XmlSerializer ser = new XmlSerializer(tablelist.GetType());
                tablelist = ser.Deserialize(new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) as List<TableInfo>;
                if (!string.IsNullOrEmpty(this.txtTableName.Text.ToUpper()))
                {
                    this.loadFieldsAndOptionFromMemory(this.txtTableName.Text.ToUpper());
                }
                //在当前激活的工作表上存放数据
                //ws = Globals.Factory.GetVstoObject(Globals.ThisAddIn.Application.ActiveWorkbook.ActiveSheet);
                //ws.ActivateEvent += new Microsoft.Office.Interop.Excel.DocEvents_ActivateEventHandler(ws_ActivateEvent);
                MessageBox.Show("恢复成功");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        //尝试从内存中恢复
        private void btn_refreshInfo_Click(object sender, EventArgs e)
        {
            if (this.loadFieldsAndOptionFromMemory(txtTableName.Text.ToUpper()))
            {
                MessageBox.Show("加载成功");
            }
            else
            {
                MessageBox.Show("加载失败");
            }
        }
        //private void cbx_systemlist_Enter(object sender, EventArgs e)
        //{
        //    cbx_systemlist.DataSource = null;
        //    cbx_systemlist.DataSource = SAPINT.SAPLogonConfigList.SystemNameList;
        //}
        //private void cbx_systemlist_MouseClick(object sender, MouseEventArgs e)
        //{
        //    this.cbx_systemlist.DataSource = null;
        //    this.cbx_systemlist.DataSource = SAPINT.SAPLogonConfigList.SystemNameList;
        //}
        //批量取消选中
        private void btnUnSelect_Click(object sender, EventArgs e)
        {
            //this.dataGridView1.Rows.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected == true)
                {
                    if (row.Cells["FieldName"].Value != null)
                    {
                        if ((bool)row.Cells[0].Value == true)
                        {
                            row.Cells[0].Value = false;
                        }
                    }
                }
            }
        }
        //批量选择字段
        private void clearFields_Click(object sender, EventArgs e)
        {
            //this.dataGridView1.Rows.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected == true)
                {
                    if (row.Cells["FieldName"].Value != null)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            if ((bool)row.Cells[0].Value == false)
                            {
                                row.Cells[0].Value = true;
                            }
                        }

                    }
                }
            }
        }
        private void btnCacheMe_Click(object sender, EventArgs e)
        {
            SaveFieldsAndOptiontoMemory(this.txtTableName.Text.Trim().ToUpper());
        }


        public string _delimiter { get; set; }


        private void cbx_systemlist_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this._systemName = cbx_systemlist.Text;
            EventGetTable(this, null);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex != 3)
            {
                return;
            }
            DataGridViewCell cell = this.dataGridView1[e.ColumnIndex, e.RowIndex];
            if (cell.Value != null)
            {
                if (!string.IsNullOrWhiteSpace(cell.Value.ToString()))
                {
                    this.txtTableName.Text = cell.Value.ToString();
                    loadTable();
                }
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Modifiers == Keys.Control)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.C:
                            // CDataGridViewUtils.CopyToClipboard(dataGridView1);
                            break;
                        case Keys.V:
                            // PasteClipboardValue(dgvBatchInput  ,false);
                            CDataGridViewUtils.Paste(dataGridView1, "", 0, false);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Copy/paste operation failed. " + ex.Message, "Copy/Paste", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}
