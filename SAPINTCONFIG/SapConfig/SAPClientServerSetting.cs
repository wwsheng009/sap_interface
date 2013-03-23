using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using ConfigFileTool.SapConfig;
using System.Collections;
using System.Reflection;

namespace ConfigFileTool
{
    public sealed class SAPClientServerSetting
    {

        private static ConfigurationSectionGroup sectionGroup;

        static SAPClientServerSetting()
        {
            //加载默认根节点
            getSapSectionGroup();
        }
        /// <summary>
        /// 从配置文件中加载客户端设置的名列表。
        /// </summary>
        /// <returns></returns>
        public static List<string> LoadSAPClientNameList()
        {
            List<String> ClientList = new List<string>();
            try
            {
                RfcGeneralConfiguration configuration2 = getSAPGeneralConfiguration();
                RfcDestinationCollection clientsSetting = getClientSettings();

                IEnumerator enumerator = clientsSetting.GetEnumerator();

                while (enumerator.MoveNext())
                {
                    RfcDestinationParameters current = (RfcDestinationParameters)enumerator.Current;
                    ClientList.Add(current.Name);

                }
                // RfcDestinationManager.RegisterDefaultConfiguration(new DefaultDestinationConfiguration(clientsSetting));
            }
            catch (Exception)
            {

                throw;
            }
            return ClientList;
        }

        ///// <summary>
        ///// 从配置文件中加载SAP的连接配置。
        ///// </summary>
        ///// <returns></returns>
        //public static RfcDestinationCollection LoadSAPAllConfig()
        //{

        //    //if (SAPINT.SAPConfigList.loadDefaultSystemListFromSAPLogonIniFile())
        //    //{
        //    //    // MessageBox.Show("成功加载SAP GUI配置文件！");
        //    //}


        //    try
        //    {

        //        RfcGeneralConfiguration configuration2 = getSAPGeneralConfiguration();
        //        RfcDestinationCollection clientsSetting = getClientSettings();
        //        if (clientsSetting != null)
        //        {
        //            return clientsSetting;
        //         //    RfcDestinationManager.RegisterDestinationConfiguration(new DefaultDestinationConfiguration(clientsSetting));
        //        }

        //        RfcServerCollection severSetting = getServerSettings();
        //        if (severSetting != null)
        //        {
        //         //   RfcServerManager.RegisterServerConfiguration(new DefaultServerConfiguration(severSetting));
        //        }

        //        // RfcServerManager.loadedFromParameterFile = true;

        //    }
        //    catch (Exception)
        //    {

        //        throw new Exception("无法从配置文件加载");
        //    }

        //}
        
        /// <summary>
        /// 加载根节点
        /// </summary>
        private static void getSapSectionGroup()
        {
            System.Configuration.Configuration configuration = null;
            // configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration = SAPGlobalSettings.config;
            sectionGroup = configuration.GetSectionGroup("SAPINT");
            if (sectionGroup==null)
            {
                throw new Exception("无法从配置文件加载SAP配置！！");
            }

        }

        /// <summary>
        /// 加载SAP一般设置
        /// </summary>
        /// <returns></returns>
        private static RfcGeneralConfiguration getSAPGeneralConfiguration()
        {
            RfcGeneralConfiguration configuration2 = null;
            if (sectionGroup != null)
            {
                configuration2 = sectionGroup.Sections["GeneralSettings"] as RfcGeneralConfiguration;

                if (configuration2 != null)
                {
                    if (configuration2.DefaultTraceLevel.Length > 0)
                    {
                        //
                    }
                    string directory = null;
                    string encoding = null;
                    bool perThread = true;
                    if (configuration2.TraceDir.Length > 0)
                    {
                        directory = configuration2.TraceDir;
                    }
                    if (configuration2.TraceEncoding.Length > 0)
                    {
                        encoding = configuration2.TraceEncoding;
                    }
                    if (configuration2.TraceType.Equals("PROCESS"))
                    {
                        perThread = false;
                    }
                    //
                }
            }
            return configuration2;

        }

        /// <summary>
        /// 客户端设置
        /// </summary>
        /// <returns></returns>
        public static RfcDestinationCollection getClientSettings()
        {
            if (sectionGroup != null)
            {

                try
                {
                    ConfigurationSectionGroup group2 = sectionGroup.SectionGroups["ClientSettings"];
                    if (group2 != null)
                    {
                        RfcTypeConfiguration configuration3 = group2.Sections["DestinationTypeConfiguration"] as RfcTypeConfiguration;
                        if (configuration3 != null)
                        {
                            Type type = Assembly.LoadFrom(configuration3.AssemblyName).GetType(configuration3.TypeName);
                            if (type == null)
                            {
                                throw new Exception("Unable to load class " + configuration3.TypeName + " from " + configuration3.AssemblyName);
                            }
                            // RfcDestinationManager.RegisterDestinationConfiguration((IDestinationConfiguration)Activator.CreateInstance(type));
                        }
                        else
                        {
                            RfcDestinationConfiguration configuration4 = group2.Sections["DestinationConfiguration"] as RfcDestinationConfiguration;
                            if (configuration4 != null)
                            {
                                return configuration4.Destinations;
                                // RfcDestinationManager.RegisterDefaultConfiguration(new DefaultDestinationConfiguration(configuration4.Destinations));
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    // RfcTrace.LogError("Could not initialize configuration:", null, exception);
                    throw new Exception(exception.Message);
                }

            }
            return null;
        }
        /// <summary>
        /// 加载客户端服务端设置。
        /// </summary>
        /// <returns></returns>
        public static RfcServerCollection getServerSettings()
        {

            if (sectionGroup != null)
            {

                try
                {
                    ConfigurationSectionGroup group3 = sectionGroup.SectionGroups["ServerSettings"];
                    if (group3 != null)
                    {
                        RfcTypeConfiguration configuration5 = group3.Sections["ServerTypeConfiguration"] as RfcTypeConfiguration;
                        if (configuration5 != null)
                        {
                            Type type2 = Assembly.LoadFrom(configuration5.AssemblyName).GetType(configuration5.TypeName);
                            if (type2 == null)
                            {
                                throw new Exception("Unable to load class " + configuration5.TypeName + " from " + configuration5.AssemblyName);
                            }
                            //   RfcServerManager.RegisterServerConfiguration((IServerConfiguration)Activator.CreateInstance(type2));
                        }
                        else
                        {
                            RfcServerConfiguration configuration6 = group3.Sections["ServerConfiguration"] as RfcServerConfiguration;
                            if (configuration6 != null)
                            {
                                return configuration6.Servers;
                                //  RfcServerManager.RegisterServerConfiguration(new DefaultServerConfiguration(configuration6.Servers));
                                //    RfcServerManager.loadedFromParameterFile = true;
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    // RfcTrace.LogError("Could not initialize configuration:", null, exception);
                    
                    throw;
                }

            }
            return null;
        }
    }
}
