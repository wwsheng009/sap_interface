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
    public partial class FormDataBase : Form
    {
        public FormDataBase()
        {
            InitializeComponent();
            Alsing.SourceCode.SyntaxDefinition sl = new Alsing.SourceCode.SyntaxDefinitionLoader().Load("sql.syn");
            this.syntaxBoxControl1.Document.Parser.Init(sl);
        }
        DataTable dt;
        private void btnExcute_Click(object sender, EventArgs e)
        {
            String dbName = new ConfigFileTool.SAPGlobalSettings().GetDefaultDbConnection();
            dt = new DataTable();
            SAPINTDB.netlib7 dbhelper = new SAPINTDB.netlib7(dbName);


            dbhelper.DataTableFill(dt, this.syntaxBoxControl1.Document.Text);
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = dt;
        }

        private void btnUpdateDb_Click(object sender, EventArgs e)
        {
            String dbName = new ConfigFileTool.SAPGlobalSettings().GetDefaultDbConnection();
            SAPINTDB.netlib7 dbhelper = new SAPINTDB.netlib7(dbName);
            dbhelper.DataTableUpdate(dt, this.syntaxBoxControl1.Document.Text);
            dt.AcceptChanges();
            this.dataGridView1.DataSource = dt;

        }
    }
}
