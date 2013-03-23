using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPINT.Utils;

namespace SAPINTCODE
{
    public class AbapCode
    {
        private Dictionary<int, String> _CodeList;
        private List<string> _DataDeclaration;
        private List<string> _Header;
        private List<string> _SelectSql;

        private List<TableInfo> _Tables;
        StringBuilder sb = new StringBuilder();

        public AbapCode()
        {
            _CodeList = new Dictionary<int, string>();
            _DataDeclaration = new List<string>();
            _Header = new List<string>();
            _SelectSql = new List<string>();
        }

        public List<TableInfo> Tables
        {
            set
            {
                this._Tables = value;
            }
        }
        private void BuildHeader()
        {
            _Header.Clear();
            _Header.Add("REPORT ZVI001.");
        }


        private void BuildDeclaration()
        {
            _DataDeclaration.Clear();
            string tmplate = "      {0}   TYPE {1}-{0}," + "  \"" + "{2}";

            _DataDeclaration.Add("DATA: BEGIN OF IT_DATA OCCURS 0 ,");
            foreach (TableInfo item in _Tables)
            {

                foreach (ReadTableField field in item.Fields.Where(x => x.Active == true))
                {
                    string s = string.Format(tmplate, field.FieldName, item.Name, field.FieldText);
                    _DataDeclaration.Add(s);

                }


            }
            _DataDeclaration.Add("END OF IT_DATA.");
        }

        private void BuildSelectSql()
        {
            _SelectSql.Clear();
            _SelectSql.Add("SELECT \r\n");
            if (_Tables.Count == 0)
            {
                return;
            }

            foreach (TableInfo item in _Tables)
            {

                foreach (ReadTableField field in item.Fields.Where(x => x.Active == true))
                {
                    _SelectSql.Add(string.Format("   {0}~{1} \r\n", item.Name, field.FieldName));
                }

            }

            _SelectSql.Add("  INTO TABLE IT_DATA \r\n");
            _SelectSql.Add(string.Format("  FROM {0} \r\n", _Tables[0].Name));

            for (int i = 1; i < _Tables.Count; i++)
            {
                _SelectSql.Add(string.Format(" INNER JOIN {1} ON {0}~ = {1}~ \r\n", _Tables[0].Name, _Tables[i].Name));
            }

            _SelectSql.Add("  WHERE \r\n");

            bool onlyOneTime = false;
            for (int i = 0; i < _Tables.Count; i++)
            {
                for (int g = 0; g < _Tables[i].Fields.Count; g++)
                {
                    if (_Tables[i].Fields[g].Active == false)
                    {
                        continue;
                    }

                    if (onlyOneTime == false)
                    {
                        _SelectSql.Add(string.Format("   {0}~{1} = '' \r\n", _Tables[i].Name, _Tables[i].Fields[g].FieldName));
                        onlyOneTime = true;
                    }
                    else
                    {
                        _SelectSql.Add(string.Format("  AND {0}~{1} = '' \r\n", _Tables[i].Name, _Tables[i].Fields[g].FieldName));
                    }
                }

            }

            _SelectSql.Add(".");
        }


        public string Excute()
        {
            sb.Clear();

            BuildHeader();
            _Header.ForEach(x => sb.AppendLine(x));

            AddBlankLine(2);
            BuildDeclaration();
            _DataDeclaration.ForEach(x => sb.AppendFormat("{0}\r\n", x));

            sb.AppendLine("START-OF-SELECTION.");
            AddBlankLine(2);

            BuildSelectSql();
            _SelectSql.ForEach(x => sb.Append(x));


            return sb.ToString();
        }

        private void AddBlankLine(int n)
        {
            for (int i = 0; i < n; i++)
            {
                sb.AppendLine();
            }

        }




    }
}
