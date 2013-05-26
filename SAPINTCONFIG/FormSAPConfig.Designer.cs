namespace ConfigFileTool
{
    partial class FormSAPConfig
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxSAPServer = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxDb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxSAPClient = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReadConfig = new System.Windows.Forms.Button();
            this.btnWriteConfig = new System.Windows.Forms.Button();
            this.txtKeyValues = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxSAPServer);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbxDb);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbxSAPClient);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(484, 75);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "默认设置";
            // 
            // cbxSAPServer
            // 
            this.cbxSAPServer.FormattingEnabled = true;
            this.cbxSAPServer.Location = new System.Drawing.Point(95, 44);
            this.cbxSAPServer.Name = "cbxSAPServer";
            this.cbxSAPServer.Size = new System.Drawing.Size(143, 20);
            this.cbxSAPServer.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "默认SAP服务器";
            // 
            // cbxDb
            // 
            this.cbxDb.FormattingEnabled = true;
            this.cbxDb.Location = new System.Drawing.Point(333, 18);
            this.cbxDb.Name = "cbxDb";
            this.cbxDb.Size = new System.Drawing.Size(121, 20);
            this.cbxDb.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "默认数据库";
            // 
            // cbxSAPClient
            // 
            this.cbxSAPClient.FormattingEnabled = true;
            this.cbxSAPClient.Location = new System.Drawing.Point(95, 18);
            this.cbxSAPClient.Name = "cbxSAPClient";
            this.cbxSAPClient.Size = new System.Drawing.Size(143, 20);
            this.cbxSAPClient.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "默认SAP客户端";
            // 
            // btnReadConfig
            // 
            this.btnReadConfig.Location = new System.Drawing.Point(15, 464);
            this.btnReadConfig.Name = "btnReadConfig";
            this.btnReadConfig.Size = new System.Drawing.Size(110, 23);
            this.btnReadConfig.TabIndex = 2;
            this.btnReadConfig.Text = "读取设置文件";
            this.btnReadConfig.UseVisualStyleBackColor = true;
            this.btnReadConfig.Click += new System.EventHandler(this.btnReadConfig_Click);
            // 
            // btnWriteConfig
            // 
            this.btnWriteConfig.Location = new System.Drawing.Point(147, 464);
            this.btnWriteConfig.Name = "btnWriteConfig";
            this.btnWriteConfig.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnWriteConfig.Size = new System.Drawing.Size(127, 23);
            this.btnWriteConfig.TabIndex = 3;
            this.btnWriteConfig.Text = "保存设置文件";
            this.btnWriteConfig.UseVisualStyleBackColor = true;
            this.btnWriteConfig.Click += new System.EventHandler(this.btnWriteConfig_Click);
            // 
            // txtKeyValues
            // 
            this.txtKeyValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKeyValues.Location = new System.Drawing.Point(3, 17);
            this.txtKeyValues.Multiline = true;
            this.txtKeyValues.Name = "txtKeyValues";
            this.txtKeyValues.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtKeyValues.Size = new System.Drawing.Size(478, 345);
            this.txtKeyValues.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtKeyValues);
            this.groupBox2.Location = new System.Drawing.Point(12, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(484, 365);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "全局设置";
            // 
            // FormSAPConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 516);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnWriteConfig);
            this.Controls.Add(this.btnReadConfig);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormSAPConfig";
            this.Text = "SAP配置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxSAPClient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxDb;
        private System.Windows.Forms.Button btnReadConfig;
        private System.Windows.Forms.Button btnWriteConfig;
        private System.Windows.Forms.TextBox txtKeyValues;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbxSAPServer;
        private System.Windows.Forms.Label label3;
    }
}
