using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAPINT.Idocs;

namespace SAPINT.Gui.Idocs
{
    public partial class FormIdocCopy : ToolWindow
    {

        IdocDb idocdb = null;
        private string _idocNumber = string.Empty;
        private string _systemNumber = string.Empty;
        private string _dbConn = string.Empty;


        public FormIdocCopy()
        {
            InitializeComponent();
            this.cbxDbConnection.DataSource = ConfigFileTool.SAPGlobalSettings.getDbConnectionList();
            this.cbxDbConnection.Text = ConfigFileTool.SAPGlobalSettings.GetDefaultDbConnection();

            this.cbxSapSystem.DataSource = ConfigFileTool.SAPGlobalSettings.GetSAPClientList();
            this.cbxSapSystem.Text = ConfigFileTool.SAPGlobalSettings.GetDefaultSapCient();

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            _idocNumber = this.txtIdocNumber.Text.Trim();
            _systemNumber = this.cbxSapSystem.Text;
            _dbConn = this.cbxDbConnection.Text;

            if (string.IsNullOrEmpty(_idocNumber))
            {
                MessageBox.Show("请输入IDOC编号");
                return;
            }

            if (string.IsNullOrEmpty(_systemNumber))
            {
                MessageBox.Show("请选择SAP系统");
                return;
            }
            if (string.IsNullOrEmpty(_dbConn))
            {
                MessageBox.Show("请选择本地数据库连接");
                return;
            }
            try
            {
                idocdb = new IdocDb(this.cbxDbConnection.Text);
                idocdb.AppendTodb = checkboxAppend.Checked;
                idocdb.CopyIdocFromSAP(_idocNumber, _systemNumber);
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
                    idocdb = new IdocDb(this.cbxDbConnection.Text);
                }
                else
                {
                    SAPINT.Idocs.Idoc idoc = idocdb.ReadIdoc(this.txtIdocNumber.Text, this.cbxSapSystem.Text);
                    if (idoc != null)
                    {
                        FormIdocMeta formIdocMeta = new FormIdocMeta();

                        formIdocMeta.SapSystemName = this.cbxSapSystem.Text;
                        formIdocMeta.Idoc = idoc;

                        formIdocMeta.IdocToTreeControl();
                        formIdocMeta.DtStatus = idocdb.IdocStatus;
                        formIdocMeta.Show();
                    }
                    else
                    {
                        MessageBox.Show("无法解析IDOC" + this.txtIdocNumber.Text);
                    }

                }

            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }

        }

    }
}
