using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAPINT.Gui.Functions
{
    public partial class FormSearchRfcFunction : ToolWindow
    {

        BindingSource bs = new BindingSource();

        public FormSearchRfcFunction()
        {
            InitializeComponent();
            this.cbxSapClientList.DataSource = ConfigFileTool.SAPGlobalSettings.GetSAPClientList();
            this.cbxSapClientList.Text = ConfigFileTool.SAPGlobalSettings.GetDefaultSapCient();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                bs.DataSource = SAPINT.Function.SAPFunction.SearchRfcFunctions(this.cbxSapClientList.Text, this.txtRfcFunctionName.Text, this.txtFuncGroup.Text);

                this.dataGridView1.DataSource = bs;
                this.dataGridView1.AutoResizeColumns();

                //this.bindingNavigator1.BindingSource = bs;

                this.txtRfcFunctionName.DataBindings.Clear();
                this.txtRfcFunctionText.DataBindings.Clear();
                this.txtRfcFunctionName.DataBindings.Add("Text", bs, "FUNCNAME");
                this.txtRfcFunctionText.DataBindings.Add("Text", bs, "STEXT");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
            
        }
    }
}
