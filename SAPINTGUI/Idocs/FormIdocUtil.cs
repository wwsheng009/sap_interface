using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAPINT.Gui.Idocs
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

            String sqlstr = String.Format("select * from EDIDC where docnum like '{0}'", this.txtIdocNumber.Text.Trim());
            dbhelper.DataTableFill(dt, sqlstr);
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = dt;

            var dt2 = new DataTable();
            sqlstr = String.Format("select * from EDID4 where docnum like '{0}'", this.txtIdocNumber.Text.Trim());
            dbhelper.DataTableFill(dt2, sqlstr);
            this.dataGridView2.DataSource = null;
            this.dataGridView2.DataSource = dt2;

            var dt3 = new DataTable();
            sqlstr = String.Format("select * from EDIDS where docnum like '{0}'", this.txtIdocNumber.Text.Trim());
            dbhelper.DataTableFill(dt3, sqlstr);
            this.dataGridView3.DataSource = null;
            this.dataGridView3.DataSource = dt3;
        }


    }
}
