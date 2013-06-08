namespace SAPINTCODE
{
    partial class FormGenerateTableClass
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
            this.btnGenerateCode = new System.Windows.Forms.Button();
            this.cbxSystemList = new System.Windows.Forms.ComboBox();
            this.textBoxTableName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lable2 = new System.Windows.Forms.Label();
            this.btnGetTableDefinitioin = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBoxTemplate = new Alsing.Windows.Forms.SyntaxBoxControl();
            this.syntaxDocument2 = new Alsing.SourceCode.SyntaxDocument(this.components);
            this.textBoxResult = new Alsing.Windows.Forms.SyntaxBoxControl();
            this.syntaxDocument3 = new Alsing.SourceCode.SyntaxDocument(this.components);
            this.dgvFieldList = new System.Windows.Forms.DataGridView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.syntaxDocument1 = new Alsing.SourceCode.SyntaxDocument(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFieldList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGenerateCode
            // 
            this.btnGenerateCode.Location = new System.Drawing.Point(491, 9);
            this.btnGenerateCode.Name = "btnGenerateCode";
            this.btnGenerateCode.Size = new System.Drawing.Size(75, 23);
            this.btnGenerateCode.TabIndex = 0;
            this.btnGenerateCode.Text = "生成代码";
            this.btnGenerateCode.UseVisualStyleBackColor = true;
            this.btnGenerateCode.Click += new System.EventHandler(this.btnGenerateCode_Click);
            // 
            // cbxSystemList
            // 
            this.cbxSystemList.FormattingEnabled = true;
            this.cbxSystemList.Location = new System.Drawing.Point(74, 12);
            this.cbxSystemList.Name = "cbxSystemList";
            this.cbxSystemList.Size = new System.Drawing.Size(136, 20);
            this.cbxSystemList.TabIndex = 1;
            // 
            // textBoxTableName
            // 
            this.textBoxTableName.Location = new System.Drawing.Point(239, 10);
            this.textBoxTableName.Name = "textBoxTableName";
            this.textBoxTableName.Size = new System.Drawing.Size(156, 21);
            this.textBoxTableName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "系统";
            // 
            // lable2
            // 
            this.lable2.AutoSize = true;
            this.lable2.Location = new System.Drawing.Point(216, 15);
            this.lable2.Name = "lable2";
            this.lable2.Size = new System.Drawing.Size(17, 12);
            this.lable2.TabIndex = 5;
            this.lable2.Text = "表";
            // 
            // btnGetTableDefinitioin
            // 
            this.btnGetTableDefinitioin.Location = new System.Drawing.Point(410, 10);
            this.btnGetTableDefinitioin.Name = "btnGetTableDefinitioin";
            this.btnGetTableDefinitioin.Size = new System.Drawing.Size(75, 23);
            this.btnGetTableDefinitioin.TabIndex = 7;
            this.btnGetTableDefinitioin.Text = "读取表定义";
            this.btnGetTableDefinitioin.UseVisualStyleBackColor = true;
            this.btnGetTableDefinitioin.Click += new System.EventHandler(this.btnGetTableDefinitioin_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBoxTemplate);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBoxResult);
            this.splitContainer1.Size = new System.Drawing.Size(335, 412);
            this.splitContainer1.SplitterDistance = 206;
            this.splitContainer1.TabIndex = 10;
            // 
            // textBoxTemplate
            // 
            this.textBoxTemplate.ActiveView = Alsing.Windows.Forms.ActiveView.BottomRight;
            this.textBoxTemplate.AutoListPosition = null;
            this.textBoxTemplate.AutoListSelectedText = "a123";
            this.textBoxTemplate.AutoListVisible = false;
            this.textBoxTemplate.BackColor = System.Drawing.Color.White;
            this.textBoxTemplate.BorderStyle = Alsing.Windows.Forms.BorderStyle.None;
            this.textBoxTemplate.CopyAsRTF = false;
            this.textBoxTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTemplate.Document = this.syntaxDocument2;
            this.textBoxTemplate.FontName = "Courier new";
            this.textBoxTemplate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBoxTemplate.InfoTipCount = 1;
            this.textBoxTemplate.InfoTipPosition = null;
            this.textBoxTemplate.InfoTipSelectedIndex = 1;
            this.textBoxTemplate.InfoTipVisible = false;
            this.textBoxTemplate.Location = new System.Drawing.Point(0, 0);
            this.textBoxTemplate.LockCursorUpdate = false;
            this.textBoxTemplate.Name = "textBoxTemplate";
            this.textBoxTemplate.ShowScopeIndicator = false;
            this.textBoxTemplate.Size = new System.Drawing.Size(335, 206);
            this.textBoxTemplate.SmoothScroll = false;
            this.textBoxTemplate.SplitviewH = -4;
            this.textBoxTemplate.SplitviewV = -4;
            this.textBoxTemplate.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.textBoxTemplate.TabIndex = 0;
            this.textBoxTemplate.Text = "syntaxBoxControl1";
            this.textBoxTemplate.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
            // 
            // syntaxDocument2
            // 
            this.syntaxDocument2.Lines = new string[] {
        ""};
            this.syntaxDocument2.MaxUndoBufferSize = 1000;
            this.syntaxDocument2.Modified = false;
            this.syntaxDocument2.UndoStep = 0;
            // 
            // textBoxResult
            // 
            this.textBoxResult.ActiveView = Alsing.Windows.Forms.ActiveView.BottomRight;
            this.textBoxResult.AutoListPosition = null;
            this.textBoxResult.AutoListSelectedText = "a123";
            this.textBoxResult.AutoListVisible = false;
            this.textBoxResult.BackColor = System.Drawing.Color.White;
            this.textBoxResult.BorderStyle = Alsing.Windows.Forms.BorderStyle.None;
            this.textBoxResult.CopyAsRTF = false;
            this.textBoxResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxResult.Document = this.syntaxDocument3;
            this.textBoxResult.FontName = "Courier new";
            this.textBoxResult.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBoxResult.InfoTipCount = 1;
            this.textBoxResult.InfoTipPosition = null;
            this.textBoxResult.InfoTipSelectedIndex = 1;
            this.textBoxResult.InfoTipVisible = false;
            this.textBoxResult.Location = new System.Drawing.Point(0, 0);
            this.textBoxResult.LockCursorUpdate = false;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.ShowScopeIndicator = false;
            this.textBoxResult.Size = new System.Drawing.Size(335, 202);
            this.textBoxResult.SmoothScroll = false;
            this.textBoxResult.SplitviewH = -4;
            this.textBoxResult.SplitviewV = -4;
            this.textBoxResult.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.textBoxResult.TabIndex = 0;
            this.textBoxResult.Text = "syntaxBoxControl1";
            this.textBoxResult.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
            // 
            // syntaxDocument3
            // 
            this.syntaxDocument3.Lines = new string[] {
        ""};
            this.syntaxDocument3.MaxUndoBufferSize = 1000;
            this.syntaxDocument3.Modified = false;
            this.syntaxDocument3.UndoStep = 0;
            // 
            // dgvFieldList
            // 
            this.dgvFieldList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFieldList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFieldList.Location = new System.Drawing.Point(0, 0);
            this.dgvFieldList.Name = "dgvFieldList";
            this.dgvFieldList.RowTemplate.Height = 23;
            this.dgvFieldList.Size = new System.Drawing.Size(321, 412);
            this.dgvFieldList.TabIndex = 11;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(12, 65);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvFieldList);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(660, 412);
            this.splitContainer2.SplitterDistance = 321;
            this.splitContainer2.TabIndex = 12;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(14, 38);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 13;
            this.btnSelect.Text = "选中";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(95, 38);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 14;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // syntaxDocument1
            // 
            this.syntaxDocument1.Lines = new string[] {
        ""};
            this.syntaxDocument1.MaxUndoBufferSize = 1000;
            this.syntaxDocument1.Modified = false;
            this.syntaxDocument1.UndoStep = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(636, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "▼";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(593, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(37, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "▲";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(547, 39);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = ">";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(505, 39);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(36, 23);
            this.button4.TabIndex = 18;
            this.button4.Text = "<";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // FormGenerateTableClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 489);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.btnGetTableDefinitioin);
            this.Controls.Add(this.lable2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxTableName);
            this.Controls.Add(this.cbxSystemList);
            this.Controls.Add(this.btnGenerateCode);
            this.Name = "FormGenerateTableClass";
            this.Text = "根据结构字段生成代码";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFieldList)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateCode;
        private System.Windows.Forms.ComboBox cbxSystemList;
        private System.Windows.Forms.TextBox textBoxTableName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lable2;
        private System.Windows.Forms.Button btnGetTableDefinitioin;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvFieldList;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnCancle;
        private Alsing.SourceCode.SyntaxDocument syntaxDocument1;
        private Alsing.Windows.Forms.SyntaxBoxControl textBoxTemplate;
        private Alsing.SourceCode.SyntaxDocument syntaxDocument2;
        private Alsing.Windows.Forms.SyntaxBoxControl textBoxResult;
        private Alsing.SourceCode.SyntaxDocument syntaxDocument3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}
