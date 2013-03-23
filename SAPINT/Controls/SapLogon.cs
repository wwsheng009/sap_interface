using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAP.Middleware.Connector;
using Microsoft.Win32;
namespace SAPINT.Controls
{
    public partial class SapLogon : UserControl
    {
        SapConfigClass _config;
        public SapLogon()
        {
            InitializeComponent();
            cbxName.DataSource = null;
            cbxName.DataSource = SAPLogonConfigList.SystemNameList;
        }

        public SapConfigClass Config
        {
            get
            {
                return _config;
            }
            set
            {
                _config = value;
            }
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                addConfig();
                cbxName.DataSource = null;
                cbxName.DataSource = SAPLogonConfigList.SystemNameList;
                MessageBox.Show("添加成功");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }
        private bool check()
        {
            string name = cbxName.Text.Trim().ToUpper();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("请指定系统");
                return false;
            }
            else return true;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!check())
            {
                return;
            }
            try
            {
                string name = cbxName.Text.Trim().ToUpper();
                SAPLogonConfigList.RemoveConfig(name);
                clear();
                cbxName.DataSource = null;
                cbxName.DataSource = SAPLogonConfigList.SystemNameList;
                MessageBox.Show("删除成功");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        //从内存中根据连接名加载配置。
        private void loadConfigFromMemory()
        {
            if (!check())
            {
                return;
            }
            try
            {
                loadConfig(cbxName.Text.Trim());
                MessageBox.Show("加载成功");
            }
            catch (SAPException ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {

        }
        //增加一个连接配置，如果可以登录成功，加到内存中。
        private void addConfig()
        {
            try
            {
                if (!check())
                {
                    return;
                }
                _config = new SapConfigClass();
                _config.Name = cbxName.Text.Trim().ToUpper();
                _config.AppServerHost = txtAppServerHost.Text.Trim().ToUpper();
                _config.SAPRouter = txtRouter.Text.Trim().ToUpper();
                _config.SystemID = txtSystemId.Text.Trim().ToUpper();
                _config.SystemNumber = txtSystemNumber.Text.Trim().ToUpper();
                _config.User = txtUser.Text.Trim().ToUpper();
                _config.Password = txtPassword.Text.Trim();
                _config.Client = txtClient.Text.Trim().ToUpper();
                _config.Language = txtLanguage.Text.Trim().ToUpper();
                // _config.PoolSize = "5";
                // _config.MaxPoolSize = "10";
                // _config.IdleTimeout = "60";

                RfcDestination des = SAPDestination.GetDesByConfig(_config);
                des.Ping();
                SAPLogonConfigList.AddConfig(_config.Name, _config);
            }
            catch (RfcLogonException e)
            {
                var s = e.Message;
                if ("LOGON_FAILURE" == e.Key)
                {
                    s = s + "登陆失败";
                }
                throw new SAPException(e.Key + s);
            }
            catch (RfcAbapRuntimeException e)
            {
                throw new SAPException(e.Key + e.Message);
            }
            catch (RfcAbapException e)
            {
                throw new SAPException(e.Key + e.Message);
            }

        }
        private void clear()
        {
            cbxName.Text = "";
            txtAppServerHost.Text = "";
            txtSystemId.Text = "";
            txtSystemNumber.Text = "";
            txtClient.Text = "";
            txtLanguage.Text = "";
        }
        //加载配置
        private void loadConfig(string name)
        {
            if (!check())
            {
                return;
            }
            _config = SAPLogonConfigList.GetConfig(name);
            if (_config == null)
            {
                MessageBox.Show("没有找到配置");
            }
            clear();
            cbxName.Text = _config.Name;
            txtAppServerHost.Text = _config.AppServerHost;
            txtRouter.Text = _config.SAPRouter;
            txtSystemId.Text = _config.SystemID;
            txtSystemNumber.Text = _config.SystemNumber;
            txtClient.Text = _config.Client;
            txtLanguage.Text = _config.Language;
        }
        private void cbxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbxName.Text))
            {
                return;
            }
            loadConfig(cbxName.Text);
        }

        //尝试加载SAP客户端自带的sap logon.ini文件
        private void btnloadsaplogonFile_Click(object sender, EventArgs e)
        {
            if (SAPINT.SAPLogonConfigList.loadDefaultSystemListFromSAPLogonIniFile())
            {
                cbxName.DataSource = null;
                cbxName.DataSource = SAPLogonConfigList.SystemNameList;
                MessageBox.Show("成功加载SAP GUI配置文件！");
            }
            else
            {
                MessageBox.Show("请在SAP客户端配置SAP连接配置！！");
            };
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
        }

    }
}
