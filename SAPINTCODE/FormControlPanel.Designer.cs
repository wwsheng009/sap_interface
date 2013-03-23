namespace SAPINTCODE
{
    partial class FormControlPanel
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
            this.btnGenerateClass = new System.Windows.Forms.Button();
            this.btnAbapCode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGenerateClass
            // 
            this.btnGenerateClass.Location = new System.Drawing.Point(13, 13);
            this.btnGenerateClass.Name = "btnGenerateClass";
            this.btnGenerateClass.Size = new System.Drawing.Size(162, 23);
            this.btnGenerateClass.TabIndex = 0;
            this.btnGenerateClass.Text = "SAP表生成类";
            this.btnGenerateClass.UseVisualStyleBackColor = true;
            this.btnGenerateClass.Click += new System.EventHandler(this.btnGenerateClass_Click);
            // 
            // btnAbapCode
            // 
            this.btnAbapCode.Location = new System.Drawing.Point(13, 58);
            this.btnAbapCode.Name = "btnAbapCode";
            this.btnAbapCode.Size = new System.Drawing.Size(162, 23);
            this.btnAbapCode.TabIndex = 1;
            this.btnAbapCode.Text = "SAP代码生成";
            this.btnAbapCode.UseVisualStyleBackColor = true;
            this.btnAbapCode.Click += new System.EventHandler(this.btnAbapCode_Click);
            // 
            // FormControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 432);
            this.Controls.Add(this.btnAbapCode);
            this.Controls.Add(this.btnGenerateClass);
            this.Name = "FormControlPanel";
            this.Text = "FormControlPanel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateClass;
        private System.Windows.Forms.Button btnAbapCode;
    }
}