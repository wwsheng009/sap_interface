using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NVelocity;
using NVelocity.App;
using SAPINT.RFCTable;
using SAPINTDB.CodeManager;
using SAPINTGUI.Table;
using WeifenLuo.WinFormsUI.Docking;


namespace SAPINTGUI.CodeManager
{
    public partial class FormCodeGenerater : DockWindow
    {
        private FormCodeManager m_FormCodeManager = null;
        private FormTableField m_FormTableField = null;
        private List<RFCTableInfo> m_tableList = null;
        private Code _Code = null;
        public FormCodeGenerater()
        {
            InitializeComponent();
            dockPanel1.DocumentStyle = DocumentStyle.DockingWindow;
            m_FormTableField = new FormTableField();
            m_FormTableField.Show(dockPanel1, DockState.DockLeft);
            m_FormTableField.EventReadTableField += m_FormTableField_EventReadTableField;
            m_FormCodeManager = new FormCodeManager();
            m_FormCodeManager.Show(dockPanel1, DockState.DockLeft);
        }

        void m_FormTableField_EventReadTableField(FormTableField FormtableField)
        {
            m_tableList = FormtableField.TableList;
            //throw new NotImplementedException();
        }

        private void codeManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_FormCodeManager == null)
            {
                m_FormCodeManager = new FormCodeManager();
            }
            if (m_FormCodeManager.IsDisposed)
            {
                m_FormCodeManager = new FormCodeManager();
            }

            m_FormCodeManager.Show(dockPanel1, DockState.DockLeft);
        }

        private void tableFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_FormTableField == null)
            {
                m_FormTableField = new FormTableField();
            }
            if (m_FormTableField.IsDisposed)
            {
                m_FormTableField = new FormTableField();
            }
            m_FormTableField.Show(dockPanel1, DockState.DockLeft);
        }
        private void GenerateCode()
        {
            try
            {
                if (this.m_FormTableField == null)
                {
                    MessageBox.Show("没有选中的字段");
                    return;
                }
                if (this.m_FormCodeManager == null)
                {
                    MessageBox.Show("没有打开的模板");
                    return;
                }
                if (this.m_FormTableField.TableList == null)
                {
                    MessageBox.Show("没有选中的字段");
                    return;
                }
                if (this.m_FormTableField.TableList.Count == 0)
                {
                    MessageBox.Show("没有选中的字段");
                    return;
                }
                if (this.m_FormCodeManager.SelectedTree == null)
                {
                    MessageBox.Show("请先选中一个文件夹");
                    return;
                }
                if (this.m_FormCodeManager.TemplateCode == null)
                {
                    MessageBox.Show("请先锁定模板");
                    return;
                }

                VelocityEngine ve = new VelocityEngine();
                ve.Init();
                VelocityContext ct = new VelocityContext();

                ct.Put("tables", this.m_FormTableField.TableList);
                System.IO.StringWriter vltWriter = new System.IO.StringWriter();

                string template = string.Empty;
                template = m_FormCodeManager.TemplateCode.Content;
                ve.Evaluate(ct, vltWriter, null, template);


                String result = string.Empty;
                result = vltWriter.GetStringBuilder().ToString();

                _Code = new Code();
                _Code.Content = result;
                _Code.Title = m_FormCodeManager.TemplateCode.Title + "_NEW*";
                m_FormCodeManager.AddNewCodeToSelectedCodeTree(_Code, true);
                // newCode.TreeId = m_FormCodeManager.SelectedTree.Id;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        private void generateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateCode();
        }

        private void excuteAbapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_FormTableField == null)
            {
                MessageBox.Show("没有选中的字段");
                return;
            }
            if (this.m_FormCodeManager == null)
            {
                MessageBox.Show("没有打开的模板");
                return;
            }
            if (this.m_FormCodeManager.AbapRunCode == null)
            {
                MessageBox.Show("请先锁定运行代码");
                return;
            }
            var code1 = this.m_FormCodeManager.AbapRunCode;

            try
            {
                
                var str_system = this.m_FormTableField.SystemName.Trim().ToUpper();

                if (string.IsNullOrEmpty(str_system))
                {
                    MessageBox.Show("无法确定SAP系统!");
                    return;
                }
                var string_reslut = ExcuteAbapCode(code1.Content, str_system);
                if (!string.IsNullOrEmpty(string_reslut))
                {
                    var result = new Code();
                    result.Content = string_reslut;
                    result.Title = code1.Title + "_Result*";
                    m_FormCodeManager.AddNewCodeToSelectedCodeTree(result, true);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }
        private string ExcuteAbapCode(String code, String sapSystem)
        {

            SAPINT.Utils.ABAPCode abap = new SAPINT.Utils.ABAPCode(sapSystem);
            var result = string.Empty;
            try
            {
                result = abap.InstallAndRun(code);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            return result;
        }
    }
}
