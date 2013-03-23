namespace SAPINTCODE
{
    partial class FormAbapCode
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.sapTableField1 = new SAPINTCODE.SAPTableField();
            this.label1 = new System.Windows.Forms.Label();
            this.checkboxAuto = new System.Windows.Forms.CheckBox();
            this.lblconnected = new System.Windows.Forms.Label();
            this.tablecombobox = new System.Windows.Forms.ComboBox();
            this.userDataGridView = new System.Windows.Forms.DataGridView();
            this.btnOpenDb = new System.Windows.Forms.Button();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.textTemplate = new SyntaxHighlighter.SyntaxRichTextBox();
            this.textResultCode = new SyntaxHighlighter.SyntaxRichTextBox();
            this.textResult = new System.Windows.Forms.TextBox();
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
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1021, 717);
            this.splitContainer1.SplitterDistance = 368;
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
            this.splitContainer4.Panel2.Controls.Add(this.label1);
            this.splitContainer4.Panel2.Controls.Add(this.checkboxAuto);
            this.splitContainer4.Panel2.Controls.Add(this.lblconnected);
            this.splitContainer4.Panel2.Controls.Add(this.tablecombobox);
            this.splitContainer4.Panel2.Controls.Add(this.userDataGridView);
            this.splitContainer4.Panel2.Controls.Add(this.btnOpenDb);
            this.splitContainer4.Size = new System.Drawing.Size(364, 713);
            this.splitContainer4.SplitterDistance = 356;
            this.splitContainer4.TabIndex = 2;
            // 
            // sapTableField1
            // 
            this.sapTableField1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sapTableField1.Location = new System.Drawing.Point(0, 0);
            this.sapTableField1.Name = "sapTableField1";
            this.sapTableField1.Size = new System.Drawing.Size(364, 356);
            this.sapTableField1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "数据库状态";
            // 
            // checkboxAuto
            // 
            this.checkboxAuto.AutoSize = true;
            this.checkboxAuto.Location = new System.Drawing.Point(203, 28);
            this.checkboxAuto.Name = "checkboxAuto";
            this.checkboxAuto.Size = new System.Drawing.Size(72, 16);
            this.checkboxAuto.TabIndex = 6;
            this.checkboxAuto.Text = "自动选择";
            this.checkboxAuto.UseVisualStyleBackColor = true;
            // 
            // lblconnected
            // 
            this.lblconnected.AutoSize = true;
            this.lblconnected.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblconnected.Location = new System.Drawing.Point(95, 30);
            this.lblconnected.Name = "lblconnected";
            this.lblconnected.Size = new System.Drawing.Size(65, 12);
            this.lblconnected.TabIndex = 5;
            this.lblconnected.Text = "Disconnect";
            // 
            // tablecombobox
            // 
            this.tablecombobox.FormattingEnabled = true;
            this.tablecombobox.Location = new System.Drawing.Point(97, 7);
            this.tablecombobox.Name = "tablecombobox";
            this.tablecombobox.Size = new System.Drawing.Size(178, 20);
            this.tablecombobox.TabIndex = 4;
            this.tablecombobox.SelectedIndexChanged += new System.EventHandler(this.tablecombobox_SelectedIndexChanged);
            // 
            // userDataGridView
            // 
            this.userDataGridView.AllowUserToAddRows = false;
            this.userDataGridView.AllowUserToDeleteRows = false;
            this.userDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userDataGridView.Location = new System.Drawing.Point(3, 50);
            this.userDataGridView.Name = "userDataGridView";
            this.userDataGridView.ReadOnly = true;
            this.userDataGridView.RowTemplate.Height = 23;
            this.userDataGridView.Size = new System.Drawing.Size(358, 305);
            this.userDataGridView.TabIndex = 1;
            this.userDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.userDataGridView_CellMouseClick);
            // 
            // btnOpenDb
            // 
            this.btnOpenDb.Location = new System.Drawing.Point(3, 5);
            this.btnOpenDb.Name = "btnOpenDb";
            this.btnOpenDb.Size = new System.Drawing.Size(88, 23);
            this.btnOpenDb.TabIndex = 0;
            this.btnOpenDb.Text = "打开模板文件";
            this.btnOpenDb.UseVisualStyleBackColor = true;
            this.btnOpenDb.Click += new System.EventHandler(this.btnOpenDb_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer3.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
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
            this.splitContainer3.Size = new System.Drawing.Size(647, 717);
            this.splitContainer3.SplitterDistance = 552;
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
            this.splitContainer2.Size = new System.Drawing.Size(647, 552);
            this.splitContainer2.SplitterDistance = 328;
            this.splitContainer2.TabIndex = 8;
            // 
            // textTemplate
            // 
            this.textTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textTemplate.Location = new System.Drawing.Point(0, 0);
            this.textTemplate.Name = "textTemplate";
            this.textTemplate.Size = new System.Drawing.Size(324, 548);
            this.textTemplate.TabIndex = 0;
            this.textTemplate.Text = "";
            this.textTemplate.WordWrap = false;
            // 
            // textResultCode
            // 
            this.textResultCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textResultCode.Location = new System.Drawing.Point(0, 0);
            this.textResultCode.Name = "textResultCode";
            this.textResultCode.Size = new System.Drawing.Size(311, 548);
            this.textResultCode.TabIndex = 0;
            this.textResultCode.Text = "";
            this.textResultCode.WordWrap = false;
            // 
            // textResult
            // 
            this.textResult.AcceptsReturn = true;
            this.textResult.AcceptsTab = true;
            this.textResult.AllowDrop = true;
            this.textResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textResult.Location = new System.Drawing.Point(0, 0);
            this.textResult.MaxLength = 327670;
            this.textResult.Multiline = true;
            this.textResult.Name = "textResult";
            this.textResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textResult.Size = new System.Drawing.Size(643, 156);
            this.textResult.TabIndex = 4;
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
            // FormAbapCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 742);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormAbapCode";
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
            this.splitContainer3.Panel2.PerformLayout();
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
        private System.Windows.Forms.TextBox textResult;
        private System.Windows.Forms.ToolStripMenuItem 模板ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tspProcessTemplate;
        private System.Windows.Forms.ToolStripMenuItem 代码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tspRunAbapCode;
        private System.Windows.Forms.ToolStripMenuItem tspLoadSystax;
        private System.Windows.Forms.ToolStripMenuItem tspGenerateCode;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private SyntaxHighlighter.SyntaxRichTextBox textTemplate;
        private SyntaxHighlighter.SyntaxRichTextBox textResultCode;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.DataGridView userDataGridView;
        private System.Windows.Forms.Button btnOpenDb;
        private System.Windows.Forms.OpenFileDialog opnfiledlg;
        private System.Windows.Forms.ComboBox tablecombobox;
        private System.Windows.Forms.Label lblconnected;
        private System.Windows.Forms.CheckBox checkboxAuto;
        private System.Windows.Forms.Label label1;
       
    }
}

