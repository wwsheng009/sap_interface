namespace SAPINT.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class QuerySelectionParameter
    {
        #region Fields
        // Fields
        private string _ABAPType;
        private string _DescriptionText;
        private string _FieldName;
        private Kind _Kind;
        private int _Length;
        private string _Name;
        private bool _NoDisplay;
        private bool _Obligatory;
        private RangeCollection _Ranges;
        #endregion Fields
        #region Constructors
        // Methods
        public QuerySelectionParameter()
        {
            this._Name = "";
            this._FieldName = "";
            this._DescriptionText = "";
            this._ABAPType = "C";
            this._Ranges = new RangeCollection();
        }
        public QuerySelectionParameter(string Name, string FieldName, string DescriptionText, int Length, bool Obligatory, bool NoDisplay, Kind Kind)
        {
            this._Name = "";
            this._FieldName = "";
            this._DescriptionText = "";
            this._ABAPType = "C";
            this._Ranges = new RangeCollection();
            this.Name = Name;
            this.FieldName = FieldName;
            this.DescriptionText = DescriptionText;
            this.Length = Length;
            this.Obligatory = Obligatory;
            this.NoDisplay = NoDisplay;
            this.Kind = Kind;
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
        public string DescriptionText
        {
            get
            {
                return this._DescriptionText;
            }
            set
            {
                this._DescriptionText = value;
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
                this._FieldName = value.Trim().ToUpper();
            }
        }
        public Kind Kind
        {
            get
            {
                return this._Kind;
            }
            set
            {
                this._Kind = value;
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
        public bool NoDisplay
        {
            get
            {
                return this._NoDisplay;
            }
            set
            {
                this._NoDisplay = value;
            }
        }
        public bool Obligatory
        {
            get
            {
                return this._Obligatory;
            }
            set
            {
                this._Obligatory = value;
            }
        }
        public RangeCollection Ranges
        {
            get
            {
                return this._Ranges;
            }
            set
            {
                this._Ranges = value;
            }
        }
        #endregion Properties
        #region Methods
        public virtual void AddRange(string Value)
        {
            this._Ranges.Add(Sign.Include, RangeOption.Equals, Value, "");
        }
        public virtual void AddRange(Sign Sign, RangeOption Option, string Value)
        {
            this._Ranges.Add(Sign, Option, Value, "");
        }
        public virtual void AddRange(Sign Sign, RangeOption Option, string LowValue, string HighValue)
        {
            this._Ranges.Add(Sign, Option, LowValue, HighValue);
        }
        #endregion Methods
    }
}