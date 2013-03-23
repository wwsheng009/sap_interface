using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;
using SAP.Middleware.Connector;
using System.Collections;
using ConfigFileTool;
using ConfigFileTool.SapConfig;

namespace SAPINT.SapConfig
{
    public class SAPConfigFromFile
    {
        public static bool _serverStarted = false;
        public static bool _clientStarted = false;

        public static bool ServerStarted
        {
            get { return _serverStarted; }
            private set { _serverStarted = value; }
        }

        public static bool ClientStarted
        {
            get { return _clientStarted; }
            private set { _clientStarted = value; }
        }


        //public static List<string> LoadSAPClientSettings()
        //{
        //    List<String> ClientList = new List<string>();
        //    try
        //    {
        //        ConfigurationSectionGroup sectionGroup = getSapSectionGroup();
        //        RfcGeneralConfiguration configuration2 = getSAPGeneralConfiguration(sectionGroup);
        //        RfcDestinationCollection clientsSetting = getClientSettings(sectionGroup);

        //        IEnumerator enumerator = clientsSetting.GetEnumerator();

        //        while (enumerator.MoveNext())
        //        {
        //            RfcDestinationParameters current = (RfcDestinationParameters)enumerator.Current;
        //            ClientList.Add(current.Name);

        //        }
        //        // RfcDestinationManager.RegisterDefaultConfiguration(new DefaultDestinationConfiguration(clientsSetting));
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return ClientList;
        //}
        public static bool LoadSAPClientConfig()
        {
            try
            {
                if (_clientStarted == false)
                {
                    RfcDestinationCollection clientsSetting = ConfigFileTool.SAPClientServerSetting.getClientSettings();
                    if (clientsSetting != null)
                    {
                        RfcDestinationManager.RegisterDestinationConfiguration(new DefaultDestinationConfiguration(clientsSetting));
                    }

                    //RfcServerCollection severSetting = ConfigFileTool.SAPClientServerSetting.getServerSettings();
                    //if (severSetting != null)
                    //{
                    //    RfcServerManager.RegisterServerConfiguration(new DefaultServerConfiguration(severSetting));
                    //}

                    // RfcServerManager.loadedFromParameterFile = true;
                    _clientStarted = true;

                }
                return true;

            }
            catch (Exception exception)
            {

                throw new SAPException(exception.Message +　"无法从配置文件加载");
            }
        }
        public static bool LoadSAPServerConfig()
        {
            try
            {
                //RfcDestinationCollection clientsSetting = ConfigFileTool.SAPClientServerSetting.getClientSettings();
                //if (clientsSetting != null)
                //{
                //    RfcDestinationManager.RegisterDestinationConfiguration(new DefaultDestinationConfiguration(clientsSetting));
                //}
                if (_serverStarted == false)
                {
                    RfcServerCollection severSetting = ConfigFileTool.SAPClientServerSetting.getServerSettings();
                    if (severSetting != null)
                    {
                        RfcServerManager.RegisterServerConfiguration(new DefaultServerConfiguration(severSetting));
                    }
                    _serverStarted = true;
                }


                // RfcServerManager.loadedFromParameterFile = true;
                return true;
            }
            catch (Exception)
            {

                throw new SAPException("无法从配置文件加载");
            }
        }

        /// <summary>
        /// 从配置文件中加载SAP的连接配置。
        /// </summary>
        /// <returns></returns>
        public static void LoadSAPAllConfig()
        {

            LoadSAPClientConfig();
            LoadSAPServerConfig();


        }
        //private static ConfigurationSectionGroup getSapSectionGroup()
        //{
        //    System.Configuration.Configuration configuration = null;
        //    configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        //    ConfigurationSectionGroup sectionGroup = configuration.GetSectionGroup("SAPINT");
        //    return sectionGroup;
        //}

        //private static RfcGeneralConfiguration getSAPGeneralConfiguration(ConfigurationSectionGroup sectionGroup)
        //{
        //    RfcGeneralConfiguration configuration2 = null;
        //    if (sectionGroup != null)
        //    {
        //        configuration2 = sectionGroup.Sections["GeneralSettings"] as RfcGeneralConfiguration;

        //        if (configuration2 != null)
        //        {
        //            if (configuration2.DefaultTraceLevel.Length > 0)
        //            {
        //                //
        //            }
        //            string directory = null;
        //            string encoding = null;
        //            bool perThread = true;
        //            if (configuration2.TraceDir.Length > 0)
        //            {
        //                directory = configuration2.TraceDir;
        //            }
        //            if (configuration2.TraceEncoding.Length > 0)
        //            {
        //                encoding = configuration2.TraceEncoding;
        //            }
        //            if (configuration2.TraceType.Equals("PROCESS"))
        //            {
        //                perThread = false;
        //            }
        //            //
        //        }
        //    }
        //    return configuration2;

        //}
        //private static RfcDestinationCollection getClientSettings(ConfigurationSectionGroup sectionGroup)
        //{
        //    if (sectionGroup != null)
        //    {

        //        try
        //        {
        //            ConfigurationSectionGroup group2 = sectionGroup.SectionGroups["ClientSettings"];
        //            if (group2 != null)
        //            {
        //                RfcTypeConfiguration configuration3 = group2.Sections["DestinationTypeConfiguration"] as RfcTypeConfiguration;
        //                if (configuration3 != null)
        //                {
        //                    Type type = Assembly.LoadFrom(configuration3.AssemblyName).GetType(configuration3.TypeName);
        //                    if (type == null)
        //                    {
        //                        throw new Exception("Unable to load class " + configuration3.TypeName + " from " + configuration3.AssemblyName);
        //                    }
        //                    // RfcDestinationManager.RegisterDestinationConfiguration((IDestinationConfiguration)Activator.CreateInstance(type));
        //                }
        //                else
        //                {
        //                    RfcDestinationConfiguration configuration4 = group2.Sections["DestinationConfiguration"] as RfcDestinationConfiguration;
        //                    if (configuration4 != null)
        //                    {
        //                        return configuration4.Destinations;
        //                        // RfcDestinationManager.RegisterDefaultConfiguration(new DefaultDestinationConfiguration(configuration4.Destinations));
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception exception)
        //        {
        //            // RfcTrace.LogError("Could not initialize configuration:", null, exception);
        //            throw;
        //        }

        //    }
        //    return null;
        //}
        //private static RfcServerCollection getServerConfig(ConfigurationSectionGroup sectionGroup)
        //{

        //    if (sectionGroup != null)
        //    {

        //        try
        //        {
        //            ConfigurationSectionGroup group3 = sectionGroup.SectionGroups["ServerSettings"];
        //            if (group3 != null)
        //            {
        //                RfcTypeConfiguration configuration5 = group3.Sections["ServerTypeConfiguration"] as RfcTypeConfiguration;
        //                if (configuration5 != null)
        //                {
        //                    Type type2 = Assembly.LoadFrom(configuration5.AssemblyName).GetType(configuration5.TypeName);
        //                    if (type2 == null)
        //                    {
        //                        throw new Exception("Unable to load class " + configuration5.TypeName + " from " + configuration5.AssemblyName);
        //                    }
        //                    //   RfcServerManager.RegisterServerConfiguration((IServerConfiguration)Activator.CreateInstance(type2));
        //                }
        //                else
        //                {
        //                    RfcServerConfiguration configuration6 = group3.Sections["ServerConfiguration"] as RfcServerConfiguration;
        //                    if (configuration6 != null)
        //                    {
        //                        return configuration6.Servers;
        //                        //  RfcServerManager.RegisterServerConfiguration(new DefaultServerConfiguration(configuration6.Servers));
        //                        //    RfcServerManager.loadedFromParameterFile = true;
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception exception)
        //        {
        //            // RfcTrace.LogError("Could not initialize configuration:", null, exception);
        //            throw;
        //        }

        //    }
        //    return null;
        //}
    }
}
