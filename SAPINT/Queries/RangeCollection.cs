namespace SAPINT.Queries
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class RangeCollection : CollectionBase
    {
        #region Indexers
        // Properties
        public virtual Range this[int Index]
        {
            get
            {
                return (Range)base.List[Index];
            }
            set
            {
                base.List[Index] = value;
            }
        }
        #endregion Indexers
        #region Methods
        // Methods
        public virtual void Add(Range NewParameter)
        {
            base.List.Add(NewParameter);
        }
        public virtual void Add(string Value)
        {
            base.List.Add(new Range(Sign.Include, RangeOption.Equals, Value, ""));
        }
        public virtual void Add(Sign Sign, RangeOption Option, string Value)
        {
            base.List.Add(new Range(Sign, Option, Value, ""));
        }
        public virtual void Add(Sign Sign, RangeOption Option, string LowValue, string HighValue)
        {
            base.List.Add(new Range(Sign, Option, LowValue, HighValue));
        }
        #endregion Methods
    }
}
