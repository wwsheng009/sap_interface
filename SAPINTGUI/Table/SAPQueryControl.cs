using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAPINT.Queries;
//using Microsoft.Office.Tools.Excel;
using SAPINT;
using SAPINT.Queries.QueryHelper;
namespace SAPINTGUI
{
    public delegate void QueryExcuteDone(DataTable resultDataTable);
    public partial class SAPQueryControl : UserControl
    {
        public event QueryExcuteDone eventQueryExuteDone;
        string systemName = "";
        string userGroup = "";
        string queryName = "";
        string variant = "";
        int maxRow = 0;
        WorkSpace area;
        QuerySelectionParameterCollection parameterCollection;
        Query q;
        public SAPQueryControl()
        {
            InitializeComponent();
        }
        private void btnExcute_Click(object sender, EventArgs e)
        {
            if (this.Check())
            {
                this.Excute();
            }
        }
        private bool Check()
        {
            systemName = this.cbxSystemList.Text.Trim();
            userGroup = this.cbxUserGroup.Text.Trim();
            queryName = this.cbxQueries.Text.Trim();
            variant = this.cbxVariants.Text.Trim();
            maxRow = Convert.ToInt32(this.txtMaxRows.Text.Trim());
            area = checkStandard.Checked == true ? WorkSpace.StandardArea : WorkSpace.GlobalArea;
            if (maxRow <= 0)
            {
                MessageBox.Show("行数不正确");
                return false;
            }
            if (string.IsNullOrEmpty(systemName))
            {
                MessageBox.Show("请选择系统名称");
                return false;
            }
            if (string.IsNullOrEmpty(userGroup))
            {
                MessageBox.Show("请用户组");
                return false;
            }
            if (string.IsNullOrEmpty(queryName))
            {
                MessageBox.Show("请选择查询");
                return false;
            }
            //if (string.IsNullOrEmpty(variant))
            //{
            //    MessageBox.Show("请选择变量");
            //    return false;
            //}
            return true;
            //throw new NotImplementedException();
        }
        private void Excute()
        {
            try
            {
                SAPConnection con = new SAPConnection(systemName);
                q = con.CreateQuery(area, userGroup, queryName, variant);
                q.MaxRows = maxRow;
                foreach (DataGridViewRow row in dgvParameters.Rows)
                {
                    if (row.Cells["CNAME"].Value != null && row.Cells["CSIGN"].Value != null)
                    {
                        Range r = new Range();
                        r.Sign = row.Cells["CSIGN"].Value.ToString() == "I" ? Sign.Include : Sign.Exclude;
                        if (row.Cells["CLOW"].Value != null)
                        {
                            r.LowValue = row.Cells["CLOW"].Value.ToString();
                        }
                        if (row.Cells["CHIGH"].Value != null)
                        {
                            r.HighValue = row.Cells["CHIGH"].Value.ToString();
                        }
                        if (row.Cells["CNAME"].Value != null)
                        {
                            q.SelectionParameters[row.Cells["CNAME"].Value.ToString()].Ranges.Add(r);
                        }
                    }
                }
                q.Excute();
               // DataTable dt = q.Result;
                eventQueryExuteDone(q.Result);
                //Worksheet ws;          //当前工作表。
                ////在当前激活的工作表上存放数据
                //ws = Globals.Factory.GetVstoObject(Globals.ThisAddIn.Application.ActiveWorkbook.ActiveSheet);
                //ListObject ls;
                //if (!ws.Controls.Contains(queryName))
                //{
                //    int count = ws.ListObjects.Count;
                //    for (int i = 1; i < count + 1; i++)
                //    {
                //        if (ws.ListObjects[i].Name == queryName)
                //        {
                //            ws.ListObjects[i].Delete();
                //            // ws.Controls.Remove(_tableName);
                //        }
                //    }
                //    ls = ws.Controls.AddListObject(ws.Range["A2"], queryName);
                //}
                //else
                //{
                //    ls = (ListObject)ws.Controls[queryName];
                //}
                //ls.SetDataBinding(q.Result);
               
                //for (int i = 0; i < q.Fields.Count; i++)
                //{
                //    ls.ListColumns[i + 1].Name = q.Fields[i].Name;
                //    ws.Cells.set_Item(1,i+1,q.Fields[i].Description);
                //}
                //ws.Columns.AutoFit();
                //ws.Columns.ShrinkToFit = true;
                //ws.Name = queryName;
                MessageBox.Show("加载完成");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (this.Check())
            {
                this.GetQueryDefinition();
            }
        }
        private void GetQueryDefinition()
        {
            try
            {
                WorkSpace area = checkStandard.Checked == true ? WorkSpace.StandardArea : WorkSpace.GlobalArea;
                SAPConnection con = new SAPConnection(systemName);
                q = con.CreateQuery(area, userGroup, queryName, variant);
                // parameterCollection = new QuerySelectionParameterCollection();
                parameterCollection = q.SelectionParameters;
                dgvParameters.Rows.Clear();
                DataGridViewComboBoxColumn col = (DataGridViewComboBoxColumn)dgvParameters.Columns["CSELNAME"];
                col.DataSource = null;
                col.DataSource = parameterCollection;
                col.DisplayMember = "DescriptionText";
                q = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void dgvParameters_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvParameters.CurrentCell.ColumnIndex == 0 && dgvParameters.CurrentCell.RowIndex != -1)
            {
                (e.Control as ComboBox).SelectedIndexChanged += new EventHandler(SAPQuery_SelectedIndexChanged);
                (e.Control as ComboBox).SelectedValueChanged += new EventHandler(SAPQuery_SelectedIndexChanged);
            }
        }
        void SAPQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ComboBox comboBox = sender as ComboBox;
            if (comboBox.DataSource != null)
            {
                QuerySelectionParameterCollection collection = (QuerySelectionParameterCollection)comboBox.DataSource;
                foreach (QuerySelectionParameter item in collection)
                {
                    if (item.DescriptionText == comboBox.Text)
                    {
                        dgvParameters.Rows[dgvParameters.CurrentCell.RowIndex].Cells["CKIND"].Value = item.Kind == Kind.SelectOption ? "SelectOption" : "Parameter";
                        dgvParameters.Rows[dgvParameters.CurrentCell.RowIndex].Cells["CFIELDNAME"].Value = item.FieldName;
                        dgvParameters.Rows[dgvParameters.CurrentCell.RowIndex].Cells["CNAME"].Value = item.Name;
                    }
                }
            }
            comboBox.SelectedIndexChanged -= new EventHandler(SAPQuery_SelectedIndexChanged);
        }
        private void btnSearchUserGroup_Click(object sender, EventArgs e)
        {
            area = checkStandard.Checked == true ? WorkSpace.StandardArea : WorkSpace.GlobalArea;
            systemName = this.cbxSystemList.Text.Trim();
            QueryHelper helper = new QueryHelper(systemName);
            string searchString = cbxUserGroup.Text;
            if (string.IsNullOrEmpty(searchString))
            {
                searchString = "*";
            }
            SearchResultUserGroupsDataTable dt = helper.SearchForUserGroups(area, searchString);
            cbxUserGroup.DataSource = null;
            cbxUserGroup.DataSource = dt;
            cbxUserGroup.DisplayMember = "UserGroup";
            this.dgvSearchResult.DataSource = null;
            this.dgvSearchResult.DataSource = dt;
        }
        private void btnSearchQuery_Click(object sender, EventArgs e)
        {
            systemName = this.cbxSystemList.Text.Trim();
            QueryHelper helper = new QueryHelper(systemName);
            area = checkStandard.Checked == true ? WorkSpace.StandardArea : WorkSpace.GlobalArea;
            userGroup = this.cbxUserGroup.Text.Trim();
            
            string searchString = cbxQueries.Text;
            if (string.IsNullOrEmpty(searchString))
            {
                searchString = "*";
            }
            SearchResultQueryDataTable dt = helper.SearchForQueries(area, userGroup, searchString, "*");
            cbxQueries.DataSource = null;
            cbxQueries.DataSource = dt;
            cbxQueries.DisplayMember = "QueryName";
            this.dgvSearchResult.DataSource = null;
            this.dgvSearchResult.DataSource = dt;
        }
        private void btnSearchVariant_Click(object sender, EventArgs e)
        {
            systemName = this.cbxSystemList.Text.Trim();
            QueryHelper helper = new QueryHelper(systemName);
            area = checkStandard.Checked == true ? WorkSpace.StandardArea : WorkSpace.GlobalArea;
            userGroup = this.cbxUserGroup.Text.Trim();
            queryName = this.cbxQueries.Text.Trim();
            SearchResultVariantsDataTable dt = helper.SearchForVariants(area, userGroup, queryName);
            cbxVariants.DataSource = null;
            cbxVariants.DataSource = dt;
            cbxVariants.DisplayMember = "VariantName";
            this.dgvSearchResult.DataSource = null;
            this.dgvSearchResult.DataSource = dt;
        }
        private void cbxUserGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
