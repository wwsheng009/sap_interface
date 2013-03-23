using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ConfigFileTool.SapConfig
{
    internal class RfcServerConfiguration : ConfigurationSection
    {
        // Properties
        [ConfigurationProperty("servers", IsRequired = true)]
        public RfcServerCollection Servers
        {
            get
            {
                return (RfcServerCollection)base["servers"];
            }
            set
            {
                base["servers"] = value;
            }
        }
    }


}
