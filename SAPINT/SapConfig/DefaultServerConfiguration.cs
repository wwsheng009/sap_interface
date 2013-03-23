using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using System.Collections;
using System.Reflection;
using ConfigFileTool;
using ConfigFileTool.SapConfig;

namespace SAPINT.SapConfig
{
    internal class DefaultServerConfiguration : IServerConfiguration
    {
        // Fields
        private Dictionary<string, RfcConfigParameters> servers;

        // Events
        public event RfcServerManager.ConfigurationChangeHandler ConfigurationChanged;
        private RfcServerCollection severSetting;

        // Methods
        internal DefaultServerConfiguration(RfcServerCollection serverCollection)
        {
            IEnumerator enumerator = serverCollection.GetEnumerator();
            this.servers = new Dictionary<string, RfcConfigParameters>();
            while (enumerator.MoveNext())
            {
                RfcServerParameters current = (RfcServerParameters)enumerator.Current;
                RfcConfigParameters parameters2 = new RfcConfigParameters(0x20);
               // PropertyInfo[] properties = Type.GetType("SAP.Middleware.Connector.RfcServerParameters").GetProperties();
                PropertyInfo[] properties = Assembly.LoadFrom("ConfigFileTool.dll").GetType("ConfigFileTool.SapConfig.RfcServerParameters").GetProperties();
               // Type type = Type.GetType("SAP.Middleware.Connector.RfcConfigParameters");
                Type type = Assembly.LoadFrom("sapnco.dll").GetType("SAP.Middleware.Connector.RfcConfigParameters");
                for (int i = 0; i < properties.Length; i++)
                {
                    string str = properties[i].GetValue(current, null) as string;
                    if ((str != null) && (str.Length > 0))
                    {
                        parameters2[(string)type.GetField(properties[i].Name).GetValue(null)] = str;
                    }
                }
                this.servers[current.Name] = parameters2;
            }
        }


        public bool ChangeEventsSupported()
        {
            return true;
        }

        public RfcConfigParameters GetParameters(string destinationName)
        {
            return this.servers[destinationName];
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (string str in this.servers.Keys)
            {
                if (builder.Length > 0)
                {
                    builder.Append(' ');
                }
                builder.Append(str);
                builder.Append(":[");
                builder.Append(this.servers[str].ToString());
                builder.Append(']');
            }
            return builder.ToString();
        }
    }

 

}
