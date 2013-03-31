using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections;

namespace ConfigFileTool
{
    public class SAPGlobalSettings
    {
        private SapDefaultSettingSection defaultSettingSection = null;
        private static String defaultconfigfilepath = "D:\\sapint.config";
        public static Configuration config { get; private set; }
        static SAPGlobalSettings()
        {
            
            config = ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap() { ExeConfigFilename = defaultconfigfilepath }, ConfigurationUserLevel.None);
        }
        public string GetDefaultSapCient()
        {

            defaultSettingSection = (SapDefaultSettingSection)config.GetSection("SAPDefaultSetting");
            // defaultSettingSection = (SapDefaultSettingSection)ConfigurationManager.GetSection("SAPDefaultSetting");
            if (defaultSettingSection != null)
            {
                return defaultSettingSection.DefaultSapClient;
            }
            else
            {
                return "";
            }

        }
        public string GetDefultSAPServer()
        {
            defaultSettingSection = (SapDefaultSettingSection)config.GetSection("SAPDefaultSetting");
            // defaultSettingSection = (SapDefaultSettingSection)ConfigurationManager.GetSection("SAPDefaultSetting");
            if (defaultSettingSection != null)
            {
                return defaultSettingSection.DefaultSapServer;
            }
            else
            {
                return "";
            }
        }
        public string GetDefaultDbConnection()
        {

            defaultSettingSection = (SapDefaultSettingSection)config.GetSection("SAPDefaultSetting");

            // defaultSettingSection = (SapDefaultSettingSection)ConfigurationManager.GetSection("SAPDefaultSetting");
            if (defaultSettingSection != null)
            {
                return defaultSettingSection.DefaultDb;
            }
            return "";

        }

        public string GetTemplateDb()
        {

            XmlKeyValueSection globalSettingSection = (XmlKeyValueSection)config.GetSection("GlobalSetting");
            //XmlKeyValueSection globalSettingSection = (XmlKeyValueSection)System.Configuration.ConfigurationManager.GetSection("GlobalSetting");
            return globalSettingSection.KeyValues["DefaultTemplateDb"].Value;
        }
        public  string GetReadTableFunction()
        {
            XmlKeyValueSection globalSettingSection = (XmlKeyValueSection)config.GetSection("GlobalSetting");
            //XmlKeyValueSection globalSettingSection = (XmlKeyValueSection)System.Configuration.ConfigurationManager.GetSection("GlobalSetting");
            return globalSettingSection.KeyValues["DefaultReadTableFunction"].Value;
        }

        public List<String> getSAPClientList()
        {
            List<String> clientList = new List<string>();

            ConfigFileTool.SapConfig.RfcDestinationCollection sapclient = SAPClientServerSetting.getClientSettings();
            IEnumerator enumerator = sapclient.GetEnumerator();
            while (enumerator.MoveNext())
            {
                ConfigFileTool.SapConfig.RfcDestinationParameters current = (ConfigFileTool.SapConfig.RfcDestinationParameters)enumerator.Current;
                clientList.Add(current.Name);
            }
            return clientList;
        }

        public List<String> getSAPServerList()
        {
            List<String> serverList = new List<string>();
            ConfigFileTool.SapConfig.RfcServerCollection sapserver = SAPClientServerSetting.getServerSettings();
            IEnumerator enumerator1 = sapserver.GetEnumerator();
            while (enumerator1.MoveNext())
            {
                ConfigFileTool.SapConfig.RfcServerParameters current = (ConfigFileTool.SapConfig.RfcServerParameters)enumerator1.Current;
                serverList.Add(current.Name);
            }
            return serverList;

        }

        public List<String> getDbConnectionList()
        {
            List<String> dbList = new List<string>();
            foreach (ConnectionStringSettings item in System.Configuration.ConfigurationManager.ConnectionStrings)
            {
                dbList.Add(item.Name);
            }
            return dbList;
        }
    }
}
