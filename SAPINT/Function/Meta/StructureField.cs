using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SAPINT.Function.Meta
{
    /// <summary>
    /// 表示结构中的一个字段
    /// </summary>
    public class StructureField
    {
 
        public readonly String Name;
        public readonly String DataType;
        public readonly int Decimals;
        public readonly String Documentation;
        public readonly int Length;
        //public StructureField(String name)
        //{
        //    this.Name = name;
        //}
        //public StructureField(String name,String dataType)
        //{
        //    this.Name = name;
        //    this.DataType = dataType;
        //}
        //public StructureField(String name, String dataType, int decimals)
        //{
        //    this.Name = name;
        //    this.DataType = dataType;
        //    this.Decimals = decimals;
        //}
        public StructureField(String name, String dataType, int decimals, int lenght)
        {
            this.Name = name;
            this.DataType = dataType;
            this.Decimals = decimals;
            this.Length = lenght;
        }
        public StructureField(String name, String dataType,int decimals,int lenght, String documentation)
        {
            this.Name = name;
            this.DataType = dataType;
            this.Decimals = decimals;
            this.Length = lenght;
            this.Documentation = documentation;
        }
    }
}
