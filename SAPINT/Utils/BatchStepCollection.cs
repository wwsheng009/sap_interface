namespace SAPINT.Utils
{
    using System;
    using System.Collections;
    using System.Reflection;
    public class BatchStepCollection : CollectionBase
    {
        public virtual void Add(BatchStep NewParameter)
        {
            base.List.Add(NewParameter);
        }
        public virtual void Insert(int Index, BatchStep NewParameter)
        {
            base.List.Insert(Index, NewParameter);
        }
        public virtual BatchStep this[int Index]
        {
            get
            {
                return (BatchStep) base.List[Index];
            }
            set
            {
                base.List[Index] = value;
            }
        }
    }
}
