namespace SAPINT.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Range
    {
        #region Fields
        private Queries.RangeOption Option_2;
        private string p;
        private Queries.Sign Sign_2;
        private string Value;
        // Fields
        private string _HighValue;
        private string _LowValue;
        private RangeOption _Option;
        private Sign _Sign;
        #endregion Fields
        #region Constructors
        // Methods
        public Range()
        {
            this._LowValue = "";
            this._HighValue = "";
        }
        public Range(Sign Sign, RangeOption Option, string LowValue, string HighValue)
        {
            this._LowValue = "";
            this._HighValue = "";
            this.Sign = Sign;
            this.Option = Option;
            this.LowValue = LowValue;
            this.HighValue = HighValue;
        }
        #endregion Constructors
        #region Properties
        // Properties
        public string HighValue
        {
            get
            {
                return this._HighValue;
            }
            set
            {
                this._HighValue = value;
            }
        }
        public string LowValue
        {
            get
            {
                return this._LowValue;
            }
            set
            {
                this._LowValue = value;
            }
        }
        public RangeOption Option
        {
            get
            {
                return this._Option;
            }
            set
            {
                this._Option = value;
            }
        }
        public Sign Sign
        {
            get
            {
                return this._Sign;
            }
            set
            {
                this._Sign = value;
            }
        }
        #endregion Properties
    }
}
