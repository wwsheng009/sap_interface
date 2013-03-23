namespace SAPINT.Idocs
{
    using SAPINT;
    using System;
    using System.Collections;
    using System.Reflection;
    public class IdocSegmentFieldCollection : CollectionBase
    {
        public void Add(IdocSegmentField NewParameter)
        {
            base.List.Add(NewParameter);
        }
        public IdocSegmentField Add(string Name)
        {
            IdocSegmentField field = new IdocSegmentField(Name);
            base.List.Add(field);
            return field;
        }
        public IdocSegmentField Add(string Name, string Description, int Length, int Offset, string DataType, object FieldValue)
        {
            IdocSegmentField field = new IdocSegmentField(Name, Description, Length, Offset, DataType, FieldValue);
            base.List.Add(field);
            return field;
        }
        public virtual IdocSegmentField this[string SegmentName]
        {
            get
            {
                for (int i = 0; i < base.List.Count; i++)
                {
                    if (((IdocSegmentField) base.List[i]).FieldName == SegmentName.ToUpper().Trim())
                    {
                        return this[i];
                    }
                }
                throw new SAPException(string.Format(Messages.CouldnotfindElement_0, SegmentName));
            }
            set
            {
                for (int i = 0; i < base.List.Count; i++)
                {
                    if (((IdocSegmentField) base.List[i]).FieldName == SegmentName.ToUpper().Trim())
                    {
                        this[i] = value;
                    }
                }
                throw new SAPException(string.Format(Messages.CouldnotfindElement_0, SegmentName));
            }
        }
        public virtual IdocSegmentField this[int Index]
        {
            get
            {
                return (IdocSegmentField) base.List[Index];
            }
            set
            {
                base.List[Index] = value;
            }
        }
    }
}
