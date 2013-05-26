//namespace SAPINT.DbHelper
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Data;
//    using System.Data.Common;
//    using System.Data.SQLite;
//    using System.Diagnostics;
//    using System.Globalization;
//    using System.IO;
//    using System.Linq;
//    using System.Text;
//    using SAP.Middleware.Connector;
//    using SAPINT.Queries;
//    /// <summary>
//    /// 用于处理RFC接口中的表，把RFC表保存到本地数据库中。
//    /// </summary>
//    public class DataTable2Sqlite
//    {
//        #region Fields
//        private string _dbname;
//        #endregion Fields
//        #region Constructors
//        /// <summary>
//        /// 初始类，传入RFC表，与数据库名
//        /// </summary>
//        /// <param name="dbname"></param>
//        /// <param name="tble"></param>
//        public DataTable2Sqlite(String dbname, string tableName,DataTable tble)
//        {
//            if (tble == null)
//            {
//                return;
//            }
//            this._dbname = dbname;
//            this.tableName = tableName;
//            this.dt = tble;
//        }
//        private DataTable2Sqlite()
//        {
//            // TODO: Complete member initialization
//        }
//        #endregion Constructors
//        #region Properties
//        public String DbName
//        {
//            get
//            {
//                return _dbname;
//            }
//               internal set
//            {
//                if (string.IsNullOrEmpty(DbName))
//                {
//                    this._dbname = "SAP_QUERIES";
//                }
//                else
//                {
//                    this._dbname = value;
//                }
//            }
//        }
//        private DataTable dt
//        {
//            get; set;
//        }
//        private string tableName
//        {
//            get;set;
//        }
//        #endregion Properties
//        #region Methods
//        //可以外部进行多线程调用，这样更快。
//        public void saveTable()
//        {
//            if (string.IsNullOrEmpty(DbName))
//            {
//                return;
//            }
//            if (dt != null)
//            {
//                saveDataTable();
//            }
//        }
//        //构造一个创建表的command text.
//        private string buidCreateTableString()
//        {
//            StringBuilder str = new StringBuilder("CREATE TABLE");
//            str.AppendFormat(" {0}", this.tableName);
//            str.Append("([id] integer NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,");
//            // var sqlstr = @"CREATE TABLE Test3(id integer NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,N
//            foreach (DataColumn dc in dt.Columns)
//            {
//               string[] name = dc.ColumnName.Split('-');
//               if (name.Count() == 2)
//               {
//                   str.AppendFormat(" {0} {1} ,", name[1], DbTypeConvertor.ToSqlDbType(dc.DataType), dc.MaxLength);
//               }
//               else
//               {
//                   str.AppendFormat(" {0} {1} ,", name[0], DbTypeConvertor.ToSqlDbType(dc.DataType), dc.MaxLength);
//               }
//            }
//            str.Remove(str.Length - 1, 1);//注意这里是倒数第一个，还有一个空格
//            str.Append(" )");
//            return str.ToString();
//        }
//        //根据表创建Insert Into String
//        private string buildInsertIntoString()
//        {
//            //建立插入语句
//            StringBuilder insertStr = new StringBuilder("INSERT INTO ");
//            insertStr.AppendFormat("{0}", this.tableName);
//            insertStr.Append("(");
//            for (int i = 0; i < dt.Columns.Count; i++)
//            {
//                string[] name = dt.Columns[i].ColumnName.Split('-');
//                if (name.Count() == 2)
//                {
//                    insertStr.AppendFormat("{0},", name[1]);
//                }
//                else
//                {
//                    insertStr.AppendFormat("{0},", name[0]);
//                }
//            }
//            insertStr.Remove(insertStr.Length - 1, 1);//注意去除最后一个，
//            insertStr.Append(")values(");
//            for (int i = 0; i < dt.Columns.Count; i++)
//            {
//                insertStr.Append("?,");
//            }
//            insertStr.Remove(insertStr.Length - 1, 1);
//            insertStr.Append(")");
//            return insertStr.ToString();
//        }
//        //把IRFCTABLE中的内容全部保存到数据库中。
//        private void saveDataTable()
//        {
//            string _dbFile = "E:\\wangws";
//            _dbFile = _dbFile + "\\" + DbName + ".db";
//            //if (File.Exists(_dbFile)) {
//            //    File.Delete(_dbFile);
//            //}
//            if (!File.Exists(_dbFile))
//            {
//                SQLiteConnection.CreateFile(_dbFile);
//            }
//            DbProviderFactory factory = SQLiteFactory.Instance;
//            using (DbConnection conn = factory.CreateConnection())
//            {
//                // 连接数据库
//                conn.ConnectionString = "Data Source=" + _dbFile;
//                conn.Open();
//                // 创建数据表
//                //  string sql = "create table [person] ([id] INTEGER PRIMARY KEY, [name] varchar(50) COLLATE NOCASE)";
//                DbCommand cmd = conn.CreateCommand();
//                cmd.Connection = conn;
//                cmd.CommandText = "drop table if exists " + this.tableName;
//                cmd.ExecuteNonQuery();
//                cmd.CommandText = buidCreateTableString();
//                cmd.ExecuteNonQuery();
//                // 添加参数
//                // 开始计时
//                //  Stopwatch watch = new Stopwatch();
//                //  watch.Start();
//                //按字段的多少新建参数
//                for (int i = 0; i < dt.Columns.Count; i++)
//                {
//                    cmd.Parameters.Add(cmd.CreateParameter());
//                }
//                cmd.CommandText = buildInsertIntoString();
//                //使用事务
//                 DbTransaction trans = conn.BeginTransaction();// <-------------------
//                    try
//                    {
//                        for (int x = 0; x < dt.Rows.Count; x++)
//                        {
//                            for (int i = 0; i < dt.Columns.Count; i++)
//                            {
//                                // insertStr.AppendFormat("'{0}',", tble[x][i].GetValue());不要使用这种方法，有单引号或是其它特殊符号就会出错。
//                                //  cmd.Parameters.Add(cmd.CreateParameter());
//                                //cmd.Parameters[i].Value = tble[x][i].GetValue();
//                                //IRfcField field = lines[x][i];
//                                   //field.Metadata.DataType
//                                cmd.Parameters[i].Value = dt.Rows[x][i];
//                             //   cmd.Parameters[i].Value = lines[x][i].GetValue();
//                               // cmd.Parameters[i].Value = mapData(lines[x][i]);
//                            }
//                            cmd.ExecuteNonQuery();
//                        }
//                        trans.Commit(); // <-------------------
//                    }
//                    catch(Exception e)
//                    {
//                        trans.Rollback(); // <-------------------
//                        throw; // <-------------------
//                    }
//                }
//                // 停止计时
//                //  watch.Stop();
//                //  Console.WriteLine(watch.Elapsed);
//                //  Console.Read();
//        }
//        #endregion Methods
//    }
//}
