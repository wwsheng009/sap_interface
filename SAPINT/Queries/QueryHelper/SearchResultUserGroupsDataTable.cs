using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
namespace SAPINT.Queries.QueryHelper
{
    public class SearchResultUserGroupsDataTable : DataTable, IEnumerable
    {
        // Fields
        private DataColumn columnDescriptionText;
        private DataColumn columnUserGroup;
        // Methods
        internal SearchResultUserGroupsDataTable()
            : base("SearchResultUserGroups")
        {
            this.InitClass();
        }
        internal SearchResultUserGroupsDataTable(DataTable table)
            : base(table.TableName)
        {
            if (table.CaseSensitive != table.DataSet.CaseSensitive)
            {
                base.CaseSensitive = table.CaseSensitive;
            }
            if (table.Locale.ToString() != table.DataSet.Locale.ToString())
            {
                base.Locale = table.Locale;
            }
            if (table.Namespace != table.DataSet.Namespace)
            {
                base.Namespace = table.Namespace;
            }
            base.Prefix = table.Prefix;
            base.MinimumCapacity = table.MinimumCapacity;
            base.DisplayExpression = table.DisplayExpression;
        }
        public void AddSearchResultUserGroupsRow(SearchResultUserGroupsRow row)
        {
            base.Rows.Add(row);
        }
        public SearchResultUserGroupsRow AddSearchResultUserGroupsRow(string UserGroup, string DescriptionText)
        {
            SearchResultUserGroupsRow row = (SearchResultUserGroupsRow)base.NewRow();
            row.ItemArray = new object[] { UserGroup, DescriptionText };
            base.Rows.Add(row);
            return row;
        }
        public override DataTable Clone()
        {
            SearchResultUserGroupsDataTable table = (SearchResultUserGroupsDataTable)base.Clone();
            table.InitVars();
            return table;
        }
        protected override DataTable CreateInstance()
        {
            return new SearchResultUserGroupsDataTable();
        }
        public IEnumerator GetEnumerator()
        {
            return base.Rows.GetEnumerator();
        }
        protected override Type GetRowType()
        {
            return typeof(SearchResultUserGroupsRow);
        }
        private void InitClass()
        {
            this.columnUserGroup = new DataColumn("UserGroup", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnUserGroup);
            this.columnDescriptionText = new DataColumn("DescriptionText", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnDescriptionText);
        }
        internal void InitVars()
        {
            this.columnUserGroup = base.Columns["UserGroup"];
            this.columnDescriptionText = base.Columns["DescriptionText"];
        }
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new SearchResultUserGroupsRow(builder);
        }
        public SearchResultUserGroupsRow NewSearchResultUserGroupsRow()
        {
            return (SearchResultUserGroupsRow)base.NewRow();
        }
        protected override void OnRowChanged(DataRowChangeEventArgs e)
        {
            base.OnRowChanged(e);
        }
        protected override void OnRowChanging(DataRowChangeEventArgs e)
        {
            base.OnRowChanging(e);
        }
        protected override void OnRowDeleted(DataRowChangeEventArgs e)
        {
            base.OnRowDeleted(e);
        }
        protected override void OnRowDeleting(DataRowChangeEventArgs e)
        {
            base.OnRowDeleting(e);
        }
        public void RemoveSearchResultUserGroupsRow(SearchResultUserGroupsRow row)
        {
            base.Rows.Remove(row);
        }
        // Properties
        [Browsable(false)]
        public int Count
        {
            get
            {
                return base.Rows.Count;
            }
        }
        internal DataColumn DescriptionTextColumn
        {
            get
            {
                return this.columnDescriptionText;
            }
        }
        public SearchResultUserGroupsRow this[int index]
        {
            get
            {
                return (SearchResultUserGroupsRow)base.Rows[index];
            }
        }
        internal DataColumn UserGroupColumn
        {
            get
            {
                return this.columnUserGroup;
            }
        }
    }

}
