using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;

namespace SAPINT.Idocs.Meta
{
    /// <summary>
    /// 从SAP的数据库中读取IDOC数据，并且解析成一个IDOC对象。
    /// </summary>
    public class IdocUtil
    {
        private String SystemName { get; set; }
        private List<String> segNameList { get; set; }


        public IdocUtil()
        {
            SystemName = new ConfigFileTool.SAPGlobalSettings().GetDefaultSapCient();
        }
        public IdocUtil(String psysName)
        {
            SystemName = psysName;
            segNameList = new List<string>();
        }

        /// <summary>
        /// 根据IDOC编号从SAP系统里读取一个idoc
        /// </summary>
        /// <param name="idocNumber"></param>
        /// <returns></returns>
        public Idoc getIodcFromSapDataBase(String idocNumber)
        {
            SAPINT.Utils.ReadTable idocReadItem = null;
            SAPINT.Utils.ReadTable idocReadHeader = null;
            DataTable dtIdocItem = new DataTable();
            DataTable dtIdocHeder = new DataTable();
            idocNumber = idocNumber.TrimStart('0');
            String criteria = idocNumber.PadLeft(16, '0');
            criteria = String.Format("DOCNUM = '{0}'", criteria);
            String readTableFunction = new ConfigFileTool.SAPGlobalSettings().GetReadTableFunction();

            idocReadItem = new Utils.ReadTable(SystemName);
            idocReadItem.TableName = "EDID4";
            idocReadItem.SetCustomFunctionName(readTableFunction);
            idocReadItem.AddCriteria(criteria);
            idocReadItem.Run();
            dtIdocItem = idocReadItem.Result;

            if (dtIdocItem.Rows.Count == 0)
            {
                idocReadItem = new Utils.ReadTable(SystemName);
                idocReadItem.TableName = "EDID2";
                idocReadItem.SetCustomFunctionName(readTableFunction);
                idocReadItem.AddCriteria(criteria);
                idocReadItem.Run();
                dtIdocItem = idocReadItem.Result;

            }
            if (dtIdocItem.Rows.Count == 0)
            {
                idocReadItem = new Utils.ReadTable(SystemName);
                idocReadItem.TableName = "EDIDD_OLD";
                idocReadItem.SetCustomFunctionName(readTableFunction);
                idocReadItem.AddCriteria(criteria);
                idocReadItem.Run();
                dtIdocItem = idocReadItem.Result;
            }
            if (dtIdocItem.Rows.Count == 0)
            {
                throw new SAPException(String.Format("无法找到IDOC{0}明细", idocNumber));
            }
            //读取IDOC头
            idocReadHeader = new Utils.ReadTable(SystemName);
            idocReadHeader.TableName = "EDIDC";
            idocReadHeader.SetCustomFunctionName(readTableFunction);
            idocReadHeader.AddCriteria(criteria);
            idocReadHeader.Run();
            dtIdocHeder = idocReadHeader.Result;

            if (dtIdocHeder.Rows.Count != 1)
            {
                throw new SAPException(String.Format("无法找到IDOC{0}抬头定义", idocNumber));
            }

            Idoc idoc = processSingleIdocFromDataTable(dtIdocHeder, dtIdocItem);

            return idoc;

        }

        /// <summary>
        /// 把从数据库中读取的IDOC定义转换成一个IDOC对象。
        /// </summary>
        /// <param name="dtHeader"></param>
        /// <param name="dtItem"></param>
        /// <returns></returns>
        public Idoc processSingleIdocFromDataTable(DataTable dtHeader, DataTable dtItem)
        {
            if (dtHeader==null || dtItem == null)
            {
                throw new SAPException("无效的IDOC定义!!");
            }
            if (dtHeader.Rows.Count == 0 )
            {
                throw new SAPException("无法找到IDOC抬头定义!!");
            }
            if (dtHeader.Rows.Count > 1)
            {
                throw new SAPException("存在重复的IDOC!!");
            }

            if (dtItem.Rows.Count == 0)
            {
                throw new SAPException("无法找到IDOC明细!!");
            }

            DataRow header = dtHeader.Rows[0];
            Idoc idoc = null;
            try
            {
                idoc = new Idoc
               {
                   // TABNAM = header["TABNAM"].ToString().Trim(),
                   MANDT = header["MANDT"].ToString().Trim(),
                   DOCNUM = header["DOCNUM"].ToString().Trim(),
                   DOCREL = header["DOCREL"].ToString().Trim(),
                   STATUS = header["STATUS"].ToString().Trim(),
                   DIRECT = header["DIRECT"].ToString().Trim(),
                   OUTMOD = header["OUTMOD"].ToString().Trim(),
                   EXPRSS = header["EXPRSS"].ToString().Trim(),
                   //特别注意不要使用“DOCTYP”
                   IDOCTYP = header["IDOCTP"].ToString().Trim(),
                   CIMTYP = header["CIMTYP"].ToString().Trim(),
                   MESTYP = header["MESTYP"].ToString().Trim(),
                   MESCOD = header["MESCOD"].ToString().Trim(),
                   MESFCT = header["MESFCT"].ToString().Trim(),
                   STD = header["STD"].ToString().Trim(),
                   STDVRS = header["STDVRS"].ToString().Trim(),
                   STDMES = header["STDMES"].ToString().Trim(),
                   SNDPOR = header["SNDPOR"].ToString().Trim(),
                   SNDPRT = header["SNDPRT"].ToString().Trim(),
                   SNDPFC = header["SNDPFC"].ToString().Trim(),
                   SNDPRN = header["SNDPRN"].ToString().Trim(),
                   SNDSAD = header["SNDSAD"].ToString().Trim(),
                   SNDLAD = header["SNDLAD"].ToString().Trim(),
                   RCVPOR = header["RCVPOR"].ToString().Trim(),
                   RCVPRT = header["RCVPRT"].ToString().Trim(),
                   RCVPFC = header["RCVPFC"].ToString().Trim(),
                   RCVPRN = header["RCVPRN"].ToString().Trim(),
                   RCVSAD = header["RCVSAD"].ToString().Trim(),
                   RCVLAD = header["RCVLAD"].ToString().Trim(),
                   CREDAT = header["CREDAT"].ToString().Trim(),
                   CRETIM = header["CRETIM"].ToString().Trim(),
                   REFINT = header["REFINT"].ToString().Trim(),
                   REFGRP = header["REFGRP"].ToString().Trim(),
                   REFMES = header["REFMES"].ToString().Trim(),
                   ARCKEY = header["ARCKEY"].ToString().Trim(),
                   SERIAL = header["SERIAL"].ToString().Trim()
               };

                Hashtable hashtable = new Hashtable();
                for (int i = 0; i < dtItem.Rows.Count; i++)
                {
                    DataRow item = dtItem.Rows[i];
                    if (item["DOCNUM"].ToString().Trim().Equals(header["DOCNUM"].ToString().Trim()))
                    {
                        IdocSegment newSegment = new IdocSegment();
                        if (item["PSGNUM"].ToString() == "000000")
                        {
                            idoc.Segments.Add(newSegment);
                        }
                        else
                        {
                            IdocSegment segment2 = (IdocSegment)hashtable[item["PSGNUM"].ToString()];
                            if (segment2 != null)
                            {
                                segment2.ChildSegments.Add(newSegment);
                            }
                            else
                            {
                                idoc.Segments.Add(newSegment);
                            }
                        }
                        newSegment.SegmentName = item["SEGNAM"].ToString();
                        newSegment.SegmentNumber = item["SEGNUM"].ToString();
                        string content = item["SDATA"].ToString();
                        newSegment.WriteDataBuffer(content, 0, 0x3e8);
                        if (!hashtable.ContainsKey(item["SEGNUM"].ToString()))
                        {
                            hashtable.Add(item["SEGNUM"].ToString(), newSegment);
                        }
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

            return idoc;
        }

        /// <summary>
        /// 转换RFC函数读取过来的IDOC.
        /// </summary>
        /// <param name="tControl"></param>
        /// <param name="datarows"></param>
        /// <returns></returns>
        private Idoc processSingleIdoc(IRfcStructure tControl, IRfcTable datarows)
        {
            Idoc idoc = new Idoc
            {
                TABNAM = tControl["TABNAM"].GetValue().ToString().Trim(),
                MANDT = tControl["MANDT"].GetValue().ToString().Trim(),
                DOCNUM = tControl["DOCNUM"].GetValue().ToString().Trim(),
                DOCREL = tControl["DOCREL"].GetValue().ToString().Trim(),
                STATUS = tControl["STATUS"].GetValue().ToString().Trim(),
                DIRECT = tControl["DIRECT"].GetValue().ToString().Trim(),
                OUTMOD = tControl["OUTMOD"].GetValue().ToString().Trim(),
                EXPRSS = tControl["EXPRSS"].ToString().Trim(),
                IDOCTYP = tControl["IDOCTYP"].GetValue().ToString().Trim(),
                CIMTYP = tControl["CIMTYP"].GetValue().ToString().Trim(),
                MESTYP = tControl["MESTYP"].GetValue().ToString().Trim(),
                MESCOD = tControl["MESCOD"].GetValue().ToString().Trim(),
                MESFCT = tControl["MESFCT"].GetValue().ToString().Trim(),
                STD = tControl["STD"].GetValue().ToString().Trim(),
                STDVRS = tControl["STDVRS"].GetValue().ToString().Trim(),
                STDMES = tControl["STDMES"].GetValue().ToString().Trim(),
                SNDPOR = tControl["SNDPOR"].GetValue().ToString().Trim(),
                SNDPRT = tControl["SNDPRT"].GetValue().ToString().Trim(),
                SNDPFC = tControl["SNDPFC"].GetValue().ToString().Trim(),
                SNDPRN = tControl["SNDPRN"].GetValue().ToString().Trim(),
                SNDSAD = tControl["SNDSAD"].GetValue().ToString().Trim(),
                SNDLAD = tControl["SNDLAD"].GetValue().ToString().Trim(),
                RCVPOR = tControl["RCVPOR"].GetValue().ToString().Trim(),
                RCVPRT = tControl["RCVPRT"].GetValue().ToString().Trim(),
                RCVPFC = tControl["RCVPFC"].GetValue().ToString().Trim(),
                RCVPRN = tControl["RCVPRN"].GetValue().ToString().Trim(),
                RCVSAD = tControl["RCVSAD"].GetValue().ToString().Trim(),
                RCVLAD = tControl["RCVLAD"].GetValue().ToString().Trim(),
                CREDAT = tControl["CREDAT"].GetValue().ToString().Trim(),
                CRETIM = tControl["CRETIM"].GetValue().ToString().Trim(),
                REFINT = tControl["REFINT"].GetValue().ToString().Trim(),
                REFGRP = tControl["REFGRP"].GetValue().ToString().Trim(),
                REFMES = tControl["REFMES"].GetValue().ToString().Trim(),
                ARCKEY = tControl["ARCKEY"].GetValue().ToString().Trim(),
                SERIAL = tControl["SERIAL"].GetValue().ToString().Trim()
            };

            Hashtable hashtable = new Hashtable();
            for (int i = 0; i < datarows.RowCount; i++)
            {
                IRfcStructure structure = datarows[i];
                if (structure["DOCNUM"].GetValue().ToString().Trim().Equals(tControl["DOCNUM"].GetValue().ToString().Trim()))
                {
                    IdocSegment newSegment = new IdocSegment();
                    if (structure["PSGNUM"].GetValue().ToString() == "000000")
                    {
                        idoc.Segments.Add(newSegment);
                    }
                    else
                    {
                        IdocSegment segment2 = (IdocSegment)hashtable[structure["PSGNUM"].GetValue().ToString()];
                        if (segment2 != null)
                        {
                            segment2.ChildSegments.Add(newSegment);
                        }
                        else
                        {
                            idoc.Segments.Add(newSegment);
                        }
                    }
                    newSegment.SegmentName = structure["SEGNAM"].GetValue().ToString();
                    newSegment.SegmentNumber = structure["SEGNUM"].ToString();
                    segNameList.Add(newSegment.SegmentName);
                    string content = structure["SDATA"].GetValue().ToString();
                    newSegment.WriteDataBuffer(content, 0, 0x3e8);
                    if (!hashtable.ContainsKey(structure["SEGNUM"].GetValue().ToString()))
                    {
                        hashtable.Add(structure["SEGNUM"].GetValue().ToString(), newSegment);
                    }
                }
            }
            return idoc;
        }
    }
}
