using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAPINTGUI.Idoc
{
    public partial class FormIdocUtil : DockWindow
    {
        public FormIdocUtil()
        {
            InitializeComponent();
        }
        DataTable dt = null;

        private void btnReadIdocFromDb_Click(object sender, EventArgs e)
        {
            String dbName = ConfigFileTool.SAPGlobalSettings.GetDefaultDbConnection();
            dt = new DataTable();
            SAPINTDB.netlib7 dbhelper = new SAPINTDB.netlib7(dbName);

            String idocNumber = String.Format("select * from T{0}" ,this.txtIdocNumber.Text.Trim());
            dbhelper.DataTableFill(dt, idocNumber);
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = dt;
        }

        
    }
}
