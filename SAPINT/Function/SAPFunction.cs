namespace SAPINT.Function
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
   // using System.Data.SQLite;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using SAP.Middleware.Connector;
    using SAPINT.DbHelper;
    using SAPINT.Function.Meta;
    //与SAP间的接口。
    public static class SAPFunction
    {
        #region Methods

        /// <summary>
        /// 动态调用RFC函数
        /// </summary>
        /// <param name="sysName"></param>
        /// <param name="funame"></param>
        /// <param name="input"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public static bool InvokeFunction(string sysName, string funame, MetaValueList input, out MetaValueList output)
        {
            try
            {
                RfcFunctionMetadata MetaData = SAPFunctionMeta.getRfcFunctionMetadata(sysName, funame);
                IRfcFunction function = MetaData.CreateFunction();
                //初步序列化后的参数还需要进一步进行格式化，把结构体与表格都转化成SAP格式。
                if (input != null)
                {
                    //填充所有的参数
                    List<String> KeyIndex = new List<string>();
                    KeyIndex.AddRange(input.FieldValueList.Keys);
                    KeyIndex.AddRange(input.StructureValueList.Keys);
                    KeyIndex.AddRange(input.TableValueList.Keys);
                    KeyIndex.ForEach(x => x.ToUpper().Trim());
                    for (int i = 0; i < MetaData.ParameterCount; i++)
                    {
                        RfcParameterMetadata pMetadata = MetaData[i];
                        if (pMetadata.Direction == RfcDirection.EXPORT)
                        {
                            continue;
                        }
                        if (!KeyIndex.Contains(pMetadata.Name))
                        {
                            continue;
                        }

                        // Dictionary<String, Object> ParameterList = new Dictionary<string, object>();
                        if (pMetadata.DataType == RfcDataType.STRUCTURE)
                        {
                            if (input.StructureValueList.ContainsKey(pMetadata.Name))
                            {
                                Dictionary<String, String> structure;
                                input.StructureValueList.TryGetValue(pMetadata.Name, out structure);
                                IRfcStructure str = function.GetStructure(pMetadata.Name, true);
                                if (structure != null)
                                {
                                    for (int s = 0; s < str.Metadata.FieldCount; s++)
                                    {
                                        RfcFieldMetadata field = str.Metadata[s];
                                        if (structure.Keys.Contains(field.Name))
                                        {
                                            Object o = Converts.ObjectToRfcValue(structure[field.Name], field.DataType);
                                            str.SetValue(field.Name, o);
                                        }

                                    }
                                }
                            }
                        }
                        else if (pMetadata.DataType == RfcDataType.TABLE)
                        {
                            List<Dictionary<String, String>> tablelist;
                            input.TableValueList.TryGetValue(pMetadata.Name, out tablelist);
                            if (tablelist != null)
                            {
                                IRfcTable table = function.GetTable(pMetadata.Name);
                                for (int j = 0; j < tablelist.Count; j++)
                                {
                                    table.Append();
                                    for (int k = 0; k < table.Metadata.LineType.FieldCount; k++)
                                    {
                                        RfcFieldMetadata field = table.Metadata.LineType[k];
                                        if (tablelist[j].Keys.Contains(field.Name))
                                        {
                                            Object o = Converts.ObjectToRfcValue(tablelist[j][field.Name], field.DataType);
                                            table.SetValue(field.Name, o);
                                        }
                                    }
                                }
                            }

                        }
                        else
                        {
                            String value = "";
                            input.FieldValueList.TryGetValue(pMetadata.Name, out value);
                            Object o = Converts.ObjectToRfcValue(value, pMetadata.DataType);
                            function.SetValue(pMetadata.Name, o);
                        }
                    }
                }
                try
                {
                    RfcDestination destination = SAPDestination.GetDesByName(sysName);
                    function.Invoke(destination);
                }
                catch (RfcAbapException ee)
                {
                    throw new SAPException(ee.Key + ee.Message + ee.PlainText);
                }
                catch (RfcAbapRuntimeException runtimeEx)
                {
                    throw new SAPException(runtimeEx.Key + runtimeEx.Message + runtimeEx.PlainText);
                }

                MetaValueList outputlist = new MetaValueList();
                for (int i = 0; i < MetaData.ParameterCount; i++)
                {

                    RfcParameterMetadata pMetadata = MetaData[i];
                    if (pMetadata.Direction == RfcDirection.IMPORT)
                    {
                        continue;
                    }
                   // outputlist.FieldTypeList.Add(pMetadata.Name, pMetadata.DataType.ToString());
                    if (pMetadata.DataType == RfcDataType.STRUCTURE)
                    {
                        Dictionary<String, String> stru = null;
                        IRfcStructure structure = function.GetStructure(pMetadata.Name, false);
                        if (structure != null)
                        {
                            stru = new Dictionary<string, string>();
                            for (int s = 0; s < structure.Metadata.FieldCount; s++)
                            {
                                RfcFieldMetadata field = structure.Metadata[s];
                                object result = structure.GetObject(field.Name).ToString();
                                result = Converts.RfcToDoNetValue(result, field.DataType).ToString();
                                stru.Add(field.Name, result.ToString());
                            }
                            if (stru != null)
                            {
                                outputlist.StructureValueList.Add(pMetadata.Name, stru);
                            }
                        }
                    }
                    else if (pMetadata.DataType == RfcDataType.TABLE)
                    {
                        List<Dictionary<String, String>> outTableList = null;
                        IRfcTable outTable = function.GetTable(pMetadata.Name, false);
                        if (outTable != null)
                        {
                            outTableList = new List<Dictionary<string, string>>();
                            for (int s = 0; s < outTable.RowCount; s++)
                            {
                                IRfcStructure rfcTableLine = outTable[s];
                                Dictionary<String, String> row = new Dictionary<string, string>();
                                for (int z = 0; z < rfcTableLine.Metadata.FieldCount; z++)
                                {
                                    RfcFieldMetadata field = rfcTableLine[z].Metadata;
                                    Object result = rfcTableLine.GetObject(field.Name);
                                    result = Converts.RfcToDoNetValue(result, field.DataType).ToString();
                                    row.Add(field.Name, result.ToString());
                                }
                                outTableList.Add(row);
                            }
                        }
                        outputlist.TableValueList.Add(pMetadata.Name, outTableList);
                    }
                    else
                    {
                        Object result = function.GetObject(pMetadata.Name);
                        result = Converts.RfcToDoNetValue(result, pMetadata.DataType);
                        outputlist.FieldValueList.Add(pMetadata.Name, result.ToString());
                    }
                }
                output = outputlist;
                return true;
            }
            catch (Exception e)
            {
                output = null;
                throw new SAPException(e.Message);
            }

        }

        //测试使用CustomDestination,运行时修改用户与密码
        public static string login(string usname, string password, string client, string lang)
        {
            try
            {
                //RfcCustomDestination des = SAPDestination.GetDesByName("DM0_800").CreateCustomDestination();
                RfcCustomDestination des = SAPDestination.GetDesByName(ConfigFileTool.SAPGlobalSettings.GetDefaultSapCient()).CreateCustomDestination();
                // SAPBackupConfig config = new SAPBackupConfig();
                //RfcConfigParameters paras =  config.GetParameters("DM0_800");
                des.User = usname;
                des.Password = password;
                des.Client = client;
                des.Language = lang;
                IRfcFunction ping = des.Repository.CreateFunction("RFC_PING");
                ping.Invoke(des);
                return "Success";
            }
            catch (RfcAbapException rfce)
            {
                // return "Failed";
                throw new SAPException(rfce.Key + rfce.Message);
            }
        }
        public static bool CheckFunction(string sysName, string functionName)
        {
            try
            {
                RfcDestination destination = SAPDestination.GetDesByName(sysName);
                string _funame = functionName;
                IRfcFunction RFC_FUNCTION_SEARCH = destination.Repository.CreateFunction("RFC_FUNCTION_SEARCH");
                RFC_FUNCTION_SEARCH.SetValue("FUNCNAME", _funame);
                RFC_FUNCTION_SEARCH.Invoke(destination);
                IRfcTable FUNCTIONS = RFC_FUNCTION_SEARCH.GetTable("FUNCTIONS");
                if (FUNCTIONS.RowCount == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (RfcAbapException rfce)
            {
                throw new SAPException(rfce.Key + rfce.Message);
            }
        }
        /// <summary>
        /// 封装RFC函数DDIF_FIELDINFO_GET，传入表名，返回具体信息。
        /// </summary>
        /// <param name="sysName"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static DataTable DDIF_FIELDINFO_GET(String sysName, String TableName)
        {
            try
            {
                RfcDestination destination = SAPDestination.GetDesByName(sysName);
                IRfcFunction RFC_FUNCTION_SEARCH = destination.Repository.CreateFunction("DDIF_FIELDINFO_GET");
                RFC_FUNCTION_SEARCH.SetValue("TABNAME", TableName);
                RFC_FUNCTION_SEARCH.Invoke(destination);
                IRfcTable DFIES_TAB = RFC_FUNCTION_SEARCH.GetTable("DFIES_TAB");
                DataTable dt = RfcTableToDataTable(DFIES_TAB);
                return dt;
            }
            catch(RfcAbapException abapException)
            {
                throw new SAPException(abapException.Key + abapException.Message);
            }
            catch (RfcAbapBaseException abapbaseException)
            {
                throw new SAPException(abapbaseException.PlainText+ abapbaseException.Message);
            }
            catch (Exception ex)
            {

                throw new SAPException(ex.Message);
            }

        }
        //把RFCTABLE 转换成DataTable.
        public static DataTable RfcTableToDataTable(IRfcTable rfcTable)
        {
            DataTable dtRet = new DataTable();
            for (int liElement = 0; liElement < rfcTable.ElementCount; liElement++)
            {

                RfcElementMetadata rfcEMD = rfcTable.GetElementMetadata(liElement);
                //Console.WriteLine("Name:" + rfcEMD.Name);
                //Console.WriteLine("DatType:" + rfcEMD.DataType);
                dtRet.Columns.Add(rfcEMD.Name, RfcTypeConvertor.RfcTypeToSystemType(rfcEMD.DataType));
            }
            foreach (IRfcStructure row in rfcTable)
            {
                DataRow dr = dtRet.NewRow();
                for (int liElement = 0; liElement < rfcTable.ElementCount; liElement++)
                {
                    RfcElementMetadata rfcEMD = rfcTable.GetElementMetadata(liElement);
                    //Console.WriteLine("Name:" + rfcEMD.Name);
                    //Console.WriteLine("DatType:" + rfcEMD.DataType);
                    //Console.WriteLine("Object:" + row.GetObject(liElement));
                    Object o = Converts.RfcToDoNetValue(row.GetObject(liElement), rfcEMD.DataType);
                    if (String.IsNullOrWhiteSpace(o.ToString()))
                    {
                        o = "";
                    }
                    //Console.WriteLine("ConvertedValue:  " + o);
                    //Console.WriteLine("");
                    dr[rfcEMD.Name] = o;
                }
                dtRet.Rows.Add(dr);
            }
            return dtRet;
        }

        //public static rfcdestination getdestination(string sysname)
        //{
        //    return sapdestination.getdesbyname(sysname);
        //}

        /// <summary>
        /// 搜索SAP中所有的RFC函数，如果函数名为空，读取所有的函数列表
        /// 并直接在储到数据库中
        /// </summary>
        /// <param name="sysName"></param>
        /// <param name="functionName"></param>
        /// <returns></returns>
        public static bool GetRFCfunctionListAndSaveToSqliteDb(string sysName, string functionName)
        {
            try
            {
                RfcDestination destination = SAPDestination.GetDesByName(sysName);
                string _funame = string.Format("*{0}*", functionName);
                IRfcFunction RFC_FUNCTION_SEARCH = destination.Repository.CreateFunction("RFC_FUNCTION_SEARCH");
                RFC_FUNCTION_SEARCH.SetValue("FUNCNAME", _funame);
                RFC_FUNCTION_SEARCH.Invoke(destination);
                IRfcTable FUNCTIONS = RFC_FUNCTION_SEARCH.GetTable("FUNCTIONS");
                if (FUNCTIONS.RowCount > 0)
                {
                   // RfcTableToDb dbhelper = new RfcTableToDb("RFC_FUNCTIONS", "FUNCTIONS", FUNCTIONS);
                  //  dbhelper.saveTable();
                    //ThreadStart threadStart = new ThreadStart(dbhelper.saveTable);
                    //Thread thread = new Thread(threadStart);
                    //thread.Start();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (RfcAbapException rfce)
            {
                throw new SAPException(rfce.Key + rfce.Message);
            }
            catch (Exception e)
            {
                throw new SAPException(e.Message);
            }
        }

        
        #endregion Methods
    }
}