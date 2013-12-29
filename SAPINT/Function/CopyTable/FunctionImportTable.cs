using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using System.Data;

namespace SAPINT.Function.CopyTable
{
    // public delegate void delegateImportTableFinished(FunctionImportTable sender, DataTable result);
    public delegate void delegateImporeTableDone(FunctionImportTable sender);
    public class FunctionImportTable
    {
        //如果在两个系统直接直接抽取与插入，直接使用RFCTABLE传输数据
        public IRfcTable DATA { get; set; }
        public IRfcTable FIELDS { get; set; }

        //public string ImportTableFunctionName { get; set; }
        
        //  public event delegateImportTableFinished eventImportTableFinishded;
        public event delegateImporeTableDone eventImportTableFinished;
        // public string ptableName { get; set; }

        private List<String> _dataInput = null;
        private List<CopyTableField> _fieldsIn = null;

        public List<String> DataInput { set { this._dataInput = value; } get { return _dataInput; } }
        public string TableName { get; set; }
        public string FunctionName { get; set; }
        private RfcDestination _destination = null;
        private IRfcFunction _function = null;

        //操作类型
        public OperationType Operation { get; set; }

        public String SapClient
        {
            set
            {
                try
                {
                    this._destination = SAPDestination.GetDesByName(value);

                    this._function = this._destination.Repository.CreateFunction(this.FunctionName);
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
        }

        public FunctionImportTable()
        {
            this.Operation = OperationType.direct;
            this.FunctionName = "ZVI_RFC_IMPORT_TABLE";

        }
        public void setFields(List<CopyTableField> fields)
        {
            this._fieldsIn = new List<CopyTableField>();
            this._fieldsIn = fields;
        }
        public void Excute()
        {
            if (String.IsNullOrEmpty(this.TableName))
            {
                throw new SAPException("表名为空！！");
            }

            if (this._dataInput == null && DATA == null)
            {
                throw new SAPException("数量为0！！");
            }
            if (this._fieldsIn == null && FIELDS == null)
            {
                throw new SAPException("字段列表不能为空！！");
            }
            try
            {
                IRfcTable DATA2 = this._function.GetTable("DATA");
                IRfcTable FIELDS2 = this._function.GetTable("FIELDS");
                DATA2.Clear();
                FIELDS2.Clear();
                IRfcStructure line2;

                if (this.Operation == OperationType.direct)
                {
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
                }
                else if (this.Operation == OperationType.write)
                {
                    foreach (var item in this._dataInput)
                    {

                        line2 = DATA2.Metadata.LineType.CreateStructure();
                        line2.SetValue(0, item);
                        DATA2.Append(line2);
                    }
                    foreach (var item in this._fieldsIn)
                    {
                        line2 = FIELDS2.Metadata.LineType.CreateStructure();
                        line2.SetValue("FIELDNAME", item.FieldName);
                        line2.SetValue("OFFSET", item.Offset);
                        line2.SetValue("LENGTH", item.Length);
                        line2.SetValue("TYPE", item.Type);
                        line2.SetValue("FIELDTEXT", item.FieldText);
                        FIELDS2.Append(line2);
                    }
                }

                this._function.SetValue("QUERY_TABLE", this.TableName);
                this._function.SetValue("DATA", DATA2);
                this._function.SetValue("FIELDS", FIELDS2);
                this._function.SetValue("DELIMITER", this.Delimiter);


                this._function.SetValue("INSERTX", this.isInsert == true ? "X" : "");
                this._function.SetValue("UPDATEX", this.isUpdate == true ? "X" : "");
                this._function.SetValue("MODIFYX", this.isModify == true ? "X" : "");
                this._function.SetValue("DELETEX", this.isDelete == true ? "X" : "");

                NotifyListener(String.Format("SAP表：{0},总行数{1}写入开始！", this.TableName, DATA2.RowCount.ToString()));
                this._function.Invoke(_destination);
                NotifyListener(String.Format("SAP表：{0},写入结束！", this.TableName));
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
        public void loadDataFromFile(String filename)
        {
            //todo load datafrom file
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
