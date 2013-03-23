using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using SAP.Middleware.Connector;
using SAPINT.DbHelper;
using SAPINT.Function.Meta;

namespace SAPINT.Function
{
    /// <summary>
    /// 专门处理与Json格式相关的数据
    /// </summary>
    public static class SAPFunctionJson
    {
        //获取与服务器的连接信息
        public static string GetSever(string sysName)
        {
            string output = "";
            RfcDestination destination = SAPDestination.GetDesByName(sysName);
            output = JsonConvert.SerializeObject(destination);
            return output;
        }
        /// <summary>
        /// 根据Json数据进行函数调用。
        /// </summary>
        /// <param name="jsondata"></param>
        /// <param name="funame"></param>
        /// <returns></returns>
        public static string PostJson(string sysName, string funame, string jsondata)
        {
            funame = funame.ToUpper();
            if (funame == "")
            {
                return @"{'error': '函数名为空'}";
            }
            //保留反序列化后的传入参数。
            RfcInputListJson list;
            try
            {
                list = JsonConvert.DeserializeObject<RfcInputListJson>(jsondata);
            }
            catch (Exception ee)
            {
                return JsonConvert.SerializeObject(ee);
            }
            if (list == null)
            {
                return @"{'Message': '参数列表为空'}";
            }
            RfcOutputListJson outlist = new RfcOutputListJson();
            try
            {
                var b = InvokeFunctionFromJson(sysName, funame, list, out outlist);
                if (b == false)
                {
                    return @"{'Message': '调用出错'}";
                }
            }
            catch (Exception ee)
            {
                return JsonConvert.SerializeObject(ee);
            }

            string output = "";
            //序列化并输出结果
            output = JsonConvert.SerializeObject(outlist, new JsonSerializerSettings
            {
                Error = delegate(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs args)
                {
                    // errors.Add(args.ErrorContext.Error.Message);
                    args.ErrorContext.Handled = true;
                }
                // Converters = { new IsoDateTimeConverter() }
            });
            return output;
        }
        /// <summary>
        /// 填充所有的参数调用SAP RFC函数后，填充所有的参数
        /// </summary>
        /// <param name="funame">函数名</param>
        /// <param name="list">输入参数列表</param>
        /// <param name="olist">输出参数列表</param>
        /// <returns></returns>
        private static bool InvokeFunctionFromJson(string sysName, string funame, RfcInputListJson list, out RfcOutputListJson olist)
        {
            try
            {
                if (funame == "" || null == list)
                {
                    olist = null;
                    return false;
                }
                if (!SAPFunction.CheckFunction(sysName, funame))
                {
                    olist = null;
                    return false;
                }
                RfcDestination destination = SAPDestination.GetDesByName(sysName);
                RfcFunctionMetadata MetaData = destination.Repository.GetFunctionMetadata(funame);
                IRfcFunction function = MetaData.CreateFunction();
                //初步序列化后的参数还需要进一步进行格式化，把结构体与表格都转化成SAP格式。
                list.All.Clear();
                list.All.AddRange(list.Import);
                list.All.AddRange(list.Change);
                list.All.AddRange(list.Tables);
                foreach (var item in list.All)
                {
                    if (item.Value == null)
                    {
                        continue;
                    }
                    RfcParameterMetadata p = MetaData[item.Name];
                    if (p == null)
                    {
                        continue;
                    }
                    //尝试把OBJECT反解析成对应的类型
                    if (p.DataType == RfcDataType.STRUCTURE)
                    {
                        Console.WriteLine(item.Value.GetType().ToString());
                        if (item.Value.GetType().ToString() != "Newtonsoft.Json.Linq.JArray" && item.Value.GetType().ToString() != "System.Array")
                        {
                            continue;
                        }
                        if (item.Value.GetType().ToString() != "System.Array")
                        {
                            // continue;
                        }
                        IRfcStructure str = function.GetStructure(item.Name, true);
                        var arr = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(item.Value.ToString());
                        if (arr.Count == 1)
                        {
                            //结构使用第一行
                            var o = arr[0];
                            for (int s = 0; s < str.Metadata.FieldCount; s++)
                            {
                                RfcFieldMetadata field = str.Metadata[s];
                                str.SetValue(field.Name, o[field.Name]);
                            }
                        }
                        item.Value = str;
                    }
                    else if (p.DataType == RfcDataType.TABLE)
                    {
                        if (string.IsNullOrEmpty(item.Value.ToString()))
                        {
                            continue;
                        }
                        IRfcTable tbl = function.GetTable(item.Name, true);
                        var arr = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(item.Value.ToString());
                        for (int x = 0; x < arr.Count; x++)
                        {
                            IRfcStructure str = tbl.Metadata.LineType.CreateStructure();
                            for (int s = 0; s < tbl.Metadata.LineType.FieldCount; s++)
                            {
                                RfcFieldMetadata field = tbl.Metadata.LineType[s];
                                str.SetValue(field.Name, arr[x][field.Name]);
                            }
                            tbl.Append(str);
                        }
                        item.Value = tbl;
                    }
                }
                //填充所有的参数
                for (int i = 0; i < MetaData.ParameterCount; i++)
                {
                    RfcParameterMetadata pMetadata = MetaData[i];
                    if (list.All.Exists(x => x.Name == pMetadata.Name))
                    {
                        var value = list.All.Find(x => x.Name == pMetadata.Name).Value;
                        if (value != null)
                        {
                            function.SetValue(pMetadata.Name, value);
                        }
                    }
                }
                //远程调用函数
                try
                {
                    function.Invoke(destination);
                }
                catch (RfcAbapException ee)
                {
                    throw new Exception(ee.Key + ee.Message);
                }
                //保留调用结果。
                RfcOutputListJson outlist = new RfcOutputListJson();
                //循环读取结果。把所以的结果都保存到List<object>中。
                for (int i = 0; i < MetaData.ParameterCount; i++)
                {
                    RfcParameterMetadata pMetadata = MetaData[i];
                    //
                    if (pMetadata.Direction == RfcDirection.IMPORT)
                    {
                        continue;
                    }
                    RfcKeyValueJson d = new RfcKeyValueJson();
                    d.Name = pMetadata.Name;
                    if (pMetadata.DataType == RfcDataType.STRUCTURE)
                    {
                        //注意，在这里就算是结构体，也把放到List中，这样可以序列化成数组格式。
                        List<object> tb_list = new List<object>();
                        IRfcStructure row = function.GetStructure(pMetadata.Name);
                        Dictionary<string, object> rowd = new Dictionary<string, object>();
                        for (int x = 0; x < row.Metadata.FieldCount; x++)
                        {
                            rowd.Add(row[x].Metadata.Name, row[x].GetValue());
                        }
                        tb_list.Add(rowd);
                        d.Value = tb_list;
                    }
                    else if (pMetadata.DataType == RfcDataType.TABLE)
                    {
                        List<object> tb_list = new List<object>();
                        IRfcTable tble = function.GetTable(pMetadata.Name);
                        var readItems = tble.RowCount;
                        if (readItems > 0)
                        {
                            try
                            {
                               // RfcTableToDb dbhelper = new RfcTableToDb(funame, d.Name, tble);
                              //  dbhelper.saveTable();
                            }
                            catch (Exception ee)
                            {
                                throw new Exception(ee.Message);
                            }
                            // ThreadStart threadStart = new ThreadStart(dbhelper.saveTable);
                            //  Thread thread = new Thread(threadStart);
                            //  thread.Start();
                            //DbHelper.saveRfcTable(funame,ref tble);
                        }
                        //控制100条，数据过多会序列华出错。以后再做改善，
                        if (readItems > 10)
                        {
                            readItems = 10;
                        }
                        for (int rowc = 0; rowc < readItems; rowc++)
                        {
                            IRfcStructure row = tble[rowc];
                            Dictionary<string, object> rowd = new Dictionary<string, object>();
                            for (int x = 0; x < row.Metadata.FieldCount; x++)
                            {
                                rowd.Add(row[x].Metadata.Name, row[x].GetValue());
                            }
                            tb_list.Add(rowd);
                        }
                        d.Value = tb_list;
                    }
                    else
                    {
                        d.Value = function.GetValue(pMetadata.Name);
                    }
                    //存放于不同的集合也是为了序列化方便。
                    switch (pMetadata.Direction)
                    {
                        case RfcDirection.CHANGING:
                            outlist.Change.Add(d);
                            break;
                        case RfcDirection.EXPORT:
                            outlist.Export.Add(d);
                            break;
                        case RfcDirection.IMPORT:
                            outlist.Import.Add(d);
                            break;
                        case RfcDirection.TABLES:
                            outlist.Tables.Add(d);
                            break;
                    }
                }
                olist = outlist;
                return true;
            }
            catch (Exception e)
            {
                throw new SAPException(e.Message);
            }
        }
        public static RfcOutputListJson GetFunMetaList(string sysName, string funame)
        {
            RfcOutputListJson paralist = new RfcOutputListJson();
            try
            {
                if (string.IsNullOrEmpty(funame))
                {
                    throw new SAPException("请输入函数！！");
                }
                if (!SAPFunction.CheckFunction(sysName, funame))
                {
                    throw new SAPException("函数不存在！！");
                }
                funame = funame.ToUpper();
                RfcDestination destination = SAPDestination.GetDesByName(sysName);
                destination.Repository.ClearAllMetadata();
                RfcFunctionMetadata MetaData = destination.Repository.GetFunctionMetadata(funame);
                IRfcFunction function = null;
                function = MetaData.CreateFunction();

                //根据参数的方向，分为四种（CHANGING,EXPORT,IMPORT,TABLES);
                for (int i = 0; i < MetaData.ParameterCount; i++)
                {
                    RfcParameterMetadata pMetadata = MetaData[i];
                    paralist.All.Add(pMetadata);
                    switch (pMetadata.Direction)
                    {
                        case RfcDirection.CHANGING:
                            paralist.Change.Add(pMetadata);
                            break;
                        case RfcDirection.EXPORT:
                            paralist.Export.Add(pMetadata);
                            break;
                        case RfcDirection.IMPORT:
                            paralist.Import.Add(pMetadata);
                            break;
                        case RfcDirection.TABLES:
                            paralist.Tables.Add(pMetadata);
                            break;
                    }
                    //参数也可能是结构体，表，ABAP对象
                    //一定要分开TRY，因为有些是没有的
                    if (pMetadata.DataType == RfcDataType.STRUCTURE)
                    {
                        try
                        {
                            //结构体的行项目结构
                            List<object> elelist = new List<object>();
                            RfcStructureMetadata strucmeta = pMetadata.ValueMetadataAsStructureMetadata;
                            for (int f = 0; f < strucmeta.FieldCount; f++)
                            {
                                RfcFieldMetadata fieldm = strucmeta[f];
                                elelist.Add(fieldm);
                            }
                            paralist.Objects.Add(pMetadata.Name, elelist);
                        }
                        catch (Exception)
                        {
                            //  throw new SAPException(ee.Message);
                        }
                    }
                    if (pMetadata.DataType == RfcDataType.TABLE)
                    {
                        //表结构的行项目结构
                        List<object> tbllist = new List<object>();
                        RfcTableMetadata tablem = pMetadata.ValueMetadataAsTableMetadata;
                        for (int t = 0; t < tablem.LineType.FieldCount; t++)
                        {
                            RfcFieldMetadata fieldm = tablem.LineType[t];
                            tbllist.Add(fieldm);
                        }
                        paralist.Objects.Add(pMetadata.Name, tbllist);
                    }
                    if (pMetadata.DataType == RfcDataType.CLASS)
                    {
                        //abap object 属性
                        List<object> attlist = new List<object>();
                        RfcAbapObjectMetadata abapitem = pMetadata.ValueMetadataAsAbapObjectMetadata;
                        for (int o = 0; o < abapitem.AttributeCount; o++)
                        {
                            RfcAttributeMetadata abapobject = abapitem[o];
                            attlist.Add(abapobject);
                        }
                        paralist.Objects.Add(pMetadata.Name, attlist);
                    }

                }
                return paralist;
            }
            catch (Exception ee)
            {
                throw new SAPException(ee.Message);
            }
        }

        /// <summary>
        /// 测试读取RFC函数的所有的函数的元数据
        /// 返回JSON格式
        /// </summary>
        /// <param name="sysName"></param>
        /// <param name="funame"></param>
        /// <param name="outJson"></param>
        /// <returns></returns>
        public static bool GetFuncMeta(string sysName, string funame, out string outJson)
        {
            string output = "";
            try
            {
                RfcOutputListJson paralist = GetFunMetaList(sysName, funame);
                if (paralist == null)
                {
                    output = JsonConvert.SerializeObject("连接SAP系统出错！！！");
                }
                //输出时忽略转换错误
                output = JsonConvert.SerializeObject(paralist, new JsonSerializerSettings
                {
                    Error = delegate(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs args)
                    {
                        // errors.Add(args.ErrorContext.Error.Message);
                        args.ErrorContext.Handled = true;
                    }
                    // Converters = { new IsoDateTimeConverter() }
                }
                );
                outJson = output;
                return true;
            }
            catch (Exception ee)
            {
                outJson = JsonConvert.SerializeObject(ee);
                throw new SAPException(ee.Message);
            }

        }

    }
}
