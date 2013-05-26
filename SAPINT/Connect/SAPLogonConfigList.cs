using System.Collections.Generic;
using SAP.Middleware.Connector;
using Microsoft.Win32;
using SAPINT.Controls;
using System;
namespace SAPINT
{
    //程序运行时保存在内存中的SAP客户端连接的信息列表。
    public class SAPLogonConfigList
    {
        private static Dictionary<string, SapConfigClass> systemList = new Dictionary<string, SapConfigClass>();
        private static List<string> _systemNameList = new List<string>();
        public static Dictionary<string, SapConfigClass> SystemList
        {
            get
            {
                return systemList;
            }
        }
        public static List<String> SystemNameList
        {
            get
            {
                return _systemNameList;
            }
        }

        
        /// <summary>
        //根据SAP GUI 客户端保存的配置文件的路径自动加载系统配置列表
        /// </summary>
        /// <returns></returns>
        public static bool loadDefaultSystemListFromSAPLogonIniFile()
        {
            SapConfigClass _config;
            bool success = false;
            string saplogonini = "";
            try
            {
                //根据注册表读取sap logon.ini文件的存放位置
                RegistryKey hkml = Registry.CurrentUser.OpenSubKey("SOFTWARE").OpenSubKey("SAP").OpenSubKey("SAPLogon").OpenSubKey("ConfigFilesLastUsed");
                saplogonini = hkml.GetValue("ConnectionConfigFile").ToString();
                if (saplogonini != "")
                {
                    ReadIniSection sConfiguration = new ReadIniSection(saplogonini, "Configuration");
                    int sessionCount = int.Parse(sConfiguration["SessManNewKey"]);
                    if (sessionCount == 1)
                    {
                        //  MessageBox.Show("请在SAP客户端配置SAP连接配置！！");
                    }
                    ReadIniSection sEntryKey = new ReadIniSection(saplogonini, "EntryKey");
                    ReadIniSection sRouter = new ReadIniSection(saplogonini, "Router");
                    ReadIniSection sServer = new ReadIniSection(saplogonini, "Server");
                    ReadIniSection sDatabase = new ReadIniSection(saplogonini, "Database");
                    ReadIniSection sDescription = new ReadIniSection(saplogonini, "Description");
                    ReadIniSection sMSSysName = new ReadIniSection(saplogonini, "MSSysName");
                    ReadIniSection sMSSrvPort = new ReadIniSection(saplogonini, "MSSrvPort");
                    for (int i = 1; i < sessionCount; i++)
                    {
                        string key = "Item" + i;

                        _config = new SapConfigClass();
                        _config.Name = sDescription[key];
                        if (string.IsNullOrEmpty(_config.Name))
                        {
                            continue;
                        }
                        _config.AppServerHost = sServer[key];
                        _config.SystemID = sMSSysName[key];
                        _config.SAPRouter = sRouter[key];
                        _config.SystemNumber = sDatabase[key];
                        // _config.User = txtUser.Text.Trim().ToUpper();
                        //_config.Password = txtPassword.Text.Trim();
                        _config.Client = "800";
                        _config.Language = "EN";
                        _config.PoolSize = "5";
                        _config.MaxPoolSize = "10";
                        _config.IdleTimeout = "60";
                        SAPLogonConfigList.AddConfig(_config.Name, _config);
                    }

                    success = true;
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
            return success;
        }
        //Add one system config
        public static void AddConfig(string name, SapConfigClass config)
        {
            name = name.Trim().ToUpper();
            if (string.IsNullOrEmpty(name))
            {
                throw new SAPException(Messages.EmptyName);
            }
            config.Name = name;
            if (systemList.ContainsKey(name))
            {
                systemList[name] = config;
            }
            else
            {
                systemList.Add(name, config);
                SystemNameList.Add(name);
            }
        }
        public static SapConfigClass GetConfig(string name)
        {
            name = name.Trim().ToUpper();
            if (systemList.ContainsKey(name))
            {
                return systemList[name];
            }
            else
            {
                return null;
            }
        }
        public static bool RemoveConfig(string name)
        {
            name = name.Trim().ToUpper();
            if (string.IsNullOrEmpty(name))
            {
                throw new SAPException(Messages.EmptyName);
            }
            if (systemList.ContainsKey(name))
            {
                systemList.Remove(name);
                SystemNameList.Remove(name);
                return true;
            }
            else
            {
                throw new SAPException(Messages.Configisnotexist);
            }
        }
        public static void InitSystemList()
        {
            //SapConfig _config;
            //_config = new SapConfig();
            //_config.Name = "DEV_000";
            //_config.AppServerHost = "/H/183.62.234.131/H/192.168.123.31";
            //_config.SystemID = "DEV";
            //_config.SystemNumber = "00";
            //_config.User = "wangws";
            //_config.Password = "wwsheng";
            //_config.Client = "700";
            //_config.Language = "ZH";
            //_config.PoolSize = "5";
            //_config.MaxPoolSize = "10";
            //_config.IdleTimeout = "60";
            //SAPConfigList.AddConfig(_config.Name, _config);
            //_config = new SapConfig();
            //_config.Name = "PRD_700";
            //_config.AppServerHost = "/H/183.62.234.131/H/192.168.123.32";
            //_config.SystemID = "PRD";
            //_config.SystemNumber = "00";
            //_config.User = "wangws";
            //_config.Password = "wwsheng";
            //_config.Client = "700";
            //_config.Language = "ZH";
            //_config.PoolSize = "5";
            //_config.MaxPoolSize = "10";
            //_config.IdleTimeout = "60";
            //SAPConfigList.AddConfig(_config.Name, _config);
        }
    }
    public class SapConfigClass
    {
        public string AbapDebug { set; get; }
        public string AliasUser { set; get; }
        public string AppServerHost { set; get; }
        public string AppServerService { set; get; }
        public string CharacterFaultIndicatorToken { set; get; }
        public string Client { set; get; }
        public string Codepage { set; get; }
        public string GatewayHost { set; get; }
        public string GatewayService { set; get; }
        public string IdleCheckTime { set; get; }
        public string IdleTimeout { set; get; }
        public string Language { set; get; }
        public string LogonCheck { set; get; }
        public string LogonGroup { set; get; }
        public string MaxPoolSize { set; get; }
        public string MaxPoolWaitTime { set; get; }
        public string MessageServerHost { set; get; }
        public string MessageServerService { set; get; }
        public string Name { set; get; }
        public string NoCompression { set; get; }
        public string OnCharacterConversionError { set; get; }
        public string PartnerCharSize { set; get; }
        public string Password { set; get; }
        public string PasswordChangeEnforced { set; get; }
        public string PoolSize { set; get; }
        public string ProgramID { set; get; }
        public string RegistrationCount { set; get; }
        public string RepositoryDestination { set; get; }
        public string RepositoryPassword { set; get; }
        public string RepositorySncMyName { set; get; }
        public string RepositoryUser { set; get; }
        public string RepositoryX509Certificate { set; get; }
        public string SAPRouter { set; get; }
        public string SAPSSO2Ticket { set; get; }
        public string SncLibraryPath { set; get; }
        public string SncMode { set; get; }
        public string SncMyName { set; get; }
        public string SncPartnerName { set; get; }
        public string SncPartnerNames { set; get; }
        public string SncQOP { set; get; }
        public string SystemID { set; get; }
        public string SystemIDs { set; get; }
        public string SystemNumber { set; get; }
        public string Trace { set; get; }
        public string User { set; get; }
        public string UseSAPGui { set; get; }
        public string X509Certificate { set; get; }
        public RfcConfigParameters GetParameters()
        {
            RfcConfigParameters paras = new RfcConfigParameters();
            if (!string.IsNullOrEmpty(this.AbapDebug))
            {
                paras.Add(RfcConfigParameters.AbapDebug, this.AbapDebug.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.AliasUser))
            {
                paras.Add(RfcConfigParameters.AliasUser, this.AliasUser.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.AppServerHost))
            {
                paras.Add(RfcConfigParameters.AppServerHost, this.AppServerHost.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.AppServerService))
            {
                paras.Add(RfcConfigParameters.AppServerService, this.AppServerService.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.CharacterFaultIndicatorToken))
            {
                paras.Add(RfcConfigParameters.CharacterFaultIndicatorToken, this.CharacterFaultIndicatorToken.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.Client))
            {
                paras.Add(RfcConfigParameters.Client, this.Client.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.Codepage))
            {
                paras.Add(RfcConfigParameters.Codepage, this.Codepage.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.GatewayHost))
            {
                paras.Add(RfcConfigParameters.GatewayHost, this.GatewayHost.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.GatewayService))
            {
                paras.Add(RfcConfigParameters.GatewayService, this.GatewayService.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.IdleCheckTime))
            {
                paras.Add(RfcConfigParameters.IdleCheckTime, this.IdleCheckTime.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.IdleTimeout))
            {
                paras.Add(RfcConfigParameters.IdleTimeout, this.IdleTimeout.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.Language))
            {
                paras.Add(RfcConfigParameters.Language, this.Language.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.LogonCheck))
            {
                paras.Add(RfcConfigParameters.LogonCheck, this.LogonCheck.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.LogonGroup))
            {
                paras.Add(RfcConfigParameters.LogonGroup, this.LogonGroup.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.MaxPoolSize))
            {
                paras.Add(RfcConfigParameters.MaxPoolSize, this.MaxPoolSize.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.MaxPoolWaitTime))
            {
                paras.Add(RfcConfigParameters.MaxPoolWaitTime, this.MaxPoolWaitTime.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.MessageServerHost))
            {
                paras.Add(RfcConfigParameters.MessageServerHost, this.MessageServerHost.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.MessageServerService))
            {
                paras.Add(RfcConfigParameters.MessageServerService, this.MessageServerService.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.Name))
            {
                paras.Add(RfcConfigParameters.Name, this.Name.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.NoCompression))
            {
                paras.Add(RfcConfigParameters.NoCompression, this.NoCompression.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.OnCharacterConversionError))
            {
                paras.Add(RfcConfigParameters.OnCharacterConversionError, this.OnCharacterConversionError.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.PartnerCharSize))
            {
                paras.Add(RfcConfigParameters.PartnerCharSize, this.PartnerCharSize.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.Password))
            {
                paras.Add(RfcConfigParameters.Password, this.Password);
            }
            if (!string.IsNullOrEmpty(this.PasswordChangeEnforced))
            {
                paras.Add(RfcConfigParameters.PasswordChangeEnforced, this.PasswordChangeEnforced.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.PoolSize))
            {
                paras.Add(RfcConfigParameters.PoolSize, this.PoolSize.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.ProgramID))
            {
                paras.Add(RfcConfigParameters.ProgramID, this.ProgramID.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.RegistrationCount))
            {
                paras.Add(RfcConfigParameters.RegistrationCount, this.RegistrationCount.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.RepositoryDestination))
            {
                paras.Add(RfcConfigParameters.RepositoryDestination, this.RepositoryDestination.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.RepositoryPassword))
            {
                paras.Add(RfcConfigParameters.RepositoryPassword, this.RepositoryPassword.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.RepositorySncMyName))
            {
                paras.Add(RfcConfigParameters.RepositorySncMyName, this.RepositorySncMyName.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.RepositoryUser))
            {
                paras.Add(RfcConfigParameters.RepositoryUser, this.RepositoryUser.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.RepositoryX509Certificate))
            {
                paras.Add(RfcConfigParameters.RepositoryX509Certificate, this.RepositoryX509Certificate.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.SAPRouter))
            {
                paras.Add(RfcConfigParameters.SAPRouter, this.SAPRouter.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.SAPSSO2Ticket))
            {
                paras.Add(RfcConfigParameters.SAPSSO2Ticket, this.SAPSSO2Ticket.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.SncLibraryPath))
            {
                paras.Add(RfcConfigParameters.SncLibraryPath, this.SncLibraryPath.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.SncMode))
            {
                paras.Add(RfcConfigParameters.SncMode, this.SncMode.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.SncMyName))
            {
                paras.Add(RfcConfigParameters.SncMyName, this.SncMyName.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.SncPartnerName))
            {
                paras.Add(RfcConfigParameters.SncPartnerName, this.SncPartnerName.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.SncPartnerNames))
            {
                paras.Add(RfcConfigParameters.SncPartnerNames, this.SncPartnerNames.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.SncQOP))
            {
                paras.Add(RfcConfigParameters.SncQOP, this.SncQOP.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.SystemID))
            {
                paras.Add(RfcConfigParameters.SystemID, this.SystemID.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.SystemIDs))
            {
                paras.Add(RfcConfigParameters.SystemIDs, this.SystemIDs.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.SystemNumber))
            {
                paras.Add(RfcConfigParameters.SystemNumber, this.SystemNumber.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.Trace))
            {
                paras.Add(RfcConfigParameters.Trace, this.Trace.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.User))
            {
                paras.Add(RfcConfigParameters.User, this.User.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.UseSAPGui))
            {
                paras.Add(RfcConfigParameters.UseSAPGui, this.UseSAPGui.ToUpper());
            }
            if (!string.IsNullOrEmpty(this.X509Certificate))
            {
                paras.Add(RfcConfigParameters.X509Certificate, this.X509Certificate.ToUpper());
            }
            return paras;
        }
    }
}
