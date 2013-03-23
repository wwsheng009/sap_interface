namespace SAPINT.Utils
{
    using System;
    using System.Collections;
    using System.Reflection;
    public class BatchReturnCollection : CollectionBase
    {
        public virtual void Add(BatchReturn NewBatchReturn)
        {
            base.List.Add(NewBatchReturn);
        }
        public virtual BatchReturn this[int Index]
        {
            get
            {
                return (BatchReturn) base.List[Index];
            }
        }
    }
}
