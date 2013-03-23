using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ConfigFileTool.SapConfig
{
    /// <summary>
    /// SAP服务端连接参数
    /// </summary>
    public class RfcServerCollection : ConfigurationElementCollection
    {
        // Methods
        public void Add(ConfigurationElement elem)
        {
            this.BaseAdd(elem);
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new RfcServerParameters(string.Empty);
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((RfcServerParameters)element).Name;
        }
    }


}
