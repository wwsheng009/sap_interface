namespace SAPINT.Gui.CodeManager
{
    partial class FormScreenGernerator
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
            this.btnGetScreenFields = new System.Windows.Forms.Button();
            this.cbxSystem = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProg = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnGernerateCode = new System.Windows.Forms.Button();
            this.cbxDynnr = new System.Windows.Forms.ComboBox();
            this.txtUsdLine = new System.Windows.Forms.TextBox();
            this.txtUsedCol = new System.Windows.Forms.TextBox();
            this.txtTotalLine = new System.Windows.Forms.TextBox();
            this.txtTotalCol = new System.Windows.Forms.TextBox();
            this.btnGernerateScreen = new System.Windows.Forms.Button();
            this.txtTitle = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetScreenFields
            // 
            this.btnGetScreenFields.Location = new System.Drawing.Point(503, 36);
            this.btnGetScreenFields.Name = "btnGetScreenFields";
            this.btnGetScreenFields.Size = new System.Drawing.Size(122, 23);
            this.btnGetScreenFields.TabIndex = 0;
            this.btnGetScreenFields.Text = "读取屏幕字段清单";
            this.btnGetScreenFields.UseVisualStyleBackColor = true;
            this.btnGetScreenFields.Click += new System.EventHandler(this.btnGetScreenFields_Click);
            // 
            // cbxSystem
            // 
            this.cbxSystem.FormattingEnabled = true;
            this.cbxSystem.Location = new System.Drawing.Point(81, 12);
            this.cbxSystem.Name = "cbxSystem";
            this.cbxSystem.Size = new System.Drawing.Size(121, 20);
            this.cbxSystem.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "系统";
            // 
            // txtProg
            // 
            this.txtProg.Location = new System.Drawing.Point(81, 38);
            this.txtProg.Name = "txtProg";
            this.txtProg.Size = new System.Drawing.Size(260, 21);
            this.txtProg.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "程序";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "屏幕";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 103);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(770, 406);
            this.dataGridView1.TabIndex = 7;
            // 
            // btnGernerateCode
            // 
            this.btnGernerateCode.Location = new System.Drawing.Point(631, 36);
            this.btnGernerateCode.Name = "btnGernerateCode";
            this.btnGernerateCode.Size = new System.Drawing.Size(135, 23);
            this.btnGernerateCode.TabIndex = 8;
            this.btnGernerateCode.Text = "生成代码";
            this.btnGernerateCode.UseVisualStyleBackColor = true;
            this.btnGernerateCode.Click += new System.EventHandler(this.btnGernerateCode_Click);
            // 
            // cbxDynnr
            // 
            this.cbxDynnr.FormattingEnabled = true;
            this.cbxDynnr.Location = new System.Drawing.Point(81, 66);
            this.cbxDynnr.Name = "cbxDynnr";
            this.cbxDynnr.Size = new System.Drawing.Size(121, 20);
            this.cbxDynnr.TabIndex = 9;
            // 
            // txtUsdLine
            // 
            this.txtUsdLine.Location = new System.Drawing.Point(347, 12);
            this.txtUsdLine.Name = "txtUsdLine";
            this.txtUsdLine.Size = new System.Drawing.Size(32, 21);
            this.txtUsdLine.TabIndex = 11;
            // 
            // txtUsedCol
            // 
            this.txtUsedCol.Location = new System.Drawing.Point(385, 12);
            this.txtUsedCol.Name = "txtUsedCol";
            this.txtUsedCol.Size = new System.Drawing.Size(28, 21);
            this.txtUsedCol.TabIndex = 11;
            // 
            // txtTotalLine
            // 
            this.txtTotalLine.Location = new System.Drawing.Point(347, 38);
            this.txtTotalLine.Name = "txtTotalLine";
            this.txtTotalLine.Size = new System.Drawing.Size(32, 21);
            this.txtTotalLine.TabIndex = 11;
            // 
            // txtTotalCol
            // 
            this.txtTotalCol.Location = new System.Drawing.Point(385, 39);
            this.txtTotalCol.Name = "txtTotalCol";
            this.txtTotalCol.Size = new System.Drawing.Size(28, 21);
            this.txtTotalCol.TabIndex = 11;
            // 
            // btnGernerateScreen
            // 
            this.btnGernerateScreen.Location = new System.Drawing.Point(631, 68);
            this.btnGernerateScreen.Name = "btnGernerateScreen";
            this.btnGernerateScreen.Size = new System.Drawing.Size(135, 23);
            this.btnGernerateScreen.TabIndex = 12;
            this.btnGernerateScreen.Text = "模拟屏幕";
            this.btnGernerateScreen.UseVisualStyleBackColor = true;
            this.btnGernerateScreen.Click += new System.EventHandler(this.btnGernerateScreen_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(209, 66);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(311, 21);
            this.txtTitle.TabIndex = 13;
            // 
            // FormScreenGernerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 521);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.btnGernerateScreen);
            this.Controls.Add(this.txtTotalCol);
            this.Controls.Add(this.txtTotalLine);
            this.Controls.Add(this.txtUsedCol);
            this.Controls.Add(this.txtUsdLine);
            this.Controls.Add(this.cbxDynnr);
            this.Controls.Add(this.btnGernerateCode);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxSystem);
            this.Controls.Add(this.btnGetScreenFields);
            this.Name = "FormScreenGernerator";
            this.Text = "FormScreenGernerator";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetScreenFields;
        private System.Windows.Forms.ComboBox cbxSystem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnGernerateCode;
        private System.Windows.Forms.ComboBox cbxDynnr;
        private System.Windows.Forms.TextBox txtUsdLine;
        private System.Windows.Forms.TextBox txtUsedCol;
        private System.Windows.Forms.TextBox txtTotalLine;
        private System.Windows.Forms.TextBox txtTotalCol;
        private System.Windows.Forms.Button btnGernerateScreen;
        private System.Windows.Forms.TextBox txtTitle;
    }
}