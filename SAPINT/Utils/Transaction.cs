namespace SAPINT.Utils
{
    using SAPINT;
    using System;
    using System.ComponentModel;
    using SAP.Middleware.Connector;
    public class Transaction : Component
    {
        private BatchStepCollection _BatchSteps;
        private RfcDestination _des;
        private string _CustomFunctionName;
        private TransactionDialogMode _ExceutionMode;
        private BatchReturnCollection _Returns;
        private string _TCode;
        private TransactionType _Type;
        private TransactionUpdateMode _UpdateMode;
        private string _sysName;
        public Transaction()
        {
            this._BatchSteps = new BatchStepCollection();
            this._TCode = "";
            this._Type = TransactionType.Multiple;
            this._Returns = new BatchReturnCollection();
            this._CustomFunctionName = "";
        }
        public Transaction(string sysName)
        {
            this._BatchSteps = new BatchStepCollection();
            this._TCode = "";
            this._Type = TransactionType.Multiple;
            this._Returns = new BatchReturnCollection();
            this._CustomFunctionName = "";
            this._des = SAPDestination.GetDesByName(sysName);
            this._sysName = sysName.ToUpper().Trim();
        }
        public void AddStepSetCursor(string FieldName)
        {
            this._BatchSteps.Add(new BatchStep("", "0", false, "BDC_CURSOR", FieldName));
        }
        public void AddStepSetField(string FieldName, string FieldValue)
        {
            this._BatchSteps.Add(new BatchStep("", "0", false, FieldName, FieldValue));
        }
        public void AddStepSetNewDynpro(string Program, string DynproNumber)
        {
            this._BatchSteps.Add(new BatchStep(Program, DynproNumber, true, "", ""));
        }
        public void AddStepSetOKCode(string OKCode)
        {
            this._BatchSteps.Add(new BatchStep("", "0", false, "BDC_OKCODE", OKCode));
        }
        public void AddStepSwitchToShowAll()
        {
            this.AddStepSetOKCode("/BDA");
        }
        public void AddStepSwitchToShowOnlyErrors()
        {
            this.AddStepSetOKCode("/BDE");
        }
        public void Execute()
        {
            this.InternalExecute();
        }
        private void InternalExecute()
        {
            if (this._des == null)
            {
                throw new SAPException("Connection Is Not Valid");
            }
            //if (!this._des.Ping())
            //{
            //    throw new SAPException(Messages.ConnectionIsNotValid);
            //}
            this.Returns.Clear();

                this.ExecutionMode = TransactionDialogMode.Background;
            if (this._Type == TransactionType.Single)
            {
                this.InternalExecuteRFC_CALL_TRANSACTION_USING();
            }
            else
            {
                this.InternalExecuteRFC_CALL_TRANSACTION_USING();
            }
        }
        private void InternalExecuteRFC_CALL_TRANSACTION()
        {
            IRfcFunction function;
            if (this._CustomFunctionName.Equals(""))
            {
                function = _des.Repository.CreateFunction("RFC_CALL_TRANSACTION");
            }
            else
            {

                function = this._des.Repository.CreateFunction(this._CustomFunctionName);
            }

            function["TRANCODE"].SetValue(this._TCode);
            if (this._UpdateMode == TransactionUpdateMode.Asynchronous)
            {
                function["UPDMODE"].SetValue("A");
            }
            else if (this._UpdateMode == TransactionUpdateMode.Synchronous)
            {
                function["UPDMODE"].SetValue("S");
            }
            else
            {
                function["UPDMODE"].SetValue("L");
            }
            if (this.ExecutionMode == TransactionDialogMode.ShowAll)
            {
                this.BatchSteps.Insert(0, new BatchStep("", "0", false, "BDC_OKCODE", "/BDA"));
            }
            else if (this.ExecutionMode == TransactionDialogMode.ShowOnlyErrors)
            {
                this.BatchSteps.Insert(0, new BatchStep("", "0", false, "BDC_OKCODE", "/BDE"));
            }
            IRfcTable table = function.GetTable("BDCTABLE");
            for (int i = 0; i < this.BatchSteps.Count; i++)
            {
                table.Append();
                IRfcStructure structure = table.CurrentRow;
                structure["PROGRAM"].SetValue(this.BatchSteps[i].ProgramName);
                structure["DYNPRO"].SetValue(this.BatchSteps[i].DynproNumber);
                if (this.BatchSteps[i].BeginNewDynpro)
                {
                    structure["DYNBEGIN"].SetValue("X");
                }
                structure["FNAM"].SetValue(this.BatchSteps[i].FieldName);
                structure["FVAL"].SetValue(this.BatchSteps[i].FieldValue);
            }
            function.Invoke(_des);
            IRfcStructure structure2 = function.GetStructure("MESSG");
            if (structure2["MSGTY"].GetValue().ToString().Trim() != "")
            {
                BatchReturn newBatchReturn = new BatchReturn {
                    Type = structure2["MSGTY"].GetValue().ToString(),
                    Message = structure2["MSGTX"].GetValue().ToString(),
                    MessageID = structure2["MSGID"].GetValue().ToString(),
                    MessageNumber = structure2["MSGNO"].GetValue().ToString()
                };
                this.Returns.Add(newBatchReturn);
            }
        }
        private void InternalExecuteRFC_CALL_TRANSACTION_USING()
        {
            IRfcFunction function;
            if (this._CustomFunctionName.Equals(""))
            {
               // function = RFCFunctionFactory.GenerateFunctionObjectForRFC_CALL_TRANSACTION_USING(this._con.IsUnicode);
                function = _des.Repository.CreateFunction("RFC_CALL_TRANSACTION_USING");
            }
            else
            {
                //function = this._con.CreateFunction(this._CustomFunctionName);
                function = this._des.Repository.CreateFunction(this._CustomFunctionName);
            }
           // function.Connection = this._con;
            function["TCODE"].SetValue(this._TCode);
            if (this.ExecutionMode == TransactionDialogMode.ShowAll)
            {
                function["MODE"].SetValue("A");
            }
            else if (this.ExecutionMode == TransactionDialogMode.Background)
            {
                function["MODE"].SetValue("N");
            }
            else
            {
                function["MODE"].SetValue("E");
            }
            IRfcTable table = function.GetTable("BT_DATA");
            for (int i = 0; i < this.BatchSteps.Count; i++)
            {
                table.Append();
                IRfcStructure structure = table.CurrentRow;
                structure["PROGRAM"].SetValue(this.BatchSteps[i].ProgramName);
                structure["DYNPRO"].SetValue(this.BatchSteps[i].DynproNumber);
                if (this.BatchSteps[i].BeginNewDynpro)
                {
                    structure["DYNBEGIN"].SetValue("X");
                }
                structure["FNAM"].SetValue(this.BatchSteps[i].FieldName);
                structure["FVAL"].SetValue(this.BatchSteps[i].FieldValue);
            }
            function.Invoke(_des);
            for (int j = 0; j < function.GetTable("L_ERRORS").RowCount; j++)
            {
                IRfcStructure structure2 = function.GetTable("L_ERRORS")[j];
                BatchReturn newBatchReturn = new BatchReturn {
                    Message = "",
                    Type = structure2["MSGTYP"].GetValue().ToString(),
                    MessageID = structure2["MSGID"].GetValue().ToString(),
                    MessageNumber = structure2["MSGNR"].GetValue().ToString(),
                    MessageVariable1 = structure2["MSGV1"].GetValue().ToString(),
                    MessageVariable2 = structure2["MSGV2"].GetValue().ToString(),
                    MessageVariable3 = structure2["MSGV3"].GetValue().ToString(),
                    MessageVariable4 = structure2["MSGV4"].GetValue().ToString()
                };
                newBatchReturn.FillMessageText(_sysName);
                this.Returns.Add(newBatchReturn);
            }
        }
        public void SetCustomFunctionName(string CustomFunctionName)
        {
            this._CustomFunctionName = CustomFunctionName;
        }
        public BatchStepCollection BatchSteps
        {
            get
            {
                return this._BatchSteps;
            }
            set
            {
                this._BatchSteps = value;
            }
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
        public TransactionDialogMode ExecutionMode
        {
            get
            {
                return this._ExceutionMode;
            }
            set
            {
                this._ExceutionMode = value;
            }
        }
        public BatchReturnCollection Returns
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
        public string TCode
        {
            get
            {
                return this._TCode;
            }
            set
            {
                this._TCode = value;
            }
        }
        public TransactionType Type
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
        public TransactionUpdateMode UpdateMode
        {
            get
            {
                return this._UpdateMode;
            }
            set
            {
                this._UpdateMode = value;
            }
        }
    }
}
