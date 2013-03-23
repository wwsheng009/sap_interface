namespace SAPINT.Utils
{
    using System;
    public class ReadTableField
    {
        private string _ABAPType;
        private int _Decimals;
        private string _FieldName;
        private string _FieldText;
        private string _CheckTable;
        private int _Length;
        private bool _Active;
        internal string LastKeyValue;
        public ReadTableField()
        {
            this._FieldName = "";
            this._ABAPType = "";
            this._FieldText = "";
            this.LastKeyValue = "";
        }
        public ReadTableField(string FieldName, int Length, string ABAPType, string FieldText, int Decimals)
        {
            this._FieldName = "";
            this._ABAPType = "";
            this._FieldText = "";
            this.LastKeyValue = "";
            this._FieldName = FieldName;
            this._Length = Length;
            this._ABAPType = ABAPType;
            this._FieldText = FieldText;
            this._Decimals = Decimals;
        }
        public ReadTableField(string FieldName, int Length, string ABAPType, string FieldText, int Decimals,string CheckTable)
        {
            this._FieldName = "";
            this._ABAPType = "";
            this._FieldText = "";
            this.LastKeyValue = "";
            this._CheckTable = "";
            this._FieldName = FieldName;
            this._Length = Length;
            this._ABAPType = ABAPType;
            this._FieldText = FieldText;
            this._Decimals = Decimals;
            this._CheckTable = CheckTable;
        }
        
        public string ABAPType
        {
            get
            {
                return this._ABAPType;
            }
            set
            {
                this._ABAPType = value.ToUpper().Trim();
            }
        }
        public int Decimals
        {
            get
            {
                return this._Decimals;
            }
            set
            {
                this._Decimals = value;
            }
        }
        public string FieldName
        {
            get
            {
                return this._FieldName;
            }
            set
            {
                this._FieldName = value.ToUpper().Trim();
            }
        }
        public string FieldText
        {
            get
            {
                return this._FieldText;
            }
            set
            {
                this._FieldText = value;
            }
        }
        public int Length
        {
            get
            {
                return this._Length;
            }
            set
            {
                this._Length = value;
            }
        }
        public string CheckTable
        {
            get
            {
                return this._CheckTable;
            }
            set
            {
                this._CheckTable = value;
            }
        }
        public bool Active
        {
            get
            {
                return this._Active;
            }
            set
            {
                this._Active = value;
            }
        }
    }
}
