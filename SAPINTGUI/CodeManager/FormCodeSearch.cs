using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAPINT.Gui.Util;
using SAPINT.Utils;
using SAPINTDB;
using SAPINTDB.CodeManager;

namespace SAPINT.Gui.CodeManager
{
    public partial class FormCodeSearch : DockWindow
    {

        List<Code> list;


        SAPINTDB.CodeManager.Codedb codedb = new Codedb();
        BindingSource bs = new BindingSource();

        private DataTable m_CurrentDb = null;

        public FormCodeSearch()
        {
            InitializeComponent();
            this.dataGridView1.CellClick += dataGridView1_CellClick;
            this.dataGridView1.CurrentCellChanged += dataGridView1_CurrentCellChanged;

        }

        void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {

            var cell = dataGridView1.CurrentCell;
            if (cell != null && cell.Value != null)
            {
                this.syntaxBoxControl1.Document.Text = cell.Value.ToString();
                this.webBrowser1.DocumentText = cell.Value.ToString();
            }
        }

        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }

            DataGridViewCell cell = this.dataGridView1[e.ColumnIndex, e.RowIndex];
            if (cell == null || cell.Value == null)
            {
                return;
            }

            this.syntaxBoxControl1.Document.Text = cell.Value.ToString();
            if (dataGridView1.Columns[cell.ColumnIndex].Name == "CodeId")
            {
                if (!String.IsNullOrWhiteSpace(cell.Value.ToString()))
                {
                    editCode(cell.Value.ToString());
                }
            }

        }

        private void editCode(String id)
        {
            try
            {
                Code code = codedb.GetCode(id);
                if (code != null)
                {
                    FormCodeEditor frm = new FormCodeEditor();
                    frm.code = code;
                    frm.Show();
                }
            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.Message);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                this.dataGridView1.DataSource = null;
                // list = codedb.searchCode(this.txtSearch.Text);
                DataTable dt = codedb.SearchCodeToDataTable(this.txtSearch.Text);
                if (dt.Rows.Count <= 0)
                {
                    return;
                }
                dt.Columns.Add("iid", typeof(int));
                dt.Columns["iid"].SetOrdinal(0);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["iid"] = i;
                }
                m_CurrentDb = dt;
                bs.DataSource = dt;

                this.dataGridView1.DataSource = bs;
                this.txtCodeId.DataBindings.Clear();
                this.txtCodeId.DataBindings.Add("Text", bs, "Id");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnEditCode_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txtCodeId.Text))
            {
                editCode(this.txtCodeId.Text);
            }
            else
            {
                MessageBox.Show("请选择代码");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                this.dataGridView1.DataSource = null;
                // list = codedb.searchCode(this.txtSearch.Text);
                var list = codedb.SearchCode(this.txtSearch.Text);
                if (list.Count <= 0)
                {
                    return;
                }

                var dt = ListHelper.ToDataTable(list);
                dt.Columns.Add("iid", typeof(int));
                dt.Columns["iid"].SetOrdinal(0);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["iid"] = i;
                }
                m_CurrentDb = dt;
                bs.DataSource = dt;

                this.dataGridView1.DataSource = bs;
                this.txtCodeId.DataBindings.Clear();
                this.txtCodeId.DataBindings.Add("Text", bs, "Id");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_CurrentDb.Columns.Contains("VersionList"))
                {
                    m_CurrentDb.Columns.Remove("VersionList");
                }
                //if (m_CurrentDb.Columns.Contains("Id"))
                //{
                //    m_CurrentDb.Columns.Remove("Id");
                //}
                //if (m_CurrentDb.Columns.Contains("TreeId"))
                //{
                //    m_CurrentDb.Columns.Remove("TreeId");
                //}

                //ExcelXMLExportHelperGui.SaveDt2Excel(m_CurrentDb);
                ClosedExcelGui.SaveDt2Excel(m_CurrentDb);
                //ExportToExcel exportExcel = new ExportToExcel();
                //exportExcel.SaveExcel(m_CurrentDb, "", "", "Sheet1");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
