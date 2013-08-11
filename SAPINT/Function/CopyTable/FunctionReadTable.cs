using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using System.Data;
using SAPINT.Function;

namespace SAPINT.Table
{
    public delegate void delegateReadTableDone(FunctionReadTable sender, DataTable result);
    public class FunctionReadTable
    {

        public IRfcTable DATA { get; set; }
        public IRfcTable FIELDS { get; set; }
        private static RfcDestination destination = null;
        public List<String> conditions { get; set; }
        public DataTable Result { get; set; }
        public string Message { get; private set; }

        public event delegateReadTableDone eventReadTableDone;

        public int RowCount
        {
            get;
            set;
        }
        public void Excute(String psourceSystemName, String ptableName)
        {
            try
            {
                if (String.IsNullOrEmpty(ptableName))
                {
                    throw new SAPException("表名为空！！");
                }
                DATA = null;
                FIELDS = null;
                destination = SAPDestination.GetDesByName(psourceSystemName);
                //string _funame = "Z_SAPINT_READ_TABLE";
                IRfcFunction FunctionReadTable = destination.Repository.CreateFunction("ZVI_RFC_READ_TABLE");
                FunctionReadTable.SetValue("QUERY_TABLE", ptableName);
                FunctionReadTable.SetValue("ROWCOUNT", RowCount);
                FunctionReadTable.SetValue("DELIMITER", Delimiter);

                if (conditions != null)
                {
                    if (conditions.Count > 0)
                    {
                        IRfcTable rfcOptions = FunctionReadTable.GetTable("OPTIONS");
                        foreach (var item in conditions)
                        {
                            rfcOptions.Append();
                            rfcOptions.SetValue("TEXT", item);
                        }
                    }

                }

                FunctionReadTable.Invoke(destination);
                DATA = FunctionReadTable.GetTable("DATA");
                FIELDS = FunctionReadTable.GetTable("FIELDS");
                Result = SAPFunction.RfcTableToDataTable(DATA);

                if (eventReadTableDone != null)
                {
                    this.Message = string.Format("表{0}，一共{1}行，读取完成！！", ptableName, DATA.RowCount.ToString());
                    eventReadTableDone(this, Result);
                }

            }
            catch (RfcAbapException abapEx)
            {
                throw new SAPException(abapEx.Key + abapEx.Message);
            }
            catch (RfcBaseException rfcbase)
            {
                throw new SAPException(rfcbase.Message);
            }
            catch (Exception ex)
            {
                throw new SAPException(ex.Message);
            }
        }


        public string Delimiter { get; set; }
    }
}
