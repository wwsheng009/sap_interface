using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace SAPINT
{
    public class BapiReturnCollection : CollectionBase
    {
        public virtual void Add(BapiReturn NewBapiReturn)
        {
            base.List.Add(NewBapiReturn);
        }
        public virtual BapiReturn this[int Index]
        {
            get
            {
                return (BapiReturn)base.List[Index];
            }
        }
    }
}
