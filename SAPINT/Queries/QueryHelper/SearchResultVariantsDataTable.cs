using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
namespace SAPINT.Queries.QueryHelper
{
    public class SearchResultVariantsDataTable : DataTable, IEnumerable
    {
        // Fields
        private DataColumn columnDescriptionText;
        private DataColumn columnVariantName;
        // Methods
        internal SearchResultVariantsDataTable()
            : base("SearchResultVariants")
        {
            this.InitClass();
        }
        internal SearchResultVariantsDataTable(DataTable table)
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
        public void AddSearchResultVariantsRow(SearchResultVariantsRow row)
        {
            base.Rows.Add(row);
        }
        public SearchResultVariantsRow AddSearchResultVariantsRow(string VariantName, string DescriptionText)
        {
            SearchResultVariantsRow row = (SearchResultVariantsRow)base.NewRow();
            row.ItemArray = new object[] { VariantName, DescriptionText };
            base.Rows.Add(row);
            return row;
        }
        public override DataTable Clone()
        {
            SearchResultVariantsDataTable table = (SearchResultVariantsDataTable)base.Clone();
            table.InitVars();
            return table;
        }
        protected override DataTable CreateInstance()
        {
            return new SearchResultVariantsDataTable();
        }
        public IEnumerator GetEnumerator()
        {
            return base.Rows.GetEnumerator();
        }
        protected override Type GetRowType()
        {
            return typeof(SearchResultVariantsRow);
        }
        private void InitClass()
        {
            this.columnVariantName = new DataColumn("VariantName", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnVariantName);
            this.columnDescriptionText = new DataColumn("DescriptionText", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnDescriptionText);
        }
        internal void InitVars()
        {
            this.columnVariantName = base.Columns["VariantName"];
            this.columnDescriptionText = base.Columns["DescriptionText"];
        }
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new SearchResultVariantsRow(builder);
        }
        public SearchResultVariantsRow NewSearchResultVariantsRow()
        {
            return (SearchResultVariantsRow)base.NewRow();
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
        public void RemoveSearchResultVariantsRow(SearchResultVariantsRow row)
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
        public SearchResultVariantsRow this[int index]
        {
            get
            {
                return (SearchResultVariantsRow)base.Rows[index];
            }
        }
        internal DataColumn VariantNameColumn
        {
            get
            {
                return this.columnVariantName;
            }
        }
    }

}
