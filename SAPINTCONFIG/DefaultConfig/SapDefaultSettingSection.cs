using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ConfigFileTool
{
    //SAP默认设置节点设置
    internal class SapDefaultSettingSection : ConfigurationSection
    {
        [ConfigurationProperty("db",IsRequired = true)]
        public string DefaultDb
        {
            get { return this["db"].ToString(); }
            set { this["db"] = value; }
        }

        [ConfigurationProperty("sapclient", IsRequired = true)]
        public string DefaultSapClient
        {
            get { return this["sapclient"].ToString(); }
            set { this["sapclient"] = value; }
        }

        [ConfigurationProperty("sapserver",IsRequired = false)]
        public string DefaultSapServer
        {
            get { return this["sapserver"].ToString(); }
            set { this["sapserver"] = value; }
        }
    }
}
