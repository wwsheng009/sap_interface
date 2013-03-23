namespace SAPINT.Utils
{
    using SAPINT;
    using System;
    using System.Data;
    using SAP.Middleware.Connector;
    public class BatchReturn
    {
        private string _Message = "";
        private string _MessageID = "";
        private string _MessageNumber = "";
        private string _MessageVariable1 = "";
        private string _MessageVariable2 = "";
        private string _MessageVariable3 = "";
        private string _MessageVariable4 = "";
        private string _Type = "";
        internal void FillMessageText(string sysName)
        {
            ReadTable table = new ReadTable(sysName);
            RfcDestination des = SAPDestination.GetDesByName(sysName);
            
            table.AddField("TEXT");
            table.AddCriteria("SPRSL = '" + Converts.languageIsotoSap(des.Language)+ "' ");
            table.AddCriteria("AND ARBGB = '" + this.MessageID + "' ");
            table.AddCriteria("AND MSGNR = '" + this.MessageNumber + "' ");
            table.TableName = "T100";
            table.RowCount = 10;
            table.Run();
            DataTable result = table.Result;
            if (result.Rows.Count == 0)
            {
                //this.Message = "Message could not be found";// Messages.Messagecouldnotbefound;
                this.Message = Messages.Messagecouldnotbefound;
            }
            else
            {
                this.Message = result.Rows[0]["TEXT"].ToString().Trim();
                int length = 0;
                length = this.Message.IndexOf("&");
                if (length >= 0)
                {
                    this.Message = this.Message.Substring(0, length).Trim() + " " + this.MessageVariable1 + " " + this.Message.Substring(length + 1).Trim();
                }
                length = this.Message.IndexOf("&");
                if (length >= 0)
                {
                    this.Message = this.Message.Substring(0, length).Trim() + " " + this.MessageVariable2 + " " + this.Message.Substring(length + 1).Trim();
                }
                length = this.Message.IndexOf("&");
                if (length >= 0)
                {
                    this.Message = this.Message.Substring(0, length).Trim() + " " + this.MessageVariable3 + " " + this.Message.Substring(length + 1).Trim();
                }
                length = this.Message.IndexOf("&");
                if (length >= 0)
                {
                    this.Message = this.Message.Substring(0, length).Trim() + " " + this.MessageVariable4 + " " + this.Message.Substring(length + 1).Trim();
                }
                this.Message = this.Message.Trim();
            }
        }
        public string Message
        {
            get
            {
                return this._Message;
            }
            set
            {
                this._Message = value;
            }
        }
        public string MessageID
        {
            get
            {
                return this._MessageID;
            }
            set
            {
                this._MessageID = value;
            }
        }
        public string MessageNumber
        {
            get
            {
                return this._MessageNumber;
            }
            set
            {
                this._MessageNumber = value;
            }
        }
        public string MessageVariable1
        {
            get
            {
                return this._MessageVariable1;
            }
            set
            {
                this._MessageVariable1 = value;
            }
        }
        public string MessageVariable2
        {
            get
            {
                return this._MessageVariable2;
            }
            set
            {
                this._MessageVariable2 = value;
            }
        }
        public string MessageVariable3
        {
            get
            {
                return this._MessageVariable3;
            }
            set
            {
                this._MessageVariable3 = value;
            }
        }
        public string MessageVariable4
        {
            get
            {
                return this._MessageVariable4;
            }
            set
            {
                this._MessageVariable4 = value;
            }
        }
        public string Type
        {
            get
            {
                return this._Type;
            }
            set
            {
                this._Type = value;
            }
        }
    }
}
