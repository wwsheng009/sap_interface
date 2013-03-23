namespace SAPINT.Utils
{
    using SAPINT;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using SAP.Middleware.Connector;
    public class ABAPCode : Component
    {
        private ArrayList _code;
        private RfcDestination _des;
        private string _LastError;
        private ArrayList _result;
        public ABAPCode()
        {
            this._code = new ArrayList();
            this._result = new ArrayList();
            this._LastError = "";
        }
        public ABAPCode(string sysName)
        {
            this._des = SAPDestination.GetDesByName(sysName);
            this._code = new ArrayList();
            this._result = new ArrayList();
            this._LastError = "";
            if (_des == null)
            {
                throw new SAPException(Messages.Connectionisnotvalid);

            }
        }
        public void AddCodeLine(string CodeLine)
        {
            this._code.Add(CodeLine);
        }
        public bool Execute()
        {
            IRfcFunction function;
            try
            {
                if (this._des == null)
                {
                    throw new SAPException(Messages.Connectionisnotvalid);
                }

                this._LastError = "";
                function = _des.Repository.CreateFunction("ZRFC_ABAP_INSTALL_AND_RUN");
                IRfcTable table = function.GetTable("PROGRAM");

                if (this._code.Count <= 1)
                {
                    throw new Exception(Messages.Thegivencodeisnotvalid);

                }
                foreach (string str in this._code)
                {
                    table.Append();
                    IRfcStructure row = table.CurrentRow;
                    row.SetValue("LINE", str);
                }

                function.Invoke(_des);
            }
            catch (RfcAbapException e)
            {

                throw new SAPException(e.Key + e.Message);
            }
            this._LastError = function.GetValue("ERRORMESSAGE").ToString().Trim();
            if (this._LastError != "")
            {
                return false;
            }
            this._result.Clear();
            IRfcTable table2 = function.GetTable("WRITES");
            for (int i = 0; i < table2.RowCount; i++)
            {
                this._result.Add(table2[i].GetValue("ZEILE").ToString().Trim());
            }
            return true;
        }
        public string GetResultLine(int Index)
        {
            return (string)this._result[Index];
        }
        public void ResetCode()
        {
            this._code.Clear();
        }
        public RfcDestination Destination
        {
            get
            {
                return this._des;
            }
            set
            {
                this._des = value;
            }
        }
        public string LastABAPSyntaxError
        {
            get
            {
                return this._LastError;
            }
        }
        public int ResultLineCount
        {
            get
            {
                return this._result.Count;
            }
        }
    }
}
