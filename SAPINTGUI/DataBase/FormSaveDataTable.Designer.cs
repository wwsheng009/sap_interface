namespace SAPINTGUI.DataBase
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
            this.btnSaveToDb = new System.Windows.Forms.Button();
            this.radioBtNew = new System.Windows.Forms.RadioButton();
            this.radioBtAppend = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLocalTableName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.labelRowsCount = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSapTableName
            // 
            this.txtSapTableName.Location = new System.Drawing.Point(128, 53);
            this.txtSapTableName.Name = "txtSapTableName";
            this.txtSapTableName.Size = new System.Drawing.Size(131, 21);
            this.txtSapTableName.TabIndex = 1;
            // 
            // txtStructName
            // 
            this.txtStructName.Location = new System.Drawing.Point(128, 80);
            this.txtStructName.Name = "txtStructName";
            this.txtStructName.Size = new System.Drawing.Size(131, 21);
            this.txtStructName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "SAP系统";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "表名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 83);
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
            this.groupBox1.Location = new System.Drawing.Point(21, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 121);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SAP";
            // 
            // txtSapSystem
            // 
            this.txtSapSystem.FormattingEnabled = true;
            this.txtSapSystem.Location = new System.Drawing.Point(128, 26);
            this.txtSapSystem.Name = "txtSapSystem";
            this.txtSapSystem.Size = new System.Drawing.Size(131, 20);
            this.txtSapSystem.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtLocalDbConnection);
            this.groupBox2.Controls.Add(this.btnSaveToDb);
            this.groupBox2.Controls.Add(this.radioBtNew);
            this.groupBox2.Controls.Add(this.radioBtAppend);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtLocalTableName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(21, 169);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(265, 240);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "本地数据库";
            // 
            // txtLocalDbConnection
            // 
            this.txtLocalDbConnection.FormattingEnabled = true;
            this.txtLocalDbConnection.Location = new System.Drawing.Point(128, 18);
            this.txtLocalDbConnection.Name = "txtLocalDbConnection";
            this.txtLocalDbConnection.Size = new System.Drawing.Size(131, 20);
            this.txtLocalDbConnection.TabIndex = 9;
            // 
            // btnSaveToDb
            // 
            this.btnSaveToDb.Location = new System.Drawing.Point(128, 151);
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
            this.radioBtNew.Location = new System.Drawing.Point(128, 100);
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
            this.radioBtAppend.Location = new System.Drawing.Point(128, 78);
            this.radioBtAppend.Name = "radioBtAppend";
            this.radioBtAppend.Size = new System.Drawing.Size(71, 16);
            this.radioBtAppend.TabIndex = 5;
            this.radioBtAppend.TabStop = true;
            this.radioBtAppend.Text = "附加数据";
            this.radioBtAppend.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(81, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "表名";
            // 
            // txtLocalTableName
            // 
            this.txtLocalTableName.Location = new System.Drawing.Point(128, 51);
            this.txtLocalTableName.Name = "txtLocalTableName";
            this.txtLocalTableName.Size = new System.Drawing.Size(131, 21);
            this.txtLocalTableName.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "本地数据库连接";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(331, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(420, 392);
            this.dataGridView1.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(329, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "行数目:";
            // 
            // labelRowsCount
            // 
            this.labelRowsCount.AutoSize = true;
            this.labelRowsCount.Location = new System.Drawing.Point(383, 32);
            this.labelRowsCount.Name = "labelRowsCount";
            this.labelRowsCount.Size = new System.Drawing.Size(0, 12);
            this.labelRowsCount.TabIndex = 10;
            // 
            // FormSaveDataTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 466);
            this.Controls.Add(this.labelRowsCount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormSaveDataTable";
            this.Text = "FormSaveDataTable";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelRowsCount;
        private System.Windows.Forms.Button btnSaveToDb;
        private System.Windows.Forms.ComboBox txtSapSystem;
        private System.Windows.Forms.ComboBox txtLocalDbConnection;
    }
}