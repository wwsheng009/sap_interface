namespace SAPINT.Queries
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class QuerySelectionParameterCollection : CollectionBase
    {
        #region Indexers
        // Properties
        public virtual QuerySelectionParameter this[string Name]
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
                throw new Exception(string.Format("Con't find Element"));
            }
            set
            {
                Name = Name.ToUpper().Trim();
                for (int i = 0; i < base.Count; i++)
                {
                    if (this[i].Name == Name)
                    {
                        this[i] = value;
                        return;
                    }
                }
                throw new Exception(string.Format("Con't find Element"));
            }
        }
        public virtual QuerySelectionParameter this[int Index]
        {
            get
            {
                return (QuerySelectionParameter)base.List[Index];
            }
            set
            {
                QuerySelectionParameter parameter = (QuerySelectionParameter)base.List[Index];
                if (!parameter.ABAPType.Equals("") && value.ABAPType.Equals(""))
                {
                    value.ABAPType = parameter.ABAPType;
                }
                if (!parameter.DescriptionText.Equals("") && value.DescriptionText.Equals(""))
                {
                    value.DescriptionText = parameter.DescriptionText;
                }
                if (!parameter.FieldName.Equals("") && value.FieldName.Equals(""))
                {
                    value.FieldName = parameter.FieldName;
                }
                if (!parameter.Name.Equals("") && value.Name.Equals(""))
                {
                    value.Name = parameter.Name;
                }
                if ((parameter.Length > 0) && (value.Length == 0))
                {
                    value.Length = parameter.Length;
                }
                base.List[Index] = value;
            }
        }
        #endregion Indexers
        #region Methods
        // Methods
        public virtual void Add(QuerySelectionParameter NewParameter)
        {
            base.List.Add(NewParameter);
        }
        #endregion Methods
    }
}
