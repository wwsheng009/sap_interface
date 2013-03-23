namespace SAPINTCODE
{
    partial class Form1
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
            this.sapTableField1 = new SAPINTCODE.SAPTableField();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.textTemplate = new SyntaxHighlighter.SyntaxRichTextBox();
            this.textResultCode = new ICSharpCode.TextEditor.TextEditorControl();
            this.textAbapResult = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fILEToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tspNewTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMChooseTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.tspSaveTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.模板ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tspProcessTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.tspLoadSystax = new System.Windows.Forms.ToolStripMenuItem();
            this.代码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tspRunAbapCode = new System.Windows.Forms.ToolStripMenuItem();
            this.tspGenerateCode = new System.Windows.Forms.ToolStripMenuItem();
            this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fILEToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.sapTableField1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(896, 672);
            this.splitContainer1.SplitterDistance = 323;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 4;
            // 
            // sapTableField1
            // 
            this.sapTableField1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sapTableField1.Location = new System.Drawing.Point(0, 0);
            this.sapTableField1.Name = "sapTableField1";
            this.sapTableField1.Size = new System.Drawing.Size(319, 668);
            this.sapTableField1.TabIndex = 1;
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
            this.splitContainer3.Panel2.Controls.Add(this.textAbapResult);
            this.splitContainer3.Size = new System.Drawing.Size(567, 672);
            this.splitContainer3.SplitterDistance = 518;
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
            this.splitContainer2.Size = new System.Drawing.Size(567, 518);
            this.splitContainer2.SplitterDistance = 285;
            this.splitContainer2.TabIndex = 8;
            // 
            // textTemplate
            // 
            this.textTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textTemplate.Location = new System.Drawing.Point(0, 0);
            this.textTemplate.Name = "textTemplate";
            this.textTemplate.Size = new System.Drawing.Size(281, 514);
            this.textTemplate.TabIndex = 0;
            this.textTemplate.Text = "";
            this.textTemplate.WordWrap = false;
            // 
            // textResultCode
            // 
            this.textResultCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textResultCode.IsReadOnly = false;
            this.textResultCode.Location = new System.Drawing.Point(0, 0);
            this.textResultCode.Name = "textResultCode";
            this.textResultCode.Size = new System.Drawing.Size(274, 514);
            this.textResultCode.TabIndex = 3;
            this.textResultCode.Text = "text";
            // 
            // textAbapResult
            // 
            this.textAbapResult.AcceptsReturn = true;
            this.textAbapResult.AcceptsTab = true;
            this.textAbapResult.AllowDrop = true;
            this.textAbapResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textAbapResult.Location = new System.Drawing.Point(0, 0);
            this.textAbapResult.MaxLength = 327670;
            this.textAbapResult.Multiline = true;
            this.textAbapResult.Name = "textAbapResult";
            this.textAbapResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textAbapResult.Size = new System.Drawing.Size(563, 145);
            this.textAbapResult.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem2,
            this.模板ToolStripMenuItem,
            this.代码ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(896, 25);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fILEToolStripMenuItem2
            // 
            this.fILEToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspNewTemplate,
            this.tsMChooseTemplate,
            this.tspSaveTemplate});
            this.fILEToolStripMenuItem2.Name = "fILEToolStripMenuItem2";
            this.fILEToolStripMenuItem2.Size = new System.Drawing.Size(44, 21);
            this.fILEToolStripMenuItem2.Text = "文件";
            // 
            // tspNewTemplate
            // 
            this.tspNewTemplate.Name = "tspNewTemplate";
            this.tspNewTemplate.Size = new System.Drawing.Size(124, 22);
            this.tspNewTemplate.Text = "新建模板";
            this.tspNewTemplate.Click += new System.EventHandler(this.tspNewTemplate_Click);
            // 
            // tsMChooseTemplate
            // 
            this.tsMChooseTemplate.Name = "tsMChooseTemplate";
            this.tsMChooseTemplate.Size = new System.Drawing.Size(124, 22);
            this.tsMChooseTemplate.Text = "选择模板";
            this.tsMChooseTemplate.Click += new System.EventHandler(this.tsMChooseTemplate_Click);
            // 
            // tspSaveTemplate
            // 
            this.tspSaveTemplate.Name = "tspSaveTemplate";
            this.tspSaveTemplate.Size = new System.Drawing.Size(124, 22);
            this.tspSaveTemplate.Text = "保存模板";
            this.tspSaveTemplate.Click += new System.EventHandler(this.tspSaveTemplate_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 697);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem tsMChooseTemplate;
        private System.Windows.Forms.ToolStripMenuItem tspSaveTemplate;
        private ICSharpCode.TextEditor.TextEditorControl textResultCode;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private SAPTableField sapTableField1;
        private System.Windows.Forms.TextBox textAbapResult;
        private System.Windows.Forms.ToolStripMenuItem 模板ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tspProcessTemplate;
        private System.Windows.Forms.ToolStripMenuItem 代码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tspRunAbapCode;
        private System.Windows.Forms.ToolStripMenuItem tspLoadSystax;
        private System.Windows.Forms.ToolStripMenuItem tspGenerateCode;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ToolStripMenuItem tspNewTemplate;
        private SyntaxHighlighter.SyntaxRichTextBox textTemplate;
       
    }
}

