using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ConfigFileTool.SapConfig
{
    public class RfcGeneralParameters : ConfigurationElement
    {
        // Properties
        [ConfigurationProperty("CFIT", IsRequired = false)]
        public string CharacterFaultIndicatorToken
        {
            get
            {
                return (string)base["CFIT"];
            }
            set
            {
                base["CFIT"] = value;
            }
        }

        [ConfigurationProperty("CODEPAGE", IsRequired = false)]
        public string Codepage
        {
            get
            {
                return (string)base["CODEPAGE"];
            }
            set
            {
                base["CODEPAGE"] = value;
            }
        }

        [ConfigurationProperty("NAME", IsRequired = true)]
        public string Name
        {
            get
            {
                return (string)base["NAME"];
            }
            set
            {
                base["NAME"] = value;
            }
        }

        [ConfigurationProperty("NO_COMPRESSION", IsRequired = false)]
        public string NoCompression
        {
            get
            {
                return (string)base["NO_COMPRESSION"];
            }
            set
            {
                base["NO_COMPRESSION"] = value;
            }
        }

        [ConfigurationProperty("ON_CCE", IsRequired = false)]
        public string OnCharacterConversionError
        {
            get
            {
                return (string)base["ON_CCE"];
            }
            set
            {
                base["ON_CCE"] = value;
            }
        }

        [ConfigurationProperty("PCS", DefaultValue = "1", IsRequired = false)]
        public string PartnerCharSize
        {
            get
            {
                return (string)base["PCS"];
            }
            set
            {
                base["PCS"] = value;
            }
        }

        [ConfigurationProperty("REPOSITORY_DESTINATION", IsRequired = false)]
        public string RepositoryDestination
        {
            get
            {
                return (string)base["REPOSITORY_DESTINATION"];
            }
            set
            {
                base["REPOSITORY_DESTINATION"] = value;
            }
        }

        [ConfigurationProperty("SAPROUTER", IsRequired = false)]
        public string SAPRouter
        {
            get
            {
                return (string)base["SAPROUTER"];
            }
            set
            {
                base["SAPROUTER"] = value;
            }
        }

        [ConfigurationProperty("SNC_LIB", IsRequired = false)]
        public string SncLibraryPath
        {
            get
            {
                return (string)base["SNC_LIB"];
            }
            set
            {
                base["SNC_LIB"] = value;
            }
        }

        [ConfigurationProperty("SNC_MODE", IsRequired = false)]
        public string SncMode
        {
            get
            {
                return (string)base["SNC_MODE"];
            }
            set
            {
                base["SNC_MODE"] = value;
            }
        }

        [ConfigurationProperty("SNC_MYNAME", IsRequired = false)]
        public string SncMyName
        {
            get
            {
                return (string)base["SNC_MYNAME"];
            }
            set
            {
                base["SNC_MYNAME"] = value;
            }
        }

        [ConfigurationProperty("SNC_PARTNERNAME", IsRequired = false)]
        public string SncPartnerName
        {
            get
            {
                return (string)base["SNC_PARTNERNAME"];
            }
            set
            {
                base["SNC_PARTNERNAME"] = value;
            }
        }

        [ConfigurationProperty("SNC_QOP", DefaultValue = "8", IsRequired = false)]
        public string SncQOP
        {
            get
            {
                return (string)base["SNC_QOP"];
            }
            set
            {
                base["SNC_QOP"] = value;
            }
        }

        [ConfigurationProperty("TRACE", DefaultValue = "0", IsRequired = false)]
        public string Trace
        {
            get
            {
                return (string)base["TRACE"];
            }
            set
            {
                base["TRACE"] = value;
            }
        }
    }
}