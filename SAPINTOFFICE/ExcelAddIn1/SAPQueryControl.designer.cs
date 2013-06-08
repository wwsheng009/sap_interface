namespace ExcelAddIn1
{
    partial class SAPQueryControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkStandard = new System.Windows.Forms.CheckBox();
            this.cbxVariants = new System.Windows.Forms.ComboBox();
            this.cbxQueries = new System.Windows.Forms.ComboBox();
            this.cbxUserGroup = new System.Windows.Forms.ComboBox();
            this.txtMaxRows = new System.Windows.Forms.TextBox();
            this.btnExcute = new System.Windows.Forms.Button();
            this.dgvParameters = new System.Windows.Forms.DataGridView();
            this.CSELNAME = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CKIND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CFieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CSIGN = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.COPTION = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CLOW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHIGH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnSearchUserGroup = new System.Windows.Forms.Button();
            this.btnSearchQuery = new System.Windows.Forms.Button();
            this.dgvSearchResult = new System.Windows.Forms.DataGridView();
            this.btnSearchVariant = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cbxSystemList = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "标准工作区域";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "查询名称";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "用户组";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "变量名";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "数量";
            // 
            // checkStandard
            // 
            this.checkStandard.AutoSize = true;
            this.checkStandard.Location = new System.Drawing.Point(91, 138);
            this.checkStandard.Name = "checkStandard";
            this.checkStandard.Size = new System.Drawing.Size(15, 14);
            this.checkStandard.TabIndex = 2;
            this.checkStandard.UseVisualStyleBackColor = true;
            // 
            // cbxVariants
            // 
            this.cbxVariants.FormattingEnabled = true;
            this.cbxVariants.Location = new System.Drawing.Point(57, 80);
            this.cbxVariants.Name = "cbxVariants";
            this.cbxVariants.Size = new System.Drawing.Size(110, 20);
            this.cbxVariants.TabIndex = 5;
            // 
            // cbxQueries
            // 
            this.cbxQueries.FormattingEnabled = true;
            this.cbxQueries.Location = new System.Drawing.Point(58, 54);
            this.cbxQueries.Name = "cbxQueries";
            this.cbxQueries.Size = new System.Drawing.Size(109, 20);
            this.cbxQueries.TabIndex = 4;
            // 
            // cbxUserGroup
            // 
            this.cbxUserGroup.FormattingEnabled = true;
            this.cbxUserGroup.Location = new System.Drawing.Point(57, 30);
            this.cbxUserGroup.Name = "cbxUserGroup";
            this.cbxUserGroup.Size = new System.Drawing.Size(110, 20);
            this.cbxUserGroup.TabIndex = 3;
            this.cbxUserGroup.SelectedIndexChanged += new System.EventHandler(this.cbxUserGroup_SelectedIndexChanged);
            // 
            // txtMaxRows
            // 
            this.txtMaxRows.Location = new System.Drawing.Point(57, 110);
            this.txtMaxRows.Name = "txtMaxRows";
            this.txtMaxRows.Size = new System.Drawing.Size(49, 21);
            this.txtMaxRows.TabIndex = 6;
            this.txtMaxRows.Text = "500";
            // 
            // btnExcute
            // 
            this.btnExcute.Location = new System.Drawing.Point(119, 113);
            this.btnExcute.Name = "btnExcute";
            this.btnExcute.Size = new System.Drawing.Size(61, 39);
            this.btnExcute.TabIndex = 9;
            this.btnExcute.Text = "读取数据";
            this.btnExcute.UseVisualStyleBackColor = true;
            this.btnExcute.Click += new System.EventHandler(this.btnExcute_Click);
            // 
            // dgvParameters
            // 
            this.dgvParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParameters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CSELNAME,
            this.CKIND,
            this.CFieldName,
            this.CName,
            this.CSIGN,
            this.COPTION,
            this.CLOW,
            this.CHIGH});
            this.dgvParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvParameters.Location = new System.Drawing.Point(0, 0);
            this.dgvParameters.Name = "dgvParameters";
            this.dgvParameters.RowHeadersWidth = 20;
            this.dgvParameters.RowTemplate.Height = 23;
            this.dgvParameters.Size = new System.Drawing.Size(675, 149);
            this.dgvParameters.TabIndex = 8;
            this.dgvParameters.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvParameters_EditingControlShowing);
            // 
            // CSELNAME
            // 
            this.CSELNAME.HeaderText = "列名";
            this.CSELNAME.Name = "CSELNAME";
            this.CSELNAME.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CSELNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CKIND
            // 
            this.CKIND.HeaderText = "类型";
            this.CKIND.Name = "CKIND";
            this.CKIND.ReadOnly = true;
            this.CKIND.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // CFieldName
            // 
            this.CFieldName.HeaderText = "列名";
            this.CFieldName.Name = "CFieldName";
            this.CFieldName.ReadOnly = true;
            // 
            // CName
            // 
            this.CName.HeaderText = "参数名";
            this.CName.Name = "CName";
            this.CName.ReadOnly = true;
            // 
            // CSIGN
            // 
            this.CSIGN.HeaderText = "标识";
            this.CSIGN.Items.AddRange(new object[] {
            "I",
            "E"});
            this.CSIGN.Name = "CSIGN";
            this.CSIGN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CSIGN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CSIGN.Width = 50;
            // 
            // COPTION
            // 
            this.COPTION.HeaderText = "选项";
            this.COPTION.Items.AddRange(new object[] {
            "EQ",
            "NE"});
            this.COPTION.Name = "COPTION";
            this.COPTION.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.COPTION.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.COPTION.Width = 50;
            // 
            // CLOW
            // 
            this.CLOW.HeaderText = "低位";
            this.CLOW.Name = "CLOW";
            this.CLOW.Width = 150;
            // 
            // CHIGH
            // 
            this.CHIGH.HeaderText = "高位";
            this.CHIGH.Name = "CHIGH";
            this.CHIGH.Width = 150;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(186, 113);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(62, 39);
            this.btnQuery.TabIndex = 7;
            this.btnQuery.Text = "查询条件";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnSearchUserGroup
            // 
            this.btnSearchUserGroup.Location = new System.Drawing.Point(173, 27);
            this.btnSearchUserGroup.Name = "btnSearchUserGroup";
            this.btnSearchUserGroup.Size = new System.Drawing.Size(75, 23);
            this.btnSearchUserGroup.TabIndex = 10;
            this.btnSearchUserGroup.Text = "搜索用户组";
            this.btnSearchUserGroup.UseVisualStyleBackColor = true;
            this.btnSearchUserGroup.Click += new System.EventHandler(this.btnSearchUserGroup_Click);
            // 
            // btnSearchQuery
            // 
            this.btnSearchQuery.Location = new System.Drawing.Point(173, 52);
            this.btnSearchQuery.Name = "btnSearchQuery";
            this.btnSearchQuery.Size = new System.Drawing.Size(75, 23);
            this.btnSearchQuery.TabIndex = 11;
            this.btnSearchQuery.Text = "搜索查询";
            this.btnSearchQuery.UseVisualStyleBackColor = true;
            this.btnSearchQuery.Click += new System.EventHandler(this.btnSearchQuery_Click);
            // 
            // dgvSearchResult
            // 
            this.dgvSearchResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSearchResult.Location = new System.Drawing.Point(0, 0);
            this.dgvSearchResult.Name = "dgvSearchResult";
            this.dgvSearchResult.RowTemplate.Height = 23;
            this.dgvSearchResult.Size = new System.Drawing.Size(235, 149);
            this.dgvSearchResult.TabIndex = 12;
            // 
            // btnSearchVariant
            // 
            this.btnSearchVariant.Location = new System.Drawing.Point(173, 80);
            this.btnSearchVariant.Name = "btnSearchVariant";
            this.btnSearchVariant.Size = new System.Drawing.Size(75, 23);
            this.btnSearchVariant.TabIndex = 13;
            this.btnSearchVariant.Text = "搜索变量";
            this.btnSearchVariant.UseVisualStyleBackColor = true;
            this.btnSearchVariant.Click += new System.EventHandler(this.btnSearchVariant_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "SAP系统";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(254, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvSearchResult);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvParameters);
            this.splitContainer1.Size = new System.Drawing.Size(914, 149);
            this.splitContainer1.SplitterDistance = 235;
            this.splitContainer1.TabIndex = 17;
            // 
            // cbxSystemList
            // 
            this.cbxSystemList.FormattingEnabled = true;
            this.cbxSystemList.Location = new System.Drawing.Point(58, 4);
            this.cbxSystemList.Name = "cbxSystemList";
            this.cbxSystemList.Size = new System.Drawing.Size(109, 20);
            this.cbxSystemList.TabIndex = 18;
            // 
            // SAPQueryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbxSystemList);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSearchVariant);
            this.Controls.Add(this.btnSearchQuery);
            this.Controls.Add(this.btnSearchUserGroup);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.btnExcute);
            this.Controls.Add(this.txtMaxRows);
            this.Controls.Add(this.cbxUserGroup);
            this.Controls.Add(this.cbxQueries);
            this.Controls.Add(this.cbxVariants);
            this.Controls.Add(this.checkStandard);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "SAPQueryControl";
            this.Size = new System.Drawing.Size(1171, 159);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchResult)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkStandard;
        private System.Windows.Forms.ComboBox cbxVariants;
        private System.Windows.Forms.ComboBox cbxQueries;
        private System.Windows.Forms.ComboBox cbxUserGroup;
        private System.Windows.Forms.TextBox txtMaxRows;
        private System.Windows.Forms.Button btnExcute;
        private System.Windows.Forms.DataGridView dgvParameters;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.DataGridViewComboBoxColumn CSELNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn CKIND;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFieldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CName;
        private System.Windows.Forms.DataGridViewComboBoxColumn CSIGN;
        private System.Windows.Forms.DataGridViewComboBoxColumn COPTION;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLOW;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHIGH;
        private System.Windows.Forms.Button btnSearchUserGroup;
        private System.Windows.Forms.Button btnSearchQuery;
        private System.Windows.Forms.DataGridView dgvSearchResult;
        private System.Windows.Forms.Button btnSearchVariant;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox cbxSystemList;
    }
}
