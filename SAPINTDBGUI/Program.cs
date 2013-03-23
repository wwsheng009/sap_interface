using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SAPINTDBGUI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
           // SAPINT.SapConfig.SAPConfigFromFile.LoadSAPAllConfig();
            SAPINT.SapConfig.SAPConfigFromFile.LoadSAPClientConfig();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
