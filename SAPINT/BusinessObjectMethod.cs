using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
namespace SAPINT
{
   public class BusinessObjectMethod
    {
        private string _name;
        private string _MethodName;
        private string _ObjectName;
        private BapiReturnCollection _Returns;
        private RfcDestination des;
        public BusinessObjectMethod(string sysName)
        {
            this._ObjectName = "";
            this._MethodName = "";
            this._Returns = new BapiReturnCollection();
            this.des = SAPDestination.GetDesByName(sysName);
        }
        public void CommitWork(bool Wait)
        {
            IRfcFunction function = des.Repository.CreateFunction("BAPI_TRANSACTION_COMMIT");
           // function.Exports.Add("WAIT", RFCTYPE.CHAR, base.Connection.IsUnicode ? 2 : 1);
            if (Wait)
            {
                function["WAIT"].SetValue("X");
            }
            function.Invoke(des);
        }
        //public override void Execute()
        //{
        //    ();
        //    this._Returns.Clear();
        //    for (int i = 0; i < base.Tables.Count; i++)
        //    {
        //        if (base.Tables[i].Name.Trim().Equals("RETURN"))
        //        {
        //            RFCTable table = base.Tables[i];
        //            for (int k = 0; k < table.Rows.Count; k++)
        //            {
        //                BapiReturn newBapiReturn = new BapiReturn
        //                {
        //                    Message = table[k, "MESSAGE"].ToString(),
        //                    Type = table[k, "TYPE"].ToString()
        //                };
        //                try
        //                {
        //                    newBapiReturn.Code = table[k, "CODE"].ToString();
        //                }
        //                catch
        //                {
        //                }
        //                try
        //                {
        //                    newBapiReturn.Code = table[k, "NUMBER"].ToString();
        //                }
        //                catch
        //                {
        //                }
        //                newBapiReturn.LogMessageNumber = table[k, "LOG_NO"].ToString();
        //                newBapiReturn.LogMessageNumber = table[k, "LOG_MSG_NO"].ToString();
        //                newBapiReturn.MessageVariable1 = table[k, "MESSAGE_V1"].ToString();
        //                newBapiReturn.MessageVariable2 = table[k, "MESSAGE_V2"].ToString();
        //                newBapiReturn.MessageVariable3 = table[k, "MESSAGE_V3"].ToString();
        //                newBapiReturn.MessageVariable4 = table[k, "MESSAGE_V4"].ToString();
        //                this._Returns.Add(newBapiReturn);
        //            }
        //        }
        //    }
        //    for (int j = 0; j < base.Imports.Count; j++)
        //    {
        //        if (base.Imports[j].Name.Trim().Equals("RETURN") && base.Imports[j].IsStructure())
        //        {
        //            RFCStructure structure = base.Imports[j].ToStructure();
        //            if (!structure["TYPE"].ToString().Trim().Equals(""))
        //            {
        //                BapiReturn return3 = new BapiReturn
        //                {
        //                    Message = structure["MESSAGE"].ToString(),
        //                    Type = structure["TYPE"].ToString()
        //                };
        //                try
        //                {
        //                    return3.Code = structure["CODE"].ToString();
        //                }
        //                catch
        //                {
        //                }
        //                try
        //                {
        //                    return3.Code = structure["NUMBER"].ToString();
        //                }
        //                catch
        //                {
        //                }
        //                return3.LogMessageNumber = structure["LOG_NO"].ToString();
        //                return3.LogMessageNumber = structure["LOG_MSG_NO"].ToString();
        //                return3.MessageVariable1 = structure["MESSAGE_V1"].ToString();
        //                return3.MessageVariable2 = structure["MESSAGE_V2"].ToString();
        //                return3.MessageVariable3 = structure["MESSAGE_V3"].ToString();
        //                return3.MessageVariable4 = structure["MESSAGE_V4"].ToString();
        //                this._Returns.Add(return3);
        //            }
        //        }
        //    }
        //}
        public void RollbackWork()
        {
            IRfcFunction function = des.Repository.CreateFunction("BAPI_TRANSACTION_ROLLBACK");
            function.Invoke(des);
            //new RFCFunction(base.Connection, "BAPI_TRANSACTION_ROLLBACK").Execute();
        }
        public string MethodName
        {
            get
            {
                return this._MethodName;
            }
            set
            {
                this._MethodName = value.Trim().ToUpper();
            }
        }
        public string ObjectName
        {
            get
            {
                return this._ObjectName;
            }
            set
            {
                this._ObjectName = value.Trim().ToUpper();
            }
        }
        public BapiReturnCollection Returns
        {
            get
            {
                return this._Returns;
            }
            set
            {
                this._Returns = value;
            }
        }
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value.ToUpper().Trim();
            }
        }
        public RfcDestination destination
        {
            get
            {
                return this.des;
            }
            set
            {
                this.des = value;
            }
        }
        
    }
}
