using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using Dapper;
using DapperExtensions;
using DapperExtensions.Mapper;
using DapperExtensions.Sql;

namespace SAPINTDB.CodeManager
{


    public class Codedb
    {
        //public string id { get; set; }
        //public string content { get; set; }
        //public string version { get; private set; }
        //public string desc { get; set; }
        //public string categery { get; set; }

        //private bool readOnly { get; set; }

        public string dbname { get; set; }
        private SAPINTDB.netlib7 net { get; set; }
        public static List<Code> codelist = new List<Code>();

        //public Code _code = new Code();

        IDatabase Db = null;
        IDbConnection connection = null;
        SqlDialectBase dialect = null;


        public Codedb()
        {
            InitDb();
        }
        //public Codedb(Code code)
        //{
        //    this._code = code;
        //    InitDb();
        //}

        //public Codedb(DataRow row)
        //{

        //    if (row != null)
        //    {
        //        _code = datatrowToObject(row);
        //    }

        //    InitDb();
        //}

        private void InitDb()
        {
            dbname = new ConfigFileTool.SAPGlobalSettings().GetTemplateDb();
            if (string.IsNullOrWhiteSpace(dbname))
            {
                throw new Exception("Can't get the dbName");
            }
            net = new SAPINTDB.netlib7(dbname);
            connection = net.CreateConnection();



            switch (net.ProviderType)
            {
                case netlib7.ProviderTypes.Oracle:
                    break;
                case netlib7.ProviderTypes.SqlServer:
                    dialect = new SqlServerDialect();
                    break;
                case netlib7.ProviderTypes.MsAccess:
                    break;
                case netlib7.ProviderTypes.MySql:
                    dialect = new MySqlDialect();
                    break;
                case netlib7.ProviderTypes.PostgreSQL:
                    break;
                case netlib7.ProviderTypes.OleDB:
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

        private void checkSqlError()
        {
            if (!String.IsNullOrWhiteSpace(net.ErrorMessage))
            {
                throw new Exception(net.ErrorMessage);
            }
        }
        public bool SaveCodeList(List<Code> codelist)
        {
            Db.BeginTransaction();
            try
            {

                foreach (var item in codelist)
                {
                    SaveCode(item);
                }
                Db.Commit();
            }
            catch (Exception)
            {
                Db.Rollback();

                throw;
            }


            return true;

        }
        public bool DeleteCode(Code _code)
        {
            return Db.Delete(_code);
        }
        public Code SaveCode(Code _code)
        {
            CodeVersion version = new CodeVersion();
            //Guid id = Guid.Empty;
            String id = null;

            bool saveOk = false;
            _code.getNextVersion();

            _code.LastChangeTime = DateTime.Now;
            if (String.IsNullOrWhiteSpace(_code.Id))
            {
                _code.CreateTime = DateTime.Now;
                _code.Id = Guid.NewGuid().ToString();
                id = Db.Insert(_code);
                // _code.Id = id;
                saveOk = true;


                //CodeTree tree = new CodeTree();
                ////tree.DocumentId = _code.Id;
                //tree.Text = _code.Title;
                //tree.Type = CodeType.Document.ToString();
                //Db.Insert(tree);

            }
            else
            {
                id = _code.Id;

                saveOk = Db.Update(_code);

            }

            if (String.IsNullOrWhiteSpace(_code.Id))
            {
                throw new Exception("Can't save the Code");
            }
            if (true == saveOk)
            {
                version.Title = _code.Title;
                version.Desc = _code.Desc;
                version.CodeId = _code.Id;
                version.Content = _code.Content;
                version.Version = _code.Version;
                saveVersion(version);
            }

            return _code;

        }
        public Code getCodebyId(String p)
        {
            Code code = Db.Get<Code>(p);
            if (code != null)
            {
                var predicate = new { CodeId = code.Id };
                code.VersionList = Db.GetList<CodeVersion>(predicate).ToList<CodeVersion>();

            }

            return code;
        }

        //public void savetodb()
        //{
        //    if (String.IsNullOrWhiteSpace(_code.content))
        //    {
        //        throw new Exception("No thing to save");
        //    }
        //    if (string.IsNullOrWhiteSpace(_code.desc))
        //    {
        //        if (_code.content.Length > 50)
        //        {
        //            _code.desc = _code.content.Substring(0, 50);
        //        }
        //        else
        //        {
        //            _code.desc = _code.content;
        //        }

        //    }


        //    if (!string.IsNullOrWhiteSpace(dbname))
        //    {
        //        getNextVersion();
        //        String sql = String.Format("insert into codeTemplate ('code','desc','version')values('{0}','{1}','{2}')",
        //            _code.content, _code.desc, _code.version);
        //        object o = net.ExecScalar(sql);
        //        if (!String.IsNullOrWhiteSpace(net.ErrorMessage))
        //        {
        //            throw new Exception(net.ErrorMessage);
        //        }
        //    }

        //}

        public DataTable searchCodeDataTable(string search)
        {

            if (net.ProviderType == netlib7.ProviderTypes.SQLite)
            {
                string sql = String.Format("select title,snippet(codeindex,'<strong>', '</strong>', '...')result ,id,desc from codeindex where codeindex match '*{0}*'", search);

                sql = string.Format(" select V.[title],snippet(codeindex,'<strong>', '</strong>', '...') result ,I.[id],V.[codeid],V.[Desc],V.[version] from codeindex I inner join codeversion V on I.id = V.id where codeindex match '*{0}*' ", search);

                DataTable dt = net.DataTableFill(sql);
                if (!String.IsNullOrWhiteSpace(net.ErrorMessage))
                {
                    throw new Exception(net.ErrorMessage);
                }

                return dt;
            }

            else
            {
                // var predicate = Predicates.Field<Code>(f => f.Content, Operator.Like, search, true);
                //codeSearchResult = Db.GetList<Code>(predicate).ToList<Code>();
                throw new Exception("Only Support sqlite search");

            }
        }

        public CodeTree SaveTreeNode(CodeTree treeNode)
        {

            if (String.IsNullOrEmpty(treeNode.Id))
            {
                treeNode.Id = Guid.NewGuid().ToString();
                var id = Db.Insert(treeNode);
                treeNode.Id = id;
            }
            else
            {
                if (Db.Update(treeNode))
                {
                    return treeNode;
                }
                else
                {
                    return null;
                }
            }
            //if (String.IsNullOrEmpty(treeNode.ParentId))
            //{
            //    // treeNode.ParentId = Guid.NewGuid().ToString();
            //}


            return treeNode;

        }
        public List<CodeTree> GetTopLit()
        {

            var pre = Predicates.Field<CodeTree>(f => f.ParentId, Operator.Eq, string.Empty, false);
            var list = Db.GetList<CodeTree>(pre).ToList<CodeTree>();

            var newList = new List<CodeTree>();
            foreach (var item in list)
            {
                newList.Add(GetTree(item.Id));
            }
            return newList;


        }

        public CodeTree GetTree(String id)
        {

            var tree = Db.Get<CodeTree>(id);
            if (tree == null)
            {
                throw new Exception("Id is not valid");
            }

            // var codeList = new List<Code>();

            var pre = Predicates.Field<CodeTree>(f => f.ParentId, Operator.Eq, id, false);
            tree.SubTreeList = Db.GetList<CodeTree>(pre).ToList<CodeTree>();

            var codpre = Predicates.Field<Code>(f => f.TreeId, Operator.Eq, id, false);
            tree.CodeList = Db.GetList<Code>(codpre).ToList<Code>();
            //foreach (var item in codeTreelist)
            //{
            //    //var codpre = Predicates.Field<Code>(f => f.Id, Operator.Eq, item.DocumentId, true);
            //    var code = Db.Get<Code>(item.DocumentId);
            //    codeList.Add(code);
            //}

            return tree;
            //return codeTreelist;

        }
        public List<Code> searchCode(string search)
        {
            var codeSearchResult = new List<Code>();
            if (net.ProviderType == netlib7.ProviderTypes.SQLite)
            {
                string sql = String.Format("select snippet(codeindex,'<strong>', '</strong>', '...') from codeindex where codeindex match '*{0}*'", search);
                DataTable dt = net.DataTableFill(sql);
                if (!String.IsNullOrWhiteSpace(net.ErrorMessage))
                {
                    throw new Exception(net.ErrorMessage);
                }

                if (dt.Rows.Count > 0)
                {
                    codeSearchResult.Clear();
                }
                foreach (DataRow item in dt.Rows)
                {
                    codeSearchResult.Add(new Code(item));
                }
                return codeSearchResult;
            }

            else
            {
                var predicate = Predicates.Field<Code>(f => f.Content, Operator.Like, search, true);
                codeSearchResult = Db.GetList<Code>(predicate).ToList<Code>();
                throw new Exception("Only Support sqlite search");

            }
        }



        public void saveVersion(CodeVersion version)
        {
            // var config = new DapperExtensionsConfiguration(typeof(CodeMapper), new List<Assembly>(), dialect);
            // var sqlGenerator = new SqlGeneratorImpl(config);
            //  Db = new Database(connection, sqlGenerator);

            version.Id = Guid.NewGuid().ToString();
            //Guid versionid = Db.Insert(version);
            String versionid = Db.Insert(version);
            CodeIndex index = new CodeIndex();
            //index.Id = versionid.ToString();
            index.Id = version.Id;
            index.Content = version.Content;
            //index.Desc = version.Desc;
            //index.Title = version.Title;
            index.CodeId = version.CodeId;
            Db.Insert(index);

        }



        public void BeginTransaction()
        {
            this.Db.BeginTransaction();
        }

        public void Commit()
        {
            Db.Commit();
        }

        public void DeleteCodeList(List<Code> removed)
        {
            if (removed != null)
            {
                BeginTransaction();
                foreach (var item in removed)
                {
                    DeleteCode(item);
                    var codpre = Predicates.Field<CodeVersion>(f => f.CodeId, Operator.Eq, item.Id, false);
                    Db.Delete<CodeVersion>(codpre);
                    var codpre2 = Predicates.Field<CodeIndex>(f => f.CodeId, Operator.Eq, item.Id, false);
                    Db.Delete<CodeIndex>(codpre2);
                }
                Commit();
            }

        }

        public bool DeleteTreeNode(CodeTree codeTreeNode)
        {

            if (codeTreeNode == null)
            {
                return false;
            }
            var id = codeTreeNode.Id;


            var tree = Db.Get<CodeTree>(id);
            if (tree == null)
            {
                throw new Exception("Id is not valid");
            }
            wholeTreeList.Clear();
            wholeCodeList.Clear();
            wholeTreeList.Add(tree);

            getWholeCodeTree(tree.Id);

            Db.BeginTransaction();
            foreach (var item in wholeTreeList)
            {
                Db.Delete(item);
            }
            foreach (var item in wholeCodeList)
            {
                Db.Delete(item);
                var codpre = Predicates.Field<CodeVersion>(f => f.CodeId, Operator.Eq, item.Id, false);
                Db.Delete<CodeVersion>(codpre);
                var codpre2 = Predicates.Field<CodeIndex>(f => f.CodeId, Operator.Eq, item.Id, false);
                Db.Delete<CodeIndex>(codpre2);

            }
            Db.Commit();
            return true;
        }
        List<CodeTree> wholeTreeList = new List<CodeTree>();
        List<Code> wholeCodeList = new List<Code>();

        private void getWholeCodeTree(String id)
        {
            var pre = Predicates.Field<CodeTree>(f => f.ParentId, Operator.Eq, id, false);
            var subTreeList = Db.GetList<CodeTree>(pre).ToList<CodeTree>();

            var codpre = Predicates.Field<Code>(f => f.TreeId, Operator.Eq, id, false);
            var _codeList = Db.GetList<Code>(codpre).ToList<Code>();
            wholeCodeList.AddRange(_codeList);
            if (subTreeList.Count > 0)
            {
                wholeTreeList.AddRange(subTreeList);

                foreach (var item in subTreeList)
                {
                    getWholeCodeTree(item.Id);
                }
            }
        }
    }
}
