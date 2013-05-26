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
    /// 封装一个SAP表的定义
    /// </summary>
    public class RFCTableInfo
    {
        public String Name { get; set; }
        public int FieldCount { get; private set; }
        public List<TableField> Fields { get; set; }
        log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private DataTable fieldDt = null;

        private static DataTable dtDFIES = null;


        public RFCTableInfo()
        {

        }
        public RFCTableInfo(String systemName, String tableName)
        {
            GetTableDefinition(systemName, tableName);
        }
        /// <summary>
        /// 转换SAP类型对应的系统类型。
        /// </summary>
        public void TransformDataType()
        {
            Fields.ForEach(row =>
            {
                row.DOTNETTYPE = RfcTypeConvertor.AbapInnerTypeToSystemType(row.INTTYPE).ToString();
                row.DOTNETTYPE.Replace("System.", "");
                //  row.DOTNETTYPE = RfcTypeConvertor.AbapInnerTypeToSystemType(row.INTTYPE).ToString();
                Type e = Type.GetType(row.DOTNETTYPE);
                row.DBTYPE = SAPINT.DbHelper.DbTypeConvertor.ToDbType(e).ToString();
                row.SQLTYPE = SAPINT.DbHelper.DbTypeConvertor.ToSqlDbType(e).ToString();

            });
        }
        public DataTable GetTableDefinitionDt(String pSystemName, String pTableName)
        {
            Name = pTableName.Trim().ToUpper();
            try
            {
                // DataTable dt = SAPINT.Function.SAPFunction.DDIF_FIELDINFO_GET(pSystemName, pTableName);
                DataTable dt = getSAPTabledef(pSystemName, pTableName);
                if (dt == null)
                {
                    throw new SAPException(String.Format("无法获取表结构{0}的定义", pTableName));
                }
                else
                {
                    fieldDt = dt;
                    DataColumn dc = new DataColumn("Selected", typeof(bool));
                    dc.DefaultValue = false;
                    dt.Columns.Add(dc);
                    dc.SetOrdinal(0);

                }
                return dt;
            }
            catch (Exception exception)
            {
                throw new SAPException(exception.Message);
            }
        }
        private static DataTable getSAPTabledef(String sysName, String TableName)
        {
            try
            {
                RfcDestination destination = SAPDestination.GetDesByName(sysName);
                IRfcFunction RFC_FUNCTION_SEARCH = destination.Repository.CreateFunction("DDIF_FIELDINFO_GET");
                RFC_FUNCTION_SEARCH.SetValue("TABNAME", TableName);
                RFC_FUNCTION_SEARCH.Invoke(destination);
                IRfcTable DFIES_TAB = RFC_FUNCTION_SEARCH.GetTable("DFIES_TAB");
                DataTable dt = GET_DFIES_TABLE(DFIES_TAB);
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
        private static DataTable buildTable()
        {

            DataTable dt = null;
            dt = new DataTable("DFIES");
            dt.Columns.AddRange(new DataColumn[]{
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
                });


            return dt;
        }
        private static DataTable GET_DFIES_TABLE(IRfcTable rfcTable)
        {
            if (dtDFIES == null)
            {
                dtDFIES = buildTable();
            }
            DataTable dt = dtDFIES.Copy();
            dt.Clear();
            foreach (IRfcStructure row in rfcTable)
            {
                DataRow dr = dt.NewRow();
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
                dt.Rows.Add(dr);
            }
            return dt;
        }
        /// <summary>
        /// 读取表的定义
        /// </summary>
        /// <param name="pSystemName"></param>
        /// <param name="pTableName"></param>
        public void GetTableDefinition(String pSystemName, String pTableName)
        {
            try
            {
                var dt = this.GetTableDefinitionDt(pSystemName, pTableName);
                var list = dt.ToList<TableField>() as List<TableField>;
                Fields = list;
                FieldCount = list.Count;
            }
            catch (Exception)
            {

                throw;
            }


            //Name = pTableName.Trim().ToUpper();
            //try
            //{
            //    DataTable dt = SAPINT.Function.SAPFunction.DDIF_FIELDINFO_GET(pSystemName, pTableName);
            //    this.list<TableField>(dt);
            //    if (dt == null)
            //    {
            //        throw new SAPException(String.Format("无法获取表结构{0}的定义", pTableName));
            //    }

            //    Fields = new List<TableField>();
            //    PropertyInfo[] properties = Type.GetType("SAPINT.RFCTable.TableField").GetProperties();

            //    //Type type = Type.GetType("SAPINTCODE.TableField");


            //    foreach (DataRow datarow in dt.Rows)
            //    {
            //        //st.AppendLine("DataRow:" + datarow.ToString());
            //        TableField tablerow = new TableField();
            //        for (int i = 0; i < properties.Length; i++)
            //        {
            //            if (dt.Columns.Contains(properties[i].Name))
            //            {

            //                Type DataRowType = datarow[properties[i].Name].GetType();
            //                Type SystemType = properties[i].PropertyType;
            //                if (!DataRowType.Equals(SystemType))
            //                {
            //                    // log.Debug("RFC类型转换成系统类型出错！！\n\r");
            //                    // log.Debug("Field: " + properties[i].Name);
            //                    // log.Debug(" SystemType:" + properties[i].PropertyType);
            //                    //  log.Debug(" DataRowType:" + datarow[properties[i].Name].GetType());
            //                    //  log.Debug(" DataRowValue:" + datarow[properties[i].Name]);

            //                }
            //                else
            //                {
            //                    Object o = datarow[properties[i].Name];
            //                    properties[i].SetValue(tablerow, datarow[properties[i].Name], null);
            //                }
            //                //Type t2 = properties[i].GetType();
            //                if (!DataRowType.Name.Equals("DBNull"))
            //                {
            //                    // log.Error( "字段"+ properties[i].Name + "数据类型为DBNull！");
            //                }

            //            }
            //        }
            //        //if (!String.IsNullOrWhiteSpace(st.ToString()))
            //        //{
            //        //    throw new SAPException(st.ToString());
            //        //}

            //        //  tablerow.DOTNETTYPE = RfcTypeConvertor.AbapInnerTypeToSystemType(tablerow.INTTYPE).ToString();
            //        Fields.Add(tablerow);

            //    }

            //    FieldCount = Fields.Count;
            //}
            //catch (Exception exception)
            //{
            //    throw new SAPException(exception.Message);
            //}

        }
    }
}
