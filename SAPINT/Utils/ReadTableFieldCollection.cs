namespace SAPINT.Utils
{
    using System;
    using System.Collections;
    using System.Reflection;
    public class ReadTableFieldCollection : CollectionBase
    {
        public virtual void Add(ReadTableField NewParameter)
        {
            base.List.Add(NewParameter);
        }
        internal int GetOverallLength()
        {
            int num = 0;
            foreach (ReadTableField field in this)
            {
                num += field.Length;
            }
            return num;
        }
        public virtual ReadTableField this[int Index]
        {
            get
            {
                return (ReadTableField) base.List[Index];
            }
            set
            {
                base.List[Index] = value;
            }
        }
    }
}
