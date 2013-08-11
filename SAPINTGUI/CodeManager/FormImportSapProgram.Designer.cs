namespace SAPINT.Gui.CodeManager
{
    partial class FormImportSapProgram
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.syntaxDocument1 = new Alsing.SourceCode.SyntaxDocument(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnSearchReport = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDevClass = new System.Windows.Forms.TextBox();
            this.txtObject = new System.Windows.Forms.TextBox();
            this.btnCancelImport = new System.Windows.Forms.Button();
            this.txtProgress = new System.Windows.Forms.TextBox();
            this.txtCurrentProg = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cbxNotLimit = new System.Windows.Forms.CheckBox();
            this.numPauseTime = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cboxSystemList1 = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.txtTreePath = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.txtTreeId = new System.Windows.Forms.TextBox();
            this.btnCancelSelect = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnReadObjectFromSap = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.syntaxBoxControl1 = new Alsing.Windows.Forms.SyntaxBoxControl();
            this.btnLoad = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSapProgram = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numPauseTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // syntaxDocument1
            // 
            this.syntaxDocument1.Lines = new string[] {
        ""};
            this.syntaxDocument1.MaxUndoBufferSize = 1000;
            this.syntaxDocument1.Modified = false;
            this.syntaxDocument1.UndoStep = 0;
            // 
            // btnSearchReport
            // 
            this.btnSearchReport.Location = new System.Drawing.Point(170, 32);
            this.btnSearchReport.Name = "btnSearchReport";
            this.btnSearchReport.Size = new System.Drawing.Size(50, 23);
            this.btnSearchReport.TabIndex = 21;
            this.btnSearchReport.Text = "搜索";
            this.btnSearchReport.UseVisualStyleBackColor = true;
            this.btnSearchReport.Click += new System.EventHandler(this.btnSearchReport_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(530, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 43;
            this.label3.Text = "开发类";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(396, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 42;
            this.label2.Text = "对象类型";
            // 
            // txtDevClass
            // 
            this.txtDevClass.Location = new System.Drawing.Point(574, 5);
            this.txtDevClass.Name = "txtDevClass";
            this.txtDevClass.Size = new System.Drawing.Size(75, 21);
            this.txtDevClass.TabIndex = 41;
            // 
            // txtObject
            // 
            this.txtObject.Location = new System.Drawing.Point(456, 6);
            this.txtObject.Name = "txtObject";
            this.txtObject.Size = new System.Drawing.Size(70, 21);
            this.txtObject.TabIndex = 40;
            // 
            // btnCancelImport
            // 
            this.btnCancelImport.Location = new System.Drawing.Point(370, 32);
            this.btnCancelImport.Name = "btnCancelImport";
            this.btnCancelImport.Size = new System.Drawing.Size(75, 23);
            this.btnCancelImport.TabIndex = 39;
            this.btnCancelImport.Text = "取消导入";
            this.btnCancelImport.UseVisualStyleBackColor = true;
            this.btnCancelImport.Click += new System.EventHandler(this.btnCancelImport_Click);
            // 
            // txtProgress
            // 
            this.txtProgress.Location = new System.Drawing.Point(485, 57);
            this.txtProgress.Name = "txtProgress";
            this.txtProgress.ReadOnly = true;
            this.txtProgress.Size = new System.Drawing.Size(100, 21);
            this.txtProgress.TabIndex = 38;
            // 
            // txtCurrentProg
            // 
            this.txtCurrentProg.Location = new System.Drawing.Point(210, 57);
            this.txtCurrentProg.Name = "txtCurrentProg";
            this.txtCurrentProg.ReadOnly = true;
            this.txtCurrentProg.Size = new System.Drawing.Size(269, 21);
            this.txtCurrentProg.TabIndex = 37;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(591, 55);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(133, 23);
            this.progressBar1.TabIndex = 36;
            // 
            // cbxNotLimit
            // 
            this.cbxNotLimit.AutoSize = true;
            this.cbxNotLimit.Location = new System.Drawing.Point(651, 8);
            this.cbxNotLimit.Name = "cbxNotLimit";
            this.cbxNotLimit.Size = new System.Drawing.Size(60, 16);
            this.cbxNotLimit.TabIndex = 35;
            this.cbxNotLimit.Text = "无限制";
            this.cbxNotLimit.UseVisualStyleBackColor = true;
            // 
            // numPauseTime
            // 
            this.numPauseTime.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numPauseTime.Location = new System.Drawing.Point(667, 33);
            this.numPauseTime.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numPauseTime.Name = "numPauseTime";
            this.numPauseTime.Size = new System.Drawing.Size(40, 21);
            this.numPauseTime.TabIndex = 34;
            this.numPauseTime.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(573, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 33;
            this.label1.Text = "暂停时间(毫秒)";
            // 
            // cboxSystemList1
            // 
            this.cboxSystemList1.FormattingEnabled = true;
            this.cboxSystemList1.Location = new System.Drawing.Point(13, 4);
            this.cboxSystemList1.Name = "cboxSystemList1";
            this.cboxSystemList1.Size = new System.Drawing.Size(102, 20);
            this.cboxSystemList1.TabIndex = 31;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(778, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(31, 21);
            this.button5.TabIndex = 26;
            this.button5.Text = "<";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // txtTreePath
            // 
            this.txtTreePath.Location = new System.Drawing.Point(46, 57);
            this.txtTreePath.Name = "txtTreePath";
            this.txtTreePath.ReadOnly = true;
            this.txtTreePath.Size = new System.Drawing.Size(145, 21);
            this.txtTreePath.TabIndex = 30;
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Location = new System.Drawing.Point(815, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(31, 21);
            this.button6.TabIndex = 25;
            this.button6.Text = ">";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // txtTreeId
            // 
            this.txtTreeId.Location = new System.Drawing.Point(13, 57);
            this.txtTreeId.Name = "txtTreeId";
            this.txtTreeId.ReadOnly = true;
            this.txtTreeId.Size = new System.Drawing.Size(27, 21);
            this.txtTreeId.TabIndex = 29;
            // 
            // btnCancelSelect
            // 
            this.btnCancelSelect.Location = new System.Drawing.Point(63, 32);
            this.btnCancelSelect.Name = "btnCancelSelect";
            this.btnCancelSelect.Size = new System.Drawing.Size(42, 23);
            this.btnCancelSelect.TabIndex = 26;
            this.btnCancelSelect.Text = "取消";
            this.btnCancelSelect.UseVisualStyleBackColor = true;
            this.btnCancelSelect.Click += new System.EventHandler(this.btnCancelSelect_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(12, 32);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(45, 23);
            this.btnSelect.TabIndex = 25;
            this.btnSelect.Text = "选择";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnReadObjectFromSap
            // 
            this.btnReadObjectFromSap.Location = new System.Drawing.Point(226, 32);
            this.btnReadObjectFromSap.Name = "btnReadObjectFromSap";
            this.btnReadObjectFromSap.Size = new System.Drawing.Size(76, 23);
            this.btnReadObjectFromSap.TabIndex = 24;
            this.btnReadObjectFromSap.Text = "读取程序";
            this.btnReadObjectFromSap.UseVisualStyleBackColor = true;
            this.btnReadObjectFromSap.Click += new System.EventHandler(this.btnReadObjectFromSap_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(308, 32);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(56, 23);
            this.btnImport.TabIndex = 23;
            this.btnImport.Text = "导入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(2, 84);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.syntaxBoxControl1);
            this.splitContainer1.Size = new System.Drawing.Size(844, 415);
            this.splitContainer1.SplitterDistance = 506;
            this.splitContainer1.TabIndex = 22;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(506, 415);
            this.dataGridView1.TabIndex = 20;
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
            this.syntaxBoxControl1.Size = new System.Drawing.Size(334, 415);
            this.syntaxBoxControl1.SmoothScroll = false;
            this.syntaxBoxControl1.SplitviewH = -4;
            this.syntaxBoxControl1.SplitviewV = -4;
            this.syntaxBoxControl1.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.syntaxBoxControl1.TabIndex = 17;
            this.syntaxBoxControl1.Text = "syntaxBoxControl1";
            this.syntaxBoxControl1.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(456, 33);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(111, 23);
            this.btnLoad.TabIndex = 16;
            this.btnLoad.Text = "读取程序(方法2)";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(121, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "SAP程序";
            // 
            // txtSapProgram
            // 
            this.txtSapProgram.Location = new System.Drawing.Point(170, 3);
            this.txtSapProgram.Name = "txtSapProgram";
            this.txtSapProgram.Size = new System.Drawing.Size(208, 21);
            this.txtSapProgram.TabIndex = 14;
            // 
            // FormImportSapProgram
            // 
            this.AcceptButton = this.btnSearchReport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 501);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDevClass);
            this.Controls.Add(this.txtObject);
            this.Controls.Add(this.btnCancelImport);
            this.Controls.Add(this.txtProgress);
            this.Controls.Add(this.txtCurrentProg);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.cbxNotLimit);
            this.Controls.Add(this.numPauseTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboxSystemList1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.txtTreePath);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.txtTreeId);
            this.Controls.Add(this.btnCancelSelect);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnReadObjectFromSap);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnSearchReport);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSapProgram);
            this.Name = "FormImportSapProgram";
            this.Text = "导入SAP程序";
            ((System.ComponentModel.ISupportInitialize)(this.numPauseTime)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSapProgram;
        private System.Windows.Forms.Button btnLoad;
        private Alsing.Windows.Forms.SyntaxBoxControl syntaxBoxControl1;
        private Alsing.SourceCode.SyntaxDocument syntaxDocument1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSearchReport;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnReadObjectFromSap;
        private System.Windows.Forms.Button btnCancelSelect;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox txtTreeId;
        private System.Windows.Forms.TextBox txtTreePath;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ComboBox cboxSystemList1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numPauseTime;
        private System.Windows.Forms.CheckBox cbxNotLimit;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox txtCurrentProg;
        private System.Windows.Forms.TextBox txtProgress;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnCancelImport;
        private System.Windows.Forms.TextBox txtObject;
        private System.Windows.Forms.TextBox txtDevClass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
