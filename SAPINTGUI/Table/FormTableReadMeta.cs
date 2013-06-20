using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAPINT.Function;

namespace SAPINT.Gui.Table
{
    public delegate void DelegateTableReadMeta(FormTableReadMeta dataTableInfo);

    public partial class FormTableReadMeta : DockWindow
    {
        public event DelegateTableReadMeta EventTableReadMeta;
        string _tableName = "";  //当前的表名
        List<TableInfo> tablelist;  //缓存列表
        private string _systemName;//连接的SAP系统的配置名称
        List<String> TitleList;
        public DataTable DtMetaList = null;

        public FormTableReadMeta()
        {
            InitializeComponent();
            this.cbx_systemlist.DataSource = ConfigFileTool.SAPGlobalSettings.GetSAPClientList();
            this.cbx_systemlist.Text = ConfigFileTool.SAPGlobalSettings.GetDefaultSapCient();

            tablelist = new List<TableInfo>();
            TitleList = new List<string>();

            new DgvFilterPopup.DgvFilterManager(this.dataGridView1);
            new DgvFilterPopup.DgvFilterManager(this.dataGridView2);
            CDataGridViewUtils.CopyPasteDataGridView(this.dataGridView1);
            CDataGridViewUtils.CopyPasteDataGridView(this.dataGridView2);

        }
        public string TableName
        {
            get
            {
                return this._tableName;
            }
        }
        public string SystemName
        {
            get
            {
                return this._systemName;
            }
        }
        private bool Check()
        {
            this._systemName = this.cbx_systemlist.Text.ToUpper().Trim();
            if (string.IsNullOrEmpty(_systemName))
            {
                MessageBox.Show("请选择系统");
                return false;
            }
            this._tableName = this.txtTableName.Text.Trim().ToUpper();
            Parent.Text = _tableName;
            if (string.IsNullOrEmpty(this._tableName))
            {
                MessageBox.Show("请指定表名");
                return false;
            }
            return true;
        }

        private void btRun_Click(object sender, EventArgs e)
        {
            if (!Check())
            {
                return;
            }
            try
            {
                loadTableMetaData();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        /// <summary>
        /// 有些表结构的字段并不需要，将它们屏蔽掉。
        /// </summary>
        /// <param name="dt"></param>
        void DeleteRows(ref DataTable dt)
        {
            bool search = false;
            if (this.dataGridView1.Rows.Count > 0)
            {
                DataTable dtnew = dt.Clone();

                //for (int i = 0; i < dt.Rows.Count; i++)
                //{

                //查找哪些是没有选中的字段列表。
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value == null)
                    {
                        continue;
                    }


                    if ((Boolean)row.Cells[0].Value == true)
                    {
                        search = true;
                        String FieldName = (String)row.Cells[1].Value;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            //    if (dt.Rows[i]["FIELDNAME"].ToString() != FieldName)
                            //    {
                            //        dt.Rows[i].Delete();
                            //    }
                            //}
                            //dt.AcceptChanges();
                            if (dt.Rows[i]["FIELDNAME"].ToString() == FieldName)
                            {
                                DataRow rownew = dtnew.NewRow();
                                rownew.ItemArray = dt.Rows[i].ItemArray;
                                dtnew.Rows.Add(rownew);
                                //  dt.Rows[i].Delete();
                            }
                        }
                    }
                }
                if (search)
                {
                    dt = dtnew;
                }


                //  dt.AcceptChanges();
            }

        }
        /// <summary>
        /// 屏蔽不需要的列
        /// </summary>
        /// <param name="dt"></param>
        private void DeleteColumn(ref DataTable dt)
        {
            if (this.dataGridView2.Rows.Count != 0)
            {
                TitleList.Clear();
                //查找哪些是没有选中的字段列表。
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    String FieldName = (String)row.Cells[1].Value;
                    if (row.Cells[1].Value == null)
                    {
                        break;
                    }
                    if ((Boolean)row.Cells[0].Value == false)
                    {

                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            if (dt.Columns[i].ColumnName == FieldName)
                            {
                                dt.Columns.Remove(FieldName);
                                break;
                            }
                        }
                    }
                    else
                    {
                        TitleList.Add(FieldName);
                    }
                }
            }
        }
        /// <summary>
        /// 设置一些一定要显示的字段
        /// </summary>
        private void SetDefaultOptions()
        {
            if (this.dataGridView2.Rows.Count == 0)
            {
                return;
            }
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                String FieldName = row.Cells[1].Value.ToString();
                switch (FieldName)
                {
                    case "POSITION"://位置
                        row.Cells[0].Value = true;
                        break;
                    case "FIELDNAME"://字段名
                        row.Cells[0].Value = true;
                        break;
                    case "LENG"://长度
                        row.Cells[0].Value = true;
                        break;
                    case "DECIMALS"://小数点后长度
                        row.Cells[0].Value = true;
                        break;
                    case "DATATYPE"://数据类型
                        row.Cells[0].Value = true;
                        break;
                    case "ROLLNAME"://数据元素
                        row.Cells[0].Value = true;
                        break;
                    case "FIELDTEXT"://短文本
                        row.Cells[0].Value = true;
                        break;
                    // case "SCRTEXT_M"://字段描述
                    //      row.Cells[0].Value = true;
                    //      break;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// 默认生成模板样式
        /// </summary>
        public void FormatTamplate()
        {
            //ws = Globals.Factory.GetVstoObject(Globals.ThisAddIn.Application.ActiveWorkbook.ActiveSheet);
            //Microsoft.Office.Interop.Excel.Range rang = (Microsoft.Office.Interop.Excel.Range)ws.get_Range("B1", "G1");


            //rang.Select();
            //rang.Merge(false);
            //rang = (Microsoft.Office.Interop.Excel.Range)ws.get_Range("B2", "G2"); 
            //rang.Select();
            //rang.Merge(false);
            //rang = (Microsoft.Office.Interop.Excel.Range)ws.get_Range("B3", "G3"); 
            //rang.Select();
            //rang.Merge(false);
            //ws.Cells.set_Item(1, 1, "输出表");
            //ws.Cells.set_Item(2, 1, "表名称");
            //ws.Cells.set_Item(3, 1, "备注");
            //ws.Cells.set_Item(3,2, this._tableName);
            //ws.Cells.set_Item(4, 1, "字段编号");
            //ws.Cells.set_Item(4, 2, "字段");
            //ws.Cells.set_Item(4, 3, "数据元素");
            //ws.Cells.set_Item(4, 4, "长度");
            //ws.Cells.set_Item(4, 5, "小数位");
            //ws.Cells.set_Item(4, 6, "类型");
            //ws.Cells.set_Item(4, 7, "字段含义");

            //ws.Columns.AutoFit();
        }
        /// <summary>
        /// 从SAP系统中加载表或结构的定义。
        /// 
        /// </summary>
        void loadTableMetaData()
        {

            String sysName = _systemName.ToUpper().Trim();
            DtMetaList = SAPFunction.DDIF_FIELDINFO_GET(sysName, _tableName);
            DeleteRows(ref DtMetaList);
            DeleteColumn(ref DtMetaList);
            if (EventTableReadMeta != null)
            {
                EventTableReadMeta(this);
            }


            //MessageBox.Show("加载完成");
        }

        private void loadFields_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Check())
                {
                    return;
                }
                if (!Check())
                {
                    return;
                }
                this.dataGridView1.Rows.Clear();
                DataTable dtTableMetaList = SAPFunction.DDIF_FIELDINFO_GET(_systemName, _tableName);
                // ReadTableFieldCollection co = dt.Fields;
                for (int i = 0; i < dtTableMetaList.Rows.Count; i++)
                {
                    this.dataGridView1.Rows.Add(new object[] { false, dtTableMetaList.Rows[i]["FIELDNAME"], dtTableMetaList.Rows[i]["SCRTEXT_M"] });
                }
                dataGridView1.AutoResizeColumns();
                //  saveContext();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnLoadFields2_Click(object sender, EventArgs e)
        {
            if (!Check())
            {
                return;
            }
            this.dataGridView2.Rows.Clear();
            DataTable dtColumns = SAPFunction.DDIF_FIELDINFO_GET(_systemName, "DFIES");
            for (int i = 0; i < dtColumns.Rows.Count; i++)
            {
                this.dataGridView2.Rows.Add(new object[] { false, dtColumns.Rows[i]["FIELDNAME"], dtColumns.Rows[i]["SCRTEXT_M"] });
            }
            dataGridView2.AutoResizeColumns();
            SetDefaultOptions();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            CDataGridViewUtils.SelectRows(dataGridView1);
        }

        private void btnUnSelect_Click(object sender, EventArgs e)
        {
            CDataGridViewUtils.UnSelectRows(dataGridView1);
        }

        private void btnSelect2_Click(object sender, EventArgs e)
        {
            CDataGridViewUtils.SelectRows(dataGridView2);
        }

        private void btnUnSelect2_Click(object sender, EventArgs e)
        {
            CDataGridViewUtils.SelectRows(dataGridView2);
        }
    }
}
