namespace SAPINT.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class QueryField
    {
        #region Fields
        // Fields
        private string _ABAPType;
        private int _Decimals;
        private string _Description;
        private int _Length;
        private string _Name;
        #endregion Fields
        #region Constructors
        // Methods
        public QueryField()
        {
            this._Name = "";
            this._Description = "";
            this._ABAPType = "";
        }
        public QueryField(string Name, string ABAPType, int Length, int Decimals, string Description)
        {
            this._Name = "";
            this._Description = "";
            this._ABAPType = "";
            this.Name = Name;
            this.ABAPType = ABAPType;
            this.Length = Length;
            this.Decimals = Decimals;
            this.Description = Description;
        }
        #endregion Constructors
        #region Properties
        // Properties
        public string ABAPType
        {
            get
            {
                return this._ABAPType;
            }
            set
            {
                this._ABAPType = value.Trim().ToUpper();
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
        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this._Description = value.Trim();
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
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value.Trim().ToUpper();
            }
        }
        #endregion Properties
    }
}
