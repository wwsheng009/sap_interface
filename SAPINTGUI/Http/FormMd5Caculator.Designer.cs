namespace SAPINT.Gui.Http
{
    partial class FormMd5Caculator
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
            this.txtSource = new System.Windows.Forms.TextBox();
            this.btnCaculate = new System.Windows.Forms.Button();
            this.txtMd5Result = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSource
            // 
            this.txtSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSource.Location = new System.Drawing.Point(3, 41);
            this.txtSource.Multiline = true;
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(619, 444);
            this.txtSource.TabIndex = 0;
            // 
            // btnCaculate
            // 
            this.btnCaculate.Location = new System.Drawing.Point(12, 12);
            this.btnCaculate.Name = "btnCaculate";
            this.btnCaculate.Size = new System.Drawing.Size(75, 23);
            this.btnCaculate.TabIndex = 1;
            this.btnCaculate.Text = "计算MD5";
            this.btnCaculate.UseVisualStyleBackColor = true;
            this.btnCaculate.Click += new System.EventHandler(this.btnCaculate_Click);
            // 
            // txtMd5Result
            // 
            this.txtMd5Result.Location = new System.Drawing.Point(174, 12);
            this.txtMd5Result.Name = "txtMd5Result";
            this.txtMd5Result.ReadOnly = true;
            this.txtMd5Result.Size = new System.Drawing.Size(354, 21);
            this.txtMd5Result.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "结果";
            // 
            // FormMd5Caculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 488);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMd5Result);
            this.Controls.Add(this.btnCaculate);
            this.Controls.Add(this.txtSource);
            this.Name = "FormMd5Caculator";
            this.Text = "FormMd5Caculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Button btnCaculate;
        private System.Windows.Forms.TextBox txtMd5Result;
        private System.Windows.Forms.Label label1;
    }
}