namespace SAPINT.Gui.Functions
{
    partial class FormSearchRfcFunction
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbxSapClientList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtRfcFunctionName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRfcFunctionText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFuncGroup = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(14, 109);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(229, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "搜索RFC函数";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbxSapClientList
            // 
            this.cbxSapClientList.FormattingEnabled = true;
            this.cbxSapClientList.Location = new System.Drawing.Point(65, 6);
            this.cbxSapClientList.Name = "cbxSapClientList";
            this.cbxSapClientList.Size = new System.Drawing.Size(121, 20);
            this.cbxSapClientList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "SAP系统";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(14, 138);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(229, 356);
            this.dataGridView1.TabIndex = 3;
            // 
            // txtRfcFunctionName
            // 
            this.txtRfcFunctionName.Location = new System.Drawing.Point(65, 29);
            this.txtRfcFunctionName.Name = "txtRfcFunctionName";
            this.txtRfcFunctionName.Size = new System.Drawing.Size(185, 21);
            this.txtRfcFunctionName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "RFC函数";
            // 
            // txtRfcFunctionText
            // 
            this.txtRfcFunctionText.Location = new System.Drawing.Point(65, 56);
            this.txtRfcFunctionText.Name = "txtRfcFunctionText";
            this.txtRfcFunctionText.Size = new System.Drawing.Size(185, 21);
            this.txtRfcFunctionText.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "文本";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "函数组";
            // 
            // txtFuncGroup
            // 
            this.txtFuncGroup.Location = new System.Drawing.Point(65, 79);
            this.txtFuncGroup.Name = "txtFuncGroup";
            this.txtFuncGroup.Size = new System.Drawing.Size(100, 21);
            this.txtFuncGroup.TabIndex = 10;
            // 
            // FormSearchRfcFunction
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 506);
            this.Controls.Add(this.txtFuncGroup);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRfcFunctionText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRfcFunctionName);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxSapClientList);
            this.Controls.Add(this.btnSearch);
            this.Name = "FormSearchRfcFunction";
            this.Text = "搜索RFC函数";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cbxSapClientList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtRfcFunctionName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRfcFunctionText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFuncGroup;
    }
}
