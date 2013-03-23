using SAP.Middleware.Connector;
using System.Collections.Generic;
using System;
namespace SAPINT.SapConfig
{
    //可增加多个服务器的连接,used for the not interactive activities。
    /// <summary>
    /// 客户端连接参数连接配置
    /// </summary>
    internal class BackupDestinationConfiguration : IDestinationConfiguration
    {
        #region Events
        public event RfcDestinationManager.ConfigurationChangeHandler ConfigurationChanged;
        #endregion Events
        #region Methods
        public bool ChangeEventsSupported()
        {
            return false;
        }
        public RfcConfigParameters GetParameters(String destinationName)
        {
            if ("RETDEV1".Equals(destinationName))
            {
                RfcConfigParameters parms = new RfcConfigParameters();
                parms.Add(RfcConfigParameters.Name, "RETDEV");
                parms.Add(RfcConfigParameters.AppServerHost, "192.168.0.208");
                parms.Add(RfcConfigParameters.SAPRouter, "/H/183.62.136.248/H/");
                parms.Add(RfcConfigParameters.SystemNumber, "00");
                parms.Add(RfcConfigParameters.SystemID, "RET");
                parms.Add(RfcConfigParameters.User, "WWS");
                parms.Add(RfcConfigParameters.Password, "123456");
                parms.Add(RfcConfigParameters.Client, "765");
                parms.Add(RfcConfigParameters.Language, "ZH");
                
               // parms.Add(RfcConfigParameters.PoolSize, "5");
               // parms.Add(RfcConfigParameters.MaxPoolSize, "10");
               // parms.Add(RfcConfigParameters.IdleTimeout, "60");
                parms.Add(RfcConfigParameters.AbapDebug, "true");
                return parms;
            }
            else if ("RETNEW1".Equals(destinationName))
            {
                RfcConfigParameters parms = new RfcConfigParameters();
                parms.Add(RfcConfigParameters.Name, "RETNEW");
                parms.Add(RfcConfigParameters.AppServerHost, "192.168.0.208");
                parms.Add(RfcConfigParameters.SAPRouter, "/H/183.62.136.248/H/");
                parms.Add(RfcConfigParameters.SystemNumber, "00");
                parms.Add(RfcConfigParameters.SystemID, "RET");
                parms.Add(RfcConfigParameters.User, "wwsheng");
                parms.Add(RfcConfigParameters.Password, "wwsheng");
                parms.Add(RfcConfigParameters.Client, "900");
                parms.Add(RfcConfigParameters.Language, "ZH");
               // parms.Add(RfcConfigParameters.PoolSize, "5");
              //  parms.Add(RfcConfigParameters.MaxPoolSize, "10");
               // parms.Add(RfcConfigParameters.IdleTimeout, "60");
                parms.Add(RfcConfigParameters.AbapDebug, "true");
                
                return parms;
            }
            else if ("CHJ".Equals(destinationName))
            {
                RfcConfigParameters parms = new RfcConfigParameters();
                parms.Add(RfcConfigParameters.Name, "CHJ");
                parms.Add(RfcConfigParameters.AppServerHost, "192.168.0.252");
                parms.Add(RfcConfigParameters.SystemNumber, "00");
                parms.Add(RfcConfigParameters.SAPRouter, "/H/61.141.22.72/H/");
                parms.Add(RfcConfigParameters.SystemID, "DEV");
                parms.Add(RfcConfigParameters.User, "wwsheng");
                parms.Add(RfcConfigParameters.Password, "wwsheng");
                parms.Add(RfcConfigParameters.Client, "800");
                parms.Add(RfcConfigParameters.Language, "ZH");
                parms.Add(RfcConfigParameters.PoolSize, "5");
                parms.Add(RfcConfigParameters.MaxPoolSize, "10");
                parms.Add(RfcConfigParameters.IdleTimeout, "60");
                parms.Add(RfcConfigParameters.AbapDebug, "true");
                return parms;
            }
            else return null;
        }
        #endregion Methods
    }
}
