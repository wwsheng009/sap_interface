using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;
namespace SAPINT.Queries.QueryHelper
{
    [DebuggerStepThrough]
    public class SearchResultVariantsRow : DataRow
    {
        // Fields
        private SearchResultVariantsDataTable tableSearchResultVariants;
        // Methods
        internal SearchResultVariantsRow(DataRowBuilder rb)
            : base(rb)
        {
            this.tableSearchResultVariants = (SearchResultVariantsDataTable)base.Table;
        }
        public bool IsDescriptionTextNull()
        {
            return base.IsNull(this.tableSearchResultVariants.DescriptionTextColumn);
        }
        public bool IsVariantNameNull()
        {
            return base.IsNull(this.tableSearchResultVariants.VariantNameColumn);
        }
        public void SetDescriptionTextNull()
        {
            base[this.tableSearchResultVariants.DescriptionTextColumn] = Convert.DBNull;
        }
        public void SetVariantNameNull()
        {
            base[this.tableSearchResultVariants.VariantNameColumn] = Convert.DBNull;
        }
        // Properties
        public string DescriptionText
        {
            get
            {
                string str;
                try
                {
                    str = (string)base[this.tableSearchResultVariants.DescriptionTextColumn];
                }
                catch (InvalidCastException exception)
                {
                    throw new StrongTypingException("DBNull", exception);
                }
                return str;
            }
            set
            {
                base[this.tableSearchResultVariants.DescriptionTextColumn] = value;
            }
        }
        public string VariantName
        {
            get
            {
                string str;
                try
                {
                    str = (string)base[this.tableSearchResultVariants.VariantNameColumn];
                }
                catch (InvalidCastException exception)
                {
                    throw new StrongTypingException("DBNull", exception);
                }
                return str;
            }
            set
            {
                base[this.tableSearchResultVariants.VariantNameColumn] = value;
            }
        }
    }

}
