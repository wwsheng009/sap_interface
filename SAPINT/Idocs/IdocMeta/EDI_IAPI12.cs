using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAPINT.Idocs.Meta
{
    public struct EDI_IAPI12
    {
        public System.String SEGMENTTYP { get; set; } // 段类型（30 字符格式）
        public System.String FIELDNAME { get; set; } // 字段名
        public System.Int32 INTLEN { get; set; } // 以字节计的内部长度
        public System.Int32 EXTLEN { get; set; } // 输出长度
        public System.Int32 FIELD_POS { get; set; } // 字段的位置号码
        public System.Int32 BYTE_FIRST { get; set; } // 第一个字节的位置
        public System.Int32 BYTE_LAST { get; set; } // 最后一个字节的位置
        public System.String ROLLNAME { get; set; } // 数据元素 (语义域)
        public System.String DOMNAME { get; set; } // 定义域名
        public System.String DATATYPE { get; set; } // ABAP/4 字典: 屏幕绘制器的屏幕数据类型
        public System.String DESCRP { get; set; } // 对象的简短说明
        public System.String ISOCODE { get; set; } // IDoc 开发：字段中的 ISO 代码标识
        public System.String VALUETAB { get; set; } // IDoc 段字段的值表
    }

    public struct EDI_IAPI11
    {
        public System.Int32 NR { get; set; } // IDoc 类型中段的序列号
        public System.String SEGMENTTYP { get; set; } // 段类型（30 字符格式）
        public System.String SEGMENTDEF { get; set; } // IDoc 开发：段定义
        public System.String QUALIFIER { get; set; } // 标记：IDoc 中限定的段
        public System.Int32 SEGLEN { get; set; } // 一个字段的长度(位置的数目)
        public System.String PARSEG { get; set; } // 段类型（30 字符格式）
        public System.Int32 PARPNO { get; set; } // 父代段的序列号
        public System.String PARFLG { get; set; } // 父段标记：段是段组的开始
        public System.String MUSTFL { get; set; } // 标记：强制条目
        public System.Int32 OCCMIN { get; set; } // 序列中段的最小数目
        public System.Double OCCMAX { get; set; } // 序列中最大段数目
        public System.Int32 HLEVEL { get; set; } // IDoc 类型段的层次水平
        public System.String DESCRP { get; set; } // 对象的简短说明
        public System.String GRP_MUSTFL { get; set; } // 组标记：强制
        public System.Int32 GRP_OCCMIN { get; set; } // 序列中最小组号
        public System.Double GRP_OCCMAX { get; set; } // 序列中最大组号
        public System.String REFSEGTYP { get; set; } // 段类型（30 字符格式）
    }

    public struct EDI_IAPI14
    {
        public System.String STRNAME { get; set; } // 内部结构的名称
        public System.String FIELDNAME { get; set; } // 字段名
        public System.String FLDVALUE_L { get; set; } // 下限值 / 单一值
        public System.String FLDVALUE_H { get; set; } // 上限值
        public System.String DESCRP { get; set; } // 说明简要文字
    }

    public struct EDI_IAPI17
    {
        public System.String MESTYP { get; set; } // 消息类型
        public System.String DESCRP { get; set; } // 对象的简短说明
        public System.String IDOCTYP { get; set; } // 基本类型
        public System.String CIMTYP { get; set; } // 分机号
        public System.String RELEASED { get; set; } // 消息类型分配有效的版本
    }

}
