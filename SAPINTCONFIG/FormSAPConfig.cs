using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Reflection;
using System.Collections;

namespace ConfigFileTool
{
    public partial class FormSAPConfig : Form
    {
        public FormSAPConfig()
        {
            InitializeComponent();
            loadConfigOptions();
            readConfig();
        }

        public void loadConfigOptions()
        {
          
            this.cbxDb.DataSource = SAPGlobalSettings.GetDbConnectionList();
            cbxSAPClient.DataSource = SAPGlobalSettings.GetSAPClientList();
            cbxSAPServer.DataSource = SAPGlobalSettings.GetSAPServerList();





            //foreach (ConnectionStringSettings item in System.Configuration.ConfigurationManager.ConnectionStrings)
            //{
            //    this.cbxDb.Items.Add(item.Name);
            //}
            ////

            //ConfigFileTool.SapConfig.RfcDestinationCollection sapclient = SAPClientServerSetting.getClientSettings();
            //IEnumerator enumerator = sapclient.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    ConfigFileTool.SapConfig.RfcDestinationParameters current = (ConfigFileTool.SapConfig.RfcDestinationParameters)enumerator.Current;
            //    cbxSAPClient.Items.Add(current.Name);
            //}
            //ConfigFileTool.SapConfig.RfcServerCollection sapserver = SAPClientServerSetting.getServerSettings();
            //IEnumerator enumerator1 = sapserver.GetEnumerator();
            //while (enumerator1.MoveNext())
            //{
            //    ConfigFileTool.SapConfig.RfcServerParameters current = (ConfigFileTool.SapConfig.RfcServerParameters)enumerator1.Current;
            //    cbxSAPServer.Items.Add(current.Name);
            //}
        }

        private void readConfig()
        {
            // SapDefaultSettingSection defaultSettingSection = (SapDefaultSettingSection)ConfigurationManager.GetSection("SAPDefaultSetting");
            SAPGlobalSettings.reload();
            this.cbxDb.DataSource = SAPGlobalSettings.GetDbConnectionList();
            cbxSAPClient.DataSource = SAPGlobalSettings.GetSAPClientList();
            cbxSAPServer.DataSource = SAPGlobalSettings.GetSAPServerList();

            SapDefaultSettingSection defaultSettingSection = (SapDefaultSettingSection)SAPGlobalSettings.config.GetSection("SAPDefaultSetting");
            this.cbxSAPClient.Text = defaultSettingSection.DefaultSapClient;
            this.cbxDb.Text = defaultSettingSection.DefaultDb;
            this.cbxSAPServer.Text = defaultSettingSection.DefaultSapServer;


            XmlKeyValueSection globalSettingSection = (XmlKeyValueSection)SAPGlobalSettings.config.GetSection("GlobalSetting");
            // XmlKeyValueSection globalSettingSection = (XmlKeyValueSection)System.Configuration.ConfigurationManager.GetSection("GlobalSetting");
            txtKeyValues.Text = string.Join("\r\n",
                                    (from kv in globalSettingSection.KeyValues.Cast<XmlKeyValueSetting>()
                                     let s = string.Format("{0}={1}", kv.Key, kv.Value)
                                     select s).ToArray());

        }
        private void btnReadConfig_Click(object sender, EventArgs e)
        {
            readConfig();
        }

        private void btnWriteConfig_Click(object sender, EventArgs e)
        {
            SaveConfig();
        }

        private void SaveConfig()
        {
            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            Configuration config = SAPGlobalSettings.config;

            SapDefaultSettingSection defaultSettingSection = config.GetSection("SAPDefaultSetting") as SapDefaultSettingSection;

            defaultSettingSection.DefaultSapClient = this.cbxSAPClient.Text.Trim();
            defaultSettingSection.DefaultSapServer = this.cbxSAPServer.Text.Trim();
            defaultSettingSection.DefaultDb = this.cbxDb.Text.Trim();

            XmlKeyValueSection globalSettingSection = config.GetSection("GlobalSetting") as XmlKeyValueSection;
            globalSettingSection.KeyValues.Clear();

            (from s in txtKeyValues.Lines
             let p = s.IndexOf('=')
             where p > 0
             select new XmlKeyValueSetting { Key = s.Substring(0, p), Value = s.Substring(p + 1) }
            ).ToList()
            .ForEach(kv => globalSettingSection.KeyValues.Add(kv));

            config.Save(ConfigurationSaveMode.Modified);
            //这里需要刷新缓存
            ConfigurationManager.RefreshSection("SAPDefaultSetting");
            ConfigurationManager.RefreshSection("GlobalSetting");
            MessageBox.Show("OK", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


    }




}
