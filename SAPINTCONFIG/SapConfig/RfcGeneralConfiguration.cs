using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ConfigFileTool.SapConfig
{
    internal class RfcGeneralConfiguration : ConfigurationSection
    {
        // Properties
        [ConfigurationProperty("defaultTraceLevel", IsRequired = false)]
        public string DefaultTraceLevel
        {
            get
            {
                return (string)base["defaultTraceLevel"];
            }
            set
            {
                base["defaultTraceLevel"] = value;
            }
        }

        [ConfigurationProperty("traceDir", IsRequired = false)]
        public string TraceDir
        {
            get
            {
                return (string)base["traceDir"];
            }
            set
            {
                base["traceDir"] = value;
            }
        }

        [ConfigurationProperty("traceEncoding", IsRequired = false)]
        public string TraceEncoding
        {
            get
            {
                return (string)base["traceEncoding"];
            }
            set
            {
                base["traceEncoding"] = value;
            }
        }

        [ConfigurationProperty("traceType", IsRequired = false)]
        public string TraceType
        {
            get
            {
                return (string)base["traceType"];
            }
            set
            {
                base["traceType"] = value;
            }
        }
    }
}
