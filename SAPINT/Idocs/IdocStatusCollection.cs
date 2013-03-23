namespace SAPINT.Idocs
{
    using System;
    using System.Collections;
    using System.Reflection;
    public class IdocStatusCollection : CollectionBase
    {
        public virtual void Add(IdocStatus NewStatus)
        {
            base.List.Add(NewStatus);
        }
        public virtual IdocStatus this[int Index]
        {
            get
            {
                return (IdocStatus) base.List[Index];
            }
        }
    }
}
