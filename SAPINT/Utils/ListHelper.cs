using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SAPINT.Utils
{
   public static class ListHelper
    {
       public static IList<T> ToList<T>(this DataTable dt) where T : class
       {
           // List<TableField> = fieldDt.to
           var Fields = new List<T>();

           Type t = typeof(T);
           PropertyInfo[] properties = t.GetProperties();
           foreach (DataRow datarow in dt.Rows)
           {
               T entity = t.Assembly.CreateInstance(t.FullName) as T;
               for (int i = 0; i < properties.Length; i++)
               {
                   PropertyInfo prop = properties[i];
                   if (dt.Columns.Contains(prop.Name))
                   {
                       var value = datarow[prop.Name];
                       if (value!=DBNull.Value)
                       {
                           prop.SetValue(entity, value, null);
                       }
                       
                   }

               }
               Fields.Add(entity);
           }

           // table.Columns.Add(prop.Name, prop.PropertyType);


           return Fields;
       }

       public static DataTable ToDataTable<T>(this IList<T> data) where T:class
       {
           Type t = typeof(T);
           PropertyInfo[] properties = t.GetProperties();
           DataTable table = new DataTable();
           for (int i = 0; i < properties.Length; i++)
           {
               PropertyInfo prop = properties[i];
               table.Columns.Add(prop.Name, prop.PropertyType);
           }
           object[] values = new object[properties.Length];
           foreach (T item in data)
           {
               for (int i = 0; i < values.Length; i++)
               {
                   values[i] = properties[i].GetValue(item,null) ?? DBNull.Value;
               }
               table.Rows.Add(values);
           }
           return table;
       }

    }
}
