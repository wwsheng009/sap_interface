using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAPINT.Screen
{
    public class CSapScreen
    {

        public static DataTable Fields = null;

        public static DataTable getScreenList(String system, string prog)
        {
            try
            {
                SAPINT.Utils.ReadTable screenlist = new Utils.ReadTable(system);
                screenlist.TableName = "D020S";
                screenlist.AddField("PROG");
                screenlist.AddField("DNUM");
                // screenlist.AddField("DTXT");
                screenlist.AddCriteria(string.Format("PROG = '{0}'", prog));
                // screenlist.AddCriteria(string.Format("AND LANG = {0}", 1));
                screenlist.Run();

                return screenlist.Result;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public static void GetFieldList(String system, string prog, string dynum)
        {
            try
            {
                RfcDestination destination = SAPDestination.GetDesByName(system);
                IRfcFunction function = destination.Repository.CreateFunction("ZVI_RFC_READ_SCREEN");
                function.SetValue("I_PROG", prog);
                function.SetValue("I_DYNNR", dynum);
                function.Invoke(destination);

                IRfcTable fields = function.GetTable("ET_FELD");
                IRfcStructure rs37a = function.GetStructure("E_HEADER");

                Fields = CScreenField.getScreenFieldAsDt(fields);
                UsedLine = rs37a.GetInt("BZMX");
                TotalLine = rs37a.GetInt("NOLI");
                TotalCol = rs37a.GetInt("NOCO");
                UsedCol = rs37a.GetInt("BZBR");

                ScreenType = rs37a.GetString("TYPE");
                Title = function.GetString("E_TITLE");

            }
            catch (RfcAbapException rfce)
            {
                throw new SAPException(rfce.Key + rfce.Message);
            }
            catch (Exception e)
            {
                throw new SAPException(e.Message);
            }

        }

        public static int TotalLine { get; set; }

        public static int UsedLine { get; set; }

        public static int UsedCol { get; set; }

        public static int TotalCol { get; set; }

        public static string ScreenType { get; set; }

        public static string Title { get; set; }
    }//class


}
