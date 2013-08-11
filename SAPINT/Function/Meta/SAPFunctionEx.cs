using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SAP.Middleware.Connector;
namespace SAPINT.Function.Meta
{
    public class SAPFunctionEx
    {
        private String _sysTemName;
        private String _functionName;
        /// <summary>
        /// RFC函数的元信息
        /// </summary>
        private FunctionMetaAsDataTable _funcMeta = null;
        /// <summary>
        /// 根据结构名动态生成的DataTable;
        /// </summary>
        private Dictionary<String, DataTable> _tableValueList = null;
        /// <summary>
        /// 在调用RFC函数时，用于输入的参数值。
        /// </summary>
        MetaValueList _inputList = null;
        /// <summary>
        /// 调用RFC函数后，保存输出的所有的参数的值
        /// </summary>
        MetaValueList _outputList = null;

        public bool Is_rfc { get { return _funcMeta.Is_RFC; } }

        public SAPFunctionEx(String sapSystemName, String functionName)
        {
            if (String.IsNullOrEmpty(sapSystemName))
            {
                throw new SAPException("请指定系统名称");
            }
            if (String.IsNullOrEmpty(sapSystemName))
            {
                throw new SAPException("请指定函数名！");
            }
            this._sysTemName = sapSystemName.Trim();
            this._functionName = functionName.Trim().ToUpper();
            GetFunMetaListAsDataTable();
        }
        /// <summary>
        /// 连接SAP系统，读取RFC的元数据，以DataTable的形式存储。
        /// 同时，如果参数是结构体，也存储结构体的具体信息。
        /// </summary>
        private void GetFunMetaListAsDataTable()
        {
            this._funcMeta = SAPFunctionMeta.GetFuncMetaAsDataTable(_sysTemName, _functionName);
            _tableValueList = _funcMeta.InputTable;
        }

        /// <summary>
        /// 传入参数，并动态调用，并返回传出参数。
        /// </summary>
        public void Excute()
        {
            if (_funcMeta == null)
            {
                throw new SAPException("函数的元数据为空");
            }
            if (_funcMeta.Is_RFC == false)
            {
                throw new SAPException("非RFC函数，不能远程运行！");
            }
            HandleInput();
            SAPFunction.InvokeFunction(_sysTemName, _functionName, _inputList, out _outputList);
            HandleOutput();
        }
        /// <summary>
        /// 按函数的参数元数据定义，把传入参数转换成lisT格式。
        /// </summary>
        private void HandleInput()
        {

            _inputList = new MetaValueList();
            DataTableAndList.DataTableToList(_funcMeta.Import, _tableValueList, ref _inputList);
            DataTableAndList.DataTableToList(_funcMeta.Export, _tableValueList, ref _inputList);
            DataTableAndList.DataTableToList(_funcMeta.Changing, _tableValueList, ref _inputList);
            DataTableAndList.DataTableToList(_funcMeta.Tables, _tableValueList, ref _inputList);
        }
        private void HandleOutput()
        {
            DataTableAndList.ListToDataTable(_outputList, _funcMeta.Import, ref _tableValueList);
            DataTableAndList.ListToDataTable(_outputList, _funcMeta.Export, ref _tableValueList);
            DataTableAndList.ListToDataTable(_outputList, _funcMeta.Changing, ref _tableValueList);
            DataTableAndList.ListToDataTable(_outputList, _funcMeta.Tables, ref _tableValueList);
        }


        public Dictionary<String, DataTable> TableValueList
        {
            get
            {
                return _tableValueList;
            }
        }
        public FunctionMetaAsDataTable FunctionMeta
        {
            get
            {
                return _funcMeta;
            }
        }
    }
}
