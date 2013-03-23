using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
namespace SAPINT.Queries.QueryHelper
{
    public class SearchResultQueryDataTable : DataTable, IEnumerable
    {
        // Fields
        private DataColumn columnDescriptionText;
        private DataColumn columnQueryName;
        private DataColumn columnUserGroup;
        // Methods
        internal SearchResultQueryDataTable()
            : base("SearchResultQuery")
        {
            this.InitClass();
        }
        internal SearchResultQueryDataTable(DataTable table)
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
        public void AddSearchResultQueryRow(SearchResultQueryRow row)
        {
            base.Rows.Add(row);
        }
        public SearchResultQueryRow AddSearchResultQueryRow(string QueryName, string UserGroup, string DescriptionText)
        {
            SearchResultQueryRow row = (SearchResultQueryRow)base.NewRow();
            row.ItemArray = new object[] { QueryName, UserGroup, DescriptionText };
            base.Rows.Add(row);
            return row;
        }
        public override DataTable Clone()
        {
            SearchResultQueryDataTable table = (SearchResultQueryDataTable)base.Clone();
            table.InitVars();
            return table;
        }
        protected override DataTable CreateInstance()
        {
            return new SearchResultQueryDataTable();
        }
        public IEnumerator GetEnumerator()
        {
            return base.Rows.GetEnumerator();
        }
        protected override Type GetRowType()
        {
            return typeof(SearchResultQueryRow);
        }
        private void InitClass()
        {
            this.columnQueryName = new DataColumn("QueryName", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnQueryName);
            this.columnUserGroup = new DataColumn("UserGroup", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnUserGroup);
            this.columnDescriptionText = new DataColumn("DescriptionText", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnDescriptionText);
        }
        internal void InitVars()
        {
            this.columnQueryName = base.Columns["QueryName"];
            this.columnUserGroup = base.Columns["UserGroup"];
            this.columnDescriptionText = base.Columns["DescriptionText"];
        }
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new SearchResultQueryRow(builder);
        }
        public SearchResultQueryRow NewSearchResultQueryRow()
        {
            return (SearchResultQueryRow)base.NewRow();
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
        public void RemoveSearchResultQueryRow(SearchResultQueryRow row)
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
        public SearchResultQueryRow this[int index]
        {
            get
            {
                return (SearchResultQueryRow)base.Rows[index];
            }
        }
        internal DataColumn QueryNameColumn
        {
            get
            {
                return this.columnQueryName;
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
