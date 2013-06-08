using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SAPINT.Function;
using System.Data.Common;
using SAPINTDB;
using System.IO;

namespace SAPINT.RFCTable
{
    public delegate void DelegateLogMessage(String message);
    public class SapTable
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        private bool _appendToDb = false;
        private bool _newTable = false;

        private String TableName { get; set; }       //需要保存的表名。
        private String StructureName { get; set; }   //表的定义名字。
        private String SystemName { get; set; }      //SAP系统连接名
        public String DbConnectionString { get; set; }
        //private String ProviderName { get; set; }       //数据库的引擎名
        //private String ConnectionString { get; set; }    //连接字符串

        private List<String> ErrorMessageList = new List<string>();
        private String _errorMessage = null;

        public event DelegateLogMessage EventLogMessage = null;
        public String ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            private set
            {
                _errorMessage = value;
                if (String.IsNullOrWhiteSpace(_errorMessage))
                {
                    ErrorMessageList.Add(_errorMessage);
                }

            }
        }
        public bool AppendToDb
        {
            get { return _appendToDb; }
            set { _appendToDb = value; }

        } //是否是附加上现有的数据库表。
        public bool NewTable
        {

            get { return _newTable; }
            set { _newTable = value; }

        } //是否创建一个新表。
        //数据库表的结构定义，从SAP系统获取。
        private SAPINT.RFCTable.RFCTableInfo rfcTableInfo = new SAPINT.RFCTable.RFCTableInfo();
        //数据库帮助类
        SAPINTDB.netlib7 db2 = null;
        //是否已经把结构定义中的特别字符替换
        // private bool isGetRidofThePrefix = false;//是否已经把'/'进行了替换
        //Sqlite，Mysql不支持字段名中包含"/"，需要把它替换或删除。

        private DataTable dtToSaved = null;

        private bool notSAPTable = false;
        public SapTable(String pTableName)
        {
            TableName = pTableName.Trim().ToUpper();
            notSAPTable = true;
        }
        /// <summary>
        /// 初始化，需要sap系统名与表名，表名与结构名一致。
        /// </summary>
        /// <param name="psysName"></param>
        /// <param name="pTableName"></param>
        public SapTable(String psysName, String pTableName)
        {
            SystemName = psysName;
            TableName = pTableName.Trim().ToUpper();
            StructureName = pTableName.Trim().ToUpper();
            // prepareFieldsFromSapSystem();
        }
        /// <summary>
        /// 使用结构名来初始化，适用于，表名与结构定义不一致的情况。
        /// </summary>
        /// <param name="psysName"></param>
        /// <param name="pTableName"></param>
        /// <param name="pStructureName"></param>
        public SapTable(String psysName, String pTableName, String pStructureName)
        {
            SystemName = psysName;
            TableName = pTableName.Trim().ToUpper();
            StructureName = pStructureName.Trim().ToUpper();
            // prepareFieldsFromSapSystem();
        }

        private void sendMessage(String message)
        {
            if (this.EventLogMessage != null)
            {
                EventLogMessage(message);
            }
        }
        private void prepareFieldsFromDataTable()
        {
            sendMessage("准备字段列表");
            if (notSAPTable)
            {
                sendMessage("DataTable不是来自SAP,将临时构造内表");
                foreach (DataColumn item in dtToSaved.Columns)
                {
                    TableField field = new SAPINT.RFCTable.TableField();
                    item.ColumnName = item.ColumnName.Replace("/", "_");
                    field.FIELDNAME = item.ColumnName;
                    field.DOTNETTYPE = item.DataType.ToString();
                    field.DOTNETTYPE = field.DOTNETTYPE.Replace("System.", "");
                    field.OUTPUTLEN = item.MaxLength;
                    field.DBTYPE = SAPINT.DbHelper.DbTypeConvertor.ToDbType(item.DataType).ToString();
                    field.SQLTYPE = SAPINT.DbHelper.DbTypeConvertor.ToSqlDbType(item.DataType).ToString();
                    rfcTableInfo.Fields.Add(field);

                }
            }
            else
            {
                prepareFieldsFromSapSystem();
                HandleTableFields();
            }

        }
        /// <summary>
        /// 准备工作，获取结构定义。
        /// </summary>
        private void prepareFieldsFromSapSystem()
        {
            try
            {
                if (String.IsNullOrWhiteSpace(SystemName))
                {
                    throw new SAPException("SAP系统不能为空");
                }
                if (String.IsNullOrWhiteSpace(StructureName))
                {
                    throw new SAPException("结构定义不能为空");
                }
                sendMessage("开始从SAP系统获取结构定义" + "系统名:" + SystemName + "结构定义:" + StructureName);
                rfcTableInfo.GetTableDefinition(SystemName, StructureName);
                sendMessage("获取表定义完成");
                rfcTableInfo.TransformDataType();
            }
            catch (Exception ex)
            {

                sendMessage(ex.Message);
            }

        }

        /// <summary>
        /// 构造插入语句。
        /// </summary>
        /// <returns></returns>
        private string buildInsertIntoString()
        {
            try
            {
                StringBuilder insertStr;
                if (db2.ProviderType == netlib7.ProviderTypes.OleDB)
                {
                    //建立插入语句
                    insertStr = new StringBuilder("INSERT INTO ");
                    insertStr.AppendFormat("{0}", this.TableName);
                    insertStr.Append("( SAPSYS,");

                    foreach (var item in rfcTableInfo.Fields)
                    {
                        if (item != null)
                        {
                            insertStr.AppendFormat("{0},", item.FIELDNAME);
                        }

                    }

                    insertStr.Remove(insertStr.Length - 1, 1);//注意去除最后一个，
                    insertStr.Append(")values(?,");
                    foreach (var item in rfcTableInfo.Fields)
                    {
                        if (item != null)
                        {
                            insertStr.Append("?,");
                        }
                    }

                    insertStr.Remove(insertStr.Length - 1, 1);
                    insertStr.Append(")");
                    // return insertStr.ToString();
                }
                else if (db2.ProviderType == netlib7.ProviderTypes.SqlServer)
                {
                    //建立插入语句
                    insertStr = new StringBuilder("INSERT INTO ");
                    insertStr.AppendFormat("[{0}]", this.TableName);
                    insertStr.Append("(SAPSYS,");

                    foreach (var item in rfcTableInfo.Fields)
                    {
                        if (item != null)
                        {
                            insertStr.AppendFormat("[{0}],", item.FIELDNAME);
                        }
                    }

                    insertStr.Remove(insertStr.Length - 1, 1);//注意去除最后一个，
                    insertStr.Append(")values(@p1,");
                    int i = 2;
                    foreach (var item in rfcTableInfo.Fields)
                    {
                        if (item != null)
                        {
                            insertStr.Append(String.Format("@p{0},", i));
                            i++;
                        }
                    }

                    insertStr.Remove(insertStr.Length - 1, 1);
                    insertStr.Append(")");
                }
                else
                {
                    //建立插入语句
                    insertStr = new StringBuilder("INSERT INTO ");
                    insertStr.AppendFormat("{0}", this.TableName);
                    insertStr.Append("(SAPSYS,");

                    foreach (var item in rfcTableInfo.Fields)
                    {
                        if (item != null)
                        {
                            insertStr.AppendFormat("{0},", item.FIELDNAME);
                        }
                    }
                    insertStr.Remove(insertStr.Length - 1, 1);//注意去除最后一个，
                    insertStr.Append(")values(?,");
                    foreach (var item in rfcTableInfo.Fields)
                    {
                        if (item != null)
                        {
                            insertStr.Append("?,");
                        }
                    }

                    insertStr.Remove(insertStr.Length - 1, 1);
                    insertStr.Append(")");
                }

                return insertStr.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 根据结构名字构造一个表。
        /// </summary>
        /// <param name="db2"></param>
        /// <returns></returns>
        private string buidCreateTableString()
        {
            StringBuilder str = null;
            if (db2.ProviderType == netlib7.ProviderTypes.OleDB)
            {
                str = new StringBuilder("CREATE TABLE");
                str.AppendFormat(" {0}", this.TableName);
                str.Append("(id autoincrement primary key,SAPSYS NVARCHAR(20),");
                // var sqlstr = @"CREATE TABLE Test3(id integer NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,N

                foreach (var item in rfcTableInfo.Fields)
                {
                    if (item.KEYFLAG.Equals("X"))
                    {
                        if (db2.DbDataType(item.DOTNETTYPE) == "STRING")
                        {
                            if (item.LENG > 255)
                            {
                                str.AppendFormat("{0} {1},", item.FIELDNAME, "MEMO");
                            }
                            else
                            {
                                str.AppendFormat("{0} {1}({2}),", item.FIELDNAME, db2.DbDataType(item.DOTNETTYPE), item.OUTPUTLEN * 2 + item.DECIMALS);
                            }

                        }
                        else
                        {
                            str.AppendFormat("{0} {1},", item.FIELDNAME, "MEMO");
                        }

                    }
                    else
                    {
                        if (db2.DbDataType(item.DOTNETTYPE) == "STRING")
                        {
                            // str.AppendFormat("'{0}' {1}({2}),", item.FIELDNAME, db2.DbDataType(item.DOTNETTYPE), item.OUTPUTLEN);

                            if (item.LENG > 255)
                            {
                                str.AppendFormat("{0} {1},", item.FIELDNAME, "MEMO");
                            }
                            else
                            {
                                str.AppendFormat("{0} {1}({2}),", item.FIELDNAME, db2.DbDataType(item.DOTNETTYPE), item.OUTPUTLEN * 2 + item.DECIMALS);
                            }

                        }
                        else
                        {
                            // str.AppendFormat("'{0}' {1},", item.FIELDNAME, db2.DbDataType(item.DOTNETTYPE));
                            str.AppendFormat("{0} {1},", item.FIELDNAME, "MEMO");
                        }
                    }

                }
                str.Remove(str.Length - 1, 1);//注意这里是倒数第一个，还有一个空格
                str.Append(" )");

                // cmd.CommandText = buidCreateTableString(db2);
                log.Info("SQL 创建表语句： " + str.ToString());
            }
            else if (db2.ProviderType == netlib7.ProviderTypes.MySql)
            {
                str = new StringBuilder("CREATE TABLE IF NOT EXISTS");
                str.AppendFormat(" {0} ", this.TableName);
                str.Append("(idd int(11) NOT NULL AUTO_INCREMENT, SAPSYS nvarchar(20),");

                // var sqlstr = @"CREATE TABLE Test3(id integer NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,N

                foreach (var item in rfcTableInfo.Fields)
                {
                    if (item == null)
                    {
                        continue;
                    }
                    if (item.KEYFLAG.Equals("X"))
                    {
                        str.AppendFormat(" {0} {1}({2}) NOT NULL, ", item.FIELDNAME, item.SQLTYPE, item.OUTPUTLEN + item.DECIMALS);
                        //  str.AppendFormat("KEY {0} ({0})", item.FIELDNAME);
                    }
                    else
                    {
                        str.AppendFormat(" {0} {1}({2}) , ", item.FIELDNAME, item.SQLTYPE, item.OUTPUTLEN + item.DECIMALS);
                    }
                    //  Console.WriteLine(item.FIELDNAME);
                }
                //str.Remove(str.Length - 2, 1);//注意这里是倒数第一个，还有一个空格
                str.Append("PRIMARY KEY (idd)");
                str.Append(" ) CHARSET=utf8 AUTO_INCREMENT=1 ;");
            }
            else if (db2.ProviderType == netlib7.ProviderTypes.SQLite)
            {
                str = new StringBuilder("CREATE TABLE");
                str.AppendFormat(" {0}", this.TableName);
                str.Append("(idd integer NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, SAPSYS nvarchar(20),");
                // var sqlstr = @"CREATE TABLE Test3(id integer NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,N

                foreach (var item in rfcTableInfo.Fields)
                {
                    if (item.KEYFLAG.Equals("X"))
                    {
                        str.AppendFormat(" {0} {1} , ", item.FIELDNAME, item.SQLTYPE, item.OUTPUTLEN + item.DECIMALS);
                    }
                    else
                    {
                        str.AppendFormat(" {0} {1} , ", item.FIELDNAME, item.SQLTYPE, item.OUTPUTLEN + item.DECIMALS);
                    }

                }
                str.Remove(str.Length - 2, 1);//注意这里是倒数第一个，还有一个空格
                str.Append(" )");
            }
            else if (db2.ProviderType == netlib7.ProviderTypes.SqlServer)
            {
                str = new StringBuilder("CREATE TABLE");
                str.AppendFormat(" {0}", this.TableName);
                str.Append("(id int identity(1,1) primary key, SAPSYS nvarchar(20),");
                // var sqlstr = @"CREATE TABLE Test3(id integer NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,N

                foreach (var item in rfcTableInfo.Fields)
                {
                    if (item.KEYFLAG.Equals("X"))
                    {
                        if (db2.DbDataType(item.DOTNETTYPE) == "nvarchar")
                        {
                            str.AppendFormat("{0} {1}({2}),", item.FIELDNAME, "nvarchar", item.OUTPUTLEN + item.DECIMALS);

                        }
                        else
                        {
                            str.AppendFormat("{0} {1},", item.FIELDNAME, db2.DbDataType(item.DOTNETTYPE));
                        }

                    }
                    else
                    {
                        if (db2.DbDataType(item.DOTNETTYPE) == "nvarchar")
                        {
                            str.AppendFormat("{0} {1}({2}),", item.FIELDNAME, "nvarchar", item.OUTPUTLEN + item.DECIMALS);
                        }
                        else
                        {
                            str.AppendFormat("{0} {1},", item.FIELDNAME, db2.DbDataType(item.DOTNETTYPE));
                        }
                    }

                }
                str.Remove(str.Length - 1, 1);//注意这里是倒数第一个，还有一个空格
                str.Append(" )");

                // cmd.CommandText = buidCreateTableString(db2);
                log.Info("SQL 创建表语句： " + str.ToString());
            }
            return str.ToString();

        }


        /// <summary>
        /// 保存一个DataTable 到数据库
        /// </summary>
        /// <param name="dtToSaved"></param>
        private bool InsertDataTablaToGeneraDb()
        {

            sendMessage("将数据插入一般数据库");
            using (DbCommand cmd = db2.CreateCommand())
            {
                cmd.Connection.Open();

                cmd.Parameters.Add(cmd.CreateParameter());// for the SAPSYS field
                sendMessage("变量准备");
                foreach (var item in rfcTableInfo.Fields)
                {
                    cmd.Parameters.Add(cmd.CreateParameter());
                }

                cmd.CommandText = buildInsertIntoString();
                //使用事务

                sendMessage("事务开始");
                DbTransaction trans = cmd.Connection.BeginTransaction();// <-------------------
                cmd.Transaction = trans;
                try
                {
                    for (int x = 0; x < dtToSaved.Rows.Count; x++)
                    {
                        if (dtToSaved.Rows[x] == null)
                        {
                            continue;
                        }
                        cmd.Parameters[0].Value = SystemName;
                        for (int i = 0; i < rfcTableInfo.Fields.Count; i++)
                        {

                            cmd.Parameters[i + 1].Value = dtToSaved.Rows[x][i];

                        }
                        cmd.ExecuteNonQuery();
                    }
                    trans.Commit(); // <-------------------
                    cmd.Connection.Close();
                    sendMessage("事务结束");
                    return true;
                }
                catch (Exception e)
                {
                    trans.Rollback(); // <-------------------
                    cmd.Connection.Close();
                    sendMessage("事务回滚");
                    throw new Exception(e.Message); // <-------------------
                }

            }


        }
        /// <summary>
        /// OleDb类型的数据库要单独处理，因为它的修改的方式不一样
        /// </summary>
        /// <param name="dtToSaved"></param>
        private bool InsertDataToOleDb()
        {
            DbCommand cmd = db2.CreateCommand();
            cmd.Connection = db2.CreateConnection();
            cmd.Connection.Open();

            cmd.CommandText = buildInsertIntoString();

            cmd.Parameters.Add(cmd.CreateParameter());//for the SAPSYS field
            foreach (var item in rfcTableInfo.Fields)
            {
                cmd.Parameters.Add(cmd.CreateParameter());
            }

            DbTransaction trans = cmd.Connection.BeginTransaction();// <-------------------
            cmd.Transaction = trans;

            try
            {
                for (int x = 0; x < dtToSaved.Rows.Count; x++)
                {
                    if (dtToSaved.Rows[x] == null)
                    {
                        continue;
                    }
                    cmd.Parameters[0].Value = SystemName;
                    for (int i = 0; i < rfcTableInfo.Fields.Count; i++)
                    {
                        cmd.Parameters[i + 1].Value = dtToSaved.Rows[x][i];

                    }
                    cmd.ExecuteNonQuery();
                }
                trans.Commit(); // <-------------------
                cmd.Connection.Close();

            }

            catch (Exception e)
            {
                trans.Rollback(); // <-------------------
                cmd.Connection.Close();
                throw new Exception(e.Message); // <-------------------
            }
            cmd.Connection.Close();
            cmd.Connection.Dispose();
            cmd.Dispose();
            return true;
        }

        private bool InsertDataTableToSqlServer2()
        {
            sendMessage("将数据插入SqlServer");

            using (DbCommand cmd = db2.CreateCommand())
            {
                cmd.Connection.Open();

                DbParameter para = cmd.CreateParameter();
                para.ParameterName = "@p1";
                cmd.Parameters.Add(para);

                int j = 2;
                sendMessage("准备变量");
                foreach (var item in rfcTableInfo.Fields)
                {
                    //特别要注意要声明变量。
                    para = cmd.CreateParameter();
                    para.ParameterName = "@p" + j;
                    cmd.Parameters.Add(para);
                    j++;
                }

                cmd.CommandText = buildInsertIntoString();
                //使用事务

                sendMessage("开始事务");
                DbTransaction trans = cmd.Connection.BeginTransaction();// <-------------------

                //  var debugstr = string.Empty;
                cmd.Transaction = trans;
                try
                {
                    for (int x = 0; x < dtToSaved.Rows.Count; x++)
                    {
                        //   Console.WriteLine(x.ToString());
                        if (dtToSaved.Rows[x] == null)
                        {
                            continue;
                        }
                        cmd.Parameters[0].Value = SystemName;
                        for (int i = 0; i < rfcTableInfo.Fields.Count; i++)
                        {
                            //  log.InfoFormat("字段{0},定义长度{1},值{2},实际长度{3}", rfcTableInfo.Fields[i].FIELDNAME, rfcTableInfo.Fields[i].OUTPUTLEN, dtToSaved.Rows[x][i], dtToSaved.Rows[x][i].ToString().Length);

                            cmd.Parameters[i + 1].Value = dtToSaved.Rows[x][i];



                        }

                        log.InfoFormat("Command Text {0}", cmd.CommandText);
                        cmd.ExecuteNonQuery();

                    }
                    trans.Commit(); // <-------------------
                    cmd.Connection.Close();
                    sendMessage("事务结束");
                    return true;
                }
                catch (Exception e)
                {
                    trans.Rollback(); // <-------------------
                    cmd.Connection.Close();
                    sendMessage("事务回滚");
                    throw new Exception(e.Message); // <-------------------
                }

            }
        }
        private bool InsertDataTableToSqlServer()
        {
            try
            {
                //String sql = "";
                //foreach (var item in rfcTableInfo.Fields)
                //{
                //    sql = sql + String.Format("[{0}] ", item.FIELDNAME);
                //}
                //sql = "Select " + sql + "from " + this.TableName;

                db2.DataTableUpdate(dtToSaved, String.Format("Select * from {0}", this.TableName));
                // db2.DataTableUpdate(dtToSaved, sql);
                // db2.ErrorMessage
            }
            catch (Exception ee)
            {

                throw new SAPException(ee.Message);
            }
            return true;

        }
        /// <summary>
        /// 可能DATA TABLE 的列数比字段列表
        /// </summary>
        private void HandleTableFields()
        {
            sendMessage("替换rfcTableInfo字段名称中的'/'为'_'");

            rfcTableInfo.Fields.ForEach(row =>
            {
                row.DOTNETTYPE = row.DOTNETTYPE.Replace("System.", "");
                row.FIELDNAME = row.FIELDNAME.Replace("/", "_");
            });

            List<SAPINT.RFCTable.TableField> FieldList = new List<SAPINT.RFCTable.TableField>();
            sendMessage("替换DataColumn字段名称中的'/'为'_'");
            foreach (DataColumn col in dtToSaved.Columns)
            {
                col.ColumnName = col.ColumnName.Replace("/", "_");
                FieldList.Add(rfcTableInfo.Fields.Find(field => field.FIELDNAME == col.ColumnName));
            }

            rfcTableInfo.Fields.Clear();

            sendMessage("重新构建一个字段列表");
            FieldList.ForEach(field => rfcTableInfo.Fields.Add(field));
            // rfcTableInfo.Fields.AddRange(FieldList);
        }

        public bool CreateNewTable()
        {
            sendMessage("创建新的数据库表");
            DbCommand cmd = db2.CreateCommand();
            cmd.Connection = db2.CreateConnection();
            cmd.Connection.Open();
            try
            {


                if (db2.ProviderType == netlib7.ProviderTypes.OleDB)
                {
                    try
                    {
                       // if (!checkTableIsExist())
                       // {
                            cmd.CommandText = "DROP TABLE " + this.TableName;
                            cmd.ExecuteNonQuery();
                            sendMessage("删除数据库表" + this.TableName);
                      //  }

                        
                    }
                    catch (Exception)
                    {

                        // throw;
                    }
                    cmd.CommandText = buidCreateTableString();
                    cmd.ExecuteNonQuery();


                }
                else if (db2.ProviderType == netlib7.ProviderTypes.SqlServer)
                {

                    cmd.CommandText = String.Format(
                    @"IF  EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME= '{0}')
                     DROP TABLE {0}", this.TableName);
                    cmd.ExecuteNonQuery();
                    sendMessage("删除数据库表" + this.TableName);

                    cmd.CommandText = buidCreateTableString();
                    cmd.ExecuteNonQuery();

                }
                else
                {
                    cmd.Connection = db2.CreateConnection();
                    cmd.Connection.Open();

                    cmd.CommandText = "drop table if exists " + this.TableName;
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = buidCreateTableString();
                    cmd.ExecuteNonQuery();
                    sendMessage("删除数据库表" + this.TableName);

                }

                cmd.Connection.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
                sendMessage(ex.Message);
                return false;
            }

        }
        private bool checkTableIsExist()
        {
            sendMessage("检查表是否存在");
            int i = 0;
            String sql = "";
            sendMessage("数据库类型:" + db2.ProviderType.ToString());
            if (db2.ProviderType == netlib7.ProviderTypes.SqlServer)
            {
                sql = String.Format("select count(*) from sysobjects where id = object_id('{0}')", this.TableName);

            }
            else if (db2.ProviderType == netlib7.ProviderTypes.MySql)
            {
                sql = string.Format("select COUNT(TABLE_NAME) from INFORMATION_SCHEMA.TABLES where TABLE_NAME ='{0}'", this.TableName);
            }
            else if (db2.ProviderType == netlib7.ProviderTypes.SQLite)
            {
                sql = string.Format("SELECT count(*) FROM sqlite_master WHERE type='table' AND name='{0}'", this.TableName);

            }
            else if (db2.ProviderType == netlib7.ProviderTypes.OleDB)
            {
                sql = string.Format("select COUNT(*) from MSysObjects where name='{0}'", this.TableName);
            }
            else
            {
                throw new SAPException(db2.ProviderType + "不支持！！");
            }
            Object result = this.db2.ExecScalar(sql);
            ErrorMessage = db2.ErrorMessage;
            if (!String.IsNullOrEmpty(ErrorMessage))
            {
                sendMessage(ErrorMessage);
            }
            if (result != null)
            {
                i = int.Parse(result.ToString());
            }

            if (i > 0)
            {

                return true;
            }
            else
            {
                return false;
            }

        }

        private bool InserDataTableTodb()
        {
            sendMessage("将数据插入数据库");
            if (db2.ProviderType == netlib7.ProviderTypes.OleDB)
            {
                return InsertDataToOleDb();

            }
            else if (db2.ProviderType == netlib7.ProviderTypes.SqlServer)
            {

                return InsertDataTableToSqlServer2();
            }
            else
            {

                return InsertDataTablaToGeneraDb();

            }

        }
        public void setDataTable(DataTable dt)
        {
            dtToSaved = dt;
            if (dtToSaved == null)
            {
                throw new SAPException("DataTable为NULL");
            }
            prepareFieldsFromDataTable();

        }
        //把一个DATATABLE保存到数据库
        public bool SaveDataTable(DataTable dt)
        {
            sendMessage("数据保存开始==========================>");
            setDataTable(dt);

            //  String defaultDb = null;
            if (String.IsNullOrWhiteSpace(DbConnectionString))
            {

                DbConnectionString = ConfigFileTool.SAPGlobalSettings.GetDefaultDbConnection();
            }
            //defaultDb = ConfigFileTool.SAPGlobalSettings.GetDefaultDb();
            if (string.IsNullOrWhiteSpace(DbConnectionString))
            {
                sendMessage("没有配置默认的数据库连接！！");
                throw new SAPException("没有配置默认的数据库连接！！");
            }

            sendMessage("数据连接字符串:" + DbConnectionString);
            db2 = new netlib7(DbConnectionString);
            db2.LogEvents = true;

            bool isCreated = false;
            if (!_appendToDb || _newTable)
            {
                isCreated = CreateNewTable();
            }
            else if (!checkTableIsExist())
            {
                isCreated = CreateNewTable();

            }

            if (!isCreated)
            {
                return false;
            }
            try
            {
                InserDataTableTodb();
                sendMessage("数据结束开始==========================>");
                this.ErrorMessage = db2.ErrorMessage;

                if (String.IsNullOrWhiteSpace(ErrorMessage))
                {
                    sendMessage("保存成功");
                    return true;
                }
                else
                    sendMessage("出错啦" + ErrorMessage);
                return false;
            }

            catch (Exception exception)
            {
                ErrorMessage = exception.Data + exception.StackTrace + exception.Message;
                // log.Error(ErrorMessage);
                sendMessage(exception.Message);
                return false;
            }
        }
    }
}

