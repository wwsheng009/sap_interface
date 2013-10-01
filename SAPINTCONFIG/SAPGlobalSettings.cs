using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections;


namespace ConfigFileTool
{
    public static class SAPGlobalSettings
    {
        private static SapDefaultSettingSection defaultSettingSection = null;
        private static String defaultconfigfilepath = "D:\\sapint.config";
        public static Configuration config { get; private set; }

        public static List<String> SapClientList
        {
            get { return GetSAPClientList(); }

        }
        static SAPGlobalSettings()
        {

            config = ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap() { ExeConfigFilename = defaultconfigfilepath }, ConfigurationUserLevel.None);
        }
        public static string GetDefaultSapCient()
        {
            try
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
            catch (Exception)
            {

                throw;
            }


        }
        public static string GetDefultSAPServer()
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
        public static string GetDefaultDbConnection()
        {

            defaultSettingSection = (SapDefaultSettingSection)config.GetSection("SAPDefaultSetting");

            // defaultSettingSection = (SapDefaultSettingSection)ConfigurationManager.GetSection("SAPDefaultSetting");
            if (defaultSettingSection != null)
            {
                return defaultSettingSection.DefaultDb;
            }
            return "";

        }

        public static string GetCodeTemplateDb()
        {
            XmlKeyValueSection globalSettingSection = (XmlKeyValueSection)config.GetSection("GlobalSetting");
            return globalSettingSection.KeyValues["CodeTemplate"].Value;
        }
        public static string GetSettingsFromDb()
        {
            XmlKeyValueSection globalSettingSection = (XmlKeyValueSection)config.GetSection("GlobalSetting");
            return globalSettingSection.KeyValues["SettingDb"].Value;
        }
        public static string GetDefaultCodeManagerDb()
        {

            XmlKeyValueSection globalSettingSection = (XmlKeyValueSection)config.GetSection("GlobalSetting");
            //XmlKeyValueSection globalSettingSection = (XmlKeyValueSection)System.Configuration.ConfigurationManager.GetSection("GlobalSetting");
            return globalSettingSection.KeyValues["CodeManagerDb"].Value;
        }
        public static string GetReadTableFunction()
        {
            XmlKeyValueSection globalSettingSection = (XmlKeyValueSection)config.GetSection("GlobalSetting");
            //XmlKeyValueSection globalSettingSection = (XmlKeyValueSection)System.Configuration.ConfigurationManager.GetSection("GlobalSetting");
            return globalSettingSection.KeyValues["DefaultReadTableFunction"].Value;
        }

        public static List<String> GetSAPClientList()
        {
            List<String> clientList = new List<string>();

            ConfigFileTool.SapConfig.RfcDestinationCollection sapclient = SAPClientServerSetting.getClientSettings();
            if (sapclient != null)
            {
                IEnumerator enumerator = sapclient.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    ConfigFileTool.SapConfig.RfcDestinationParameters current = (ConfigFileTool.SapConfig.RfcDestinationParameters)enumerator.Current;
                    clientList.Add(current.Name);
                }
            }

            return clientList;
        }

        public static List<String> GetSAPServerList()
        {
            List<String> serverList = new List<string>();
            ConfigFileTool.SapConfig.RfcServerCollection sapserver = SAPClientServerSetting.getServerSettings();
            if (sapserver != null)
            {

                IEnumerator enumerator1 = sapserver.GetEnumerator();
                while (enumerator1.MoveNext())
                {
                    ConfigFileTool.SapConfig.RfcServerParameters current = (ConfigFileTool.SapConfig.RfcServerParameters)enumerator1.Current;
                    serverList.Add(current.Name);
                }
            }
            return serverList;

        }

        public static List<String> GetManagerDbList()
        {
            return GetDbConnectionList("CMD_");
        }
        public static List<String> GetDbConnectionList(string filter = "")
        {

            List<String> dbList = new List<string>();

            if (string.IsNullOrEmpty(filter))
            {
                filter = "V_";
            }

            //foreach (ConnectionStringSettings item in System.Configuration.ConfigurationManager.ConnectionStrings)
            //{
            //    dbList.Add(item.Name);
            //}
            //return dbList;

            ConnectionStringSettingsCollection connections = GetConnectionStrings();
            IEnumerator enumerator = connections.GetEnumerator();
            while (enumerator.MoveNext())
            {
                ConnectionStringSettings current = (ConnectionStringSettings)enumerator.Current;
                if (current.Name.StartsWith(filter))
                {
                    dbList.Add(current.Name);
                }

            }
            return dbList;
        }




        public static ConnectionStringSettingsCollection GetConnectionStrings()
        {
            ConnectionStringsSection connections = (ConnectionStringsSection)config.GetSection("connectionStrings");
            return connections.ConnectionStrings;
        }

        internal static void reload()
        {
            config = ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap() { ExeConfigFilename = defaultconfigfilepath }, ConfigurationUserLevel.None);
        }
    }
}
