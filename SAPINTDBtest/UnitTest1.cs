using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAPINTGUI;

namespace SAPINTDBtest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            SAPINTGUI.AbapCode.FormImportFile frm = new SAPINTGUI.AbapCode.FormImportFile();
            frm.Show();
        }
    }
}
