using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using System.Data;
using SAPINT.Function;

namespace SAPINT.Function.CopyTable
{
    public delegate void delegateReadTableDone(FunctionReadTable sender, List<CopyTableField> fields, List<String> result);

    /// <summary>
    /// 封装SAP抽取表数据的接口
    /// </summary>
    public class FunctionReadTable
    {


        //如果在两个系统直接直接抽取与插入，直接使用RFCTABLE传输数据
        public IRfcTable RfcDATA { get; set; }
        public IRfcTable RfcFIELDS { get; set; }

        public string FunctionName { get; set; }

        public List<String> conditions { get; set; }
        public List<String> Result { get; set; }
        public string Message { get; private set; }


        public string TableName { get; set; }

        public string Delimiter { get; set; }

        private List<CopyTableField> _fieldsIn { get; set; }
        private List<CopyTableField> _fieldsOut { get; set; }
        private RfcDestination _destination = null;
        private IRfcFunction _function = null;

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
        //操作类型
        public OperationType Operation { get; set; }

        public event delegateReadTableDone eventReadTableDone;

        public int RowCount
        {
            get;
            set;
        }
        public FunctionReadTable()
        {
            this.Operation = OperationType.direct;
            FunctionName = "ZVI_RFC_READ_TABLE";
        }
        public void setFields(List<CopyTableField> fields)
        {
            this._fieldsIn = fields;
        }
        public List<CopyTableField> getFields()
        {
            return this._fieldsOut;
        }
        //public List<TableField> getFields()
        //{
        //    var list = new List<TableField>();

        //    for (int i = 0; i < FIELDS.RowCount; i++)
        //    {
        //        var field = new TableField();
        //        field.FieldText =  FIELDS[i].GetString("FIELDTEXT");
        //        field.FieldName = FIELDS[i].GetString("FIELDNAME");
        //        field.Length =  FIELDS[i].GetInt("LENGTH");
        //        field.Offset = FIELDS[i].GetInt("OFFSET");
        //        field.Type = FIELDS[i].GetString("TYPE");
        //    }

        //    return list;

        //}
        public void Excute()
        {
            try
            {
                if (String.IsNullOrEmpty(this.TableName))
                {
                    throw new SAPException("表名为空！！");
                }
                RfcDATA = null;
                RfcFIELDS = null;

                //string _funame = "Z_SAPINT_READ_TABLE";

                this._function.SetValue("QUERY_TABLE", this.TableName);
                this._function.SetValue("ROWCOUNT", this.RowCount);
                this._function.SetValue("DELIMITER", this.Delimiter);

                if (conditions != null)
                {
                    if (conditions.Count > 0)
                    {
                        IRfcTable rfcOptions = this._function.GetTable("OPTIONS");
                        foreach (var item in conditions)
                        {
                            rfcOptions.Append();
                            rfcOptions.SetValue("TEXT", item);
                        }
                    }

                }

                if (this._fieldsIn != null)
                {
                    if (_fieldsIn.Count > 0)
                    {
                        IRfcTable rfcfields = this._function.GetTable("FIELDS");
                        foreach (var item in _fieldsIn)
                        {
                            rfcfields.Append();
                            rfcfields.SetValue("FIELDNAME", item.FieldName);
                        }
                    }
                }

                this._function.Invoke(this._destination);

                RfcDATA = this._function.GetTable("DATA");
                RfcFIELDS = this._function.GetTable("FIELDS");

                //输出到界面或需要进一步的处理
                if (this.Operation != OperationType.direct)
                {
                    this.Result = new List<String>();
                    for (int i = 0; i < RfcDATA.RowCount; i++)
                    {
                        this.Result.Add(RfcDATA[i].GetString(0));
                    }

                    this._fieldsOut = new List<CopyTableField>();
                    for (int i = 0; i < RfcFIELDS.RowCount; i++)
                    {
                        var field = new CopyTableField();
                        field.FieldText = RfcFIELDS[i].GetString("FIELDTEXT");
                        field.FieldName = RfcFIELDS[i].GetString("FIELDNAME");
                        field.Length = RfcFIELDS[i].GetInt("LENGTH");
                        field.Offset = RfcFIELDS[i].GetInt("OFFSET");
                        field.Type = RfcFIELDS[i].GetString("TYPE");
                        _fieldsOut.Add(field);
                    }
                    //Result = SAPFunction.RfcTableToDataTable(DATA);


                }
                if (eventReadTableDone != null)
                {
                    this.Message = string.Format("表{0}，一共{1}行，读取完成！！", this.TableName, RfcDATA.RowCount.ToString());
                    eventReadTableDone(this, this._fieldsOut, this.Result);
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

        public void saveDataToFile(string filename)
        {
            //todo save data to file

        }




    }
}
