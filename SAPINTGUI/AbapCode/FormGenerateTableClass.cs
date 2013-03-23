using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NVelocity.App;
using NVelocity;
using System.Reflection;

namespace SAPINTCODE
{

    public partial class FormGenerateTableClass : Form
    {
        SAPINT.RFCTable.RFCTableInfo rfctable = new SAPINT.RFCTable.RFCTableInfo();

        // List<SAPINT.RFCTable.TableField> fieldList = new List<SAPINT.RFCTable.TableField>();

        public FormGenerateTableClass()
        {
            InitializeComponent();

            this.cbxSystemList.DataSource = SAPINT.SAPLogonConfigList.SystemNameList;
            this.textBoxTemplate.Text =
@"public class $rfctable.Name
{
#foreach($field in $rfctable.Fields)
	public $field.DOTNETTYPE $field.FIELDNAME {get;set;} // $field.FIELDTEXT
#end
}";

        }

        private void btnGenerateCode_Click(object sender, EventArgs e)
        {

            processTemplate();


        }

        private void processTemplate()
        {
            if (rfctable.Fields.Count ==0 )
            {
                MessageBox.Show("没有字段");
                return;
            }
            try
            {
                VelocityEngine ve = new VelocityEngine();
                ve.Init();
                VelocityContext ct = new VelocityContext();

               // AbapCode code = new AbapCode();

                ct.Put("rfctable", rfctable);
                System.IO.StringWriter vltWriter = new System.IO.StringWriter();
                ve.Evaluate(ct, vltWriter, null, this.textBoxTemplate.Text);
                this.textBoxResult.Text = vltWriter.GetStringBuilder().ToString();
                MessageBox.Show("处理成功");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                //throw;
            }
        }
        /// <summary>
        /// 从SAP系统中加载表的定义信息。
        /// </summary>
        private void GetTableDefinition()
        {
            try
            {
                rfctable.GetTableDefinition(cbxSystemList.Text, textBoxTableName.Text);
                rfctable.TransformDataType();
                rfctable.Fields.ForEach(row =>
                {
                    row.FIELDNAME = row.FIELDNAME.Replace("/", "_");
                });
                // fieldList =  SAPINT.RFCTable.RFCTable.GetTableDefinition(cbxSystemList.Text,textBoxTableName.Text);
                if (rfctable != null)
                {
                    if (rfctable.FieldCount > 0)
                    {
                        MessageBox.Show("读取成功");
                    }
                    else
                    {
                        MessageBox.Show("无可用字段");
                    }

                }
                else
                {
                    MessageBox.Show("无法读取表信息");
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);

            }

        }

        private void btnGetTableDefinitioin_Click(object sender, EventArgs e)
        {
            GetTableDefinition();
            this.dgvFieldList.DataSource = rfctable.Fields;
            this.dgvFieldList.AutoResizeColumns();
           
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SAPINTGUI.CDataGridViewUtils.SelectRows(dgvFieldList);
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            SAPINTGUI.CDataGridViewUtils.UnSelectRows(dgvFieldList);
        }
    }


    //sealed class TableField
    //{
    //    public string TABNAME { get; set; }   //表名
    //    public string FIELDNAME { get; set; }   //字段名
    //    public string LANGU { get; set; }   //语言代码
    //    public string POSITION { get; set; }   // 表格中区域的位置
    //    public string OFFSET { get; set; }   //工作区内域偏移
    //    public string DOMNAME { get; set; }   //定义域名
    //    public string ROLLNAME { get; set; }   //数据元素 (语义域)
    //    public string CHECKTABLE { get; set; }   //表名
    //    public string LENG { get; set; }   //长度（字符数）
    //    public string INTLEN { get; set; }   //以字节计的内部长度
    //    public string OUTPUTLEN { get; set; }   //输出长度
    //    public string DECIMALS { get; set; }   //小数点后的位数
    //    public string DATATYPE { get; set; }   //ABAP/4 字典: 屏幕绘制器的屏幕数据类型
    //    public string INTTYPE { get; set; }   //ABAP 数据类型(C,D,N,...)
    //    public string REFTABLE { get; set; }   //索引字段的表
    //    public string REFFIELD { get; set; }   //货币和数量字段的参考字段
    //    public string PRECFIELD { get; set; }   //包含表格的名称
    //    public string AUTHORID { get; set; }   //授权类别
    //    public string MEMORYID { get; set; }   //设置/获取参数标识
    //    public string LOGFLAG { get; set; }   // 写变化文档指示符
    //    public string MASK { get; set; }   //模板（未使用）
    //    public string MASKLEN { get; set; }   //模板长度（未使用）
    //    public string CONVEXIT { get; set; }   //转换例程
    //    public string HEADLEN { get; set; }   //表头的最大长度
    //    public string SCRLEN1 { get; set; }   //短字段标签的最大长度
    //    public string SCRLEN2 { get; set; }   //中等字段标签的最大长度
    //    public string SCRLEN3 { get; set; }   //长字段标签的最大长度
    //    public string FIELDTEXT { get; set; }   //描述 R/3 资源库对象的短文本
    //    public string REPTEXT { get; set; }   //标题
    //    public string SCRTEXT_S { get; set; }   //短字段标签
    //    public string SCRTEXT_M { get; set; }   //中字段标签
    //    public string SCRTEXT_L { get; set; }   //长字段标签
    //    public string KEYFLAG { get; set; }   //标识表格的关键字段
    //    public string LOWERCASE { get; set; }   //允许/不允许小写字母
    //    public string MAC { get; set; }   //如果搜索帮助附加到字段上，则进行标记
    //    public string GENKEY { get; set; }   //标记(X或空白)
    //    public string NOFORKEY { get; set; }   //标记(X或空白)
    //    public string VALEXI { get; set; }   //固定值存在
    //    public string NOAUTHCH { get; set; }   //标记(X或空白)
    //    public string SIGN { get; set; }   //数值域的符号标志
    //    public string DYNPFLD { get; set; }   //标记: 在屏幕上显示字段
    //    public string F4AVAILABL { get; set; }   //字段有输入帮助吗
    //    public string COMPTYPE { get; set; }   //DD：组件类型
    //    public string LFIELDNAME { get; set; }   //字段名
    //    public string LTRFLDDIS { get; set; }   //Basic write direction has been defined LTR (left-to-right)
    //    public string BIDICTRLC { get; set; }   //DD: No Filtering of BIDI Formatting Characters
    //    public string OUTPUTSTYLE { get; set; }   //DD: Output Style (Output Style) for Decfloat Types
    //    public string NOHISTORY { get; set; }   //DD: Flag for Deactivating Input History in Screen Field
    //    public string AMPMFORMAT { get; set; }   //DD: Indicator whether AM/PM time format is required

    //}

}
