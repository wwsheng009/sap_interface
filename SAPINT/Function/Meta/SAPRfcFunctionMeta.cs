using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SAP.Middleware.Connector;
using SAPINT.RFCTable;
namespace SAPINT.Function.Meta
{

    //生成对应的类定义
    public class CParams
    {
        public String paramclass { get; set; } // 参数类型
        public String parameter { get; set; } // 参数名称
        public String tabname { get; set; } // 表名
        public String fieldname { get; set; } // 字段名
        public String exid { get; set; } // ABAP/4 数据类型
        public int position { get; set; } //   结构中的字段位置(从1)
        public int offset { get; set; } // 结构初始的字段偏移(从0)
        public int intlength { get; set; } // 字段的内部长度
        public int decimals { get; set; } // 小数点后的位数
        public String defaultv { get; set; } // 输入参数的缺省值
        public String paramtext { get; set; } // 短文本
        public String optional { get; set; } // 可选参数
    }

    public static class SAPFunctionMeta
    {

        public static bool Is_rfc = false;

        /// <summary>
        /// 把RF函数中的字段元数据添加到Table中
        /// </summary>
        /// <param name="pMetadata"></param>
        /// <param name="dt"></param>
        private static void AddMetadataToTable(ref RfcParameterMetadata pMetadata, ref DataTable dt)
        {
            DataRow dtrow = dt.NewRow();
            dtrow["Name"] = pMetadata.Name;
            dtrow["DataType"] = pMetadata.DataType;
            dtrow["Decimals"] = pMetadata.Decimals;
            if (pMetadata.DefaultValue != null)
            {
                if (pMetadata.DefaultValue.StartsWith("'"))
                {
                    pMetadata.DefaultValue = pMetadata.DefaultValue.Remove(0, 1);
                }
                if (pMetadata.DefaultValue.EndsWith("'"))
                {
                    pMetadata.DefaultValue = pMetadata.DefaultValue.Remove(pMetadata.DefaultValue.Length - 1, 1);
                }
                if (pMetadata.DefaultValue.ToUpper() == "SPACE")
                {
                    pMetadata.DefaultValue = string.Empty;
                }
                dtrow["DefaultValue"] = pMetadata.DefaultValue;
            }


            dtrow["Length"] = pMetadata.NucLength;
            dtrow["Optional"] = pMetadata.Optional;
            dtrow["Documentation"] = pMetadata.Documentation;
            if (pMetadata.DataType == RfcDataType.STRUCTURE)
            {
                RfcContainerMetadata<RfcFieldMetadata> meta = pMetadata.ValueMetadataAsStructureMetadata;
                dtrow["DataTypeName"] = meta.Name;
            }
            else if (pMetadata.DataType == RfcDataType.TABLE)
            {
                RfcContainerMetadata<RfcFieldMetadata> meta = pMetadata.ValueMetadataAsTableMetadata;
                RfcTableMetadata tablem = pMetadata.ValueMetadataAsTableMetadata;
                dtrow["DataTypeName"] = tablem.LineType.Name;
            }
            else
            {

            }
            dt.Rows.Add(dtrow);
        }
        /// <summary>
        /// 读取RFC函数的全部信息
        /// </summary>
        /// <param name="sysName"></param>
        /// <param name="funame"></param>
        /// <returns></returns>
        public static RfcFunctionMetaAsList GetFuncMetaAsList(string sysName, string funame)
        {
            funame = funame.ToUpper().Trim();
            RfcFunctionMetadata MetaData = GetRfcFunctionMetadata(sysName, funame);
            RfcFunctionMetaAsList metaList = new RfcFunctionMetaAsList();
            // metaList.Import.Add(
            //根据参数的方向，分为四种（CHANGING,EXPORT,IMPORT,TABLES);
            for (int i = 0; i < MetaData.ParameterCount; i++)
            {
                RfcParameterMetadata pMetadata = MetaData[i];
                FunctionField field = null;
                String dataTypeName = String.Empty;
                if (pMetadata.DataType == RfcDataType.STRUCTURE)
                {
                    RfcContainerMetadata<RfcFieldMetadata> meta = pMetadata.ValueMetadataAsStructureMetadata;
                    dataTypeName = meta.Name;
                }
                else if (pMetadata.DataType == RfcDataType.TABLE)
                {
                    RfcContainerMetadata<RfcFieldMetadata> meta = pMetadata.ValueMetadataAsTableMetadata;
                    RfcTableMetadata tablem = pMetadata.ValueMetadataAsTableMetadata;
                    dataTypeName = tablem.LineType.Name;
                }
                field = new FunctionField(pMetadata.Name, pMetadata.Direction.ToString(), pMetadata.DataType.ToString(), pMetadata.Decimals, pMetadata.DefaultValue, pMetadata.NucLength, pMetadata.Optional, pMetadata.Documentation, dataTypeName);
                switch (pMetadata.Direction)
                {
                    //创建四个方向的参数列表
                    case RfcDirection.CHANGING:
                        metaList.Changing.Add(pMetadata.Name, field);
                        break;
                    case RfcDirection.EXPORT:
                        metaList.Export.Add(pMetadata.Name, field);
                        break;
                    case RfcDirection.IMPORT:
                        metaList.Import.Add(pMetadata.Name, field);
                        break;
                    case RfcDirection.TABLES:
                        metaList.Tables.Add(pMetadata.Name, field);
                        break;
                }
                if (pMetadata.DataType == RfcDataType.STRUCTURE)
                {
                    RfcContainerMetadata<RfcFieldMetadata> fieldMeta = pMetadata.ValueMetadataAsStructureMetadata;
                    if (!metaList.StructureDetail.Keys.Contains(fieldMeta.Name))
                    {
                        RfcStructureMetadata strucmeta = pMetadata.ValueMetadataAsStructureMetadata;
                        List<StructureField> fieldList = new List<StructureField>();
                        for (int f = 0; f < strucmeta.FieldCount; f++)
                        {
                            RfcFieldMetadata fieldm = strucmeta[f];
                            StructureField structureField = new StructureField(fieldm.Name, fieldm.DataType.ToString(), fieldm.Decimals, fieldm.NucLength, fieldm.Documentation);
                            fieldList.Add(structureField);
                        }
                        metaList.StructureDetail.Add(fieldMeta.Name, fieldList);
                    }
                }
                else if (pMetadata.DataType == RfcDataType.TABLE)
                {
                    RfcTableMetadata tableMeta = pMetadata.ValueMetadataAsTableMetadata;
                    if (!metaList.StructureDetail.Keys.Contains(tableMeta.LineType.Name))
                    {
                        List<StructureField> tableFieldList = new List<StructureField>();
                        for (int f = 0; f < tableMeta.LineType.FieldCount; f++)
                        {
                            RfcFieldMetadata fieldm = tableMeta.LineType[f];
                            StructureField structureField = new StructureField(fieldm.Name, fieldm.DataType.ToString(), fieldm.Decimals, fieldm.NucLength, fieldm.Documentation);
                            tableFieldList.Add(structureField);
                        }
                        metaList.StructureDetail.Add(tableMeta.LineType.Name, tableFieldList);
                    }
                }
            }
            return metaList;
        }

        /// <summary>
        ///根据函数名，返回函数的元数据，各个参数的名称，类型等。
        /// </summary>
        /// <param name="sysName"></param>
        /// <param name="funame"></param>
        /// <returns></returns>
        public static RfcFunctionMetadata GetRfcFunctionMetadata(string sysName, string funame)
        {
            funame = funame.ToUpper().Trim();
            if (string.IsNullOrEmpty(funame))
            {
                throw new SAPException("请输入函数！！");

            }
            if (!SAPFunction.CheckFunction(sysName, funame))
            {
                throw new SAPException("函数不存在！！");

            }
            RfcFunctionMetadata MetaData = null;
            try
            {
                RfcDestination destination = SAPDestination.GetDesByName(sysName);
                //destination.Repository.ClearAllMetadata();
                MetaData = destination.Repository.GetFunctionMetadata(funame);
            }
            catch (RfcAbapException rfce)
            {
                throw new SAPException(rfce.Key + rfce.Message);
            }
            catch (RfcAbapRuntimeException rfcrunteime)
            {
                throw new SAPException(rfcrunteime.Key + rfcrunteime.Message);
            }
            return MetaData;
        }

        //类型赋值
        private static List<CParams> get_Params_list(IRfcFunction pFunction)
        {
            List<CParams> _Params_list = new List<CParams>();
            IRfcTable rfctable_Params = pFunction.GetTable("PARAMS");

            // C${rfctable.Name} _C${rfctable.Name};
            for (int i = 0; i < rfctable_Params.RowCount; i++)
            {
                var _Params = new CParams();
                _Params.paramclass = rfctable_Params[i].GetString("PARAMCLASS"); // 参数类型
                _Params.parameter = rfctable_Params[i].GetString("PARAMETER"); // 参数名称
                _Params.tabname = rfctable_Params[i].GetString("TABNAME"); // 表名
                _Params.fieldname = rfctable_Params[i].GetString("FIELDNAME"); // 字段名
                _Params.exid = rfctable_Params[i].GetString("EXID"); // Typ
                _Params.position = rfctable_Params[i].GetInt("POSITION"); // 
                _Params.offset = rfctable_Params[i].GetInt("OFFSET"); // 
                _Params.intlength = rfctable_Params[i].GetInt("INTLENGTH"); // 
                _Params.decimals = rfctable_Params[i].GetInt("DECIMALS"); // 
                _Params.defaultv = rfctable_Params[i].GetString("DEFAULT"); // 输入参数的缺省值
                _Params.paramtext = rfctable_Params[i].GetString("PARAMTEXT"); // 短文本
                _Params.optional = rfctable_Params[i].GetString("OPTIONAL"); // 可选参数
                _Params_list.Add(_Params);
            }
            return _Params_list;
        }
        /// <summary>
        /// 有些SAP的函数RFC_GET_FUNCTION_INTERFACE不
        /// 支持返回REMOTE_CALL函数。
        /// 通过直接读取数据库表判断函数是否是RFC函数。
        /// </summary>
        /// <param name="pSystem"></param>
        /// <param name="pFunction"></param>
        /// <returns></returns>
        public static string CheckFunctionMode(string pSystem, String pFunction)
        {
            var _is_rfc = string.Empty;

            var _tfdir = new SAPINT.Utils.ReadTable(pSystem);
            _tfdir.TableName = "TFDIR";
            _tfdir.AddCriteria("FUNCNAME = '" + pFunction + "'");
            _tfdir.RowCount = 1;
            _tfdir.Run();
            var _tfdirResult = _tfdir.Result;
            if (_tfdirResult != null)
            {
                if (_tfdirResult.Rows.Count > 0)
                {
                    _is_rfc = _tfdirResult.Rows[0]["FMODE"].ToString();
                }
            }
            return _is_rfc;
        }
        public static List<CParams> getFunctionDef(string pSystem, string pFunction)
        {
            var _is_rfc = string.Empty;

            RfcDestination destination = SAPDestination.GetDesByName(pSystem);

            IRfcFunction _functionInterface = destination.Repository.CreateFunction("RFC_GET_FUNCTION_INTERFACE");
            _functionInterface.SetValue("FUNCNAME", pFunction);

            try
            {
                _functionInterface.Invoke(destination);

                int x = _functionInterface.Metadata.TryNameToIndex("REMOTE_CALL");
                if (x == -1)
                {
                    _is_rfc = CheckFunctionMode(pSystem, pFunction);
                }
                else
                {
                    //有些SAP的版本不支持这个传出参数。
                    _is_rfc = _functionInterface.GetString("REMOTE_CALL");
                }


                if (_is_rfc == "R")
                {
                    Is_rfc = true;

                }
                else
                {
                    Is_rfc = false;
                }
                return get_Params_list(_functionInterface);

            }
            catch (RfcAbapException abapEx)
            {
                throw new SAPException(abapEx.Key + abapEx.Message);
            }
            catch (RfcBaseException rfcbase)
            {
                throw new SAPException(rfcbase.Message);
            }
            catch (Exception ex)
            {
                throw new SAPException(ex.Message);
            }

        }

        public static FunctionMetaAsDataTable GetFuncMetaAsDataTable(string sysName, String funame)
        {
            FunctionMetaAsDataTable metaTable = null;

            List<CParams> parameters = getFunctionDef(sysName, funame);
            metaTable = new FunctionMetaAsDataTable();


            if (Is_rfc == true)
            {
                metaTable = GetRfcFuncMetaAsDataTable(sysName, funame);
                metaTable.Is_RFC = Is_rfc;
                return metaTable;
            }
            metaTable.Is_RFC = Is_rfc;
            DataTable dtImport = FunctionMetaAsDataTable.ParameterDefinitionView();
            DataTable dtExport = dtImport.Copy();
            DataTable dtChanging = dtImport.Copy();
            DataTable dtTables = dtImport.Copy();


            for (int i = 0; i < parameters.Count; i++)
            {
                var item = parameters[i];
                switch (item.paramclass)
                {
                    case "I":
                        AddMetadataToTable2(ref item, ref dtImport);
                        break;
                    case "E":
                        AddMetadataToTable2(ref item, ref dtExport);
                        break;
                    case "T":
                        AddMetadataToTable2(ref item, ref dtTables);
                        break;
                    case "C":
                        AddMetadataToTable2(ref item, ref dtChanging);
                        break;
                    case "X":
                        //AddMetadataToTable2(ref item, ref );
                        break;
                    default:
                        break;
                }



                if (item.paramclass == "T")
                {
                    if (!metaTable.StructureDetail.Keys.Contains(item.tabname))
                    {
                        //在这里创建结构体的定义表格
                        DataTable dtStructure = FunctionMetaAsDataTable.StructDefinitionView();
                        var tableInfo = new SAPTableInfo(sysName, item.tabname);

                        var fields = tableInfo.Fields;

                        foreach (var field in fields)
                        {
                            DataRow dr = dtStructure.NewRow();
                            dr["Name"] = field.FIELDNAME;
                            dr["DataType"] = field.DOMNAME;
                            dr["Decimals"] = field.DECIMALS;
                            dr["Length"] = field.OUTPUTLEN;
                            dr["Documentation"] = field.SCRTEXT_L;

                            dtStructure.Rows.Add(dr);
                        }

                        metaTable.StructureDetail.Add(item.tabname, dtStructure);
                    }
                }
            }

            metaTable.Import = dtImport;
            metaTable.Export = dtExport;
            metaTable.Changing = dtChanging;
            metaTable.Tables = dtTables;
            return metaTable;

        }
        private static void AddMetadataToTable2(ref CParams pMetadata, ref DataTable dt)
        {
            DataRow dtrow = dt.NewRow();
            dtrow["Name"] = pMetadata.parameter;
            if (!string.IsNullOrEmpty(pMetadata.exid))
            {
                switch (pMetadata.exid)
                {
                    case "C":
                        dtrow["DataType"] = "TYPE";
                        break;
                    case "I":
                        dtrow["DataType"] = "TYPE";
                        break;
                    case "u":
                        dtrow["DataType"] = "TABLE";
                        break;
                    case "X":
                        dtrow["DataType"] = "LIKE";
                        break;
                    case "h"://表类型
                        dtrow["DataType"] = "TABLE";
                        break;
                    default:
                        dtrow["DataType"] = "";
                        break;
                }
            }


            dtrow["Decimals"] = pMetadata.decimals;

            if (pMetadata.defaultv.StartsWith("'"))
            {
                pMetadata.defaultv = pMetadata.defaultv.Remove(0, 1);
            }
            if (pMetadata.defaultv.EndsWith("'"))
            {
                pMetadata.defaultv = pMetadata.defaultv.Remove(pMetadata.defaultv.Length - 1, 1);
            }
            if (pMetadata.defaultv.ToUpper() == "SPACE")
            {
                pMetadata.defaultv = string.Empty;
            }
            dtrow["DefaultValue"] = pMetadata.defaultv;

            dtrow["Length"] = pMetadata.intlength;
            if (pMetadata.optional == "X")
            {
                dtrow["Optional"] = true;
            }
            else
            {
                dtrow["Optional"] = false;
            }

            dtrow["Documentation"] = pMetadata.paramtext;
            if (String.IsNullOrEmpty(pMetadata.fieldname))
            {
                dtrow["DataTypeName"] = pMetadata.tabname;
            }
            else
            {
                dtrow["DataTypeName"] = pMetadata.tabname + "-" + pMetadata.fieldname;

            }


            dt.Rows.Add(dtrow);
        }

        /// <summary>
        /// 读取RFCFunction的所有元数据，并以DataTable的形式输出
        /// </summary>
        /// <param name="sysName"></param>
        /// <param name="funame"></param>
        /// <returns></returns>
        public static FunctionMetaAsDataTable GetRfcFuncMetaAsDataTable(string sysName, string funame)
        {
            FunctionMetaAsDataTable metaTable = null;
            try
            {
                RfcFunctionMetadata MetaData = GetRfcFunctionMetadata(sysName, funame);
                metaTable = new FunctionMetaAsDataTable();
                DataTable dtImport = FunctionMetaAsDataTable.ParameterDefinitionView();
                DataTable dtExport = dtImport.Copy();
                DataTable dtChanging = dtImport.Copy();
                DataTable dtTables = dtImport.Copy();
                //根据参数的方向，分为四种（CHANGING,EXPORT,IMPORT,TABLES);
                for (int i = 0; i < MetaData.ParameterCount; i++)
                {
                    RfcParameterMetadata pMetadata = MetaData[i];
                    switch (pMetadata.Direction)
                    {
                        //创建四个方向的参数列表
                        case RfcDirection.CHANGING:
                            AddMetadataToTable(ref pMetadata, ref dtChanging);
                            break;
                        case RfcDirection.EXPORT:
                            AddMetadataToTable(ref pMetadata, ref dtExport);
                            break;
                        case RfcDirection.IMPORT:
                            AddMetadataToTable(ref pMetadata, ref dtImport);
                            break;
                        case RfcDirection.TABLES:
                            AddMetadataToTable(ref pMetadata, ref dtTables);
                            break;
                    }
                    if (pMetadata.DataType == RfcDataType.STRUCTURE)
                    {
                        RfcStructureMetadata strucmeta = pMetadata.ValueMetadataAsStructureMetadata;
                        RfcContainerMetadata<RfcFieldMetadata> meta = pMetadata.ValueMetadataAsStructureMetadata;
                        if (!metaTable.StructureDetail.Keys.Contains(meta.Name))
                        {
                            //在这里创建结构体的定义表格
                            DataTable dtStructure = FunctionMetaAsDataTable.StructDefinitionView();
                            for (int f = 0; f < strucmeta.FieldCount; f++)
                            {
                                DataRow dr = dtStructure.NewRow();
                                RfcFieldMetadata fieldm = strucmeta[f];
                                dr["Name"] = fieldm.Name;
                                dr["DataType"] = fieldm.DataType.ToString();
                                dr["Decimals"] = fieldm.Decimals;
                                dr["Length"] = fieldm.NucLength;
                                dr["Documentation"] = fieldm.Documentation;
                                dtStructure.Rows.Add(dr);
                            }
                            metaTable.StructureDetail.Add(meta.Name, dtStructure);
                        }
                        if (!metaTable.InputTable.Keys.Contains(pMetadata.Name))
                        {
                            //用于输入数据的DataTable;
                            DataTable dtInput = new DataTable();
                            for (int f = 0; f < strucmeta.FieldCount; f++)
                            {
                                RfcFieldMetadata fieldm = strucmeta[f];
                                DataColumn dc = null;
                                String colName = fieldm.Name;
                                dc = new DataColumn(colName, Type.GetType("System.String"));
                                dc.MaxLength = fieldm.NucLength;
                                dc.Caption = fieldm.Documentation;
                                dtInput.Columns.Add(dc);
                            }
                            metaTable.InputTable.Add(pMetadata.Name, dtInput);
                        }

                    }
                    else if (pMetadata.DataType == RfcDataType.TABLE)
                    {
                        //在这里创建表的定义明细表格
                        RfcTableMetadata tablem = pMetadata.ValueMetadataAsTableMetadata;
                        if (!metaTable.StructureDetail.Keys.Contains(tablem.LineType.Name))
                        {
                            DataTable dtTable = FunctionMetaAsDataTable.StructDefinitionView();
                            for (int f = 0; f < tablem.LineType.FieldCount; f++)
                            {
                                DataRow dr = dtTable.NewRow();
                                RfcFieldMetadata fieldm = tablem.LineType[f];
                                dr["Name"] = fieldm.Name;
                                dr["DataType"] = fieldm.DataType;
                                dr["Decimals"] = fieldm.Decimals;
                                dr["Length"] = fieldm.NucLength;
                                dr["Documentation"] = fieldm.Documentation;
                                dtTable.Rows.Add(dr);
                            }
                            metaTable.StructureDetail.Add(tablem.LineType.Name, dtTable);
                        }
                        if (!metaTable.InputTable.Keys.Contains(pMetadata.Name))
                        {
                            //用于输入数据的DataTable;
                            DataTable dtInput = new DataTable();
                            for (int f = 0; f < tablem.LineType.FieldCount; f++)
                            {
                                RfcFieldMetadata fieldm = tablem.LineType[f];
                                DataColumn dc = null;
                                String colName = fieldm.Name;
                                dc = new DataColumn(colName, Type.GetType("System.String"));
                                dc.MaxLength = fieldm.NucLength;
                                dc.Caption = fieldm.Documentation;
                                dtInput.Columns.Add(dc);
                            }
                            metaTable.InputTable.Add(pMetadata.Name, dtInput);
                        }

                    }
                }
                metaTable.Import = dtImport;
                metaTable.Export = dtExport;
                metaTable.Changing = dtChanging;
                metaTable.Tables = dtTables;
            }
            catch (Exception ee)
            {
                metaTable = null;
                throw new SAPException(ee.Message);
            }
            return metaTable;
        }


    }
}
