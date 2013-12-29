using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAPINT.Gui.Util
{
    public partial class FormGetList : Form
    {

        public DataTable dt = null;
        public List<String> List = new List<string>();

        public FormGetList()
        {
            InitializeComponent();

            dt = new DataTable();
            dt.Columns.Add("active", typeof(Boolean));
            dt.Columns.Add("field", typeof(String));

            this.dataGridView1.DataSource = dt;
            SAPINT.Gui.CDataGridViewUtils.CopyPasteDataGridView(dataGridView1);
            new DgvFilterPopup.DgvFilterManager(dataGridView1);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            List.Clear();
            foreach (DataRow item in dt.Rows)
            {
                if ((bool)item[0] == true)
                {
                    List.Add(item[1].ToString());
                }
            }
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SAPINT.Gui.CDataGridViewUtils.SelectRows(dataGridView1);
        }

        private void btnUnSelect_Click(object sender, EventArgs e)
        {
            SAPINT.Gui.CDataGridViewUtils.UnSelectRows(dataGridView1);
        }
    }
}
