using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
namespace SAPINT.Queries.QueryHelper
{
    public class QueryHelper
    {
        // Fields
        private RfcDestination _des;
        // Methods
        public QueryHelper(string sysName)
        {
            this._des = SAPDestination.GetDesByName(sysName);
        }
        public SearchResultQueryDataTable SearchForQueries(WorkSpace WorkSpace, string SearchPatternUserGroup, string SearchPatternQueryName, string SearchPatternFunctionAreaName)
        {
            SearchResultQueryDataTable table = new SearchResultQueryDataTable();
            IRfcFunction function = this._des.Repository.CreateFunction("RSAQ_REMOTE_QUERY_CATALOG");
            function["WORKSPACE"].SetValue( (WorkSpace == WorkSpace.GlobalArea) ? "X" : " ");
            if (SearchPatternQueryName.Trim().Equals(""))
            {
                SearchPatternQueryName = "*";
            }
            if (SearchPatternUserGroup.Trim().Equals(""))
            {
                SearchPatternUserGroup = "*";
            }
            if (SearchPatternFunctionAreaName.Trim().Equals(""))
            {
                SearchPatternFunctionAreaName = "*";
            }
            function["GENERIC_QUERYNAME"].SetValue(SearchPatternQueryName);
            function["GENERIC_USERGROUP"].SetValue(SearchPatternUserGroup);
            function["GENERIC_FUNCAREA"].SetValue(SearchPatternFunctionAreaName);
            function.Invoke(_des);
            IRfcTable table2 = function.GetTable("QUERYCATALOG");
            foreach (IRfcStructure structure in table2.ToList())
            {
                table.AddSearchResultQueryRow(structure["QUERY"].GetValue().ToString().Trim(), structure["NUM"].GetValue().ToString().Trim(), structure["QTEXT"].GetValue().ToString().Trim());
            }
            return table;
        }
        public SearchResultUserGroupsDataTable SearchForUserGroups(WorkSpace WorkSpace, string UserGroupSearchPattern)
        {
            SearchResultUserGroupsDataTable table = new SearchResultUserGroupsDataTable();
            IRfcFunction function = this._des.Repository.CreateFunction("RSAQ_REMOTE_USERGROUP_CATALOG");
            function["WORKSPACE"].SetValue((WorkSpace == WorkSpace.GlobalArea) ? "X" : " ");
            function["GENERIC_USERGROUP"].SetValue(UserGroupSearchPattern);
            function.Invoke(_des);
            IRfcTable table2 = function.GetTable("USERGROUPCATALOG");
            foreach (IRfcStructure structure in table2.ToList())
            {
                string userGroup = structure["NUM"].GetValue().ToString().Trim();
                string descriptionText = structure["UTEXT"].GetValue().ToString().Trim();
                table.AddSearchResultUserGroupsRow(userGroup, descriptionText);
            }
            return table;
        }
        public SearchResultVariantsDataTable SearchForVariants(WorkSpace WorkSpace, string UserGroupName, string QueryName)
        {
            SearchResultVariantsDataTable table = new SearchResultVariantsDataTable();
            IRfcFunction function = this._des.Repository.CreateFunction("RSAQ_REMOTE_QUERY_CALL_CATALOG");
            function["WORKSPACE"].SetValue((WorkSpace == WorkSpace.GlobalArea) ? "X" : " ");
            function["GENERIC_QUERYNAME"].SetValue(QueryName);
            function["GENERIC_USERGROUP"].SetValue(UserGroupName);
            function["GENERIC_FUNCAREA"].SetValue("*");
            function.Invoke(_des);
            IRfcTable table2 = function.GetTable("QUERYCATALOG");
            foreach (IRfcStructure structure in table2.ToList())
            {
                string str = structure["VARIANT"].GetValue().ToString().Trim();
                string descriptionText = structure["VTEXT"].GetValue().ToString().Trim();
                bool flag = false;
                if (!str.Equals(""))
                {
                    foreach (SearchResultVariantsRow row in table.Rows)
                    {
                        if (row.VariantName.Trim().Equals(str))
                        {
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        table.AddSearchResultVariantsRow(str, descriptionText);
                    }
                }
            }
            return table;
        }
        // Properties
        public RfcDestination Destination
        {
            get
            {
                return this._des;
            }
            set
            {
                this._des = value;
            }
        }
    }

}
