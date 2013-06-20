using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using SAPINT.Utils;

namespace SAPINT.Gui.Table
{
    public delegate void DelegateReadSAPTable(FormTableRead sender, DataTable resultdt);
    public partial class FormTableRead : ToolWindow
    {

        private ReadTable m_dt = null;           //读取实例
        private string m_tableName = string.Empty;  //当前的表名
        private string m_systemName = string.Empty;//连接的SAP系统的配置名称
        private string m_filepath = @"C:\temp\ReadTable.xml"; //配置文件的路径。
        private string m_delimiter { get; set; }

        public event DelegateReadSAPTable EventGetTable;//当读取到数据时，通过监视者。
        public event DelegateMessage EventMessage;
        public List<TableInfo> Tablelist = null;  //缓存列表

        public String TableName
        {
            get
            {
                return m_tableName;
            }
        }
        public String SystemName
        {
            get
            {
                return m_systemName;
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
        public FormTableRead()
        {
            InitializeComponent();
            InitControls();
            
        }
        private void InitControls()
        {
            rowNum.Text = "50";

            Tablelist = new List<TableInfo>();

            this.cbx_systemlist.DataSource = null;
            this.cbx_systemlist.DataSource = ConfigFileTool.SAPGlobalSettings.GetSAPClientList();
            this.cbx_systemlist.Text = ConfigFileTool.SAPGlobalSettings.GetDefaultSapCient();

            new DgvFilterPopup.DgvFilterManager(this.dataGridView1);
            new DgvFilterPopup.DgvFilterManager(this.dataGridView2);

            CDataGridViewUtils.CopyPasteDataGridView(this.dataGridView1);
            CDataGridViewUtils.CopyPasteDataGridView(this.dataGridView2);


            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView2.CellValueChanged += dataGridView2_CellValueChanged;
            //
            this.listBox1.DoubleClick += listBox1_DoubleClick;
            this.listBox1.KeyDown += listBox1_KeyDown;
            this.listBox1.SelectionMode = SelectionMode.MultiExtended;

            if (File.Exists(m_filepath))
            {
                RestoreFields_And_Condition();
            }
            this.FormClosed += FormTableRead_FormClosed;

            this.txtTableName.TextChanged += txtTableName_TextChanged;
            this.txtDelimiter.Items.AddRange(new object[] {
            "",
            "★",
            "☆",
            "♀",
            "卐",
            "※",
            "◆",
            "◇",
            "◣",
            "◢",
            "◥",
            "▲",
            "▼",
            "△",
            "▽",
            "⊿",
            "◤",
            "◥",
            "▆",
            "▇",
            "█",
            "█",
            "■",
            "▓",
            "〓",
            "≡",
            "╝",
            "╚",
            "╔",
            "╗",
            "╬",
            "═",
            "╓",
            "╩",
            "┠",
            "┯",
            "┷",
            "┏",
            "┓",
            "┗",
            "┛",
            "┳",
            "⊥",
            "﹃",
            "﹄",
            "┐",
            "└",
            "┘",
            "∟",
            "「",
            "」",
            "↑",
            "↓",
            "→",
            "←",
            "↘",
            "↙",
            "♀",
            "♂",
            "┇",
            "┅",
            "﹉",
            "﹊",
            "﹍",
            "﹎",
            "╭"});

        }

        void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            AddFieldsAndConditionToCache();
        }

        void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            AddFieldsAndConditionToCache();
        }

        void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {

                RemoveFieldsFromCache();
            }
        }

        void txtTableName_TextChanged(object sender, EventArgs e)
        {
            m_tableName = txtTableName.Text.Trim();
            if (!string.IsNullOrEmpty(m_tableName))
            {
                LoadFieldsFromCache(m_tableName);
            }
            //throw new NotImplementedException();
        }

        void FormTableRead_FormClosed(object sender, FormClosedEventArgs e)
        {
            AddFieldsAndConditionToCache();
            BackUpField_And_Condition();
        }

        void listBox1_DoubleClick(object sender, EventArgs e)
        {
            LoadFieldsFromCache(listBox1.SelectedItem as string);
        }
        private bool check()
        {
            this.m_systemName = this.cbx_systemlist.Text.ToUpper().Trim();
            this.m_delimiter = this.txtDelimiter.Text.Trim();
            if (string.IsNullOrEmpty(m_systemName))
            {
                MessageBox.Show("请选择系统");
                return false;
            }
            this.m_tableName = this.txtTableName.Text.Trim().ToUpper();
            if (string.IsNullOrEmpty(this.m_tableName))
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
        private void btRun_Click(object sender, EventArgs e)
        {
            loadTable();
        }

        private void loadTable()
        {
            if (!check())
            {
                return;
            }
            Parent.Text = m_tableName;
            try
            {

                loadTableData();
                AddFieldsAndConditionToCache();
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
                m_dt = new ReadTable(m_systemName);
                m_dt.EventMessage += dt_eventMessage;
                // dt.SetCustomFunctionName("Z_XTRACT_IS_TABLE");
                m_dt.SetCustomFunctionName("Z_SAPINT_READ_TABLE2");
                m_dt.TableName = m_tableName;
                m_dt.Delimiter = m_delimiter;
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
                                    m_dt.AddField(s);
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
                            m_dt.AddCriteria(s);
                        }
                    }
                }
                m_dt.RowCount = Convert.ToInt32(rowNum.Text);
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

            m_dt.Run();
            ResultAsTable = m_dt.Result;
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
        bool SaveFieldsAndOptiontoCache(string TableName)
        {
            // dt.Fields.Cast<ReadTableField>().ToList().ForEach(I=> info.Fields.Add(I));
            //在当前激活的工作表上存放数据
            if (string.IsNullOrEmpty(TableName))
            {
                return false;
            }
            TableInfo info = new TableInfo();
            info.Name = TableName;
            var rowsCount = 0;
            int.TryParse(this.rowNum.Text, out rowsCount);
            info.RowCount = rowsCount;
            info.Delimiter = this.txtDelimiter.Text;

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
            TableInfo info1 = Tablelist.Find(X => X.Name == m_tableName);
            if (info1 != null)
            {
                Tablelist.Remove(info1);
            }
            Tablelist.Add(info);
            return true;
        }
        bool LoadFieldsAndOptionFromCache(string tableName)
        {
            tableName = tableName.Trim().ToUpper();
            this.dataGridView1.Rows.Clear();
            this.dataGridView2.Rows.Clear();


            //按照表名加载字段列表与条件列表
            TableInfo info = Tablelist.Find(x => x.Name == tableName);
            if (info != null)
            {
                if (String.IsNullOrEmpty(this.txtTableName.Text))
                {
                    this.txtTableName.Text = m_tableName;
                }
                this.rowNum.Text = info.RowCount.ToString();
                this.txtDelimiter.Text = info.Delimiter;
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

        private void loadFields_Click(object sender, EventArgs e)
        {
            try
            {
                if (!check())
                {
                    return;
                }
                this.dataGridView1.Rows.Clear();
                m_dt = new ReadTable(m_systemName.ToUpper().Trim());
                m_dt.TableName = m_tableName;
                ReadTableFieldCollection fields = m_dt.GetAllFieldsOfTable();
                if (fields == null || fields.Count == 0)
                {
                    return;
                }

                for (int i = 0; i < fields.Count; i++)
                {
                    this.dataGridView1.Rows.Add(fields[i].Active, fields[i].FieldName, fields[i].FieldText, fields[i].CheckTable);
                }
                dataGridView1.AutoResizeColumns();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void BackUpField_And_Condition()
        {
            if (Tablelist == null)
            {
                return;
            }
            try
            {
                XmlSerializer ser = new XmlSerializer(Tablelist.GetType());
                ser.Serialize(new FileStream(m_filepath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite), Tablelist);
                this.toolStripStatusLabel1.Text = "字段与条件备份成功" + m_filepath;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void RestoreFields_And_Condition()
        {
            if (!System.IO.File.Exists(m_filepath))
            {
                this.toolStripStatusLabel1.Text = "没有发现备份文件" + m_filepath;
                return;
            }
            try
            {
                XmlSerializer ser = new XmlSerializer(Tablelist.GetType());
                Tablelist = ser.Deserialize(new FileStream(m_filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) as List<TableInfo>;
                this.listBox1.Items.Clear();
                var _tableName = this.txtTableName.Text.ToUpper();
                foreach (var item in Tablelist)
                {
                    this.listBox1.Items.Add(item.Name);
                    if (String.IsNullOrEmpty(_tableName))
                    {
                        _tableName = item.Name;

                    }
                }

                this.LoadFieldsAndOptionFromCache(_tableName);

                this.toolStripStatusLabel1.Text = "字段与条件恢复成功!";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        private void btn_loadInfo_Click(object sender, EventArgs e)
        {
            RestoreFields_And_Condition();
        }

        private void LoadFieldsFromCache(string table_Name = null)
        {
            //if (listBox1.SelectedItem == null)
            //{
            //    MessageBox.Show("请选择一个表");
            //    return;
            //}
            if (String.IsNullOrEmpty(table_Name))
            {
                table_Name = this.listBox1.SelectedItem as string;

            }

            if (this.LoadFieldsAndOptionFromCache(table_Name))
            {
                this.toolStripStatusLabel1.Text = String.Format("表{0}的字段与条件加载成功", table_Name);

            }
            else
            {
                this.toolStripStatusLabel1.Text = String.Format("表{0}的字段与条件加载失败", table_Name);
            }
            this.txtTableName.Text = table_Name;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            CDataGridViewUtils.SelectRows(dataGridView1);
        }

        private void btnUnSelect_Click(object sender, EventArgs e)
        {
            CDataGridViewUtils.UnSelectRows(dataGridView1);
        }

        private void btnCacheMe_Click(object sender, EventArgs e)
        {
            AddFieldsAndConditionToCache();
        }
        private void AddFieldsAndConditionToCache()
        {
            m_tableName = this.txtTableName.Text.Trim().ToUpper();

            if (SaveFieldsAndOptiontoCache(m_tableName))
            {
                if (!this.listBox1.Items.Contains(m_tableName))
                {
                    listBox1.Items.Add(m_tableName);
                }
                toolStripStatusLabel1.Text = string.Format("表{0}字段与条件已缓存", m_tableName);
            }
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
        private void RemoveFieldsFromCache(String tableName = null)
        {
            //if (this.listBox1.SelectedItem != null)
            //{
            //    if (DeleteFieldsAndConditionsFromCache(this.listBox1.SelectedItem as string))
            //    {
            //        this.listBox1.Items.Remove(this.listBox1.SelectedItem);
            //    }

            //}
            try
            {

                if (listBox1.SelectedItems.Count > 0)
                {
                    for (int x = listBox1.SelectedIndices.Count - 1; x >= 0; x--)
                    {
                        int idx = listBox1.SelectedIndices[x];
                        // listBox2.Items.Add(listBox1.Items[idx]);
                        if (DeleteFieldsAndConditionsFromCache(this.listBox1.Items[idx] as string))
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

        private bool DeleteFieldsAndConditionsFromCache(string p)
        {
            TableInfo info1 = Tablelist.Find(X => X.Name == p);
            if (info1 != null)
            {
                Tablelist.Remove(info1);
                return true;
            }
            return false;
        }

        private void BackupFieldInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpField_And_Condition();
        }

        private void RestoreFieldsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestoreFields_And_Condition();
        }

        private void LoadFieldsFromCache_MenuItem_Click(object sender, EventArgs e)
        {
            LoadFieldsFromCache();
        }

        private void CacheFieldsConToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFieldsAndConditionToCache();
        }

        private void RemoveFieldsConFromCache_MenuItem_Click(object sender, EventArgs e)
        {
            RemoveFieldsFromCache();
        }

        private void FieldInfoSaveAs_MenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //  saveFileDialog1.CheckFileExists = true;
                saveFileDialog1.Filter = "*.xml|*.*";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var file = saveFileDialog1.FileName;
                    File.Copy(m_filepath, file);
                    toolStripStatusLabel1.Text = file + "另存成功";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void LoadFiledInfoFromFile_MenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.openFileDialog1.Filter = "*.xml|*.*";
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var fileName = openFileDialog1.FileName;
                    if (!String.IsNullOrEmpty(openFileDialog1.FileName))
                    {
                        if (File.Exists(fileName))
                        {
                            this.m_filepath = fileName;
                            RestoreFields_And_Condition();
                        }

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddFieldsToCache_Click(object sender, EventArgs e)
        {
            AddFieldsAndConditionToCache();
        }


    }
}
