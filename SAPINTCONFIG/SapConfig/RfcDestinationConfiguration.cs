using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ConfigFileTool.SapConfig
{
    public class RfcDestinationConfiguration : ConfigurationSection
    {
        // Properties
        [ConfigurationProperty("destinations", IsRequired = true)]
        public RfcDestinationCollection Destinations
        {
            get
            {
                return (RfcDestinationCollection)base["destinations"];
            }
            set
            {
                base["destinations"] = value;
            }
        }
    }


}
