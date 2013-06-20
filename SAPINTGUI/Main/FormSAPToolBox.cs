using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAPINT.Function.Meta;
using SAPINT.Function;
using SAPINT.Function.Json;
using SAPINT;
using SAPINT.Gui.Idocs;
using System.Threading;
using WeifenLuo.WinFormsUI.Docking;
using SAPINT.Gui.Functions;
using SAPINT.Gui.Table;
namespace SAPINT.Gui
{
    public partial class FormSAPToolBox : DockWindow
    {
        public FormSAPToolBox()
        {
            InitializeComponent();
            

        }
        private void button3_Click(object sender, EventArgs e)
        {
            //MetaValueList input = new MetaValueList();
            //input.FlatList.Add("TABNAME", "MARA");
            //MetaValueList output = new MetaValueList();
            //SAPINT.Function.Meta.SAPFunctionMeta.InvokeFunction("RET", "DDIF_FIELDINFO_GET", input, out output);
            //List<Dictionary<String,String>> Data = null;
            //output.TableList.TryGetValue("DFIES_TAB",out Data);
            //MessageBox.Show(Data.Count.ToString());
        }
        private void button4_Click(object sender, EventArgs e)
        {
            FormFunctionMetaEx formFunctionMeta = new FormFunctionMetaEx();
            formFunctionMeta.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FormReadTable formReadTable = new FormReadTable();
            formReadTable.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FormSAPQuery formSapQuery = new FormSAPQuery();
            formSapQuery.Show();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            FormGetTableMeta formGetTableMeta = new FormGetTableMeta();
            formGetTableMeta.Show();
        }
        private void btnSytemConfig_Click(object sender, EventArgs e)
        {
            //SAPINT.Controls.FormAddConfig config = new SAPINT.Controls.FormAddConfig();
            //config.ShowDialog();
            ConfigFileTool.FormSAPConfig config = new ConfigFileTool.FormSAPConfig();
            config.Show();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            FormFunctionMetaJson formForJson = new FormFunctionMetaJson();
            formForJson.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            
            FormCopyTable formCopyTable = new FormCopyTable();
            formCopyTable.Show();
        }

        private void btnCodeGeneration_Click(object sender, EventArgs e)
        {
            SAPINTCODE.FormGenerateTableClass formGenerateTable = new SAPINTCODE.FormGenerateTableClass();
            formGenerateTable.Show();
        }

        private void btnAbapCode_Click(object sender, EventArgs e)
        {
            SAPINTCODE.FormAbapCode2 form = new SAPINTCODE.FormAbapCode2();
            form.Show();
        }

        private void btnDataBase_Click(object sender, EventArgs e)
        {
            SAPINT.Gui.DataBase.FormSmallSql formdb = new DataBase.FormSmallSql();
            formdb.Show();
        }

        private void btnIdocUtil_Click(object sender, EventArgs e)
        {
            FormIdocUtil formIdocUtil = new FormIdocUtil();
            formIdocUtil.Show();
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {


        }
        public void startSever()
        {
 
        }

        private void btnIdocMeta_Click(object sender, EventArgs e)
        {
            Idocs.FormIdocMeta formidocmeta = new FormIdocMeta();
            formidocmeta.Show();
        }

        private void btnSaveDb_Click(object sender, EventArgs e)
        {
            SAPINT.Gui.DataBase.FormSaveDataTable formSaveDt = new SAPINT.Gui.DataBase.FormSaveDataTable();
            formSaveDt.Show();
        }

        private void btnDbUtil_Click(object sender, EventArgs e)
        {
            SAPINT.Gui.DataBase.FormSchemas formUtil = new DataBase.FormSchemas();
            formUtil.Show();
        }

        private void btnCopyIdocToLocalDb_Click(object sender, EventArgs e)
        {
            FormIdocCopy formCopyIdoc = new FormIdocCopy();
            formCopyIdoc.Show();
        }

        private void btnSearchRfcFunction_Click(object sender, EventArgs e)
        {
            Functions.FormSearchRfcFunction formsearchRfcFunction = new Functions.FormSearchRfcFunction();
            formsearchRfcFunction.Show();
        }

        private void btnCodeEditor_Click(object sender, EventArgs e)
        {
            CodeManager.FormCodeEditor frm = new CodeManager.FormCodeEditor();
            frm.Show();
        }

        private void btnCodeManager_Click(object sender, EventArgs e)
        {
            CodeManager.FormCodeManager frm = new CodeManager.FormCodeManager();
            frm.Show();
        }

        private void btnImportFile_Click(object sender, EventArgs e)
        {
            CodeManager.FormImportFile frm = new CodeManager.FormImportFile();
            frm.Show();
        }

        private void btnLoadSapProgram_Click(object sender, EventArgs e)
        {
            CodeManager.FormImporSapProgram frm = new CodeManager.FormImporSapProgram();
            frm.Show();
        }

        private void btnCodeSearch_Click(object sender, EventArgs e)
        {
            CodeManager.FormCodeSearch frm = new CodeManager.FormCodeSearch();
            frm.Show();
        }

        private void btnLinqTest_Click(object sender, EventArgs e)
        {
            FormLinqTable frm = new FormLinqTable();
            frm.Show();
        }
    }
}
