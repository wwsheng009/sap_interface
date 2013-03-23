namespace ExcelAddIn1
{
    partial class FormFunctionMeta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFunctionMeta));
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_SystemList = new SAPINT.Controls.CboxSystemList();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFunctionName = new System.Windows.Forms.TextBox();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvImport = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvExport = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvChanging = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dgvTables = new System.Windows.Forms.DataGridView();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.btnParseToExcel = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.dgvBatchInput = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnBatchInput = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImport)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExport)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChanging)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBatchInput)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "SAP系统";
            // 
            // cbx_SystemList
            // 
            this.cbx_SystemList.DataSource = ((object)(resources.GetObject("cbx_SystemList.DataSource")));
            this.cbx_SystemList.Location = new System.Drawing.Point(58, 4);
            this.cbx_SystemList.Name = "cbx_SystemList";
            this.cbx_SystemList.Size = new System.Drawing.Size(162, 20);
            this.cbx_SystemList.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "函数名:";
            // 
            // txtFunctionName
            // 
            this.txtFunctionName.Location = new System.Drawing.Point(58, 30);
            this.txtFunctionName.Name = "txtFunctionName";
            this.txtFunctionName.Size = new System.Drawing.Size(327, 21);
            this.txtFunctionName.TabIndex = 12;
            this.txtFunctionName.Text = "Z_RFC_STORE2_01";
            // 
            // btnDisplay
            // 
            this.btnDisplay.Location = new System.Drawing.Point(391, 30);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(75, 23);
            this.btnDisplay.TabIndex = 13;
            this.btnDisplay.Text = "显示";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(7, 59);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDetail);
            this.splitContainer1.Size = new System.Drawing.Size(736, 415);
            this.splitContainer1.SplitterDistance = 207;
            this.splitContainer1.TabIndex = 14;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(736, 207);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(728, 181);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "属性";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvImport);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(728, 181);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Import";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvImport
            // 
            this.dgvImport.AllowUserToAddRows = false;
            this.dgvImport.AllowUserToDeleteRows = false;
            this.dgvImport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvImport.Location = new System.Drawing.Point(3, 3);
            this.dgvImport.Name = "dgvImport";
            this.dgvImport.ReadOnly = true;
            this.dgvImport.RowTemplate.Height = 23;
            this.dgvImport.Size = new System.Drawing.Size(722, 175);
            this.dgvImport.TabIndex = 0;
            this.dgvImport.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvImport_CellClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvExport);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(728, 181);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Export";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvExport
            // 
            this.dgvExport.AllowUserToAddRows = false;
            this.dgvExport.AllowUserToDeleteRows = false;
            this.dgvExport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExport.Location = new System.Drawing.Point(3, 3);
            this.dgvExport.Name = "dgvExport";
            this.dgvExport.ReadOnly = true;
            this.dgvExport.RowTemplate.Height = 23;
            this.dgvExport.Size = new System.Drawing.Size(722, 175);
            this.dgvExport.TabIndex = 0;
            this.dgvExport.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExport_CellClick);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgvChanging);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(728, 181);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Changing";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvChanging
            // 
            this.dgvChanging.AllowUserToAddRows = false;
            this.dgvChanging.AllowUserToDeleteRows = false;
            this.dgvChanging.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChanging.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChanging.Location = new System.Drawing.Point(3, 3);
            this.dgvChanging.Name = "dgvChanging";
            this.dgvChanging.ReadOnly = true;
            this.dgvChanging.RowTemplate.Height = 23;
            this.dgvChanging.Size = new System.Drawing.Size(722, 175);
            this.dgvChanging.TabIndex = 0;
            this.dgvChanging.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChanging_CellClick);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dgvTables);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(728, 181);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Tables";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dgvTables
            // 
            this.dgvTables.AllowUserToAddRows = false;
            this.dgvTables.AllowUserToDeleteRows = false;
            this.dgvTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTables.Location = new System.Drawing.Point(3, 3);
            this.dgvTables.Name = "dgvTables";
            this.dgvTables.ReadOnly = true;
            this.dgvTables.RowTemplate.Height = 23;
            this.dgvTables.Size = new System.Drawing.Size(722, 175);
            this.dgvTables.TabIndex = 0;
            this.dgvTables.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTables_CellClick);
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.Size = new System.Drawing.Size(736, 204);
            this.dgvDetail.TabIndex = 0;
            // 
            // btnParseToExcel
            // 
            this.btnParseToExcel.Location = new System.Drawing.Point(492, 30);
            this.btnParseToExcel.Name = "btnParseToExcel";
            this.btnParseToExcel.Size = new System.Drawing.Size(97, 23);
            this.btnParseToExcel.TabIndex = 15;
            this.btnParseToExcel.Text = "格式化到Excel";
            this.btnParseToExcel.UseVisualStyleBackColor = true;
            this.btnParseToExcel.Click += new System.EventHandler(this.btnParseToExcel_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.dgvBatchInput);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(728, 181);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "批量读取函数";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // dgvBatchInput
            // 
            this.dgvBatchInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBatchInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBatchInput.Location = new System.Drawing.Point(3, 3);
            this.dgvBatchInput.Name = "dgvBatchInput";
            this.dgvBatchInput.RowTemplate.Height = 23;
            this.dgvBatchInput.Size = new System.Drawing.Size(722, 175);
            this.dgvBatchInput.TabIndex = 0;
            this.dgvBatchInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvBatchInput_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(492, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "格式化到Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnParseToExcel_Click);
            // 
            // btnBatchInput
            // 
            this.btnBatchInput.Location = new System.Drawing.Point(607, 30);
            this.btnBatchInput.Name = "btnBatchInput";
            this.btnBatchInput.Size = new System.Drawing.Size(75, 23);
            this.btnBatchInput.TabIndex = 16;
            this.btnBatchInput.Text = "批量处理";
            this.btnBatchInput.UseVisualStyleBackColor = true;
            this.btnBatchInput.Click += new System.EventHandler(this.btnBatchInput_Click);
            // 
            // FormFunctionMeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 486);
            this.Controls.Add(this.btnBatchInput);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnParseToExcel);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnDisplay);
            this.Controls.Add(this.txtFunctionName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbx_SystemList);
            this.Name = "FormFunctionMeta";
            this.Text = "FormFunctionMeta";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvImport)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExport)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChanging)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBatchInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private SAPINT.Controls.CboxSystemList cbx_SystemList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFunctionName;
        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.DataGridView dgvImport;
        private System.Windows.Forms.DataGridView dgvExport;
        private System.Windows.Forms.DataGridView dgvChanging;
        private System.Windows.Forms.DataGridView dgvTables;
        private System.Windows.Forms.Button btnParseToExcel;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.DataGridView dgvBatchInput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnBatchInput;
    }
}