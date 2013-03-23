using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAPINT.Utils;

namespace SAPINTCODE
{


    public partial class SAPTableField : UserControl
    {

        string _tableName = "";  //当前的表名
        private string _systemName;//连接的SAP系统的配置名称
        private List<TableInfo> _tablelist;  //缓存列表

        public List<TableInfo> TableList
        {
            get
            {
                return this._tablelist;
            }
        }
        public string SystemName
        {
            get
            {
                return this._systemName ;
            }
        }
                
        public SAPTableField()
        {
            InitializeComponent();
            _tablelist = new List<TableInfo>();
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

        private void btnReadSAPTable_Click(object sender, EventArgs e)
        {
            try
            {
                ReadTable dt;
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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            //this.dataGridView1.Rows.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected == true)
                {
                    if (row.Cells["FieldName"].Value != null)
                    {
                        if ((bool)row.Cells["Select"].Value == false)
                        {
                            row.Cells["Select"].Value = true;
                        }

                    }
                }

            }
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
            _tableName = TableName;
            TableInfo info = new TableInfo();
            info.Name = _tableName;
            foreach (DataGridViewRow item in this.dataGridView1.Rows)
            {
                if (item.Cells["FieldName"].Value != null)
                {
                    //if (item.Cells["Select"].Value != null)
                    //{
                    //    if ((bool)item.Cells["Select"].Value == true)
                    //    {
                    info.Fields.Add(new ReadTableField
                    {
                        FieldName = item.Cells["FieldName"].Value == null ? "" : item.Cells["FieldName"].Value.ToString(),
                        FieldText = item.Cells["FieldText"].Value == null ? "" : item.Cells["FieldText"].Value.ToString(),
                        CheckTable = item.Cells["CheckTable"].Value == null ? "" : item.Cells["CheckTable"].Value.ToString(),
                        Active = item.Cells["Select"].Value == null ? false : (bool)item.Cells["Select"].Value
                    });
                    //    }
                    //}

                }

            }
            //dt.Options.Cast<string>().ToList().ForEach(I => info.Options.Add(I));
            TableInfo info1 = _tablelist.Find(X => X.Name == _tableName);
            if (info1 != null)
            {
                _tablelist.Remove(info1);
            }
            _tablelist.Add(info);

            return true;
        }

        bool loadFieldsAndOptionFromMemory(string tableName)
        {
            _tableName = tableName;
            tableName = tableName.ToUpper();
            //按照表名加载字段列表与条件列表
            TableInfo info = _tablelist.Find(x => x.Name == tableName);
            if (info != null)
            {
                this.dataGridView1.Rows.Clear();

                foreach (SAPINT.Utils.ReadTableField item in info.Fields)
                {
                    this.dataGridView1.Rows.Add(item.Active, item.FieldName, item.FieldText, item.CheckTable);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private void RemoveFieldsAndOptionFromMemory(string tableName)
        {
            if (string.IsNullOrEmpty(tableName))
            {
                return;
            }
            _tableName = tableName;
            TableInfo info1 = _tablelist.Find(X => X.Name == _tableName);
            if (info1 != null)
            {
                _tablelist.Remove(info1);
            }
        }

        private void btnUnSelect_Click(object sender, EventArgs e)
        {
            //this.dataGridView1.Rows.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected == true)
                {
                    if (row.Cells["FieldName"].Value != null)
                    {
                        if ((bool)row.Cells["Select"].Value == true)
                        {
                            row.Cells["Select"].Value = false;
                        }
                    }

                }

            }
        }

        private void btnCacheMe_Click(object sender, EventArgs e)
        {
            SaveFieldsAndOptiontoMemory(this.txtTableName.Text.Trim().ToUpper());
        }

        private void btnLoadCache_Click(object sender, EventArgs e)
        {
            loadFieldsAndOptionFromMemory(this.txtTableName.Text.Trim().ToUpper());
        }

        private void cbx_systemlist_MouseClick(object sender, MouseEventArgs e)
        {
            this.cbx_systemlist.DataSource = null;
            this.cbx_systemlist.DataSource = SAPINT.SAPConfigList.SystemNameList;
        }

        private void btnRemoveCache_Click(object sender, EventArgs e)
        {
            RemoveFieldsAndOptionFromMemory(this.txtTableName.Text.Trim().ToUpper());
        }



    }

    /// <summary>
    /// 保存上运行过程中的字段与条件
    /// </summary>
    public class TableInfo
    {
        public TableInfo()
        {
            Fields = new List<SAPINT.Utils.ReadTableField>();
        }
        //表名
        public string Name { get; set; }
        //字段列表
        public List<SAPINT.Utils.ReadTableField> Fields { get; set; }
    }
}
