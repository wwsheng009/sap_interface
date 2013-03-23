using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SAPINT.Function
{
    //保存序列化后的传入参数
    public class RfcInputListJson
    {
        #region Constructors
        public RfcInputListJson()
        {
            Import = new List<RfcKeyValueJson>();
            Export = new List<RfcKeyValueJson>();
            Tables = new List<RfcKeyValueJson>();
            Change = new List<RfcKeyValueJson>();
            All = new List<RfcKeyValueJson>();
        }
        #endregion Constructors
        #region Properties
        //是其它4种内容的汇总
        public List<RfcKeyValueJson> All
        {
            get;
            set;
        }
        public List<RfcKeyValueJson> Change
        {
            get;
            set;
        }
        public List<RfcKeyValueJson> Export
        {
            get;
            set;
        }
        public List<RfcKeyValueJson> Import
        {
            get;
            set;
        }
        public List<RfcKeyValueJson> Tables
        {
            get;
            set;
        }
        #endregion Properties
    }
}
