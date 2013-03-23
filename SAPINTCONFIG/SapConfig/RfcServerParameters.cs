using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ConfigFileTool.SapConfig
{
    public class RfcServerParameters : RfcGeneralParameters
    {
        // Methods
        public RfcServerParameters(string alias)
        {
            base.Name = alias;
        }

        // Properties
        [ConfigurationProperty("GWHOST", IsRequired = true)]
        public string GatewayHost
        {
            get
            {
                return (string)base["GWHOST"];
            }
            set
            {
                base["GWHOST"] = value;
            }
        }

        [ConfigurationProperty("GWSERV", IsRequired = true)]
        public string GatewayService
        {
            get
            {
                return (string)base["GWSERV"];
            }
            set
            {
                base["GWSERV"] = value;
            }
        }

        [ConfigurationProperty("PROGRAM_ID", IsRequired = true)]
        public string ProgramID
        {
            get
            {
                return (string)base["PROGRAM_ID"];
            }
            set
            {
                base["PROGRAM_ID"] = value;
            }
        }

        [ConfigurationProperty("REG_COUNT", IsRequired = false)]
        public string RegistrationCount
        {
            get
            {
                return (string)base["REG_COUNT"];
            }
            set
            {
                base["REG_COUNT"] = value;
            }
        }

        [ConfigurationProperty("SNC_PARTNER_NAMES", IsRequired = false)]
        public string SncPartnerNames
        {
            get
            {
                return (string)base["SNC_PARTNER_NAMES"];
            }
            set
            {
                base["SNC_PARTNER_NAMES"] = value;
            }
        }

        [ConfigurationProperty("SYS_IDS", IsRequired = false)]
        public string SystemIDs
        {
            get
            {
                return (string)base["SYS_IDS"];
            }
            set
            {
                base["SYS_IDS"] = value;
            }
        }
    }



}
