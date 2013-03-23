using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

namespace SAPINT.RFCTable
{
    /// <summary>
    /// 封装一个SAP表的定义
    /// </summary>
    public class RFCTableInfo
    {
        public String Name { get; private set; }
        public int FieldCount { get; private set; }
        public List<TableField> Fields { get; private set; }
        log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public RFCTableInfo()
        {

        }
        public  RFCTableInfo(String systemName, String tableName)
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
        /// <summary>
        /// 读取表的定义
        /// </summary>
        /// <param name="pSystemName"></param>
        /// <param name="pTableName"></param>
        public void GetTableDefinition(String pSystemName, String pTableName)
        {
            Name = pTableName.Trim().ToUpper();
            try
            {
                DataTable dt = SAPINT.Function.SAPFunction.DDIF_FIELDINFO_GET(pSystemName, pTableName);
                if (dt==null)
                {
                    throw new SAPException(String.Format("无法获取表结构{0}的定义",pTableName));
                }

                Fields = new List<TableField>();
                PropertyInfo[] properties = Type.GetType("SAPINT.RFCTable.TableField").GetProperties();
                
                //Type type = Type.GetType("SAPINTCODE.TableField");

                
                foreach (DataRow datarow in dt.Rows)
                {
                    //st.AppendLine("DataRow:" + datarow.ToString());
                    TableField tablerow = new TableField();
                    for (int i = 0; i < properties.Length; i++)
                    {
                        if (dt.Columns.Contains(properties[i].Name))
                        {
                            
                            Type DataRowType = datarow[properties[i].Name].GetType();
                            Type SystemType = properties[i].PropertyType;
                            if (!DataRowType.Equals(SystemType))
                            {
                                log.Debug("RFC类型转换成系统类型出错！！\n\r");
                                log.Debug("Field: " + properties[i].Name);
                                log.Debug(" SystemType:" + properties[i].PropertyType);
                                log.Debug(" DataRowType:" + datarow[properties[i].Name].GetType());
                                log.Debug(" DataRowValue:" + datarow[properties[i].Name]);
                                
                            }
                            else
                            {
                                Object o = datarow[properties[i].Name];
                                properties[i].SetValue(tablerow, datarow[properties[i].Name], null);
                            }
                            //Type t2 = properties[i].GetType();
                            if (!DataRowType.Name.Equals("DBNull"))
                            {
                               // log.Error( "字段"+ properties[i].Name + "数据类型为DBNull！");
                            }
                            
                        }
                    }
                    //if (!String.IsNullOrWhiteSpace(st.ToString()))
                    //{
                    //    throw new SAPException(st.ToString());
                    //}

                    //  tablerow.DOTNETTYPE = RfcTypeConvertor.AbapInnerTypeToSystemType(tablerow.INTTYPE).ToString();
                    Fields.Add(tablerow);
                }
                FieldCount = Fields.Count;
            }
            catch (Exception exception)
            {
                throw new SAPException(exception.Message);
            }

        }
    }
}
