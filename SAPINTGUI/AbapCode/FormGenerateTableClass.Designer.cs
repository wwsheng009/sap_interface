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
            this.btnGenerateCode = new System.Windows.Forms.Button();
            this.cbxSystemList = new System.Windows.Forms.ComboBox();
            this.textBoxTableName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lable2 = new System.Windows.Forms.Label();
            this.btnGetTableDefinitioin = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBoxTemplate = new SyntaxHighlighter.SyntaxRichTextBox();
            this.textBoxResult = new SyntaxHighlighter.SyntaxRichTextBox();
            this.dgvFieldList = new System.Windows.Forms.DataGridView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
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
            this.btnGenerateCode.Location = new System.Drawing.Point(514, 10);
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
            this.cbxSystemList.Size = new System.Drawing.Size(121, 20);
            this.cbxSystemList.TabIndex = 1;
            // 
            // textBoxTableName
            // 
            this.textBoxTableName.Location = new System.Drawing.Point(250, 9);
            this.textBoxTableName.Name = "textBoxTableName";
            this.textBoxTableName.Size = new System.Drawing.Size(121, 21);
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
            this.btnGetTableDefinitioin.Location = new System.Drawing.Point(407, 10);
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
            this.textBoxTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTemplate.Location = new System.Drawing.Point(0, 0);
            this.textBoxTemplate.Name = "textBoxTemplate";
            this.textBoxTemplate.Size = new System.Drawing.Size(335, 206);
            this.textBoxTemplate.TabIndex = 0;
            this.textBoxTemplate.Text = "";
            // 
            // textBoxResult
            // 
            this.textBoxResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxResult.Location = new System.Drawing.Point(0, 0);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(335, 202);
            this.textBoxResult.TabIndex = 0;
            this.textBoxResult.Text = "";
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
            // FormGenerateTableClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 489);
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
            this.Text = "FormGenerateTableClass";
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
        private SyntaxHighlighter.SyntaxRichTextBox textBoxResult;
        private SyntaxHighlighter.SyntaxRichTextBox textBoxTemplate;
        private System.Windows.Forms.DataGridView dgvFieldList;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnCancle;
    }
}