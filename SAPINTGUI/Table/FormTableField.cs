using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAPINT.RFCTable;
using WeifenLuo.WinFormsUI.Docking;
using SAPINT.Utils;

namespace SAPINT.Gui.Table
{
    public delegate void DelegateTableField(FormTableField FormtableField);
    public partial class FormTableField : DockWindow
    {
        string m_TableName = "";  //当前的表名
        private string m_SystemName;//连接的SAP系统的配置名称
        //private List<TableInfo> _tablelist;  //缓存表字段列表
        private DataTable m_FieldsDt = null;
        private List<RFCTableInfo> m_RfcTableList = new List<RFCTableInfo>();

        private bool m_SortByPosition = false;
        public event DelegateTableField EventReadTableField = null;

        public FormTableField()
        {
            InitializeComponent();
            //_tablelist = new List<TableInfo>();
            SAPINT.Gui.CDataGridViewUtils.CopyPasteDataGridView(dataGridView1);
            
            new DgvFilterPopup.DgvFilterManager(dataGridView1);

            this.cbx_systemlist.DataSource = ConfigFileTool.SAPGlobalSettings.GetSAPClientList();
            this.cbx_systemlist.Text = ConfigFileTool.SAPGlobalSettings.GetDefaultSapCient();


            this.listBox1.DoubleClick += listBox1_DoubleClick;
            this.listBox1.KeyDown += listBox1_KeyDown;
        }
        public List<RFCTableInfo> TableList
        {
            get
            {
                return this.m_RfcTableList;
            }
        }
        public string SystemName
        {
            private set
            {
                this.m_SystemName = value;
            }
            get
            {
                return this.m_SystemName;
            }
        }


        private bool check()
        {
            this.m_SystemName = this.cbx_systemlist.Text.ToUpper().Trim();

            if (string.IsNullOrEmpty(m_SystemName))
            {
                MessageBox.Show("请选择系统");
                return false;
            }

            this.m_TableName = this.txtTableName.Text.Trim().ToUpper();
            if (string.IsNullOrEmpty(this.m_TableName))
            {
                MessageBox.Show("请指定表名");
                return false;
            }

            return true;
        }

        /// <summary>
        /// 从SAP系统中加载表的定义信息。
        /// </summary>
        private bool GetTableDefinition()
        {
            if (!check())
            {
                return false;
            }
            try
            {
                this.dataGridView1.DataSource = null;
                var _rfctable = new RFCTableInfo();
                m_FieldsDt = _rfctable.GetTableDefinitionDt(m_SystemName, m_TableName);
                this.dataGridView1.DataSource = m_FieldsDt;
                this.Text = "表：" + m_TableName;
                if (m_FieldsDt != null)
                {
                    if (m_FieldsDt.Rows.Count > 0)
                    {
                        this.toolStripStatusLabel1.Text = string.Format("{0} 读取成功", m_TableName);
                        return true;
                    }
                    else
                    {
                        this.toolStripStatusLabel1.Text = string.Format("{0} 无可用字", m_TableName);
                        return false;
                    }

                }
                else
                {

                    MessageBox.Show("无法读取表信息");
                    return false;
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);

            }
            return false;
        }
        /// <summary>
        ///读取表的所有字段列表 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadSAPTable_Click(object sender, EventArgs e)
        {

            if (GetTableDefinition())
            {
                UpdateDgvDisplay();
                SaveFieldsToCache();
            }

        }

        private void UpdateDgvDisplay()
        {

            // DgvFilterPopup.DgvFilterManager fm = new DgvFilterPopup.DgvFilterManager(this.dataGridView1);

            if (dataGridView1.Columns.Contains("POSITION"))
            {
                this.dataGridView1.Columns["POSITION"].DisplayIndex = 1;
            }

            if (dataGridView1.Columns.Contains("FIELDNAME"))
            {
                this.dataGridView1.Columns["FIELDNAME"].DisplayIndex = 2;
            }
            if (dataGridView1.Columns.Contains("TABNAME"))
            {
                this.dataGridView1.Columns["TABNAME"].DisplayIndex = 3;
            }
            if (dataGridView1.Columns.Contains("FIELDTEXT"))
            {
                this.dataGridView1.Columns["FIELDTEXT"].DisplayIndex = 4;
            }

            if (dataGridView1.Columns.Contains("DOTNETTYPE"))
            {
                //this.dataGridView1.Columns.Remove("DOTNETTYPE");
                this.dataGridView1.Columns["DOTNETTYPE"].DisplayIndex = 5;
            }
            if (dataGridView1.Columns.Contains("DBTYPE"))
            {
                this.dataGridView1.Columns.Remove("DBTYPE");
            }
            if (dataGridView1.Columns.Contains("SQLTYPE"))
            {
                this.dataGridView1.Columns.Remove("SQLTYPE");
            }

            this.dataGridView1.AutoResizeColumns();

        }
        /// <summary>
        /// 标记已经选中的行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            SAPINT.Gui.CDataGridViewUtils.SelectRows(dataGridView1);
            SaveFieldsToCache();
        }

        //保存当前的字段与条件到内存中。
        private bool SaveFieldsToCache(string TableName = null, DataTable dt = null)
        {
            if (string.IsNullOrEmpty(TableName))
            {
                this.m_TableName = this.txtTableName.Text.Trim().ToUpper();
                TableName = this.m_TableName;
                
            }
            if (string.IsNullOrEmpty(TableName))
            {
                MessageBox.Show("表名不能为空");
                return false;
            }

            if (dt == null)
            {
                dt = this.dataGridView1.DataSource as DataTable;
            }
            if (dt == null)
            {
                toolStripStatusLabel1.Text = "DataTable 为空值";
                return false;
            }

            RFCTableInfo info2 = m_RfcTableList.Find(x => x.Name == TableName);
            if (info2 != null)
            {
                m_RfcTableList.Remove(info2);
            }

            var _rfctable = new RFCTableInfo();
            _rfctable.Fields = dt.ToList<TableField>() as List<TableField>;
            //_rfctable.TransformDataType();
            _rfctable.Name = TableName;
            m_RfcTableList.Add(_rfctable);

            int pos = 1;
            foreach (var item in m_RfcTableList)
            {
                foreach (var field in item.Fields)
                {
                    field.POSITION2 = string.Empty;
                    if (field.Selected)
                    {
                        field.POSITION2 = pos.ToString().PadLeft(4, '0');
                        pos++;
                    }
                }
            }
            if (!this.listBox1.Items.Contains(this.m_TableName))
            {
                this.listBox1.Items.Add(this.m_TableName);
            }
            this.toolStripStatusLabel1.Text = m_TableName + "保存成功";
            return true;
        }

        private bool LoadFieldsFromCache(string tableName)
        {
            this.dataGridView1.DataSource = null;
            var info = new RFCTableInfo();
            info = m_RfcTableList.Find(x => x.Name == tableName);
            if (info != null)
            {
                this.dataGridView1.DataSource = info.Fields.ToDataTable<TableField>();

                UpdateDgvDisplay();
                this.txtTableName.Text = tableName;
                return true;
            }
            else
            {
                return false;
            }


        }

        /// <summary>
        /// 从缓存中删除字段列表。
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        private bool RemoveFieldsFromCache(string tableName = null)
        {
            if (string.IsNullOrEmpty(tableName))
            {
                tableName = this.m_TableName;
            }
            if (string.IsNullOrEmpty(tableName))
            {
                return false;
            }

            RFCTableInfo info = m_RfcTableList.Find(x => x.Name == tableName);
            if (info != null)
            {
                m_RfcTableList.Remove(info);
                this.toolStripStatusLabel1.Text = tableName + "删除成功";
                return true;
            }
            else
            {
                this.toolStripStatusLabel1.Text = tableName + "删除失败";
                return false;
            }
        }

        /// <summary>
        /// 取消标识
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnSelect_Click(object sender, EventArgs e)
        {
            SAPINT.Gui.CDataGridViewUtils.UnSelectRows(dataGridView1);
            SaveFieldsToCache();
        }

        private void Notify()
        {
            if (EventReadTableField != null)
            {
                EventReadTableField(this);
            }
        }

        private void btnCacheMe_Click(object sender, EventArgs e)
        {

            SaveFieldsToCache();

        }

        private void btnLoadCache_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedItem != null)
            {
                this.m_TableName = this.listBox1.SelectedItem as string;
                
                LoadFieldsFromCache(m_TableName);
            }


        }

        private void btnRemoveCache_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedItem != null)
            {
                this.m_TableName = this.listBox1.SelectedItem as string;
                if (true == RemoveFieldsFromCache(m_TableName))
                {
                    this.dataGridView1.DataSource = null;
                    this.listBox1.Items.Remove(this.listBox1.SelectedItem);
                }

            }

        }

        private void cbx_systemlist_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            this.SystemName = cbx_systemlist.Text;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.dataGridView1.SearchDataGridView();
        }

        private void btnSearch2_Click(object sender, EventArgs e)
        {
            FormSearchText2 form = new FormSearchText2();
            form.dt = this.dataGridView1.DataSource as DataTable;
            form.Show();

        }


        void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (listBox1.SelectedItems.Count > 0)
                    {
                        for (int x = listBox1.SelectedIndices.Count - 1; x >= 0; x--)
                        {
                            int idx = listBox1.SelectedIndices[x];
                            if (RemoveFieldsFromCache(this.listBox1.Items[idx] as string))
                            {
                                listBox1.Items.RemoveAt(idx);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        void listBox1_DoubleClick(object sender, EventArgs e)
        {
            LoadFieldsFromCache(this.listBox1.SelectedItem as string);
        }
    }
}
