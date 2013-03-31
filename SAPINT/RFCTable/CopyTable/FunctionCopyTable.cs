using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using System.Data;
namespace SAPINT.Function
{
    public delegate void delegateCopyFinished(FunctionCopyTable sender, DataTable result);
    public delegate void delegateImporeTableFinished(FunctionCopyTable sender);

    public class FunctionCopyTable
    {
        private IRfcTable DATA = null;
        private IRfcTable FIELDS = null;

        //private static RfcDestination targetDestination = null;
        //private static RfcDestination destination = null;

        private List<String> conditions = null;

        public event delegateCopyFinished eventCopied;

        public FunctionCopyTable(String soureSystem, String pSourceTable)
        {
            if (String.IsNullOrWhiteSpace(soureSystem))
            {
                throw new SAPException("源系统名为空！");
            }
            if (String.IsNullOrWhiteSpace(pSourceTable))
            {
                throw new SAPException("表名为空!!");
            }

            this.SourceSystemName = soureSystem.Trim();
            SourceTableName = pSourceTable.Trim().ToUpper();
        }
        public FunctionCopyTable(String soureSystem, String targetSystem, String pSourceTable, String pTargetTable)
        {

            this.isDelete = false;
            this.isModify = false;
            this.isUpdate = false;
            this.isInsert = false;
            this.SourceSystemName = soureSystem.Trim();
            this.TargetSystemName = targetSystem.Trim();
            this.SourceTableName = pSourceTable.Trim().ToUpper();
            this.TargetTableName = pTargetTable.Trim().ToUpper();

        }

        public FunctionCopyTable()
        {
            // TODO: Complete member initialization
        }

        public void WriteTable()
        {
            FunctionImportTable functionImportTable = new FunctionImportTable();
            functionImportTable.eventImportTableFinished += new delegateImporeTableDone(functionImportTable_eventImportTableFinished);
            functionImportTable.Delimiter = this.ImportDelimiter;
            functionImportTable.DATA = this.DATA;
            functionImportTable.FIELDS = this.FIELDS;
            functionImportTable.isDelete = this.isDelete;
            functionImportTable.isInsert = this.isInsert;
            functionImportTable.isModify = this.isModify;
            functionImportTable.isUpdate = this.isUpdate;
            functionImportTable.Excute(TargetSystemName, TargetTableName);

            //this.WriteTable(this.TargetSystemName, TargetTableName);
        }

        private void functionImportTable_eventImportTableFinished(FunctionImportTable sender)
        {
            NotifyListener(sender.Message);
            //throw new NotImplementedException();
        }



        public void ReadTable()
        {
            FunctionReadTable functionReadTable = new FunctionReadTable();
            functionReadTable.eventReadTableDone += new delegateReadTableDone(functionReadTable_eventReadTableDone);
            functionReadTable.RowCount = this.RowCount;
            functionReadTable.Delimiter = this.Delimiter;
            functionReadTable.conditions = this.conditions;
            functionReadTable.Excute(SourceSystemName, SourceTableName);

            this.DATA = functionReadTable.DATA;
            this.FIELDS = functionReadTable.FIELDS;
            //this.ReadTable(SourceSystemName, SourceTableName);
        }

        void functionReadTable_eventReadTableDone(FunctionReadTable sender, DataTable result)
        {
            if (eventCopied != null)
            {
                this.Message = sender.Message;
                eventCopied(this, result);
            }
            // throw new NotImplementedException();
        }

        private void NotifyListener(String Message)
        {
            if (eventCopied != null)
            {
                this.Message = Message;
                eventCopied(this, null);
                //  eventReadTableDone(this, result);
                //   eventReadTableDone(this, null);
            }
        }

        public void SetCondition(List<String> conditionList)
        {
            conditions = conditionList;
        }

        

        public bool Excute()
        {
            ReadTable();
            WriteTable();
            return true;
        }

        public DataTable Result
        {
            private set;
            get;
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
        public int RowCount
        {
            get;
            set;
        }
        public String SourceTableName
        {
            get;
            set;
        }
        public String TargetTableName
        {
            get;
            set;
        }

        public String SourceSystemName
        {
            get;
            set;
        }
        public String TargetSystemName
        {
            get;
            set;
        }

        public string Message { get; set; }
        public string ReadTableFunctionName { get; set; }
        public string ImportTableFunctionName { get; set; }

        public string Delimiter { get; set; }

        public string ImportDelimiter { get; set; }
    }
}
