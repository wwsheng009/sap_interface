using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPINT.Function.Meta;
using Newtonsoft.Json;
using System.Data;
namespace SAPINT.Function.Json
{
    public class SAPFunctionJson2
    {
        /// <summary>
        /// 使用JSON调用RFC函数。
        /// </summary>
        /// <param name="sysName"></param>
        /// <param name="funame"></param>
        /// <param name="jsondata"></param>
        /// <returns></returns>
        public static string InvokeFunctionFromJson(string sysName, string funame, string jsondata)
        {
            MetaValueList list = null;
            if (String.IsNullOrWhiteSpace(jsondata))
            {
                list = new MetaValueList();
            }
            else
            {
                try
                {
                    list = JsonConvert.DeserializeObject<MetaValueList>(jsondata);
                }
                catch (Exception ee)
                {
                    return JsonConvert.SerializeObject(ee);
                }
            }
            MetaValueList outList = null;
            string output = "";
            if (list != null)
            {
                SAPFunction.InvokeFunction(sysName, funame, list, out outList);
            }
            //序列化并输出结果
            output = JsonConvert.SerializeObject(outList, new JsonSerializerSettings
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

        public static string GetFuncMeta(string sysName, string funame)
        {
            string output = "";
            try
            {
                RfcFunctionMetaAsList list = SAPFunctionMeta.GetFuncMetaAsList(sysName, funame);
                //  paralist = GetFunMetaList(sysName, funame);
                if (list == null)
                {
                    output = JsonConvert.SerializeObject("连接SAP系统出错！！！");
                }
                //输出时忽略转换错误
                output = JsonConvert.SerializeObject(list, new JsonSerializerSettings
                {
                    Error = delegate(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs args)
                    {
                        // errors.Add(args.ErrorContext.Error.Message);
                        args.ErrorContext.Handled = true;
                    }
                    // Converters = { new IsoDateTimeConverter() }
                }
                );
                return output;
            }
            catch (Exception ee)
            {
                return JsonConvert.SerializeObject(ee);
                throw new SAPException(ee.Message);
            }
        }
        public static string convertDataTableToJson(DataTable dt)
        {
                string output = "";
             //输出时忽略转换错误
                output = JsonConvert.SerializeObject(dt, new JsonSerializerSettings
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
    }
}
