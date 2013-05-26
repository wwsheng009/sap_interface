namespace SAPINTGUI.CodeManager
{
    partial class FormImporSapProgram
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
            this.label5 = new System.Windows.Forms.Label();
            this.txtSapProgram = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.syntaxBoxControl1 = new Alsing.Windows.Forms.SyntaxBoxControl();
            this.syntaxDocument1 = new Alsing.SourceCode.SyntaxDocument(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSearchReport = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnReadObjectFromSap = new System.Windows.Forms.Button();
            this.btnCancelSelect = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.txtTreeId = new System.Windows.Forms.TextBox();
            this.txtTreePath = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.cboxSystemList1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numPauseTime = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPauseTime)).BeginInit();
            this.SuspendLayout();
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
            this.txtSapProgram.Location = new System.Drawing.Point(184, 5);
            this.txtSapProgram.Name = "txtSapProgram";
            this.txtSapProgram.Size = new System.Drawing.Size(363, 21);
            this.txtSapProgram.TabIndex = 14;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(582, 30);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(111, 23);
            this.btnLoad.TabIndex = 16;
            this.btnLoad.Text = "读取程序(方法2)";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
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
            this.syntaxBoxControl1.Size = new System.Drawing.Size(272, 415);
            this.syntaxBoxControl1.SmoothScroll = false;
            this.syntaxBoxControl1.SplitviewH = -4;
            this.syntaxBoxControl1.SplitviewV = -4;
            this.syntaxBoxControl1.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.syntaxBoxControl1.TabIndex = 17;
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
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(415, 415);
            this.dataGridView1.TabIndex = 20;
            // 
            // btnSearchReport
            // 
            this.btnSearchReport.Location = new System.Drawing.Point(184, 32);
            this.btnSearchReport.Name = "btnSearchReport";
            this.btnSearchReport.Size = new System.Drawing.Size(75, 23);
            this.btnSearchReport.TabIndex = 21;
            this.btnSearchReport.Text = "搜索";
            this.btnSearchReport.UseVisualStyleBackColor = true;
            this.btnSearchReport.Click += new System.EventHandler(this.btnSearchReport_Click);
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
            this.splitContainer1.Size = new System.Drawing.Size(691, 415);
            this.splitContainer1.SplitterDistance = 415;
            this.splitContainer1.TabIndex = 22;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(351, 32);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(79, 23);
            this.btnImport.TabIndex = 23;
            this.btnImport.Text = "导入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnReadObjectFromSap
            // 
            this.btnReadObjectFromSap.Location = new System.Drawing.Point(265, 32);
            this.btnReadObjectFromSap.Name = "btnReadObjectFromSap";
            this.btnReadObjectFromSap.Size = new System.Drawing.Size(80, 23);
            this.btnReadObjectFromSap.TabIndex = 24;
            this.btnReadObjectFromSap.Text = "读取程序";
            this.btnReadObjectFromSap.UseVisualStyleBackColor = true;
            this.btnReadObjectFromSap.Click += new System.EventHandler(this.btnReadObjectFromSap_Click);
            // 
            // btnCancelSelect
            // 
            this.btnCancelSelect.Location = new System.Drawing.Point(93, 32);
            this.btnCancelSelect.Name = "btnCancelSelect";
            this.btnCancelSelect.Size = new System.Drawing.Size(75, 23);
            this.btnCancelSelect.TabIndex = 26;
            this.btnCancelSelect.Text = "取消选择";
            this.btnCancelSelect.UseVisualStyleBackColor = true;
            this.btnCancelSelect.Click += new System.EventHandler(this.btnCancelSelect_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(12, 32);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 25;
            this.btnSelect.Text = "批量选择";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtTreeId
            // 
            this.txtTreeId.Location = new System.Drawing.Point(13, 57);
            this.txtTreeId.Name = "txtTreeId";
            this.txtTreeId.ReadOnly = true;
            this.txtTreeId.Size = new System.Drawing.Size(246, 21);
            this.txtTreeId.TabIndex = 29;
            // 
            // txtTreePath
            // 
            this.txtTreePath.Location = new System.Drawing.Point(265, 57);
            this.txtTreePath.Name = "txtTreePath";
            this.txtTreePath.ReadOnly = true;
            this.txtTreePath.Size = new System.Drawing.Size(340, 21);
            this.txtTreePath.TabIndex = 30;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(621, 56);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(31, 21);
            this.button5.TabIndex = 26;
            this.button5.Text = "<";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(658, 56);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(31, 21);
            this.button6.TabIndex = 25;
            this.button6.Text = ">";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // cboxSystemList1
            // 
            this.cboxSystemList1.FormattingEnabled = true;
            this.cboxSystemList1.Location = new System.Drawing.Point(13, 3);
            this.cboxSystemList1.Name = "cboxSystemList1";
            this.cboxSystemList1.Size = new System.Drawing.Size(102, 20);
            this.cboxSystemList1.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(437, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 33;
            this.label1.Text = "暂停时间(毫秒)";
            // 
            // numPauseTime
            // 
            this.numPauseTime.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numPauseTime.Location = new System.Drawing.Point(532, 35);
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
            // FormImporSapProgram
            // 
            this.AcceptButton = this.btnSearchReport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 501);
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
            this.Name = "FormImporSapProgram";
            this.Text = "导入SAP程序";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numPauseTime)).EndInit();
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
    }
}
