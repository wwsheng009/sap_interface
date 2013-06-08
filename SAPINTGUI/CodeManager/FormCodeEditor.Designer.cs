namespace SAPINTGUI.CodeManager
{
    partial class FormCodeEditor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCodeEditor));
            this.syntaxBoxControl1 = new Alsing.Windows.Forms.SyntaxBoxControl();
            this.syntaxDocument1 = new Alsing.SourceCode.SyntaxDocument(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxCategory = new System.Windows.Forms.ComboBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtTreeText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.NewToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.SaveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.CopytoolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.DeletetoolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SatustoolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // syntaxBoxControl1
            // 
            this.syntaxBoxControl1.ActiveView = Alsing.Windows.Forms.ActiveView.BottomRight;
            this.syntaxBoxControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.syntaxBoxControl1.AutoListPosition = null;
            this.syntaxBoxControl1.AutoListSelectedText = "a123";
            this.syntaxBoxControl1.AutoListVisible = false;
            this.syntaxBoxControl1.BackColor = System.Drawing.Color.White;
            this.syntaxBoxControl1.BorderStyle = Alsing.Windows.Forms.BorderStyle.None;
            this.syntaxBoxControl1.CopyAsRTF = false;
            this.syntaxBoxControl1.Document = this.syntaxDocument1;
            this.syntaxBoxControl1.FontName = "Courier new";
            this.syntaxBoxControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.syntaxBoxControl1.InfoTipCount = 1;
            this.syntaxBoxControl1.InfoTipPosition = null;
            this.syntaxBoxControl1.InfoTipSelectedIndex = 1;
            this.syntaxBoxControl1.InfoTipVisible = false;
            this.syntaxBoxControl1.Location = new System.Drawing.Point(0, 79);
            this.syntaxBoxControl1.LockCursorUpdate = false;
            this.syntaxBoxControl1.Name = "syntaxBoxControl1";
            this.syntaxBoxControl1.ShowScopeIndicator = false;
            this.syntaxBoxControl1.Size = new System.Drawing.Size(764, 305);
            this.syntaxBoxControl1.SmoothScroll = false;
            this.syntaxBoxControl1.SplitviewH = -4;
            this.syntaxBoxControl1.SplitviewV = -4;
            this.syntaxBoxControl1.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.syntaxBoxControl1.TabIndex = 0;
            this.syntaxBoxControl1.Text = "syntaxBoxControl1";
            this.syntaxBoxControl1.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
            this.syntaxBoxControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.syntaxBoxControl1_KeyDown);
            // 
            // syntaxDocument1
            // 
            this.syntaxDocument1.Lines = new string[] {
        ""};
            this.syntaxDocument1.MaxUndoBufferSize = 1000;
            this.syntaxDocument1.Modified = false;
            this.syntaxDocument1.UndoStep = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "分类";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(449, 28);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDesc.Size = new System.Drawing.Size(315, 45);
            this.txtDesc.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(414, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "描述";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "标题";
            // 
            // cbxCategory
            // 
            this.cbxCategory.FormattingEnabled = true;
            this.cbxCategory.Location = new System.Drawing.Point(66, 52);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(100, 20);
            this.cbxCategory.TabIndex = 14;
            this.cbxCategory.SelectedIndexChanged += new System.EventHandler(this.cbxCategory_SelectedIndexChanged);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(66, 30);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(329, 21);
            this.txtTitle.TabIndex = 13;
            // 
            // txtTreeText
            // 
            this.txtTreeText.Location = new System.Drawing.Point(226, 52);
            this.txtTreeText.Name = "txtTreeText";
            this.txtTreeText.Size = new System.Drawing.Size(169, 21);
            this.txtTreeText.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(172, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 27;
            this.label7.Text = "文件夹";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewToolStripButton,
            this.SaveToolStripButton,
            this.CopytoolStripButton2,
            this.DeletetoolStripButton1,
            this.toolStripSeparator1,
            this.SatustoolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(764, 25);
            this.toolStrip1.TabIndex = 29;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // NewToolStripButton
            // 
            this.NewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NewToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("NewToolStripButton.Image")));
            this.NewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewToolStripButton.Name = "NewToolStripButton";
            this.NewToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.NewToolStripButton.Text = "新建(&N)";
            this.NewToolStripButton.Click += new System.EventHandler(this.NewToolStripButton_Click);
            // 
            // SaveToolStripButton
            // 
            this.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveToolStripButton.Image")));
            this.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveToolStripButton.Name = "SaveToolStripButton";
            this.SaveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.SaveToolStripButton.Text = "保存(&S)";
            this.SaveToolStripButton.Click += new System.EventHandler(this.SaveToolStripButton_Click);
            // 
            // CopytoolStripButton2
            // 
            this.CopytoolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CopytoolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("CopytoolStripButton2.Image")));
            this.CopytoolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CopytoolStripButton2.Name = "CopytoolStripButton2";
            this.CopytoolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.CopytoolStripButton2.Text = "复制代码(&C)";
            this.CopytoolStripButton2.Click += new System.EventHandler(this.CopytoolStripButton2_Click);
            // 
            // DeletetoolStripButton1
            // 
            this.DeletetoolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeletetoolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("DeletetoolStripButton1.Image")));
            this.DeletetoolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeletetoolStripButton1.Name = "DeletetoolStripButton1";
            this.DeletetoolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.DeletetoolStripButton1.Text = "删除(&D)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // SatustoolStripLabel1
            // 
            this.SatustoolStripLabel1.Name = "SatustoolStripLabel1";
            this.SatustoolStripLabel1.Size = new System.Drawing.Size(56, 22);
            this.SatustoolStripLabel1.Text = "操作状态";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabel7});
            this.statusStrip1.Location = new System.Drawing.Point(0, 387);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(764, 22);
            this.statusStrip1.TabIndex = 30;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel2.Text = "创建时间:";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel4.Text = "00:00:00";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(83, 17);
            this.toolStripStatusLabel1.Text = "最后修改时间:";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel5.Text = "00:00:00";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel3.Text = "版本:";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(25, 17);
            this.toolStripStatusLabel6.Text = "0.0";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(14, 17);
            this.toolStripStatusLabel7.Text = "..";
            // 
            // FormCodeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 409);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTreeText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxCategory);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.syntaxBoxControl1);
            this.Name = "FormCodeEditor";
            this.Text = "代码编辑";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Alsing.Windows.Forms.SyntaxBoxControl syntaxBoxControl1;
        private Alsing.SourceCode.SyntaxDocument syntaxDocument1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxCategory;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtTreeText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripButton NewToolStripButton;
        private System.Windows.Forms.ToolStripButton SaveToolStripButton;
        private System.Windows.Forms.ToolStripButton DeletetoolStripButton1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripLabel SatustoolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton CopytoolStripButton2;

    }
}
