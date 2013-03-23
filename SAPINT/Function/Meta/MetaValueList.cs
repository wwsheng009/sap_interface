using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace SAPINT.Function.Meta
{
    /// <summary>
    /// 这里只是包含了字段与值，并没有描述字段的类型。所以它需要配合其它结构才能解析出真正的意义
    /// </summary>
    public class MetaValueList
    {
        public MetaValueList()
        {
            //所有的字段与它的类型，普通，结构，还是表。
            // FieldTypeList = new Dictionary<string, string>();
            //扁平的参数，与它的值
            FieldValueList = new Dictionary<string, string>();
            //所有的结构与结构值列表。
            StructureValueList = new Dictionary<string, Dictionary<string, string>>();
            //
            TableValueList = new Dictionary<string, List<Dictionary<string, string>>>();
        }
        //public Dictionary<String, String> FieldTypeList
        //{
        //    get;
        //    set;
        //}
        public Dictionary<String, String> FieldValueList
        {
            get;
            set;
        }
        public Dictionary<String, Dictionary<String, String>> StructureValueList
        {
            get;
            set;
        }
        public Dictionary<String, List<Dictionary<String, String>>> TableValueList
        {
            set;
            get;
        }
    }

}
