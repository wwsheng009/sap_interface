using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SAPINT.Function.Meta
{
    public class RfcFunctionMetaAsList
    {
        public RfcFunctionMetaAsList()
        {
            Import = new Dictionary<string, FunctionField>();
            Export = new Dictionary<string, FunctionField>();
            Changing = new Dictionary<string, FunctionField>();
            Tables = new Dictionary<string, FunctionField>();
            StructureDetail = new Dictionary<string, List<StructureField>>();
        }
        public Dictionary<String, FunctionField> Import
        {
            get;
            set;
        }
        public Dictionary<String, FunctionField> Export
        {
            get;
            set;
        }
        public Dictionary<String, FunctionField> Changing
        {
            get;
            set;
        }
        public Dictionary<String, FunctionField> Tables
        {
            get;
            set;
        }
        public Dictionary<String, List<StructureField>> StructureDetail
        {
            get;
            set;
        }
    }
}
