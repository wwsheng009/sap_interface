using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SAP.Middleware.Connector;
namespace SAPINT.Function.Meta
{
    public static class SAPFunctionMeta
    {
        /// <summary>
        /// 把RFC中的字段元数据添加到Table中
        /// </summary>
        /// <param name="pMetadata"></param>
        /// <param name="dt"></param>
        private static void AddMetadataToTable(ref RfcParameterMetadata pMetadata, ref DataTable dt)
        {
            DataRow dtrow = dt.NewRow();
            dtrow["Name"] = pMetadata.Name;
            dtrow["DataType"] = pMetadata.DataType;
            dtrow["Decimals"] = pMetadata.Decimals;
            dtrow["DefaultValue"] = pMetadata.DefaultValue;
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
        /// <summary>
        /// 读取RFCFunction的所有元数据，并以DataTable的形式输出
        /// </summary>
        /// <param name="sysName"></param>
        /// <param name="funame"></param>
        /// <returns></returns>
        public static RfcFunctionMetaAsDataTable GetFuncMetaAsDataTable(string sysName, string funame)
        {
            RfcFunctionMetaAsDataTable metaTable = null;
            try
            {
                RfcFunctionMetadata MetaData = GetRfcFunctionMetadata(sysName, funame);
                metaTable = new RfcFunctionMetaAsDataTable();
                DataTable dtImport = RfcFunctionMetaAsDataTable.ParameterDefinitionView();
                DataTable dtExport = dtImport.Copy();
                DataTable dtChanging = dtImport.Copy(); ;
                DataTable dtTables = dtImport.Copy(); ;
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
                            DataTable dtStructure = RfcFunctionMetaAsDataTable.StructDefinitionView();
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
                            DataTable dtTable = RfcFunctionMetaAsDataTable.StructDefinitionView();
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
