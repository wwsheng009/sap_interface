using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using System.Data;

namespace SAPINT.Table
{
   // public delegate void delegateImportTableFinished(FunctionImportTable sender, DataTable result);
    public delegate void delegateImporeTableDone(FunctionImportTable sender);
    public class FunctionImportTable
    {

        public IRfcTable DATA { get; set; }
        public IRfcTable FIELDS { get; set; }
        public string ImportTableFunctionName { get; set; }
        private static RfcDestination targetDestination = null;
      //  public event delegateImportTableFinished eventImportTableFinished;
        public event delegateImporeTableDone eventImportTableFinished;
       // public string ptableName { get; set; }

        public void Excute(String targetSystem, String ptableName)
        {
            if (String.IsNullOrEmpty(ptableName))
            {
                throw new SAPException("表名为空！！");
            }

            if (DATA.RowCount == 0 || DATA == null)
            {
                throw new SAPException("数量为0！！");
            }
            if (FIELDS.Count == 0 || FIELDS == null)
            {
                throw new SAPException("字段列表不能为空！！");
            }
            try
            {
                targetDestination = SAPDestination.GetDesByName(targetSystem);
                
                //string _funame = "Z_SAPINT_READ_TABLE";
                IRfcFunction FunctionImportTable = null;
                
                if (!String.IsNullOrWhiteSpace(ImportTableFunctionName))
                {
                    FunctionImportTable = targetDestination.Repository.CreateFunction(ImportTableFunctionName);
                }
                else
                {
                    FunctionImportTable = targetDestination.Repository.CreateFunction("ZVI_RFC_IMPORT_TABLE");
                }

                IRfcTable DATA2 = FunctionImportTable.GetTable("DATA");
                IRfcTable FIELDS2 = FunctionImportTable.GetTable("FIELDS");
                DATA2.Clear();
                FIELDS2.Clear();

                IRfcStructure line2;
                for (int i = 0; i < DATA.RowCount; i++)
                {
                    DATA.CurrentIndex = i;

                    line2 = DATA2.Metadata.LineType.CreateStructure();
                    line2.SetValue("FELD", DATA.GetValue("FELD"));
                    DATA2.Append(line2);
                }


                for (int i = 0; i < FIELDS.RowCount; i++)
                {
                    FIELDS.CurrentIndex = i;

                    line2 = FIELDS2.Metadata.LineType.CreateStructure();
                    line2.SetValue("FIELDNAME", FIELDS.GetValue("FIELDNAME"));
                    line2.SetValue("OFFSET", FIELDS.GetValue("OFFSET"));
                    line2.SetValue("LENGTH", FIELDS.GetValue("LENGTH"));
                    line2.SetValue("TYPE", FIELDS.GetValue("TYPE"));
                    line2.SetValue("FIELDTEXT", FIELDS.GetValue("FIELDTEXT"));
                    FIELDS2.Append(line2);
                }
                FunctionImportTable.SetValue("QUERY_TABLE", ptableName);
                FunctionImportTable.SetValue("DATA", DATA2);
                FunctionImportTable.SetValue("FIELDS", FIELDS2);
                FunctionImportTable.SetValue("DELIMITER", this.Delimiter);

                if (isInsert)
                {
                    FunctionImportTable.SetValue("INSERTX", 'X');
                }
                if (isUpdate)
                {
                    FunctionImportTable.SetValue("UPDATEX", 'X');
                }
                if (isModify)
                {
                    FunctionImportTable.SetValue("MODIFYX", 'X');
                }
                if (isDelete)
                {
                    FunctionImportTable.SetValue("DELETEX", 'X');
                }
                NotifyListener(String.Format("SAP表：{0},总行数{1}写入开始！", ptableName, DATA2.RowCount.ToString()));
                FunctionImportTable.Invoke(targetDestination);
                NotifyListener(String.Format("SAP表：{0},写入结束！", ptableName));
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

        private void NotifyListener(String Message)
        {
            if (eventImportTableFinished != null)
            {
                this.Message = Message;
                eventImportTableFinished(this);
            }
        }


        public bool isInsert
        {
            get;
            set;
        }

        public bool isUpdate
        {
            get;
            set;
        }
        public bool isModify
        {
            get;
            set;
        }
        public bool isDelete
        {
            get;
            set;
        }
        public string Message { get; private set; }

        public string Delimiter { get; set; }
    }
}
