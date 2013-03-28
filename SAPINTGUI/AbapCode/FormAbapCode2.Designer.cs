namespace SAPINTCODE
{
    partial class FormAbapCode2
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.sapTableField1 = new SAPINTCODE.SAPTableField();
            this.btnInserTemplate = new System.Windows.Forms.Button();
            this.btnUpdateTemplate = new System.Windows.Forms.Button();
            this.btnOpenTemplateTable = new System.Windows.Forms.Button();
            this.checkboxAuto = new System.Windows.Forms.CheckBox();
            this.userDataGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnPrettyCode = new System.Windows.Forms.Button();
            this.btnExcuteCode = new System.Windows.Forms.Button();
            this.btnGenerateCode = new System.Windows.Forms.Button();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.textTemplate = new Alsing.Windows.Forms.SyntaxBoxControl();
            this.syntaxDocument1 = new Alsing.SourceCode.SyntaxDocument(this.components);
            this.textResultCode = new Alsing.Windows.Forms.SyntaxBoxControl();
            this.syntaxDocument2 = new Alsing.SourceCode.SyntaxDocument(this.components);
            this.textResult = new Alsing.Windows.Forms.SyntaxBoxControl();
            this.syntaxDocument3 = new Alsing.SourceCode.SyntaxDocument(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fILEToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.模板ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tspProcessTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.tspLoadSystax = new System.Windows.Forms.ToolStripMenuItem();
            this.代码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tspRunAbapCode = new System.Windows.Forms.ToolStripMenuItem();
            this.tspGenerateCode = new System.Windows.Forms.ToolStripMenuItem();
            this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fILEToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.opnfiledlg = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.btnPrettyCode);
            this.splitContainer1.Panel2.Controls.Add(this.btnExcuteCode);
            this.splitContainer1.Panel2.Controls.Add(this.btnGenerateCode);
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1021, 717);
            this.splitContainer1.SplitterDistance = 316;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 4;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.sapTableField1);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.btnInserTemplate);
            this.splitContainer4.Panel2.Controls.Add(this.btnUpdateTemplate);
            this.splitContainer4.Panel2.Controls.Add(this.btnOpenTemplateTable);
            this.splitContainer4.Panel2.Controls.Add(this.checkboxAuto);
            this.splitContainer4.Panel2.Controls.Add(this.userDataGridView);
            this.splitContainer4.Size = new System.Drawing.Size(312, 713);
            this.splitContainer4.SplitterDistance = 356;
            this.splitContainer4.TabIndex = 2;
            // 
            // sapTableField1
            // 
            this.sapTableField1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sapTableField1.Location = new System.Drawing.Point(0, 0);
            this.sapTableField1.Name = "sapTableField1";
            this.sapTableField1.Size = new System.Drawing.Size(312, 356);
            this.sapTableField1.TabIndex = 1;
            // 
            // btnInserTemplate
            // 
            this.btnInserTemplate.Location = new System.Drawing.Point(104, 12);
            this.btnInserTemplate.Name = "btnInserTemplate";
            this.btnInserTemplate.Size = new System.Drawing.Size(93, 23);
            this.btnInserTemplate.TabIndex = 9;
            this.btnInserTemplate.Text = "插入模板内容";
            this.btnInserTemplate.UseVisualStyleBackColor = true;
            this.btnInserTemplate.Click += new System.EventHandler(this.btnInserTemplate_Click);
            // 
            // btnUpdateTemplate
            // 
            this.btnUpdateTemplate.Location = new System.Drawing.Point(11, 41);
            this.btnUpdateTemplate.Name = "btnUpdateTemplate";
            this.btnUpdateTemplate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateTemplate.TabIndex = 8;
            this.btnUpdateTemplate.Text = "更新模板";
            this.btnUpdateTemplate.UseVisualStyleBackColor = true;
            this.btnUpdateTemplate.Click += new System.EventHandler(this.btnUpdateTemplate_Click);
            // 
            // btnOpenTemplateTable
            // 
            this.btnOpenTemplateTable.Location = new System.Drawing.Point(11, 12);
            this.btnOpenTemplateTable.Name = "btnOpenTemplateTable";
            this.btnOpenTemplateTable.Size = new System.Drawing.Size(75, 23);
            this.btnOpenTemplateTable.TabIndex = 7;
            this.btnOpenTemplateTable.Text = "打开模板";
            this.btnOpenTemplateTable.UseVisualStyleBackColor = true;
            this.btnOpenTemplateTable.Click += new System.EventHandler(this.btnOpenTemplateTable_Click);
            // 
            // checkboxAuto
            // 
            this.checkboxAuto.AutoSize = true;
            this.checkboxAuto.Location = new System.Drawing.Point(104, 48);
            this.checkboxAuto.Name = "checkboxAuto";
            this.checkboxAuto.Size = new System.Drawing.Size(72, 16);
            this.checkboxAuto.TabIndex = 6;
            this.checkboxAuto.Text = "自动选择";
            this.checkboxAuto.UseVisualStyleBackColor = true;
            // 
            // userDataGridView
            // 
            this.userDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userDataGridView.Location = new System.Drawing.Point(3, 80);
            this.userDataGridView.Name = "userDataGridView";
            this.userDataGridView.RowTemplate.Height = 23;
            this.userDataGridView.Size = new System.Drawing.Size(306, 275);
            this.userDataGridView.TabIndex = 1;
            this.userDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.userDataGridView_CellMouseClick);
            this.userDataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.userDataGridView_CellMouseDoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(302, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPrettyCode
            // 
            this.btnPrettyCode.Location = new System.Drawing.Point(198, 1);
            this.btnPrettyCode.Name = "btnPrettyCode";
            this.btnPrettyCode.Size = new System.Drawing.Size(87, 35);
            this.btnPrettyCode.TabIndex = 14;
            this.btnPrettyCode.Text = "代码美化";
            this.btnPrettyCode.UseVisualStyleBackColor = true;
            this.btnPrettyCode.Click += new System.EventHandler(this.btnPrettyCode_Click);
            // 
            // btnExcuteCode
            // 
            this.btnExcuteCode.Location = new System.Drawing.Point(99, 1);
            this.btnExcuteCode.Name = "btnExcuteCode";
            this.btnExcuteCode.Size = new System.Drawing.Size(93, 35);
            this.btnExcuteCode.TabIndex = 13;
            this.btnExcuteCode.Text = "远程执行代码";
            this.btnExcuteCode.UseVisualStyleBackColor = true;
            this.btnExcuteCode.Click += new System.EventHandler(this.btnExcuteCode_Click);
            // 
            // btnGenerateCode
            // 
            this.btnGenerateCode.Location = new System.Drawing.Point(16, 2);
            this.btnGenerateCode.Name = "btnGenerateCode";
            this.btnGenerateCode.Size = new System.Drawing.Size(77, 34);
            this.btnGenerateCode.TabIndex = 12;
            this.btnGenerateCode.Text = "生成代码";
            this.btnGenerateCode.UseVisualStyleBackColor = true;
            this.btnGenerateCode.Click += new System.EventHandler(this.btnGenerateCode_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer3.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer3.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainer3.Location = new System.Drawing.Point(0, 42);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.textResult);
            this.splitContainer3.Size = new System.Drawing.Size(689, 675);
            this.splitContainer3.SplitterDistance = 519;
            this.splitContainer3.SplitterWidth = 5;
            this.splitContainer3.TabIndex = 11;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.textTemplate);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.textResultCode);
            this.splitContainer2.Size = new System.Drawing.Size(689, 519);
            this.splitContainer2.SplitterDistance = 344;
            this.splitContainer2.TabIndex = 8;
            // 
            // textTemplate
            // 
            this.textTemplate.ActiveView = Alsing.Windows.Forms.ActiveView.BottomRight;
            this.textTemplate.AutoListPosition = null;
            this.textTemplate.AutoListSelectedText = "a123";
            this.textTemplate.AutoListVisible = false;
            this.textTemplate.BackColor = System.Drawing.Color.White;
            this.textTemplate.BorderStyle = Alsing.Windows.Forms.BorderStyle.None;
            this.textTemplate.CopyAsRTF = false;
            this.textTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textTemplate.Document = this.syntaxDocument1;
            this.textTemplate.FontName = "Courier new";
            this.textTemplate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textTemplate.InfoTipCount = 1;
            this.textTemplate.InfoTipPosition = null;
            this.textTemplate.InfoTipSelectedIndex = 1;
            this.textTemplate.InfoTipVisible = false;
            this.textTemplate.Location = new System.Drawing.Point(0, 0);
            this.textTemplate.LockCursorUpdate = false;
            this.textTemplate.Name = "textTemplate";
            this.textTemplate.ShowScopeIndicator = false;
            this.textTemplate.Size = new System.Drawing.Size(340, 515);
            this.textTemplate.SmoothScroll = false;
            this.textTemplate.SplitviewH = -4;
            this.textTemplate.SplitviewV = -4;
            this.textTemplate.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.textTemplate.TabIndex = 1;
            this.textTemplate.Text = "syntaxBoxControl1";
            this.textTemplate.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
            // 
            // syntaxDocument1
            // 
            this.syntaxDocument1.Lines = new string[] {
        ""};
            this.syntaxDocument1.MaxUndoBufferSize = 1000;
            this.syntaxDocument1.Modified = false;
            this.syntaxDocument1.UndoStep = 0;
            // 
            // textResultCode
            // 
            this.textResultCode.ActiveView = Alsing.Windows.Forms.ActiveView.BottomRight;
            this.textResultCode.AutoListPosition = null;
            this.textResultCode.AutoListSelectedText = "a123";
            this.textResultCode.AutoListVisible = false;
            this.textResultCode.BackColor = System.Drawing.Color.White;
            this.textResultCode.BorderStyle = Alsing.Windows.Forms.BorderStyle.None;
            this.textResultCode.CopyAsRTF = false;
            this.textResultCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textResultCode.Document = this.syntaxDocument2;
            this.textResultCode.FontName = "Courier new";
            this.textResultCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textResultCode.InfoTipCount = 1;
            this.textResultCode.InfoTipPosition = null;
            this.textResultCode.InfoTipSelectedIndex = 1;
            this.textResultCode.InfoTipVisible = false;
            this.textResultCode.Location = new System.Drawing.Point(0, 0);
            this.textResultCode.LockCursorUpdate = false;
            this.textResultCode.Name = "textResultCode";
            this.textResultCode.ShowScopeIndicator = false;
            this.textResultCode.Size = new System.Drawing.Size(337, 515);
            this.textResultCode.SmoothScroll = false;
            this.textResultCode.SplitviewH = -4;
            this.textResultCode.SplitviewV = -4;
            this.textResultCode.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.textResultCode.TabIndex = 1;
            this.textResultCode.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
            // 
            // syntaxDocument2
            // 
            this.syntaxDocument2.Lines = new string[] {
        ""};
            this.syntaxDocument2.MaxUndoBufferSize = 1000;
            this.syntaxDocument2.Modified = false;
            this.syntaxDocument2.UndoStep = 0;
            // 
            // textResult
            // 
            this.textResult.ActiveView = Alsing.Windows.Forms.ActiveView.BottomRight;
            this.textResult.AutoListPosition = null;
            this.textResult.AutoListSelectedText = "a123";
            this.textResult.AutoListVisible = false;
            this.textResult.BackColor = System.Drawing.Color.White;
            this.textResult.BorderStyle = Alsing.Windows.Forms.BorderStyle.None;
            this.textResult.CopyAsRTF = false;
            this.textResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textResult.Document = this.syntaxDocument3;
            this.textResult.FontName = "Courier new";
            this.textResult.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textResult.InfoTipCount = 1;
            this.textResult.InfoTipPosition = null;
            this.textResult.InfoTipSelectedIndex = 1;
            this.textResult.InfoTipVisible = false;
            this.textResult.Location = new System.Drawing.Point(0, 0);
            this.textResult.LockCursorUpdate = false;
            this.textResult.Name = "textResult";
            this.textResult.ShowScopeIndicator = false;
            this.textResult.Size = new System.Drawing.Size(685, 147);
            this.textResult.SmoothScroll = false;
            this.textResult.SplitviewH = -4;
            this.textResult.SplitviewV = -4;
            this.textResult.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.textResult.TabIndex = 0;
            this.textResult.Text = "syntaxBoxControl2";
            this.textResult.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
            // 
            // syntaxDocument3
            // 
            this.syntaxDocument3.Lines = new string[] {
        ""};
            this.syntaxDocument3.MaxUndoBufferSize = 1000;
            this.syntaxDocument3.Modified = false;
            this.syntaxDocument3.UndoStep = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem2,
            this.模板ToolStripMenuItem,
            this.代码ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1021, 25);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fILEToolStripMenuItem2
            // 
            this.fILEToolStripMenuItem2.Name = "fILEToolStripMenuItem2";
            this.fILEToolStripMenuItem2.Size = new System.Drawing.Size(44, 21);
            this.fILEToolStripMenuItem2.Text = "文件";
            // 
            // 模板ToolStripMenuItem
            // 
            this.模板ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspProcessTemplate,
            this.tspLoadSystax});
            this.模板ToolStripMenuItem.Name = "模板ToolStripMenuItem";
            this.模板ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.模板ToolStripMenuItem.Text = "模板";
            // 
            // tspProcessTemplate
            // 
            this.tspProcessTemplate.Name = "tspProcessTemplate";
            this.tspProcessTemplate.Size = new System.Drawing.Size(148, 22);
            this.tspProcessTemplate.Text = "模板处理";
            this.tspProcessTemplate.Click += new System.EventHandler(this.tspProcessTemplate_Click);
            // 
            // tspLoadSystax
            // 
            this.tspLoadSystax.Name = "tspLoadSystax";
            this.tspLoadSystax.Size = new System.Drawing.Size(148, 22);
            this.tspLoadSystax.Text = "加载语法高亮";
            this.tspLoadSystax.Click += new System.EventHandler(this.tspLoadSystax_Click);
            // 
            // 代码ToolStripMenuItem
            // 
            this.代码ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspRunAbapCode,
            this.tspGenerateCode});
            this.代码ToolStripMenuItem.Name = "代码ToolStripMenuItem";
            this.代码ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.代码ToolStripMenuItem.Text = "代码";
            // 
            // tspRunAbapCode
            // 
            this.tspRunAbapCode.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.tspRunAbapCode.Name = "tspRunAbapCode";
            this.tspRunAbapCode.Size = new System.Drawing.Size(124, 22);
            this.tspRunAbapCode.Text = "运行";
            this.tspRunAbapCode.Click += new System.EventHandler(this.tspRunAbapCode_Click);
            // 
            // tspGenerateCode
            // 
            this.tspGenerateCode.Name = "tspGenerateCode";
            this.tspGenerateCode.Size = new System.Drawing.Size(124, 22);
            this.tspGenerateCode.Text = "生成代码";
            this.tspGenerateCode.Click += new System.EventHandler(this.tspGenerateCode_Click);
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.Size = new System.Drawing.Size(43, 21);
            this.fILEToolStripMenuItem.Text = "FILE";
            // 
            // fILEToolStripMenuItem1
            // 
            this.fILEToolStripMenuItem1.Name = "fILEToolStripMenuItem1";
            this.fILEToolStripMenuItem1.Size = new System.Drawing.Size(43, 21);
            this.fILEToolStripMenuItem1.Text = "FILE";
            // 
            // FormAbapCode2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 742);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormAbapCode2";
            this.Text = "ABAP代码生成";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userDataGridView)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private SAPTableField sapTableField1;
        private System.Windows.Forms.ToolStripMenuItem 模板ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tspProcessTemplate;
        private System.Windows.Forms.ToolStripMenuItem 代码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tspRunAbapCode;
        private System.Windows.Forms.ToolStripMenuItem tspLoadSystax;
        private System.Windows.Forms.ToolStripMenuItem tspGenerateCode;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.DataGridView userDataGridView;
        private System.Windows.Forms.OpenFileDialog opnfiledlg;
        private System.Windows.Forms.CheckBox checkboxAuto;
        private System.Windows.Forms.Button btnUpdateTemplate;
        private System.Windows.Forms.Button btnOpenTemplateTable;
        private System.Windows.Forms.Button btnInserTemplate;
        private System.Windows.Forms.Button btnGenerateCode;
        private System.Windows.Forms.Button btnPrettyCode;
        private System.Windows.Forms.Button btnExcuteCode;
        private System.Windows.Forms.Button button1;
        private Alsing.Windows.Forms.SyntaxBoxControl textTemplate;
        private Alsing.SourceCode.SyntaxDocument syntaxDocument1;
        private Alsing.Windows.Forms.SyntaxBoxControl textResultCode;
        private Alsing.SourceCode.SyntaxDocument syntaxDocument2;
        private Alsing.Windows.Forms.SyntaxBoxControl textResult;
        private Alsing.SourceCode.SyntaxDocument syntaxDocument3;
       
    }
}

