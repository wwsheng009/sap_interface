using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAPINTDB;

namespace SAPINTGUI.DataBase
{
    public partial class FormSaveDataTable : Form
    {
        private String _sapTableName = null;
        private String _sapStructName = null;
        private String _sapSystemName = null;
        private DataTable _dt = null;

        public String SapTableName
        {
            get
            {
                return _sapTableName;
            }
            set
            {
                this._sapTableName = value;
                this.txtLocalTableName.Text = _sapTableName;
                this.txtSapTableName.Text = _sapTableName;
                this.txtStructName.Text = _sapTableName;
            }
        }
        public String SapSystemName
        {
            get
            {
                return _sapSystemName;
            }
            set
            {
                this._sapSystemName = value;
                this.txtSapSystem.Text = _sapSystemName;
                //  this.txtSapSystem.SelectedText = _sapSystemName;
            }

        }
        public String SapStrutureName
        {
            get
            {
                return _sapStructName;
            }
            set
            {
                this._sapStructName = value;
                this.txtStructName.Text = _sapStructName;
            }

        }

        public DataTable Dt
        {

            get
            {
                return _dt;
            }
            set
            {
                _dt = value;
                if (_dt != null)
                {
                    this.labelRowsCount.Text = _dt.Rows.Count.ToString();
                }

            }
        }


        public String DbConnectionName { get; set; }
        public String LocalTableName { get; set; }

        public FormSaveDataTable()
        {
            InitializeComponent();
            // SAPINT.SAPLogonConfigList.SystemNameList.ForEach(name => this.txtSapSystem.Items.Add(name));
            this.txtSapSystem.Text = _sapSystemName;
            this.txtSapSystem.DataSource = ConfigFileTool.SAPGlobalSettings.getSAPClientList();
            this.txtLocalDbConnection.DataSource = ConfigFileTool.SAPGlobalSettings.getDbConnectionList();
            this.txtLocalDbConnection.Text = ConfigFileTool.SAPGlobalSettings.GetDefaultDbConnection();
        }

        private bool check()
        {
            SapStrutureName = txtStructName.Text.Trim();
            SapSystemName = txtSapSystem.Text.Trim();
            LocalTableName = txtLocalTableName.Text.Trim();

            if (String.IsNullOrWhiteSpace(SapStrutureName) && radioBtNew.Checked == true)
            {
                MessageBox.Show("创建新表需要指定结构名！！");
                return false;
            }
            if (String.IsNullOrWhiteSpace(SapSystemName) && radioBtNew.Checked == true)
            {
                MessageBox.Show("创建新表需要指定SAP系统！！");
                return false;
            }
            if (String.IsNullOrWhiteSpace(LocalTableName))
            {
                MessageBox.Show("请指定表名！！");
                return false;
            }
            return true;
        }

        private void SaveToDb()
        {
            try
            {
                if (check())
                {
                    SapTable table = null;
                    if (!String.IsNullOrWhiteSpace(SapSystemName) && !String.IsNullOrWhiteSpace(SapStrutureName))
                    {
                        table = new SapTable(SapSystemName, LocalTableName, SapStrutureName);
                        table.DbConnectionString = txtLocalDbConnection.Text.Trim();
                        table.AppendToDb = radioBtAppend.Checked;
                        table.NewTable = radioBtNew.Checked;

                    }
                    else
                    {
                        table = new SapTable(LocalTableName);
                        table.DbConnectionString = txtLocalDbConnection.Text.Trim();
                        table.AppendToDb = radioBtAppend.Checked;
                        table.NewTable = radioBtNew.Checked;
                        table.saveDataTable(_dt);
                    } 
                    if (!table.saveDataTable(_dt))
                    {
                        MessageBox.Show(table.ErrorMessage);
                    }
                    else
                    {
                        MessageBox.Show("保存成功！！");
                    }


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        private void btnSaveToDb_Click(object sender, EventArgs e)
        {
            SaveToDb();
        }

        private void readDt()
        {
            SAPINTDB.netlib7 net = new netlib7(this.txtLocalDbConnection.Text.Trim());
            if (_dt == null)
            {
                _dt = new DataTable();
            }

            net.DataTableFill(_dt, String.Format("select * from [{0}]", this.txtLocalTableName.Text));

            this.dataGridView1.DataSource = _dt;
            if (!String.IsNullOrWhiteSpace(net.ErrorMessage))
            {
                MessageBox.Show(net.ErrorMessage);
            }
        }

    }
}
