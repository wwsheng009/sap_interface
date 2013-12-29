using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;

namespace SAPINT.Function2
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

    public class SAPFunction2
    {
        public string SystemName { get; set; }
        public string FunctionName { get; set; }
        public SAP.Middleware.Connector.RfcDestination destination { get; set; }

        public List<CParams> Params { get; private set; }


        public SAPFunction2(string pSystem, string pFunction)
        {


        }
        //类型赋值
        private List<CParams> Get_Params_list(IRfcFunction pFunction)
        {
            List<CParams> _Params_list = new List<CParams>();
            IRfcTable rfctable_Params = pFunction.GetTable("Params");

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
        public void GetFunctionDef(string pSystem, string pFunction)
        {
            destination = SAPDestination.GetDesByName(pSystem);

            IRfcFunction _functionInterface = destination.Repository.CreateFunction("RFC_GET_FUNCTION_INTERFACE");
            _functionInterface.SetValue("FUNCNAME", pFunction);
            try
            {
                _functionInterface.Invoke(destination);

                Params = Get_Params_list(_functionInterface);

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



        public IRfcTable _rfc_params { get; set; }
    }
}
