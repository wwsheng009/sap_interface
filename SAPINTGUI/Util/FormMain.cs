using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAPINT.Utils;
using SAPINTCODE;
using SAPINT.Gui.CodeManager;
using SAPINT.Gui.DataBase;
using SAPINT.Gui.Functions;
using SAPINT.Gui.Http;
using SAPINT.Gui.Idocs;
using SAPINT.Gui.Main;
using SAPINT.Gui.Table;
using WeifenLuo.WinFormsUI.Docking;
namespace SAPINT.Gui
{
    public partial class FormMain : Form
    {
        private bool m_bSaveLayout = true;
        private DeserializeDockContent m_deserializeDockContent;
        private FormSAPToolBox m_formSAPToolBox = null;

        //*
        private FormFunctionMetaEx m_formFunctionMetaEx = null;
        private FormFunctionMetaJson m_formFunctionMetaJson = null;
        private FormSearchRfcFunction m_formSearchRfcFunction = null;
        //*
        private FormAbapCode2 m_FormAbapCode2 = null;
        private FormCodeEditor m_FormCodeEditor = null;
        //*
        private FormCodeManager m_FormCodeManager = null;
        private FormCodeManagerListView m_FormCodeManagerListView = null;
        private FormCodeGenerater m_FormCodeGenerater = null;

        //*
        private FormSmallSql m_FormSmallSql = null;
        private FormSchemas m_FormSchemas = null;
        //*
        private FormReadTable m_formReadTable = null;
        private FormGetTableMeta m_formGetTableMeta = null;
        private FormSAPQuery m_FormSAPQuery = null;
        private FormTableField m_FormTableField = null;
        private FormTableRead m_FormTableRead = null;
        private FormTableReadMeta m_FormTableReadMeta = null;
        private FormSAPDataTable m_FormSAPDataTable = null;

        //*
        private FormIdocCopy m_FormIdocCopy = null;
        private FormIdocMeta m_FormIdocMeta = null;
        private FormIdocUtil m_FormIdocUtil = null;
        private FormIdocCreate m_FormIdocCreate = null;


        private FormLog m_FormLog = null;


        public FormMain()
        {
            InitializeComponent();
            this.Shown += FormMain_Shown;
            this.WindowState = FormWindowState.Maximized;
            CreateStandardControls();

            m_deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);

        }

        void FormMain_Shown(object sender, EventArgs e)
        {
            this.toolBar.Visible = false;
            toolBarToolStripMenuItem.Checked = false;
        }

        void m_FormTableRead_EventMessage(string message)
        {
            if (dockPanel.InvokeRequired)
            {
                this.Invoke(new DelegateMessage(m_FormTableRead_EventMessage), new object[] { message });
            }
            else
            {
                var m = DateTime.Now.ToLocalTime() + "==>" + message + "\r\n";
                if (m_FormLog == null)
                {
                    ShowLogWindow();
                }
                if (m_FormTableRead.IsDisposed)
                {
                    ShowLogWindow();
                }
                m_FormLog.Show(dockPanel, DockState.DockBottom);
                m_FormLog.AppendLogText(m);

            }
        }
        void m_FormTableReadMeta_EventTableReadMeta(FormTableReadMeta dataTableInfo)
        {
            if (dockPanel.InvokeRequired)
            {
                this.Invoke(new DelegateTableReadMeta(m_FormTableReadMeta_EventTableReadMeta), new object[] { dataTableInfo });
            }
            else
            {
                m_FormSAPDataTable = new FormSAPDataTable();
                m_FormSAPDataTable.DataTable = dataTableInfo.DtMetaList;
                m_FormSAPDataTable.TableName = dataTableInfo.TableName;
                m_FormSAPDataTable.SystemName = dataTableInfo.SystemName;
                m_FormSAPDataTable.DockHandler.Show(this.dockPanel, DockState.Document);
            }
            //throw new NotImplementedException();
        }
        void m_FormTableRead_EventGetTable(FormTableRead sender, DataTable resultdt)
        {
            if (resultdt == null)
            {
                return;
            }
            if (dockPanel.InvokeRequired)
            {
                this.Invoke(new DelegateReadSAPTable(m_FormTableRead_EventGetTable), new object[] { sender, resultdt });
            }
            else
            {
                var localdt = resultdt;
                m_FormSAPDataTable = new FormSAPDataTable();
                m_FormSAPDataTable.DataTable = localdt;
                m_FormSAPDataTable.TableName = sender.TableName;
                m_FormSAPDataTable.SystemName = sender.SystemName;
                m_FormSAPDataTable.DockHandler.Show(this.dockPanel, DockState.Document);

                ShowLogWindow();

            }
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
            //var abapDoc = CreateAbapDoc();
            //if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            //{
            //    abapDoc.MdiParent = this;
            //    abapDoc.Show();
            //}
            //else
            //    abapDoc.Show(dockPanel);

            m_FormCodeEditor = new FormCodeEditor();
            m_FormCodeEditor.Show(dockPanel);

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
            //m_FormCodeEditor = new FormCodeEditor();
            //m_FormCodeEditor.Show(dockPanel);
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

            if (m_FormCodeGenerater == null)
            {
                m_FormCodeGenerater = new FormCodeGenerater();

            }
            if (m_FormCodeGenerater.IsDisposed)
            {
                m_FormCodeGenerater = new FormCodeGenerater();

            }
            m_FormCodeGenerater.Show(dockPanel);


            //m_FormCodeGenerater = new FormCodeGenerater();
            //m_FormCodeGenerater.Show(dockPanel);
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

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMain newWindow = new FormMain();
            newWindow.Text = newWindow.Text + " - New";
            newWindow.Show();
        }

        private void smallSqlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_FormSmallSql = new FormSmallSql();
            m_FormSmallSql.Show(dockPanel);
        }

        private void schemasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (m_FormSchemas == null)
            {
                m_FormSchemas = new FormSchemas();
            }
            if (m_FormSchemas.IsDisposed)
            {
                m_FormSchemas = new FormSchemas();
            }
            m_FormSchemas.Show(dockPanel, DockState.DockRight);
        }

        private void importFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormImportFile m_FormImportFile = new FormImportFile();
            m_FormImportFile.Show(dockPanel);
        }

        private void importSAPPRGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormImportSapProgram m_FormImporSapProgram = new FormImportSapProgram();
            m_FormImporSapProgram.Show(dockPanel);
        }

        private void codeManager2ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (m_FormCodeManagerListView == null)
            {
                m_FormCodeManagerListView = new FormCodeManagerListView();
            }
            if (m_FormCodeManagerListView.IsDisposed)
            {
                m_FormCodeManagerListView = new FormCodeManagerListView();
            }
            m_FormCodeManagerListView.Show(dockPanel, DockState.DockLeft);
        }

        private void tableReadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_FormTableRead == null)
            {
                m_FormTableRead = new FormTableRead();
                m_FormTableRead.EventGetTable += m_FormTableRead_EventGetTable;
                m_FormTableRead.EventMessage += m_FormTableRead_EventMessage;
            }
            if (m_FormTableRead.IsDisposed)
            {
                m_FormTableRead = new FormTableRead();
                m_FormTableRead.EventGetTable += m_FormTableRead_EventGetTable;
                m_FormTableRead.EventMessage += m_FormTableRead_EventMessage;
            }
            m_FormTableRead.Show(dockPanel, DockState.DockLeft);

        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowLogWindow();
        }
        private void ShowLogWindow()
        {
            if (m_FormLog == null)
            {
                m_FormLog = new FormLog();

            }
            if (m_FormLog.IsDisposed)
            {
                m_FormLog = new FormLog();
            }
            m_FormLog.Show(dockPanel, DockState.DockBottomAutoHide);
        }

        private void tableReadMetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_FormTableReadMeta == null)
            {
                m_FormTableReadMeta = new FormTableReadMeta();
                m_FormTableReadMeta.EventTableReadMeta += m_FormTableReadMeta_EventTableReadMeta;
            }
            if (m_FormTableReadMeta.IsDisposed)
            {
                m_FormTableReadMeta = new FormTableReadMeta();
                m_FormTableReadMeta.EventTableReadMeta += m_FormTableReadMeta_EventTableReadMeta;
            }
            m_FormTableReadMeta.Show(dockPanel, DockState.DockLeft);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void IdocCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_FormIdocCopy = new FormIdocCopy();
            m_FormIdocCopy.Show(dockPanel);
        }

        private void IdocMetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_FormIdocMeta = new FormIdocMeta();
            m_FormIdocMeta.Show(dockPanel);
        }

        private void IdocUtilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_FormIdocUtil = new FormIdocUtil();
            m_FormIdocUtil.Show(dockPanel);
        }

        private void test1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRestClient form = new FormRestClient();
            form.Show(dockPanel);
        }

        private void IdocCreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_FormIdocCreate = new FormIdocCreate();
            m_FormIdocCreate.Show(dockPanel);
        }

        private void md5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var m_FormMd5Caculator = new FormMd5Caculator();
            m_FormMd5Caculator.Show(dockPanel);
        }




    }
}
