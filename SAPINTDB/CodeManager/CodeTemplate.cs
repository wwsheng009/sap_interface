using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DapperExtensions;
using DapperExtensions.Sql;
using DapperExtensions.Mapper;
using System.Reflection;

namespace SAPINTDB.CodeManager
{
    public class CodeTemplate
    {
        public int Id { get; set; }
 
        public string Content { get; set; }
        public string Desc { get; set; }


    }

    public class CodeTmeplateManager
    {

        public string dbname { get; set; }
        private netlib7 netlib = null;
        IDatabase Db = null;
        IDbConnection connection = null;



        public CodeTmeplateManager(String dbName = null)
        {

            getDb(dbName);
        }

        public void getDb(String dbName = null)
        {
            SqlDialectBase dialect = null;

            if (String.IsNullOrEmpty(dbName))
            {
                dbname = ConfigFileTool.SAPGlobalSettings.GetCodeTemplateDb();
            }
            else
            {
                dbname = dbName;
            }


            if (string.IsNullOrEmpty(dbname))
            {
                throw new Exception("Con't get the db connection");

            }
            netlib = new netlib7(dbname);
            connection = netlib.CreateConnection();

            switch (netlib.ProviderType)
            {
                case netlib7.ProviderTypes.Oracle:
                    break;
                case netlib7.ProviderTypes.SqlServer:
                    dialect = new SqlServerDialect();
                    break;
                case netlib7.ProviderTypes.MsAccess:
                    dialect = new SqlCeDialect();
                    break;
                case netlib7.ProviderTypes.MySql:
                    dialect = new MySqlDialect();
                    break;
                case netlib7.ProviderTypes.PostgreSQL:
                    break;
                case netlib7.ProviderTypes.OleDB:
                    dialect = new SqlCeDialect();
                    break;
                case netlib7.ProviderTypes.SQLite:
                    dialect = new SqliteDialect();
                    break;
                case netlib7.ProviderTypes.Unknown:
                    break;
                default:
                    break;
            }

            var config = new DapperExtensionsConfiguration(typeof(AutoClassMapper<>), new List<Assembly>(), dialect);
            var sqlGenerator = new SqlGeneratorImpl(config);
            Db = new Database(connection, sqlGenerator);
        }

        public CodeTemplate save(CodeTemplate _template)
        {
            if (_template.Id == 0)
            {
                var id = Db.Insert(_template);
                _template.Id = id;
            }
            else
            {
                Db.Update(_template);
            }
            return _template;
        }
        public CodeTemplate get(long id)
        {
            var template = Db.Get<CodeTemplate>(id);

            return template;

        }
        public List<CodeTemplate> getList()
        {
            var list = Db.GetList<CodeTemplate>() as List<CodeTemplate>;
            return list;

        }

        public DataTable getDt()
        {
            var dt = new DataTable();
            netlib.DataTableFill(dt, "select id,desc from codeTemplate");
            return dt;
        }

        public bool deleteById(int intId)
        {
            var pre = Predicates.Field<CodeTemplate>(f => f.Id, Operator.Eq, intId, false);
            return Db.Delete<CodeTemplate>(pre);
        }
    }
}
