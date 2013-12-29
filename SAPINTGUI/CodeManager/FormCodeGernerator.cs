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
using SAPINT.Gui.Table;
using WeifenLuo.WinFormsUI.Docking;


namespace SAPINT.Gui.CodeManager
{
    public partial class FormCodeGernerator : DockWindow
    {
        private FormCodeManager m_FormCodeManager = null;
        private FormTableField m_FormTableField = null;
        private List<SAPTableInfo> m_tableList = null;
        // private Code _Code = null;
        public FormCodeGernerator()
        {
            InitializeComponent();
            this.Text = "代码生成器";

            dockPanel1.DocumentStyle = DocumentStyle.DockingWindow;
            m_FormTableField = new FormTableField();
            m_FormTableField.Show(dockPanel1, DockState.DockLeft);
            m_FormTableField.EventReadTableField += m_FormTableField_EventReadTableField;
            m_FormCodeManager = new FormCodeManager();
            m_FormCodeManager.Show(dockPanel1, DockState.DockLeft);

            m_FormCodeManager.EventCodeManagerChange += m_FormCodeManager_EventCodeManagerChange;

            this.toolStripStatusLabel1.Text = "临时文件夹:";
            this.toolStripStatusLabel2.Text = "代码模板:";
            this.toolStripStatusLabel3.Text = "临时ABAP代码:";
            if (m_FormCodeManager.TempFolder != null)
            {
                this.toolStripStatusLabel1.Text = "临时文件夹:" + m_FormCodeManager.TempFolder.Text;
            }

        }

        void m_FormCodeManager_EventCodeManagerChange(object sender, EventArgs e)
        {
            if (sender == null)
            {
                return;
            }
            m_FormCodeManager = sender as FormCodeManager;
            if (m_FormCodeManager.TempFolder != null)
            {
                this.toolStripStatusLabel1.Text = "临时文件夹:" + m_FormCodeManager.TempFolder.Text;
            }
            if (m_FormCodeManager.TemplateCode != null)
            {
                this.toolStripStatusLabel2.Text = "代码模板:" + m_FormCodeManager.TemplateCode.Title;
            }
            if (m_FormCodeManager.TempAbapRunCode != null)
            {
                this.toolStripStatusLabel3.Text = "临时ABAP代码:" + m_FormCodeManager.TempAbapRunCode.Title;
            }

        }

        void m_FormTableField_EventReadTableField(FormTableField FormtableField)
        {
            m_tableList = FormtableField.TableList;
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
        private Boolean checkBeforeGernerate()
        {
            if (this.m_FormTableField == null)
            {
                MessageBox.Show("没有选中的字段");
                return false;
            }
            if (this.m_FormCodeManager == null)
            {
                MessageBox.Show("没有打开的模板");
                return false;
            }
            if (this.m_FormTableField.TableList == null)
            {
                MessageBox.Show("没有选中的字段");
                return false;
            }
            if (this.m_FormTableField.TableList.Count == 0)
            {
                MessageBox.Show("没有选中的字段");
                return false;
            }
            if (this.m_FormCodeManager.TempFolder == null)
            {
                MessageBox.Show("请先选中一个文件夹");
                return false;
            }
            if (this.m_FormCodeManager.TemplateCode == null)
            {
                MessageBox.Show("请先锁定模板");
                return false;
            }
            return true;

        }
        private void GenerateCode()
        {
            if (checkBeforeGernerate() == false)
            {
                return;
            }
            try
            {


                VelocityEngine ve = new VelocityEngine();
                ve.Init();
                VelocityContext ct = new VelocityContext();

                ct.Put("tables", this.m_FormTableField.TableList);
                System.IO.StringWriter vltWriter = new System.IO.StringWriter();

                string template = string.Empty;
                var _Code = m_FormCodeManager.GetLatestCode(m_FormCodeManager.TemplateCode);
                template = _Code.Content;
                ve.Evaluate(ct, vltWriter, null, template);

                String result = string.Empty;
                result = vltWriter.GetStringBuilder().ToString();

                var _newCode = new Code();
                _newCode.Content = result;
                _newCode.Category = _Code.Category;
                _newCode.Title = m_FormCodeManager.TemplateCode.Title + "_NEW*";
                m_FormCodeManager.AddNewCodeToTempFolder(_newCode, true);
                // newCode.TreeId = m_FormCodeManager.SelectedTree.Id;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
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
            if (this.m_FormCodeManager.TempAbapRunCode == null)
            {
                MessageBox.Show("请先锁定运行代码");
                return;
            }
            var code1 = this.m_FormCodeManager.TempAbapRunCode;

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
                    m_FormCodeManager.AddNewCodeToTempFolder(result, true);
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

        private void aLVGerneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (checkBeforeGernerate() == false)
            //{
            //    return;
            //}

            FormAlvGernerator alvGernerator = new FormAlvGernerator();
            alvGernerator.setTableList(this.m_FormTableField.TableList);
            alvGernerator.setFormCodeManager(this.m_FormCodeManager);
            alvGernerator.Show();

        }

        private void directGerneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateCode();
        }

        private void screenGerneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormScreenGernerator screenGerneraoter = new FormScreenGernerator();
            screenGerneraoter.setFormCodeManager(this.m_FormCodeManager);
            screenGerneraoter.Show();
        }
    }
}
