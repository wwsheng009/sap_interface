namespace ExcelAddIn1
{
    partial class ManageTaskPaneRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public ManageTaskPaneRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
            
        }



        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.tgbtnShowReadTable = this.Factory.CreateRibbonToggleButton();
            this.separator1 = this.Factory.CreateRibbonSeparator();
            this.tgbtnQuery = this.Factory.CreateRibbonToggleButton();
            this.separator3 = this.Factory.CreateRibbonSeparator();
            this.btnGetTableInfo = this.Factory.CreateRibbonToggleButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.btFuncMeta = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.group2.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Groups.Add(this.group2);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.tgbtnShowReadTable);
            this.group1.Items.Add(this.separator1);
            this.group1.Items.Add(this.tgbtnQuery);
            this.group1.Items.Add(this.separator3);
            this.group1.Items.Add(this.btnGetTableInfo);
            this.group1.Label = "数据查询";
            this.group1.Name = "group1";
            // 
            // tgbtnShowReadTable
            // 
            this.tgbtnShowReadTable.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.tgbtnShowReadTable.Image = global::ExcelAddIn1.Properties.Resources.sap_read_table__1_;
            this.tgbtnShowReadTable.Label = "显示读表窗口";
            this.tgbtnShowReadTable.Name = "tgbtnShowReadTable";
            this.tgbtnShowReadTable.ShowImage = true;
            this.tgbtnShowReadTable.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.tgbtnShowReadTable_Click);
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            // 
            // tgbtnQuery
            // 
            this.tgbtnQuery.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.tgbtnQuery.Image = global::ExcelAddIn1.Properties.Resources.sap_qeury;
            this.tgbtnQuery.Label = "SAP QUERY";
            this.tgbtnQuery.Name = "tgbtnQuery";
            this.tgbtnQuery.ShowImage = true;
            this.tgbtnQuery.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.tgbtnQuery_Click);
            // 
            // separator3
            // 
            this.separator3.Name = "separator3";
            // 
            // btnGetTableInfo
            // 
            this.btnGetTableInfo.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnGetTableInfo.Image = global::ExcelAddIn1.Properties.Resources.sap_read_table__1_;
            this.btnGetTableInfo.Label = "显示表元数据";
            this.btnGetTableInfo.Name = "btnGetTableInfo";
            this.btnGetTableInfo.ShowImage = true;
            this.btnGetTableInfo.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnGetTableInfo_Click);
            // 
            // group2
            // 
            this.group2.Items.Add(this.btFuncMeta);
            this.group2.Label = "工具";
            this.group2.Name = "group2";
            // 
            // btFuncMeta
            // 
            this.btFuncMeta.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btFuncMeta.Image = global::ExcelAddIn1.Properties.Resources.run_abap_Code;
            this.btFuncMeta.Label = "显示函数信息";
            this.btFuncMeta.Name = "btFuncMeta";
            this.btFuncMeta.ShowImage = true;
            this.btFuncMeta.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btFuncMeta_Click);
            // 
            // ManageTaskPaneRibbon
            // 
            this.Name = "ManageTaskPaneRibbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.SAPINTRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton tgbtnShowReadTable;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator1;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton tgbtnQuery;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton btnGetTableInfo;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btFuncMeta;
    }

    partial class ThisRibbonCollection
    {
        internal ManageTaskPaneRibbon ManageTaskPaneRibbon
        {
            get { return this.GetRibbon<ManageTaskPaneRibbon>(); }
        }
    }
}
