namespace SAPINT.Gui.DataBase
{
    partial class FormSaveDataTable
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
            this.txtSapTableName = new System.Windows.Forms.TextBox();
            this.txtStructName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSapSystem = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtLocalDbConnection = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.labelRowsCount = new System.Windows.Forms.Label();
            this.btnSaveToDb = new System.Windows.Forms.Button();
            this.radioBtNew = new System.Windows.Forms.RadioButton();
            this.radioBtAppend = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLocalTableName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.btnSave2Excel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSapTableName
            // 
            this.txtSapTableName.Location = new System.Drawing.Point(85, 47);
            this.txtSapTableName.Name = "txtSapTableName";
            this.txtSapTableName.Size = new System.Drawing.Size(131, 21);
            this.txtSapTableName.TabIndex = 1;
            // 
            // txtStructName
            // 
            this.txtStructName.Location = new System.Drawing.Point(85, 74);
            this.txtStructName.Name = "txtStructName";
            this.txtStructName.Size = new System.Drawing.Size(131, 21);
            this.txtStructName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "SAP系统";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "表名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "结构名";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSapSystem);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSapTableName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtStructName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 121);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SAP";
            // 
            // txtSapSystem
            // 
            this.txtSapSystem.FormattingEnabled = true;
            this.txtSapSystem.Location = new System.Drawing.Point(85, 20);
            this.txtSapSystem.Name = "txtSapSystem";
            this.txtSapSystem.Size = new System.Drawing.Size(131, 20);
            this.txtSapSystem.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSave2Excel);
            this.groupBox2.Controls.Add(this.txtLocalDbConnection);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.labelRowsCount);
            this.groupBox2.Controls.Add(this.btnSaveToDb);
            this.groupBox2.Controls.Add(this.radioBtNew);
            this.groupBox2.Controls.Add(this.radioBtAppend);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtLocalTableName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(237, 180);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "本地数据库";
            // 
            // txtLocalDbConnection
            // 
            this.txtLocalDbConnection.FormattingEnabled = true;
            this.txtLocalDbConnection.Location = new System.Drawing.Point(68, 18);
            this.txtLocalDbConnection.Name = "txtLocalDbConnection";
            this.txtLocalDbConnection.Size = new System.Drawing.Size(152, 20);
            this.txtLocalDbConnection.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "行数目:";
            // 
            // labelRowsCount
            // 
            this.labelRowsCount.AutoSize = true;
            this.labelRowsCount.Location = new System.Drawing.Point(65, 147);
            this.labelRowsCount.Name = "labelRowsCount";
            this.labelRowsCount.Size = new System.Drawing.Size(29, 12);
            this.labelRowsCount.TabIndex = 10;
            this.labelRowsCount.Text = "数目";
            // 
            // btnSaveToDb
            // 
            this.btnSaveToDb.Location = new System.Drawing.Point(6, 110);
            this.btnSaveToDb.Name = "btnSaveToDb";
            this.btnSaveToDb.Size = new System.Drawing.Size(92, 23);
            this.btnSaveToDb.TabIndex = 7;
            this.btnSaveToDb.Text = "保存到数据库";
            this.btnSaveToDb.UseVisualStyleBackColor = true;
            this.btnSaveToDb.Click += new System.EventHandler(this.btnSaveToDb_Click);
            // 
            // radioBtNew
            // 
            this.radioBtNew.AutoSize = true;
            this.radioBtNew.Checked = true;
            this.radioBtNew.Location = new System.Drawing.Point(145, 78);
            this.radioBtNew.Name = "radioBtNew";
            this.radioBtNew.Size = new System.Drawing.Size(71, 16);
            this.radioBtNew.TabIndex = 6;
            this.radioBtNew.TabStop = true;
            this.radioBtNew.Text = "插入全新";
            this.radioBtNew.UseVisualStyleBackColor = true;
            // 
            // radioBtAppend
            // 
            this.radioBtAppend.AutoSize = true;
            this.radioBtAppend.Location = new System.Drawing.Point(68, 78);
            this.radioBtAppend.Name = "radioBtAppend";
            this.radioBtAppend.Size = new System.Drawing.Size(71, 16);
            this.radioBtAppend.TabIndex = 5;
            this.radioBtAppend.Text = "附加数据";
            this.radioBtAppend.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "表名";
            // 
            // txtLocalTableName
            // 
            this.txtLocalTableName.Location = new System.Drawing.Point(68, 44);
            this.txtLocalTableName.Name = "txtLocalTableName";
            this.txtLocalTableName.Size = new System.Drawing.Size(152, 21);
            this.txtLocalTableName.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "数据库";
            // 
            // textBoxLog
            // 
            this.textBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLog.Location = new System.Drawing.Point(255, 12);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxLog.Size = new System.Drawing.Size(266, 303);
            this.textBoxLog.TabIndex = 11;
            // 
            // btnSave2Excel
            // 
            this.btnSave2Excel.Location = new System.Drawing.Point(123, 110);
            this.btnSave2Excel.Name = "btnSave2Excel";
            this.btnSave2Excel.Size = new System.Drawing.Size(79, 23);
            this.btnSave2Excel.TabIndex = 11;
            this.btnSave2Excel.Text = "保存到EXCEL";
            this.btnSave2Excel.UseVisualStyleBackColor = true;
            this.btnSave2Excel.Click += new System.EventHandler(this.btnSave2Excel_Click);
            // 
            // FormSaveDataTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 327);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormSaveDataTable";
            this.Text = "保存数据";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSapTableName;
        private System.Windows.Forms.TextBox txtStructName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLocalTableName;
        private System.Windows.Forms.RadioButton radioBtNew;
        private System.Windows.Forms.RadioButton radioBtAppend;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelRowsCount;
        private System.Windows.Forms.Button btnSaveToDb;
        private System.Windows.Forms.ComboBox txtSapSystem;
        private System.Windows.Forms.ComboBox txtLocalDbConnection;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Button btnSave2Excel;
    }
}
