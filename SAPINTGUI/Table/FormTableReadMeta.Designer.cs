namespace SAPINTGUI.Table
{
    partial class FormTableReadMeta
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
            this.btnLoadFields2 = new System.Windows.Forms.Button();
            this.btnSelect2 = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FIELDNAME1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FIELDNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnUnSelect2 = new System.Windows.Forms.Button();
            this.loadFields = new System.Windows.Forms.Button();
            this.btnUnSelect = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.cbx_systemlist = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.btRun = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadFields2
            // 
            this.btnLoadFields2.Location = new System.Drawing.Point(175, 84);
            this.btnLoadFields2.Name = "btnLoadFields2";
            this.btnLoadFields2.Size = new System.Drawing.Size(47, 23);
            this.btnLoadFields2.TabIndex = 36;
            this.btnLoadFields2.Text = "加载";
            this.btnLoadFields2.UseVisualStyleBackColor = true;
            this.btnLoadFields2.Click += new System.EventHandler(this.btnLoadFields2_Click);
            // 
            // btnSelect2
            // 
            this.btnSelect2.Location = new System.Drawing.Point(82, 84);
            this.btnSelect2.Name = "btnSelect2";
            this.btnSelect2.Size = new System.Drawing.Size(44, 23);
            this.btnSelect2.TabIndex = 32;
            this.btnSelect2.Text = "选中所选";
            this.btnSelect2.UseVisualStyleBackColor = true;
            this.btnSelect2.Click += new System.EventHandler(this.btnSelect2_Click);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "检查表";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "描述";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // FIELDNAME1
            // 
            this.FIELDNAME1.HeaderText = "字段";
            this.FIELDNAME1.Name = "FIELDNAME1";
            this.FIELDNAME1.Width = 60;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn1.Width = 20;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.FIELDNAME1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 20;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(225, 233);
            this.dataGridView2.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "检查表";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 60;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "描述";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // FIELDNAME
            // 
            this.FIELDNAME.HeaderText = "字段";
            this.FIELDNAME.Name = "FIELDNAME";
            this.FIELDNAME.Width = 60;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.HeaderText = "";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn2.Width = 20;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn2,
            this.FIELDNAME,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(225, 231);
            this.dataGridView1.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 113);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView2);
            this.splitContainer1.Size = new System.Drawing.Size(225, 468);
            this.splitContainer1.SplitterDistance = 231;
            this.splitContainer1.TabIndex = 38;
            // 
            // btnUnSelect2
            // 
            this.btnUnSelect2.Location = new System.Drawing.Point(132, 84);
            this.btnUnSelect2.Name = "btnUnSelect2";
            this.btnUnSelect2.Size = new System.Drawing.Size(37, 23);
            this.btnUnSelect2.TabIndex = 34;
            this.btnUnSelect2.Text = "取消";
            this.btnUnSelect2.UseVisualStyleBackColor = true;
            this.btnUnSelect2.Click += new System.EventHandler(this.btnUnSelect2_Click);
            // 
            // loadFields
            // 
            this.loadFields.Location = new System.Drawing.Point(175, 55);
            this.loadFields.Name = "loadFields";
            this.loadFields.Size = new System.Drawing.Size(47, 23);
            this.loadFields.TabIndex = 37;
            this.loadFields.Text = "加载";
            this.loadFields.UseVisualStyleBackColor = true;
            this.loadFields.Click += new System.EventHandler(this.loadFields_Click);
            // 
            // btnUnSelect
            // 
            this.btnUnSelect.Location = new System.Drawing.Point(132, 55);
            this.btnUnSelect.Name = "btnUnSelect";
            this.btnUnSelect.Size = new System.Drawing.Size(37, 23);
            this.btnUnSelect.TabIndex = 35;
            this.btnUnSelect.Text = "取消";
            this.btnUnSelect.UseVisualStyleBackColor = true;
            this.btnUnSelect.Click += new System.EventHandler(this.btnUnSelect_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(82, 55);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(44, 23);
            this.btnSelect.TabIndex = 33;
            this.btnSelect.Text = "选中所选";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // cbx_systemlist
            // 
            this.cbx_systemlist.FormattingEnabled = true;
            this.cbx_systemlist.Location = new System.Drawing.Point(62, 0);
            this.cbx_systemlist.Name = "cbx_systemlist";
            this.cbx_systemlist.Size = new System.Drawing.Size(160, 20);
            this.cbx_systemlist.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 31;
            this.label3.Text = "SAP系统";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 30;
            this.label1.Text = "表名";
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(62, 24);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(160, 21);
            this.txtTableName.TabIndex = 28;
            // 
            // btRun
            // 
            this.btRun.Location = new System.Drawing.Point(3, 55);
            this.btRun.Name = "btRun";
            this.btRun.Size = new System.Drawing.Size(73, 52);
            this.btRun.TabIndex = 29;
            this.btRun.Text = "开始读取";
            this.btRun.UseVisualStyleBackColor = true;
            this.btRun.Click += new System.EventHandler(this.btRun_Click);
            // 
            // FormTableReadMeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 583);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnLoadFields2);
            this.Controls.Add(this.btnSelect2);
            this.Controls.Add(this.btnUnSelect2);
            this.Controls.Add(this.loadFields);
            this.Controls.Add(this.btnUnSelect);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.cbx_systemlist);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTableName);
            this.Controls.Add(this.btRun);
            this.Name = "FormTableReadMeta";
            this.Text = "FormTableReadMeta";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadFields2;
        private System.Windows.Forms.Button btnSelect2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn FIELDNAME1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn FIELDNAME;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnUnSelect2;
        private System.Windows.Forms.Button loadFields;
        private System.Windows.Forms.Button btnUnSelect;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.ComboBox cbx_systemlist;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Button btRun;
    }
}