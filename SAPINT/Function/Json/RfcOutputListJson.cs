using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SAPINT.Function
{

    //保存函数的元数据，根据函数的输入输出方向不同，存放在不同的列表中
    public class RfcOutputListJson
    {
        #region Constructors
        public RfcOutputListJson()
        {
            Import = new List<object>();
            Export = new List<object>();
            Tables = new List<object>();
            Change = new List<object>();
            All = new List<object>();
            Objects = new Dictionary<string, object>();
        }
        #endregion Constructors
        #region Properties
        //其它四种结构的汇总
        public List<object> All
        {
            get;
            set;
        }
        public List<object> Change
        {
            get;
            set;
        }
        public List<object> Export
        {
            get;
            set;
        }
        public List<object> Import
        {
            get;
            set;
        }
        //函数中结构或是表的结构定义
        public Dictionary<string, object> Objects
        {
            get;
            set;
        }
        public List<object> Tables
        {
            get;
            set;
        }
        #endregion Properties
    }
}
