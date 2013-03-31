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
    public partial class FormCopyIdoc : Form
    {

        SAPINTDB.IdocDb idocdb = null;

        public FormCopyIdoc()
        {
            InitializeComponent();
            this.cbxDbConnection.DataSource = new ConfigFileTool.SAPGlobalSettings().getDbConnectionList();
            this.cbxDbConnection.Text = new ConfigFileTool.SAPGlobalSettings().GetDefaultDbConnection();

            this.cbxSapSystem.DataSource = new ConfigFileTool.SAPGlobalSettings().getSAPClientList();
            this.cbxSapSystem.Text = new ConfigFileTool.SAPGlobalSettings().GetDefultSAPServer();

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                idocdb = new SAPINTDB.IdocDb(this.cbxDbConnection.Text);
                idocdb.AppendTodb = checkboxAppend.Checked;
                idocdb.CopyIdocFromSAP(this.txtIdocNumber.Text, this.cbxSapSystem.Text);
                MessageBox.Show("保存成功！");

            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }

        }

        private void btnDecombileIdoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (idocdb == null)
                {
                    idocdb = new SAPINTDB.IdocDb(this.cbxDbConnection.Text);
                }
                else
                {
                    SAPINT.Idocs.Idoc idoc = idocdb.readIdoc(this.txtIdocNumber.Text,this.cbxSapSystem.Text);

                    FormIdocMeta formIdocMeta = new FormIdocMeta();
                   
                    formIdocMeta.SapSystemName = this.cbxSapSystem.Text;
                    formIdocMeta.Idoc = idoc;
                    
                    formIdocMeta.IdocToTreeControl();
                    formIdocMeta.DtStatus = idocdb.IdocStatus;
                    formIdocMeta.Show();
                }

            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }

        }

    }
}
