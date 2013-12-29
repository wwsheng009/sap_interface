using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using System.Data;
namespace SAPINT.Function.CopyTable
{
    public delegate void DelegateCopyFinished(FunctionCopyTable sender, List<CopyTableField> fields, List<string> result);
    public delegate void DelegateImporeTableFinished(FunctionCopyTable sender);

    public class FunctionCopyTable
    {
        private IRfcTable DATA = null;//用于传输导出导入的数据
        private IRfcTable FIELDS = null;//字段列表

        private FunctionImportTable _importTable = null;
        private FunctionReadTable _readTable = null;

        //private static RfcDestination targetDestination = null;
        //private static RfcDestination destination = null;

        public List<String> Conditions { get; set; }

        public List<String> ExchangeData { get; set; }
        public List<CopyTableField> Fields { get; set; }

        public event DelegateCopyFinished EventCopied;


        public OperationType readOperation = OperationType.read;
        public OperationType writeOperation = OperationType.write;

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
            this.SourceTableName = pSourceTable.Trim().ToUpper();
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

        /// <summary>
        /// 往SAP系统写入数据
        /// </summary>
        public void WriteTable()
        {
            _importTable = new FunctionImportTable();
            _importTable.eventImportTableFinished += new delegateImporeTableDone(functionImportTable_eventImportTableFinished);
            _importTable.Delimiter = this.ImportDelimiter;

            _importTable.isDelete = this.isDelete;
            _importTable.isInsert = this.isInsert;
            _importTable.isModify = this.isModify;
            _importTable.isUpdate = this.isUpdate;
            _importTable.SapClient = this.TargetSystemName;
            _importTable.TableName = this.TargetTableName;

            _importTable.setFields(this.Fields);

            if (this.writeOperation == OperationType.direct)
            {
                _importTable.DATA = this.DATA;
                _importTable.FIELDS = this.FIELDS;
                _importTable.Operation = OperationType.direct;
            }
            else
            {
                _importTable.DataInput = this.ExchangeData;
                _importTable.Operation = OperationType.write;
            }


            _importTable.Excute();

            //this.WriteTable(this.TargetSystemName, TargetTableName);
        }

        private void functionImportTable_eventImportTableFinished(FunctionImportTable sender)
        {
            NotifyListener(sender.Message);
            //throw new NotImplementedException();
        }

        public void ReadTable()
        {
            _readTable = new FunctionReadTable();
            _readTable.eventReadTableDone += new delegateReadTableDone(functionReadTable_eventReadTableDone);
            _readTable.RowCount = this.RowCount;
            _readTable.Delimiter = this.Delimiter;
            _readTable.conditions = this.Conditions;
            _readTable.SapClient = this.SourceSystemName;
            _readTable.TableName = this.SourceTableName;

            _readTable.setFields(this.Fields);

            if (this.readOperation == OperationType.direct)
            {
                _readTable.Operation = OperationType.direct;
                _readTable.Excute();

                this.DATA = _readTable.RfcDATA;
                this.FIELDS = _readTable.RfcFIELDS;
            }
            else
            {

                //this.Fields = _readTable.getFields();
                _readTable.Operation = OperationType.read;//读取到界面
                _readTable.Excute();
                this.ExchangeData = _readTable.Result;
                this.Fields = _readTable.getFields();

            }


            //this.ReadTable(SourceSystemName, SourceTableName);
        }

        void functionReadTable_eventReadTableDone(FunctionReadTable sender, List<CopyTableField> fields, List<String> result)
        {
            if (EventCopied != null)
            {
                this.Message = sender.Message;
                EventCopied(this, fields, result);
            }
            // throw new NotImplementedException();
        }

        private void NotifyListener(String Message)
        {
            if (EventCopied != null)
            {
                this.Message = Message;
                EventCopied(this, null, null);
                //  eventReadTableDone(this, result);
                //   eventReadTableDone(this, null);
            }
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
