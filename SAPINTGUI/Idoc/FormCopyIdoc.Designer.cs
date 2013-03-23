namespace SAPINTGUI.Idoc
{
    partial class FormCopyIdoc
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
            this.SuspendLayout();
            // 
            // txtIdocNumber
            // 
            this.txtIdocNumber.Location = new System.Drawing.Point(189, 32);
            this.txtIdocNumber.Name = "txtIdocNumber";
            this.txtIdocNumber.Size = new System.Drawing.Size(195, 21);
            this.txtIdocNumber.TabIndex = 0;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(420, 30);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(108, 23);
            this.btnCopy.TabIndex = 1;
            this.btnCopy.Text = "复制IDOC到本地";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // cbxSapSystem
            // 
            this.cbxSapSystem.FormattingEnabled = true;
            this.cbxSapSystem.Location = new System.Drawing.Point(28, 32);
            this.cbxSapSystem.Name = "cbxSapSystem";
            this.cbxSapSystem.Size = new System.Drawing.Size(121, 20);
            this.cbxSapSystem.TabIndex = 2;
            // 
            // cbxDbConnection
            // 
            this.cbxDbConnection.FormattingEnabled = true;
            this.cbxDbConnection.Location = new System.Drawing.Point(28, 70);
            this.cbxDbConnection.Name = "cbxDbConnection";
            this.cbxDbConnection.Size = new System.Drawing.Size(121, 20);
            this.cbxDbConnection.TabIndex = 3;
            // 
            // checkboxAppend
            // 
            this.checkboxAppend.AutoSize = true;
            this.checkboxAppend.Location = new System.Drawing.Point(189, 70);
            this.checkboxAppend.Name = "checkboxAppend";
            this.checkboxAppend.Size = new System.Drawing.Size(96, 16);
            this.checkboxAppend.TabIndex = 4;
            this.checkboxAppend.Text = "附加到数据库";
            this.checkboxAppend.UseVisualStyleBackColor = true;
            // 
            // btnDecombileIdoc
            // 
            this.btnDecombileIdoc.Location = new System.Drawing.Point(420, 62);
            this.btnDecombileIdoc.Name = "btnDecombileIdoc";
            this.btnDecombileIdoc.Size = new System.Drawing.Size(108, 23);
            this.btnDecombileIdoc.TabIndex = 5;
            this.btnDecombileIdoc.Text = "解析IDOC";
            this.btnDecombileIdoc.UseVisualStyleBackColor = true;
            this.btnDecombileIdoc.Click += new System.EventHandler(this.btnDecombileIdoc_Click);
            // 
            // FormCopyIdoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 381);
            this.Controls.Add(this.btnDecombileIdoc);
            this.Controls.Add(this.checkboxAppend);
            this.Controls.Add(this.cbxDbConnection);
            this.Controls.Add(this.cbxSapSystem);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.txtIdocNumber);
            this.Name = "FormCopyIdoc";
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
    }
}