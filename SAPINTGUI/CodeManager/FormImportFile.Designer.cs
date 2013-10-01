namespace SAPINT.Gui.CodeManager
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnChooseFolder = new System.Windows.Forms.Button();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnStartImport = new System.Windows.Forms.Button();
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnClearExtension = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.txtFolderName = new System.Windows.Forms.TextBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.txtFilesCount = new System.Windows.Forms.TextBox();
            this.txtFoldersFileCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSavedFiles = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStopImport = new System.Windows.Forms.Button();
            this.cbxDbSources = new System.Windows.Forms.ComboBox();
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
            this.btnChooseFolder.Location = new System.Drawing.Point(0, 2);
            this.btnChooseFolder.Name = "btnChooseFolder";
            this.btnChooseFolder.Size = new System.Drawing.Size(83, 23);
            this.btnChooseFolder.TabIndex = 0;
            this.btnChooseFolder.Text = "选择文件夹";
            this.btnChooseFolder.UseVisualStyleBackColor = true;
            this.btnChooseFolder.Click += new System.EventHandler(this.btnChooseFolder_Click);
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(91, 2);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(276, 21);
            this.txtFolder.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(483, 399);
            this.dataGridView1.TabIndex = 4;
            // 
            // btnStartImport
            // 
            this.btnStartImport.Location = new System.Drawing.Point(373, 58);
            this.btnStartImport.Name = "btnStartImport";
            this.btnStartImport.Size = new System.Drawing.Size(77, 25);
            this.btnStartImport.TabIndex = 11;
            this.btnStartImport.Text = "导入";
            this.btnStartImport.UseVisualStyleBackColor = true;
            this.btnStartImport.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(0, 27);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(85, 24);
            this.btnChooseFile.TabIndex = 4;
            this.btnChooseFile.Text = "选择多个文件";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // btnListFile
            // 
            this.btnListFile.Location = new System.Drawing.Point(373, 1);
            this.btnListFile.Name = "btnListFile";
            this.btnListFile.Size = new System.Drawing.Size(75, 23);
            this.btnListFile.TabIndex = 2;
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
            this.syntaxBoxControl1.Size = new System.Drawing.Size(348, 399);
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
            this.btnSelect.TabIndex = 8;
            this.btnSelect.Text = "批量选择";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnCancelSelect
            // 
            this.btnCancelSelect.Location = new System.Drawing.Point(170, 57);
            this.btnCancelSelect.Name = "btnCancelSelect";
            this.btnCancelSelect.Size = new System.Drawing.Size(75, 23);
            this.btnCancelSelect.TabIndex = 9;
            this.btnCancelSelect.Text = "取消选择";
            this.btnCancelSelect.UseVisualStyleBackColor = true;
            this.btnCancelSelect.Click += new System.EventHandler(this.btnCancelSelect_Click);
            // 
            // chxSubFolder
            // 
            this.chxSubFolder.AutoSize = true;
            this.chxSubFolder.Checked = true;
            this.chxSubFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chxSubFolder.Location = new System.Drawing.Point(91, 30);
            this.chxSubFolder.Name = "chxSubFolder";
            this.chxSubFolder.Size = new System.Drawing.Size(72, 16);
            this.chxSubFolder.TabIndex = 5;
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
            this.splitContainer1.Size = new System.Drawing.Size(835, 399);
            this.splitContainer1.SplitterDistance = 483;
            this.splitContainer1.TabIndex = 13;
            // 
            // chkReadHeader
            // 
            this.chkReadHeader.AutoSize = true;
            this.chkReadHeader.Checked = true;
            this.chkReadHeader.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReadHeader.Location = new System.Drawing.Point(170, 29);
            this.chkReadHeader.Name = "chkReadHeader";
            this.chkReadHeader.Size = new System.Drawing.Size(84, 16);
            this.chkReadHeader.TabIndex = 6;
            this.chkReadHeader.Text = "预读文件头";
            this.chkReadHeader.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(326, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "(字节)";
            // 
            // numericSize
            // 
            this.numericSize.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericSize.Location = new System.Drawing.Point(250, 25);
            this.numericSize.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericSize.Name = "numericSize";
            this.numericSize.Size = new System.Drawing.Size(74, 21);
            this.numericSize.TabIndex = 7;
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
            this.listExtension.Location = new System.Drawing.Point(0, 181);
            this.listExtension.Name = "listExtension";
            this.listExtension.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listExtension.Size = new System.Drawing.Size(83, 328);
            this.listExtension.TabIndex = 19;
            // 
            // chxFilter
            // 
            this.chxFilter.AutoSize = true;
            this.chxFilter.Location = new System.Drawing.Point(0, 92);
            this.chxFilter.Name = "chxFilter";
            this.chxFilter.Size = new System.Drawing.Size(48, 16);
            this.chxFilter.TabIndex = 10;
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
            this.btnAddExtension.Location = new System.Drawing.Point(0, 135);
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
            this.txtTreePath.Location = new System.Drawing.Point(323, 86);
            this.txtTreePath.Name = "txtTreePath";
            this.txtTreePath.ReadOnly = true;
            this.txtTreePath.Size = new System.Drawing.Size(335, 21);
            this.txtTreePath.TabIndex = 24;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(373, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "复制本地文件夹与文件";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClearExtension
            // 
            this.btnClearExtension.Location = new System.Drawing.Point(0, 159);
            this.btnClearExtension.Name = "btnClearExtension";
            this.btnClearExtension.Size = new System.Drawing.Size(83, 23);
            this.btnClearExtension.TabIndex = 26;
            this.btnClearExtension.Text = "清除后缀";
            this.btnClearExtension.UseVisualStyleBackColor = true;
            this.btnClearExtension.Click += new System.EventHandler(this.btnClearExtension_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(711, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(213, 23);
            this.progressBar1.TabIndex = 27;
            // 
            // txtFolderName
            // 
            this.txtFolderName.Location = new System.Drawing.Point(662, 55);
            this.txtFolderName.Name = "txtFolderName";
            this.txtFolderName.ReadOnly = true;
            this.txtFolderName.Size = new System.Drawing.Size(262, 21);
            this.txtFolderName.TabIndex = 28;
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(711, 29);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(213, 21);
            this.txtFileName.TabIndex = 29;
            // 
            // txtFilesCount
            // 
            this.txtFilesCount.Location = new System.Drawing.Point(519, 2);
            this.txtFilesCount.Name = "txtFilesCount";
            this.txtFilesCount.ReadOnly = true;
            this.txtFilesCount.Size = new System.Drawing.Size(51, 21);
            this.txtFilesCount.TabIndex = 30;
            // 
            // txtFoldersFileCount
            // 
            this.txtFoldersFileCount.Location = new System.Drawing.Point(662, 28);
            this.txtFoldersFileCount.Name = "txtFoldersFileCount";
            this.txtFoldersFileCount.ReadOnly = true;
            this.txtFoldersFileCount.Size = new System.Drawing.Size(36, 21);
            this.txtFoldersFileCount.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(460, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 31;
            this.label1.Text = "总文件数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(576, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 32;
            this.label3.Text = "文件夹文件数";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(600, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 33;
            this.label4.Text = "文件夹名";
            // 
            // txtSavedFiles
            // 
            this.txtSavedFiles.Location = new System.Drawing.Point(662, 2);
            this.txtSavedFiles.Name = "txtSavedFiles";
            this.txtSavedFiles.ReadOnly = true;
            this.txtSavedFiles.Size = new System.Drawing.Size(36, 21);
            this.txtSavedFiles.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(588, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 35;
            this.label5.Text = "保存的数量";
            // 
            // btnStopImport
            // 
            this.btnStopImport.Location = new System.Drawing.Point(456, 58);
            this.btnStopImport.Name = "btnStopImport";
            this.btnStopImport.Size = new System.Drawing.Size(75, 24);
            this.btnStopImport.TabIndex = 36;
            this.btnStopImport.Text = "停止导入";
            this.btnStopImport.UseVisualStyleBackColor = true;
            this.btnStopImport.Click += new System.EventHandler(this.btnStopImport_Click);
            // 
            // cbxDbSources
            // 
            this.cbxDbSources.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxDbSources.FormattingEnabled = true;
            this.cbxDbSources.Location = new System.Drawing.Point(251, 59);
            this.cbxDbSources.Name = "cbxDbSources";
            this.cbxDbSources.Size = new System.Drawing.Size(98, 20);
            this.cbxDbSources.TabIndex = 45;
            // 
            // FormImportFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 524);
            this.Controls.Add(this.cbxDbSources);
            this.Controls.Add(this.btnStopImport);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSavedFiles);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFoldersFileCount);
            this.Controls.Add(this.txtFilesCount);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.txtFolderName);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnClearExtension);
            this.Controls.Add(this.button1);
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
            this.Controls.Add(this.btnStartImport);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.btnChooseFolder);
            this.Name = "FormImportFile";
            this.Text = "导入文件";
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnStartImport;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnClearExtension;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox txtFolderName;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.TextBox txtFilesCount;
        private System.Windows.Forms.TextBox txtFoldersFileCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSavedFiles;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnStopImport;
        private System.Windows.Forms.ComboBox cbxDbSources;
    }
}
