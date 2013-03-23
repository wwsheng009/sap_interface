namespace SAPINT.Utils
{
    using System;
    public class BatchStep
    {
        private bool _DYNBEGIN;
        private string _DYNPRO;
        private string _FNAM;
        private string _FVAL;
        private string _PROGRAM;
        public BatchStep()
        {
            this._PROGRAM = "";
            this._DYNPRO = "";
            this._FNAM = "";
            this._FVAL = "";
        }
        public BatchStep(string ProgramName, string DynproNumber, bool BeginNewDynpro, string FieldName, string FieldValue)
        {
            this._PROGRAM = "";
            this._DYNPRO = "";
            this._FNAM = "";
            this._FVAL = "";
            this.ProgramName = ProgramName;
            this.DynproNumber = DynproNumber;
            this.BeginNewDynpro = BeginNewDynpro;
            this.FieldName = FieldName;
            this.FieldValue = FieldValue;
        }
        public bool BeginNewDynpro
        {
            get
            {
                return this._DYNBEGIN;
            }
            set
            {
                this._DYNBEGIN = value;
            }
        }
        public string DynproNumber
        {
            get
            {
                return this._DYNPRO;
            }
            set
            {
                this._DYNPRO = value.ToUpper().Trim().PadLeft(4, "0".ToCharArray()[0]);
            }
        }
        public string FieldName
        {
            get
            {
                return this._FNAM;
            }
            set
            {
                this._FNAM = value.ToUpper().Trim();
            }
        }
        public string FieldValue
        {
            get
            {
                return this._FVAL;
            }
            set
            {
                this._FVAL = value.Trim();
            }
        }
        public string ProgramName
        {
            get
            {
                return this._PROGRAM;
            }
            set
            {
                this._PROGRAM = value.ToUpper().Trim();
            }
        }
    }
}
