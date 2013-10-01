namespace SAPINT.Gui.CodeManager
{
    partial class FormAlvGernerator
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
            this.btnGernerate = new System.Windows.Forms.Button();
            this.btCheckSettings = new System.Windows.Forms.Button();
            this.btnUpdateHeaderInfo = new System.Windows.Forms.Button();
            this.btnUpdateSettings = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProgramName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.txtHeaderInfo = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvLayout = new System.Windows.Forms.DataGridView();
            this.chxTrafficLight = new System.Windows.Forms.CheckBox();
            this.chxAddBox = new System.Windows.Forms.CheckBox();
            this.chxEditable = new System.Windows.Forms.CheckBox();
            this.chxAddHeaderPage = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chxList_alv_grid_events = new System.Windows.Forms.CheckedListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvFieldCat = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbxCategory = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLayout)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFieldCat)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGernerate);
            this.groupBox1.Controls.Add(this.btCheckSettings);
            this.groupBox1.Controls.Add(this.btnUpdateHeaderInfo);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(577, 47);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "一般选项";
            // 
            // btnGernerate
            // 
            this.btnGernerate.Location = new System.Drawing.Point(486, 18);
            this.btnGernerate.Name = "btnGernerate";
            this.btnGernerate.Size = new System.Drawing.Size(75, 23);
            this.btnGernerate.TabIndex = 8;
            this.btnGernerate.Text = "生成代码";
            this.btnGernerate.UseVisualStyleBackColor = true;
            this.btnGernerate.Click += new System.EventHandler(this.btnGernerate_Click);
            // 
            // btCheckSettings
            // 
            this.btCheckSettings.Location = new System.Drawing.Point(163, 18);
            this.btCheckSettings.Name = "btCheckSettings";
            this.btCheckSettings.Size = new System.Drawing.Size(75, 23);
            this.btCheckSettings.TabIndex = 3;
            this.btCheckSettings.Text = "更新设定";
            this.btCheckSettings.UseVisualStyleBackColor = true;
            this.btCheckSettings.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnUpdateHeaderInfo
            // 
            this.btnUpdateHeaderInfo.Location = new System.Drawing.Point(6, 18);
            this.btnUpdateHeaderInfo.Name = "btnUpdateHeaderInfo";
            this.btnUpdateHeaderInfo.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateHeaderInfo.TabIndex = 10;
            this.btnUpdateHeaderInfo.Text = "更新抬头";
            this.btnUpdateHeaderInfo.UseVisualStyleBackColor = true;
            this.btnUpdateHeaderInfo.Click += new System.EventHandler(this.btnUpdateHeaderInfo_Click);
            // 
            // btnUpdateSettings
            // 
            this.btnUpdateSettings.Location = new System.Drawing.Point(472, 3);
            this.btnUpdateSettings.Name = "btnUpdateSettings";
            this.btnUpdateSettings.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateSettings.TabIndex = 8;
            this.btnUpdateSettings.Text = "更新设置";
            this.btnUpdateSettings.UseVisualStyleBackColor = true;
            this.btnUpdateSettings.Click += new System.EventHandler(this.btnUpdateSettings_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "程序名：";
            // 
            // txtProgramName
            // 
            this.txtProgramName.Location = new System.Drawing.Point(86, 88);
            this.txtProgramName.Name = "txtProgramName";
            this.txtProgramName.Size = new System.Drawing.Size(208, 21);
            this.txtProgramName.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "抬头文本：";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(86, 61);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(208, 21);
            this.txtTitle.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(22, 65);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(567, 443);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.txtDescription);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Controls.Add(this.txtProjectName);
            this.tabPage4.Controls.Add(this.txtProgramName);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.txtHeaderInfo);
            this.tabPage4.Controls.Add(this.txtAuthor);
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.txtTitle);
            this.tabPage4.Controls.Add(this.dateTimePicker1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(559, 417);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "抬头";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "描述：";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(86, 143);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(378, 63);
            this.txtDescription.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "项目名称：";
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(86, 116);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(208, 21);
            this.txtProjectName.TabIndex = 8;
            // 
            // txtHeaderInfo
            // 
            this.txtHeaderInfo.Location = new System.Drawing.Point(6, 241);
            this.txtHeaderInfo.Multiline = true;
            this.txtHeaderInfo.Name = "txtHeaderInfo";
            this.txtHeaderInfo.Size = new System.Drawing.Size(458, 168);
            this.txtHeaderInfo.TabIndex = 4;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(86, 34);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(132, 21);
            this.txtAuthor.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "创建人：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "创建时间：";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(86, 6);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(132, 21);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbxCategory);
            this.tabPage1.Controls.Add(this.dgvLayout);
            this.tabPage1.Controls.Add(this.chxTrafficLight);
            this.tabPage1.Controls.Add(this.chxAddBox);
            this.tabPage1.Controls.Add(this.chxEditable);
            this.tabPage1.Controls.Add(this.chxAddHeaderPage);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(559, 417);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "函数ALV";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvLayout
            // 
            this.dgvLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLayout.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLayout.Location = new System.Drawing.Point(213, 6);
            this.dgvLayout.Name = "dgvLayout";
            this.dgvLayout.RowTemplate.Height = 23;
            this.dgvLayout.Size = new System.Drawing.Size(334, 383);
            this.dgvLayout.TabIndex = 10;
            // 
            // chxTrafficLight
            // 
            this.chxTrafficLight.AutoSize = true;
            this.chxTrafficLight.Location = new System.Drawing.Point(25, 102);
            this.chxTrafficLight.Name = "chxTrafficLight";
            this.chxTrafficLight.Size = new System.Drawing.Size(84, 16);
            this.chxTrafficLight.TabIndex = 5;
            this.chxTrafficLight.Text = "增加交通灯";
            this.chxTrafficLight.UseVisualStyleBackColor = true;
            // 
            // chxAddBox
            // 
            this.chxAddBox.AutoSize = true;
            this.chxAddBox.Location = new System.Drawing.Point(25, 58);
            this.chxAddBox.Name = "chxAddBox";
            this.chxAddBox.Size = new System.Drawing.Size(72, 16);
            this.chxAddBox.TabIndex = 6;
            this.chxAddBox.Text = "增加方框";
            this.chxAddBox.UseVisualStyleBackColor = true;
            // 
            // chxEditable
            // 
            this.chxEditable.AutoSize = true;
            this.chxEditable.Location = new System.Drawing.Point(25, 80);
            this.chxEditable.Name = "chxEditable";
            this.chxEditable.Size = new System.Drawing.Size(60, 16);
            this.chxEditable.TabIndex = 4;
            this.chxEditable.Text = "可编辑";
            this.chxEditable.UseVisualStyleBackColor = true;
            // 
            // chxAddHeaderPage
            // 
            this.chxAddHeaderPage.AutoSize = true;
            this.chxAddHeaderPage.Location = new System.Drawing.Point(25, 38);
            this.chxAddHeaderPage.Name = "chxAddHeaderPage";
            this.chxAddHeaderPage.Size = new System.Drawing.Size(84, 16);
            this.chxAddHeaderPage.TabIndex = 7;
            this.chxAddHeaderPage.Text = "增加抬头页";
            this.chxAddHeaderPage.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chxList_alv_grid_events);
            this.groupBox2.Location = new System.Drawing.Point(25, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(182, 265);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "事件";
            // 
            // chxList_alv_grid_events
            // 
            this.chxList_alv_grid_events.CheckOnClick = true;
            this.chxList_alv_grid_events.FormattingEnabled = true;
            this.chxList_alv_grid_events.Items.AddRange(new object[] {
            "ITEM_DATA_EXPAND",
            "REPREP_SEL_MODIFY",
            "CALLER_EXIT",
            "USER_COMMAND",
            "TOP_OF_PAGE",
            "DATA_CHANGED",
            "TOP_OF_COVERPAGE",
            "END_OF_COVERPAGE",
            "FOREIGN_TOP_OF_PAGE",
            "FOREIGN_END_OF_PAGE",
            "PF_STATUS_SET",
            "LIST_MODIFY",
            "TOP_OF_LIST",
            "END_OF_PAGE"});
            this.chxList_alv_grid_events.Location = new System.Drawing.Point(6, 20);
            this.chxList_alv_grid_events.MultiColumn = true;
            this.chxList_alv_grid_events.Name = "chxList_alv_grid_events";
            this.chxList_alv_grid_events.Size = new System.Drawing.Size(156, 228);
            this.chxList_alv_grid_events.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvFieldCat);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(559, 417);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "字段设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvFieldCat
            // 
            this.dgvFieldCat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFieldCat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFieldCat.Location = new System.Drawing.Point(3, 3);
            this.dgvFieldCat.Name = "dgvFieldCat";
            this.dgvFieldCat.RowTemplate.Height = 23;
            this.dgvFieldCat.Size = new System.Drawing.Size(553, 411);
            this.dgvFieldCat.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnUpdateSettings);
            this.tabPage3.Controls.Add(this.dataGridView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(559, 417);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "设置预览";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 29);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(557, 385);
            this.dataGridView1.TabIndex = 2;
            // 
            // cbxCategory
            // 
            this.cbxCategory.FormattingEnabled = true;
            this.cbxCategory.Location = new System.Drawing.Point(25, 6);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(100, 20);
            this.cbxCategory.TabIndex = 11;
            // 
            // FormAlvGernerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 508);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormAlvGernerator";
            this.Text = "ALV代码生成器";
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLayout)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFieldCat)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.CheckedListBox chxList_alv_grid_events;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btCheckSettings;
        private System.Windows.Forms.DataGridView dgvFieldCat;
        private System.Windows.Forms.TextBox txtProgramName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUpdateSettings;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnGernerate;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHeaderInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Button btnUpdateHeaderInfo;
        private System.Windows.Forms.CheckBox chxTrafficLight;
        private System.Windows.Forms.CheckBox chxAddBox;
        private System.Windows.Forms.CheckBox chxEditable;
        private System.Windows.Forms.CheckBox chxAddHeaderPage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.DataGridView dgvLayout;
        private System.Windows.Forms.ComboBox cbxCategory;
    }
}