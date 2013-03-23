namespace SAPINT.Queries
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class QueryFieldCollection : CollectionBase
    {
        #region Indexers
        // Properties
        public virtual QueryField this[string Name]
        {
            get
            {
                Name = Name.ToUpper().Trim();
                for (int i = 0; i < base.Count; i++)
                {
                    if (this[i].Name == Name)
                    {
                        return this[i];
                    }
                }
                throw new Exception(string.Format("Con't find element"));
            }
            set
            {
                Name = Name.ToUpper().Trim();
                for (int i = 0; i < base.Count; i++)
                {
                    if (this[i].Name == Name)
                    {
                        this[i] = value;
                    }
                }
                throw new Exception(string.Format("Con't find element"));
            }
        }
        public virtual QueryField this[int Index]
        {
            get
            {
                return (QueryField)base.List[Index];
            }
            set
            {
                base.List[Index] = value;
            }
        }
        #endregion Indexers
        #region Methods
        // Methods
        public virtual void Add(QueryField NewParameter)
        {
            base.List.Add(NewParameter);
        }
        #endregion Methods
    }
}