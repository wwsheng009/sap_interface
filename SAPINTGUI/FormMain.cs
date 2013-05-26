using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAPINTCODE;
using SAPINTGUI.CodeManager;
using SAPINTGUI.Functions;
using SAPINTGUI.Table;
using WeifenLuo.WinFormsUI.Docking;
namespace SAPINTGUI
{
    public partial class FormMain : Form
    {
        private bool m_bSaveLayout = true;
        private DeserializeDockContent m_deserializeDockContent;
        private FormSAPToolBox m_formSAPToolBox = null;
        private FormFunctionMetaEx m_formFunctionMetaEx = null;
        private FormFunctionMetaJson m_formFunctionMetaJson = null;
        private FormSearchRfcFunction m_formSearchRfcFunction = null;
        private FormReadTable m_formReadTable = null;
        private FormGetTableMeta m_formGetTableMeta = null;
        private FormSAPQuery m_FormSAPQuery = null;
        private FormAbapCode2 m_FormAbapCode2 = null;
        private FormCodeEditor m_FormCodeEditor = null;
        private FormTableField m_FormTableField = null;
        private FormCodeManager m_FormCodeManager = null;
        private FormCodeGenerater m_FormCodeGenerater = null;

        public FormMain()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            CreateStandardControls();

            m_deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);

        }

        private void CreateStandardControls()
        {
            //m_solutionExplorer = new DummySolutionExplorer();
            //m_propertyWindow = new DummyPropertyWindow();
            //m_toolbox = new DummyToolbox();
            //m_outputWindow = new DummyOutputWindow();
            //m_taskList = new DummyTaskList();
            //  m_formSAPToolBox = new FormSAPToolBox();
            // m_formFunctionMetaEx = new FormFunctionMetaEx();
            // m_formSearchRfcFunction = new FormSearchRfcFunction();
        }
        private IDockContent GetContentFromPersistString(string persistString)
        {
            if (persistString == typeof(FormSAPToolBox).ToString())
                return m_formSAPToolBox;
            else
                return null;
        }
        private IDockContent FindDocument(string text)
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                    if (form.Text == text)
                        return form as IDockContent;

                return null;
            }
            else
            {
                foreach (IDockContent content in dockPanel.Documents)
                    if (content.DockHandler.TabText == text)
                        return content;

                return null;
            }
        }

        private void CloseAllDocuments()
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                    form.Close();
            }
            else
            {
                for (int index = dockPanel.Contents.Count - 1; index >= 0; index--)
                {
                    if (dockPanel.Contents[index] is IDockContent)
                    {
                        IDockContent content = (IDockContent)dockPanel.Contents[index];
                        content.DockHandler.Close();
                    }
                }
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // m_formSAPToolBox.Show(dockPanel1);
        }

        private void menuItemFile_Popup(object sender, EventArgs e)
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                menuItemClose.Enabled = menuItemCloseAll.Enabled = (ActiveMdiChild != null);
            }
            else
            {
                menuItemClose.Enabled = (dockPanel.ActiveDocument != null);
                menuItemCloseAll.Enabled = (dockPanel.DocumentsCount > 0);
            }
        }

        private void menuItemClose_Click(object sender, EventArgs e)
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
                ActiveMdiChild.Close();
            else if (dockPanel.ActiveDocument != null)
                dockPanel.ActiveDocument.DockHandler.Close();
        }

        private void menuItemCloseAll_Click(object sender, EventArgs e)
        {
            CloseAllDocuments();
        }

        private void MenuItemNewAbapDoc_Click(object sender, EventArgs e)
        {
            var abapDoc = CreateAbapDoc();
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                abapDoc.MdiParent = this;
                abapDoc.Show();
            }
            else
                abapDoc.Show(dockPanel);
        }

        private FormAbapDoc CreateAbapDoc()
        {
            var abapDoc = new FormAbapDoc();

            return abapDoc;
        }

        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.InitialDirectory = Application.ExecutablePath;
            openFile.Filter = "rtf files (*.rtf)|*.rtf|txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string fullName = openFile.FileName;
                string fileName = Path.GetFileName(fullName);

                if (FindDocument(fileName) != null)
                {
                    MessageBox.Show("The document: " + fileName + " has already opened!");
                    return;
                }

                FormAbapDoc abapDoc = new FormAbapDoc();
                abapDoc.Text = fileName;
                if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
                {
                    abapDoc.MdiParent = this;
                    abapDoc.Show();
                }
                else
                    abapDoc.Show(dockPanel);
                try
                {
                    abapDoc.OpenFile(fullName);
                    // abapDoc.FileName = fullName;
                }
                catch (Exception exception)
                {
                    abapDoc.Close();
                    MessageBox.Show(exception.Message);
                }

            }
        }

        private void toolBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_formSAPToolBox == null)
            {
                m_formSAPToolBox = new FormSAPToolBox();
            }
            if (m_formSAPToolBox.IsDisposed)
            {
                m_formSAPToolBox = new FormSAPToolBox();
            }
            m_formSAPToolBox.Show(dockPanel);
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

            m_formFunctionMetaEx = new FormFunctionMetaEx();
            m_formFunctionMetaEx.Show(dockPanel);
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_formSearchRfcFunction == null)
            {
                m_formSearchRfcFunction = new FormSearchRfcFunction();
            }
            if (m_formSearchRfcFunction.IsDisposed)
            {
                m_formSearchRfcFunction = new FormSearchRfcFunction();
            }
            m_formSearchRfcFunction.Show(dockPanel, DockState.DockLeft);
        }

        private void readTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_formReadTable = new FormReadTable();
            m_formReadTable.Show(dockPanel);

        }

        private void tableMetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_formGetTableMeta = new FormGetTableMeta();
            m_formGetTableMeta.Show(dockPanel);
        }

        private void queryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_FormSAPQuery = new FormSAPQuery();
            m_FormSAPQuery.Show(dockPanel);
        }

        private void jsonFunctionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_formFunctionMetaJson = new FormFunctionMetaJson();
            m_formFunctionMetaJson.Show(dockPanel);
        }

        private void codeEditorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            m_FormCodeEditor = new FormCodeEditor();
            m_FormCodeEditor.Show(dockPanel);
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
            m_FormCodeManager.Show(dockPanel, DockState.DockLeft);

        }

        private void fieldsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_FormTableField == null)
            {
                m_FormTableField = new FormTableField();
            }
            if (m_FormTableField.IsDisposed)
            {
                m_FormTableField = new FormTableField();
            }
            m_FormTableField.Show(dockPanel, DockState.DockLeft);

        }

        private void codeGeneraterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_FormCodeGenerater = new FormCodeGenerater();
            m_FormCodeGenerater.Show(dockPanel);
        }

        private void abapCode2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_FormAbapCode2 = new FormAbapCode2();
            m_FormAbapCode2.Show(dockPanel);
        }

        private void menuItemCloseAllButThisOne_Click(object sender, EventArgs e)
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                Form activeMdi = ActiveMdiChild;
                foreach (Form form in MdiChildren)
                {
                    if (form != activeMdi)
                        form.Close();
                }
            }
            else
            {
                foreach (IDockContent document in dockPanel.DocumentsToArray())
                {
                    if (!document.DockHandler.IsActivated)
                        document.DockHandler.Close();
                }
            }
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void exitWithoutSavingLayout_Click(object sender, EventArgs e)
        {
            m_bSaveLayout = false;
            Close();
            m_bSaveLayout = true;
        }

        private void toolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolBar.Visible = toolBarToolStripMenuItem.Checked = !toolBarToolStripMenuItem.Checked;
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusBar.Visible = statusBarToolStripMenuItem.Checked = !statusBarToolStripMenuItem.Checked;
        }

        private void fieldsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            m_FormTableField = new FormTableField();
            m_FormTableField.Show(dockPanel);
        }


    }
}
