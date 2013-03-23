namespace SAPINTCODE
{
    partial class SAPTableField
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
            this.btnReadSAPTable = new System.Windows.Forms.Button();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnUnSelect = new System.Windows.Forms.Button();
            this.btnCacheMe = new System.Windows.Forms.Button();
            this.btnLoadCache = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_systemlist = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CheckTable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FieldText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnRemoveCache = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReadSAPTable
            // 
            this.btnReadSAPTable.Location = new System.Drawing.Point(212, 4);
            this.btnReadSAPTable.Name = "btnReadSAPTable";
            this.btnReadSAPTable.Size = new System.Drawing.Size(61, 50);
            this.btnReadSAPTable.TabIndex = 0;
            this.btnReadSAPTable.Text = "读取";
            this.btnReadSAPTable.UseVisualStyleBackColor = true;
            this.btnReadSAPTable.Click += new System.EventHandler(this.btnReadSAPTable_Click);
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(57, 30);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(149, 21);
            this.txtTableName.TabIndex = 1;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(6, 60);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(55, 23);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "选中";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnUnSelect
            // 
            this.btnUnSelect.Location = new System.Drawing.Point(67, 60);
            this.btnUnSelect.Name = "btnUnSelect";
            this.btnUnSelect.Size = new System.Drawing.Size(42, 23);
            this.btnUnSelect.TabIndex = 4;
            this.btnUnSelect.Text = "取消";
            this.btnUnSelect.UseVisualStyleBackColor = true;
            this.btnUnSelect.Click += new System.EventHandler(this.btnUnSelect_Click);
            // 
            // btnCacheMe
            // 
            this.btnCacheMe.Location = new System.Drawing.Point(115, 61);
            this.btnCacheMe.Name = "btnCacheMe";
            this.btnCacheMe.Size = new System.Drawing.Size(45, 23);
            this.btnCacheMe.TabIndex = 5;
            this.btnCacheMe.Text = "缓存";
            this.btnCacheMe.UseVisualStyleBackColor = true;
            this.btnCacheMe.Click += new System.EventHandler(this.btnCacheMe_Click);
            // 
            // btnLoadCache
            // 
            this.btnLoadCache.Location = new System.Drawing.Point(166, 61);
            this.btnLoadCache.Name = "btnLoadCache";
            this.btnLoadCache.Size = new System.Drawing.Size(48, 23);
            this.btnLoadCache.TabIndex = 6;
            this.btnLoadCache.Text = "加载缓存";
            this.btnLoadCache.UseVisualStyleBackColor = true;
            this.btnLoadCache.Click += new System.EventHandler(this.btnLoadCache_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "表   名:";
            // 
            // cbx_systemlist
            // 
            this.cbx_systemlist.FormattingEnabled = true;
            this.cbx_systemlist.Location = new System.Drawing.Point(57, 4);
            this.cbx_systemlist.Name = "cbx_systemlist";
            this.cbx_systemlist.Size = new System.Drawing.Size(149, 20);
            this.cbx_systemlist.TabIndex = 19;
            this.cbx_systemlist.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbx_systemlist_MouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "SAP系统:";
            // 
            // CheckTable
            // 
            this.CheckTable.HeaderText = "检查表";
            this.CheckTable.Name = "CheckTable";
            this.CheckTable.ReadOnly = true;
            // 
            // FieldText
            // 
            this.FieldText.HeaderText = "描述";
            this.FieldText.Name = "FieldText";
            // 
            // FieldName
            // 
            this.FieldName.HeaderText = "字段";
            this.FieldName.Name = "FieldName";
            this.FieldName.Width = 60;
            // 
            // Select
            // 
            this.Select.HeaderText = "";
            this.Select.Name = "Select";
            this.Select.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Select.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Select.Width = 20;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.FieldName,
            this.FieldText,
            this.CheckTable});
            this.dataGridView1.Location = new System.Drawing.Point(3, 91);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(312, 464);
            this.dataGridView1.TabIndex = 8;
            // 
            // btnRemoveCache
            // 
            this.btnRemoveCache.Location = new System.Drawing.Point(221, 61);
            this.btnRemoveCache.Name = "btnRemoveCache";
            this.btnRemoveCache.Size = new System.Drawing.Size(52, 23);
            this.btnRemoveCache.TabIndex = 21;
            this.btnRemoveCache.Text = "移除";
            this.btnRemoveCache.UseVisualStyleBackColor = true;
            this.btnRemoveCache.Click += new System.EventHandler(this.btnRemoveCache_Click);
            // 
            // SAPTableField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRemoveCache);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbx_systemlist);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoadCache);
            this.Controls.Add(this.btnCacheMe);
            this.Controls.Add(this.btnUnSelect);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.txtTableName);
            this.Controls.Add(this.btnReadSAPTable);
            this.Name = "SAPTableField";
            this.Size = new System.Drawing.Size(318, 558);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReadSAPTable;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnUnSelect;
        private System.Windows.Forms.Button btnCacheMe;
        private System.Windows.Forms.Button btnLoadCache;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbx_systemlist;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldText;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnRemoveCache;
    }
}
