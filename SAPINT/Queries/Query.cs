namespace SAPINT.Queries
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using SAP.Middleware.Connector;
    public class Query
    {
        #region Fields
        // Fields
        private RfcDestination _des;
        private QueryFieldCollection _Fields;
        private int _MaxRows;
        private string _Name;
        private DataTable _Result;
        private QuerySelectionParameterCollection _SelectionParameters;
        private string _UserGroup;
        private string _Variant;
        private WorkSpace _WorkArea;
        #endregion Fields
        #region Constructors
        public Query()
        {
        }
        public Query(string sysName)
        {
            this._Name = "";
            this._UserGroup = "";
            this._Variant = "";
            this._Fields = new QueryFieldCollection();
            this._SelectionParameters = new QuerySelectionParameterCollection();
            this._des = SAPDestination.GetDesByName(sysName);
        }
        #endregion Constructors
        #region Properties
        // Properties
        public QueryFieldCollection Fields
        {
            get
            {
                return this._Fields;
            }
            set
            {
                this._Fields = value;
            }
        }
        public int MaxRows
        {
            get
            {
                return this._MaxRows;
            }
            set
            {
                this._MaxRows = value;
            }
        }
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value.Trim().ToUpper();
            }
        }
        public DataTable Result
        {
            get
            {
                return this._Result;
            }
        }
        public QuerySelectionParameterCollection SelectionParameters
        {
            get
            {
                return this._SelectionParameters;
            }
            set
            {
                this._SelectionParameters = value;
            }
        }
        public string UserGroup
        {
            get
            {
                return this._UserGroup;
            }
            set
            {
                this._UserGroup = value.Trim().ToUpper();
            }
        }
        public string Variant
        {
            get
            {
                return this._Variant;
            }
            set
            {
                this._Variant = value.Trim().ToUpper();
            }
        }
        public WorkSpace WorkArea
        {
            get
            {
                return this._WorkArea;
            }
            set
            {
                this._WorkArea = value;
            }
        }
        #endregion Properties
        #region Methods
        public void Excute()
        {
            if (this.Variant.Trim().Equals(""))
            {
                foreach (QuerySelectionParameter parameter in this.SelectionParameters)
                {
                    if ((parameter.Obligatory && (parameter.Ranges.Count == 0)) && !parameter.NoDisplay)
                    {
                        throw new SAPException(string.Format(Messages.Theselectionparameter_0_isobligatoryandthereisnovalueprovided, parameter.Name));
                        //throw new Exception();
                    }
                }
            }
            IRfcFunction function = this._des.Repository.CreateFunction("RSAQ_REMOTE_QUERY_CALL");
            if (this._WorkArea == WorkSpace.StandardArea)
            {
                function["WORKSPACE"].SetValue(" ");
            }
            else
            {
                function["WORKSPACE"].SetValue("X");
            }
            function["QUERY"].SetValue(this._Name);
            function["USERGROUP"].SetValue(this._UserGroup);
            function["VARIANT"].SetValue(this._Variant);
            function["SKIP_SELSCREEN"].SetValue("X");
            function["DATA_TO_MEMORY"].SetValue("X");
            function["DBACC"].SetValue(this._MaxRows);
            foreach (QuerySelectionParameter parameter2 in this._SelectionParameters)
            {
                for (int j = 0; j < parameter2.Ranges.Count; j++)
                {
                    IRfcTable table = function.GetTable("SELECTION_TABLE");
                    table.Append();
                    IRfcStructure structure = table.CurrentRow;
                    structure["SELNAME"].SetValue(parameter2.Name);
                    structure["KIND"].SetValue((parameter2.Kind == Kind.Parameter) ? "P" : "S");
                    structure["SIGN"].SetValue((parameter2.Ranges[j].Sign == Sign.Include) ? "I" : "E");
                    switch (parameter2.Ranges[j].Option)
                    {
                        case RangeOption.Equals:
                            structure["OPTION"].SetValue("EQ");
                            break;
                        case RangeOption.NotEquals:
                            structure["OPTION"].SetValue("NE");
                            break;
                        case RangeOption.GreaterThan:
                            structure["OPTION"].SetValue("GT");
                            break;
                        case RangeOption.LessThan:
                            structure["OPTION"].SetValue("LT");
                            break;
                        case RangeOption.GreaterThanOrEqualTo:
                            structure["OPTION"].SetValue("GE");
                            break;
                        case RangeOption.LessThanOrEqualTo:
                            structure["OPTION"].SetValue("LE");
                            break;
                        case RangeOption.Between:
                            structure["OPTION"].SetValue("BT");
                            break;
                        case RangeOption.NotBetween:
                            structure["OPTION"].SetValue("NB");
                            break;
                        case RangeOption.MatchesPattern:
                            structure["OPTION"].SetValue("CP");
                            break;
                        case RangeOption.NotMatchesPattern:
                            structure["OPTION"].SetValue("NP");
                            break;
                        default:
                            throw new Exception(string.Format(Messages.Unabletoconvert_0, parameter2.Ranges[j].Option.ToString()));
                        //throw new Exception();
                    }
                    structure["LOW"].SetValue(parameter2.Ranges[j].LowValue);
                    structure["HIGH"].SetValue(parameter2.Ranges[j].HighValue);
                }
            }
            try
            {
                function.Invoke(_des);
            }
            catch (RfcAbapException exception)
            {
                if (exception.Message.Equals("NO_USERGROUP"))
                {
                    throw new SAPException(Messages.Usergroupdoesnotexist, exception);
                }
                if (exception.Message.Equals("NO_QUERY"))
                {
                    throw new SAPException(Messages.Querydoesnotexists, exception);
                }
                if (exception.Message.Equals("QUERY_LOCKED"))
                {
                    throw new SAPException(Messages.Querylocked, exception);
                }
                if (exception.Message.Equals("NO_SELECTION"))
                {
                    throw new SAPException(Messages.PleasedefineaselectionorusetheMaxRowsproperty, exception);
                }
                if (exception.Message.Equals("NO_VARIANT"))
                {
                    throw new SAPException(Messages.Novariantorvariantinvalid, exception);
                }
                if (exception.Message.Equals("JUST_VIA_VARIANT"))
                {
                    throw new SAPException(Messages.Querymusthaveavariant, exception);
                }
                if (exception.Message.Equals("NO_SUBMIT_AUTH"))
                {
                    throw new SAPException(Messages.Badauthentication, exception);
                }
                if (exception.Message.Equals("NO_DATA_SELECTED"))
                {
                    throw new SAPException(Messages.Nodatacouldbeselected, exception);
                }
                if (exception.Message.Equals("DATA_TO_MEMORY_NOT_POSSIBLE"))
                {
                    throw new SAPException(Messages.ErrorduringSAPmemoryallocation, exception);
                }
                throw new SAPException(exception.Key + exception.Message);
            }
            this._Fields.Clear();
            string str = "";
            foreach (IRfcStructure structure2 in function.GetTable("LISTDESC").ToList())
            {
                if (str == "")
                {
                    str = structure2["LID"].GetValue().ToString();
                }
                if (structure2["LID"].GetValue().ToString() == str)
                {
                    bool flag = false;
                    for (int k = 0; k < this._Fields.Count; k++)
                    {
                        if (this._Fields[k].Name.Equals(structure2["FNAMEINT"].GetValue().ToString()))
                        {
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        this._Fields.Add(new QueryField(structure2["FNAMEINT"].GetValue().ToString(), structure2["FTYP"].GetValue().ToString(), Convert.ToInt32(structure2["FLEN"].GetValue().ToString()), Convert.ToInt32(structure2["FDEC"].GetValue().ToString()), structure2["FDESC"].GetValue().ToString()));
                    }
                }
            }
            DataTable dt = new DataTable();
            dt.BeginInit();
            for (int i = 0; i < this._Fields.Count; i++)
            {
                string name = this._Fields[i].Name;
                DataColumn column = new DataColumn(name)
                {
                    Caption = this._Fields[i].Description
                };
                if (this._Fields[i].ABAPType.Equals("I"))
                {
                    column.DataType = Type.GetType("System.Int32");
                }
                else if (this._Fields[i].ABAPType.Equals("F"))
                {
                    column.DataType = Type.GetType("System.Double");
                }
                else if (this._Fields[i].ABAPType.Equals("P"))
                {
                    column.DataType = Type.GetType("System.Decimal");
                }
                else
                {
                    column.DataType = Type.GetType("System.String");
                }
                if (!this.SpalteVorhanden(dt, name))
                {
                    dt.Columns.Add(column);
                }
            }
            dt.EndInit();
            int startIndex = 0;
            int num5 = 0;
            int length = 0;
            int num7 = 0;
            string str3 = "";
            string str4 = "";
            bool flag2 = true;
            IRfcStructure structure3 = null;
            if (function.GetTable("LDATA").RowCount > 0)
            {
                DataRow row = dt.NewRow();
                while (flag2)
                {
                    IRfcTable tb = function.GetTable("LDATA");
                    structure3 = function.GetTable("LDATA")[num7];
                    str3 = structure3["LINE"].GetValue().ToString().PadRight(0x41a);
                    string str5 = str3.Substring(startIndex, 3);
                    if (str5.Contains(":") && (startIndex > 1))
                    {
                        startIndex--;
                        str5 = str3.Substring(startIndex, 3);
                    }
                    if (str5.Contains(":") && (startIndex > 1))
                    {
                        startIndex--;
                        str5 = str3.Substring(startIndex, 3);
                    }
                    if (str5.Equals("   "))
                    {
                        if (num7 < (function.GetTable("LDATA").RowCount - 1))
                        {
                            num7++;
                            startIndex = 0;
                        }
                        else
                        {
                            flag2 = false;
                        }
                        continue;
                    }
                    if (str5.Equals("/  "))
                    {
                        flag2 = false;
                        continue;
                    }
                    length = Convert.ToInt32(str5);
                    startIndex += 4;
                    str4 = str3.Substring(startIndex, length);
                    if (this._Fields[num5].ABAPType.Equals("I"))
                    {
                        try
                        {
                            bool flag3 = false;
                            if (str4.EndsWith("-"))
                            {
                                flag3 = true;
                                str4 = str4.Substring(0, str4.Length - 1);
                            }
                            int num8 = Convert.ToInt32(str4);
                            if (flag3)
                            {
                                num8 *= -1;
                            }
                            row[num5] = num8;
                            goto Label_0B7C;
                        }
                        catch (Exception exception2)
                        {
                            throw new SAPException("Unable to convert '" + str4 + "' to data type Int32", exception2);
                            //throw exception2;
                        }
                    }
                    if (this._Fields[num5].ABAPType.Equals("P"))
                    {
                        str4 = str4.Replace(".", "").Replace(",", "");
                        bool flag4 = false;
                        try
                        {
                            if (str4.EndsWith("-"))
                            {
                                flag4 = true;
                                str4 = str4.Substring(0, str4.Length - 1);
                            }
                            int num9 = str4.Length;
                            string str6 = str4.Substring(num9 - this._Fields[num5].Decimals, this._Fields[num5].Decimals);
                            string str7 = str4.Substring(0, num9 - this._Fields[num5].Decimals);
                            if (str6.Equals(""))
                            {
                                str6 = "0";
                            }
                            decimal num10 = Convert.ToDecimal(str7) + (Convert.ToDecimal(str6) / Convert.ToDecimal(Math.Pow(10.0, (double)this._Fields[num5].Decimals)));
                            if (flag4)
                            {
                                num10 *= -1M;
                            }
                            row[num5] = num10;
                            goto Label_0B7C;
                        }
                        catch (Exception exception3)
                        {
                            throw new SAPException("Unable to convert '" + str4 + "' to data type Decimal", exception3);
                        }
                    }
                    if (this._Fields[num5].ABAPType.Equals("F"))
                    {
                        try
                        {
                            row[num5] = Convert.ToDouble(str4);
                            goto Label_0B7C;
                        }
                        catch (Exception exception4)
                        {
                            throw new SAPException("Unable to convert '" + str4 + "' to data type Double", exception4);
                        }
                    }
                    try
                    {
                        row[num5] = str4;
                    }
                    catch (Exception exception5)
                    {
                        throw new SAPException("Unable to process value '" + str4 + "'", exception5);
                    }
                Label_0B7C:
                    startIndex += length + 1;
                    if (num5 == (this._Fields.Count - 1))
                    {
                        dt.Rows.Add(row);
                        row = dt.NewRow();
                        num5 = 0;
                    }
                    else
                    {
                        num5++;
                    }
                }
                this._Result = dt;
            }
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Name: ".PadRight(20) + this.Name + "\r\n");
            builder.Append("Usergroup: ".PadRight(20) + this.UserGroup + "\r\n");
            builder.Append("WorkArea: ".PadRight(20) + this.WorkArea + "\r\n");
            builder.Append("Variant: ".PadRight(20) + this.Variant + "\r\n");
            builder.Append("\r\n");
            builder.Append("Selection Fields\r\n");
            builder.Append("################\r\n");
            foreach (QuerySelectionParameter parameter in this.SelectionParameters)
            {
                builder.Append(parameter.Name.PadRight(20) + " (" + parameter.Kind.ToString() + ") -> " + parameter.DescriptionText + " " + (parameter.Obligatory ? "(Obligatory) " : "") + "\r\n");
            }
            builder.Append("\r\n");
            builder.Append("Output Fields\r\n");
            builder.Append("#############\r\n");
            foreach (QueryField field in this.Fields)
            {
                builder.Append(field.Name.PadRight(20) + " (" + field.ABAPType + ")\r\n");
            }
            return builder.ToString();
        }
        internal void RefreshFieldsAndSelections()
        {
            if (this._UserGroup.Trim().Equals("") || this._Name.Trim().Equals(""))
            {
                throw new SAPException(Messages.PleasemakesurethatthefieldsUserGroupandNamearefilledcorrectly);
            }
            //RFCFunction function = RFCFunctionFactory.GenerateFunctionObjectForRSAQ_REMOTE_QUERY_FIELDLIST(this._con.IsUnicode);
            IRfcFunction function = _des.Repository.CreateFunction("RSAQ_REMOTE_QUERY_FIELDLIST");
            //function.Connection = this._con;
            if (this._WorkArea == WorkSpace.StandardArea)
            {
                function.SetValue("WORKSPACE", " ");
            }
            else
            {
                function.SetValue("WORKSPACE", "X");
            }
            function["QUERY"].SetValue(this._Name);
            function.SetValue("USERGROUP", this._UserGroup);
            //function.Exports["USERGROUP"].ParamValue = this._UserGroup;
            try
            {
                function.Invoke(_des);
                // function.Execute();
                IRfcTable table = function.GetTable("FIELDS");
                IRfcTable table2 = function.GetTable("SEL_FIELDS");
                this._Fields.Clear();
                this._SelectionParameters.Clear();
                string str = "";
                foreach (IRfcStructure structure in table.ToList())
                {
                    if (str == "")
                    {
                        str = structure["LID"].GetValue().ToString();
                    }
                    if (str == structure["LID"].GetValue().ToString())
                    {
                        QueryField newParameter = new QueryField(structure["NAME"].GetValue().ToString(), structure["TYPE"].GetValue().ToString(), Convert.ToInt32(structure["OLENG"].GetValue()), Convert.ToInt32(structure["DECIMALS"].GetValue()), "");
                        this._Fields.Add(newParameter);
                        if ((!structure["CURRY"].GetValue().ToString().Trim().Equals("") && !structure["CURRY"].GetValue().ToString().Trim().Equals("W")) && !structure["CURRY"].GetValue().ToString().Trim().Equals("E"))
                        {
                            QueryField field2 = new QueryField(structure["NAME"].GetValue().ToString() + "-" + structure["LINE"].GetValue().ToString() + structure["POS"].GetValue().ToString(), "C", 10, 0, "");
                            this._Fields.Add(field2);
                        }
                    }
                }
                foreach (IRfcStructure structure2 in table2.ToList())
                {
                    if (!structure2["SPNAME"].GetValue().ToString().Substring(0, 1).Equals("%"))
                    {
                        string descriptionText = structure2["FTEXT"].GetValue().ToString();
                        if (descriptionText.StartsWith("D       "))
                        {
                            descriptionText = descriptionText.Substring(8);
                        }
                        QuerySelectionParameter parameter = new QuerySelectionParameter(structure2["SPNAME"].GetValue().ToString(), structure2["FNAME"].GetValue().ToString(), descriptionText, Convert.ToInt32(structure2["LENGTH"].GetValue()), structure2["OBLIGATORY"].GetValue().ToString().Equals("X"), structure2["NODISPLAY"].GetValue().ToString().Equals("X"), structure2["KIND"].GetValue().ToString().Equals("S") ? Kind.SelectOption : Kind.Parameter);
                        this.SelectionParameters.Add(parameter);
                    }
                }
            }
            catch (RfcAbapException ee)
            {
                throw new SAPException(ee.Key + ee.Message);
            }
            catch (Exception ee)
            {
                throw new SAPException(ee.Message);
            }

        }
        private bool SpalteVorhanden(DataTable dt, string name)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (name.Equals(dt.Columns[i].ColumnName))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion Methods
    }
}
