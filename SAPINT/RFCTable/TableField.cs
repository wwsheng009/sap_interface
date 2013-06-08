using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace SAPINT.RFCTable
{
    /// <summary>
    /// 排序定义
    /// </summary>
    public class SelectedComparer : IComparer<TableField>
    {

        public int Compare(TableField x, TableField y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    // ...and y is not null, compare the 
                    // lengths of the two strings.
                    //
                    if (x.Selected == true)
                    {
                        if (y.Selected == true)
                        {
                            return 0;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        if (y.Selected == true)
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    }


                }
            }
        }
    }
    /// <summary>
    /// 按位置POSITION排序。
    /// </summary>
    public class PositionComparer : IComparer<TableField>
    {
        public int Compare(TableField x, TableField y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    int retval = x.POSITION.CompareTo(y.POSITION); // x.Length.CompareTo(y.Length);

                    if (retval != 0)
                    {
                        return retval;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }
    }
    /// <summary>
    /// 将原生的类型进行一些必要的扩展。
    /// </summary>
    public class TableField : RfcTableField
    {
        public bool Selected { get; set; }
        public string DOTNETTYPE { get; set; }
        public string DBTYPE { get; set; }
        public string SQLTYPE { get; set; }
        public string POSITION2 { get; set; }
    }
    /// <summary>
    /// SAP中结构DFIES的类型定义。这是在SAP字典里定义的。直接复制过来
    /// </summary>
    public class RfcTableField
    {
        public string TABNAME { get; set; }   //表名
        public string FIELDNAME { get; set; }   //字段名
        public int POSITION { get; set; }   // 表格中区域的位置
        public int OFFSET { get; set; }   //工作区内域偏移
        public string DOMNAME { get; set; }   //定义域名
        public string ROLLNAME { get; set; }   //数据元素 (语义域)
        public string CHECKTABLE { get; set; }   //表名
        public int LENG { get; set; }   //长度（字符数）
        public int OUTPUTLEN { get; set; }   //输出长度
        public int DECIMALS { get; set; }   //小数点后的位数
        public string DATATYPE { get; set; }   //ABAP/4 字典: 屏幕绘制器的屏幕数据类型
        public string INTTYPE { get; set; }   //ABAP 数据类型(C,D,N,...)
        public string REFTABLE { get; set; }   //索引字段的表
        public string REFFIELD { get; set; }   //货币和数量字段的参考字段
        public string FIELDTEXT { get; set; }   //描述 R/3 资源库对象的短文本
        public string REPTEXT { get; set; }   //标题
        public string SCRTEXT_S { get; set; }   //短字段标签
        public string SCRTEXT_M { get; set; }   //中字段标签
        public string SCRTEXT_L { get; set; }   //长字段标签
        public string KEYFLAG { get; set; } //标识表格的关键字段
    }
}
