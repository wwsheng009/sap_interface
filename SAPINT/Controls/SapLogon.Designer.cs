namespace SAPINT.Controls
{
    partial class SapLogon
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region 组件设计器生成的代码
        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Server = new System.Windows.Forms.Label();
            this.txtAppServerHost = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSystemNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSystemId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtClient = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLanguage = new System.Windows.Forms.TextBox();
            this.cbxName = new System.Windows.Forms.ComboBox();
            this.btnloadsaplogonFile = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRouter = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(3, 250);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(201, 43);
            this.btnSubmit.TabIndex = 9;
            this.btnSubmit.Text = "登录SAP";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(3, 299);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(201, 23);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "删除配置";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name:";
            // 
            // Server
            // 
            this.Server.AutoSize = true;
            this.Server.Location = new System.Drawing.Point(5, 37);
            this.Server.Name = "Server";
            this.Server.Size = new System.Drawing.Size(47, 12);
            this.Server.TabIndex = 4;
            this.Server.Text = "Server:";
            // 
            // txtAppServerHost
            // 
            this.txtAppServerHost.Location = new System.Drawing.Point(58, 34);
            this.txtAppServerHost.Name = "txtAppServerHost";
            this.txtAppServerHost.Size = new System.Drawing.Size(150, 21);
            this.txtAppServerHost.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "SystemNumber:";
            // 
            // txtSystemNumber
            // 
            this.txtSystemNumber.Location = new System.Drawing.Point(117, 112);
            this.txtSystemNumber.Name = "txtSystemNumber";
            this.txtSystemNumber.Size = new System.Drawing.Size(91, 21);
            this.txtSystemNumber.TabIndex = 4;
            this.txtSystemNumber.Text = "00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "SystemID:";
            // 
            // txtSystemId
            // 
            this.txtSystemId.Location = new System.Drawing.Point(73, 85);
            this.txtSystemId.Name = "txtSystemId";
            this.txtSystemId.Size = new System.Drawing.Size(135, 21);
            this.txtSystemId.TabIndex = 3;
            this.txtSystemId.Text = "DEV";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "UserName:";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(73, 139);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(135, 21);
            this.txtUser.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(73, 167);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(135, 21);
            this.txtPassword.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "Client:";
            // 
            // txtClient
            // 
            this.txtClient.Location = new System.Drawing.Point(73, 194);
            this.txtClient.Name = "txtClient";
            this.txtClient.Size = new System.Drawing.Size(135, 21);
            this.txtClient.TabIndex = 7;
            this.txtClient.Text = "800";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Language:";
            // 
            // txtLanguage
            // 
            this.txtLanguage.Location = new System.Drawing.Point(73, 223);
            this.txtLanguage.Name = "txtLanguage";
            this.txtLanguage.Size = new System.Drawing.Size(135, 21);
            this.txtLanguage.TabIndex = 8;
            this.txtLanguage.Text = "ZH";
            // 
            // cbxName
            // 
            this.cbxName.FormattingEnabled = true;
            this.cbxName.Location = new System.Drawing.Point(58, 9);
            this.cbxName.Name = "cbxName";
            this.cbxName.Size = new System.Drawing.Size(150, 20);
            this.cbxName.TabIndex = 12;
            this.cbxName.SelectedIndexChanged += new System.EventHandler(this.cbxName_SelectedIndexChanged);
            // 
            // btnloadsaplogonFile
            // 
            this.btnloadsaplogonFile.Location = new System.Drawing.Point(3, 328);
            this.btnloadsaplogonFile.Name = "btnloadsaplogonFile";
            this.btnloadsaplogonFile.Size = new System.Drawing.Size(201, 23);
            this.btnloadsaplogonFile.TabIndex = 13;
            this.btnloadsaplogonFile.Text = "加载SAP GUI 配置";
            this.btnloadsaplogonFile.UseVisualStyleBackColor = true;
            this.btnloadsaplogonFile.Click += new System.EventHandler(this.btnloadsaplogonFile_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "Router:";
            // 
            // txtRouter
            // 
            this.txtRouter.Location = new System.Drawing.Point(58, 61);
            this.txtRouter.Name = "txtRouter";
            this.txtRouter.Size = new System.Drawing.Size(150, 21);
            this.txtRouter.TabIndex = 2;
            // 
            // SapLogon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnloadsaplogonFile);
            this.Controls.Add(this.cbxName);
            this.Controls.Add(this.txtLanguage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtClient);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSystemId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSystemNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRouter);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtAppServerHost);
            this.Controls.Add(this.Server);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSubmit);
            this.Name = "SapLogon";
            this.Size = new System.Drawing.Size(218, 364);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Server;
        private System.Windows.Forms.TextBox txtAppServerHost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSystemNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSystemId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtClient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLanguage;
        private System.Windows.Forms.ComboBox cbxName;
        private System.Windows.Forms.Button btnloadsaplogonFile;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRouter;
    }
}
