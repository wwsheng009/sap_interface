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
using SAPINT.Gui;

namespace SAPINTCODE
{

    public partial class FormGenerateTableClass : DockWindow
    {
        SAPINT.RFCTable.SAPTableInfo rfctable = new SAPINT.RFCTable.SAPTableInfo();

        // List<SAPINT.RFCTable.TableField> fieldList = new List<SAPINT.RFCTable.TableField>();

        public FormGenerateTableClass()
        {
            InitializeComponent();
            SAPINT.Gui.CDataGridViewUtils.CopyPasteDataGridView(dgvFieldList);

            this.cbxSystemList.DataSource = SAPINT.SAPLogonConfigList.SystemNameList;
            this.textBoxTemplate.Document.Text =
@"public class $rfctable.Name
{
#foreach($field in $rfctable.Fields)
#if(true == $field.selected)
	public $field.DOTNETTYPE $field.FIELDNAME {get;set;} // $field.FIELDTEXT
#end
#end
}";
            Alsing.SourceCode.SyntaxDefinition sl = new Alsing.SourceCode.SyntaxDefinitionLoader().Load("SyntaxFiles\\CSharp.syn");
            this.textBoxTemplate.Document.Parser.Init(sl);
            this.textBoxResult.Document.Parser.Init(sl);
        }



        private void btnGenerateCode_Click(object sender, EventArgs e)
        {

            processTemplate();


        }

        private void processTemplate()
        {
            if (rfctable.Fields.Count == 0)
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
                ve.Evaluate(ct, vltWriter, null, this.textBoxTemplate.Document.Text);
                this.textBoxResult.Document.Text = vltWriter.GetStringBuilder().ToString();
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
                    if (rfctable.FieldsCount > 0)
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
            SAPINT.Gui.CDataGridViewUtils.SelectRows(dgvFieldList);
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            SAPINT.Gui.CDataGridViewUtils.UnSelectRows(dgvFieldList);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2Collapsed = !this.splitContainer1.Panel2Collapsed;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel1Collapsed = !this.splitContainer1.Panel1Collapsed;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.splitContainer2.Panel1Collapsed = !this.splitContainer2.Panel1Collapsed;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.splitContainer2.Panel2Collapsed = !this.splitContainer2.Panel2Collapsed;
        }
    }
}
