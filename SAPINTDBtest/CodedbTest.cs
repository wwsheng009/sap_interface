using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAPINTDB;
using System.Data;
using SAPINTDB.CodeManager;

namespace SAPINTDBtest
{
    [TestClass]
    public class CodedbTest
    {
        [TestMethod]
        public void CodeSaveTest()
        {
            Code code = new Code();
            code.Content = "wfwefwef\r\n";
            code.Version = "210";
            code.Desc = "hello";
            code.VersionList.Add(new CodeVersion() { Content = "xhes", Version = code.Version });
            Codedb codedb = new Codedb();


            codedb.SaveCode(code);

            CodeVersion version = new CodeVersion();
            version.Content = "sdfef";
            codedb.saveVersion(version);

           // code = codedb.getCodebyId(10);
        }

        [TestMethod]
        public void CodeSelectTest()
        {
            Codedb codedb = new Codedb();
         //   Code code = codedb.getCodebyId(10);
        }
    }
}
