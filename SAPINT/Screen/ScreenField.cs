using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAPINT.Screen
{
    public class CScreenField
    {
        public static readonly string C_INDEX = "INDEX";
        public static readonly string C_SELECT = "SELECT";
        public static readonly string C_NAME = "NAME";// 屏幕元素的名称
        public static readonly string C_DYNNR = "DYNNR";// 屏幕号码
        public static readonly string C_LINE = "LINE";// 出现字段的屏幕上的行
        public static readonly string C_COLN = "COLN";// 在屏幕上显示字段的列
        public static readonly string C_LENG = "LENG";// 定义的屏幕字段长度
        public static readonly string C_VLENG = "VLENG";// 屏幕中可见的（定为可见的）字段长度
        public static readonly string C_HIGH = "HIGH";// 屏幕中元素的高度
        public static readonly string C_TYPE = "TYPE";// 字段格式（ABAP 词典数据类型）
        public static readonly string C_FEIN = "FEIN";// 此字段的期望输入
        public static readonly string C_FOUT = "FOUT";// 此字段的期望输出
        public static readonly string C_SCROLL = "SCROLL";// 可滚动的输入/输出字段
        public static readonly string C_DICT = "DICT";// ABAP 字典中的字段
        public static readonly string C_DMOD = "DMOD";// 修改 ABAP 字典的字段
        public static readonly string C_GRP1 = "GRP1";// 修改组 1
        public static readonly string C_GRP2 = "GRP2";// 修改组 2
        public static readonly string C_GRP3 = "GRP3";//   修改组3
        public static readonly string C_GRP4 = "GRP4";//   修改组4
        public static readonly string C_LOOP = "LOOP";// 循环计数
        public static readonly string C_FOBL = "FOBL";// 字段中的条目
        public static readonly string C_FSTR = "FSTR";// * 条目
        public static readonly string C_FNRS = "FNRS";// 未重置
        public static readonly string C_FGKS = "FGKS";// 大/小写条目
        public static readonly string C_FFIX = "FFIX";// 固定，带下划线的字符模板
        public static readonly string C_FOSB = "FOSB";// 不用模板在 CHAR 字段中输入所有字符
        public static readonly string C_FFKY = "FFKY";// 字典的外键检查为活动状态
        public static readonly string C_FSPA = "FSPA";// SET 参数
        public static readonly string C_FGPA = "FGPA";// GET 参数
        public static readonly string C_PAID = "PAID";// 参数ID SAP内存
        public static readonly string C_UCNV = "UCNV";// 转换出口
        public static readonly string C_HELL = "HELL";// 亮度显示
        public static readonly string C_UNSI = "UNSI";// 不可见显示
        public static readonly string C_INVR = "INVR";// 显示反转视频
        public static readonly string C_BLIN = "BLIN";// 闪烁
        public static readonly string C_ULIN = "ULIN";// 突出显示
        public static readonly string C_COLR = "COLR";// 显示颜色1...7
        public static readonly string C_FJUS = "FJUS";// 右对齐显示
        public static readonly string C_FILL = "FILL";// 显示前导零
        public static readonly string C_LABELLEFT = "LABELLEFT";// 作为左侧标签
        public static readonly string C_LABELRIGHT = "LABELRIGHT";// 作为右侧标签
        public static readonly string C_DBLCLICK = "DBLCLICK";// 响应双击
        public static readonly string C_LTR = "LTR";// 基本写方向已定义为 LTR（从左至右）
        public static readonly string C_BIDICTRL = "BIDICTRL";// ABAP 字典：不过滤双向格式字符
        public static readonly string C_MTCH = "MTCH";// 搜索帮助
        public static readonly string C_WAER = "WAER";// 参考字段
        public static readonly string C_FCOD = "FCOD";// 用于按钮的功能码
        public static readonly string C_PTYPE = "PTYPE";// 按钮的功能码类型
        public static readonly string C_CTMENUPROG = "CTMENUPROG";// 上下文菜单：程序名称
        public static readonly string C_CTMENUSTAT = "CTMENUSTAT";// 上下文菜单：状态/菜单名
        public static readonly string C_CTMENUONCT = "CTMENUONCT";// 上下文菜单：动态回调 ON_CTMENU_...
        public static readonly string C_CTMENUST = "CTMENUST";// 上下文菜单：静态
        public static readonly string C_CTMENUDY = "CTMENUDY";// 上下文菜单：动态 (ON_CTMENU_...)
        public static readonly string C_CCNAME = "CCNAME";// Control Composite：名称
        public static readonly string C_CCDLEFT = "CCDLEFT";// Control Composite：左停靠
        public static readonly string C_CCDRIGHT = "CCDRIGHT";// Control Composite：右停靠
        public static readonly string C_CCDTOP = "CCDTOP";// Control Composite：上停靠
        public static readonly string C_CCDBOTTOM = "CCDBOTTOM";// Control Composite：下停靠
        public static readonly string C_CCDLEN_L = "CCDLEN_L";// Control Composite：停靠控件的宽度
        public static readonly string C_CCDLEN_R = "CCDLEN_R";// Control Composite：停靠控件的宽度
        public static readonly string C_CCDHIG_T = "CCDHIG_T";// Control Composite：停靠控件的高度
        public static readonly string C_CCDHIG_B = "CCDHIG_B";// Control Composite：停靠控件的高度
        public static readonly string C_LTYP = "LTYP";// 循环：循环类型(固定的或可变的)
        public static readonly string C_GTYP = "GTYP";// 屏幕元素类型
        public static readonly string C_FIXF = "FIXF";// 以固定字体代替比例字体
        public static readonly string C_NO3D = "NO3D";// 输入/输出字段的二维显示
        public static readonly string C_OOUT = "OOUT";// 纯输出字段
        public static readonly string C_WIN1 = "WIN1";// 图形屏幕绘制器：全屏编辑器
        public static readonly string C_WIN2 = "WIN2";// 图形屏幕绘制器：字段属性
        public static readonly string C_WIN3 = "WIN3";// 图形屏幕绘制器：ABAP/4 字典/程序字段
        public static readonly string C_STXT = "STXT";// 屏幕元素的文本/模板
        public static readonly string C_CMBTAST = "CMBTAST";// 可能条目按钮和可能条目的修改
        public static readonly string C_CMBFOC = "CMBFOC";// 可能条目的有效性
        public static readonly string C_DROPFROM = "DROPFROM";// 输入帮助: 原始值
        public static readonly string C_DROPDOWN = "DROPDOWN";// 下拉
        public static readonly string C_FETCHFLD = "FETCHFLD";// 取得表字段或程序字段 (一般)
        public static readonly string C_RFCDEST = "RFCDEST";// 参考系统（RFC 目标）
        public static readonly string C_SCHAB = "SCHAB";// 预选字典或程序字段的输入/输出字段
        public static readonly string C_SCHLK = "SCHLK";// 为词典字段预选短字段标签
        public static readonly string C_SCHLM = "SCHLM";// 为词典字段预选中字段标签
        public static readonly string C_SCHLL = "SCHLL";// 为词典字段预选长字段标签
        public static readonly string C_UEBER = "UEBER";// 为词典字段预选标题
        public static readonly string C_SCHLNO = "SCHLNO";// 预选带有短文本 (无字段标签) 的词典字段
        public static readonly string C_SCHABNO = "SCHABNO";// 词典或程序字段 I/O 模板无预选
        public static readonly string C_TEXTMOD = "TEXTMOD";// 预选：使用修正的词典文本
        public static readonly string C_TEXTORIG = "TEXTORIG";// 预选：像在词典中一样使用原始文本
        public static readonly string C_DEZUSATZ = "DEZUSATZ";// 数据元素增补
        public static readonly string C_TLTRENNHOR = "TLTRENNHOR";// 表控件：带水平分隔符
        public static readonly string C_TLTRENNVER = "TLTRENNVER";// 表控件：带垂直分隔符
        public static readonly string C_TLSCROLLH = "TLSCROLLH";// 控件：水平滚动
        public static readonly string C_TLSCROLLV = "TLSCROLLV";// 控件：垂直滚动
        public static readonly string C_TLSCROLL = "TLSCROLL";// 控件：可滚动
        public static readonly string C_TLSELECTZN = "TLSELECTZN";// 表控制：无行选择
        public static readonly string C_TLSELECTZS = "TLSELECTZS";// 表控制：单行选择
        public static readonly string C_TLSELECTZM = "TLSELECTZM";// 表控制：多行选择
        public static readonly string C_TLSELECTSN = "TLSELECTSN";// 表控制：无列选择
        public static readonly string C_TLSELECTSS = "TLSELECTSS";// 表控制：单列选择
        public static readonly string C_TLSELECTSM = "TLSELECTSM";// 表控制：多列选择
        public static readonly string C_TLSHOWONLY = "TLSHOWONLY";// 表控件：仅显示
        public static readonly string C_TLVARV = "TLVARV";// 控制：垂直调整
        public static readonly string C_TLVARVMIN = "TLVARVMIN";// 控制：垂直调整中最少的行数
        public static readonly string C_TLVARH = "TLVARH";// 控制：水平调整
        public static readonly string C_TLVARHMIN = "TLVARHMIN";// 控制：水平调整中最少的列数
        public static readonly string C_TLMARK = "TLMARK";// 表控制：选择列
        public static readonly string C_TLTITEL = "TLTITEL";// 表控制：带标题行
        public static readonly string C_TLUEBER = "TLUEBER";// 表控制：带列头
        public static readonly string C_TLERFA = "TLERFA";// 表控制：项表
        public static readonly string C_TLAUSW = "TLAUSW";// 表控制：选定行
        public static readonly string C_TLCONF = "TLCONF";// 表控制：可配置性
        public static readonly string C_TLTEXT = "TLTEXT";// 表控制：字段文本
        public static readonly string C_TLENTRY = "TLENTRY";// 表控制：项/模板字段
        public static readonly string C_TLRADIOB = "TLRADIOB";// 表控制：单选按钮
        public static readonly string C_TLCHECKB = "TLCHECKB";// 表控制：复选框
        public static readonly string C_TLPUSHB = "TLPUSHB";// 表控制：按钮
        public static readonly string C_TLNAMETYP = "TLNAMETYP";//   Multi--目的文本通用
        public static readonly string C_TLNAMEFLD = "TLNAMEFLD";// 屏幕元素的名称
        public static readonly string C_TLNAMEUEB = "TLNAMEUEB";// 屏幕元素的名称
        public static readonly string C_TLNAMESEL = "TLNAMESEL";// 屏幕元素的名称
        public static readonly string C_TLNAMETIT = "TLNAMETIT";// 屏幕元素的名称
        public static readonly string C_TLFELDFIX = "TLFELDFIX";// 固定字段
        public static readonly string C_TLFIXANZ = "TLFIXANZ";// 表控件：固定主导列数目
        public static readonly string C_TLFELDNR = "TLFELDNR";// 列号
        public static readonly string C_TLFELDNR00 = "TLFELDNR00";// 列号
        public static readonly string C_TLFELDSPBR = "TLFELDSPBR";// 列宽
        public static readonly string C_SPCELL1 = "SPCELL1";// 分割条单元格名称
        public static readonly string C_SPCELL2 = "SPCELL2";// 分割条单元格名称
        public static readonly string C_SPSPLITTHORIZ = "SPSPLITTHORIZ";// 分割条控件：分割方向垂直/水平
        public static readonly string C_SPSPLITTVERT = "SPSPLITTVERT";// 分割条控件：分割方向垂直/水平
        public static readonly string C_SPSASH = "SPSASH";// 分割条控件：框格
        public static readonly string C_OUTPUTSTYLE = "OUTPUTSTYLE";// 十进制浮点：输出样式
        public static readonly string C_SIGN = "SIGN";// 带 +/- 符号
        public static readonly string C_NOINPUTHISTORY = "NOINPUTHISTORY";// 无 GUI 输入历史记录
        public static readonly string C_AMPMENABLED = "AMPMENABLED";// AM/PM 启用时间格式
        public static readonly string C_EXTEND = "EXTEND";// 屏幕对象的修改状态
        public static readonly string C_HIERARCHY = "HIERARCHY";// 屏幕字段间的层次关系
        public static readonly string C_ICON = "ICON";// 图标标识（包括 @）
        public static readonly string C_ICON_N = "ICON_N";// 图标：名称
        public static readonly string C_ICON_T = "ICON_T";// 图标：描述
        public static readonly string C_ICON_L = "ICON_L";// 图标长度
        public static readonly string C_ICON_Q = "ICON_Q";// 图标：快速信息文本
        public static readonly string C_ICON_B = "ICON_B";// 图标：描述文本
        public static readonly string C_ICON_X = "ICON_X";// 图标: 带图标的输出元素
        public static readonly string C_FLDP = "FLDP";// 匹配码子键中的字段标识
        public static readonly string C_FLDN = "FLDN";// 匹配码子关键字中的字段名
        public static readonly string C_PROG = "PROG";// 修改：程序名称
        public static readonly string C_DNUM = "DNUM";// 修改：屏幕编号
        public static readonly string C_PBO_F = "PBO_F";// 修改：PBO 开头
        public static readonly string C_PBO_L = "PBO_L";// 修改：PBO 结尾
        public static readonly string C_PAI_F = "PAI_F";// 修改：PAI 开头
        public static readonly string C_PAI_L = "PAI_L";// 修改：PAI 结尾
        public static readonly string C_EXTEXT = "EXTEXT";// 修改：文本字段
        public static readonly string C_EXENTRY = "EXENTRY";// 修改：输入/输出字段
        public static readonly string C_EXRADIO = "EXRADIO";// 修改: 单选按钮
        public static readonly string C_EXCHECK = "EXCHECK";// 修改：复选框
        public static readonly string C_EXPUSH = "EXPUSH";// 修改: 按钮
        public static readonly string C_EXFRAME = "EXFRAME";// 修改: 框
        public static readonly string C_EXTABCTRL = "EXTABCTRL";// 修改：表控件
        public static readonly string C_EXCUSTOM = "EXCUSTOM";// 修改: 定制控制
        public static readonly string C_EXTSTRCTRL = "EXTSTRCTRL";// 修改：标签条控件
        public static readonly string C_EXSUBSCR = "EXSUBSCR";// 修改：子屏幕
        public static readonly string C_EXSPLITTER = "EXSPLITTER";// 修改：拆分器控件
        public static readonly string C_EXSHOW = "EXSHOW";// 修改：详细信息视图
        public static readonly string C_MSG_LINE1 = "MSG_LINE1";// 对话框状态行
        public static readonly string C_MSG_LINE2 = "MSG_LINE2";// 对话框状态行
        public static readonly string C_PROPSHOW = "PROPSHOW";// 属性包：转到属性列表
        public static readonly string C_PROPNAME = "PROPNAME";// 属性
        public static readonly string C_PROPBOOL = "PROPBOOL";// 属性包：布尔值
        public static readonly string C_PROPSTRING = "PROPSTRING";// 属性包：字符串值

        public int Index { get; set; }
        public bool Select { get; set; }
        public String name { get; set; } // 屏幕元素的名称
        public String dynnr { get; set; } // 屏幕号码
        public Decimal line { get; set; } // 出现字段的屏幕上的行
        public Decimal coln { get; set; } // 在屏幕上显示字段的列
        public Decimal leng { get; set; } // 定义的屏幕字段长度
        public Decimal vleng { get; set; } // 屏幕中可见的（定为可见的）字段长度
        public Decimal high { get; set; } // 屏幕中元素的高度
        public String type { get; set; } // 字段格式（ABAP 词典数据类型）
        public String fein { get; set; } // 此字段的期望输入
        public String fout { get; set; } // 此字段的期望输出
        public String scroll { get; set; } // 可滚动的输入/输出字段
        public String dict { get; set; } // ABAP 字典中的字段
        public String dmod { get; set; } // 修改 ABAP 字典的字段
        public String grp1 { get; set; } // 修改组 1
        public String grp2 { get; set; } // 修改组 2
        public String grp3 { get; set; } //   修改组3
        public String grp4 { get; set; } //   修改组4
        public Decimal loop { get; set; } // 循环计数
        public String fobl { get; set; } // 字段中的条目
        public String fstr { get; set; } // * 条目
        public String fnrs { get; set; } // 未重置
        public String fgks { get; set; } // 大/小写条目
        public String ffix { get; set; } // 固定，带下划线的字符模板
        public String fosb { get; set; } // 不用模板在 CHAR 字段中输入所有字符
        public String ffky { get; set; } // 字典的外键检查为活动状态
        public String fspa { get; set; } // SET 参数
        public String fgpa { get; set; } // GET 参数
        public String paid { get; set; } // 参数ID SAP内存
        public String ucnv { get; set; } // 转换出口
        public String hell { get; set; } // 亮度显示
        public String unsi { get; set; } // 不可见显示
        public String invr { get; set; } // 显示反转视频
        public String blin { get; set; } // 闪烁
        public String ulin { get; set; } // 突出显示
        public String colr { get; set; } // 显示颜色1...7
        public String fjus { get; set; } // 右对齐显示
        public String fill { get; set; } // 显示前导零
        public String labelleft { get; set; } // 作为左侧标签
        public String labelright { get; set; } // 作为右侧标签
        public String dblclick { get; set; } // 响应双击
        public String ltr { get; set; } // 基本写方向已定义为 LTR（从左至右）
        public String bidictrl { get; set; } // ABAP 字典：不过滤双向格式字符
        public String mtch { get; set; } // 搜索帮助
        public String waer { get; set; } // 参考字段
        public String fcod { get; set; } // 用于按钮的功能码
        public String ptype { get; set; } // 按钮的功能码类型
        public String ctmenuprog { get; set; } // 上下文菜单：程序名称
        public String ctmenustat { get; set; } // 上下文菜单：状态/菜单名
        public String ctmenuonct { get; set; } // 上下文菜单：动态回调 ON_CTMENU_...
        public String ctmenust { get; set; } // 上下文菜单：静态
        public String ctmenudy { get; set; } // 上下文菜单：动态 (ON_CTMENU_...)
        public String ccname { get; set; } // Control Composite：名称
        public String ccdleft { get; set; } // Control Composite：左停靠
        public String ccdright { get; set; } // Control Composite：右停靠
        public String ccdtop { get; set; } // Control Composite：上停靠
        public String ccdbottom { get; set; } // Control Composite：下停靠
        public int ccdlen_l { get; set; } // Control Composite：停靠控件的宽度
        public int ccdlen_r { get; set; } // Control Composite：停靠控件的宽度
        public int ccdhig_t { get; set; } // Control Composite：停靠控件的高度
        public int ccdhig_b { get; set; } // Control Composite：停靠控件的高度
        public String ltyp { get; set; } // 循环：循环类型(固定的或可变的)
        public String gtyp { get; set; } // 屏幕元素类型
        public String fixf { get; set; } // 以固定字体代替比例字体
        public String no3d { get; set; } // 输入/输出字段的二维显示
        public String oout { get; set; } // 纯输出字段
        public String win1 { get; set; } // 图形屏幕绘制器：全屏编辑器
        public String win2 { get; set; } // 图形屏幕绘制器：字段属性
        public String win3 { get; set; } // 图形屏幕绘制器：ABAP/4 字典/程序字段
        public String stxt { get; set; } // 屏幕元素的文本/模板
        public String cmbtast { get; set; } // 可能条目按钮和可能条目的修改
        public String cmbfoc { get; set; } // 可能条目的有效性
        public String dropfrom { get; set; } // 输入帮助: 原始值
        public String dropdown { get; set; } // 下拉
        public String fetchfld { get; set; } // 取得表字段或程序字段 (一般)
        public String rfcdest { get; set; } // 参考系统（RFC 目标）
        public String schab { get; set; } // 预选字典或程序字段的输入/输出字段
        public String schlk { get; set; } // 为词典字段预选短字段标签
        public String schlm { get; set; } // 为词典字段预选中字段标签
        public String schll { get; set; } // 为词典字段预选长字段标签
        public String ueber { get; set; } // 为词典字段预选标题
        public String schlno { get; set; } // 预选带有短文本 (无字段标签) 的词典字段
        public String schabno { get; set; } // 词典或程序字段 I/O 模板无预选
        public String textmod { get; set; } // 预选：使用修正的词典文本
        public String textorig { get; set; } // 预选：像在词典中一样使用原始文本
        public String dezusatz { get; set; } // 数据元素增补
        public String tltrennhor { get; set; } // 表控件：带水平分隔符
        public String tltrennver { get; set; } // 表控件：带垂直分隔符
        public String tlscrollh { get; set; } // 控件：水平滚动
        public String tlscrollv { get; set; } // 控件：垂直滚动
        public String tlscroll { get; set; } // 控件：可滚动
        public String tlselectzn { get; set; } // 表控制：无行选择
        public String tlselectzs { get; set; } // 表控制：单行选择
        public String tlselectzm { get; set; } // 表控制：多行选择
        public String tlselectsn { get; set; } // 表控制：无列选择
        public String tlselectss { get; set; } // 表控制：单列选择
        public String tlselectsm { get; set; } // 表控制：多列选择
        public String tlshowonly { get; set; } // 表控件：仅显示
        public String tlvarv { get; set; } // 控制：垂直调整
        public Decimal tlvarvmin { get; set; } // 控制：垂直调整中最少的行数
        public String tlvarh { get; set; } // 控制：水平调整
        public Decimal tlvarhmin { get; set; } // 控制：水平调整中最少的列数
        public String tlmark { get; set; } // 表控制：选择列
        public String tltitel { get; set; } // 表控制：带标题行
        public String tlueber { get; set; } // 表控制：带列头
        public String tlerfa { get; set; } // 表控制：项表
        public String tlausw { get; set; } // 表控制：选定行
        public String tlconf { get; set; } // 表控制：可配置性
        public String tltext { get; set; } // 表控制：字段文本
        public String tlentry { get; set; } // 表控制：项/模板字段
        public String tlradiob { get; set; } // 表控制：单选按钮
        public String tlcheckb { get; set; } // 表控制：复选框
        public String tlpushb { get; set; } // 表控制：按钮
        public String tlnametyp { get; set; } //   Multi--目的文本通用
        public String tlnamefld { get; set; } // 屏幕元素的名称
        public String tlnameueb { get; set; } // 屏幕元素的名称
        public String tlnamesel { get; set; } // 屏幕元素的名称
        public String tlnametit { get; set; } // 屏幕元素的名称
        public String tlfeldfix { get; set; } // 固定字段
        public int tlfixanz { get; set; } // 表控件：固定主导列数目
        public int tlfeldnr { get; set; } // 列号
        public int tlfeldnr00 { get; set; } // 列号
        public int tlfeldspbr { get; set; } // 列宽
        public String spcell1 { get; set; } // 分割条单元格名称
        public String spcell2 { get; set; } // 分割条单元格名称
        public String spsplitthoriz { get; set; } // 分割条控件：分割方向垂直/水平
        public String spsplittvert { get; set; } // 分割条控件：分割方向垂直/水平
        public int spsash { get; set; } // 分割条控件：框格
        public int outputstyle { get; set; } // 十进制浮点：输出样式
        public String sign { get; set; } // 带 +/- 符号
        public String noinputhistory { get; set; } // 无 GUI 输入历史记录
        public String ampmenabled { get; set; } // AM/PM 启用时间格式
        public String extend { get; set; } // 屏幕对象的修改状态
        public String hierarchy { get; set; } // 屏幕字段间的层次关系
        public String icon { get; set; } // 图标标识（包括 @）
        public String icon_n { get; set; } // 图标：名称
        public String icon_t { get; set; } // 图标：描述
        public String icon_l { get; set; } // 图标长度
        public String icon_q { get; set; } // 图标：快速信息文本
        public String icon_b { get; set; } // 图标：描述文本
        public String icon_x { get; set; } // 图标: 带图标的输出元素
        public String fldp { get; set; } // 匹配码子键中的字段标识
        public String fldn { get; set; } // 匹配码子关键字中的字段名
        public String prog { get; set; } // 修改：程序名称
        public String dnum { get; set; } // 修改：屏幕编号
        public String pbo_f { get; set; } // 修改：PBO 开头
        public String pbo_l { get; set; } // 修改：PBO 结尾
        public String pai_f { get; set; } // 修改：PAI 开头
        public String pai_l { get; set; } // 修改：PAI 结尾
        public String extext { get; set; } // 修改：文本字段
        public String exentry { get; set; } // 修改：输入/输出字段
        public String exradio { get; set; } // 修改: 单选按钮
        public String excheck { get; set; } // 修改：复选框
        public String expush { get; set; } // 修改: 按钮
        public String exframe { get; set; } // 修改: 框
        public String extabctrl { get; set; } // 修改：表控件
        public String excustom { get; set; } // 修改: 定制控制
        public String extstrctrl { get; set; } // 修改：标签条控件
        public String exsubscr { get; set; } // 修改：子屏幕
        public String exsplitter { get; set; } // 修改：拆分器控件
        public String exshow { get; set; } // 修改：详细信息视图
        public String msg_line1 { get; set; } // 对话框状态行
        public String msg_line2 { get; set; } // 对话框状态行
        public String propshow { get; set; } // 属性包：转到属性列表
        public String propname { get; set; } // 属性
        public String propbool { get; set; } // 属性包：布尔值
        public String propstring { get; set; } // 属性包：字符串值


        public static DataTable dtFields = null;
        public CScreenField()
        {
            dtFields = buildDtSchma();
        }
        //返回dt架构
        public static DataTable buildDtSchma()
        {
            DataTable dt = null;
            dt = new DataTable("ScreenField");
            dt.Columns.AddRange(new DataColumn[]{
		    	new DataColumn(C_INDEX,typeof(int)),//索引
	    		new DataColumn(C_SELECT,typeof(bool)),//是否选择
                new DataColumn(C_HIERARCHY,typeof(String)),// 屏幕字段间的层次关系
                new DataColumn(C_EXTEND,typeof(String)),// 屏幕对象的修改状态
    			new DataColumn(C_NAME,typeof(String)),// 屏幕元素的名称
                new DataColumn(C_GTYP,typeof(String)),// 屏幕元素类型
    			new DataColumn(C_DYNNR,typeof(String)),// 屏幕号码
    			new DataColumn(C_LINE,typeof(Decimal)),// 出现字段的屏幕上的行
    			new DataColumn(C_COLN,typeof(Decimal)),// 在屏幕上显示字段的列
    			new DataColumn(C_LENG,typeof(Decimal)),// 定义的屏幕字段长度
    			new DataColumn(C_VLENG,typeof(Decimal)),// 屏幕中可见的（定为可见的）字段长度
    			new DataColumn(C_HIGH,typeof(Decimal)),// 屏幕中元素的高度
                new DataColumn(C_STXT,typeof(String)),// 屏幕元素的文本/模板
    			new DataColumn(C_TYPE,typeof(String)),// 字段格式（ABAP 词典数据类型）
    			new DataColumn(C_FEIN,typeof(String)),// 此字段的期望输入
    			new DataColumn(C_FOUT,typeof(String)),// 此字段的期望输出
    			new DataColumn(C_SCROLL,typeof(String)),// 可滚动的输入/输出字段
    			new DataColumn(C_DICT,typeof(String)),// ABAP 字典中的字段
    			new DataColumn(C_DMOD,typeof(String)),// 修改 ABAP 字典的字段
    			new DataColumn(C_GRP1,typeof(String)),// 修改组 1
    			new DataColumn(C_GRP2,typeof(String)),// 修改组 2
    			new DataColumn(C_GRP3,typeof(String)),//   修改组3
    			new DataColumn(C_GRP4,typeof(String)),//   修改组4
    			new DataColumn(C_LOOP,typeof(Decimal)),// 循环计数
    			new DataColumn(C_FOBL,typeof(String)),// 字段中的条目
    			new DataColumn(C_FSTR,typeof(String)),// * 条目
    			new DataColumn(C_FNRS,typeof(String)),// 未重置
    			new DataColumn(C_FGKS,typeof(String)),// 大/小写条目
    			new DataColumn(C_FFIX,typeof(String)),// 固定，带下划线的字符模板
    			new DataColumn(C_FOSB,typeof(String)),// 不用模板在 CHAR 字段中输入所有字符
    			new DataColumn(C_FFKY,typeof(String)),// 字典的外键检查为活动状态
    			new DataColumn(C_FSPA,typeof(String)),// SET 参数
    			new DataColumn(C_FGPA,typeof(String)),// GET 参数
    			new DataColumn(C_PAID,typeof(String)),// 参数ID SAP内存
    			new DataColumn(C_UCNV,typeof(String)),// 转换出口
    			new DataColumn(C_HELL,typeof(String)),// 亮度显示
    			new DataColumn(C_UNSI,typeof(String)),// 不可见显示
    			new DataColumn(C_INVR,typeof(String)),// 显示反转视频
    			new DataColumn(C_BLIN,typeof(String)),// 闪烁
    			new DataColumn(C_ULIN,typeof(String)),// 突出显示
    			new DataColumn(C_COLR,typeof(String)),// 显示颜色1...7
    			new DataColumn(C_FJUS,typeof(String)),// 右对齐显示
    			new DataColumn(C_FILL,typeof(String)),// 显示前导零
    			new DataColumn(C_LABELLEFT,typeof(String)),// 作为左侧标签
    			new DataColumn(C_LABELRIGHT,typeof(String)),// 作为右侧标签
    			new DataColumn(C_DBLCLICK,typeof(String)),// 响应双击
    			new DataColumn(C_LTR,typeof(String)),// 基本写方向已定义为 LTR（从左至右）
    			new DataColumn(C_BIDICTRL,typeof(String)),// ABAP 字典：不过滤双向格式字符
    			new DataColumn(C_MTCH,typeof(String)),// 搜索帮助
    			new DataColumn(C_WAER,typeof(String)),// 参考字段
    			new DataColumn(C_FCOD,typeof(String)),// 用于按钮的功能码
    			new DataColumn(C_PTYPE,typeof(String)),// 按钮的功能码类型
    			new DataColumn(C_CTMENUPROG,typeof(String)),// 上下文菜单：程序名称
    			new DataColumn(C_CTMENUSTAT,typeof(String)),// 上下文菜单：状态/菜单名
    			new DataColumn(C_CTMENUONCT,typeof(String)),// 上下文菜单：动态回调 ON_CTMENU_...
    			new DataColumn(C_CTMENUST,typeof(String)),// 上下文菜单：静态
    			new DataColumn(C_CTMENUDY,typeof(String)),// 上下文菜单：动态 (ON_CTMENU_...)
    			new DataColumn(C_CCNAME,typeof(String)),// Control Composite：名称
    			new DataColumn(C_CCDLEFT,typeof(String)),// Control Composite：左停靠
    			new DataColumn(C_CCDRIGHT,typeof(String)),// Control Composite：右停靠
    			new DataColumn(C_CCDTOP,typeof(String)),// Control Composite：上停靠
    			new DataColumn(C_CCDBOTTOM,typeof(String)),// Control Composite：下停靠
    			new DataColumn(C_CCDLEN_L,typeof(int)),// Control Composite：停靠控件的宽度
    			new DataColumn(C_CCDLEN_R,typeof(int)),// Control Composite：停靠控件的宽度
    			new DataColumn(C_CCDHIG_T,typeof(int)),// Control Composite：停靠控件的高度
    			new DataColumn(C_CCDHIG_B,typeof(int)),// Control Composite：停靠控件的高度
    			new DataColumn(C_LTYP,typeof(String)),// 循环：循环类型(固定的或可变的)
    			
    			new DataColumn(C_FIXF,typeof(String)),// 以固定字体代替比例字体
    			new DataColumn(C_NO3D,typeof(String)),// 输入/输出字段的二维显示
    			new DataColumn(C_OOUT,typeof(String)),// 纯输出字段
    			new DataColumn(C_WIN1,typeof(String)),// 图形屏幕绘制器：全屏编辑器
    			new DataColumn(C_WIN2,typeof(String)),// 图形屏幕绘制器：字段属性
    			new DataColumn(C_WIN3,typeof(String)),// 图形屏幕绘制器：ABAP/4 字典/程序字段
    			
    			new DataColumn(C_CMBTAST,typeof(String)),// 可能条目按钮和可能条目的修改
    			new DataColumn(C_CMBFOC,typeof(String)),// 可能条目的有效性
    			new DataColumn(C_DROPFROM,typeof(String)),// 输入帮助: 原始值
    			new DataColumn(C_DROPDOWN,typeof(String)),// 下拉
    			new DataColumn(C_FETCHFLD,typeof(String)),// 取得表字段或程序字段 (一般)
    			new DataColumn(C_RFCDEST,typeof(String)),// 参考系统（RFC 目标）
    			new DataColumn(C_SCHAB,typeof(String)),// 预选字典或程序字段的输入/输出字段
    			new DataColumn(C_SCHLK,typeof(String)),// 为词典字段预选短字段标签
    			new DataColumn(C_SCHLM,typeof(String)),// 为词典字段预选中字段标签
    			new DataColumn(C_SCHLL,typeof(String)),// 为词典字段预选长字段标签
    			new DataColumn(C_UEBER,typeof(String)),// 为词典字段预选标题
    			new DataColumn(C_SCHLNO,typeof(String)),// 预选带有短文本 (无字段标签) 的词典字段
    			new DataColumn(C_SCHABNO,typeof(String)),// 词典或程序字段 I/O 模板无预选
    			new DataColumn(C_TEXTMOD,typeof(String)),// 预选：使用修正的词典文本
    			new DataColumn(C_TEXTORIG,typeof(String)),// 预选：像在词典中一样使用原始文本
    			new DataColumn(C_DEZUSATZ,typeof(String)),// 数据元素增补
    			new DataColumn(C_TLTRENNHOR,typeof(String)),// 表控件：带水平分隔符
    			new DataColumn(C_TLTRENNVER,typeof(String)),// 表控件：带垂直分隔符
    			new DataColumn(C_TLSCROLLH,typeof(String)),// 控件：水平滚动
    			new DataColumn(C_TLSCROLLV,typeof(String)),// 控件：垂直滚动
    			new DataColumn(C_TLSCROLL,typeof(String)),// 控件：可滚动
    			new DataColumn(C_TLSELECTZN,typeof(String)),// 表控制：无行选择
    			new DataColumn(C_TLSELECTZS,typeof(String)),// 表控制：单行选择
    			new DataColumn(C_TLSELECTZM,typeof(String)),// 表控制：多行选择
    			new DataColumn(C_TLSELECTSN,typeof(String)),// 表控制：无列选择
    			new DataColumn(C_TLSELECTSS,typeof(String)),// 表控制：单列选择
    			new DataColumn(C_TLSELECTSM,typeof(String)),// 表控制：多列选择
    			new DataColumn(C_TLSHOWONLY,typeof(String)),// 表控件：仅显示
    			new DataColumn(C_TLVARV,typeof(String)),// 控制：垂直调整
    			new DataColumn(C_TLVARVMIN,typeof(Decimal)),// 控制：垂直调整中最少的行数
    			new DataColumn(C_TLVARH,typeof(String)),// 控制：水平调整
    			new DataColumn(C_TLVARHMIN,typeof(Decimal)),// 控制：水平调整中最少的列数
    			new DataColumn(C_TLMARK,typeof(String)),// 表控制：选择列
    			new DataColumn(C_TLTITEL,typeof(String)),// 表控制：带标题行
    			new DataColumn(C_TLUEBER,typeof(String)),// 表控制：带列头
    			new DataColumn(C_TLERFA,typeof(String)),// 表控制：项表
    			new DataColumn(C_TLAUSW,typeof(String)),// 表控制：选定行
    			new DataColumn(C_TLCONF,typeof(String)),// 表控制：可配置性
    			new DataColumn(C_TLTEXT,typeof(String)),// 表控制：字段文本
    			new DataColumn(C_TLENTRY,typeof(String)),// 表控制：项/模板字段
    			new DataColumn(C_TLRADIOB,typeof(String)),// 表控制：单选按钮
    			new DataColumn(C_TLCHECKB,typeof(String)),// 表控制：复选框
    			new DataColumn(C_TLPUSHB,typeof(String)),// 表控制：按钮
    			new DataColumn(C_TLNAMETYP,typeof(String)),//   Multi--目的文本通用
    			new DataColumn(C_TLNAMEFLD,typeof(String)),// 屏幕元素的名称
    			new DataColumn(C_TLNAMEUEB,typeof(String)),// 屏幕元素的名称
    			new DataColumn(C_TLNAMESEL,typeof(String)),// 屏幕元素的名称
    			new DataColumn(C_TLNAMETIT,typeof(String)),// 屏幕元素的名称
    			new DataColumn(C_TLFELDFIX,typeof(String)),// 固定字段
    			new DataColumn(C_TLFIXANZ,typeof(int)),// 表控件：固定主导列数目
    			new DataColumn(C_TLFELDNR,typeof(int)),// 列号
    			new DataColumn(C_TLFELDNR00,typeof(int)),// 列号
    			new DataColumn(C_TLFELDSPBR,typeof(int)),// 列宽
    			new DataColumn(C_SPCELL1,typeof(String)),// 分割条单元格名称
    			new DataColumn(C_SPCELL2,typeof(String)),// 分割条单元格名称
    			new DataColumn(C_SPSPLITTHORIZ,typeof(String)),// 分割条控件：分割方向垂直/水平
    			new DataColumn(C_SPSPLITTVERT,typeof(String)),// 分割条控件：分割方向垂直/水平
    			new DataColumn(C_SPSASH,typeof(int)),// 分割条控件：框格
    			new DataColumn(C_OUTPUTSTYLE,typeof(int)),// 十进制浮点：输出样式
    			new DataColumn(C_SIGN,typeof(String)),// 带 +/- 符号
    			new DataColumn(C_NOINPUTHISTORY,typeof(String)),// 无 GUI 输入历史记录
    			new DataColumn(C_AMPMENABLED,typeof(String)),// AM/PM 启用时间格式
    			
    			
    			new DataColumn(C_ICON,typeof(String)),// 图标标识（包括 @）
    			new DataColumn(C_ICON_N,typeof(String)),// 图标：名称
    			new DataColumn(C_ICON_T,typeof(String)),// 图标：描述
    			new DataColumn(C_ICON_L,typeof(String)),// 图标长度
    			new DataColumn(C_ICON_Q,typeof(String)),// 图标：快速信息文本
    			new DataColumn(C_ICON_B,typeof(String)),// 图标：描述文本
    			new DataColumn(C_ICON_X,typeof(String)),// 图标: 带图标的输出元素
    			new DataColumn(C_FLDP,typeof(String)),// 匹配码子键中的字段标识
    			new DataColumn(C_FLDN,typeof(String)),// 匹配码子关键字中的字段名
    			new DataColumn(C_PROG,typeof(String)),// 修改：程序名称
    			new DataColumn(C_DNUM,typeof(String)),// 修改：屏幕编号
    			new DataColumn(C_PBO_F,typeof(String)),// 修改：PBO 开头
    			new DataColumn(C_PBO_L,typeof(String)),// 修改：PBO 结尾
    			new DataColumn(C_PAI_F,typeof(String)),// 修改：PAI 开头
    			new DataColumn(C_PAI_L,typeof(String)),// 修改：PAI 结尾
    			new DataColumn(C_EXTEXT,typeof(String)),// 修改：文本字段
    			new DataColumn(C_EXENTRY,typeof(String)),// 修改：输入/输出字段
    			new DataColumn(C_EXRADIO,typeof(String)),// 修改: 单选按钮
    			new DataColumn(C_EXCHECK,typeof(String)),// 修改：复选框
    			new DataColumn(C_EXPUSH,typeof(String)),// 修改: 按钮
    			new DataColumn(C_EXFRAME,typeof(String)),// 修改: 框
    			new DataColumn(C_EXTABCTRL,typeof(String)),// 修改：表控件
    			new DataColumn(C_EXCUSTOM,typeof(String)),// 修改: 定制控制
    			new DataColumn(C_EXTSTRCTRL,typeof(String)),// 修改：标签条控件
    			new DataColumn(C_EXSUBSCR,typeof(String)),// 修改：子屏幕
    			new DataColumn(C_EXSPLITTER,typeof(String)),// 修改：拆分器控件
    			new DataColumn(C_EXSHOW,typeof(String)),// 修改：详细信息视图
    			new DataColumn(C_MSG_LINE1,typeof(String)),// 对话框状态行
    			new DataColumn(C_MSG_LINE2,typeof(String)),// 对话框状态行
    			new DataColumn(C_PROPSHOW,typeof(String)),// 属性包：转到属性列表
    			new DataColumn(C_PROPNAME,typeof(String)),// 属性
    			new DataColumn(C_PROPBOOL,typeof(String)),// 属性包：布尔值
    			new DataColumn(C_PROPSTRING,typeof(String)),// 属性包：字符串值
  			});
            return dt;

        }
        //配置DGV控件,抬头
        public static void ConfigDgv(DataGridView dgv)
        {
            DataGridViewColumn dgvCol = null;
            dgvCol = dgv.Columns[C_INDEX];
            if (dgvCol != null) dgvCol.HeaderText = "索引";
            dgvCol = dgv.Columns[C_SELECT];
            if (dgvCol != null) dgvCol.HeaderText = "选择";
            dgvCol = dgv.Columns[C_NAME];
            if (dgvCol != null) dgvCol.HeaderText = "名称";
            dgvCol = dgv.Columns[C_DYNNR];
            if (dgvCol != null) dgvCol.HeaderText = "号码";
            dgvCol = dgv.Columns[C_LINE];
            if (dgvCol != null) dgvCol.HeaderText = "行";
            dgvCol = dgv.Columns[C_COLN];
            if (dgvCol != null) dgvCol.HeaderText = "列";
            dgvCol = dgv.Columns[C_LENG];
            if (dgvCol != null) dgvCol.HeaderText = "长度";
            dgvCol = dgv.Columns[C_VLENG];
            if (dgvCol != null) dgvCol.HeaderText = "可见长度";
            dgvCol = dgv.Columns[C_HIGH];
            if (dgvCol != null) dgvCol.HeaderText = "高度";
            dgvCol = dgv.Columns[C_TYPE];
            if (dgvCol != null) dgvCol.HeaderText = "字段格式";
            dgvCol = dgv.Columns[C_FEIN];
            if (dgvCol != null) dgvCol.HeaderText = "输入";
            dgvCol = dgv.Columns[C_FOUT];
            if (dgvCol != null) dgvCol.HeaderText = "输出";
            dgvCol = dgv.Columns[C_SCROLL];
            if (dgvCol != null) dgvCol.HeaderText = "可滚动的输入/输出字段";
            dgvCol = dgv.Columns[C_DICT];
            if (dgvCol != null) dgvCol.HeaderText = "ABAP 字典中的字段";
            dgvCol = dgv.Columns[C_DMOD];
            if (dgvCol != null) dgvCol.HeaderText = "修改 ABAP 字典的字段";
            dgvCol = dgv.Columns[C_GRP1];
            if (dgvCol != null) dgvCol.HeaderText = "修改组 1";
            dgvCol = dgv.Columns[C_GRP2];
            if (dgvCol != null) dgvCol.HeaderText = "修改组 2";
            dgvCol = dgv.Columns[C_GRP3];
            if (dgvCol != null) dgvCol.HeaderText = "修改组3";
            dgvCol = dgv.Columns[C_GRP4];
            if (dgvCol != null) dgvCol.HeaderText = " 修改组4";
            dgvCol = dgv.Columns[C_LOOP];
            if (dgvCol != null) dgvCol.HeaderText = "循环计数";
            dgvCol = dgv.Columns[C_FOBL];
            if (dgvCol != null) dgvCol.HeaderText = "字段中的条目";
            dgvCol = dgv.Columns[C_FSTR];
            if (dgvCol != null) dgvCol.HeaderText = "* 条目";
            dgvCol = dgv.Columns[C_FNRS];
            if (dgvCol != null) dgvCol.HeaderText = "未重置";
            dgvCol = dgv.Columns[C_FGKS];
            if (dgvCol != null) dgvCol.HeaderText = "大/小写条目";
            dgvCol = dgv.Columns[C_FFIX];
            if (dgvCol != null) dgvCol.HeaderText = "固定，带下划线的字符模板";
            dgvCol = dgv.Columns[C_FOSB];
            if (dgvCol != null) dgvCol.HeaderText = "不用模板在 CHAR 字段中输入所有字符";
            dgvCol = dgv.Columns[C_FFKY];
            if (dgvCol != null) dgvCol.HeaderText = "字典的外键检查为活动状态";
            dgvCol = dgv.Columns[C_FSPA];
            if (dgvCol != null) dgvCol.HeaderText = "SET 参数";
            dgvCol = dgv.Columns[C_FGPA];
            if (dgvCol != null) dgvCol.HeaderText = "GET 参数";
            dgvCol = dgv.Columns[C_PAID];
            if (dgvCol != null) dgvCol.HeaderText = "参数ID SAP内存";
            dgvCol = dgv.Columns[C_UCNV];
            if (dgvCol != null) dgvCol.HeaderText = "转换出口";
            dgvCol = dgv.Columns[C_HELL];
            if (dgvCol != null) dgvCol.HeaderText = "亮度显示";
            dgvCol = dgv.Columns[C_UNSI];
            if (dgvCol != null) dgvCol.HeaderText = "不可见显示";
            dgvCol = dgv.Columns[C_INVR];
            if (dgvCol != null) dgvCol.HeaderText = "显示反转视频";
            dgvCol = dgv.Columns[C_BLIN];
            if (dgvCol != null) dgvCol.HeaderText = "闪烁";
            dgvCol = dgv.Columns[C_ULIN];
            if (dgvCol != null) dgvCol.HeaderText = "突出显示";
            dgvCol = dgv.Columns[C_COLR];
            if (dgvCol != null) dgvCol.HeaderText = "显示颜色1...7";
            dgvCol = dgv.Columns[C_FJUS];
            if (dgvCol != null) dgvCol.HeaderText = "右对齐显示";
            dgvCol = dgv.Columns[C_FILL];
            if (dgvCol != null) dgvCol.HeaderText = "显示前导零";
            dgvCol = dgv.Columns[C_LABELLEFT];
            if (dgvCol != null) dgvCol.HeaderText = "作为左侧标签";
            dgvCol = dgv.Columns[C_LABELRIGHT];
            if (dgvCol != null) dgvCol.HeaderText = "作为右侧标签";
            dgvCol = dgv.Columns[C_DBLCLICK];
            if (dgvCol != null) dgvCol.HeaderText = "响应双击";
            dgvCol = dgv.Columns[C_LTR];
            if (dgvCol != null) dgvCol.HeaderText = "基本写方向已定义为 LTR（从左至右）";
            dgvCol = dgv.Columns[C_BIDICTRL];
            if (dgvCol != null) dgvCol.HeaderText = "ABAP 字典：不过滤双向格式字符";
            dgvCol = dgv.Columns[C_MTCH];
            if (dgvCol != null) dgvCol.HeaderText = "搜索帮助";
            dgvCol = dgv.Columns[C_WAER];
            if (dgvCol != null) dgvCol.HeaderText = "参考字段";
            dgvCol = dgv.Columns[C_FCOD];
            if (dgvCol != null) dgvCol.HeaderText = "用于按钮的功能码";
            dgvCol = dgv.Columns[C_PTYPE];
            if (dgvCol != null) dgvCol.HeaderText = "按钮的功能码类型";
            dgvCol = dgv.Columns[C_CTMENUPROG];
            if (dgvCol != null) dgvCol.HeaderText = "上下文菜单：程序名称";
            dgvCol = dgv.Columns[C_CTMENUSTAT];
            if (dgvCol != null) dgvCol.HeaderText = "上下文菜单：状态/菜单名";
            dgvCol = dgv.Columns[C_CTMENUONCT];
            if (dgvCol != null) dgvCol.HeaderText = "上下文菜单：动态回调 ON_CTMENU_...";
            dgvCol = dgv.Columns[C_CTMENUST];
            if (dgvCol != null) dgvCol.HeaderText = "上下文菜单：静态";
            dgvCol = dgv.Columns[C_CTMENUDY];
            if (dgvCol != null) dgvCol.HeaderText = "上下文菜单：动态 (ON_CTMENU_...)";
            dgvCol = dgv.Columns[C_CCNAME];
            if (dgvCol != null) dgvCol.HeaderText = "Control Composite：名称";
            dgvCol = dgv.Columns[C_CCDLEFT];
            if (dgvCol != null) dgvCol.HeaderText = "Control Composite：左停靠";
            dgvCol = dgv.Columns[C_CCDRIGHT];
            if (dgvCol != null) dgvCol.HeaderText = "Control Composite：右停靠";
            dgvCol = dgv.Columns[C_CCDTOP];
            if (dgvCol != null) dgvCol.HeaderText = "Control Composite：上停靠";
            dgvCol = dgv.Columns[C_CCDBOTTOM];
            if (dgvCol != null) dgvCol.HeaderText = "Control Composite：下停靠";
            dgvCol = dgv.Columns[C_CCDLEN_L];
            if (dgvCol != null) dgvCol.HeaderText = "Control Composite：停靠控件的宽度";
            dgvCol = dgv.Columns[C_CCDLEN_R];
            if (dgvCol != null) dgvCol.HeaderText = "Control Composite：停靠控件的宽度";
            dgvCol = dgv.Columns[C_CCDHIG_T];
            if (dgvCol != null) dgvCol.HeaderText = "Control Composite：停靠控件的高度";
            dgvCol = dgv.Columns[C_CCDHIG_B];
            if (dgvCol != null) dgvCol.HeaderText = "Control Composite：停靠控件的高度";
            dgvCol = dgv.Columns[C_LTYP];
            if (dgvCol != null) dgvCol.HeaderText = "循环：循环类型(固定的或可变的)";
            dgvCol = dgv.Columns[C_GTYP];
            if (dgvCol != null) dgvCol.HeaderText = "屏幕元素类型";
            dgvCol = dgv.Columns[C_FIXF];
            if (dgvCol != null) dgvCol.HeaderText = "以固定字体代替比例字体";
            dgvCol = dgv.Columns[C_NO3D];
            if (dgvCol != null) dgvCol.HeaderText = "输入/输出字段的二维显示";
            dgvCol = dgv.Columns[C_OOUT];
            if (dgvCol != null) dgvCol.HeaderText = "纯输出字段";
            dgvCol = dgv.Columns[C_WIN1];
            if (dgvCol != null) dgvCol.HeaderText = "图形屏幕绘制器：全屏编辑器";
            dgvCol = dgv.Columns[C_WIN2];
            if (dgvCol != null) dgvCol.HeaderText = "图形屏幕绘制器：字段属性";
            dgvCol = dgv.Columns[C_WIN3];
            if (dgvCol != null) dgvCol.HeaderText = "图形屏幕绘制器：ABAP/4 字典/程序字段";
            dgvCol = dgv.Columns[C_STXT];
            if (dgvCol != null) dgvCol.HeaderText = "屏幕元素的文本/模板";
            dgvCol = dgv.Columns[C_CMBTAST];
            if (dgvCol != null) dgvCol.HeaderText = "可能条目按钮和可能条目的修改";
            dgvCol = dgv.Columns[C_CMBFOC];
            if (dgvCol != null) dgvCol.HeaderText = "可能条目的有效性";
            dgvCol = dgv.Columns[C_DROPFROM];
            if (dgvCol != null) dgvCol.HeaderText = "输入帮助: 原始值";
            dgvCol = dgv.Columns[C_DROPDOWN];
            if (dgvCol != null) dgvCol.HeaderText = "下拉";
            dgvCol = dgv.Columns[C_FETCHFLD];
            if (dgvCol != null) dgvCol.HeaderText = "取得表字段或程序字段 (一般)";
            dgvCol = dgv.Columns[C_RFCDEST];
            if (dgvCol != null) dgvCol.HeaderText = "参考系统（RFC 目标）";
            dgvCol = dgv.Columns[C_SCHAB];
            if (dgvCol != null) dgvCol.HeaderText = "预选字典或程序字段的输入/输出字段";
            dgvCol = dgv.Columns[C_SCHLK];
            if (dgvCol != null) dgvCol.HeaderText = "为词典字段预选短字段标签";
            dgvCol = dgv.Columns[C_SCHLM];
            if (dgvCol != null) dgvCol.HeaderText = "为词典字段预选中字段标签";
            dgvCol = dgv.Columns[C_SCHLL];
            if (dgvCol != null) dgvCol.HeaderText = "为词典字段预选长字段标签";
            dgvCol = dgv.Columns[C_UEBER];
            if (dgvCol != null) dgvCol.HeaderText = "为词典字段预选标题";
            dgvCol = dgv.Columns[C_SCHLNO];
            if (dgvCol != null) dgvCol.HeaderText = "预选带有短文本 (无字段标签) 的词典字段";
            dgvCol = dgv.Columns[C_SCHABNO];
            if (dgvCol != null) dgvCol.HeaderText = "词典或程序字段 I/O 模板无预选";
            dgvCol = dgv.Columns[C_TEXTMOD];
            if (dgvCol != null) dgvCol.HeaderText = "预选：使用修正的词典文本";
            dgvCol = dgv.Columns[C_TEXTORIG];
            if (dgvCol != null) dgvCol.HeaderText = "预选：像在词典中一样使用原始文本";
            dgvCol = dgv.Columns[C_DEZUSATZ];
            if (dgvCol != null) dgvCol.HeaderText = "数据元素增补";
            dgvCol = dgv.Columns[C_TLTRENNHOR];
            if (dgvCol != null) dgvCol.HeaderText = "表控件：带水平分隔符";
            dgvCol = dgv.Columns[C_TLTRENNVER];
            if (dgvCol != null) dgvCol.HeaderText = "表控件：带垂直分隔符";
            dgvCol = dgv.Columns[C_TLSCROLLH];
            if (dgvCol != null) dgvCol.HeaderText = "控件：水平滚动";
            dgvCol = dgv.Columns[C_TLSCROLLV];
            if (dgvCol != null) dgvCol.HeaderText = "控件：垂直滚动";
            dgvCol = dgv.Columns[C_TLSCROLL];
            if (dgvCol != null) dgvCol.HeaderText = "控件：可滚动";
            dgvCol = dgv.Columns[C_TLSELECTZN];
            if (dgvCol != null) dgvCol.HeaderText = "表控制：无行选择";
            dgvCol = dgv.Columns[C_TLSELECTZS];
            if (dgvCol != null) dgvCol.HeaderText = "表控制：单行选择";
            dgvCol = dgv.Columns[C_TLSELECTZM];
            if (dgvCol != null) dgvCol.HeaderText = "表控制：多行选择";
            dgvCol = dgv.Columns[C_TLSELECTSN];
            if (dgvCol != null) dgvCol.HeaderText = "表控制：无列选择";
            dgvCol = dgv.Columns[C_TLSELECTSS];
            if (dgvCol != null) dgvCol.HeaderText = "表控制：单列选择";
            dgvCol = dgv.Columns[C_TLSELECTSM];
            if (dgvCol != null) dgvCol.HeaderText = "表控制：多列选择";
            dgvCol = dgv.Columns[C_TLSHOWONLY];
            if (dgvCol != null) dgvCol.HeaderText = "表控件：仅显示";
            dgvCol = dgv.Columns[C_TLVARV];
            if (dgvCol != null) dgvCol.HeaderText = "控制：垂直调整";
            dgvCol = dgv.Columns[C_TLVARVMIN];
            if (dgvCol != null) dgvCol.HeaderText = "控制：垂直调整中最少的行数";
            dgvCol = dgv.Columns[C_TLVARH];
            if (dgvCol != null) dgvCol.HeaderText = "控制：水平调整";
            dgvCol = dgv.Columns[C_TLVARHMIN];
            if (dgvCol != null) dgvCol.HeaderText = "控制：水平调整中最少的列数";
            dgvCol = dgv.Columns[C_TLMARK];
            if (dgvCol != null) dgvCol.HeaderText = "表控制：选择列";
            dgvCol = dgv.Columns[C_TLTITEL];
            if (dgvCol != null) dgvCol.HeaderText = "表控制：带标题行";
            dgvCol = dgv.Columns[C_TLUEBER];
            if (dgvCol != null) dgvCol.HeaderText = "表控制：带列头";
            dgvCol = dgv.Columns[C_TLERFA];
            if (dgvCol != null) dgvCol.HeaderText = "表控制：项表";
            dgvCol = dgv.Columns[C_TLAUSW];
            if (dgvCol != null) dgvCol.HeaderText = "表控制：选定行";
            dgvCol = dgv.Columns[C_TLCONF];
            if (dgvCol != null) dgvCol.HeaderText = "表控制：可配置性";
            dgvCol = dgv.Columns[C_TLTEXT];
            if (dgvCol != null) dgvCol.HeaderText = "表控制：字段文本";
            dgvCol = dgv.Columns[C_TLENTRY];
            if (dgvCol != null) dgvCol.HeaderText = "表控制：项/模板字段";
            dgvCol = dgv.Columns[C_TLRADIOB];
            if (dgvCol != null) dgvCol.HeaderText = "表控制：单选按钮";
            dgvCol = dgv.Columns[C_TLCHECKB];
            if (dgvCol != null) dgvCol.HeaderText = "表控制：复选框";
            dgvCol = dgv.Columns[C_TLPUSHB];
            if (dgvCol != null) dgvCol.HeaderText = "表控制：按钮";
            dgvCol = dgv.Columns[C_TLNAMETYP];
            if (dgvCol != null) dgvCol.HeaderText = "  Multi--目的文本通用";
            dgvCol = dgv.Columns[C_TLNAMEFLD];
            if (dgvCol != null) dgvCol.HeaderText = "屏幕元素的名称";
            dgvCol = dgv.Columns[C_TLNAMEUEB];
            if (dgvCol != null) dgvCol.HeaderText = "屏幕元素的名称";
            dgvCol = dgv.Columns[C_TLNAMESEL];
            if (dgvCol != null) dgvCol.HeaderText = "屏幕元素的名称";
            dgvCol = dgv.Columns[C_TLNAMETIT];
            if (dgvCol != null) dgvCol.HeaderText = "屏幕元素的名称";
            dgvCol = dgv.Columns[C_TLFELDFIX];
            if (dgvCol != null) dgvCol.HeaderText = "固定字段";
            dgvCol = dgv.Columns[C_TLFIXANZ];
            if (dgvCol != null) dgvCol.HeaderText = "表控件：固定主导列数目";
            dgvCol = dgv.Columns[C_TLFELDNR];
            if (dgvCol != null) dgvCol.HeaderText = "列号";
            dgvCol = dgv.Columns[C_TLFELDNR00];
            if (dgvCol != null) dgvCol.HeaderText = "列号";
            dgvCol = dgv.Columns[C_TLFELDSPBR];
            if (dgvCol != null) dgvCol.HeaderText = "列宽";
            dgvCol = dgv.Columns[C_SPCELL1];
            if (dgvCol != null) dgvCol.HeaderText = "分割条单元格名称";
            dgvCol = dgv.Columns[C_SPCELL2];
            if (dgvCol != null) dgvCol.HeaderText = "分割条单元格名称";
            dgvCol = dgv.Columns[C_SPSPLITTHORIZ];
            if (dgvCol != null) dgvCol.HeaderText = "分割条控件：分割方向垂直/水平";
            dgvCol = dgv.Columns[C_SPSPLITTVERT];
            if (dgvCol != null) dgvCol.HeaderText = "分割条控件：分割方向垂直/水平";
            dgvCol = dgv.Columns[C_SPSASH];
            if (dgvCol != null) dgvCol.HeaderText = "分割条控件：框格";
            dgvCol = dgv.Columns[C_OUTPUTSTYLE];
            if (dgvCol != null) dgvCol.HeaderText = "十进制浮点：输出样式";
            dgvCol = dgv.Columns[C_SIGN];
            if (dgvCol != null) dgvCol.HeaderText = "带 +/- 符号";
            dgvCol = dgv.Columns[C_NOINPUTHISTORY];
            if (dgvCol != null) dgvCol.HeaderText = "无 GUI 输入历史记录";
            dgvCol = dgv.Columns[C_AMPMENABLED];
            if (dgvCol != null) dgvCol.HeaderText = "AM/PM 启用时间格式";
            dgvCol = dgv.Columns[C_EXTEND];
            if (dgvCol != null) dgvCol.HeaderText = "已修改";
            dgvCol = dgv.Columns[C_HIERARCHY];
            if (dgvCol != null) dgvCol.HeaderText = "层次";
            dgvCol = dgv.Columns[C_ICON];
            if (dgvCol != null) dgvCol.HeaderText = "图标标识（包括 @）";
            dgvCol = dgv.Columns[C_ICON_N];
            if (dgvCol != null) dgvCol.HeaderText = "图标：名称";
            dgvCol = dgv.Columns[C_ICON_T];
            if (dgvCol != null) dgvCol.HeaderText = "图标：描述";
            dgvCol = dgv.Columns[C_ICON_L];
            if (dgvCol != null) dgvCol.HeaderText = "图标长度";
            dgvCol = dgv.Columns[C_ICON_Q];
            if (dgvCol != null) dgvCol.HeaderText = "图标：快速信息文本";
            dgvCol = dgv.Columns[C_ICON_B];
            if (dgvCol != null) dgvCol.HeaderText = "图标：描述文本";
            dgvCol = dgv.Columns[C_ICON_X];
            if (dgvCol != null) dgvCol.HeaderText = "图标: 带图标的输出元素";
            dgvCol = dgv.Columns[C_FLDP];
            if (dgvCol != null) dgvCol.HeaderText = "匹配码子键中的字段标识";
            dgvCol = dgv.Columns[C_FLDN];
            if (dgvCol != null) dgvCol.HeaderText = "匹配码子关键字中的字段名";
            dgvCol = dgv.Columns[C_PROG];
            if (dgvCol != null) dgvCol.HeaderText = "修改：程序名称";
            dgvCol = dgv.Columns[C_DNUM];
            if (dgvCol != null) dgvCol.HeaderText = "修改：屏幕编号";
            dgvCol = dgv.Columns[C_PBO_F];
            if (dgvCol != null) dgvCol.HeaderText = "修改：PBO 开头";
            dgvCol = dgv.Columns[C_PBO_L];
            if (dgvCol != null) dgvCol.HeaderText = "修改：PBO 结尾";
            dgvCol = dgv.Columns[C_PAI_F];
            if (dgvCol != null) dgvCol.HeaderText = "修改：PAI 开头";
            dgvCol = dgv.Columns[C_PAI_L];
            if (dgvCol != null) dgvCol.HeaderText = "修改：PAI 结尾";
            dgvCol = dgv.Columns[C_EXTEXT];
            if (dgvCol != null) dgvCol.HeaderText = "修改：文本字段";
            dgvCol = dgv.Columns[C_EXENTRY];
            if (dgvCol != null) dgvCol.HeaderText = "修改：输入/输出字段";
            dgvCol = dgv.Columns[C_EXRADIO];
            if (dgvCol != null) dgvCol.HeaderText = "修改: 单选按钮";
            dgvCol = dgv.Columns[C_EXCHECK];
            if (dgvCol != null) dgvCol.HeaderText = "修改：复选框";
            dgvCol = dgv.Columns[C_EXPUSH];
            if (dgvCol != null) dgvCol.HeaderText = "修改: 按钮";
            dgvCol = dgv.Columns[C_EXFRAME];
            if (dgvCol != null) dgvCol.HeaderText = "修改: 框";
            dgvCol = dgv.Columns[C_EXTABCTRL];
            if (dgvCol != null) dgvCol.HeaderText = "修改：表控件";
            dgvCol = dgv.Columns[C_EXCUSTOM];
            if (dgvCol != null) dgvCol.HeaderText = "修改: 定制控制";
            dgvCol = dgv.Columns[C_EXTSTRCTRL];
            if (dgvCol != null) dgvCol.HeaderText = "修改：标签条控件";
            dgvCol = dgv.Columns[C_EXSUBSCR];
            if (dgvCol != null) dgvCol.HeaderText = "修改：子屏幕";
            dgvCol = dgv.Columns[C_EXSPLITTER];
            if (dgvCol != null) dgvCol.HeaderText = "修改：拆分器控件";
            dgvCol = dgv.Columns[C_EXSHOW];
            if (dgvCol != null) dgvCol.HeaderText = "修改：详细信息视图";
            dgvCol = dgv.Columns[C_MSG_LINE1];
            if (dgvCol != null) dgvCol.HeaderText = "对话框状态行";
            dgvCol = dgv.Columns[C_MSG_LINE2];
            if (dgvCol != null) dgvCol.HeaderText = "对话框状态行";
            dgvCol = dgv.Columns[C_PROPSHOW];
            if (dgvCol != null) dgvCol.HeaderText = "属性包：转到属性列表";
            dgvCol = dgv.Columns[C_PROPNAME];
            if (dgvCol != null) dgvCol.HeaderText = "属性";
            dgvCol = dgv.Columns[C_PROPBOOL];
            if (dgvCol != null) dgvCol.HeaderText = "属性包：布尔值";
            dgvCol = dgv.Columns[C_PROPSTRING];
            if (dgvCol != null) dgvCol.HeaderText = "属性包：字符串值";
        }//ConfigDgv

        //根据RFCTABLE,返回DT
        public static DataTable getScreenFieldAsDt(IRfcTable iScreenField, DataTable dt = null)
        {
            if (dt == null)
            {
                if (dtFields == null)
                {
                    dtFields = buildDtSchma();
                    dt = dtFields;
                }
                else
                {
                    dt = dtFields;
                }
               // dt = buildDtSchma();
            }
            foreach (IRfcStructure row in iScreenField)
            {
                DataRow dr = dt.NewRow();
                dr[C_NAME] = row.GetValue(C_NAME) ?? DBNull.Value;//屏幕元素的名称
                dr[C_DYNNR] = row.GetValue(C_DYNNR) ?? DBNull.Value;//屏幕号码
                dr[C_LINE] = row.GetValue(C_LINE) ?? DBNull.Value;//出现字段的屏幕上的行
                dr[C_COLN] = row.GetValue(C_COLN) ?? DBNull.Value;//在屏幕上显示字段的列
                dr[C_LENG] = row.GetValue(C_LENG) ?? DBNull.Value;//定义的屏幕字段长度
                dr[C_VLENG] = row.GetValue(C_VLENG) ?? DBNull.Value;//屏幕中可见的（定为可见的）字段长度
                dr[C_HIGH] = row.GetValue(C_HIGH) ?? DBNull.Value;//屏幕中元素的高度
                dr[C_TYPE] = row.GetValue(C_TYPE) ?? DBNull.Value;//字段格式（ABAP 词典数据类型）
                dr[C_FEIN] = row.GetValue(C_FEIN) ?? DBNull.Value;//此字段的期望输入
                dr[C_FOUT] = row.GetValue(C_FOUT) ?? DBNull.Value;//此字段的期望输出
                dr[C_SCROLL] = row.GetValue(C_SCROLL) ?? DBNull.Value;//可滚动的输入/输出字段
                dr[C_DICT] = row.GetValue(C_DICT) ?? DBNull.Value;//ABAP 字典中的字段
                dr[C_DMOD] = row.GetValue(C_DMOD) ?? DBNull.Value;//修改 ABAP 字典的字段
                dr[C_GRP1] = row.GetValue(C_GRP1) ?? DBNull.Value;//修改组 1
                dr[C_GRP2] = row.GetValue(C_GRP2) ?? DBNull.Value;//修改组 2
                dr[C_GRP3] = row.GetValue(C_GRP3) ?? DBNull.Value;//  修改组3
                dr[C_GRP4] = row.GetValue(C_GRP4) ?? DBNull.Value;//  修改组4
                dr[C_LOOP] = row.GetValue(C_LOOP) ?? DBNull.Value;//循环计数
                dr[C_FOBL] = row.GetValue(C_FOBL) ?? DBNull.Value;//字段中的条目
                dr[C_FSTR] = row.GetValue(C_FSTR) ?? DBNull.Value;//* 条目
                dr[C_FNRS] = row.GetValue(C_FNRS) ?? DBNull.Value;//未重置
                dr[C_FGKS] = row.GetValue(C_FGKS) ?? DBNull.Value;//大/小写条目
                dr[C_FFIX] = row.GetValue(C_FFIX) ?? DBNull.Value;//固定，带下划线的字符模板
                dr[C_FOSB] = row.GetValue(C_FOSB) ?? DBNull.Value;//不用模板在 CHAR 字段中输入所有字符
                dr[C_FFKY] = row.GetValue(C_FFKY) ?? DBNull.Value;//字典的外键检查为活动状态
                dr[C_FSPA] = row.GetValue(C_FSPA) ?? DBNull.Value;//SET 参数
                dr[C_FGPA] = row.GetValue(C_FGPA) ?? DBNull.Value;//GET 参数
                dr[C_PAID] = row.GetValue(C_PAID) ?? DBNull.Value;//参数ID SAP内存
                dr[C_UCNV] = row.GetValue(C_UCNV) ?? DBNull.Value;//转换出口
                dr[C_HELL] = row.GetValue(C_HELL) ?? DBNull.Value;//亮度显示
                dr[C_UNSI] = row.GetValue(C_UNSI) ?? DBNull.Value;//不可见显示
                dr[C_INVR] = row.GetValue(C_INVR) ?? DBNull.Value;//显示反转视频
                dr[C_BLIN] = row.GetValue(C_BLIN) ?? DBNull.Value;//闪烁
                dr[C_ULIN] = row.GetValue(C_ULIN) ?? DBNull.Value;//突出显示
                dr[C_COLR] = row.GetValue(C_COLR) ?? DBNull.Value;//显示颜色1...7
                dr[C_FJUS] = row.GetValue(C_FJUS) ?? DBNull.Value;//右对齐显示
                dr[C_FILL] = row.GetValue(C_FILL) ?? DBNull.Value;//显示前导零
                dr[C_LABELLEFT] = row.GetValue(C_LABELLEFT) ?? DBNull.Value;//作为左侧标签
                dr[C_LABELRIGHT] = row.GetValue(C_LABELRIGHT) ?? DBNull.Value;//作为右侧标签
                dr[C_DBLCLICK] = row.GetValue(C_DBLCLICK) ?? DBNull.Value;//响应双击
                dr[C_LTR] = row.GetValue(C_LTR) ?? DBNull.Value;//基本写方向已定义为 LTR（从左至右）
                dr[C_BIDICTRL] = row.GetValue(C_BIDICTRL) ?? DBNull.Value;//ABAP 字典：不过滤双向格式字符
                dr[C_MTCH] = row.GetValue(C_MTCH) ?? DBNull.Value;//搜索帮助
                dr[C_WAER] = row.GetValue(C_WAER) ?? DBNull.Value;//参考字段
                dr[C_FCOD] = row.GetValue(C_FCOD) ?? DBNull.Value;//用于按钮的功能码
                dr[C_PTYPE] = row.GetValue(C_PTYPE) ?? DBNull.Value;//按钮的功能码类型
                dr[C_CTMENUPROG] = row.GetValue(C_CTMENUPROG) ?? DBNull.Value;//上下文菜单：程序名称
                dr[C_CTMENUSTAT] = row.GetValue(C_CTMENUSTAT) ?? DBNull.Value;//上下文菜单：状态/菜单名
                dr[C_CTMENUONCT] = row.GetValue(C_CTMENUONCT) ?? DBNull.Value;//上下文菜单：动态回调 ON_CTMENU_...
                dr[C_CTMENUST] = row.GetValue(C_CTMENUST) ?? DBNull.Value;//上下文菜单：静态
                dr[C_CTMENUDY] = row.GetValue(C_CTMENUDY) ?? DBNull.Value;//上下文菜单：动态 (ON_CTMENU_...)
                dr[C_CCNAME] = row.GetValue(C_CCNAME) ?? DBNull.Value;//Control Composite：名称
                dr[C_CCDLEFT] = row.GetValue(C_CCDLEFT) ?? DBNull.Value;//Control Composite：左停靠
                dr[C_CCDRIGHT] = row.GetValue(C_CCDRIGHT) ?? DBNull.Value;//Control Composite：右停靠
                dr[C_CCDTOP] = row.GetValue(C_CCDTOP) ?? DBNull.Value;//Control Composite：上停靠
                dr[C_CCDBOTTOM] = row.GetValue(C_CCDBOTTOM) ?? DBNull.Value;//Control Composite：下停靠
                dr[C_CCDLEN_L] = row.GetValue(C_CCDLEN_L) ?? DBNull.Value;//Control Composite：停靠控件的宽度
                dr[C_CCDLEN_R] = row.GetValue(C_CCDLEN_R) ?? DBNull.Value;//Control Composite：停靠控件的宽度
                dr[C_CCDHIG_T] = row.GetValue(C_CCDHIG_T) ?? DBNull.Value;//Control Composite：停靠控件的高度
                dr[C_CCDHIG_B] = row.GetValue(C_CCDHIG_B) ?? DBNull.Value;//Control Composite：停靠控件的高度
                dr[C_LTYP] = row.GetValue(C_LTYP) ?? DBNull.Value;//循环：循环类型(固定的或可变的)
                dr[C_GTYP] = row.GetValue(C_GTYP) ?? DBNull.Value;//屏幕元素类型
                dr[C_FIXF] = row.GetValue(C_FIXF) ?? DBNull.Value;//以固定字体代替比例字体
                dr[C_NO3D] = row.GetValue(C_NO3D) ?? DBNull.Value;//输入/输出字段的二维显示
                dr[C_OOUT] = row.GetValue(C_OOUT) ?? DBNull.Value;//纯输出字段
                dr[C_WIN1] = row.GetValue(C_WIN1) ?? DBNull.Value;//图形屏幕绘制器：全屏编辑器
                dr[C_WIN2] = row.GetValue(C_WIN2) ?? DBNull.Value;//图形屏幕绘制器：字段属性
                dr[C_WIN3] = row.GetValue(C_WIN3) ?? DBNull.Value;//图形屏幕绘制器：ABAP/4 字典/程序字段
                dr[C_STXT] = row.GetValue(C_STXT) ?? DBNull.Value;//屏幕元素的文本/模板
                dr[C_CMBTAST] = row.GetValue(C_CMBTAST) ?? DBNull.Value;//可能条目按钮和可能条目的修改
                dr[C_CMBFOC] = row.GetValue(C_CMBFOC) ?? DBNull.Value;//可能条目的有效性
                dr[C_DROPFROM] = row.GetValue(C_DROPFROM) ?? DBNull.Value;//输入帮助: 原始值
                dr[C_DROPDOWN] = row.GetValue(C_DROPDOWN) ?? DBNull.Value;//下拉
                dr[C_FETCHFLD] = row.GetValue(C_FETCHFLD) ?? DBNull.Value;//取得表字段或程序字段 (一般)
                dr[C_RFCDEST] = row.GetValue(C_RFCDEST) ?? DBNull.Value;//参考系统（RFC 目标）
                dr[C_SCHAB] = row.GetValue(C_SCHAB) ?? DBNull.Value;//预选字典或程序字段的输入/输出字段
                dr[C_SCHLK] = row.GetValue(C_SCHLK) ?? DBNull.Value;//为词典字段预选短字段标签
                dr[C_SCHLM] = row.GetValue(C_SCHLM) ?? DBNull.Value;//为词典字段预选中字段标签
                dr[C_SCHLL] = row.GetValue(C_SCHLL) ?? DBNull.Value;//为词典字段预选长字段标签
                dr[C_UEBER] = row.GetValue(C_UEBER) ?? DBNull.Value;//为词典字段预选标题
                dr[C_SCHLNO] = row.GetValue(C_SCHLNO) ?? DBNull.Value;//预选带有短文本 (无字段标签) 的词典字段
                dr[C_SCHABNO] = row.GetValue(C_SCHABNO) ?? DBNull.Value;//词典或程序字段 I/O 模板无预选
                dr[C_TEXTMOD] = row.GetValue(C_TEXTMOD) ?? DBNull.Value;//预选：使用修正的词典文本
                dr[C_TEXTORIG] = row.GetValue(C_TEXTORIG) ?? DBNull.Value;//预选：像在词典中一样使用原始文本
                dr[C_DEZUSATZ] = row.GetValue(C_DEZUSATZ) ?? DBNull.Value;//数据元素增补
                dr[C_TLTRENNHOR] = row.GetValue(C_TLTRENNHOR) ?? DBNull.Value;//表控件：带水平分隔符
                dr[C_TLTRENNVER] = row.GetValue(C_TLTRENNVER) ?? DBNull.Value;//表控件：带垂直分隔符
                dr[C_TLSCROLLH] = row.GetValue(C_TLSCROLLH) ?? DBNull.Value;//控件：水平滚动
                dr[C_TLSCROLLV] = row.GetValue(C_TLSCROLLV) ?? DBNull.Value;//控件：垂直滚动
                dr[C_TLSCROLL] = row.GetValue(C_TLSCROLL) ?? DBNull.Value;//控件：可滚动
                dr[C_TLSELECTZN] = row.GetValue(C_TLSELECTZN) ?? DBNull.Value;//表控制：无行选择
                dr[C_TLSELECTZS] = row.GetValue(C_TLSELECTZS) ?? DBNull.Value;//表控制：单行选择
                dr[C_TLSELECTZM] = row.GetValue(C_TLSELECTZM) ?? DBNull.Value;//表控制：多行选择
                dr[C_TLSELECTSN] = row.GetValue(C_TLSELECTSN) ?? DBNull.Value;//表控制：无列选择
                dr[C_TLSELECTSS] = row.GetValue(C_TLSELECTSS) ?? DBNull.Value;//表控制：单列选择
                dr[C_TLSELECTSM] = row.GetValue(C_TLSELECTSM) ?? DBNull.Value;//表控制：多列选择
                dr[C_TLSHOWONLY] = row.GetValue(C_TLSHOWONLY) ?? DBNull.Value;//表控件：仅显示
                dr[C_TLVARV] = row.GetValue(C_TLVARV) ?? DBNull.Value;//控制：垂直调整
                dr[C_TLVARVMIN] = row.GetValue(C_TLVARVMIN) ?? DBNull.Value;//控制：垂直调整中最少的行数
                dr[C_TLVARH] = row.GetValue(C_TLVARH) ?? DBNull.Value;//控制：水平调整
                dr[C_TLVARHMIN] = row.GetValue(C_TLVARHMIN) ?? DBNull.Value;//控制：水平调整中最少的列数
                dr[C_TLMARK] = row.GetValue(C_TLMARK) ?? DBNull.Value;//表控制：选择列
                dr[C_TLTITEL] = row.GetValue(C_TLTITEL) ?? DBNull.Value;//表控制：带标题行
                dr[C_TLUEBER] = row.GetValue(C_TLUEBER) ?? DBNull.Value;//表控制：带列头
                dr[C_TLERFA] = row.GetValue(C_TLERFA) ?? DBNull.Value;//表控制：项表
                dr[C_TLAUSW] = row.GetValue(C_TLAUSW) ?? DBNull.Value;//表控制：选定行
                dr[C_TLCONF] = row.GetValue(C_TLCONF) ?? DBNull.Value;//表控制：可配置性
                dr[C_TLTEXT] = row.GetValue(C_TLTEXT) ?? DBNull.Value;//表控制：字段文本
                dr[C_TLENTRY] = row.GetValue(C_TLENTRY) ?? DBNull.Value;//表控制：项/模板字段
                dr[C_TLRADIOB] = row.GetValue(C_TLRADIOB) ?? DBNull.Value;//表控制：单选按钮
                dr[C_TLCHECKB] = row.GetValue(C_TLCHECKB) ?? DBNull.Value;//表控制：复选框
                dr[C_TLPUSHB] = row.GetValue(C_TLPUSHB) ?? DBNull.Value;//表控制：按钮
                dr[C_TLNAMETYP] = row.GetValue(C_TLNAMETYP) ?? DBNull.Value;//  Multi--目的文本通用
                dr[C_TLNAMEFLD] = row.GetValue(C_TLNAMEFLD) ?? DBNull.Value;//屏幕元素的名称
                dr[C_TLNAMEUEB] = row.GetValue(C_TLNAMEUEB) ?? DBNull.Value;//屏幕元素的名称
                dr[C_TLNAMESEL] = row.GetValue(C_TLNAMESEL) ?? DBNull.Value;//屏幕元素的名称
                dr[C_TLNAMETIT] = row.GetValue(C_TLNAMETIT) ?? DBNull.Value;//屏幕元素的名称
                dr[C_TLFELDFIX] = row.GetValue(C_TLFELDFIX) ?? DBNull.Value;//固定字段
                dr[C_TLFIXANZ] = row.GetValue(C_TLFIXANZ) ?? DBNull.Value;//表控件：固定主导列数目
                dr[C_TLFELDNR] = row.GetValue(C_TLFELDNR) ?? DBNull.Value;//列号
                dr[C_TLFELDNR00] = row.GetValue(C_TLFELDNR00) ?? DBNull.Value;//列号
                dr[C_TLFELDSPBR] = row.GetValue(C_TLFELDSPBR) ?? DBNull.Value;//列宽
                dr[C_SPCELL1] = row.GetValue(C_SPCELL1) ?? DBNull.Value;//分割条单元格名称
                dr[C_SPCELL2] = row.GetValue(C_SPCELL2) ?? DBNull.Value;//分割条单元格名称
                dr[C_SPSPLITTHORIZ] = row.GetValue(C_SPSPLITTHORIZ) ?? DBNull.Value;//分割条控件：分割方向垂直/水平
                dr[C_SPSPLITTVERT] = row.GetValue(C_SPSPLITTVERT) ?? DBNull.Value;//分割条控件：分割方向垂直/水平
                dr[C_SPSASH] = row.GetValue(C_SPSASH) ?? DBNull.Value;//分割条控件：框格
                dr[C_OUTPUTSTYLE] = row.GetValue(C_OUTPUTSTYLE) ?? DBNull.Value;//十进制浮点：输出样式
                dr[C_SIGN] = row.GetValue(C_SIGN) ?? DBNull.Value;//带 +/- 符号
                dr[C_NOINPUTHISTORY] = row.GetValue(C_NOINPUTHISTORY) ?? DBNull.Value;//无 GUI 输入历史记录
                dr[C_AMPMENABLED] = row.GetValue(C_AMPMENABLED) ?? DBNull.Value;//AM/PM 启用时间格式
                dr[C_EXTEND] = row.GetValue(C_EXTEND) ?? DBNull.Value;//屏幕对象的修改状态
                dr[C_HIERARCHY] = row.GetValue(C_HIERARCHY) ?? DBNull.Value;//屏幕字段间的层次关系
                dr[C_ICON] = row.GetValue(C_ICON) ?? DBNull.Value;//图标标识（包括 @）
                dr[C_ICON_N] = row.GetValue(C_ICON_N) ?? DBNull.Value;//图标：名称
                dr[C_ICON_T] = row.GetValue(C_ICON_T) ?? DBNull.Value;//图标：描述
                dr[C_ICON_L] = row.GetValue(C_ICON_L) ?? DBNull.Value;//图标长度
                dr[C_ICON_Q] = row.GetValue(C_ICON_Q) ?? DBNull.Value;//图标：快速信息文本
                dr[C_ICON_B] = row.GetValue(C_ICON_B) ?? DBNull.Value;//图标：描述文本
                dr[C_ICON_X] = row.GetValue(C_ICON_X) ?? DBNull.Value;//图标: 带图标的输出元素
                dr[C_FLDP] = row.GetValue(C_FLDP) ?? DBNull.Value;//匹配码子键中的字段标识
                dr[C_FLDN] = row.GetValue(C_FLDN) ?? DBNull.Value;//匹配码子关键字中的字段名
                dr[C_PROG] = row.GetValue(C_PROG) ?? DBNull.Value;//修改：程序名称
                dr[C_DNUM] = row.GetValue(C_DNUM) ?? DBNull.Value;//修改：屏幕编号
                dr[C_PBO_F] = row.GetValue(C_PBO_F) ?? DBNull.Value;//修改：PBO 开头
                dr[C_PBO_L] = row.GetValue(C_PBO_L) ?? DBNull.Value;//修改：PBO 结尾
                dr[C_PAI_F] = row.GetValue(C_PAI_F) ?? DBNull.Value;//修改：PAI 开头
                dr[C_PAI_L] = row.GetValue(C_PAI_L) ?? DBNull.Value;//修改：PAI 结尾
                dr[C_EXTEXT] = row.GetValue(C_EXTEXT) ?? DBNull.Value;//修改：文本字段
                dr[C_EXENTRY] = row.GetValue(C_EXENTRY) ?? DBNull.Value;//修改：输入/输出字段
                dr[C_EXRADIO] = row.GetValue(C_EXRADIO) ?? DBNull.Value;//修改: 单选按钮
                dr[C_EXCHECK] = row.GetValue(C_EXCHECK) ?? DBNull.Value;//修改：复选框
                dr[C_EXPUSH] = row.GetValue(C_EXPUSH) ?? DBNull.Value;//修改: 按钮
                dr[C_EXFRAME] = row.GetValue(C_EXFRAME) ?? DBNull.Value;//修改: 框
                dr[C_EXTABCTRL] = row.GetValue(C_EXTABCTRL) ?? DBNull.Value;//修改：表控件
                dr[C_EXCUSTOM] = row.GetValue(C_EXCUSTOM) ?? DBNull.Value;//修改: 定制控制
                dr[C_EXTSTRCTRL] = row.GetValue(C_EXTSTRCTRL) ?? DBNull.Value;//修改：标签条控件
                dr[C_EXSUBSCR] = row.GetValue(C_EXSUBSCR) ?? DBNull.Value;//修改：子屏幕
                dr[C_EXSPLITTER] = row.GetValue(C_EXSPLITTER) ?? DBNull.Value;//修改：拆分器控件
                dr[C_EXSHOW] = row.GetValue(C_EXSHOW) ?? DBNull.Value;//修改：详细信息视图
                dr[C_MSG_LINE1] = row.GetValue(C_MSG_LINE1) ?? DBNull.Value;//对话框状态行
                dr[C_MSG_LINE2] = row.GetValue(C_MSG_LINE2) ?? DBNull.Value;//对话框状态行
                dr[C_PROPSHOW] = row.GetValue(C_PROPSHOW) ?? DBNull.Value;//属性包：转到属性列表
                dr[C_PROPNAME] = row.GetValue(C_PROPNAME) ?? DBNull.Value;//属性
                dr[C_PROPBOOL] = row.GetValue(C_PROPBOOL) ?? DBNull.Value;//属性包：布尔值
                dr[C_PROPSTRING] = row.GetValue(C_PROPSTRING) ?? DBNull.Value;//属性包：字符串值
                dt.Rows.Add(dr);
            }
            return dt;
        }// getScreenFieldDt

        public static List<CScreenField> getScreenFieldAsList(IRfcTable iScreenField)
        {
            List<CScreenField> _ScreenField_LIST = new List<CScreenField>();

            IRfcTable rfc_ScreenField = iScreenField;


            for (int i = 0; i < rfc_ScreenField.RowCount; i++)
            {
                var _ScreenField = new CScreenField();
                _ScreenField.name = rfc_ScreenField[i].GetString(C_NAME); // 屏幕元素的名称
                _ScreenField.dynnr = rfc_ScreenField[i].GetString(C_DYNNR); // 屏幕号码
                _ScreenField.line = rfc_ScreenField[i].GetDecimal(C_LINE); // 出现字段的屏幕上的行
                _ScreenField.coln = rfc_ScreenField[i].GetDecimal(C_COLN); // 在屏幕上显示字段的列
                _ScreenField.leng = rfc_ScreenField[i].GetDecimal(C_LENG); // 定义的屏幕字段长度
                _ScreenField.vleng = rfc_ScreenField[i].GetDecimal(C_VLENG); // 屏幕中可见的（定为可见的）字段长度
                _ScreenField.high = rfc_ScreenField[i].GetDecimal(C_HIGH); // 屏幕中元素的高度
                _ScreenField.type = rfc_ScreenField[i].GetString(C_TYPE); // 字段格式（ABAP 词典数据类型）
                _ScreenField.fein = rfc_ScreenField[i].GetString(C_FEIN); // 此字段的期望输入
                _ScreenField.fout = rfc_ScreenField[i].GetString(C_FOUT); // 此字段的期望输出
                _ScreenField.scroll = rfc_ScreenField[i].GetString(C_SCROLL); // 可滚动的输入/输出字段
                _ScreenField.dict = rfc_ScreenField[i].GetString(C_DICT); // ABAP 字典中的字段
                _ScreenField.dmod = rfc_ScreenField[i].GetString(C_DMOD); // 修改 ABAP 字典的字段
                _ScreenField.grp1 = rfc_ScreenField[i].GetString(C_GRP1); // 修改组 1
                _ScreenField.grp2 = rfc_ScreenField[i].GetString(C_GRP2); // 修改组 2
                _ScreenField.grp3 = rfc_ScreenField[i].GetString(C_GRP3); //   修改组3
                _ScreenField.grp4 = rfc_ScreenField[i].GetString(C_GRP4); //   修改组4
                _ScreenField.loop = rfc_ScreenField[i].GetDecimal(C_LOOP); // 循环计数
                _ScreenField.fobl = rfc_ScreenField[i].GetString(C_FOBL); // 字段中的条目
                _ScreenField.fstr = rfc_ScreenField[i].GetString(C_FSTR); // * 条目
                _ScreenField.fnrs = rfc_ScreenField[i].GetString(C_FNRS); // 未重置
                _ScreenField.fgks = rfc_ScreenField[i].GetString(C_FGKS); // 大/小写条目
                _ScreenField.ffix = rfc_ScreenField[i].GetString(C_FFIX); // 固定，带下划线的字符模板
                _ScreenField.fosb = rfc_ScreenField[i].GetString(C_FOSB); // 不用模板在 CHAR 字段中输入所有字符
                _ScreenField.ffky = rfc_ScreenField[i].GetString(C_FFKY); // 字典的外键检查为活动状态
                _ScreenField.fspa = rfc_ScreenField[i].GetString(C_FSPA); // SET 参数
                _ScreenField.fgpa = rfc_ScreenField[i].GetString(C_FGPA); // GET 参数
                _ScreenField.paid = rfc_ScreenField[i].GetString(C_PAID); // 参数ID SAP内存
                _ScreenField.ucnv = rfc_ScreenField[i].GetString(C_UCNV); // 转换出口
                _ScreenField.hell = rfc_ScreenField[i].GetString(C_HELL); // 亮度显示
                _ScreenField.unsi = rfc_ScreenField[i].GetString(C_UNSI); // 不可见显示
                _ScreenField.invr = rfc_ScreenField[i].GetString(C_INVR); // 显示反转视频
                _ScreenField.blin = rfc_ScreenField[i].GetString(C_BLIN); // 闪烁
                _ScreenField.ulin = rfc_ScreenField[i].GetString(C_ULIN); // 突出显示
                _ScreenField.colr = rfc_ScreenField[i].GetString(C_COLR); // 显示颜色1...7
                _ScreenField.fjus = rfc_ScreenField[i].GetString(C_FJUS); // 右对齐显示
                _ScreenField.fill = rfc_ScreenField[i].GetString(C_FILL); // 显示前导零
                _ScreenField.labelleft = rfc_ScreenField[i].GetString(C_LABELLEFT); // 作为左侧标签
                _ScreenField.labelright = rfc_ScreenField[i].GetString(C_LABELRIGHT); // 作为右侧标签
                _ScreenField.dblclick = rfc_ScreenField[i].GetString(C_DBLCLICK); // 响应双击
                _ScreenField.ltr = rfc_ScreenField[i].GetString(C_LTR); // 基本写方向已定义为 LTR（从左至右）
                _ScreenField.bidictrl = rfc_ScreenField[i].GetString(C_BIDICTRL); // ABAP 字典：不过滤双向格式字符
                _ScreenField.mtch = rfc_ScreenField[i].GetString(C_MTCH); // 搜索帮助
                _ScreenField.waer = rfc_ScreenField[i].GetString(C_WAER); // 参考字段
                _ScreenField.fcod = rfc_ScreenField[i].GetString(C_FCOD); // 用于按钮的功能码
                _ScreenField.ptype = rfc_ScreenField[i].GetString(C_PTYPE); // 按钮的功能码类型
                _ScreenField.ctmenuprog = rfc_ScreenField[i].GetString(C_CTMENUPROG); // 上下文菜单：程序名称
                _ScreenField.ctmenustat = rfc_ScreenField[i].GetString(C_CTMENUSTAT); // 上下文菜单：状态/菜单名
                _ScreenField.ctmenuonct = rfc_ScreenField[i].GetString(C_CTMENUONCT); // 上下文菜单：动态回调 ON_CTMENU_...
                _ScreenField.ctmenust = rfc_ScreenField[i].GetString(C_CTMENUST); // 上下文菜单：静态
                _ScreenField.ctmenudy = rfc_ScreenField[i].GetString(C_CTMENUDY); // 上下文菜单：动态 (ON_CTMENU_...)
                _ScreenField.ccname = rfc_ScreenField[i].GetString(C_CCNAME); // Control Composite：名称
                _ScreenField.ccdleft = rfc_ScreenField[i].GetString(C_CCDLEFT); // Control Composite：左停靠
                _ScreenField.ccdright = rfc_ScreenField[i].GetString(C_CCDRIGHT); // Control Composite：右停靠
                _ScreenField.ccdtop = rfc_ScreenField[i].GetString(C_CCDTOP); // Control Composite：上停靠
                _ScreenField.ccdbottom = rfc_ScreenField[i].GetString(C_CCDBOTTOM); // Control Composite：下停靠
                _ScreenField.ccdlen_l = rfc_ScreenField[i].GetInt(C_CCDLEN_L); // Control Composite：停靠控件的宽度
                _ScreenField.ccdlen_r = rfc_ScreenField[i].GetInt(C_CCDLEN_R); // Control Composite：停靠控件的宽度
                _ScreenField.ccdhig_t = rfc_ScreenField[i].GetInt(C_CCDHIG_T); // Control Composite：停靠控件的高度
                _ScreenField.ccdhig_b = rfc_ScreenField[i].GetInt(C_CCDHIG_B); // Control Composite：停靠控件的高度
                _ScreenField.ltyp = rfc_ScreenField[i].GetString(C_LTYP); // 循环：循环类型(固定的或可变的)
                _ScreenField.gtyp = rfc_ScreenField[i].GetString(C_GTYP); // 屏幕元素类型
                _ScreenField.fixf = rfc_ScreenField[i].GetString(C_FIXF); // 以固定字体代替比例字体
                _ScreenField.no3d = rfc_ScreenField[i].GetString(C_NO3D); // 输入/输出字段的二维显示
                _ScreenField.oout = rfc_ScreenField[i].GetString(C_OOUT); // 纯输出字段
                _ScreenField.win1 = rfc_ScreenField[i].GetString(C_WIN1); // 图形屏幕绘制器：全屏编辑器
                _ScreenField.win2 = rfc_ScreenField[i].GetString(C_WIN2); // 图形屏幕绘制器：字段属性
                _ScreenField.win3 = rfc_ScreenField[i].GetString(C_WIN3); // 图形屏幕绘制器：ABAP/4 字典/程序字段
                _ScreenField.stxt = rfc_ScreenField[i].GetString(C_STXT); // 屏幕元素的文本/模板
                _ScreenField.cmbtast = rfc_ScreenField[i].GetString(C_CMBTAST); // 可能条目按钮和可能条目的修改
                _ScreenField.cmbfoc = rfc_ScreenField[i].GetString(C_CMBFOC); // 可能条目的有效性
                _ScreenField.dropfrom = rfc_ScreenField[i].GetString(C_DROPFROM); // 输入帮助: 原始值
                _ScreenField.dropdown = rfc_ScreenField[i].GetString(C_DROPDOWN); // 下拉
                _ScreenField.fetchfld = rfc_ScreenField[i].GetString(C_FETCHFLD); // 取得表字段或程序字段 (一般)
                _ScreenField.rfcdest = rfc_ScreenField[i].GetString(C_RFCDEST); // 参考系统（RFC 目标）
                _ScreenField.schab = rfc_ScreenField[i].GetString(C_SCHAB); // 预选字典或程序字段的输入/输出字段
                _ScreenField.schlk = rfc_ScreenField[i].GetString(C_SCHLK); // 为词典字段预选短字段标签
                _ScreenField.schlm = rfc_ScreenField[i].GetString(C_SCHLM); // 为词典字段预选中字段标签
                _ScreenField.schll = rfc_ScreenField[i].GetString(C_SCHLL); // 为词典字段预选长字段标签
                _ScreenField.ueber = rfc_ScreenField[i].GetString(C_UEBER); // 为词典字段预选标题
                _ScreenField.schlno = rfc_ScreenField[i].GetString(C_SCHLNO); // 预选带有短文本 (无字段标签) 的词典字段
                _ScreenField.schabno = rfc_ScreenField[i].GetString(C_SCHABNO); // 词典或程序字段 I/O 模板无预选
                _ScreenField.textmod = rfc_ScreenField[i].GetString(C_TEXTMOD); // 预选：使用修正的词典文本
                _ScreenField.textorig = rfc_ScreenField[i].GetString(C_TEXTORIG); // 预选：像在词典中一样使用原始文本
                _ScreenField.dezusatz = rfc_ScreenField[i].GetString(C_DEZUSATZ); // 数据元素增补
                _ScreenField.tltrennhor = rfc_ScreenField[i].GetString(C_TLTRENNHOR); // 表控件：带水平分隔符
                _ScreenField.tltrennver = rfc_ScreenField[i].GetString(C_TLTRENNVER); // 表控件：带垂直分隔符
                _ScreenField.tlscrollh = rfc_ScreenField[i].GetString(C_TLSCROLLH); // 控件：水平滚动
                _ScreenField.tlscrollv = rfc_ScreenField[i].GetString(C_TLSCROLLV); // 控件：垂直滚动
                _ScreenField.tlscroll = rfc_ScreenField[i].GetString(C_TLSCROLL); // 控件：可滚动
                _ScreenField.tlselectzn = rfc_ScreenField[i].GetString(C_TLSELECTZN); // 表控制：无行选择
                _ScreenField.tlselectzs = rfc_ScreenField[i].GetString(C_TLSELECTZS); // 表控制：单行选择
                _ScreenField.tlselectzm = rfc_ScreenField[i].GetString(C_TLSELECTZM); // 表控制：多行选择
                _ScreenField.tlselectsn = rfc_ScreenField[i].GetString(C_TLSELECTSN); // 表控制：无列选择
                _ScreenField.tlselectss = rfc_ScreenField[i].GetString(C_TLSELECTSS); // 表控制：单列选择
                _ScreenField.tlselectsm = rfc_ScreenField[i].GetString(C_TLSELECTSM); // 表控制：多列选择
                _ScreenField.tlshowonly = rfc_ScreenField[i].GetString(C_TLSHOWONLY); // 表控件：仅显示
                _ScreenField.tlvarv = rfc_ScreenField[i].GetString(C_TLVARV); // 控制：垂直调整
                _ScreenField.tlvarvmin = rfc_ScreenField[i].GetDecimal(C_TLVARVMIN); // 控制：垂直调整中最少的行数
                _ScreenField.tlvarh = rfc_ScreenField[i].GetString(C_TLVARH); // 控制：水平调整
                _ScreenField.tlvarhmin = rfc_ScreenField[i].GetDecimal(C_TLVARHMIN); // 控制：水平调整中最少的列数
                _ScreenField.tlmark = rfc_ScreenField[i].GetString(C_TLMARK); // 表控制：选择列
                _ScreenField.tltitel = rfc_ScreenField[i].GetString(C_TLTITEL); // 表控制：带标题行
                _ScreenField.tlueber = rfc_ScreenField[i].GetString(C_TLUEBER); // 表控制：带列头
                _ScreenField.tlerfa = rfc_ScreenField[i].GetString(C_TLERFA); // 表控制：项表
                _ScreenField.tlausw = rfc_ScreenField[i].GetString(C_TLAUSW); // 表控制：选定行
                _ScreenField.tlconf = rfc_ScreenField[i].GetString(C_TLCONF); // 表控制：可配置性
                _ScreenField.tltext = rfc_ScreenField[i].GetString(C_TLTEXT); // 表控制：字段文本
                _ScreenField.tlentry = rfc_ScreenField[i].GetString(C_TLENTRY); // 表控制：项/模板字段
                _ScreenField.tlradiob = rfc_ScreenField[i].GetString(C_TLRADIOB); // 表控制：单选按钮
                _ScreenField.tlcheckb = rfc_ScreenField[i].GetString(C_TLCHECKB); // 表控制：复选框
                _ScreenField.tlpushb = rfc_ScreenField[i].GetString(C_TLPUSHB); // 表控制：按钮
                _ScreenField.tlnametyp = rfc_ScreenField[i].GetString(C_TLNAMETYP); //   Multi--目的文本通用
                _ScreenField.tlnamefld = rfc_ScreenField[i].GetString(C_TLNAMEFLD); // 屏幕元素的名称
                _ScreenField.tlnameueb = rfc_ScreenField[i].GetString(C_TLNAMEUEB); // 屏幕元素的名称
                _ScreenField.tlnamesel = rfc_ScreenField[i].GetString(C_TLNAMESEL); // 屏幕元素的名称
                _ScreenField.tlnametit = rfc_ScreenField[i].GetString(C_TLNAMETIT); // 屏幕元素的名称
                _ScreenField.tlfeldfix = rfc_ScreenField[i].GetString(C_TLFELDFIX); // 固定字段
                _ScreenField.tlfixanz = rfc_ScreenField[i].GetInt(C_TLFIXANZ); // 表控件：固定主导列数目
                _ScreenField.tlfeldnr = rfc_ScreenField[i].GetInt(C_TLFELDNR); // 列号
                _ScreenField.tlfeldnr00 = rfc_ScreenField[i].GetInt(C_TLFELDNR00); // 列号
                _ScreenField.tlfeldspbr = rfc_ScreenField[i].GetInt(C_TLFELDSPBR); // 列宽
                _ScreenField.spcell1 = rfc_ScreenField[i].GetString(C_SPCELL1); // 分割条单元格名称
                _ScreenField.spcell2 = rfc_ScreenField[i].GetString(C_SPCELL2); // 分割条单元格名称
                _ScreenField.spsplitthoriz = rfc_ScreenField[i].GetString(C_SPSPLITTHORIZ); // 分割条控件：分割方向垂直/水平
                _ScreenField.spsplittvert = rfc_ScreenField[i].GetString(C_SPSPLITTVERT); // 分割条控件：分割方向垂直/水平
                _ScreenField.spsash = rfc_ScreenField[i].GetInt(C_SPSASH); // 分割条控件：框格
                _ScreenField.outputstyle = rfc_ScreenField[i].GetInt(C_OUTPUTSTYLE); // 十进制浮点：输出样式
                _ScreenField.sign = rfc_ScreenField[i].GetString(C_SIGN); // 带 +/- 符号
                _ScreenField.noinputhistory = rfc_ScreenField[i].GetString(C_NOINPUTHISTORY); // 无 GUI 输入历史记录
                _ScreenField.ampmenabled = rfc_ScreenField[i].GetString(C_AMPMENABLED); // AM/PM 启用时间格式
                _ScreenField.extend = rfc_ScreenField[i].GetString(C_EXTEND); // 屏幕对象的修改状态
                _ScreenField.hierarchy = rfc_ScreenField[i].GetString(C_HIERARCHY); // 屏幕字段间的层次关系
                _ScreenField.icon = rfc_ScreenField[i].GetString(C_ICON); // 图标标识（包括 @）
                _ScreenField.icon_n = rfc_ScreenField[i].GetString(C_ICON_N); // 图标：名称
                _ScreenField.icon_t = rfc_ScreenField[i].GetString(C_ICON_T); // 图标：描述
                _ScreenField.icon_l = rfc_ScreenField[i].GetString(C_ICON_L); // 图标长度
                _ScreenField.icon_q = rfc_ScreenField[i].GetString(C_ICON_Q); // 图标：快速信息文本
                _ScreenField.icon_b = rfc_ScreenField[i].GetString(C_ICON_B); // 图标：描述文本
                _ScreenField.icon_x = rfc_ScreenField[i].GetString(C_ICON_X); // 图标: 带图标的输出元素
                _ScreenField.fldp = rfc_ScreenField[i].GetString(C_FLDP); // 匹配码子键中的字段标识
                _ScreenField.fldn = rfc_ScreenField[i].GetString(C_FLDN); // 匹配码子关键字中的字段名
                _ScreenField.prog = rfc_ScreenField[i].GetString(C_PROG); // 修改：程序名称
                _ScreenField.dnum = rfc_ScreenField[i].GetString(C_DNUM); // 修改：屏幕编号
                _ScreenField.pbo_f = rfc_ScreenField[i].GetString(C_PBO_F); // 修改：PBO 开头
                _ScreenField.pbo_l = rfc_ScreenField[i].GetString(C_PBO_L); // 修改：PBO 结尾
                _ScreenField.pai_f = rfc_ScreenField[i].GetString(C_PAI_F); // 修改：PAI 开头
                _ScreenField.pai_l = rfc_ScreenField[i].GetString(C_PAI_L); // 修改：PAI 结尾
                _ScreenField.extext = rfc_ScreenField[i].GetString(C_EXTEXT); // 修改：文本字段
                _ScreenField.exentry = rfc_ScreenField[i].GetString(C_EXENTRY); // 修改：输入/输出字段
                _ScreenField.exradio = rfc_ScreenField[i].GetString(C_EXRADIO); // 修改: 单选按钮
                _ScreenField.excheck = rfc_ScreenField[i].GetString(C_EXCHECK); // 修改：复选框
                _ScreenField.expush = rfc_ScreenField[i].GetString(C_EXPUSH); // 修改: 按钮
                _ScreenField.exframe = rfc_ScreenField[i].GetString(C_EXFRAME); // 修改: 框
                _ScreenField.extabctrl = rfc_ScreenField[i].GetString(C_EXTABCTRL); // 修改：表控件
                _ScreenField.excustom = rfc_ScreenField[i].GetString(C_EXCUSTOM); // 修改: 定制控制
                _ScreenField.extstrctrl = rfc_ScreenField[i].GetString(C_EXTSTRCTRL); // 修改：标签条控件
                _ScreenField.exsubscr = rfc_ScreenField[i].GetString(C_EXSUBSCR); // 修改：子屏幕
                _ScreenField.exsplitter = rfc_ScreenField[i].GetString(C_EXSPLITTER); // 修改：拆分器控件
                _ScreenField.exshow = rfc_ScreenField[i].GetString(C_EXSHOW); // 修改：详细信息视图
                _ScreenField.msg_line1 = rfc_ScreenField[i].GetString(C_MSG_LINE1); // 对话框状态行
                _ScreenField.msg_line2 = rfc_ScreenField[i].GetString(C_MSG_LINE2); // 对话框状态行
                _ScreenField.propshow = rfc_ScreenField[i].GetString(C_PROPSHOW); // 属性包：转到属性列表
                _ScreenField.propname = rfc_ScreenField[i].GetString(C_PROPNAME); // 属性
                _ScreenField.propbool = rfc_ScreenField[i].GetString(C_PROPBOOL); // 属性包：布尔值
                _ScreenField.propstring = rfc_ScreenField[i].GetString(C_PROPSTRING); // 属性包：字符串值
                _ScreenField_LIST.Add(_ScreenField);

            }

            return _ScreenField_LIST;
        }// getScreenFieldList


    }//class

}
