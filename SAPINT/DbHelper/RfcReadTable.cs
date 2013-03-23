//namespace SAPINT.DbHelper
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Data;
//    using System.IO;
//    using System.Linq;
//    using System.Text;
//    using Newtonsoft.Json;
//    using SAPINT.Function;
//    /// <summary>
//    /// 读取已经保存到本地SQLITE数据库的RFC函数列表
//    /// </summary>
//    public class SqliteReadTable
//    {
//        #region Fields
//        const string DBLOCATION = "E:\\wangws";
//        #endregion Fields
//        #region Methods
//        //查询RFC函数列表，本地已经保存所有的RFC函数列表，
//        //根据函数名称可模糊查询函数，最后返回Json列表
//        public static string getRFCList(string sysName,string fname)
//        {
//            string _dbFile = "E:\\wangws";
//            _dbFile = _dbFile + "\\" + "RFC_FUNCTIONS" + ".db";
//            if (!File.Exists(_dbFile))
//            {
//                SAPFunction.GetRFCfunctionListAndSaveToSqliteDb(sysName, "");
//            }
//           // SQLiteDBHelper helper = new SQLiteDBHelper(_dbFile);
//           // string sqlstr = string.Format("select [FUNCNAME],[STEXT] from [FUNCTIONS] where funcname like '%{0}%' limit 10", fname);
//           // DataTable dt = helper.ExecuteDataTable(sqlstr, null);
//          //  var output = JsonConvert.SerializeObject(dt);
//          //  return output;
//        }
//        /// <summary>
//        /// 用于读取特定分页的内容。
//        /// </summary>
//        /// <param name="dbname">数据库名字</param>
//        /// <param name="tableName">数据表名</param>
//        /// <param name="page">页面</param>
//        /// <param name="rows">行数</param>
//        /// <returns></returns>
//        public static string read(string dbname, string tableName,int page,int rows)
//        {
//            string _dbFile = DBLOCATION;
//            _dbFile = _dbFile + "\\" + dbname + ".db";
//            //if (File.Exists(_dbFile)) {
//            //    File.Delete(_dbFile);
//            //}
//            if (!File.Exists(_dbFile))
//            {
//                return null;
//                // SQLiteConnection.CreateFile(_dbFile);
//            }
//           // string sqlstr = "";
//           // SQLiteDBHelper helper = new SQLiteDBHelper(_dbFile);
            
//            //检查表是否存在
//          //  sqlstr = String.Format("SELECT count(*) FROM sqlite_master WHERE type='table' AND name='{0}'", tableName);
//          //  int isexist = Convert.ToInt32(helper.ExecuteScalar(sqlstr, null));
//            if (isexist <= 0)
//            {
//                return "";
//            }
//            //计算行数与偏移
//            int total = Convert.ToInt32(helper.ExecuteScalar("select count(*) from " + tableName, null));
//            int offset = (page - 1) * rows;
            
            
//            if (offset != 0)
//            {
//              //  If a comma is used instead of the OFFSET keyword, then the offset is the first number and the limit is the second number.
//             //   sqlstr = "select * from {0} limit {1}, {2}";
//              //  sqlstr = String.Format(sqlstr, tableName, offset,rows );
//                sqlstr = "select * from {0} limit {1} offset {2}";
//                sqlstr = String.Format(sqlstr, tableName, rows, offset);
//            }
//            else
//            {
//                sqlstr = "select * from {0} limit {1}";
//                sqlstr = String.Format(sqlstr, tableName, rows);
//            }
//            DataTable dt = helper.ExecuteDataTable(sqlstr, null);
//            TableObject tr = new TableObject();
//            tr.total = total;
//            tr.rows = dt;
//            var output = JsonConvert.SerializeObject(tr);
//               return output;
//        }
//        #endregion Methods
//    }
//    /// <summary>
//    /// FOR THE JueryEasyUI table
//    /// </summary>
//    public class TableObject
//    {
//        #region Constructors
//        public TableObject()
//        {
//        }
//        #endregion Constructors
//        #region Properties
//        public DataTable rows
//        {
//            get; set;
//        }
//        public int total
//        {
//            get; set;
//        }
//        #endregion Properties
//    }
//}