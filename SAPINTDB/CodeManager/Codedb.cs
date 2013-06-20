using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using Dapper;
using DapperExtensions;
using DapperExtensions.Mapper;
using DapperExtensions.Sql;

//使用Dapper Extensions框架进行数据库管理
namespace SAPINTDB.CodeManager
{

    /// <summary>
    /// 管理代码与树节点。
    /// </summary>
    public class Codedb
    {
        private string m_dbname { get; set; }
        private SAPINTDB.netlib7 m_vdb { get; set; }
        // public static List<Code> codelist = new List<Code>();

        private IDatabase Db = null;
        private IDbConnection connection = null;
        private SqlDialectBase dialect = null;


        public Codedb()
        {
            InitDb();
        }

        private void InitDb()
        {
            m_dbname = ConfigFileTool.SAPGlobalSettings.GetCodeManagerDb();
            if (string.IsNullOrWhiteSpace(m_dbname))
            {
                throw new Exception("Can't get the dbName");
            }
            m_vdb = new SAPINTDB.netlib7(m_dbname);
            connection = m_vdb.CreateConnection();



            switch (m_vdb.ProviderType)
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

        private void checkSqlError()
        {
            if (!String.IsNullOrWhiteSpace(m_vdb.ErrorMessage))
            {
                throw new Exception(m_vdb.ErrorMessage);
            }
        }


        public bool DeleteCode(Code _code)
        {
            return Db.Delete(_code);
        }
        /// <summary>
        /// 保存代码
        /// </summary>
        /// <param name="_code"></param>
        /// <returns></returns>
        public Code SaveCode(Code _code)
        {
            CodeVersion version = new CodeVersion();
            //Guid id = Guid.Empty;
            String id = null;

            bool saveOk = false;
            _code.GetNewVersion();

            _code.LastChangeTime = DateTime.Now;
            if (String.IsNullOrWhiteSpace(_code.Id))
            {
                _code.CreateTime = DateTime.Now;
                _code.Id = Guid.NewGuid().ToString();
                id = Db.Insert(_code);
                saveOk = true;
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
                if (_code.Version != "1.0.0")
                {
                    SaveVersion(_code);
                }
                SaveIndex(_code);

            }

            return _code;

        }


        /// <summary>
        /// 保存代码列表
        /// </summary>
        /// <param name="codelist"></param>
        /// <returns></returns>
        public bool SaveCodeList(List<Code> codelist)
        {

            try
            {
                Db.BeginTransaction();
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

        /// <summary>
        /// 返回代码。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Code GetCode(String id)
        {
            Code code = Db.Get<Code>(id);
            if (code != null)
            {
                var predicate = new { CodeId = code.Id };
                code.VersionList = Db.GetList<CodeVersion>(predicate).ToList<CodeVersion>();

            }
            return code;
        }
        /// <summary>
        /// 全文检索，目前只支持SQLITE.
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public DataTable SearchCodeToDataTable(string search)
        {

            if (m_vdb.ProviderType == netlib7.ProviderTypes.SQLite)
            {
                string sql = String.Format("select title,snippet(codeindex,'<strong>', '</strong>', '...')result ,id,desc from codeindex where codeindex match '*{0}*'", search);

                //sql = string.Format(" select V.[title],snippet(codeindex,'<strong>', '</strong>', '...') result ,I.[id],V.[codeid],V.[Desc],V.[version] from codeindex I inner join codeversion V on I.id = V.id where codeindex match '*{0}*' ", search);
                sql = string.Format(" select V.[title],snippet(codeindex,'<strong>', '</strong>', '...') result ,V.[content],I.[id],V.[Desc],V.[version] from codeindex I inner join code V on I.id = V.id where codeindex match '*{0}*' ", search);

                DataTable dt = m_vdb.DataTableFill(sql);
                if (!String.IsNullOrWhiteSpace(m_vdb.ErrorMessage))
                {
                    throw new Exception(m_vdb.ErrorMessage);
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

        public bool SaveFolderList(Dictionary<string, CodeFolder> CopyFolderList)
        {
            Db.BeginTransaction();
            try
            {

                foreach (var item in CopyFolderList)
                {
                    this.SaveTree(item.Value);
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

        /// <summary>
        /// 保存一个树节点
        /// </summary>
        /// <param name="p_folder"></param>
        /// <returns></returns>
        public CodeFolder SaveTree(CodeFolder p_folder)
        {

            if (String.IsNullOrEmpty(p_folder.Id))
            {
                p_folder.Id = Guid.NewGuid().ToString();
                var id = Db.Insert(p_folder);
                p_folder.Id = id;
            }
            else
            {
                var x = Db.Get<CodeFolder>(p_folder.Id);
                if (x == null)
                {
                    Db.Insert(p_folder);
                }
                else
                {
                    if (Db.Update(p_folder))
                    {
                        return p_folder;
                    }
                    else
                    {
                        return null;
                    }
                }

            }
            return p_folder;

        }
        /// <summary>
        /// 读取最顶层的树节点。
        /// 同时读取它下面的一层节点，这会导致会有两层树节点。
        /// </summary>
        /// <returns></returns>
        public List<CodeFolder> GetTopLit()
        {

            var pre = Predicates.Field<CodeFolder>(f => f.ParentId, Operator.Eq, string.Empty, false);
            var list = Db.GetList<CodeFolder>(pre).ToList<CodeFolder>();

            //如果文件很多，会有严重的性能问题。
            //var newList = new List<CodeTree>();
            //foreach (var item in list)
            //{
            //    newList.Add(GetTree(item.Id));
            //}
            //return newList;

            return list;

        }
        public CodeFolder GetRootFolder()
        {
            var pre = Predicates.Field<CodeFolder>(f => f.ParentId, Operator.Eq, string.Empty, false);
            var folder = Db.GetList<CodeFolder>(pre).ToList<CodeFolder>().First();
            if (String.IsNullOrEmpty(folder.Id))
            {
                return null;
            }
            return folder;

        }
        /// <summary>
        /// 根据ID读取树节点
        /// 同时读取它的第一层子节点
        /// 同时读取它下面的代码。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CodeFolder GetFolder(String id)
        {

            var tree = Db.Get<CodeFolder>(id);
            if (tree == null)
            {
                return null;
            }

            var pre = Predicates.Field<CodeFolder>(f => f.ParentId, Operator.Eq, id, false);
            tree.SubTreeList = Db.GetList<CodeFolder>(pre).ToList<CodeFolder>();

            var codpre = Predicates.Field<Code>(f => f.TreeId, Operator.Eq, id, false);
            tree.CodeList = Db.GetList<Code>(codpre).ToList<Code>();
            return tree;
        }
        public List<Code> SearchCode(string search)
        {
            var codeSearchResult = new List<Code>();
            if (m_vdb.ProviderType == netlib7.ProviderTypes.SQLite)
            {
                string sql = String.Format("select snippet(codeindex,'<strong>', '</strong>', '...') from codeindex where codeindex match '*{0}*'", search);
                DataTable dt = m_vdb.DataTableFill(sql);
                if (!String.IsNullOrWhiteSpace(m_vdb.ErrorMessage))
                {
                    throw new Exception(m_vdb.ErrorMessage);
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
                return codeSearchResult = Db.GetList<Code>(predicate).ToList<Code>();

                // throw new Exception("Only Support sqlite search");

            }
        }


        public void SaveIndex(Code code)
        {

            CodeIndex index = new CodeIndex();
            index.Id = code.Id;
            //index.Content = code.Content;
            index.Content = code.Content.Replace("\r\n", string.Empty);
            //index.CodeId = code.Id;

            //var pre = Predicates.Field<CodeIndex>(f => f.Id, Operator.Eq, code.Id, false);
            //var count = Db.Count<CodeIndex>(pre);
            //// var x = Db.Get<CodeIndex>(index.Id);
            //if (count > 0)
            //{
            //    Db.Update(index);
            //}
            //else
            //{
            Db.Insert(index);
            //}

        }
        public void SaveVersion(Code _code)
        {
            var version = new CodeVersion();
            version.Title = _code.Title;
            version.Desc = _code.Desc;
            version.CodeId = _code.Id;
            version.Content = _code.Content;
            version.Version = _code.Version;

            version.Id = Guid.NewGuid().ToString();
            String versionid = Db.Insert(version);
        }



        public void BeginTransaction()
        {
            this.Db.BeginTransaction();
        }

        public void Commit()
        {
            Db.Commit();
        }
        /// <summary>
        /// 批量删除代码。
        /// 同时会删除所有与代码相关的版本
        /// 同时会删除所有与代码相关的索引代码
        /// </summary>
        /// <param name="removed"></param>
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
                    var codpre2 = Predicates.Field<CodeIndex>(f => f.Id, Operator.Eq, item.Id, false);
                    Db.Delete<CodeIndex>(codpre2);
                }
                Commit();
            }

        }

        /// <summary>
        /// 为了更好的性能。
        /// </summary>
        /// <param name="removed"></param>
        public void DeleteCodeList2(List<Code> removed)
        {
            if (removed != null)
            {

                DbConnection cn = m_vdb.CreateConnection();
                cn.Open();
                DbCommand cmd = m_vdb.CreateCommand(cn);

                DbTransaction trans = cmd.Connection.BeginTransaction();// <-------------------
                cmd.Transaction = trans;
                try
                {
                    foreach (var item in _wholeCodeList)
                    {
                        var sql = String.Format("Delete from codeIndex where id = '{0}'", item.Id);
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                        sql = String.Format("Delete from CodeVersion where CodeId = '{0}'", item.Id);
                        cmd.ExecuteNonQuery();
                        sql = String.Format("Delete from code where Id = '{0}'", item.Id);
                        cmd.ExecuteNonQuery();

                    }
                    trans.Commit();
                }

                catch (Exception e)
                {
                    trans.Rollback();
                    cn.Close();
                    throw;
                }
                cn.Close();

            }

        }

        /// <summary>
        /// 删除一个文件夹。
        /// 同时会删除子节点的所有文件夹
        /// 同时会删除所有文件夹下面的代码。
        /// </summary>
        /// <param name="codeFolder"></param>
        /// <returns></returns>
        public bool DeleteFolder(CodeFolder codeFolder)
        {

            if (codeFolder == null)
            {
                return false;
            }
            var id = codeFolder.Id;


            var tree = Db.Get<CodeFolder>(id);
            if (tree == null)
            {
                throw new Exception("Id is not valid");
            }
            _wholeFolderList.Clear();
            _wholeCodeList.Clear();
            _wholeFolderList.Add(tree);

            Db.BeginTransaction();
            GetWholeCodeFolder(tree.Id);
            Db.Commit();

            Db.BeginTransaction();
            foreach (var item in _wholeFolderList)
            {
                Db.Delete(item);
            }
            Db.Commit();

            this.DeleteCodeList2(_wholeCodeList);

            return true;
        }

        /// <summary>
        /// 只作获取树节点使用
        /// </summary>
        private List<CodeFolder> _wholeFolderList = new List<CodeFolder>();
        private List<Code> _wholeCodeList = new List<Code>();

        /// <summary>
        /// 根据文件夹的ID,读取文件夹下面的所有的文件，跟文件夹。
        /// </summary>
        /// <param name="id"></param>
        /// <param name="codeFoderList"></param>
        /// <param name="codeList"></param>
        public void GetWholeCodeAndFolderList(string id, out List<CodeFolder> codeFoderList, out List<Code> codeList)
        {
            var tree = Db.Get<CodeFolder>(id);
            if (tree == null)
            {
                throw new Exception("Id is not valid");
            }

            _wholeFolderList.Clear();
            _wholeCodeList.Clear();
            GetWholeCodeFolder(id);
            codeFoderList = _wholeFolderList;
            codeList = _wholeCodeList;
        }
        /// <summary>
        /// 根据文件夹的ID,读取文件夹下面的所有的文件，跟文件夹。
        /// 这个方法是循环调用
        /// </summary>
        /// <param name="id"></param>
        private void GetWholeCodeFolder(String id)
        {
            try
            {
                var pre = Predicates.Field<CodeFolder>(f => f.ParentId, Operator.Eq, id, false);
                var subFolderList = Db.GetList<CodeFolder>(pre).ToList<CodeFolder>();

                var codpre = Predicates.Field<Code>(f => f.TreeId, Operator.Eq, id, false);
                var _codeList = Db.GetList<Code>(codpre).ToList<Code>();

                if (_codeList != null)
                {
                    _codeList.AddRange(_codeList);
                }
                if (subFolderList != null && subFolderList.Count > 0)
                {
                    _wholeFolderList.AddRange(subFolderList);
                    // Db.BeginTransaction();
                    foreach (var item in subFolderList)
                    {
                        if (item == null)
                        {
                            throw new Exception("item is null");
                        }
                        GetWholeCodeFolder(item.Id);
                    }
                    // Db.Commit();
                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }


    }
}
