namespace SAPINT.Idocs
{
    using SAPINT;
    using System;
    using System.Collections;
    using System.Reflection;
    public class IdocSegmentCollection : CollectionBase
    {
        public virtual void Add(IdocSegment NewSegment)
        {
            base.List.Add(NewSegment);
        }
        public virtual IdocSegment this[string SegmentName, int Index]
        {
            get
            {
                int num = 0;
                SegmentName = SegmentName.Trim().ToUpper();
                for (int i = 0; i < base.List.Count; i++)
                {
                    if (((IdocSegment) base.List[i]).SegmentName == SegmentName)
                    {
                        if (num == Index)
                        {
                            return (IdocSegment) base.List[i];
                        }
                        num++;
                    }
                }
                throw new SAPException(string.Format(Messages.CouldnotfindElement_0, SegmentName + "-" + Index.ToString()));
            }
        }
        public virtual IdocSegment this[int Index]
        {
            get
            {
                return (IdocSegment) base.List[Index];
            }
        }
    }
}
