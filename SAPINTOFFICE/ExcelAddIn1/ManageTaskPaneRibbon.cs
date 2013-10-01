using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using SAPINT;
using SAPINT.Controls;
using Microsoft.Office.Tools;
//using AbapCodeGeneration;

namespace ExcelAddIn1
{
    public partial class ManageTaskPaneRibbon
    {
        //读取SAP查询控件
        private SAPQueryControl _SAPQueryControl;
        private CustomTaskPane _SapQueryPane;

        //读取SAP表数据控件
        private ReadTableControl _ReadTableControl;
        private CustomTaskPane _ReaTablePane;

        //读取SAP表或结构的信息控件
        private GetTableMetaControl _GetTableMetaControl;
        private CustomTaskPane _GetTableMetaPane;

        private void SAPINTRibbon_Load(object sender, RibbonUIEventArgs e)
        {
           
        }
        /// <summary>
        /// 显示读取SAP表数据的控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tgbtnShowReadTable_Click(object sender, RibbonControlEventArgs e)
        {
            if (_ReaTablePane == null)
            {
                _ReadTableControl = new ReadTableControl();
                _ReaTablePane = Globals.ThisAddIn.CustomTaskPanes.Add(_ReadTableControl, "读取SAP表内容");
                _ReaTablePane.VisibleChanged += new EventHandler(taskPaneValue_VisibleChanged);
                _ReaTablePane.Visible = true;
                _ReaTablePane.Width = 300;
            }
            else
            {
                _ReaTablePane.Visible = ((RibbonToggleButton)sender).Checked;
               
            }
            
        }

        private void btnRunAbapCode_Click(object sender, RibbonControlEventArgs e)
        {
            //Form2 form2 = new Form2();
           // form2.Show();
        }

        private void btnAddConfig_Click(object sender, RibbonControlEventArgs e)
        {
            FormAddConfig frmAddConfig = new FormAddConfig();
            frmAddConfig.ShowDialog();
        }

        /// <summary>
        /// 显示SAP Query控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tgbtnQuery_Click(object sender, RibbonControlEventArgs e)
        {
            if (_SapQueryPane == null)
            {
                _SAPQueryControl = new SAPQueryControl();
                _SapQueryPane = Globals.ThisAddIn.CustomTaskPanes.Add(_SAPQueryControl, "SAP Query");
                _SapQueryPane.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionBottom;
                _SapQueryPane.VisibleChanged += new System.EventHandler(_SapQueryPane_VisibleChanged);
                _SapQueryPane.Visible = true;
            }
            else
            {

                _SapQueryPane.Visible = ((RibbonToggleButton)sender).Checked;
            }
            

        }

        void _SapQueryPane_VisibleChanged(object sender, System.EventArgs e)
        {
            tgbtnQuery.Checked = (sender as CustomTaskPane).Visible;
        }

        void taskPaneValue_VisibleChanged(object sender, EventArgs e)
        {
           tgbtnShowReadTable.Checked = this._ReaTablePane.Visible;
        }
        void getTaBleMetaPane_VisibleChanged(object sender, EventArgs e)
        {
            btnGetTableInfo.Checked = this._GetTableMetaPane.Visible;
        }

        private void btnGetTableInfo_Click(object sender, RibbonControlEventArgs e)
        {
            if (_GetTableMetaPane == null)
            {
                _GetTableMetaControl = new GetTableMetaControl();
                _GetTableMetaPane = Globals.ThisAddIn.CustomTaskPanes.Add(_GetTableMetaControl, "读取SAP表元数据");
                _GetTableMetaPane.VisibleChanged += new EventHandler(getTaBleMetaPane_VisibleChanged);
                _GetTableMetaPane.Visible = true;
                _GetTableMetaPane.Width = 300;
            }
            else
            {
                _GetTableMetaPane.Visible = ((RibbonToggleButton)sender).Checked;

            }
        }

        private void btFuncMeta_Click(object sender, RibbonControlEventArgs e)
        {
           // SAPINTGUI.FormFunctionMetaEx formFunctionMetaEx = new SAPINTGUI.FormFunctionMetaEx();
           // formFunctionMetaEx.Show();
            FormFunctionMeta formFunctionMeta = new FormFunctionMeta();
            formFunctionMeta.Show();
        }


    }
}
