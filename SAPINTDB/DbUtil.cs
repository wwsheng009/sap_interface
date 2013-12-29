using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SAPINTDB
{
    /// <summary>
    /// 读取数据库的架构信息，如视图，数据库表清单
    /// </summary>
    public class DbUtil
    {
        private netlib7 db2 = null;

        public DbUtil() {
            String defaultConnection = ConfigFileTool.SAPGlobalSettings.GetDefaultDbConnection();
            db2 = new netlib7(defaultConnection);
            
        }
        public DbUtil(String dbConnectionName)
        {
            db2 = new netlib7(dbConnectionName);
        }

        public DataTable getDbObjectList()
        {
            DataTable dt = new DataTable();
            try
            {
                DbConnection cn = db2.CreateConnection();
                cn.Open();
                try
                {
                    dt = cn.GetSchema();
                }
                catch
                {
                    dt = null;
                }
                cn.Close();
            }
            catch (Exception)
            {
                throw;
               // throw new Exception(exception.Message);
            }
            
            return dt;
        }
        /// <summary>
        /// 输入架构名称，返回架构清单。
        /// </summary>
        /// <param name="CollectionName"></param>
        /// <returns></returns>
        public DataTable getCollection(String CollectionName)
        {
            DataTable dt = null;
            try
            {
                DbConnection cn = db2.CreateConnection();
                dt = new DataTable();

                cn.Open();
                try
                {
                    dt = cn.GetSchema(CollectionName);
                }
                catch
                {
                    dt = null;
                }
                cn.Close();
            }
            catch (Exception)
            {
                
                throw;
            }
            


            return dt;

        }

        public DataTable GetTableList()
        {
            string[] res = null;
            DataTable dt = null;
            if (db2.ProviderType == netlib7.ProviderTypes.OleDB)
            {
                res = new string[] { null, null, null, "TABLE" };
            }
            else if (db2.ProviderType == netlib7.ProviderTypes.SQLite)
            {
                res = new string[] { null, null, null, "TABLE" };
            }
            else if (db2.ProviderType == netlib7.ProviderTypes.SqlServer)
            {
                res = new string[] { null, null, null, "BASE TABLE" };

            }
            else if (db2.ProviderType == netlib7.ProviderTypes.MySql)
            {
                res = new string[] { null, "sapdb", null, "BASE TABLE" };
            }
            if (res != null)
            {
                //  dt = db2.GetSchema("Columns", res);
                DbConnection cn = db2.CreateConnection();
                dt = new DataTable();

                cn.Open();
                try
                {
   

                    dt = cn.GetSchema("Tables", res);
                  //  dtschema = cn.GetSchema("Columns");
                }
                catch
                {
                    dt = null;
                }
                cn.Close();


            }
            return dt;
            //  DataTable dt = db2.GetSchema(TableName,);
        }

    }
}
