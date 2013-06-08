namespace SAPINT.Linq
{
    using SAPINT;
    using SAPINT.Utils;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text;
    using SAP.Middleware.Connector;

    public class SAPTable<TEntity> : IOrderedQueryable<TEntity>, IQueryable<TEntity>, IEnumerable<TEntity>, IOrderedQueryable, IQueryable, IEnumerable, IQueryProvider, IListSource
    {
        private bool _count;
        private SAPDataContext _SAPDataContext;
        private bool _first;
        private bool _firstOrDefault;
        private bool _last;
        private bool _lastOrDefault;
        private string _orderBy;
        private Type _originalType;
        private Delegate _projection;
        private HashSet<string> _properties;
        private string _query;
        private int _skip;
        private int _take;
        private bool _useMultibyteExtraction;

        public string Connection;
        public TextWriter Log;
        public SAPTable(String connection)
            : this(connection, null)
        {
        }

        public SAPTable(SAPDataContext context, bool useMultibyteExtraction)
            : this(context.Connection, context.Log, useMultibyteExtraction)
        {
            this._SAPDataContext = context;
        }

        public SAPTable(String connection, TextWriter log)
        {
            this._properties = new HashSet<string>();
            this._originalType = typeof(TEntity);
            this.Connection = connection;
            //this.Connection = SAPDestination.GetDesByName(connection); ;
            this.Log = log;
        }

        public SAPTable(String connection, TextWriter log, bool useMultibyteExtraction)
            : this(connection, log)
        {
            this._useMultibyteExtraction = useMultibyteExtraction;
        }

        private void AssignResultProperty(DataRowView dr, object result, string property)
        {
            string str2;
            PropertyInfo info = this._originalType.GetProperty(property);
            SAPColumnAttribute[] customAttributes = info.GetCustomAttributes(typeof(SAPColumnAttribute), false) as SAPColumnAttribute[];
            string str = ((customAttributes != null) && (customAttributes.Length != 0)) ? customAttributes[0].Name : property;
            if (info.PropertyType == typeof(int))
            {
                str2 = Convert.ToString(dr[str]).Trim();
                if (str2 == null)
                {
                    str2 = "0";
                }
                else if (str2.EndsWith("-"))
                {
                    str2 = "-" + str2.TrimEnd("-".ToCharArray());
                }
                info.SetValue(result, Convert.ToInt32(str2, CultureInfo.InvariantCulture.NumberFormat), null);
            }
            else if (info.PropertyType == typeof(double))
            {
                str2 = Convert.ToString(dr[str]).Trim();
                if (str2 == null)
                {
                    str2 = "0";
                }
                else if (str2.EndsWith("-"))
                {
                    str2 = "-" + str2.TrimEnd("-".ToCharArray());
                }
                info.SetValue(result, Convert.ToDouble(str2, CultureInfo.InvariantCulture.NumberFormat), null);
            }
            else
            {
                if (info.PropertyType == typeof(decimal))
                {
                    str2 = Convert.ToString(dr[str]).Trim();
                    if (str2 == null)
                    {
                        str2 = "0";
                    }
                    else if (str2.EndsWith("-"))
                    {
                        str2 = "-" + str2.TrimEnd("-".ToCharArray());
                    }
                    try
                    {
                        info.SetValue(result, Convert.ToDecimal(str2, CultureInfo.InvariantCulture.NumberFormat), null);
                        return;
                    }
                    catch (Exception exception)
                    {
                        throw new Exception("Cannot convert '" + str2 + "' to decimal", exception);
                    }
                }
                if (info.PropertyType == typeof(float))
                {
                    str2 = Convert.ToString(dr[str]).Trim();
                    if (str2 == null)
                    {
                        str2 = "0";
                    }
                    else if (str2.EndsWith("-"))
                    {
                        str2 = "-" + str2.TrimEnd("-".ToCharArray());
                    }
                    info.SetValue(result, Convert.ToSingle(str2, CultureInfo.InvariantCulture.NumberFormat), null);
                }
                else
                {
                    info.SetValue(result, dr[str], null);
                }
            }
        }

        private DataTable BeginExecuteQuery()
        {
            string name;
            string str2 = this._query;
            SAPTableAttribute[] customAttributes = (SAPTableAttribute[])this._originalType.GetCustomAttributes(typeof(SAPTableAttribute), false);
            if ((customAttributes == null) || (customAttributes.Length == 0))
            {
                name = this._originalType.Name;
            }
            else if (!string.IsNullOrEmpty(customAttributes[0].Name))
            {
                name = customAttributes[0].Name;
            }
            else
            {
                name = this._originalType.Name;
            }
            //if (!this.Connection.Ping())
            //{
            //    this.Connection.
            //    this.Connection.Open();
            //}
            ReadTable table = new ReadTable(this.Connection)
            {
                TableName = name
            };
            table.EventMessage += table_eventMessage;
            if (this._useMultibyteExtraction)
            {
                table.Delimiter = "|";
            }
            if (!string.IsNullOrEmpty(str2))
            {
                table.WhereClause = str2;
            }
            if (this._skip > 0)
            {
                table.RowSkip = this._skip;
            }
            if (this._take > 0)
            {
                table.RowCount = this._take;
            }
            if (((customAttributes != null) && (customAttributes.Length > 0)) && !string.IsNullOrEmpty(customAttributes[0].CustomFunctionName))
            {
                table.SetCustomFunctionName(customAttributes[0].CustomFunctionName);
            }
            PropertyInfo[] properties = this._originalType.GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                SAPColumnAttribute[] attributeArray2 = (SAPColumnAttribute[])properties[i].GetCustomAttributes(typeof(SAPColumnAttribute), false);
                string fieldName = properties[i].Name;
                if (((attributeArray2 != null) && (attributeArray2.Length > 0)) && !string.IsNullOrEmpty(attributeArray2[0].Name))
                {
                    fieldName = attributeArray2[0].Name;
                }
                table.AddField(fieldName);
            }
            if (this.Log != null)
            {
                this.Log.WriteLine("SAPConnect.ReadTable:");
                this.Log.WriteLine(" => TableName = {0}", name);
                this.Log.WriteLine(" => RowSkip = {0}", this._skip);
                this.Log.WriteLine(" => RowCount = {0}", this._take);
                this.Log.WriteLine(" => WhereClause = {0}", str2);
                this.Log.WriteLine(" => OrderByClause = {0}", this._orderBy);
            }
            table.Run();
            DataTable result = table.Result;
            if (!string.IsNullOrEmpty(this._orderBy))
            {
                result.DefaultView.Sort = this._orderBy;
            }
            return result;
        }

        void table_eventMessage(string message)
        {
            this.Log.WriteLine("Time = {1} => Message = {0}", message, DateTime.Now.ToString());
        }

        private void BuildOrderBy(LambdaExpression le, bool desc)
        {
            MemberExpression body = le.Body as MemberExpression;
            MemberInfo member = body.Member;
            string fieldName = this.GetFieldName(member);
            if (string.IsNullOrEmpty(this._orderBy))
            {
                this._orderBy = string.Format("{0}{1}", fieldName, desc ? " DESC" : string.Empty);
            }
            else
            {
                this._orderBy = this._orderBy + string.Format(", {0}{1}", fieldName, desc ? " DESC" : string.Empty);
            }
        }

        private void BuildProjection(LambdaExpression le)
        {
            this._projection = le.Compile();
            this._originalType = le.Parameters[0].Type;
            foreach (PropertyInfo info in this._originalType.GetProperties())
            {
                this._properties.Add(info.Name);
            }
        }

        private void BuildQuery(LambdaExpression le)
        {
            StringBuilder sb = new StringBuilder();
            this.ParseQuery(le.Body, sb);
            if (string.IsNullOrEmpty(this._query))
            {
                this._query = sb.ToString();
            }
            else
            {
                this._query = this._query + " AND " + sb.ToString();
            }
        }

        public IQueryable CreateQuery(System.Linq.Expressions.Expression expression)
        {
            return this.CreateQuery<TEntity>(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(System.Linq.Expressions.Expression expression)
        {
            SAPTable<TElement> table = new SAPTable<TElement>(this.Connection, this.Log)
            {
                _query = this._query,
                _skip = this._skip,
                _take = this._take,
                _orderBy = this._orderBy,
                _projection = this._projection,
                _properties = this._properties,
                _originalType = this._originalType,
                _useMultibyteExtraction = this._useMultibyteExtraction,
                _SAPDataContext = this._SAPDataContext,
                _count = this._count,
                _first = this._first,
                _firstOrDefault = this._firstOrDefault,
                _last = this._last,
                _lastOrDefault = this._lastOrDefault
            };
            MethodCallExpression expression2 = expression as MethodCallExpression;
            if (expression2 == null)
            {
                throw new NotSupportedException(expression.ToString());
            }
            switch (expression2.Method.Name)
            {
                case "Where":
                    table.BuildQuery(((UnaryExpression)expression2.Arguments[1]).Operand as LambdaExpression);
                    return table;

                case "Select":
                    table.BuildProjection(((UnaryExpression)expression2.Arguments[1]).Operand as LambdaExpression);
                    return table;

                case "Take":
                    table._take = Convert.ToInt32(((ConstantExpression)expression2.Arguments[1]).Value);
                    return table;

                case "Skip":
                    table._skip = Convert.ToInt32(((ConstantExpression)expression2.Arguments[1]).Value);
                    return table;

                case "OrderBy":
                    table.BuildOrderBy(((UnaryExpression)expression2.Arguments[1]).Operand as LambdaExpression, false);
                    return table;

                case "OrderByDescending":
                    table.BuildOrderBy(((UnaryExpression)expression2.Arguments[1]).Operand as LambdaExpression, true);
                    return table;

                case "ThenBy":
                    table.BuildOrderBy(((UnaryExpression)expression2.Arguments[1]).Operand as LambdaExpression, false);
                    return table;

                case "ThenByDescending":
                    table.BuildOrderBy(((UnaryExpression)expression2.Arguments[1]).Operand as LambdaExpression, true);
                    return table;

                case "Count":
                    table._count = true;
                    return table;

                case "First":
                    table._first = true;
                    return table;

                case "FirstOrDefault":
                    table._firstOrDefault = true;
                    return table;

                case "Last":
                    table._last = true;
                    return table;

                case "LastOrDefault":
                    table._lastOrDefault = true;
                    return table;
            }
            throw new NotSupportedException("Unsupported method detected: " + expression2.Method.Name);
        }

        private void EndExecuteQuery()
        {
            if ((this._SAPDataContext != null) && this._SAPDataContext.AutoCloseConnection)
            {
                //  this.Connection.Close();
            }
        }

        public object Execute(System.Linq.Expressions.Expression expression)
        {
            throw new NotImplementedException();
        }

        public TResult Execute<TResult>(System.Linq.Expressions.Expression expression)
        {
            SAPTable<TResult> table = (SAPTable<TResult>)this.CreateQuery<TResult>(expression);
            if (table._count && (typeof(TResult) == typeof(int)))
            {
                return (TResult)table.GetResultsCount();
            }
            if (typeof(TResult) == typeof(TEntity))
            {
                return (TResult)table.GetResultsSingle();
            }
            if (typeof(TResult) != typeof(IEnumerable<TEntity>))
            {
                throw new NotSupportedException("The given expression cannot be evaluated and executed");
            }
            return (TResult)table.GetResults();
        }

        private string[] GetArrayValues(NewArrayExpression e)
        {
            List<string> list = new List<string>();
            if (e.Expressions.Count > 0)
            {
                foreach (System.Linq.Expressions.Expression expression in e.Expressions)
                {
                    if ((expression.NodeType != ExpressionType.Constant) || (expression.Type != typeof(string)))
                    {
                        throw new NotSupportedException("Unsupported array expression");
                    }
                    list.Add((expression as ConstantExpression).Value.ToString());
                }
            }
            return list.ToArray();
        }

        private string GetCondition(BinaryExpression e)
        {
            string fieldName;
            string str2;
            string str5;
            bool flag = false;
            string name = null;
            if ((e.Left is MemberExpression) && (((MemberExpression)e.Left).Member.DeclaringType == this._originalType))
            {
                fieldName = this.GetFieldName(((MemberExpression)e.Left).Member);
                str2 = System.Linq.Expressions.Expression.Lambda(e.Right, new ParameterExpression[0]).Compile().DynamicInvoke(new object[0]).ToString();
                name = e.Left.Type.Name;
            }
            else if ((e.Right is MemberExpression) && (((MemberExpression)e.Right).Member.DeclaringType == this._originalType))
            {
                flag = true;
                fieldName = this.GetFieldName(((MemberExpression)e.Right).Member);
                str2 = System.Linq.Expressions.Expression.Lambda(e.Left, new ParameterExpression[0]).Compile().DynamicInvoke(new object[0]).ToString();
                name = e.Right.Type.Name;
            }
            else
            {
                if (!(e.Left is MethodCallExpression))
                {
                    throw new NotSupportedException("A filtering expression should contain an entity member selection expression");
                }
                MethodCallExpression left = e.Left as MethodCallExpression;
                switch (left.Method.Name)
                {
                    case "CompareString":
                        if (!(left.Arguments[0] is MemberExpression))
                        {
                            throw new NotSupportedException("Unsupported string comparison arguments");
                        }
                        flag = false;
                        fieldName = this.GetFieldName((left.Arguments[0] as MemberExpression).Member);
                        str2 = System.Linq.Expressions.Expression.Lambda(left.Arguments[1], new ParameterExpression[0]).Compile().DynamicInvoke(new object[0]).ToString();
                        goto Label_025F;

                    case "ToSAPDate":
                        if (!(left.Arguments[0] is MemberExpression))
                        {
                            throw new NotSupportedException("Unsupported string comparison arguments");
                        }
                        flag = false;
                        fieldName = this.GetFieldName((left.Arguments[0] as MemberExpression).Member);
                        str2 = System.Linq.Expressions.Expression.Lambda(e.Right, new ParameterExpression[0]).Compile().DynamicInvoke(new object[0]).ToString();
                        goto Label_025F;

                }
                throw new NotSupportedException("Unsupported filtering method detected: " + left.Method.Name);
            }
        Label_025F:
            str2 = str2.ToString().Replace("'", "''");
            if (((str5 = name) != null) && (str5 == "Decimal"))
            {
                str2 = decimal.Parse(str2).ToString(CultureInfo.InvariantCulture.NumberFormat);
            }
            switch (e.NodeType)
            {
                case ExpressionType.Equal:
                    return string.Format("{0} = '{1}'", fieldName, str2);

                case ExpressionType.GreaterThan:
                    return string.Format(flag ? "{0} < '{1}'" : "{0} > '{1}'", fieldName, str2);

                case ExpressionType.GreaterThanOrEqual:
                    return string.Format(flag ? "{0} <= '{1}'" : "{0} >= '{1}'", fieldName, str2);

                case ExpressionType.LessThan:
                    return string.Format(flag ? "{0} > '{1}'" : "{0} < '{1}'", fieldName, str2);

                case ExpressionType.LessThanOrEqual:
                    return string.Format(flag ? "{0} >= '{1}'" : "{0} <= '{1}'", fieldName, str2);

                case ExpressionType.NotEqual:
                    return string.Format("{0} <> '{1}'", fieldName, str2);
            }
            throw new NotSupportedException("Unsupported filtering operator detected: " + e.NodeType);
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return this.GetResults();
        }

        private string GetFieldName(MemberInfo mi)
        {
            SAPColumnAttribute[] customAttributes = mi.GetCustomAttributes(typeof(SAPColumnAttribute), false) as SAPColumnAttribute[];
            if ((customAttributes != null) && (customAttributes.Length != 0))
            {
                return customAttributes[0].Name;
            }
            return mi.Name;
        }

        public IList GetList()
        {
            List<TEntity> list = new List<TEntity>();
            IEnumerator<TEntity> results = this.GetResults();
            if (results != null)
            {
                while (results.MoveNext())
                {
                    list.Add(results.Current);
                }
            }
            return list;
        }

        private IEnumerator<TEntity> GetResults()
        {
            DataTable iteratorVariable0 = this.BeginExecuteQuery();
            if (iteratorVariable0 == null)
            {
                this.EndExecuteQuery();
                //goto Label_01D1;
            }
            IEnumerator enumerator = iteratorVariable0.DefaultView.GetEnumerator();
            //Label_PostSwitchInIterator:;
            while (enumerator.MoveNext())
            {
                DataRowView current = (DataRowView)enumerator.Current;
                object result = Activator.CreateInstance((this._projection == null) ? typeof(TEntity) : this._originalType);
                if (this._projection == null)
                {
                    foreach (PropertyInfo info in typeof(TEntity).GetProperties())
                    {
                        this.AssignResultProperty(current, result, info.Name);
                    }
                    yield return (TEntity)result;
                }
                else
                {
                    foreach (string str in this._properties)
                    {
                        this.AssignResultProperty(current, result, str);
                    }
                    yield return (TEntity)this._projection.DynamicInvoke(new object[] { result });
                }
                //goto Label_PostSwitchInIterator;
            }
            //Label_01D1:
            //    this.EndExecuteQuery();
        }

        private object GetResultsCount()
        {
            DataTable table = this.BeginExecuteQuery();
            if (table == null)
            {
                return -1;
            }
            int count = table.Rows.Count;
            this.EndExecuteQuery();
            return count;
        }

        private object GetResultsSingle()
        {
            DataTable table = this.BeginExecuteQuery();
            if (table == null)
            {
                return null;
            }
            int count = table.Rows.Count;
            DataRowView dr = null;
            if (this._first || this._firstOrDefault)
            {
                if (count == 0)
                {
                    if (this._first)
                    {
                        throw new OperationCanceledException("No first record available");
                    }
                    return null;
                }
                dr = table.DefaultView[0];
            }
            else if (this._last || this._lastOrDefault)
            {
                if (count == 0)
                {
                    if (this._last)
                    {
                        throw new OperationCanceledException("No last record available");
                    }
                    return null;
                }
                dr = table.DefaultView[count - 1];
            }
            this.EndExecuteQuery();
            if (dr == null)
            {
                throw new NotSupportedException("The given expression cannot be evaluated and executed to a single entity object");
            }
            object result = Activator.CreateInstance((this._projection == null) ? typeof(TEntity) : this._originalType);
            if (this._projection == null)
            {
                foreach (PropertyInfo info in typeof(TEntity).GetProperties())
                {
                    this.AssignResultProperty(dr, result, info.Name);
                }
                return (TEntity)result;
            }
            foreach (string str in this._properties)
            {
                this.AssignResultProperty(dr, result, str);
            }
            return (TEntity)this._projection.DynamicInvoke(new object[] { result });
        }

        private void ParseQuery(System.Linq.Expressions.Expression e, StringBuilder sb)
        {
            MethodCallExpression expression3;
            sb.Append("( ");
            if (e is BinaryExpression)
            {
                BinaryExpression expression = e as BinaryExpression;
                switch (expression.NodeType)
                {
                    case ExpressionType.And:
                    case ExpressionType.AndAlso:
                        this.ParseQuery(expression.Left, sb);
                        sb.Append(" AND ");
                        this.ParseQuery(expression.Right, sb);
                        goto Label_044F;

                    case ExpressionType.Or:
                    case ExpressionType.OrElse:
                        this.ParseQuery(expression.Left, sb);
                        sb.Append(" OR ");
                        this.ParseQuery(expression.Right, sb);
                        goto Label_044F;
                }
                sb.Append(this.GetCondition(expression));
            }
            else if (e is UnaryExpression)
            {
                UnaryExpression expression2 = e as UnaryExpression;
                if (expression2.NodeType != ExpressionType.Not)
                {
                    throw new NotSupportedException("Unsupported query operator detected: " + expression2.NodeType);
                }
                sb.Append(" NOT ");
                this.ParseQuery(expression2.Operand, sb);
            }
            else
            {
                if (!(e is MethodCallExpression))
                {
                    throw new NotSupportedException("Unsupported query expression detected");
                }
                expression3 = e as MethodCallExpression;
                MemberExpression expression4 = expression3.Object as MemberExpression;
                if (!(expression3.Method.DeclaringType == typeof(string)))
                {
                    string[] arrayValues;
                    string str6;
                    if (!(expression3.Method.DeclaringType == typeof(SAPExtensions)))
                    {
                        throw new NotSupportedException("Unsupported query expression detected");
                    }
                    if (((str6 = expression3.Method.Name) == null) || !(str6 == "InList"))
                    {
                        throw new NotSupportedException("Unsupported filtering method detected: " + expression3.Method.Name);
                    }
                    expression4 = expression3.Arguments[0] as MemberExpression;
                    if (expression4 == null)
                    {
                        throw new NotSupportedException("Unsupported filtering expression detected");
                    }
                    if (expression3.Arguments[1] is NewArrayExpression)
                    {
                        arrayValues = this.GetArrayValues(expression3.Arguments[1] as NewArrayExpression);
                    }
                    else
                    {
                        arrayValues = (string[])System.Linq.Expressions.Expression.Lambda(expression3.Arguments[1], new ParameterExpression[0]).Compile().DynamicInvoke(new object[0]);
                    }
                    if (arrayValues.Length <= 0)
                    {
                        throw new Exception("Method InList requires at least one argument");
                    }
                    sb.Append(this.GetFieldName(expression4.Member)).Append(" IN (");
                    for (int i = 0; i < arrayValues.Length; i++)
                    {
                        sb.AppendFormat("'{0}'", arrayValues[i]);
                        if (i < (arrayValues.Length - 1))
                        {
                            sb.Append(", ");
                        }
                    }
                    sb.Append(")");
                }
                else
                {
                    string name = expression3.Method.Name;
                    if (name == null)
                    {
                        goto Label_02CD;
                    }
                    if (!(name == "Equals"))
                    {
                        if (name == "Contains")
                        {
                            string str2 = System.Linq.Expressions.Expression.Lambda(expression3.Arguments[0], new ParameterExpression[0]).Compile().DynamicInvoke(new object[0]).ToString();
                            sb.AppendFormat("{0} LIKE '%{1}%'", this.GetFieldName(expression4.Member), str2);
                            goto Label_044F;
                        }
                        if (name == "StartsWith")
                        {
                            string str3 = System.Linq.Expressions.Expression.Lambda(expression3.Arguments[0], new ParameterExpression[0]).Compile().DynamicInvoke(new object[0]).ToString();
                            sb.AppendFormat("{0} LIKE '{1}%'", this.GetFieldName(expression4.Member), str3);
                            goto Label_044F;
                        }
                        if (name == "EndsWith")
                        {
                            string str4 = System.Linq.Expressions.Expression.Lambda(expression3.Arguments[0], new ParameterExpression[0]).Compile().DynamicInvoke(new object[0]).ToString();
                            sb.AppendFormat("{0} LIKE '%{1}'", this.GetFieldName(expression4.Member), str4);
                            goto Label_044F;
                        }
                        //goto Label_02CD;
                        throw new NotSupportedException("Unsupported string filtering method detected: " + expression3.Method.Name);
                    }
                    string str = System.Linq.Expressions.Expression.Lambda(expression3.Arguments[0], new ParameterExpression[0]).Compile().DynamicInvoke(new object[0]).ToString();
                    sb.AppendFormat("{0} = '{1}'", this.GetFieldName(expression4.Member), str);
                }
            }
        //      goto Label_044F;
        Label_02CD:
        //     throw new NotSupportedException("Unsupported string filtering method detected: " + expression3.Method.Name);
        Label_044F:
            sb.Append(" )");
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        //public String Connection
        //{
        //  //  [CompilerGenerated]
        //    get
        //    {
        //        // return this.<Connection>k__BackingField;
        //        return this.Connection;
        //    }
        //   // [CompilerGenerated]
        //     set
        //    {
        //        this.Connection = value;
        //        // this.<Connection>k__BackingField = value;
        //    }
        //}

        public bool ContainsListCollection
        {
            get
            {
                return true;
            }
        }

        public Type ElementType
        {
            get
            {
                return typeof(TEntity);
            }
        }

        public System.Linq.Expressions.Expression Expression
        {
            get
            {
                return System.Linq.Expressions.Expression.Constant(this);
            }
        }

        //public TextWriter Log
        //{
        //   // [CompilerGenerated]
        //    get
        //    {
        //        return this.Log;
        //    }
        //  //  [CompilerGenerated]
        //    set
        //    {
        //        this.Log = value;
        //    }
        //}

        IQueryProvider IQueryable.Provider
        {
            get
            {
                return this;
            }
        }

        //        [CompilerGenerated]
        //        private sealed class <GetResults>d__0 : IEnumerator<TEntity>, IEnumerator, IDisposable
        //        {
        //            private int <>1__state;
        //            private TEntity <>2__current;
        //            public SAPTable<TEntity> <>4__this;
        //            public IEnumerator <>7__wrap4;
        //            public IDisposable <>7__wrap5;
        //            public DataRowView <dr>5__2;
        //            public DataTable <dt>5__1;
        //            public object <result>5__3;

        //            [DebuggerHidden]
        //            public <GetResults>d__0(int <>1__state)
        //            {
        //                this.<>1__state = <>1__state;
        //            }

        //            private void <>m__Finally6()
        //            {
        //                this.<>1__state = -1;
        //                this.<>7__wrap5 = this.<>7__wrap4 as IDisposable;
        //                if (this.<>7__wrap5 != null)
        //                {
        //                    this.<>7__wrap5.Dispose();
        //                }
        //            }

        //            private bool MoveNext()
        //            {
        //                bool flag;
        //                try
        //                {
        //                    switch (this.<>1__state)
        //                    {
        //                        case 3:
        //                            this.<>1__state = 1;
        //                            break;

        //                        case 5:
        //                            this.<>1__state = 1;
        //                            break;

        //                        case 0:
        //                            this.<>1__state = -1;
        //                            this.<dt>5__1 = this.<>4__this.BeginExecuteQuery();
        //                            if (this.<dt>5__1 == null)
        //                            {
        //                                goto Label_01D1;
        //                            }
        //                            this.<>7__wrap4 = this.<dt>5__1.DefaultView.GetEnumerator();
        //                            this.<>1__state = 1;
        //                            break;

        //                        default:
        //                            goto Label_01DC;
        //                    }
        //                    while (this.<>7__wrap4.MoveNext())
        //                    {
        //                        this.<dr>5__2 = (DataRowView) this.<>7__wrap4.Current;
        //                        this.<result>5__3 = Activator.CreateInstance((this.<>4__this._projection == null) ? typeof(TEntity) : this.<>4__this._originalType);
        //                        if (this.<>4__this._projection == null)
        //                        {
        //                            foreach (PropertyInfo info in typeof(TEntity).GetProperties())
        //                            {
        //                                this.<>4__this.AssignResultProperty(this.<dr>5__2, this.<result>5__3, info.Name);
        //                            }
        //                            this.<>2__current = (TEntity) this.<result>5__3;
        //                            this.<>1__state = 3;
        //                            return true;
        //                        }
        //                        foreach (string str in this.<>4__this._properties)
        //                        {
        //                            this.<>4__this.AssignResultProperty(this.<dr>5__2, this.<result>5__3, str);
        //                        }
        //                        this.<>2__current = (TEntity) this.<>4__this._projection.DynamicInvoke(new object[] { this.<result>5__3 });
        //                        this.<>1__state = 5;
        //                        return true;
        //                    }
        //                    this.<>m__Finally6();
        //                Label_01D1:
        //                    this.<>4__this.EndExecuteQuery();
        //                Label_01DC:
        //                    flag = false;
        //                }
        //                fault
        //                {
        //                    this.System.IDisposable.Dispose();
        //                }
        //                return flag;
        //            }

        //            [DebuggerHidden]
        //            void IEnumerator.Reset()
        //            {
        //                throw new NotSupportedException();
        //            }

        //            void IDisposable.Dispose()
        //            {
        //                switch (this.<>1__state)
        //                {
        //                    case 1:
        //                    case 3:
        //                    case 5:
        //                        try
        //                        {
        //                        }
        //                        finally
        //                        {
        //                            this.<>m__Finally6();
        //                        }
        //                        break;

        //                    case 2:
        //                    case 4:
        //                        break;

        //                    default:
        //                        return;
        //                }
        //            }

        //            TEntity IEnumerator<TEntity>.Current
        //            {
        //                [DebuggerHidden]
        //                get
        //                {
        //                   // return this.<>2__current;
        //return this;
        //                }
        //            }

        //            object IEnumerator.Current
        //            {
        //                [DebuggerHidden]
        //                get
        //                {
        //                   // return this.<>2__current;
        //return this;
        //}
    }
}
//    }
//}

