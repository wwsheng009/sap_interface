using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using SAPINT.Idocs;
using System.Collections;
using SAPINT.Queries;
namespace SAPINT
{
   public class SAPConnection
    {
       private RfcDestination des;
       private string _sysName;
       private bool logging;
       private string client;
       public SAPConnection(string sysName)
       {
           this._sysName = sysName;
       }
       public BusinessObjectMethod CreateBapi(string BusinessObjectName, string MethodName)
       {
           IRfcFunction function = des.Repository.CreateFunction("SWO_QUERY_API_OBJTYPES");
           function["OBJECT_NAME"].SetValue(BusinessObjectName);
           function.Invoke(des);
           if (function.GetTable("OBJTYPES").RowCount == 0)
           {
               throw new Exception("Unable to find ObjectType for name '" + BusinessObjectName + "'");
           }
           string str = function.GetTable("OBJTYPES")[0]["OBJTYPE"].GetValue().ToString();
           IRfcFunction function2 = des.Repository.CreateFunction("SWO_QUERY_API_METHODS");
           function2["OBJTYPE"].SetValue(str);
           function2["WITH_TEXTS"].SetValue("");
           function2.Invoke(des);
           for (int i = 0; i < function2.GetTable("API_METHODS").RowCount; i++)
           {
               if (function2.GetTable("API_METHODS")[i]["METHOD"].GetValue().ToString().ToUpper().Equals(MethodName.ToUpper()))
               {
                   BusinessObjectMethod method = new BusinessObjectMethod(_sysName)
                   {
                       MethodName = MethodName,
                       ObjectName = BusinessObjectName
                   };
                  // RFCFunction dest = method;
                   method.Name = function2.GetTable("API_METHODS")[i]["FUNCTION"].GetValue().ToString();
                   //this.AddParametersAndTablesToUndefinedFunctionObject(ref dest, method.Name);
                   //method.Connection = this;
                 
                   return method;
               }
           }
           throw new Exception(string.Format("Unable to find method_{0}_at Object Type_1", MethodName, str));
       }
       public Idoc CreateIdoc(string IdocType, string Enhancement)
       {
           return this.InternalCreateIdoc(IdocType, Enhancement, false);
       }
       private Idoc InternalCreateIdoc(string IdocType, string Enhancement, bool CreateEmpty)
       {
           IdocType = IdocType.ToUpper();
           IRfcFunction function = des.Repository.CreateFunction("IDOCTYPE_READ_COMPLETE");
           function["PI_IDOCTYP"].SetValue(IdocType);
           function["PI_CIMTYP"].SetValue(Enhancement);
           try
           {
               if (this.Logging)
               {
                //   function.SaveToXML("IDOCTYPE_READ_COMPLETE_01_" + DateTime.Now.Ticks.ToString() + ".xml");
                //   function.
               }
               function.Invoke(des);
               if (this.Logging)
               {
                //   function.SaveToXML("IDOCTYPE_READ_COMPLETE_02_" + DateTime.Now.Ticks.ToString() + ".xml");
               }
           }
           catch (RfcAbapException exception)
           {
               if (!exception.Message.Trim().Equals("SEGMENT_UNKNOWN"))
               {
                   throw new Exception("Get IDoc failed: " + exception.ToString());
               }
               function["PI_RELEASE"].SetValue("    ");
               function.Invoke(des);
           }
           IRfcStructure structure = function.GetStructure("PE_HEADER");
           Idoc idoc = new Idoc(IdocType, Enhancement)
           {
               Connection = this,
               MANDT = this.des.Client,
               Description = structure["DESCRP"].ToString()
           };
           //IDOC类型的段定义
           IRfcTable table = function.GetTable("PT_SEGMENTS");
           Hashtable hashtable = new Hashtable();
           for (int i = 0; i < table.RowCount; i++)
           {
               //一般来说，第一行都是主要的段定义。表示一个抬头定义。
               if (table[i]["PARPNO"].GetValue().ToString() == "0000")
               {
                   IdocSegment newSegment = new IdocSegment();
                   if (!CreateEmpty)
                   {
                       idoc.Segments.Add(newSegment);
                   }
                   newSegment.SegmentName = table[i]["SEGMENTTYP"].GetValue().ToString();
                   newSegment.SegmentType = table[i]["SEGMENTDEF"].GetValue().ToString();
                   newSegment.Description = table[i]["DESCRP"].GetValue().ToString();
                   int num2 = Convert.ToInt32(table[i]["GRP_OCCMAX"].GetValue().ToString().Substring(5, 5));
                   newSegment.MaxOccur = (num2 == 0) ? Convert.ToInt32(table[i]["OCCMAX"].GetValue().ToString().Substring(5, 5)) : num2;
                   if (newSegment.MaxOccur == 0)
                   {
                       newSegment.MaxOccur = 1;
                   }
                   string key = table[i]["NR"].GetValue().ToString();
                   hashtable.Add(key, newSegment);
               }
               else
               {
                   string str2 = table[i]["PARPNO"].GetValue().ToString();
                   string str3 = table[i]["NR"].GetValue().ToString();
                   IdocSegment segment2 = (IdocSegment)hashtable[str2];
                   if (segment2 == null)
                   {
                       throw new Exception("The idoc structure is not valid");
                   }
                   IdocSegment segment3 = new IdocSegment();
                   if (!CreateEmpty)
                   {
                       segment2.ChildSegments.Add(segment3);
                   }
                   segment3.SegmentName = table[i]["SEGMENTTYP"].GetValue().ToString();
                   segment3.SegmentType = table[i]["SEGMENTDEF"].GetValue().ToString();
                   segment3.Description = table[i]["DESCRP"].GetValue().ToString();
                   int num3 = Convert.ToInt32(table[i]["GRP_OCCMAX"].GetValue().ToString().Substring(5, 5));
                   segment3.MaxOccur = (num3 == 0) ? Convert.ToInt32(table[i]["OCCMAX"].GetValue().ToString().Substring(5, 5)) : num3;
                   if (segment3.MaxOccur == 0)
                   {
                       segment3.MaxOccur = 1;
                   }
                   hashtable.Add(str3, segment3);
               }
           }
           //查找段节点的结构定义。
           IRfcTable table2 = function.GetTable("PT_FIELDS");
           IDictionaryEnumerator enumerator = hashtable.GetEnumerator();
           while (enumerator.MoveNext())
           {
               IdocSegment segment4 = (IdocSegment)enumerator.Value;
               for (int j = 0; j < table2.RowCount; j++)
               {
                   if (table2[j]["SEGMENTTYP"].GetValue().ToString().Trim() == segment4.SegmentName.Trim())
                   {
                       segment4.Fields.Add(table2[j]["FIELDNAME"].GetValue().ToString(), table2[j]["DESCRP"].GetValue().ToString(), Convert.ToInt32(table2[j]["EXTLEN"].GetValue().ToString()), Convert.ToInt32(table2[j]["BYTE_FIRST"].GetValue().ToString()) - 0x40, table2[j]["DATATYPE"].GetValue().ToString(), "");
                   }
               }
               idoc.StoreSegmentForFurtherUse(segment4.Clone());
           }
           return idoc;
       }
       public Query CreateQuery(WorkSpace WorkSpace, string UserGroup, string QueryName, string Variant)
       {
           Query query = new Query(_sysName)
           {
               Name = QueryName,
               WorkArea = WorkSpace,
               UserGroup = UserGroup,
               Variant = Variant
           };
           query.RefreshFieldsAndSelections();
           return query;
       }
       //public string CreateTid()
       //{
       //    IRfcFunction function = des.Repository.CreateFunction("API_CREATE_TID");
       //    function.Invoke(des);
       //    String tid = function["TID"].ToString();
       //    return tid;
       //}
       public bool Logging
       {
           get
           {
               return this.logging;
           }
           set
           {
               this.logging = value;
           }
       }
       public string Client
       {
           get
           {
               return this.client;
           }
           set
           {
               this.client = value.Trim();
           }
       }
    }
     
}
