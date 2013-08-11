using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using SAPINT.Utils;
using SAP.Middleware.Connector;

namespace SAPINT.RFCTable
{
    /// <summary>
    /// 从SAP系统中读取一个表的定义。
    /// 封装一个SAP表的定义
    /// </summary>
    public class SAPTableInfo
    {
        public String SystemName { get; set; }
        public String name { get; set; }
        public int FieldsCount { get; private set; }

        public List<TableField> Fields { get; set; }

        public DataTable FieldsDt { get; private set; }

        log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        private static DataTable dtDefinition = null;


        public SAPTableInfo()
        {

        }
        public SAPTableInfo(String pSystemName, String pTableName,String pTypeName="")
        {
            name = pTableName;
            SystemName = pSystemName;

            GetTableDefinition(pSystemName, pTableName, pTypeName);
        }

        /// <summary>
        /// 读取表的定义
        /// </summary>
        /// <param name="pSystemName"></param>
        /// <param name="pTableName"></param>
        public void GetTableDefinition(String pSystemName, String pTableName, String pTypeName = "")
        {
            if (string.IsNullOrEmpty(pTypeName))
            {
                pTypeName = pTableName;
            }
            try
            {
                var dt = GetTableDefinitionDt(pSystemName, pTypeName);
                FieldsDt = dt;
                var list = dt.ToList<TableField>() as List<TableField>;
                Fields = list;
                FieldsCount = list.Count;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 把SAP类型转换成对应的NET类型。
        /// </summary>
        public void TransformDataType()
        {
            if (Fields == null)
            {
                return;
            }
            Fields.ForEach(row =>
            {
                row.DOTNETTYPE = RfcTypeConvertor.AbapInnerTypeToSystemType(row.INTTYPE).ToString();
                Type e = Type.GetType(row.DOTNETTYPE);
                row.DOTNETTYPE.Replace("System.", "");
                if (row.DOTNETTYPE.Contains("Int"))
                {
                    row.DOTNETTYPE = "int";
                }
                row.DBTYPE = SAPINT.DbHelper.DbTypeConvertor.ToDbType(e).ToString();
                row.SQLTYPE = SAPINT.DbHelper.DbTypeConvertor.ToSqlDbType(e).ToString();

            });
        }
        /// <summary>
        /// 转换SAP类型为NET类型。
        /// </summary>
        /// <param name="dt"></param>
        private static void _TransFormDataTypeForDt(DataTable dt)
        {
            bool has_inttype_column = false;
            bool has_dotnettype_column = false;
            bool has_dbtype_column = false;
            bool has_sqltype_column = false;

            if (dt.Columns.Contains("INTTYPE"))
            {
                has_inttype_column = true;
            }
            if (dt.Columns.Contains("DOTNETTYPE"))
            {
                has_dotnettype_column = true;
            }
            if (dt.Columns.Contains("DBTYPE"))
            {
                has_dbtype_column = true;
            }
            if (dt.Columns.Contains("SQLTYPE"))
            {
                has_sqltype_column = true;
            }

            foreach (DataRow row in dt.Rows)
            {
                if (has_inttype_column && has_dotnettype_column)
                {


                    row["DOTNETTYPE"] = RfcTypeConvertor.AbapInnerTypeToSystemType(row["INTTYPE"].ToString()).ToString();
                    Type e = Type.GetType(row["DOTNETTYPE"].ToString());

                    row["DOTNETTYPE"] = row["DOTNETTYPE"].ToString().Replace("System.", "");
                    if (row["DOTNETTYPE"].ToString().Contains("Int"))
                    {
                        row["DOTNETTYPE"] = "int";
                    }
                    

                    if (has_dbtype_column)
                    {
                        row["DBTYPE"] = SAPINT.DbHelper.DbTypeConvertor.ToDbType(e).ToString();
                    }
                    if (has_sqltype_column)
                    {
                        row["SQLTYPE"] = SAPINT.DbHelper.DbTypeConvertor.ToSqlDbType(e).ToString();
                    }

                }
            }
        }
        /// <summary>
        /// 返回表或结构的字段定义
        /// </summary>
        /// <param name="pSystemName">SAP系统</param>
        /// <param name="pTableName">表或结构名</param>
        /// <returns></returns>
        public static DataTable GetTableDefinitionDt(String pSystemName, String pTableName, String pTypeName = "")
        {
            if (string.IsNullOrEmpty(pTypeName))
            {
                pTypeName = pTableName;
            }
            try
            {
                // DataTable dt = SAPINT.Function.SAPFunction.DDIF_FIELDINFO_GET(pSystemName, pTableName);
                DataTable dt = _GetSAPTableDef(pSystemName, pTypeName);
                if (dt == null)
                {
                    throw new SAPException(String.Format("无法获取表结构{0}的定义", pTableName));
                }
                else
                {

                    DataColumn dc = new DataColumn("Selected", typeof(bool));
                    dc.DefaultValue = false;
                    dt.Columns.Add(dc);
                    dc.SetOrdinal(0);
                    _TransFormDataTypeForDt(dt);
                }
                return dt;
            }
            catch (Exception exception)
            {
                throw new SAPException(exception.Message);
            }
        }
        /// <summary>
        /// 返回表或结构的定义细节。
        /// </summary>
        /// <param name="p_sysName">SAP系统</param>
        /// <param name="p_TableName">表或结构</param>
        /// <returns>结构定义</returns>
        private static DataTable _GetSAPTableDef(String p_sysName, String p_TableName)
        {
            try
            {
                RfcDestination destination = SAPDestination.GetDesByName(p_sysName);
                IRfcFunction RFC_FUNCTION_SEARCH = destination.Repository.CreateFunction("DDIF_FIELDINFO_GET");
                RFC_FUNCTION_SEARCH.SetValue("TABNAME", p_TableName);
                RFC_FUNCTION_SEARCH.Invoke(destination);
                IRfcTable DFIES_TAB = RFC_FUNCTION_SEARCH.GetTable("DFIES_TAB");
                DataTable dt = _Convert_rfctable_to_dt(DFIES_TAB);
                return dt;
            }
            catch (RfcAbapException abapException)
            {
                throw new SAPException(abapException.Key + abapException.Message);
            }
            catch (RfcAbapBaseException abapbaseException)
            {
                throw new SAPException(abapbaseException.PlainText + abapbaseException.Message);
            }
            catch (Exception ex)
            {

                throw new SAPException(ex.Message);
            }
        }
        /// <summary>
        /// 构造一个用于显示数据的DT定义。
        /// </summary>
        /// <returns></returns>
        private static DataTable _BuildDataTable()
        {

            DataTable _dt = null;
            _dt = new DataTable("DFIES");
            _dt.Columns.AddRange(new DataColumn[]{
            //new DataColumn("Index",typeof(int)),
           // new DataColumn("Select",typeof(bool)),
            new DataColumn("TABNAME",typeof(System.String)),// 表名
            new DataColumn("FIELDNAME",typeof(System.String)),// 字段名
            new DataColumn("POSITION",typeof(System.Int32)),//   表格中区域的位置
            new DataColumn("OFFSET",typeof(System.Int32)),// 工作区内域偏移
            new DataColumn("DOMNAME",typeof(System.String)),// 定义域名
            new DataColumn("ROLLNAME",typeof(System.String)),// 定义域名
            new DataColumn("CHECKTABLE",typeof(System.String)),// 表名
            new DataColumn("INTTYPE",typeof(System.String)),// 长字段标签
            new DataColumn("DATATYPE",typeof(System.String)),// 长字段标签
            new DataColumn("REFTABLE",typeof(System.String)),// 长字段标签
            new DataColumn("REFFIELD",typeof(System.String)),// 长字段标签
            new DataColumn("LENG",typeof(System.Int32)),// 长度（字符数）
            new DataColumn("OUTPUTLEN",typeof(System.Int32)),// 输出长度
            new DataColumn("DECIMALS",typeof(System.Int32)),// 小数点后的位数
            new DataColumn("FIELDTEXT",typeof(System.String)),// 描述 R/3 资源库对象的短文本
            new DataColumn("REPTEXT",typeof(System.String)),// 标题
            new DataColumn("SCRTEXT_S",typeof(System.String)),// 短字段标签
            new DataColumn("SCRTEXT_M",typeof(System.String)),// 中字段标签
            new DataColumn("SCRTEXT_L",typeof(System.String)),// 长字段标签
            new DataColumn("KEYFLAG",typeof(System.String)),// 标识表格的关键字段
            new DataColumn("POSITION2",typeof(System.String)),// 格式化的POSITIOIN
            new DataColumn("DOTNETTYPE",typeof(System.String)),// 格式化的POSITIOIN
                });


            return _dt;
        }
        /// <summary>
        /// 把RFC表转换成DT格式
        /// </summary>
        /// <param name="rfcTable"></param>
        /// <returns></returns>
        private static DataTable _Convert_rfctable_to_dt(IRfcTable rfcTable)
        {
            if (dtDefinition == null)
            {
                dtDefinition = _BuildDataTable();
            }
            DataTable _dt = dtDefinition.Copy();
            _dt.Clear();
            foreach (IRfcStructure row in rfcTable)
            {
                DataRow dr = _dt.NewRow();
                dr["TABNAME"] = row.GetValue("TABNAME") ?? DBNull.Value;
                dr["FIELDNAME"] = row.GetValue("FIELDNAME") ?? DBNull.Value;
                dr["POSITION"] = row.GetValue("POSITION") ?? DBNull.Value;
                dr["OFFSET"] = row.GetValue("OFFSET") ?? DBNull.Value;
                dr["DOMNAME"] = row.GetValue("DOMNAME") ?? DBNull.Value;
                dr["ROLLNAME"] = row.GetValue("ROLLNAME") ?? DBNull.Value;
                dr["CHECKTABLE"] = row.GetValue("CHECKTABLE") ?? DBNull.Value;
                dr["LENG"] = row.GetValue("LENG") ?? DBNull.Value;
                dr["OUTPUTLEN"] = row.GetValue("OUTPUTLEN") ?? DBNull.Value;
                dr["DECIMALS"] = row.GetValue("DECIMALS") ?? DBNull.Value;
                dr["FIELDTEXT"] = row.GetValue("FIELDTEXT") ?? DBNull.Value;
                dr["REPTEXT"] = row.GetValue("REPTEXT") ?? DBNull.Value;
                dr["SCRTEXT_S"] = row.GetValue("SCRTEXT_S") ?? DBNull.Value;
                dr["SCRTEXT_M"] = row.GetValue("SCRTEXT_M") ?? DBNull.Value;
                dr["SCRTEXT_L"] = row.GetValue("SCRTEXT_L") ?? DBNull.Value;
                dr["INTTYPE"] = row.GetValue("INTTYPE") ?? DBNull.Value;
                dr["DATATYPE"] = row.GetValue("DATATYPE") ?? DBNull.Value;
                dr["REFTABLE"] = row.GetValue("REFTABLE") ?? DBNull.Value;
                dr["REFFIELD"] = row.GetValue("REFFIELD") ?? DBNull.Value;
                dr["KEYFLAG"] = row.GetValue("KEYFLAG") ?? DBNull.Value;
                // dr["DOTNETTYPE"] = RfcTypeConvertor.AbapInnerTypeToSystemType(dr["INTTYPE"].ToString()).ToString();
                // dr["DOTNETTYPE"] = dr["DOTNETTYPE"].ToString().Replace("System.", "");
                _dt.Rows.Add(dr);
            }
            return _dt;
        }

    }
}
