using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using System.Collections;
using System.Reflection;
using ConfigFileTool.SapConfig;

namespace SAPINT.SapConfig
{
    internal class DefaultDestinationConfiguration : IDestinationConfiguration
    {
        // Fields
        private Dictionary<string, RfcConfigParameters> destinations;

        // Events
        public event RfcDestinationManager.ConfigurationChangeHandler ConfigurationChanged;

        // Methods
        public DefaultDestinationConfiguration(RfcDestinationCollection destCollection)
        {
            try
            {
                IEnumerator enumerator = destCollection.GetEnumerator();
                this.destinations = new Dictionary<string, RfcConfigParameters>();
                while (enumerator.MoveNext())
                {
                    RfcDestinationParameters current = (RfcDestinationParameters)enumerator.Current;
                    RfcConfigParameters parameters2 = new RfcConfigParameters(0x20);
                    
                    //RfcConfigParameters parameters2 = new RfcConfigParameters();
                    // Assembly a = Assembly.LoadFrom("sapnco.dll");
                   // String ConfigFileToolpath = System.AppDomain.CurrentDomain.BaseDirectory + "ConfigFileTool.dll";
                   // PropertyInfo[] properties = Assembly.LoadFrom(ConfigFileToolpath).GetType("ConfigFileTool.SapConfig.RfcDestinationParameters").GetProperties();
                    PropertyInfo[] properties = current.GetType().GetProperties();
                    //  PropertyInfo[] properties = Assembly.LoadFrom("ConfigFileTool.dll").GetType("ConfigFileTool.SapConfig.RfcDestinationParameters").GetProperties();

                   // String sapncoPath = System.AppDomain.CurrentDomain.BaseDirectory + "sapnco.dll";
                   //  Type type = Assembly.LoadFrom(sapncoPath).GetType("SAP.Middleware.Connector.RfcConfigParameters");
                   //  Type type = Assembly.LoadFrom("sapnco.dll").GetType("SAP.Middleware.Connector.RfcConfigParameters");
                    Type type = parameters2.GetType();
                    for (int i = 0; i < properties.Length; i++)
                    {

                        string str = properties[i].GetValue(current, null) as string;
                        if ((str != null) && (str.Length > 0))
                        {
                            parameters2[(string)type.GetField(properties[i].Name).GetValue(null)] = str;
                        }
                    }
                    this.destinations[current.Name] = parameters2;
                    SAPLogonConfigList.SystemNameList.Add(current.Name);
                }
            }
            catch (Exception exception)
            {

                throw new SAPException(exception.Message + "无法加载程序集ConfigFileTool.exe,或sapnco.dll");
            }

        }

        public bool ChangeEventsSupported()
        {
            return false;
        }

        public RfcConfigParameters GetParameters(string destinationName)
        {
            RfcConfigParameters parameters = null;
            this.destinations.TryGetValue(destinationName, out parameters);
            return parameters;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (string str in this.destinations.Keys)
            {
                if (builder.Length > 0)
                {
                    builder.Append(' ');
                }
                builder.Append(str);
                builder.Append(":[");
                builder.Append(this.destinations[str].ToString());
                builder.Append(']');
            }
            return builder.ToString();
        }
    }
}
