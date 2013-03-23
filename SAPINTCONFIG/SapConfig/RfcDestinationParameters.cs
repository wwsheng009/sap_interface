using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ConfigFileTool.SapConfig
{
    public class RfcDestinationParameters : RfcGeneralParameters
    {
        // Methods
        public RfcDestinationParameters(string alias)
        {
            base.Name = alias;
        }

        // Properties
        [ConfigurationProperty("ABAP_DEBUG", IsRequired = false)]
        public string AbapDebug
        {
            get
            {
                return (string)base["ABAP_DEBUG"];
            }
            set
            {
                base["ABAP_DEBUG"] = value;
            }
        }

        [ConfigurationProperty("ASHOST", IsRequired = false)]
        public string AppServerHost
        {
            get
            {
                return (string)base["ASHOST"];
            }
            set
            {
                base["ASHOST"] = value;
            }
        }

        [ConfigurationProperty("ASSERV", IsRequired = false)]
        public string AppServerService
        {
            get
            {
                return (string)base["ASSERV"];
            }
            set
            {
                base["ASSERV"] = value;
            }
        }

        [ConfigurationProperty("CLIENT", IsRequired = true)]
        public string Client
        {
            get
            {
                return (string)base["CLIENT"];
            }
            set
            {
                base["CLIENT"] = value;
            }
        }

        [ConfigurationProperty("IDLE_TIMEOUT", IsRequired = false)]
        public string IdleTimeout
        {
            get
            {
                return (string)base["IDLE_TIMEOUT"];
            }
            set
            {
                base["IDLE_TIMEOUT"] = value;
            }
        }

        [ConfigurationProperty("LANG", IsRequired = true)]
        public string Language
        {
            get
            {
                return (string)base["LANG"];
            }
            set
            {
                base["LANG"] = value;
            }
        }

        [ConfigurationProperty("GROUP", IsRequired = false)]
        public string LogonGroup
        {
            get
            {
                return (string)base["GROUP"];
            }
            set
            {
                base["GROUP"] = value;
            }
        }

        [ConfigurationProperty("MAX_POOL_SIZE", IsRequired = false)]
        public string MaxPoolSize
        {
            get
            {
                return (string)base["MAX_POOL_SIZE"];
            }
            set
            {
                base["MAX_POOL_SIZE"] = value;
            }
        }

        [ConfigurationProperty("MSHOST", IsRequired = false)]
        public string MessageServerHost
        {
            get
            {
                return (string)base["MSHOST"];
            }
            set
            {
                base["MSHOST"] = value;
            }
        }

        [ConfigurationProperty("MSSERV", IsRequired = false)]
        public string MessageServerService
        {
            get
            {
                return (string)base["MSSERV"];
            }
            set
            {
                base["MSSERV"] = value;
            }
        }

        [ConfigurationProperty("PASSWD", IsRequired = false)]
        public string Password
        {
            get
            {
                return (string)base["PASSWD"];
            }
            set
            {
                base["PASSWD"] = value;
            }
        }

        [ConfigurationProperty("PASSWORD_CHANGE_ENFORCED", IsRequired = false)]
        public string PasswordChangeEnforced
        {
            get
            {
                return (string)base["PASSWORD_CHANGE_ENFORCED"];
            }
            set
            {
                base["PASSWORD_CHANGE_ENFORCED"] = value;
            }
        }

        [ConfigurationProperty("POOL_SIZE", IsRequired = false)]
        public string PoolSize
        {
            get
            {
                return (string)base["POOL_SIZE"];
            }
            set
            {
                base["POOL_SIZE"] = value;
            }
        }

        [ConfigurationProperty("MYSAPSSO2", IsRequired = false)]
        public string SAPSSO2Ticket
        {
            get
            {
                return (string)base["MYSAPSSO2"];
            }
            set
            {
                base["MYSAPSSO2"] = value;
            }
        }

        [ConfigurationProperty("SYSID", IsRequired = false)]
        public string SystemID
        {
            get
            {
                return (string)base["SYSID"];
            }
            set
            {
                base["SYSID"] = value;
            }
        }

        [ConfigurationProperty("SYSNR", IsRequired = false)]
        public string SystemNumber
        {
            get
            {
                return (string)base["SYSNR"];
            }
            set
            {
                base["SYSNR"] = value;
            }
        }

        [ConfigurationProperty("USER", IsRequired = false)]
        public string User
        {
            get
            {
                return (string)base["USER"];
            }
            set
            {
                base["USER"] = value;
            }
        }

        [ConfigurationProperty("USE_SAPGUI", IsRequired = false)]
        public string UseSAPGui
        {
            get
            {
                return (string)base["USE_SAPGUI"];
            }
            set
            {
                base["USE_SAPGUI"] = value;
            }
        }

        [ConfigurationProperty("X509CERT", IsRequired = false)]
        public string X509Certificate
        {
            get
            {
                return (string)base["X509CERT"];
            }
            set
            {
                base["X509CERT"] = value;
            }
        }

    }
}
