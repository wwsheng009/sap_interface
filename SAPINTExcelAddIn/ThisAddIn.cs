using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Tools;
using SAPINT;
using System.Windows.Forms;

namespace ExcelAddIn1
{
    public partial class ThisAddIn
    {

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            SAPINT.SapConfig.SAPConfigFromFile.LoadSAPClientConfig();
            //if (SAPINT.SAPLogonConfigList.loadDefaultSystemListFromSAPLogonIniFile())
            //{

            //   // MessageBox.Show("成功加载SAP GUI配置文件！");
            //}
            //else
            //{
            // //   MessageBox.Show("请在SAP客户端配置SAP连接配置！！");
            //};

            //SapConfig _config;
            //_config = new SapConfig();
            //_config.Name = "DEV_000";
            //_config.AppServerHost = "/H/183.62.234.131/H/192.168.123.31";
            //_config.SystemID = "DEV";
            //_config.SystemNumber = "00";
            //_config.User = "wangws";
            //_config.Password = "wwsheng";
            //_config.Client = "700";
            //_config.Language = "ZH";
            //_config.PoolSize = "5";
            //_config.MaxPoolSize = "10";
            //_config.IdleTimeout = "60";

            //SAPConfigList.AddConfig(_config.Name, _config);

            //_config = new SapConfig();
            //_config.Name = "PRD_700";
            //_config.AppServerHost = "/H/183.62.234.131/H/192.168.123.32";
            //_config.SystemID = "PRD";
            //_config.SystemNumber = "00";
            //_config.User = "wangws";
            //_config.Password = "wwsheng";
            //_config.Client = "700";
            //_config.Language = "ZH";
            //_config.PoolSize = "5";
            //_config.MaxPoolSize = "10";
            //_config.IdleTimeout = "60";

            //SAPConfigList.AddConfig(_config.Name, _config);
        }
        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
           // worksheet.Controls.
            
        }
        
        #endregion
    }
}
