namespace SAPINT.Gui.Idocs
{
    partial class FormIdocCopy
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
            this.txtIdocNumber = new System.Windows.Forms.TextBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.cbxSapSystem = new System.Windows.Forms.ComboBox();
            this.cbxDbConnection = new System.Windows.Forms.ComboBox();
            this.checkboxAppend = new System.Windows.Forms.CheckBox();
            this.btnDecombileIdoc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtIdocNumber
            // 
            this.txtIdocNumber.Location = new System.Drawing.Point(86, 41);
            this.txtIdocNumber.Name = "txtIdocNumber";
            this.txtIdocNumber.Size = new System.Drawing.Size(195, 21);
            this.txtIdocNumber.TabIndex = 0;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(86, 126);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(157, 23);
            this.btnCopy.TabIndex = 1;
            this.btnCopy.Text = "复制IDOC到本地";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // cbxSapSystem
            // 
            this.cbxSapSystem.FormattingEnabled = true;
            this.cbxSapSystem.Location = new System.Drawing.Point(86, 15);
            this.cbxSapSystem.Name = "cbxSapSystem";
            this.cbxSapSystem.Size = new System.Drawing.Size(121, 20);
            this.cbxSapSystem.TabIndex = 2;
            // 
            // cbxDbConnection
            // 
            this.cbxDbConnection.FormattingEnabled = true;
            this.cbxDbConnection.Location = new System.Drawing.Point(86, 68);
            this.cbxDbConnection.Name = "cbxDbConnection";
            this.cbxDbConnection.Size = new System.Drawing.Size(121, 20);
            this.cbxDbConnection.TabIndex = 3;
            // 
            // checkboxAppend
            // 
            this.checkboxAppend.AutoSize = true;
            this.checkboxAppend.Location = new System.Drawing.Point(86, 96);
            this.checkboxAppend.Name = "checkboxAppend";
            this.checkboxAppend.Size = new System.Drawing.Size(15, 14);
            this.checkboxAppend.TabIndex = 4;
            this.checkboxAppend.UseVisualStyleBackColor = true;
            // 
            // btnDecombileIdoc
            // 
            this.btnDecombileIdoc.Location = new System.Drawing.Point(86, 155);
            this.btnDecombileIdoc.Name = "btnDecombileIdoc";
            this.btnDecombileIdoc.Size = new System.Drawing.Size(157, 23);
            this.btnDecombileIdoc.TabIndex = 5;
            this.btnDecombileIdoc.Text = "从数据库读取并解析";
            this.btnDecombileIdoc.UseVisualStyleBackColor = true;
            this.btnDecombileIdoc.Click += new System.EventHandler(this.btnDecombileIdoc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "SAP系统:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "本地数据库:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "IDOC编号:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(111, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "附加到数据库";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 208);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(282, 207);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "根据Idoc编号从SAP系统复制idoc到本地数据库。\r\n本质上是直接复制远端SAP数据库表中的内容到本地。\r\n因此，可以使用其它方式把IDOC从SAP中批量导出" +
    "，\r\n再导入本地数据库。\r\n然后，再从本地数据库中读取IDOC，根据IDOC在\r\nSAP中的定义，把IDOC从文本形式反解析成可视化\r\n内容。";
            // 
            // FormIdocCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 449);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDecombileIdoc);
            this.Controls.Add(this.checkboxAppend);
            this.Controls.Add(this.cbxDbConnection);
            this.Controls.Add(this.cbxSapSystem);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.txtIdocNumber);
            this.Name = "FormIdocCopy";
            this.Text = "FormCopyIdoc";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIdocNumber;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.ComboBox cbxSapSystem;
        private System.Windows.Forms.ComboBox cbxDbConnection;
        private System.Windows.Forms.CheckBox checkboxAppend;
        private System.Windows.Forms.Button btnDecombileIdoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
    }
}
