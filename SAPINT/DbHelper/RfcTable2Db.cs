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
//    /// <summary>
//    /// 用于处理RFC接口中的表，把RFC表保存到本地数据库中。
//    /// </summary>
//    public class RfcTableToDb
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
//        public RfcTableToDb(String dbname, string tableName,IRfcTable tble)
//        {
//            if (tble == null)
//            {
//                return;
//            }
//            this._dbname = dbname;
//            this.tableName = tableName;
//            this.RfcTable = tble;
//            this.tableType = RfcTable.Metadata;
//            this.lineType = RfcTable.Metadata.LineType;
//            this.lines = tble.ToList();
//        }
//        private RfcTableToDb()
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
//                    this._dbname = "RFCTABLE";
//                }
//                else
//                {
//                    this._dbname = value;
//                }
//            }
//        }
//        private List<IRfcStructure> lines
//        {
//            get; set;
//        }
//        private RfcStructureMetadata lineType
//        {
//            get; set;
//        }
//        private IRfcTable RfcTable
//        {
//            get; set;
//        }
//        private string tableName
//        {
//            get;set;
//        }
//        private RfcTableMetadata tableType
//        {
//            get; set;
//        }
//        #endregion Properties
//        #region Methods
//        ////转换数据格式，一般不需要。
//        //public static object mapData(IRfcField field)
//        //{
//        //    if (field ==null)
//        //    {
//        //        return null;
//        //    }
//        //    var fieldValue = field.GetValue();
//        //    object o = fieldValue;
//        //    switch (field.Metadata.DataType)
//        //    {
//        //        case RfcDataType.BCD:
//        //            o = fieldValue;
//        //            break;
//        //        case RfcDataType.BYTE:
//        //            o = Convert.ToByte(fieldValue);
//        //            break;
//        //        case RfcDataType.CDAY:
//        //            o = fieldValue;
//        //            break;
//        //        case RfcDataType.CHAR:
//        //            o = fieldValue.ToString();
//        //            break;
//        //        case RfcDataType.CLASS:
//        //            o = fieldValue.ToString();
//        //            break;
//        //        case RfcDataType.DATE:
//        //            if (fieldValue.ToString() == "0000-00-00")
//        //            {
//        //                o = DateTime.MinValue;
//        //            }
//        //            else if (fieldValue.ToString() == "9999-99-99")
//        //            {
//        //                o = DateTime.MaxValue;
//        //            }
//        //            else {
//        //                o = Convert.ToDateTime(fieldValue).ToString("s");
//        //            }
//        //            break;
//        //        case RfcDataType.DECF16:
//        //            o = fieldValue;
//        //            break;
//        //        case RfcDataType.DECF34:
//        //            o = fieldValue;
//        //            break;
//        //        case RfcDataType.DTDAY:
//        //            if (fieldValue.ToString() == "0000-00-00")
//        //            {
//        //                o = DateTime.MinValue;
//        //            }
//        //            else if (fieldValue.ToString() == "9999-99-99")
//        //            {
//        //                o = DateTime.MaxValue;
//        //            }
//        //            else
//        //            {
//        //                o = Convert.ToDateTime(fieldValue).ToString("s");
//        //            }
//        //            break;
//        //        case RfcDataType.DTMONTH:
//        //            o = fieldValue;
//        //            break;
//        //        case RfcDataType.DTWEEK:
//        //            o = fieldValue;
//        //            break;
//        //        case RfcDataType.FLOAT:
//        //            o = Convert.ToDouble(fieldValue);
//        //            break;
//        //        case RfcDataType.INT1:
//        //            o = Convert.ToInt32(fieldValue);
//        //            break;
//        //        case RfcDataType.INT2:
//        //            o = fieldValue;
//        //            break;
//        //        case RfcDataType.INT4:
//        //            o = fieldValue;
//        //            break;
//        //        case RfcDataType.INT8:
//        //            o = fieldValue;
//        //            break;
//        //        case RfcDataType.NUM:
//        //            o = fieldValue;
//        //            break;
//        //        case RfcDataType.STRING:
//        //            o = fieldValue;
//        //            break;
//        //        case RfcDataType.STRUCTURE:
//        //            o = fieldValue.ToString();
//        //            break;
//        //        case RfcDataType.TABLE:
//        //            o = fieldValue.ToString();
//        //            break;
//        //        case RfcDataType.TIME:
//        //            o = Convert.ToDateTime(fieldValue);
//        //            break;
//        //        case RfcDataType.TMINUTE:
//        //            o = fieldValue;
//        //            break;
//        //        case RfcDataType.TSECOND:
//        //            o = fieldValue;
//        //            break;
//        //        case RfcDataType.UNKNOWN:
//        //            o = fieldValue;
//        //            break;
//        //        case RfcDataType.UTCLONG:
//        //            o = fieldValue;
//        //            break;
//        //        case RfcDataType.UTCMINUTE:
//        //            o = fieldValue;
//        //            break;
//        //        case RfcDataType.UTCSECOND:
//        //            o = fieldValue;
//        //            break;
//        //        case RfcDataType.XSTRING:
//        //            o = fieldValue;
//        //            break;
//        //        default:
//        //            o = fieldValue;
//        //            break;
//        //    }
//        //    return o;
//        //}
//        /// <summary>
//        /// 映射接口的类型
//        /// </summary>
//        /// <param name="type"></param>
//        /// <returns></returns>
//        public static SqlDbType mapDataType(RfcDataType type)
//        {
//            SqlDbType sqlType = SqlDbType.VarChar;
//            switch (type)
//            {
//                case RfcDataType.BCD:
//                    sqlType = SqlDbType.Decimal;
//                    break;
//                case RfcDataType.BYTE:
//                    sqlType = SqlDbType.Binary;
//                    break;
//                case RfcDataType.CDAY:
//                    sqlType = SqlDbType.Date;
//                    break;
//                case RfcDataType.CHAR:
//                    sqlType = SqlDbType.Char;
//                    break;
//                case RfcDataType.CLASS:
//                    sqlType = SqlDbType.VarBinary;
//                    break;
//                    //把日期转换成字符串，因为在SQLITE中，日期处理比较麻烦。
//                case RfcDataType.DATE:
//                    sqlType = SqlDbType.VarChar;
//                    break;
//                case RfcDataType.DECF16:
//                    sqlType = SqlDbType.Decimal;
//                    break;
//                case RfcDataType.DECF34:
//                    sqlType = SqlDbType.Decimal;
//                    break;
//                    //把日期转换在字符串，
//                case RfcDataType.DTDAY:
//                    sqlType = SqlDbType.VarChar;
//                    break;
//                case RfcDataType.DTMONTH:
//                    sqlType = SqlDbType.Date;
//                    break;
//                case RfcDataType.DTWEEK:
//                    sqlType = SqlDbType.Date;
//                    break;
//                case RfcDataType.FLOAT:
//                    sqlType = SqlDbType.Float;
//                    break;
//                case RfcDataType.INT1:
//                    sqlType = SqlDbType.Int;
//                    break;
//                case RfcDataType.INT2:
//                    sqlType = SqlDbType.Int;
//                    break;
//                case RfcDataType.INT4:
//                    sqlType = SqlDbType.Int;
//                    break;
//                case RfcDataType.INT8:
//                    sqlType = SqlDbType.Int;
//                    break;
//                case RfcDataType.NUM:
//                    sqlType = SqlDbType.Decimal;
//                    break;
//                case RfcDataType.STRING:
//                    sqlType = SqlDbType.VarChar;
//                    break;
//                case RfcDataType.STRUCTURE:
//                    sqlType = SqlDbType.VarBinary;
//                    break;
//                case RfcDataType.TABLE:
//                    sqlType = SqlDbType.VarBinary;
//                    break;
//                case RfcDataType.TIME:
//                    sqlType = SqlDbType.Time;
//                    break;
//                case RfcDataType.TMINUTE:
//                    sqlType = SqlDbType.Time;
//                    break;
//                case RfcDataType.TSECOND:
//                    sqlType = SqlDbType.Time;
//                    break;
//                case RfcDataType.UNKNOWN:
//                    sqlType = SqlDbType.VarBinary;
//                    break;
//                case RfcDataType.UTCLONG:
//                    sqlType = SqlDbType.VarBinary;
//                    break;
//                case RfcDataType.UTCMINUTE:
//                    sqlType = SqlDbType.Time;
//                    break;
//                case RfcDataType.UTCSECOND:
//                    sqlType = SqlDbType.Time;
//                    break;
//                case RfcDataType.XSTRING:
//                    sqlType = SqlDbType.VarChar;
//                    break;
//                default:
//                    break;
//            }
//            return sqlType;
//        }
//        public static DateTime SAPDate2NetDate(string Date)
//        {
//            if (!string.IsNullOrEmpty(Date))
//            {
//                DateTime time;
//                if (Date.Length < 8)
//                {
//                    return DateTime.MinValue;
//                }
//                if (Date == "00000000")
//                {
//                    return DateTime.MinValue;
//                }
//                if (Date == "99999999")
//                {
//                    return DateTime.MaxValue;
//                }
//                if (DateTime.TryParseExact(Date, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out time))
//                {
//                    return time;
//                }
//            }
//            return DateTime.MinValue;
//        }
//        //可以外部进行多线程调用，这样更快。
//        public void saveTable()
//        {
//            if (string.IsNullOrEmpty(DbName))
//            {
//                return;
//            }
//            if (RfcTable != null)
//            {
//                saveRfcTable();
//            }
//        }
//        //构造一个创建表的command text.
//        private string buidCreateTableString()
//        {
//            StringBuilder str = new StringBuilder("CREATE TABLE");
//            str.AppendFormat(" {0}", this.tableName);
//            str.Append("([idd] integer NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,");
//            // var sqlstr = @"CREATE TABLE Test3(id integer NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,N
//            for (int i = 0; i < lineType.FieldCount; i++)
//            {
//                RfcFieldMetadata field = lineType[i];
//                RfcDataType type = field.DataType;
//                var sqltype = mapDataType(type);
//                if (sqltype == SqlDbType.Time || sqltype == SqlDbType.DateTime || sqltype == SqlDbType.Date || sqltype == SqlDbType.SmallDateTime)
//                {
//                    str.AppendFormat(" {0} {1} , ", field.Name, sqltype, field.NucLength);
//                }
//                else
//                {
//                    str.AppendFormat(" {0} {1}({2}), ", field.Name, sqltype, field.NucLength);
//                }
//            }
//            str.Remove(str.Length - 2, 1);//注意这里是倒数第一个，还有一个空格
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
//            for (int i = 0; i < lineType.FieldCount; i++)
//            {
//                insertStr.AppendFormat("{0},", lineType[i].Name);
//            }
//            insertStr.Remove(insertStr.Length - 1, 1);//注意去除最后一个，
//            insertStr.Append(")values(");
//            for (int i = 0; i < lineType.FieldCount; i++)
//            {
//                insertStr.Append("?,");
//            }
//            insertStr.Remove(insertStr.Length - 1, 1);
//            insertStr.Append(")");
//            return insertStr.ToString();
//        }
//        //test linq
//        private void rfcTable2List()
//        {
//            foreach (var line in lines)
//            {
//                var fields = line.ToList();
//                foreach (var field in fields)
//                {
//                    field.GetValue();
//                }
//                for (int i = 0; i < line.Metadata.FieldCount; i++)
//                {
//                    var value = line[i].GetValue();
//                }
//            }
//        }
//        //把IRFCTABLE中的内容全部保存到数据库中。
//        private void saveRfcTable()
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
//                for (int i = 0; i < lineType.FieldCount; i++)
//                {
//                    cmd.Parameters.Add(cmd.CreateParameter());
//                }
//                cmd.CommandText = buildInsertIntoString();
//                //使用事务
//                 DbTransaction trans = conn.BeginTransaction();// <-------------------
//                    try
//                    {
//                        for (int x = 0; x < lines.Count; x++)
//                        {
//                            for (int i = 0; i < lineType.FieldCount; i++)
//                            {
//                                // insertStr.AppendFormat("'{0}',", tble[x][i].GetValue());不要使用这种方法，有单引号或是其它特殊符号就会出错。
//                                //  cmd.Parameters.Add(cmd.CreateParameter());
//                                //cmd.Parameters[i].Value = tble[x][i].GetValue();
//                                //IRfcField field = lines[x][i];
//                                   //field.Metadata.DataType
//                                cmd.Parameters[i].Value = lines[x][i].GetValue();
//                               // cmd.Parameters[i].Value = mapData(lines[x][i]);
//                            }
//                            cmd.ExecuteNonQuery();
//                        }
//                        trans.Commit(); // <-------------------
//                    }
//                    catch(Exception e)
//                    {
//                        trans.Rollback(); // <-------------------
//                        throw new Exception(e.Message); // <-------------------
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