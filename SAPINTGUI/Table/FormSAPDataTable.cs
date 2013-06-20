using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DgvFilterPopup;
using SAPINT.RFCTable;

namespace SAPINT.Gui.Table
{
    public partial class FormSAPDataTable : DockWindow
    {
        private DataTable localdt = null;
        public String SystemName { get; set; }

        private String _tableName = null;
        public String TableName { get { return _tableName; } set { _tableName = value; this.Text = "表：" + _tableName; } }

        public DataTable DataTable
        {
            get { return localdt; }
            set
            {
                localdt = value;
                this.dataGridView1.DataSource = localdt;

            }
        }

        public FormSAPDataTable()
        {
            InitializeComponent();
            DgvFilterManager fm = new DgvFilterManager();
            fm.ColumnFilterAdding += fm_ColumnFilterAdding;
            fm.DataGridView = dataGridView1;
            this.Shown += FormSAPDataTable_Shown;
        }
        void fm_ColumnFilterAdding(object sender, ColumnFilterEventArgs e)
        {
            e.ColumnFilter = new DgvComboBoxColumnFilter();
        }
        void FormSAPDataTable_Shown(object sender, EventArgs e)
        {
            this.dataGridView1.AutoResizeColumns();
        }

        private void ShowSaveDataTableDialog()
        {
            SAPINT.Gui.DataBase.FormSaveDataTable formSaveDt = new DataBase.FormSaveDataTable();
            formSaveDt.Dt = localdt;
            formSaveDt.SapSystemName = SystemName;
            formSaveDt.SapTableName = TableName;

            formSaveDt.Show();
        }
        private void DirectSaveDataTableToDataBase()
        {
            if (localdt != null)
            {
                if (TableName != null && SystemName != null)
                {
                    try
                    {
                        SapTable table = new SapTable(SystemName, TableName);
                        if (table.SaveDataTable(localdt))
                        {
                            MessageBox.Show("保存成功！！！");
                        }
                        else
                        {
                            MessageBox.Show("保存失败！！！");
                        }

                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                        //  throw;
                    }

                }
            }
        }
        private void SaveTabletoolStripButton1_Click(object sender, EventArgs e)
        {
            ShowSaveDataTableDialog();
        }
    }
}
