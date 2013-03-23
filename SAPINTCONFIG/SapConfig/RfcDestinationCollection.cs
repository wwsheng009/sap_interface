using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ConfigFileTool.SapConfig
{
    public class RfcDestinationCollection : ConfigurationElementCollection
    {
        // Methods
        public void Add(ConfigurationElement elem)
        {
            this.BaseAdd(elem);
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new RfcDestinationParameters(string.Empty);
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((RfcDestinationParameters)element).Name;
        }
    }
}
