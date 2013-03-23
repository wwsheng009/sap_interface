using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;
namespace SAPINT.Queries.QueryHelper
{
    [DebuggerStepThrough]
    public class SearchResultUserGroupsRow : DataRow
    {
        // Fields
        private SearchResultUserGroupsDataTable tableSearchResultUserGroups;
        // Methods
        internal SearchResultUserGroupsRow(DataRowBuilder rb)
            : base(rb)
        {
            this.tableSearchResultUserGroups = (SearchResultUserGroupsDataTable)base.Table;
        }
        public bool IsDescriptionTextNull()
        {
            return base.IsNull(this.tableSearchResultUserGroups.DescriptionTextColumn);
        }
        public bool IsUserGroupNull()
        {
            return base.IsNull(this.tableSearchResultUserGroups.UserGroupColumn);
        }
        public void SetDescriptionTextNull()
        {
            base[this.tableSearchResultUserGroups.DescriptionTextColumn] = Convert.DBNull;
        }
        public void SetUserGroupNull()
        {
            base[this.tableSearchResultUserGroups.UserGroupColumn] = Convert.DBNull;
        }
        // Properties
        public string DescriptionText
        {
            get
            {
                string str;
                try
                {
                    str = (string)base[this.tableSearchResultUserGroups.DescriptionTextColumn];
                }
                catch (InvalidCastException exception)
                {
                    throw new StrongTypingException("DBNull", exception);
                }
                return str;
            }
            set
            {
                base[this.tableSearchResultUserGroups.DescriptionTextColumn] = value;
            }
        }
        public string UserGroup
        {
            get
            {
                string str;
                try
                {
                    str = (string)base[this.tableSearchResultUserGroups.UserGroupColumn];
                }
                catch (InvalidCastException exception)
                {
                    throw new StrongTypingException("DBNull", exception);
                }
                return str;
            }
            set
            {
                base[this.tableSearchResultUserGroups.UserGroupColumn] = value;
            }
        }
    }

}
