using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ConfigFileTool.SapConfig
{
    internal class RfcTypeConfiguration : ConfigurationSection
    {
        // Properties
        [ConfigurationProperty("assemblyName", IsRequired = true)]
        public string AssemblyName
        {
            get
            {
                return (string)base["assemblyName"];
            }
            set
            {
                base["assemblyName"] = value;
            }
        }

        [ConfigurationProperty("typeName", IsRequired = true)]
        public string TypeName
        {
            get
            {
                return (string)base["typeName"];
            }
            set
            {
                base["typeName"] = value;
            }
        }
    }

 

}
