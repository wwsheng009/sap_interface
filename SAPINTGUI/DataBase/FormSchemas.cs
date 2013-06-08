using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAPINTGUI.DataBase
{
    public partial class FormSchemas : DockWindow
    {
        public FormSchemas()
        {
            InitializeComponent();
            this.cbxDbConnection.DataSource = ConfigFileTool.SAPGlobalSettings.getDbConnectionList();
            this.cbxDbConnection.Text = ConfigFileTool.SAPGlobalSettings.GetDefaultDbConnection();
            new DgvFilterPopup.DgvFilterManager(dataGridView2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SAPINTDB.DbUtil dbUtil = new SAPINTDB.DbUtil(cbxDbConnection.Text);
                this.dataGridView1.DataSource = dbUtil.getDbObjectList();
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
            
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.txtCollectionName.Text = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

        }

        private void btnGetCollection_Click(object sender, EventArgs e)
        {
            try
            {
                SAPINTDB.DbUtil dbUtil = new SAPINTDB.DbUtil(cbxDbConnection.Text);
                this.dataGridView2.DataSource = dbUtil.getCollection(txtCollectionName.Text);
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
            
        }
    }
}
