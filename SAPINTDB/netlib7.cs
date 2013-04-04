using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using ConfigFileTool;

namespace SAPINTDB
{
    /// <summary>
    /// Netlib class
    /// </summary>
    public class netlib7
    {
        #region Constructors

        /// <summary>
        /// Standard constructor
        /// </summary>
        public netlib7()
        {
        }
        /// <summary>
        /// Advanced constructor (based on configuration file)
        /// </summary>
        /// <param name="configConnectionName">the connection string section</param>
        public netlib7(string configConnectionName)
        {
         //   providerName = SAPGlobalSettings.config.ConnectionStrings[configConnectionName].ProviderName;
         //   connectionString = SAPGlobalSettings.config.ConnectionStrings[configConnectionName].ConnectionString;
            if (new SAPGlobalSettings().getConnectionStrings()[configConnectionName] == null)
            {
                errorMessage = String.Format("Can't find the connection {0}",configConnectionName);
                throw new Exception(errorMessage);
            }
            else
            {
                providerName = new SAPGlobalSettings().getConnectionStrings()[configConnectionName].ProviderName;
                connectionString = new SAPGlobalSettings().getConnectionStrings()[configConnectionName].ConnectionString;
            }
            
        }
        /// <summary>
        /// Advanced constructor (provider and connection string must be specified)
        /// </summary>
        /// <param name="ProviderName">Assembly name (e.g. System.Data.OracleClient)</param>
        /// <param name="ConnectionString">The connection string for the specified provider</param>
        public netlib7(string ProviderName, string ConnectionString)
        {
            providerName = ProviderName;
            connectionString = ConnectionString;
        }

        #endregion

        #region Properties

        // errorMessage
        string errorMessage;
        /// <summary>
        /// Get the last error message
        /// </summary>
        public string ErrorMessage
        {
            get { return errorMessage; }
        }

        // ProviderType
        /// <summary>
        /// Get the provider type
        /// </summary>
        public ProviderTypes ProviderType
        {
            get
            {
                if (String.Compare(ProviderName, "System.Data.OleDb", true) == 0)
                {
                    if (ConnectionString.IndexOf("MSDAORA", StringComparison.OrdinalIgnoreCase) >= 0)
                        return ProviderTypes.Oracle;
                    else if (ConnectionString.IndexOf("Jet.OleDb", StringComparison.OrdinalIgnoreCase) >= 0)
                        return ProviderTypes.MsAccess;
                    else
                        return ProviderTypes.OleDB;
                }
                else if (String.Compare(ProviderName, "System.Data.SqlClient", true) == 0)
                    return ProviderTypes.SqlServer;
                else if (String.Compare(ProviderName, "System.Data.OracleClient", true) == 0)
                    return ProviderTypes.Oracle;
                else if (String.Compare(ProviderName, "MySql.Data.MySqlClient", true) == 0)
                    return ProviderTypes.MySql;
                else if (String.Compare(ProviderName, "Devart.Data.PostgreSql", true) == 0)
                    return ProviderTypes.PostgreSQL;
                else if (String.Compare(ProviderName, "System.Data.SQLite", true) == 0)
                    return ProviderTypes.SQLite;
                else
                    return ProviderTypes.Unknown;
            }
        }

        // ProviderParam
        /// <summary>
        /// Get the symbol to be used for parameter with the specified provider
        /// </summary>
        public string ProviderParam
        {
            get
            {
                if (ProviderType == ProviderTypes.MsAccess || ProviderType == ProviderTypes.SqlServer || ProviderType == ProviderTypes.MySql)
                    return "@";
                else
                    return ":";
            }
        }

        // providerName (STATIC)
        static string providerName = "";
        /// <summary>
        /// Get or set the provider name
        /// </summary>
        public string ProviderName
        {
            get { return providerName; }
            set { providerName = value; }
        }

        // connectionString (STATIC)
        static string connectionString = "";
        /// <summary>
        /// Get or set the connection string for the specified provider
        /// </summary>
        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        // counterTable (STATIC)
        static string counterTable = "counterTable(key, value)";
        /// <summary>
        /// Get or set the definition of the counter table
        /// <para>default=counterTable(key, value)</para>
        /// </summary>
        public string CounterTable
        {
            get { return counterTable; }
            set { counterTable = value; }
        }

        // trace the events (STATIC)
        static bool logEvents = false;
        /// <summary>
        /// Get or set how to log events and errors
        /// <para>If true the events will be written into the event-table (or into the file if the table does not exists).</para>
        /// <para>If false the last event still remain only into errorMessage property.</para>
        /// </summary>
        public bool LogEvents
        {
            get { return logEvents; }
            set { logEvents = value; }
        }

        // logTableName (STATIC)
        static string logTable = "eventLog(eventType, eventDate, eventText, winUser)";
        /// <summary>
        /// Get or set the definition of the table for logging 
        /// <para>default=eventLog(eventType, eventDate, eventText, winUser)</para>
        /// </summary>
        public string LogTable
        {
            get { return logTable; }
            set { logTable = value; }
        }

        // folder for output files (STATIC)
        static string outputFolder = AppDomain.CurrentDomain.BaseDirectory;
        /// <summary>
        /// Get or set the folder for output files (such as event file).
        /// If empty, application folder will be used instead.
        /// </summary>
        public string OutputFolder
        {
            get { return outputFolder; }
            set
            {
                outputFolder = value;
                if (!outputFolder.EndsWith("\\"))
                    outputFolder += "\\";
            }
        }

        // default time-out for commands (STATIC)
        static int timeOut = 300;
        /// <summary>
        /// Get or set the timeout for connection and commands (default is 300 seconds)
        /// </summary>
        public int TimeOut
        {
            get { return timeOut; }
            set { timeOut = value; }
        }

        bool cancel;
        /// <summary>
        /// Set to true to abort a netlib process such as DataTableToHtml process
        /// </summary>
        public bool Cancel
        {
            set { cancel = value; }
        }

        #endregion

        #region Enumerators

        /// <summary>
        /// The type of string to filter
        /// </summary>
        public enum StringType
        {
            /// <summary>
            /// ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz
            /// </summary>
            Chars = 1,
            /// <summary>
            /// 0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz
            /// </summary>
            CharsAndNumbers,
            /// <summary>
            /// 0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz 
            /// </summary>
            CharsAndNumbersAndSpaces,
            /// <summary>
            /// ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz (+spaces and symbols)
            /// </summary>
            CharsAndSymbols,
            /// <summary>
            /// 0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz (+spaces and symbols)
            /// </summary>
            CharsAndNumbersAndSymbols,
            /// <summary>
            /// 0123456789
            /// </summary>
            Numbers,
            /// <summary>
            /// 0123456789+-
            /// </summary>
            NumbersWithSigns,
            /// <summary>
            /// 0123456789,.+-
            /// </summary>
            NumbersWithSignsAndPunctuation,
            /// <summary>
            /// 0123456789/-:.
            /// </summary>
            DateOrTime
        }

        /// <summary>
        /// Type of provider in use
        /// </summary>
        public enum ProviderTypes
        {
            /// <summary>
            /// Oracle
            /// </summary>
            Oracle = 1,
            /// <summary>
            /// SqlServer
            /// </summary>
            SqlServer = 2,
            /// <summary>
            /// Microsoft Access
            /// </summary>
            MsAccess = 3,
            /// <summary>
            /// MySql
            /// </summary>
            MySql = 4,
            /// <summary>
            /// PostgreSQL
            /// </summary>
            PostgreSQL = 5,
            /// <summary>
            /// Generic Ole DB
            /// </summary>
            OleDB = 8,

            SQLite = 9,
            /// <summary>
            /// Unknown
            /// </summary>
            Unknown = 10
        }

        #endregion

        #region Database commands & utilities

        /// <summary>
        /// Create a new connection (based on netlib properties) 
        /// </summary>
        /// <returns></returns>
        public DbConnection CreateConnection()
        {
            return CreateConnection(providerName, connectionString);
        }
        /// <summary>
        /// Create a new connection for the given Provider and ConnectionString
        /// </summary>
        /// <param name="providerName">The provider name (e.g. System.Data.SqlClient)</param>
        /// <param name="connectionString">The connection string for the specified provider</param>
        /// <returns></returns>
        public DbConnection CreateConnection(string providerName, string connectionString)
        {
            DbProviderFactory pf = DbProviderFactories.GetFactory(providerName);

            DbConnection cn = pf.CreateConnection();
            cn.ConnectionString = connectionString;

            return cn;
        }

        /// <summary>
        /// Create a new command
        /// </summary>
        public DbCommand CreateCommand()
        {
            DbConnection cn = CreateConnection();
            return CreateCommand(cn, "");
        }
        /// <summary>
        /// Create a new command with a new connection for the specified sql text
        /// </summary>
        public DbCommand CreateCommand(string sqlCommandText)
        {
            DbConnection cn = CreateConnection();
            return CreateCommand(cn, sqlCommandText);
        }
        /// <summary>
        /// Create a new command for the specified connection
        /// </summary>
        public DbCommand CreateCommand(DbConnection connectionObject)
        {
            return CreateCommand(connectionObject, "");
        }
        /// <summary>
        /// Create a new command for the specified connection and command text
        /// </summary>
        public DbCommand CreateCommand(DbConnection connectionObject, string sqlCommandText)
        {
            DbCommand cm = connectionObject.CreateCommand();
            cm.CommandTimeout = timeOut;
            if (sqlCommandText != "")
            {
                cm.CommandText = sqlCommandText;
                cm.CommandType = CommandType.Text;
            }

            return cm;
        }

        /// <summary>
        /// Create a CommandBuilder for the specified DataAdapter
        /// </summary>
        public DbCommandBuilder CreateCommandBuilder(DbDataAdapter dataAdapterObject)
        {
            DbProviderFactory pf = DbProviderFactories.GetFactory(providerName);
            DbCommandBuilder cb = pf.CreateCommandBuilder();
            cb.DataAdapter = dataAdapterObject;

            return cb;
        }

        /// <summary>
        /// Create a new DataAdapter
        /// </summary>
        public DbDataAdapter CreateDataAdapter()
        {
            DbProviderFactory pf = DbProviderFactories.GetFactory(providerName);
            return pf.CreateDataAdapter();
        }
        /// <summary>
        /// Create a new DataAdapter on the specified command
        /// </summary>
        public DbDataAdapter CreateDataAdapter(DbCommand cm)
        {
            DbProviderFactory pf = DbProviderFactories.GetFactory(providerName);

            DbDataAdapter da = pf.CreateDataAdapter();
            da.SelectCommand = cm;

            return da;
        }
        /// <summary>
        /// Create a new DataAdapter for the specified provider
        /// </summary>
        public DbDataAdapter CreateDataAdapter(string ProviderName)
        {
            DbProviderFactory pf = DbProviderFactories.GetFactory(ProviderName);
            return pf.CreateDataAdapter();
        }

        /// <summary>
        /// Create a DataReader for the specified query. 
        /// <para>Please note that the associated connection is automatically closed when then datareader is closed.</para>
        /// </summary>
        public DbDataReader CreateDataReader(string sqlCommandText)
        {
            DbCommand cm = CreateCommand(sqlCommandText);
            return CreateDataReader(cm);
        }
        /// <summary>
        /// Create a DataReader for the specified command.  
        /// <para>Please note that the associated connection is automatically closed when then datareader is closed.</para>
        /// </summary>
        public DbDataReader CreateDataReader(DbCommand cm)
        {
            DbConnection cn = cm.Connection;
            DbDataReader rd = null;

            errorMessage = "";
            try
            {
                if (cn.State != ConnectionState.Open)
                    cn.Open();
                rd = cm.ExecuteReader(CommandBehavior.CloseConnection);
                return rd;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                if (logEvents)
                    LogEvent("ERROR", cm.CommandText + "\r\n/\r\n" + ex.ToString());
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                return null;
            }
        }

        /// <summary>
        /// Create a new parameter for the specified provider
        /// </summary>
        public DbParameter CreateParameter()
        {
            DbProviderFactory pf = DbProviderFactories.GetFactory(providerName);
            return pf.CreateParameter();
        }
        /// <summary>
        /// Create a new parameter for the specified provider
        /// </summary>
        public DbParameter CreateParameter(string paramName, object paramValue)
        {
            DbProviderFactory pf = DbProviderFactories.GetFactory(providerName);
            DbParameter cm = pf.CreateParameter();
            cm.ParameterName = paramName;
            cm.Value = paramValue;
            return cm;
        }
        /// <summary>
        /// Create a new parameter for the specified command and adding it
        /// </summary>
        public DbParameter CreateParameter(DbCommand cm, string paramName, object paramValue)
        {
            DbParameter p = cm.CreateParameter();
            p.ParameterName = paramName;
            p.Value = paramValue;
            cm.Parameters.Add(p);

            return p;
        }
        /// <summary>
        /// Create a new parameter for the specified command and adding it
        /// </summary>
        public DbParameter CreateParameter(DbCommand cm, string paramName, DbType paramType, object paramValue)
        {
            DbParameter p = cm.CreateParameter();
            p.ParameterName = paramName;
            p.DbType = paramType;
            p.Value = paramValue;
            cm.Parameters.Add(p);

            return p;
        }

        /// <summary>
        /// Execute a non-query command (such as INSERT or CREATE TABLE)
        /// </summary>
        public int ExecNonQuery(string sqlCommandText)
        {
            return ExecNonQuery(sqlCommandText, null);
        }
        /// <summary>
        /// Execute a non-query command (such as INSERT or CREATE TABLE)
        /// </summary>
        public int ExecNonQuery(string sqlCommandText, DbParameter[] parameters)
        {
            DbConnection cn = CreateConnection();
            DbCommand cm = CreateCommand(cn, sqlCommandText);

            if (parameters != null)
                cm.Parameters.AddRange(parameters);

            errorMessage = "";
            int r;
            try
            {
                cn.Open();
                r = cm.ExecuteNonQuery();
                if (r < 0) r = 0;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                if (logEvents)
                    LogEvent("ERROR", sqlCommandText + "\r\n/\r\n" + ex.ToString());
                r = -1;
            }
            finally
            {
                cn.Close();
            }
            return r;
        }

        /// <summary>
        /// Execute a scalar query and return a string
        /// </summary>
        public string ExecScalars(string sqlCommandText)
        {
            return nvl(ExecScalar(sqlCommandText, null));
        }
        /// <summary>
        /// Execute a scalar query and return an object
        /// </summary>
        public object ExecScalar(string sqlCommandText)
        {
            return ExecScalar(sqlCommandText, null);
        }
        /// <summary>
        /// Execute a scalar query and return an object
        /// </summary>
        public object ExecScalar(string sqlCommandText, DbParameter[] parameters)
        {
            DbConnection cn = CreateConnection();
            DbCommand cm = CreateCommand(cn, sqlCommandText);

            if (parameters != null)
                cm.Parameters.AddRange(parameters);

            errorMessage = "";
            try
            {
                cn.Open();
                return cm.ExecuteScalar();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                if (logEvents)
                    LogEvent("ERROR", sqlCommandText + "\r\n/\r\n" + ex.ToString());
                return null;
            }
            finally
            {
                cn.Close();
            }
        }

        /// <summary>
        /// Fill a datatable based on the specified query
        /// </summary>
        /// <param name="sqlCommandText"></param>
        /// <returns></returns>
        public DataTable DataTableFill(string sqlCommandText)
        {
            DataTable dt = new DataTable();
            DataTableFill(dt, sqlCommandText);
            return dt;
        }
        /// <summary>
        /// Fill a datatable based on the specified query
        /// </summary>
        public bool DataTableFill(DataTable dt, string sqlCommandText)
        {
            
            return DataTableFill(dt, sqlCommandText, null, false);
        }
        /// <summary>
        /// Fill a datatable based on the specified query
        /// </summary>
        public bool DataTableFill(DataTable dt, string sqlCommandText, DbParameter[] parameters, bool AddPrimaryKeyInfo)
        {
            DbConnection cn = CreateConnection();
            DbCommand cm = CreateCommand(cn, sqlCommandText);
            DbDataAdapter da = CreateDataAdapter(cm);

            if (parameters != null)
                cm.Parameters.AddRange(parameters);

            errorMessage = "";
            try
            {
                cn.Open();
                if (AddPrimaryKeyInfo)
                    da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                if (logEvents)
                    LogEvent("ERROR", sqlCommandText + "\r\n/\r\n" + ex.ToString());
                return false;
            }
            finally
            {
                cn.Close();
            }
            return true;
        }

        /// <summary>
        /// Find a row in the data table and return the position index
        /// </summary>
        /// <param name="dt">The datatable</param>
        /// <param name="fieldName">The field name</param>
        /// <param name="fieldValue">The value to search</param>
        /// <param name="startRow">The row of the datatable from which the search starts</param>
        /// <returns></returns>
        public int DataTableFindRow(DataTable dt, string fieldName, string fieldValue, int startRow)
        {
            if (startRow >= dt.Rows.Count)
                return -1;

            int i;
            for (i = startRow; i < dt.Rows.Count; i++)
            {
                if (Convert.ToString(dt.Rows[i][fieldName]) == fieldValue)
                    break;
            }
            if (i == dt.Rows.Count) i = -1;
            return i;
        }
        /// <summary>
        /// Find a row in the data table and return the position index
        /// </summary>
        /// <param name="dt">The datatable</param>
        /// <param name="fieldsName">The array of fields name</param>
        /// <param name="fieldsValue">The array of values to search</param>
        /// <param name="startRow">The row of the datatable from which the search starts</param>
        /// <returns></returns>
        public int DataTableFindRow(DataTable dt, string[] fieldsName, string[] fieldsValue, int startRow)
        {
            if (startRow >= dt.Rows.Count)
                return -1;

            int i, j;
            bool found = false;
            for (i = startRow; i < dt.Rows.Count; i++)
            {
                found = true;
                for (j = 0; j < fieldsName.GetLength(0); j++)
                {
                    if (Convert.ToString(dt.Rows[i][fieldsName[j]]) != fieldsValue[j])
                    {
                        found = false;
                        break;
                    }
                }
                if (found) return i;
            }
            return -1;
        }

        /// <summary>
        /// Export a DataTable content into an HTML format
        /// </summary>
        /// <param name="dt">The DataTable to export</param>
        /// <param name="Head1">The title and H1 tag content</param>
        /// <param name="Head2">The H2 tag content</param>
        /// <param name="ColumnsName">Columns name list delimited by semicolon</param>
        /// <param name="ColumnsWidth">Columns percent width delimited by semicolon 
        ///                      <para>- specify zero to hide the column</para>
        ///                      <para>- if the first char is an asterisk then the field will be right formatted</para>
        ///                      <para>- you can specify also the format string (see String.Format function)</para>
        ///                      <para>Example: 10{0:dd/mm/yyyy};20;15;5{0:N};*7{0:N};*10{0:######}</para>
        /// </param>
        /// <param name="ColumnsToGroupBy">Group by list (delimited by semicolon and start with zero)</param>
        /// <param name="ColumnsToSum">The columns to calculate totals (delimited by semicolon and start with zero).</param>
        /// <param name="TruncateLargeColumnHeader">Set true to automatically truncate large column header</param>
        /// <param name="OpenBrowser">Set true to automatically open default browser</param>
        /// <returns>The builded file name</returns>
        public string DataTableToHtml(DataTable dt, string Head1, string Head2, string ColumnsName, string ColumnsWidth, string ColumnsToGroupBy, string ColumnsToSum, bool TruncateLargeColumnHeader, bool OpenBrowser)
        {
            if (dt == null || dt.Rows.Count == 0) return "";

            bool doHead;
            int i, j, k;
            string groupHeaderText = "";
            DataRow rw = dt.Rows[0];

            cancel = false;
            if (ColumnsName == "")
            {
                for (i = 0; i < dt.Columns.Count; i++)
                    ColumnsName += dt.Columns[i].ColumnName + ";";
                ColumnsName = RTrunc(ColumnsName, 1);
            }
            string[] columnName = ColumnsName.Split(';');
            if (ColumnsWidth == "")
            {
                int x = 100 / dt.Columns.Count;
                for (i = 0; i < dt.Columns.Count; i++)
                    ColumnsWidth += x.ToString() + ";";
                ColumnsWidth = RTrunc(ColumnsWidth, 1);
            }
            string[] columnWidth = ColumnsWidth.Split(';');
            string[] columnToGroupBy = new string[0];
            double[] sumValues = new double[dt.Columns.Count];
            double[] totValues = new double[dt.Columns.Count];
            for (i = 0; i < dt.Columns.Count; i++)
                totValues[i] = 0;

            string[] cAlign = new string[columnWidth.Length];
            string[] cWidth = new string[columnWidth.Length];
            string[] cFormat = new string[columnWidth.Length];
            for (i = 0; i < columnWidth.Length; i++)
                getColInfo(columnWidth[i], out cAlign[i], out cWidth[i], out cFormat[i]);

            int totalWidth = 0;
            for (i = 0; i < columnWidth.Length; i++)
                totalWidth += Convert.ToInt32(cWidth[i]);
            if (totalWidth > 100)
                totalWidth = 100;

            if (ColumnsToGroupBy != "")
                columnToGroupBy = ColumnsToGroupBy.Split(';');

            string html;
            html = "<html>\n";

            html += "<style>\n";
            html += "H1 { font-family:Tahoma,Arial,Sans-Serif; font-size:12pt; font-weight:bold; text-align:center; }\n";
            html += "H2 { font-family:Tahoma,Arial,Sans-Serif; font-size:10pt; font-weight:bold; text-align:center; font-variant:small-caps; }\n";
            html += "H3 { font-family:Tahoma,Arial,Sans-Serif; font-size:8pt;  font-weight:bold; text-align:left; }\n";
            html += "BODY, TD, TH { font-family : Tahoma, Arial, Sans-Serif; font-size : 8pt; }\n";
            html += "</style>";

            html += "<head><meta http-equiv=\"content-type\" content=\"text/html; charset=UTF-8\"><title>" + Head1 + "</title></head>\n";
            html += "<body>\n";
            html += "<h1>" + Head1 + "</h1>\n";
            html += "<h2>" + Head2 + "</h2>\n";

            for (i = 0; i < dt.Rows.Count; i++)
            {
                doHead = false;
                for (j = 0; j < columnToGroupBy.Length; j++)
                {
                    k = Convert.ToInt32(columnToGroupBy[j]);
                    if (rw[k].ToString() != dt.Rows[i][k].ToString())
                    {
                        doHead = true;
                        rw = dt.Rows[i];
                        break;
                    }
                }

                if (i == 0 || doHead)
                {
                    groupHeaderText = "";
                    for (j = 0; j < columnToGroupBy.Length; j++)
                    {
                        k = Convert.ToInt32(columnToGroupBy[j]);
                        groupHeaderText += columnName[k] + " " + dt.Rows[i][k].ToString() + " - ";
                    }
                    groupHeaderText = RTrunc(groupHeaderText, 3);

                    if (i > 0)
                    {
                        // totals
                        html += "<tr>\n";
                        for (j = 0; j < dt.Columns.Count; j++)
                        {
                            if (cWidth[j] != "0" && IsIn(j.ToString(), ColumnsToSum, ';'))
                            {
                                html += "<td style=\"border-top:solid;\" align=" + cAlign[j] + " width=" + cWidth[j] + "%>" + String.Format(cFormat[j], sumValues[j]) + "</td>\n";
                                totValues[j] += sumValues[j];
                            }
                            else if (cWidth[j] != "0")
                                html += "<td width=" + cWidth[j] + "%></td>\n";
                        }
                        html += "</tr>\n";
                        html += "</table><br><br><br>\n";
                    }
                    if (groupHeaderText != "")
                        html += "<h3>" + groupHeaderText + "</h3>\n";

                    // rows heading
                    html += "<table width=" + totalWidth + "% align=center border=0>\n";
                    for (j = 0; j < dt.Columns.Count; j++)
                    {
                        if (cWidth[j] != "0")
                        {
                            html += "<th align=" + cAlign[j] + " valign=bottom width=" + cWidth[j] + "%>";
                            if (TruncateLargeColumnHeader && columnName[j].Length - (columnName[j].Length * 20 / 100) - 3 > Convert.ToInt32(cWidth[j]))
                                html += columnName[j].Substring(0, Convert.ToInt32(cWidth[j])) + "...";
                            else
                                html += columnName[j];

                            html += "</th>\n";
                        }
                        sumValues[j] = 0.0;
                    }
                }

                // table rows
                html += "<tr>\n";
                for (j = 0; j < dt.Columns.Count; j++)
                {
                    if (cWidth[j] != "0")
                    {
                        html += "<td align=" + cAlign[j] + " width=" + cWidth[j] + "%>" + String.Format(cFormat[j], dt.Rows[i][j]) + "</td>\n";

                        if (ColumnsToSum != "" && IsIn(j.ToString(), ColumnsToSum, ';') && IsNumeric(dt.Rows[i][j].ToString()))
                            sumValues[j] += Convert.ToDouble(dt.Rows[i][j]);
                    }
                }
                html += "</tr>\n";

                OnDataTableToHtmlElapsed(new EventArgs());
                if (cancel) break;
            }

            // totals
            html += "<tr>\n";
            for (j = 0; j < dt.Columns.Count; j++)
            {
                if (cWidth[j] != "0" && IsIn(j.ToString(), ColumnsToSum, ';'))
                {
                    html += "<td style=\"border-top:solid;\" align=" + cAlign[j] + " width=" + cWidth[j] + "%>" + String.Format(cFormat[j], sumValues[j]) + "</td>\n";
                    totValues[j] += sumValues[j];
                }
                else if (cWidth[j] != "0")
                    html += "<td width=" + cWidth[j] + "%></td>\n";
            }
            html += "</tr>\n";
            html += "</table>\n";

            if (columnToGroupBy.Length > 0)
            {
                // grand totals
                html += "<br><br>";
                html += "<table width=" + totalWidth + "% align=center border=0>\n";
                html += "<tr>\n";
                for (j = 0; j < dt.Columns.Count; j++)
                {
                    if (cWidth[j] != "0" && IsIn(j.ToString(), ColumnsToSum, ';'))
                        html += "<td style=\"border-top:solid;\" align=" + cAlign[j] + " width=" + cWidth[j] + "%>" + String.Format(cFormat[j], totValues[j]) + "</td>\n";
                    else if (cWidth[j] != "0")
                        html += "<td width=" + cWidth[j] + "%></td>\n";
                }
                html += "</tr>\n";
                html += "</table>\n";
            }

            html += "</body>\n";
            html += "</html>\n";

            string fileName = Environment.GetEnvironmentVariable("TEMP") + "\\" + "r" + DateTime.Now.ToString("yyyyMMddhhmmssfff") + ".htm";
            StreamWriter sw = new StreamWriter(fileName);
            sw.Write(html);
            sw.Close();

            if (OpenBrowser)
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = fileName;
                p.StartInfo.UseShellExecute = true;
                p.Start();
            }

            return fileName;
        }
        /// <summary>
        /// Fires for each record to be printed
        /// </summary>
        public event EventHandler DataTableToHtmlElapsed;
        /// <summary>
        /// Fires for each record to be printed
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDataTableToHtmlElapsed(EventArgs e)
        {
            if (DataTableToHtmlElapsed != null)
                DataTableToHtmlElapsed(this, e);
        }

        /// <summary>
        /// Set a temporary primary key for a datatable who have not one
        /// </summary>
        /// <param name="dt">The datatable to manipulate</param>
        /// <param name="columnsName">list of columns name delimited by comma</param>
        /// <returns></returns>
        public void DataTableSetPKey(DataTable dt, string columnsName)
        {
            string[] arr = columnsName.Split(',');

            DataColumn[] keyCol = new DataColumn[arr.Length];
            for (int i = 0; i < arr.Length; i++)
                keyCol[i] = dt.Columns[arr[i]];

            dt.PrimaryKey = keyCol;
        }

        /// <summary>
        /// Update the pending insert, update and delete from the datatable to the database.
        /// <para>Note that the option ContinueUpdateOnError of the data adapter is set to true so the rows with errors will not be saved.</para>
        /// <para>Test out from there for datatable errors if the result is false.</para>
        /// </summary>
        /// <param name="dt">the datatable to update</param>
        /// <param name="sqlCommandText">usually the sql string used to fill the datatable</param>
        /// <returns></returns>
        public bool DataTableUpdate(DataTable dt, string sqlCommandText)
        {
            errorMessage = "";

            DbConnection cn = CreateConnection();
            try
            {
                DbCommand cm = CreateCommand(cn, sqlCommandText);
                DbDataAdapter da = CreateDataAdapter(cm);
                da.ContinueUpdateOnError = true;
                DbCommandBuilder cb = CreateCommandBuilder(da);
                cb.ConflictOption = ConflictOption.OverwriteChanges;

                da.InsertCommand = cb.GetInsertCommand();
                da.InsertCommand.CommandTimeout = timeOut;

                try
                {
                    da.UpdateCommand = cb.GetUpdateCommand();
                }
                catch (Exception ex)
                {
                    if (dt.PrimaryKey.Length == 0)
                        throw new Exception(ex.Message);

                    string tableName = sqlCommandText;
                    tableName = tableName.Replace("\r", " ");
                    tableName = tableName.Replace("\n", " ");
                    tableName = tableName.Replace("\t", " ");
                    tableName = tableName.Substring(sqlCommandText.ToUpper().IndexOf(" FROM ") + 6);
                    if (tableName.IndexOf(" ") > 0)
                        tableName = tableName.Substring(0, tableName.IndexOf(" "));

                    int k = 1;
                    string updateQuery = "update " + tableName + " set ";
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        updateQuery += dt.Columns[i].ColumnName + "=" + ProviderParam + "p" + k.ToString() + ",";
                        k++;
                    }
                    updateQuery = RTrunc(updateQuery, 1);
                    updateQuery += " where ";
                    for (int i = 0; i < dt.PrimaryKey.Length; i++)
                    {
                        updateQuery += dt.PrimaryKey[i].ColumnName + "=" + ProviderParam + "p" + k.ToString() + " and ";
                        k++;
                    }
                    updateQuery = RTrunc(updateQuery, 5);
                    DbCommand updateCommand = CreateCommand(updateQuery);
                    k = 1;
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        DbParameter p = updateCommand.CreateParameter();
                        p.ParameterName = ProviderParam + "p" + k.ToString();
                        p.SourceColumn = dt.Columns[i].ColumnName;
                        updateCommand.Parameters.Add(p);
                        k++;
                    }
                    for (int i = 0; i < dt.PrimaryKey.Length; i++)
                    {
                        DbParameter p = updateCommand.CreateParameter();
                        p.ParameterName = ProviderParam + "p" + k.ToString();
                        p.SourceColumn = dt.PrimaryKey[i].ColumnName;
                        updateCommand.Parameters.Add(p);
                        k++;
                    }
                    da.UpdateCommand = updateCommand;
                }
                da.UpdateCommand.CommandTimeout = timeOut;

                try
                {
                    da.DeleteCommand = cb.GetDeleteCommand();
                }
                catch (Exception ex)
                {
                    if (dt.PrimaryKey.Length == 0)
                        throw new Exception(ex.Message);

                    string tableName = sqlCommandText;
                    tableName = tableName.Replace("\r", " ");
                    tableName = tableName.Replace("\n", " ");
                    tableName = tableName.Replace("\t", " ");
                    tableName = tableName.Substring(sqlCommandText.ToUpper().IndexOf(" FROM ") + 6);
                    if (tableName.IndexOf(" ") > 0)
                        tableName = tableName.Substring(0, tableName.IndexOf(" "));

                    int k = 1;
                    string deleteQuery = "delete " + tableName + " where ";
                    for (int i = 0; i < dt.PrimaryKey.Length; i++)
                    {
                        deleteQuery += dt.PrimaryKey[i].ColumnName + "=" + ProviderParam + "p" + k.ToString() + " and ";
                        k++;
                    }
                    deleteQuery = RTrunc(deleteQuery, 5);
                    DbCommand deleteCommand = CreateCommand(deleteQuery);

                    k = 1;
                    for (int i = 0; i < dt.PrimaryKey.Length; i++)
                    {
                        DbParameter p = deleteCommand.CreateParameter();
                        p.ParameterName = ProviderParam + "p" + k.ToString();
                        p.SourceColumn = dt.PrimaryKey[i].ColumnName;
                        deleteCommand.Parameters.Add(p);
                        k++;
                    }
                    da.DeleteCommand = deleteCommand;
                }
                da.DeleteCommand.CommandTimeout = timeOut;

                cn.Open();
                da.Update(dt);
                if (dt.HasErrors)
                {
                    DataRow[] rw = dt.GetErrors();
                    for (int i = 0; i < rw.Length; i++)
                    {
                        errorMessage += "\r\n" + rw[i].RowError + "\r\n";
                        for (int j = 0; j < dt.Columns.Count; j++)
                            errorMessage += dt.Columns[j].ColumnName + "=" + rw[i][j].ToString() + "\r\n";
                    }
                    if (logEvents)
                        LogEvent("ERROR", "Error while updating data\r\n" + errorMessage);
                    return false;
                }
                else
                    return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                if (logEvents)
                    LogEvent("ERROR", sqlCommandText + "\r\n/\r\n" + ex.ToString(), true);
                return false;
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Return the database type for a given System.Type
        /// </summary>
        /// <param name="SystemType"></param>
        /// <returns></returns>
        public string DbDataType(string SystemType)
        {
            string r = "";
            switch (ProviderType)
            {
                case ProviderTypes.SqlServer:
                    switch (SystemType)
                    {
                        case "Boolean": r = "bit"; break;
                        case "Byte[]": r = "varbinary"; break;
                        case "DateTime": r = "datetime"; break;
                        case "Decimal": r = "numeric"; break;
                        case "Double": r = "float"; break;
                        case "Guid": r = "uniqueidentifier"; break;
                        case "Int16": r = "smallint"; break;
                        case "Int32": r = "int"; break;
                        case "Int64": r = "bigint"; break;
                        case "Object": r = "sql_variant"; break;
                        case "SByte": r = "tinyint"; break;
                        case "Single": r = "real"; break;
                        case "String": r = "varchar"; break;
                    }
                    break;
                case ProviderTypes.Oracle:
                    switch (SystemType)
                    {
                        case "Boolean": r = "char(1)"; break;
                        case "Byte[]": r = "blob"; break;
                        case "DateTime": r = "date"; break;
                        case "Decimal": r = "number"; break;
                        case "Double": r = "float"; break;
                        case "Guid": r = "rowid"; break;
                        case "Int16": r = "number(5)"; break;
                        case "Int32": r = "number(10)"; break;
                        case "Int64": r = "number(20)"; break;
                        case "Object": r = "blob"; break;
                        case "SByte": r = "number(5)"; break;
                        case "Single": r = "number"; break;
                        case "String": r = "varchar"; break;
                    }
                    break;
                case ProviderTypes.MySql:
                    switch (SystemType)
                    {
                        case "Boolean": r = "char(1)"; break;
                        case "Byte[]": r = "blob"; break;
                        case "DateTime": r = "datetime"; break;
                        case "Decimal": r = "decimal"; break;
                        case "Double": r = "double"; break;
                        case "Guid": r = ""; break;
                        case "Int16": r = "smallint"; break;
                        case "Int32": r = "int"; break;
                        case "Int64": r = "bigint"; break;
                        case "Object": r = "blob"; break;
                        case "SByte": r = "tinyint"; break;
                        case "Single": r = "float"; break;
                        case "String": r = "varchar"; break;
                    }
                    break;
                case ProviderTypes.PostgreSQL:
                    switch (SystemType)
                    {
                        case "Boolean": r = "bool"; break;
                        case "Byte[]": r = "binary"; break;
                        case "DateTime": r = "date"; break;
                        case "Decimal": r = "numeric"; break;
                        case "Double": r = "double"; break;
                        case "Guid": r = ""; break;
                        case "Int16": r = "smallint"; break;
                        case "Int32": r = "int"; break;
                        case "Int64": r = "bigint"; break;
                        case "Object": r = "binary"; break;
                        case "SByte": r = "smallint"; break;
                        case "Single": r = "float"; break;
                        case "String": r = "varchar"; break;
                    }
                    break;
                case ProviderTypes.MsAccess:
                    switch (SystemType)
                    {
                        case "Boolean": r = "Bit"; break;
                        case "Byte[]": r = "LongBinary"; break;
                        case "DateTime": r = "DateTime"; break;
                        case "Decimal": r = "Decimal"; break;
                        case "Double": r = "Double"; break;
                        case "Guid": r = "GUID"; break;
                        case "Int16": r = "Short"; break;
                        case "Int32": r = "Long"; break;
                        case "Int64": r = "Long"; break;
                        case "Object": r = "LongBinary"; break;
                        case "SByte": r = "Short"; break;
                        case "Single": r = "Single"; break;
                        case "String": r = "VarChar"; break;
                    }
                    break;
                case ProviderTypes.OleDB:
                    switch (SystemType)
                    {
                        case "Boolean": r = "BOOLEAN"; break;
                        case "Byte[]": r = "VARBINARY"; break;
                        case "DateTime": r = "DATETIME"; break;
                        case "Decimal": r = "NUMERIC"; break;
                        case "Double": r = "DOUBLE"; break;
                        case "Guid": r = "STRING"; break;
                        case "Int16": r = "INT"; break;
                        case "Int32": r = "INT"; break;
                        case "Int64": r = "LONG"; break;
                        case "Object": r = "LONGBINARY"; break;
                        case "SByte": r = "CHARACTER"; break;
                        case "Single": r = "SINGLE"; break;
                        case "String": r = "STRING"; break;
                         
                    }
                    break;
                case ProviderTypes.SQLite:
                    switch (SystemType)
                    {
                        case "Boolean": r = "Bit"; break;
                        case "Byte[]": r = "Blob"; break;
                        case "DateTime": r = "TimeStamp"; break;
                        case "Decimal": r = "Numeric(20,10)"; break;
                        case "Double": r = "Double"; break;
                        case "Guid": r = "GUID"; break;
                        case "Int16": r = "Smallint"; break;
                        case "Int32": r = "Integer"; break;
                        case "Int64": r = "Unsigned big int"; break;
                        case "Object": r = "Blob"; break;
                        case "SByte": r = "Short"; break;
                        case "Single": r = "Real"; break;
                        case "String": r = "VarChar(255)"; break;
                          
                    }
                    break;
            }
            if (r == "") r = SystemType;
            return r;
        }

        /// <summary>
        /// Add a where clause to an existing query
        /// </summary>
        /// <param name="sqlText">Query command text</param>
        /// <param name="w">where clause to add (can begin with "where" or "and")</param>
        /// <returns></returns>
        public string AddWhere(string sqlText, string w)
        {
            sqlText = sqlText.Trim();
            if (sqlText == null) return "";

            w = w.Trim();
            if (w.ToLower().StartsWith("where ")) w = w.Substring(6);
            if (w.ToLower().StartsWith("and ")) w = w.Substring(4);
            if (w.ToLower().EndsWith(" and")) w = RTrunc(w, 4);
            w = w.Trim();
            if (w == "") return sqlText;

            int braket = 0, i;
            bool whereClauseExists = false;
            for (i = 0; i < sqlText.Length; i++)
            {
                if (sqlText.Substring(i, 1) == "(")
                    braket++;
                else if (sqlText.Substring(i, 1) == ")")
                    braket--;

                if (braket == 0 && SubString(sqlText, i, 6).ToLower() == "where ")
                    whereClauseExists = true;
                if (braket == 0 && SubString(sqlText, i, 9).ToLower() == "group by ")
                    break;
                if (braket == 0 && SubString(sqlText, i, 9).ToLower() == "order by ")
                    break;
                if (braket == 0 && SubString(sqlText, i, 6).ToLower() == "limit ")
                    break;
            }

            if (whereClauseExists)
                w = "AND (" + w + ")";
            else
                w = "WHERE " + w;

            if (i == sqlText.Length)
                sqlText = sqlText + " " + w + " ";
            else
                sqlText = sqlText.Substring(0, i) + w + " " + sqlText.Substring(i);

            return sqlText;
        }

        /// <summary>
        /// Return the next numeric value incremented by 1 for the given key.
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public int GetCounter(string keyValue)
        {
            string[] v = counterTable.Split('(');
            v[1] = v[1].Replace(")", "");

            string tableName = v[0].Trim();
            string keyName = v[1].Split(',')[0].Trim();
            string lastNumber = v[1].Split(',')[1].Trim();

            return GetCounter(keyValue, tableName, keyName, lastNumber);
        }
        /// <summary>
        /// Return the next numeric value incremented by 1 for the given key.
        /// </summary>
        /// <returns></returns>
        public int GetCounter(string keyValue, string tableName, string keyName, string lastNumber)
        {
            DbConnection cn = CreateConnection();
            DbCommand cm = CreateCommand(cn);
            cm.CommandType = CommandType.Text;

            string s = "SELECT " + lastNumber + " FROM " + tableName + " WHERE " + keyName + "='" + keyValue + "'";
            string i = "INSERT INTO " + tableName + " (" + keyName + "," + lastNumber + ") VALUES ('" + keyValue + "',1) ";
            string u = "UPDATE " + tableName + " SET " + lastNumber + "=" + lastNumber + "+1 WHERE " + keyName + "='" + keyValue + "'";
            int r = -1;
            errorMessage = "";

            try
            {
                cn.Open();
                cm.Transaction = cn.BeginTransaction();

                cm.CommandText = u;					// do update immediately so the record will be locked
                int n = cm.ExecuteNonQuery();

                if (n == 0)							// the record doesn't exists so it must be inserted
                {
                    cm.CommandText = i;
                    if (cm.ExecuteNonQuery() > 0)
                        r = 1;					    // insert succesfully
                    else
                        r = -1;					    // insert failed
                }
                else if (n < 0)						// update failed
                    r = -1;
                else								// update succesfully: value will be selected
                {
                    cm.CommandText = s;
                    r = Convert.ToInt32(cm.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                if (logEvents)
                    LogEvent("ERROR", s + "\r\n" + i + "\r\n" + u + "\r\n/\r\n" + ex.Message);
                r = -1;
            }
            finally
            {
                if (r == -1)
                    cm.Transaction.Rollback();
                else
                    cm.Transaction.Commit();

                cn.Close();
            }

            return r;
        }

        /// <summary>
        /// Return a property value from connection string based on property name
        /// <para>Example: GetConnectionProperty("DataSource")</para>
        /// </summary>
        /// <param name="propertyName">the property name (e.g. DataSource)</param>
        /// <returns></returns>
        public string GetConnectionProperty(string propertyName)
        {
            string r = "";
            if (connectionString != "")
            {
                string[] v = connectionString.Split(';');
                for (int i = 0; i < v.Length; i++)
                {
                    if (String.Compare(v[i].Split('=')[0].Trim(), propertyName, true) == 0)
                        r = v[i].Split('=')[1].Trim();
                }
            }
            return r;
        }

        /// <summary>
        /// Replies the GetSchema function trapped with an error
        /// </summary>
        /// <param name="collectionName">The name of the schema to return</param>
        /// <param name="restictionValues">Set of restriction</param>
        /// <returns></returns>
        public DataTable GetSchema(string collectionName, string[] restictionValues)
        {
            DbConnection cn = CreateConnection();
            DataTable dt = new DataTable();

            cn.Open();
            try
            {
                dt.Clear();
                dt = cn.GetSchema(collectionName, restictionValues);
            }
            catch
            {
                dt = null;
            }
            cn.Close();
            return dt;
        }

        #endregion

        #region Crypting utilities

        /// <summary>
        /// Decrypt a string based on a crypt key
        /// </summary>
        /// <param name="stringToDecrypt"></param>
        /// <param name="criptKey">if empty this value is retrieved from CriptKey into the config file</param>
        /// <returns></returns>
        public string Decrypt(string stringToDecrypt, string criptKey)
        {
            int i, j;
            string r = "";
            if (criptKey == "")
              //  criptKey = SAPGlobalSettings.config.AppSettings["CriptKey"];
                criptKey = ConfigurationManager.AppSettings["CriptKey"];

            j = Convert.ToInt32(RevSubString(StringToId(criptKey).ToString(), 2));
            for (i = 0; i < stringToDecrypt.Length; i = i + 2)
            {
                r += Convert.ToChar(Convert.ToInt32(stringToDecrypt.Substring(i, 2), 16) ^ j);
                j = j + 7;
                if (j > 255) j = Convert.ToInt32(RevSubString(StringToId(criptKey).ToString(), 2));
            }

            return r;
        }

        /// <summary>
        /// Encrypt a string based on a crypt key
        /// </summary>
        /// <param name="stringToEncrypt"></param>
        /// <param name="criptKey">if empty this value is retrieved from CriptKey into the config file</param>
        /// <returns></returns>
        public string Encrypt(string stringToEncrypt, string criptKey)
        {
            int i, j;
            string r = "";
            if (criptKey == "")
             //criptKey = SAPGlobalSettings.config.AppSettings["CriptKey"];
             criptKey = ConfigurationManager.AppSettings["CriptKey"];

            j = Convert.ToInt32(RevSubString(StringToId(criptKey).ToString(), 2));
            for (i = 0; i < stringToEncrypt.Length; i++)
            {
                char c = Convert.ToChar(stringToEncrypt.Substring(i, 1));
                byte b = Convert.ToByte(c);
                int h = b ^ j;
                r += h.ToString("X").PadLeft(2, '0');
                j = j + 7;
                if (j > 255) j = Convert.ToInt32(RevSubString(StringToId(criptKey).ToString(), 2));
            }

            return r;
        }

        /// <summary>
        /// Convert the original string into MD5 cryptography (one-way cryptography)
        /// </summary>
        public string EncryptMD5(string stringToEncrypt)
        {
            return BitConverter.ToString(
                System.Security.Cryptography.MD5CryptoServiceProvider.Create().ComputeHash(
                System.Text.ASCIIEncoding.Default.GetBytes(stringToEncrypt)
                )
                ).Replace("-", "").ToLower();
        }

        #endregion

        #region Functions

        /// <summary>
        /// The decode function has the functionality of an IF-THEN-ELSE statement.
        /// <para>The syntax for the decode function is:</para>
        /// <para>    decode( expression , search , result [, search , result]... [, default] )</para>
        /// </summary>
        /// <param name="expression">is the value to compare</param>
        /// <param name="list">
        /// search is the value that is compared against expression.
        /// result is the value returned, if expression is equal to search.
        /// default is optional. If no matches are found, the decode will return default. If default is omitted, then the decode statement will return empty string (if no matches are found).
        /// </param>
        /// <returns></returns>
        public string Decode(string expression, params string[] list)
        {
            bool odd;
            if (Convert.ToInt32(list.Length / 2) == list.Length / 2.0)
                odd = false;
            else
                odd = true;

            for (int i = 0; i < list.Length; i = i + 2)
            {
                if (odd && i == list.Length - 1)
                    break;
                if (expression == list[i])
                    return list[i + 1];
            }

            if (odd)
                return list[list.Length - 1];
            else
                return "";
        }

        /// <summary>
        /// Return true if the values from...to are between the input value
        /// </summary>
        public bool IsBetween(string inputValue, string betweenFrom, string betweenTo)
        {
            if (IsNumeric(inputValue) && IsNumeric(betweenFrom) && IsNumeric(betweenTo))
            {
                if (Convert.ToDouble(inputValue) >= Convert.ToDouble(betweenFrom) && Convert.ToDouble(inputValue) <= Convert.ToDouble(betweenTo))
                    return true;
                else
                    return false;
            }
            else
            {
                if (String.Compare(inputValue, betweenFrom, true) >= 0 && String.Compare(inputValue, betweenTo, true) <= 0)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// Return true if the search value is present into the list of values (delimited by comma)
        /// <para>Example: IsIn("Paul", "Jon,Paul,Antony") return true</para>
        /// </summary>
        public bool IsIn(string stringToInspect, string listOfValues)
        {
            return IsIn(stringToInspect, listOfValues, ',');
        }
        /// <summary>
        /// Return true if the search value is present into the list of values (delimited by specified char)
        /// <para>Example: IsIn("Paul", "Jon,Paul,Antony") return true</para>
        /// </summary>
        public bool IsIn(string stringToInspect, string listOfValues, char delimiter)
        {
            string[] v = listOfValues.Split(delimiter);
            for (int i = 0; i < v.Length; i++)
            {
                if (stringToInspect == v[i])
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Load an Excel file into a datatable
        /// </summary>
        /// <param name="fileName">The file name</param>
        /// <param name="sheetName">The sheet to load (if empty will be loaded the first sheet)</param>
        /// <param name="hasHeader">If the column headings is present or not</param>
        /// <returns></returns>
        public DataTable LoadXLS(string fileName, string sheetName, bool hasHeader)
        {
            DbConnection cn = CreateConnection("System.Data.OleDb", "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties=\"Excel 8.0;HDR=" + (hasHeader ? "YES" : "NO") + ";IMEX=1\"");
            if (sheetName == "")
            {
                cn.Open();
                sheetName = cn.GetSchema("Tables").Rows[0]["table_name"].ToString();
                cn.Close();
            }

            DbDataAdapter da = CreateDataAdapter("System.Data.OleDb");
            da.SelectCommand = CreateCommand(cn, "select * from [" + sheetName + "]"); ;

            DataTable dt = new DataTable();
            cn.Open();
            da.Fill(dt);
            cn.Close();

            return dt;
        }

        /// <summary>
        /// Replaces the first occurrence of a string found within another string
        /// </summary>
        /// <param name="original">The original string</param>
        /// <param name="oldValue">A System.String to be replaced</param>
        /// <param name="newValue">A System.String to replace the first occurrence of oldValue</param>
        /// <returns></returns>
        public string ReplaceFirstOccurrence(string original, string oldValue, string newValue)
        {
            int loc = original.IndexOf(oldValue);
            if (loc >= 0)
                return original.Remove(loc, oldValue.Length).Insert(loc, newValue);
            else
                return original;
        }

        /// <summary>
        /// Make a reverse substring beginning from the end of file
        /// </summary>
        public string RevSubString(string inputValue, int size)
        {
            string s = inputValue;
            return SubString(s, s.Length - size, size);
        }
        /// <summary>
        /// Make a reverse substring beginning from the start position
        /// </summary>
        public string RevSubString(string inputValue, int start, int size)
        {
            string s = SubString(inputValue, 0, start);
            return RevSubString(s, size);
        }

        /// <summary>
        /// Truncate a string on the right of the specified length
        /// </summary>
        public string RTrunc(string inputValue, int size)
        {
            try
            {
                return inputValue.Substring(0, inputValue.Length - size);
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// Return a string filtered with only the specified characters
        /// </summary>
        public string StringFilter(string inputValue, StringType typeOfExctraction)
        {
            return StringFilter(inputValue, typeOfExctraction, "");
        }
        /// <summary>
        /// Return a string filtered with only the specified characters
        /// </summary>
        public string StringFilter(string inputValue, StringType typeOfExctraction, string moreChars)
        {
            string r = "", typeOfString;

            if (typeOfExctraction == StringType.CharsAndSymbols)
                typeOfString = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz()[]{}|\\:;<>=?@!#$%&\"'*+,-./^_` ";
            else if (typeOfExctraction == StringType.CharsAndNumbers)
                typeOfString = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            else if (typeOfExctraction == StringType.CharsAndNumbersAndSymbols)
                typeOfString = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz()[]{}|\\:;<>=?@!#$%&\"'*+,-./^_` ";
            else if (typeOfExctraction == StringType.CharsAndNumbersAndSpaces)
                typeOfString = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz ";
            else if (typeOfExctraction == StringType.DateOrTime)
                typeOfString = "0123456789/-:.";
            else if (typeOfExctraction == StringType.NumbersWithSigns)
                typeOfString = "0123456789+-";
            else if (typeOfExctraction == StringType.NumbersWithSignsAndPunctuation)
                typeOfString = "0123456789,.+-";
            else if (typeOfExctraction == StringType.Chars)
                typeOfString = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            else if (typeOfExctraction == StringType.Numbers)
                typeOfString = "0123456789";
            else
                typeOfString = "";

            typeOfString += moreChars;

            for (int i = 0; i < inputValue.Length; i++)
            {
                if (typeOfString.IndexOf(inputValue.Substring(i, 1)) >= 0)
                    r += inputValue.Substring(i, 1);
            }
            return r;
        }

        /// <summary>
        /// Convert the string into an unique number identifier for the string
        /// </summary>
        public int StringToId(string inputValue)
        {
            int r = 0;

            for (int i = 0; i < inputValue.Length; i++)
            {
                char c = Convert.ToChar(inputValue.Substring(i, 1));
                r += c * (i + 1);
            }

            return r;
        }

        /// <summary>
        /// Make a secure substring (size can be greater than the length of the string)
        /// </summary>
        public string SubString(string inputValue, int start, int size)
        {
            try
            {
                return inputValue.Substring(start, size);
            }
            catch
            {
                try
                {
                    return inputValue.Substring(start);
                }
                catch
                {
                    return inputValue;
                }
            }
        }

        /// <summary>
        /// Try to interpret and convert the input string into date format
        /// </summary>
        public string FormatDate(string inputValue)
        {
            return FormatDate(inputValue, false);
        }
        /// <summary>
        /// Try to interpret and convert the input string into date format
        /// </summary>
        public string FormatDate(string inputValue, bool truncateHMS)
        {
            string d;
            string t;

            if (inputValue == "") return "";

            // date part
            d = inputValue.Split()[0].ToString();
            // hour part
            if (inputValue.IndexOf(" ") > 0 && !truncateHMS) t = inputValue.Split()[1]; else t = "";

            // date management (if no delimiter was entered assumes dd mm yyyy format)
            if (IsNumeric(d))
            {
                if (d.Length == 7)
                    d = d.PadLeft(8, '0');
                else if (d.Length == 5)
                    d = d.PadLeft(6, '0');
                d = d.Substring(0, 2) + "/" + d.Substring(2, 2) + "/" + d.Substring(4);
            }
            try
            {
                d = Convert.ToDateTime(d).ToString("d");
            }
            catch
            {
            }

            // hour management
            t = FormatTime(t);

            return (d + " " + t).Trim();
        }

        /// <summary>
        /// Try to interpret and convert the input string into time format
        /// </summary>
        public string FormatTime(string inputValue)
        {
            if (inputValue == "") return "";

            string s = StringFilter(inputValue, StringType.Numbers);
            string f = "";

            if (s.Length <= 2)
            {
                s = s + ":00";
                f = "t";
            }
            else if (s.Length <= 4)
            {
                s = s.PadRight(4, '0');
                s = s.Substring(0, 2) + ":" + s.Substring(2);
                f = "t";
            }
            else if (s.Length <= 6)
            {
                s = s.PadLeft(6, '0');
                s = s.Substring(0, 2) + ":" + s.Substring(2, 2) + ":" + s.Substring(4);
                f = "T";
            }
            else
            {
                s = s.Substring(0, 2) + ":" + s.Substring(2, 2) + ":" + s.Substring(4, 2);
                f = "T";
            }

            try
            {
                s = Convert.ToDateTime(s).ToString(f);
            }
            catch
            {
            }
            return s;
        }

        /// <summary>
        /// Return true if the input value contain a valid date
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public bool IsDate(string inputValue)
        {
            try
            {
                Convert.ToDateTime(inputValue);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Search an array for the specified value and returns the first index found
        /// <para>-1 if not found</para>
        /// <para>-2 if the array is empty</para>
        /// <para>-3 if the array is null</para>
        /// </summary>
        public int IndexOfArray(string[] IArray, string searchString)
        {
            if (IArray == null)
                return -3;
            if (IArray.Length == 0)
                return -2;

            int i;
            int r = -1;

            for (i = 0; i < IArray.Length; i++)
            {
                if (IArray[i] == searchString)
                {
                    r = i;
                    break;
                }
            }
            return r;
        }

        /// <summary>
        /// Return true if the input value contain a valid number
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public bool IsNumeric(string inputValue)
        {
            try
            {
                Convert.ToDouble(inputValue);
                return true;
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// Return an empty string if the input value is Null or DbNull
        /// </summary>
        public string nvl(object inputValue)
        {
            return nvl(inputValue, "");
        }
        /// <summary>
        /// Return replaceValue if the input value is Null or DbNull
        /// </summary>
        public int nvl(object inputValue, int replaceValue)
        {
            if (inputValue == null || inputValue == DBNull.Value)
                return replaceValue;
            else
                return Convert.ToInt32(inputValue);
        }
        /// <summary>
        /// Return replaceValue if the input value is Null or DbNull
        /// </summary>
        public double nvl(object inputValue, double replaceValue)
        {
            if (inputValue == null || inputValue == DBNull.Value)
                return replaceValue;
            else
                return Convert.ToDouble(inputValue);
        }
        /// <summary>
        /// Return replaceValue if the input value is Null or DbNull
        /// </summary>
        public decimal nvl(object inputValue, decimal replaceValue)
        {
            if (inputValue == null || inputValue == DBNull.Value)
                return replaceValue;
            else
                return Convert.ToDecimal(inputValue);
        }
        /// <summary>
        /// Return replaceValue if the input value is Null or DbNull
        /// </summary>
        public object nvl(object inputValue, object replaceValue)
        {
            if (inputValue == null || inputValue == DBNull.Value)
                return replaceValue;
            else
                return inputValue;
        }
        /// <summary>
        /// Return replaceValue if the input value is Null or DbNull
        /// </summary>
        public string nvl(object inputValue, string replaceValue)
        {
            if (inputValue == null || inputValue == DBNull.Value)
                return replaceValue;
            else
                return inputValue.ToString();
        }
        /// <summary>
        /// Return replaceValue if the input value is an empty string
        /// </summary>
        public string nvl(string inputValue, string replaceValue)
        {
            if (inputValue == null || inputValue == "")
                return replaceValue;
            else
                return inputValue;
        }

        /// <summary>
        /// Replace the sqlCommandText with the values specified by $x parameters
        /// <para>Example: ReplaceParams("insert into xTable(field1, field2, field3, field4) values ($1,'$2',to_date('$3','dd/mm/yyyy'),'fixed value')", "10;my string value;10/01/2007", ';')</para>
        /// </summary>
        /// <param name="sqlCommandText">the sql command text</param>
        /// <param name="paramList">list of values</param>
        /// <param name="delimiter">the delimiter for the values</param>
        /// <returns></returns>
        public string ReplaceParams(string sqlCommandText, string paramList, char delimiter)
        {
            string[] s = paramList.Split(delimiter);
            return ReplaceParams(sqlCommandText, s);
        }
        /// <summary>
        /// Replace the sqlCommandText with the values specified by $x parameters
        /// <para>Example: ReplaceParams("insert into xTable(field1, field2, field3, field4) values ($1,'$2',to_date('$3','dd/mm/yyyy'),'fixed value')", 10, "my string value", "10/01/2007")</para>
        /// </summary>
        /// <param name="sqlCommandText">the sql command text</param>
        /// <param name="paramArray">array of values</param>
        /// <returns></returns>
        public string ReplaceParams(string sqlCommandText, params string[] paramArray)
        {
            for (int i = paramArray.Length - 1; i >= 0; i--)
            {
                int k = i + 1;
                sqlCommandText = sqlCommandText.Replace("$" + k.ToString(), paramArray[i]);
            }
            return sqlCommandText;
        }

        /// <summary>
        /// Sort a list of values delimited by specificed char. 
        /// <para>If uniq is true the duplicated values will be removed.</para>
        /// </summary>
        public string Sort(string inputValue, char delim, bool uniq)
        {
            bool b;
            string tmp;
            string[] v = inputValue.Split(delim);

            b = true;
            while (b)
            {
                b = false;
                for (int i = 1; i < v.Length; i++)
                {
                    if (String.Compare(v[i], v[i - 1]) < 0)
                    {
                        tmp = v[i - 1];
                        v[i - 1] = v[i];
                        v[i] = tmp;
                        b = true;
                    }
                }
            }

            if (uniq)
            {
                tmp = v[0];
                for (int i = 1; i < v.Length; i++)
                {
                    if (String.Compare(v[i], tmp) == 0)
                        v[i] = "";
                    else
                        tmp = v[i];
                }
            }

            string r = "";
            for (int i = 0; i < v.Length; i++)
            {
                if (v[i] != "")
                    r += v[i] + delim;
            }
            r = RTrunc(r, 1);

            return r;
        }

        /// <summary>
        /// Read the entire content of a text file
        /// </summary>
        /// <param name="fileName">The full path name of the file</param>
        /// <returns></returns>
        public string FileRead(string fileName)
        {
            string s = "";
            try
            {
                StreamReader f = new StreamReader(fileName);
                s = f.ReadToEnd();
                f.Close();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return s;
        }

        /// <summary>
        /// Write a text in the specified file (append by default)
        /// </summary>
        public void FileWrite(string fileName, string textToWrite)
        {
            FileWrite(fileName, textToWrite, true);
        }
        /// <summary>
        /// Write a text in the specified file
        /// </summary>
        public void FileWrite(string fileName, string textToWrite, bool append)
        {
            if (fileName.IndexOf('\\') < 0)
                fileName = outputFolder + fileName;

            if (Directory.Exists(Path.GetDirectoryName(fileName)) == false)
                Directory.CreateDirectory(Path.GetDirectoryName(fileName));

            StreamWriter f = new StreamWriter(fileName, append);
            f.Write(textToWrite);
            f.Close();
        }

        /// <summary>
        /// Write an event into the event-table. 
        /// </summary>
        public void LogEvent(string eventType, string eventText)
        {
            LogEvent(eventType, eventText, false, true);
        }
        /// <summary>
        /// Write an event into the event-table or into the event-file.
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="eventText"></param>
        /// <param name="logToFile">if true the event will be written only into the file</param>
        public void LogEvent(string eventType, string eventText, bool logToFile)
        {
            LogEvent(eventType, eventText, logToFile, true);
        }
        /// <summary>
        /// Write an event into the event-table or into the event-file. 
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="eventText"></param>
        /// <param name="logToFile">if true the event will be written only into the file</param>
        /// <param name="wrapLine">if false no carriage return will be automatically inserted</param>
        public void LogEvent(string eventType, string eventText, bool logToFile, bool wrapLine)
        {
            if (logTable == "")
                logToFile = true;
            if (!logToFile)
            {
                string qry = "insert into " + logTable
                           + "values (" + ProviderParam + "evtType, " + ProviderParam + "evtDate, " + ProviderParam + "evtText, " + ProviderParam + "evtUser)";
                DbConnection cn = CreateConnection();
                DbCommand cm = CreateCommand(cn, qry);

                try
                {
                    cn.Open();
                    CreateParameter(cm, ProviderParam + "evtType", eventType);
                    CreateParameter(cm, ProviderParam + "evtDate", DateTime.Now);
                    CreateParameter(cm, ProviderParam + "evtText", eventText);
                    CreateParameter(cm, ProviderParam + "evtUser", Environment.UserName);
                    cm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    eventText = "Log into table failed because the following error: \r\n" + ex.Message + "\r\n *** EVENT MESSAGE: \r\n" + eventText;
                    logToFile = true;
                    logTable = "";
                }
                finally
                {
                    cn.Close();
                    cm.Dispose();
                    cn.Dispose();
                }
            }
            if (logToFile)
            {
                string e = "[" + System.DateTime.Now.ToString("r") + "]" + (wrapLine ? "\r\n" : ": ") + eventText + (wrapLine ? "\r\n\r\n" : "\r\n");
                FileWrite(outputFolder + eventType + ".log", e, true);
            }
        }

        /// <summary>
        /// Serialize an object into XML format
        /// </summary>
        /// <param name="objectType"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public string XmlSerialize(Type objectType, object o)
        {
            XmlSerializer serializer = new XmlSerializer(objectType);
            MemoryStream memoryStream = new MemoryStream();
            serializer.Serialize(memoryStream, o);
            memoryStream.Seek(0, SeekOrigin.Begin);

            StreamReader stream = new StreamReader(memoryStream);
            string returnValue = stream.ReadToEnd();
            stream.Close();

            return returnValue;
        }
        /// <summary>
        /// DeSerialize an XML into an object
        /// </summary>
        /// <param name="objectType"></param>
        /// <param name="xml"></param>
        /// <param name="envelope"></param>
        /// <returns></returns>
        public object XmlDeSerialize(Type objectType, string xml, string envelope)
        {
            string s;
            if (envelope != "")
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(new StringReader(xml));
                XmlNode xmlNode = xmlDoc.SelectSingleNode(envelope);
                s = xmlNode.InnerText;
            }
            else
            {
                s = xml;
            }
            XmlSerializer serializer = new XmlSerializer(objectType);
            return serializer.Deserialize(new StringReader(s));
        }
        #endregion

        #region Private functions
        private void getColInfo(string inputValue, out string cAlign, out string cWidth, out string cFormat)
        {
            cAlign = "left";
            cWidth = "";
            cFormat = "{0:G}";

            if (inputValue.StartsWith("*"))
            {
                cAlign = "right";
                inputValue = inputValue.Substring(1);
            }

            int p = inputValue.IndexOf('{');
            if (p > 0)
            {
                cWidth = inputValue.Remove(p);
                cFormat = inputValue.Substring(p);
            }
            else
                cWidth = inputValue;
        }
        #endregion
    }
}
