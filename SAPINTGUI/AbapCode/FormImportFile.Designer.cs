namespace SAPINTGUI.AbapCode
{
    partial class FormImportFile
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
            this.btnChooseFolder = new System.Windows.Forms.Button();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.btnListFile = new System.Windows.Forms.Button();
            this.syntaxBoxControl1 = new Alsing.Windows.Forms.SyntaxBoxControl();
            this.syntaxDocument1 = new Alsing.SourceCode.SyntaxDocument(this.components);
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnCancelSelect = new System.Windows.Forms.Button();
            this.chxSubFolder = new System.Windows.Forms.CheckBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chkReadHeader = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericSize = new System.Windows.Forms.NumericUpDown();
            this.listExtension = new System.Windows.Forms.ListBox();
            this.chxFilter = new System.Windows.Forms.CheckBox();
            this.txtExtension = new System.Windows.Forms.TextBox();
            this.btnAddExtension = new System.Windows.Forms.Button();
            this.txtTreeId = new System.Windows.Forms.TextBox();
            this.txtTreePath = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSize)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChooseFolder
            // 
            this.btnChooseFolder.Location = new System.Drawing.Point(433, 4);
            this.btnChooseFolder.Name = "btnChooseFolder";
            this.btnChooseFolder.Size = new System.Drawing.Size(94, 23);
            this.btnChooseFolder.TabIndex = 0;
            this.btnChooseFolder.Text = "打开文件夹";
            this.btnChooseFolder.UseVisualStyleBackColor = true;
            this.btnChooseFolder.Click += new System.EventHandler(this.btnChooseFolder_Click);
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(59, 4);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(366, 21);
            this.txtFolder.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "文件夹";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(368, 399);
            this.dataGridView1.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(290, 56);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 25);
            this.button2.TabIndex = 5;
            this.button2.Text = "导入选择的文件";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(433, 58);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(94, 23);
            this.btnChooseFile.TabIndex = 7;
            this.btnChooseFile.Text = "打开多个文件";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // btnListFile
            // 
            this.btnListFile.Location = new System.Drawing.Point(433, 31);
            this.btnListFile.Name = "btnListFile";
            this.btnListFile.Size = new System.Drawing.Size(94, 23);
            this.btnListFile.TabIndex = 8;
            this.btnListFile.Text = "列出文件";
            this.btnListFile.UseVisualStyleBackColor = true;
            this.btnListFile.Click += new System.EventHandler(this.btnListFile_Click);
            // 
            // syntaxBoxControl1
            // 
            this.syntaxBoxControl1.ActiveView = Alsing.Windows.Forms.ActiveView.BottomRight;
            this.syntaxBoxControl1.AutoListPosition = null;
            this.syntaxBoxControl1.AutoListSelectedText = "a123";
            this.syntaxBoxControl1.AutoListVisible = false;
            this.syntaxBoxControl1.BackColor = System.Drawing.Color.White;
            this.syntaxBoxControl1.BorderStyle = Alsing.Windows.Forms.BorderStyle.None;
            this.syntaxBoxControl1.CopyAsRTF = false;
            this.syntaxBoxControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.syntaxBoxControl1.Document = this.syntaxDocument1;
            this.syntaxBoxControl1.FontName = "Courier new";
            this.syntaxBoxControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.syntaxBoxControl1.InfoTipCount = 1;
            this.syntaxBoxControl1.InfoTipPosition = null;
            this.syntaxBoxControl1.InfoTipSelectedIndex = 1;
            this.syntaxBoxControl1.InfoTipVisible = false;
            this.syntaxBoxControl1.Location = new System.Drawing.Point(0, 0);
            this.syntaxBoxControl1.LockCursorUpdate = false;
            this.syntaxBoxControl1.Name = "syntaxBoxControl1";
            this.syntaxBoxControl1.ShowScopeIndicator = false;
            this.syntaxBoxControl1.Size = new System.Drawing.Size(264, 399);
            this.syntaxBoxControl1.SmoothScroll = false;
            this.syntaxBoxControl1.SplitviewH = -4;
            this.syntaxBoxControl1.SplitviewV = -4;
            this.syntaxBoxControl1.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.syntaxBoxControl1.TabIndex = 9;
            this.syntaxBoxControl1.Text = "syntaxBoxControl1";
            this.syntaxBoxControl1.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
            // 
            // syntaxDocument1
            // 
            this.syntaxDocument1.Lines = new string[] {
        ""};
            this.syntaxDocument1.MaxUndoBufferSize = 1000;
            this.syntaxDocument1.Modified = false;
            this.syntaxDocument1.UndoStep = 0;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(89, 57);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 10;
            this.btnSelect.Text = "批量选择";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnCancelSelect
            // 
            this.btnCancelSelect.Location = new System.Drawing.Point(170, 57);
            this.btnCancelSelect.Name = "btnCancelSelect";
            this.btnCancelSelect.Size = new System.Drawing.Size(75, 23);
            this.btnCancelSelect.TabIndex = 11;
            this.btnCancelSelect.Text = "取消选择";
            this.btnCancelSelect.UseVisualStyleBackColor = true;
            this.btnCancelSelect.Click += new System.EventHandler(this.btnCancelSelect_Click);
            // 
            // chxSubFolder
            // 
            this.chxSubFolder.AutoSize = true;
            this.chxSubFolder.Checked = true;
            this.chxSubFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chxSubFolder.Location = new System.Drawing.Point(59, 35);
            this.chxSubFolder.Name = "chxSubFolder";
            this.chxSubFolder.Size = new System.Drawing.Size(72, 16);
            this.chxSubFolder.TabIndex = 12;
            this.chxSubFolder.Text = "子文件夹";
            this.chxSubFolder.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(89, 113);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.syntaxBoxControl1);
            this.splitContainer1.Size = new System.Drawing.Size(636, 399);
            this.splitContainer1.SplitterDistance = 368;
            this.splitContainer1.TabIndex = 13;
            // 
            // chkReadHeader
            // 
            this.chkReadHeader.AutoSize = true;
            this.chkReadHeader.Checked = true;
            this.chkReadHeader.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReadHeader.Location = new System.Drawing.Point(137, 36);
            this.chkReadHeader.Name = "chkReadHeader";
            this.chkReadHeader.Size = new System.Drawing.Size(84, 16);
            this.chkReadHeader.TabIndex = 16;
            this.chkReadHeader.Text = "预读文件头";
            this.chkReadHeader.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(307, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "长度(字节)";
            // 
            // numericSize
            // 
            this.numericSize.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericSize.Location = new System.Drawing.Point(227, 30);
            this.numericSize.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericSize.Name = "numericSize";
            this.numericSize.Size = new System.Drawing.Size(74, 21);
            this.numericSize.TabIndex = 18;
            this.numericSize.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // listExtension
            // 
            this.listExtension.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listExtension.FormattingEnabled = true;
            this.listExtension.ItemHeight = 12;
            this.listExtension.Location = new System.Drawing.Point(0, 169);
            this.listExtension.Name = "listExtension";
            this.listExtension.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listExtension.Size = new System.Drawing.Size(83, 340);
            this.listExtension.TabIndex = 19;
            // 
            // chxFilter
            // 
            this.chxFilter.AutoSize = true;
            this.chxFilter.Location = new System.Drawing.Point(14, 88);
            this.chxFilter.Name = "chxFilter";
            this.chxFilter.Size = new System.Drawing.Size(48, 16);
            this.chxFilter.TabIndex = 20;
            this.chxFilter.Text = "筛选";
            this.chxFilter.UseVisualStyleBackColor = true;
            // 
            // txtExtension
            // 
            this.txtExtension.Location = new System.Drawing.Point(0, 113);
            this.txtExtension.Name = "txtExtension";
            this.txtExtension.Size = new System.Drawing.Size(83, 21);
            this.txtExtension.TabIndex = 21;
            // 
            // btnAddExtension
            // 
            this.btnAddExtension.Location = new System.Drawing.Point(0, 140);
            this.btnAddExtension.Name = "btnAddExtension";
            this.btnAddExtension.Size = new System.Drawing.Size(83, 23);
            this.btnAddExtension.TabIndex = 22;
            this.btnAddExtension.Text = "添加后缀";
            this.btnAddExtension.UseVisualStyleBackColor = true;
            this.btnAddExtension.Click += new System.EventHandler(this.btnAddExtension_Click);
            // 
            // txtTreeId
            // 
            this.txtTreeId.Location = new System.Drawing.Point(89, 87);
            this.txtTreeId.Name = "txtTreeId";
            this.txtTreeId.ReadOnly = true;
            this.txtTreeId.Size = new System.Drawing.Size(228, 21);
            this.txtTreeId.TabIndex = 23;
            // 
            // txtTreePath
            // 
            this.txtTreePath.Location = new System.Drawing.Point(323, 88);
            this.txtTreePath.Name = "txtTreePath";
            this.txtTreePath.ReadOnly = true;
            this.txtTreePath.Size = new System.Drawing.Size(335, 21);
            this.txtTreePath.TabIndex = 24;
            // 
            // FormImportFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 524);
            this.Controls.Add(this.txtTreePath);
            this.Controls.Add(this.txtTreeId);
            this.Controls.Add(this.btnAddExtension);
            this.Controls.Add(this.txtExtension);
            this.Controls.Add(this.chxFilter);
            this.Controls.Add(this.listExtension);
            this.Controls.Add(this.numericSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkReadHeader);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.chxSubFolder);
            this.Controls.Add(this.btnCancelSelect);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnListFile);
            this.Controls.Add(this.btnChooseFile);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.btnChooseFolder);
            this.Name = "FormImportFile";
            this.Text = "FormImportFile";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChooseFolder;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.Button btnListFile;
        private Alsing.Windows.Forms.SyntaxBoxControl syntaxBoxControl1;
        private Alsing.SourceCode.SyntaxDocument syntaxDocument1;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnCancelSelect;
        private System.Windows.Forms.CheckBox chxSubFolder;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox chkReadHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericSize;
        private System.Windows.Forms.ListBox listExtension;
        private System.Windows.Forms.CheckBox chxFilter;
        private System.Windows.Forms.TextBox txtExtension;
        private System.Windows.Forms.Button btnAddExtension;
        private System.Windows.Forms.TextBox txtTreeId;
        private System.Windows.Forms.TextBox txtTreePath;
    }
}