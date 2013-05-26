using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAPINT.Function.Json;
namespace SAPINTGUI.Functions
{
    public partial class FormFunctionMetaJson : DockWindow
    {
        string _funcName = "";  //当前的函数名
        private string _systemName;//连接的SAP系统的配置名称
        public FormFunctionMetaJson()
        {
            InitializeComponent();
        }
        private bool check()
        {
            this._systemName = this.cbx_SystemList.Text.ToUpper().Trim();
            this._funcName = this.txtFunctionName.Text.Trim().ToUpper();
            if (string.IsNullOrEmpty(_systemName))
            {
                MessageBox.Show("请选择系统");
                return false;
            }
            if (string.IsNullOrEmpty(this._funcName))
            {
                MessageBox.Show("请指定表名");
                return false;
            }
            return true;
        }
        //从服务器加载函数的具体信息
        private void LoadFunctionMetaData()
        {
            if (!check())
            {
                return;
            }
            try
            {
                string output = SAPFunctionJson2.GetFuncMeta(_systemName, _funcName);
                txtFuncMeta.Text = output;
                MessageBox.Show("运行完成！");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            LoadFunctionMetaData();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!check())
            {
                return;
            }
            try
            {
                String input = txtInput.Text;
                String output = SAPFunctionJson2.InvokeFunctionFromJson(_systemName, _funcName, input);
                txtOutput.Text = output;
                MessageBox.Show("运行完成！");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
