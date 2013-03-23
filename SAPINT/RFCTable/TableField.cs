using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAPINT.RFCTable
{

    /// <summary>
    /// 将原生的类型进行一些必要的扩展。
    /// </summary>
    public class TableField : RfcTableField
    {
        public bool Selected { get; set; }
        public string DOTNETTYPE { get;  set; }
        public string DBTYPE { get;  set; }
        public string SQLTYPE { get;  set; }
    }
    /// <summary>
    /// SAP中结构DFIES的类型定义。这是在SAP字典里定义的。直接复制过来
    /// </summary>
    public class RfcTableField
    {
        public string TABNAME { get; set; }   //表名
        public string FIELDNAME { get; set; }   //字段名
        public string LANGU { get; set; }   //语言代码
        public int POSITION { get; set; }   // 表格中区域的位置
        public int OFFSET { get; set; }   //工作区内域偏移
        public string DOMNAME { get; set; }   //定义域名
        public string ROLLNAME { get; set; }   //数据元素 (语义域)
        public string CHECKTABLE { get; set; }   //表名
        public int LENG { get; set; }   //长度（字符数）
        public int INTLEN { get; set; }   //以字节计的内部长度
        public int OUTPUTLEN { get; set; }   //输出长度
        public int DECIMALS { get; set; }   //小数点后的位数
        public string DATATYPE { get; set; }   //ABAP/4 字典: 屏幕绘制器的屏幕数据类型
        public string INTTYPE { get; set; }   //ABAP 数据类型(C,D,N,...)
        public string REFTABLE { get; set; }   //索引字段的表
        public string REFFIELD { get; set; }   //货币和数量字段的参考字段
        public string PRECFIELD { get; set; }   //包含表格的名称
        public string AUTHORID { get; set; }   //授权类别
        public string MEMORYID { get; set; }   //设置/获取参数标识
        public string LOGFLAG { get; set; }   // 写变化文档指示符
        public string MASK { get; set; }   //模板（未使用）
        public int MASKLEN { get; set; }   //模板长度（未使用）
        public string CONVEXIT { get; set; }   //转换例程
        public int HEADLEN { get; set; }   //表头的最大长度
        public int SCRLEN1 { get; set; }   //短字段标签的最大长度
        public int SCRLEN2 { get; set; }   //中等字段标签的最大长度
        public int SCRLEN3 { get; set; }   //长字段标签的最大长度
        public string FIELDTEXT { get; set; }   //描述 R/3 资源库对象的短文本
        public string REPTEXT { get; set; }   //标题
        public string SCRTEXT_S { get; set; }   //短字段标签
        public string SCRTEXT_M { get; set; }   //中字段标签
        public string SCRTEXT_L { get; set; }   //长字段标签
        public string KEYFLAG { get; set; }   //标识表格的关键字段
        public string LOWERCASE { get; set; }   //允许/不允许小写字母
        public string MAC { get; set; }   //如果搜索帮助附加到字段上，则进行标记
        public string GENKEY { get; set; }   //标记(X或空白)
        public string NOFORKEY { get; set; }   //标记(X或空白)
        public string VALEXI { get; set; }   //固定值存在
        public string NOAUTHCH { get; set; }   //标记(X或空白)
        public string SIGN { get; set; }   //数值域的符号标志
        public string DYNPFLD { get; set; }   //标记: 在屏幕上显示字段
        public string F4AVAILABL { get; set; }   //字段有输入帮助吗
        public string COMPTYPE { get; set; }   //DD：组件类型
        public string LFIELDNAME { get; set; }   //字段名
        public string LTRFLDDIS { get; set; }   //Basic write direction has been defined LTR (left-to-right)
        public string BIDICTRLC { get; set; }   //DD: No Filtering of BIDI Formatting Characters
        public int OUTPUTSTYLE { get; set; }   //DD: Output Style (Output Style) for Decfloat Types
        public string NOHISTORY { get; set; }   //DD: Flag for Deactivating Input History in Screen Field
        public string AMPMFORMAT { get; set; }   //DD: Indicator whether AM/PM time format is required

    }
}
