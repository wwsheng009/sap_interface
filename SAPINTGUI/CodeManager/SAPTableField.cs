using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAPINT.Utils;
using SAPINT.RFCTable;
using SAPINTGUI;
using SAPINTGUI.Util;
using WeifenLuo.WinFormsUI.Docking;

namespace SAPINTCODE
{


    public partial class SAPTableField : UserControl
    {

        string _tableName = "";  //当前的表名
        private string _systemName;//连接的SAP系统的配置名称
        //private List<TableInfo> _tablelist;  //缓存表字段列表
        private DataTable fieldsDt = null;
        private List<RFCTableInfo> _rfcTableList = new List<RFCTableInfo>();
        RFCTableInfo _rfctable = null; //new RFCTableInfo();
        bool sortByPosition = false;

        public List<RFCTableInfo> TableList
        {
            get
            {
                return this._rfcTableList;
            }
        }
        public string SystemName
        {
            private set
            {
                this._systemName = value;
            }
            get
            {
                return this._systemName;
            }
        }

        public SAPTableField()
        {
            InitializeComponent();

            //_tablelist = new List<TableInfo>();
            SAPINTGUI.CDataGridViewUtils.CopyPasteDataGridView(dataGridView1);
            new DgvFilterPopup.DgvFilterManager(dataGridView1);

            this.cbx_systemlist.DataSource = ConfigFileTool.SAPGlobalSettings.getSAPClientList();
            this.cbx_systemlist.Text = ConfigFileTool.SAPGlobalSettings.GetDefaultSapCient();

        }




        private bool check()
        {
            this._systemName = this.cbx_systemlist.Text.ToUpper().Trim();

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

            return true;
        }

        /// <summary>
        /// 从SAP系统中加载表的定义信息。
        /// </summary>
        private void GetTableDefinition()
        {
            if (!check())
            {
                return;
            }
            try
            {
                _rfctable = new RFCTableInfo();
                fieldsDt = _rfctable.GetTableDefinitionDt(_systemName, _tableName);
                this.dataGridView1.DataSource = fieldsDt;
                // _rfctable.GetTableDefinition(_systemName, _tableName);
                // _rfctable.TransformDataType();
                //_rfctable.Fields.ForEach(row =>
                //{
                //    row.FIELDNAME = row.FIELDNAME.Replace("/", "_");
                //});
                // fieldList =  SAPINT.RFCTable.RFCTable.GetTableDefinition(cbxSystemList.Text,textBoxTableName.Text);
                if (fieldsDt != null)
                {
                    if (fieldsDt.Rows.Count > 0)
                    {
                        MessageBox.Show("读取成功");
                    }
                    else
                    {
                        MessageBox.Show("无可用字段");
                    }

                }
                else
                {
                    MessageBox.Show("无法读取表信息");
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);

            }
        }
        /// <summary>
        ///读取表的所有字段列表 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadSAPTable_Click(object sender, EventArgs e)
        {

            GetTableDefinition();
            //this.dataGridView1.DataSource = _rfctable.Fields;

            updateDgvDisplay();


            //try
            //{
            //    ReadTable dt;
            //    if (!check())
            //    {
            //        return;
            //    }
            //    dt = new ReadTable(_systemName.ToUpper().Trim());
            //    dt.TableName = _tableName;
            //    ReadTableFieldCollection fields = dt.GetAllFieldsOfTable();
            //    if (fields == null || fields.Count == 0)
            //    {
            //        MessageBox.Show("所选数表没有字段");
            //        return;
            //    }
            //    this.dataGridView1.Rows.Clear();
            //    for (int i = 0; i < fields.Count; i++)
            //    {
            //        this.dataGridView1.Rows.Add(fields[i].Active, fields[i].FieldName, fields[i].FieldText, fields[i].CheckTable);

            //    }
            //    dataGridView1.AutoResizeColumns();
            //}
            //catch (Exception ee)
            //{

            //    MessageBox.Show(ee.Message);
            //}
        }

        private void updateDgvDisplay()
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
                this.dataGridView1.Columns.Remove("DOTNETTYPE");
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
            SAPINTGUI.CDataGridViewUtils.SelectRows(dataGridView1);
            
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

            //TableInfo info = new TableInfo();
            //info.Name = _tableName;
            //foreach (DataGridViewRow item in this.dataGridView1.Rows)
            //{
            //    if (item.Cells["FieldName"].Value != null)
            //    {
            //        info.Fields.Add(new ReadTableField
            //        {
            //            FieldName = item.Cells["FieldName"].Value == null ? "" : item.Cells["FieldName"].Value.ToString(),
            //            FieldText = item.Cells["FieldText"].Value == null ? "" : item.Cells["FieldText"].Value.ToString(),
            //            CheckTable = item.Cells["CheckTable"].Value == null ? "" : item.Cells["CheckTable"].Value.ToString(),
            //            Active = item.Cells["Select"].Value == null ? false : (bool)item.Cells["Select"].Value
            //        });
            //    }

            //}
            ////dt.Options.Cast<string>().ToList().ForEach(I => info.Options.Add(I));
            //TableInfo info1 = _tablelist.Find(X => X.Name == _tableName);
            //if (info1 != null)
            //{
            //    _tablelist.Remove(info1);
            //}
            //_tablelist.Add(info);


            RFCTableInfo info2 = _rfcTableList.Find(x => x.Name == TableName);
            if (info2 != null)
            {
                _rfcTableList.Remove(info2);
            }
            _rfctable.Fields = fieldsDt.ToList<TableField>() as List<TableField>;
            // _rfctable.Fields.Sort(new PositionComparer());
            _rfctable.Name = TableName;
            _rfcTableList.Add(_rfctable);

            return true;
        }

        bool loadFieldsAndOptionFromMemory(string tableName)
        {
            //_tableName = tableName;
            //tableName = tableName.ToUpper();
            ////按照表名加载字段列表与条件列表
            //TableInfo info = _tablelist.Find(x => x.Name == tableName);
            //if (info != null)
            //{
            //    this.dataGridView1.Rows.Clear();

            //    foreach (SAPINT.Utils.ReadTableField item in info.Fields)
            //    {
            //        this.dataGridView1.Rows.Add(item.Active, item.FieldName, item.FieldText, item.CheckTable);
            //    }
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            this.dataGridView1.DataSource = null;
            RFCTableInfo info = _rfcTableList.Find(x => x.Name == tableName);
            if (info != null)
            {
                // IList<TableField> list = info.Fields as IList<TableField>;
                this.dataGridView1.DataSource = info.Fields.ToDataTable<TableField>();

                updateDgvDisplay();
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
        private bool RemoveFieldsAndOptionFromMemory(string tableName)
        {
            if (string.IsNullOrEmpty(tableName))
            {
                return false;
            }
            //_tableName = tableName;
            //TableInfo info1 = _tablelist.Find(X => X.Name == _tableName);
            //if (info1 != null)
            //{
            //    _tablelist.Remove(info1);
            //}

            RFCTableInfo info = _rfcTableList.Find(x => x.Name == tableName);
            if (info != null)
            {

                _rfcTableList.Remove(info);
                return true;
            }
            else
            {
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
            SAPINTGUI.CDataGridViewUtils.UnSelectRows(dataGridView1);
           
        }

        private void btnCacheMe_Click(object sender, EventArgs e)
        {

            this._tableName = this.txtTableName.Text.Trim().ToUpper();
            if (String.IsNullOrEmpty(_tableName))
            {
                MessageBox.Show("表名不能为空");
                return;
            }
            if (SaveFieldsAndOptiontoMemory(this._tableName) == true)
            {
                if (!this.listBox1.Items.Contains(this._tableName))
                {
                    this.listBox1.Items.Add(this._tableName);
                }

            }


        }

        private void btnLoadCache_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedItem != null)
            {
                this._tableName = this.listBox1.SelectedItem as string;
                this.txtTableName.Text = _tableName;
                loadFieldsAndOptionFromMemory(_tableName);
            }


        }

        private void btnRemoveCache_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedItem != null)
            {
                this._tableName = this.listBox1.SelectedItem as string;
                if (true == RemoveFieldsAndOptionFromMemory(_tableName))
                {
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


        private void btnSort_Click(object sender, EventArgs e)
        {
            if (_rfctable != null)
            {
                if (sortByPosition == true)
                {
                    //    _rfctable.Fields.Sort(new SelectedComparer());

                }
                //  this.dataGridView1.DataSource = null;
                //   this.dataGridView1.DataSource = _rfctable.Fields;
                if (sortByPosition == false)
                {
                    //  _rfctable.Fields.Sort(new PositionComparer());

                }
                sortByPosition = !sortByPosition;
                //dataGridView1.Update();
                dataGridView1.Refresh();
                //dataGridView1.Parent.Update();
                //MessageBox.Show("排序完成");

            }


        }

        private void btnSearch2_Click(object sender, EventArgs e)
        {
            //if (_rfctable != null && _rfctable.Fields.Count > 0)
            //{
            FormSearchText2 form = new FormSearchText2();
            form.dt = this.dataGridView1.DataSource as DataTable;
            form.Show();
            //}

        }

    }
}
