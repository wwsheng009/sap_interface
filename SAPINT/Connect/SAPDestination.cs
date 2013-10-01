namespace SAPINT
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SAP.Middleware.Connector;
    using SAPINT.SapConfig;
    /// <summary>
    /// 根据系统的名字来获取一个SAP CLIENT实例。
    /// </summary>
    public static class SAPDestination
    {
        #region Fields
        private static RfcDestination destination;
        private static string _systemName = String.Empty;
        #endregion Fields
        #region Properties
        static SAPDestination()
        {
            //加载程序中定义的连接参数。
            //  RfcDestinationManager.RegisterDestinationConfiguration(new SAPBackupConfig());
            //  RfcDestinationManager.RegisterDestinationConfiguration(new DefaultDestinationConfiguration());

        }
        public static string SystemName
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _systemName = value;
                    //GetDestination();
                }
            }
            get
            {
                if (string.IsNullOrEmpty(_systemName))
                {
                    _systemName = "DEV_000";
                }
                return _systemName;
            }
        }

        #endregion Properties
        #region Methods
        //根据系统ID返回目标系统
        public static RfcDestination GetDesByName(string sysName)
        {
            if (String.IsNullOrWhiteSpace(sysName))
            {
                throw new SAPException("请指定系统名！！");
            }
            SystemName = sysName.ToUpper().Trim();
            var des = GetDestination();

            try
            {

                des.Ping();
            }
            catch (RfcBaseException ex)
            {
                throw new SAPException(ex.Message);
            }

            catch (Exception E)
            {
                throw new Exception("无法连接SAP系统");
                //return null;
            }

            return des;
        }
        //Get the RfcDestinationi directly by config parameters
        public static RfcDestination GetDesByConfig(SapConfigClass config)
        {
            try
            {

                return RfcDestinationManager.GetDestination(config.GetParameters());
            }
            catch (Exception ee)
            {
                throw new SAPException(ee.Message);
            }
        }
        /// <summary>
        /// 获取SAP连接的实例
        /// </summary>
        /// <returns></returns>
        private static RfcDestination GetDestination()
        {
            if (SAPLogonConfigList.SystemList.ContainsKey(SystemName))
            {
                try
                {

                    destination = RfcDestinationManager.GetDestination(SAPLogonConfigList.SystemList[SystemName].GetParameters());
                }
                catch (Exception e)
                {
                    throw new SAPException(e.Message + "请在配置文件加上兼容配置");
                }
            }
            else
            {
                try
                {
                    destination = RfcDestinationManager.GetDestination(SystemName);
                }
                catch (Exception EE)
                {
                    //try
                    //{
                    //    RfcDestinationManager.RegisterDestinationConfiguration(new BackupDestinationConfiguration());
                    //    destination = RfcDestinationManager.GetDestination(SystemName);
                    //}
                    //catch (Exception e)
                    //{
                    //    throw new SAPException(e.Message + "请在配置文件加上兼容配置");
                    //}
                    throw new SAPException(EE.Message);
                }
            }

            return destination;
        }
        #endregion Methods

    }
}
