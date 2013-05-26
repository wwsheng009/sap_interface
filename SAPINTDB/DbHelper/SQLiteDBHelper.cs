//namespace SAPINT.DbHelper
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Data;
//    using System.Data.Common;
//    using System.Data.SQLite;
//    using System.Linq;
//    using System.Text;
//    /// <summary>  
//    /// 说明：这是一个针对System.Data.SQLite的数据库常规操作封装的通用类。  
//    /// 作者：zhoufoxcn(周公）  
//    /// 日期：2010-04-01  
//    /// Blog:http://zhoufoxcn.blog.51cto.com or http://blog.csdn.net/zhoufoxcn  
//    /// Version:0.1  
//    /// </summary>  
//    public class SQLiteDBHelper
//    {
//        #region Fields
//        private string connectionString = string.Empty;
//        #endregion Fields
//        #region Constructors
//        /// <summary>  
//        /// 构造函数  
//        /// </summary>  
//        /// <param name="dbPath">SQLite数据库文件路径</param>  
//        public SQLiteDBHelper(string dbPath)
//        {
//            this.connectionString = "Data Source=" + dbPath;
//        }
//        #endregion Constructors
//        #region Methods
//        /// <summary>  
//        /// 创建SQLite数据库文件  
//        /// </summary>  
//        /// <param name="dbPath">要创建的SQLite数据库文件路径</param>  
//        public static void CreateDB(string dbPath)
//        {
//            using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + dbPath))
//            {
//                connection.Open();
//                using (SQLiteCommand command = new SQLiteCommand(connection))
//                {
//                    command.CommandText = "CREATE TABLE Demo(id integer NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE)";
//                    command.ExecuteNonQuery();
//                    command.CommandText = "DROP TABLE Demo";
//                    command.ExecuteNonQuery();
//                }
//            }
//        }
//        /// <summary>  
//        /// 执行一个查询语句，返回一个包含查询结果的DataTable  
//        /// </summary>  
//        /// <param name="sql">要执行的查询语句</param>  
//        /// <param name="parameters">执行SQL查询语句所需要的参数，参数必须以它们在SQL语句中的顺序为准</param>  
//        /// <returns></returns>  
//        public DataTable ExecuteDataTable(string sql, SQLiteParameter[] parameters)
//        {
//            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
//            {
//                connection.Open();
//                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
//                {
//                    if (parameters != null)
//                    {
//                        command.Parameters.AddRange(parameters);
//                    }
//                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
//                    DataTable data = new DataTable();
//                    adapter.Fill(data);
//                    return data;
//                }
//            }
//        }
//        /// <summary>  
//        /// 对SQLite数据库执行增删改操作，返回受影响的行数。  
//        /// </summary>  
//        /// <param name="sql">要执行的增删改的SQL语句</param>  
//        /// <param name="parameters">执行增删改语句所需要的参数，参数必须以它们在SQL语句中的顺序为准</param>  
//        /// <returns></returns>  
//        public int ExecuteNonQuery(string sql, SQLiteParameter[] parameters)
//        {
//            int affectedRows = 0;
//            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
//            {
//                connection.Open();
//                using (DbTransaction transaction = connection.BeginTransaction())
//                {
//                    using (SQLiteCommand command = new SQLiteCommand(connection))
//                    {
//                        command.CommandText = sql;
//                        if (parameters != null)
//                        {
//                            command.Parameters.AddRange(parameters);
//                        }
//                        affectedRows = command.ExecuteNonQuery();
//                    }
//                    transaction.Commit();
//                }
//            }
//            return affectedRows;
//        }
//        /// <summary>  
//        /// 执行一个查询语句，返回一个关联的SQLiteDataReader实例  
//        /// </summary>  
//        /// <param name="sql">要执行的查询语句</param>  
//        /// <param name="parameters">执行SQL查询语句所需要的参数，参数必须以它们在SQL语句中的顺序为准</param>  
//        /// <returns></returns>  
//        public SQLiteDataReader ExecuteReader(string sql, SQLiteParameter[] parameters)
//        {
//            SQLiteConnection connection = new SQLiteConnection(connectionString);
//            SQLiteCommand command = new SQLiteCommand(sql, connection);
//            if (parameters != null)
//            {
//                command.Parameters.AddRange(parameters);
//            }
//            connection.Open();
//            return command.ExecuteReader(CommandBehavior.CloseConnection);
//        }
//        /// <summary>  
//        /// 执行一个查询语句，返回查询结果的第一行第一列  
//        /// </summary>  
//        /// <param name="sql">要执行的查询语句</param>  
//        /// <param name="parameters">执行SQL查询语句所需要的参数，参数必须以它们在SQL语句中的顺序为准</param>  
//        /// <returns></returns>  
//        public Object ExecuteScalar(string sql, SQLiteParameter[] parameters)
//        {
//            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
//            {
//                connection.Open();
//                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
//                {
//                    if (parameters != null)
//                    {
//                        command.Parameters.AddRange(parameters);
//                    }
//                    return command.ExecuteScalar();
//                    // return command.ExecuteReader(CommandBehavior.CloseConnection);
//                    //SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
//                    //DataTable data = new DataTable();
//                    //adapter.Fill(data);
//                    //return data;
//                }
//            }
//        }
//        /// <summary>  
//        /// 查询数据库中的所有数据类型信息  
//        /// </summary>  
//        /// <returns></returns>  
//        public DataTable GetSchema()
//        {
//            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
//            {
//                connection.Open();
//                DataTable data = connection.GetSchema("TABLES");
//                connection.Close();
//                //foreach (DataColumn column in data.Columns)
//                //{
//                //    Console.WriteLine(column.ColumnName);
//                //}
//                return data;
//            }
//        }
//        #endregion Methods
//    }
//}
