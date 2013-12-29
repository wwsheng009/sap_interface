using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPINT.Function.CopyTable
{
   public class CopyTableField
    {
       public String FieldName { get; set; }
       public int Offset { set; get; }
       public int Length { get; set; }
       public string Type { get; set; }
       public string FieldText { get; set; }
    }

   public enum OperationType { direct, write, read,file }
}
