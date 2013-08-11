using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace SAPINT.Function.Meta
{
    public class DataTableAndList
    {
        /// <summary>
        /// 把LIST转换成DATATABLE.
        /// </summary>
        /// <param name="outlist">调用RFC函数后，outlist包含了所有的参数与它对应的值。</param>
        /// <param name="dataTable">dataTable里已经包含了一个字段的类型描述，是结构还是表还是普通值</param>
        /// <param name="tableValueList">如果字段是复杂结构或表，把值存储在这里</param>
        public static void ListToDataTable(MetaValueList outlist, DataTable dataTable, ref Dictionary<String, DataTable> tableValueList)
        {
  
            foreach (DataRow row in dataTable.Rows)
            {
                String dataType = row[FuncFieldText.DATATYPE].ToString();
                String dataTypeName = row[FuncFieldText.DATATYPENAME].ToString();
                String fieldName = row[FuncFieldText.NAME].ToString();
                String defaultValue = row[FuncFieldText.DEFAULTVALUE].ToString();

                //如果参数的类型是结构，按结构的类型返回值。
                if (dataType == SAPDataType.STRUCTURE.ToString())
                {
                    Dictionary<String, String> structure = null;
                    outlist.StructureValueList.TryGetValue(fieldName, out structure);
                    if (structure == null)
                    {
                        continue;
                    }
                    DataTable dtNew = new DataTable();
                    foreach (var item in structure)
                    {
                        DataColumn dc = new DataColumn(item.Key, Type.GetType("System.String"));
                        dtNew.Columns.Add(dc);
                    }
                    if (structure != null)
                    {
                        dtNew.Rows.Add(dtNew.NewRow());
                        DataRow row1 = dtNew.Rows[0];
                        foreach (var item in structure)
                        {
                            row1[item.Key] = item.Value;
                        }
                    }
                    if (tableValueList.Keys.Contains(fieldName))
                    {
                        tableValueList[fieldName]=dtNew;
                    }
                    else
                    {
                        tableValueList.Add(fieldName, dtNew);
                    }
                    
                }
                else if (dataType == SAPDataType.TABLE.ToString())
                {
                    List<Dictionary<String, String>> tablelist = null;
                    outlist.TableValueList.TryGetValue(fieldName, out tablelist);
                    if (tablelist == null )
                    {
                        continue;
                    }
                    if (tablelist.Count == 0)
                    {
                        if (tableValueList.Keys.Contains(fieldName))
                        {
                            var lc_dt = tableValueList[fieldName];
                            lc_dt.Clear();
                            tableValueList[fieldName] = lc_dt;
                        }
                    }
                    else
                    {
                        DataTable dtNew = new DataTable();
                        Dictionary<String, String> line = tablelist[0];
                        foreach (var item in line)
                        {
                            DataColumn dc = new DataColumn(item.Key, Type.GetType("System.String"));
                            dtNew.Columns.Add(dc);
                        }
                        foreach (Dictionary<String, String> item in tablelist)
                        {
                            DataRow newRow = dtNew.NewRow();
                            foreach (var structure in item)
                            {
                                newRow[structure.Key] = structure.Value;
                            }
                            dtNew.Rows.Add(newRow);
                        }
                        if (tableValueList.Keys.Contains(fieldName))
                        {
                            tableValueList[fieldName] = dtNew;
                        }
                        else
                        {
                            tableValueList.Add(fieldName, dtNew);
                        }
                    }
                    
                    
                }
                else //if(!String.IsNullOrEmpty(dataTypeName))
                {
                    String value = null ;
                    outlist.FieldValueList.TryGetValue(fieldName, out value);
                    if (value !=null)
                    {
                        row[FuncFieldText.DEFAULTVALUE] = value;
                    }
                    
                }
            }

        }
        public static void DataTableToList( DataTable dataTable, Dictionary<String, DataTable> tableValueList, ref MetaValueList inputList)
        {
          //  MetaValueList inputList = new MetaValueList();
            foreach (DataRow row in dataTable.Rows)
            {
                String dataType = row[FuncFieldText.DATATYPE].ToString();
                String fieldName = row[FuncFieldText.NAME].ToString();
                String defaultValue = row[FuncFieldText.DEFAULTVALUE].ToString();
              //  inputList.FieldTypeList.Add(fieldName, dataType);
                if (dataType == SAPDataType.STRUCTURE.ToString())
                {
                    DataTable dt = null;
                    tableValueList.TryGetValue(fieldName,out dt);
                    if (dt == null)
                    {
                        continue;
                    }
                    if (dt.Rows.Count == 1)
                    {
                        DataRow structure = dt.Rows[0];
                        Dictionary<String, String> list = new Dictionary<string, string>();
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            list.Add(dt.Columns[i].ColumnName, structure[i].ToString());
                        }
                        inputList.StructureValueList.Add(fieldName, list);
                    }
                }
                if (dataType == SAPDataType.TABLE.ToString())
                {
                    DataTable dt = null;
                    tableValueList.TryGetValue(fieldName, out dt);
                    if (dt == null)
                    {
                        continue;
                    }
                    if (dt.Rows.Count > 0)
                    {
                        List<Dictionary<String, String>> tableList = new List<Dictionary<string, string>>();
                        foreach (DataRow structure in dt.Rows)
                        {
                            Dictionary<String, String> list = new Dictionary<string, string>();
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                list.Add(dt.Columns[i].ColumnName, structure[i].ToString());
                            }
                            tableList.Add(list);
                        }
                        inputList.TableValueList.Add(fieldName, tableList);
                    }
                }
                else
                {
                    inputList.FieldValueList.Add(fieldName, defaultValue);
                }
            }
            
        }
    }
}
