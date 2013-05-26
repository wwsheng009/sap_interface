using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace SAPINT.Function.Meta
{
    /// <summary>
    /// 描述RFC函数中的一个参数。
    /// </summary>
    public class FunctionField
    {
        public readonly String Direction;
        public readonly bool Optional;
        public readonly String Name;
        public readonly String DataType;
        public readonly String DefaultValue;
        public readonly int Decimals;
        public readonly String Documentation;
        public readonly int Length;
        public readonly String DataTypeName;
        //private string name;
        //private string dataType;
        //private string dataTypeName;
        //private string defaultValue;
        public FunctionField(String name, String direction, String dataType, int decimals, String defaultValue, int lenght, bool optional, String Documentation)
        {
            this.Name = name;
            this.Direction = direction;
            this.DataType = dataType;
            this.Decimals = decimals;
            this.DefaultValue = defaultValue;
            this.Length = lenght;
            this.Optional = optional;
            this.Documentation = Documentation;
            
        }
        public FunctionField(String name,String direction, String dataType, int decimals,String defaultValue,int lenght,bool optional,String Documentation,String dataTypeName)
        {
            this.Name = name;
            this.Direction = direction;
            this.DataType = dataType;
            this.Decimals = decimals;
            this.DefaultValue = defaultValue;
            this.Length = lenght;
            this.Optional = optional;
            this.Documentation = Documentation;
            this.DataTypeName = dataTypeName;
        }
        public FunctionField(string name, string dataType, string dataTypeName, string defaultValue)
        {
            // TODO: Complete member initialization
            this.Name = name;
            this.DataType = dataType;
            this.DataTypeName = dataTypeName;
            this.DefaultValue = defaultValue;
        }
    }
    public enum SAPDirection
    {
        IMPORT = 1,
        EXPORT = 2,
        CHANGING = 3,
        TABLES = 7,
    }
    public enum SAPDataType
    {
        CHAR = 0,
        BYTE = 1,
        NUM = 2,
        BCD = 3,
        DATE = 4,
        TIME = 5,
        UTCLONG = 6,
        UTCSECOND = 7,
        UTCMINUTE = 8,
        DTDAY = 9,
        DTWEEK = 10,
        DTMONTH = 11,
        TSECOND = 12,
        TMINUTE = 13,
        CDAY = 14,
        FLOAT = 15,
        INT1 = 16,
        INT2 = 17,
        INT4 = 18,
        INT8 = 19,
        DECF16 = 20,
        DECF34 = 21,
        STRING = 22,
        XSTRING = 23,
        STRUCTURE = 24,
        TABLE = 25,
        CLASS = 26,
        UNKNOWN = 27,
    }
}
