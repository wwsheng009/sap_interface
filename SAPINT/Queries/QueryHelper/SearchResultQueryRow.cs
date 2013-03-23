using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace SAPINT.Queries.QueryHelper
{
    public class SearchResultQueryRow : DataRow
    {
        // Fields
        private SearchResultQueryDataTable tableSearchResultQuery;
        // Methods
        internal SearchResultQueryRow(DataRowBuilder rb)
            : base(rb)
        {
            this.tableSearchResultQuery = (SearchResultQueryDataTable)base.Table;
        }
        // Properties
        public string DescriptionText
        {
            get
            {
                string str;
                try
                {
                    str = (string)base[this.tableSearchResultQuery.DescriptionTextColumn];
                }
                catch (InvalidCastException exception)
                {
                    throw new StrongTypingException("DBNull", exception);
                }
                return str;
            }
            set
            {
                base[this.tableSearchResultQuery.DescriptionTextColumn] = value;
            }
        }
        public string QueryName
        {
            get
            {
                string str;
                try
                {
                    str = (string)base[this.tableSearchResultQuery.QueryNameColumn];
                }
                catch (InvalidCastException exception)
                {
                    throw new StrongTypingException("DBNull", exception);
                }
                return str;
            }
            set
            {
                base[this.tableSearchResultQuery.QueryNameColumn] = value;
            }
        }
        public string UserGroup
        {
            get
            {
                string str;
                try
                {
                    str = (string)base[this.tableSearchResultQuery.UserGroupColumn];
                }
                catch (InvalidCastException exception)
                {
                    throw new StrongTypingException("DBNull", exception);
                }
                return str;
            }
            set
            {
                base[this.tableSearchResultQuery.UserGroupColumn] = value;
            }
        }
    }

}
