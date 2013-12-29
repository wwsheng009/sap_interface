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
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnRemoveCache = new System.Windows.Forms.Button();
            this.cbx_systemlist = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnSort = new System.Windows.Forms.Button();
            this.btnSearch2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReadSAPTable
            // 
            this.btnReadSAPTable.Location = new System.Drawing.Point(6, 58);
            this.btnReadSAPTable.Name = "btnReadSAPTable";
            this.btnReadSAPTable.Size = new System.Drawing.Size(100, 26);
            this.btnReadSAPTable.TabIndex = 0;
            this.btnReadSAPTable.Text = "读取";
            this.btnReadSAPTable.UseVisualStyleBackColor = true;
            this.btnReadSAPTable.Click += new System.EventHandler(this.btnReadSAPTable_Click);
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(44, 32);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(131, 21);
            this.txtTableName.TabIndex = 1;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(6, 90);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(46, 24);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "选中";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnUnSelect
            // 
            this.btnUnSelect.Location = new System.Drawing.Point(53, 90);
            this.btnUnSelect.Name = "btnUnSelect";
            this.btnUnSelect.Size = new System.Drawing.Size(46, 24);
            this.btnUnSelect.TabIndex = 4;
            this.btnUnSelect.Text = "取消";
            this.btnUnSelect.UseVisualStyleBackColor = true;
            this.btnUnSelect.Click += new System.EventHandler(this.btnUnSelect_Click);
            // 
            // btnCacheMe
            // 
            this.btnCacheMe.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCacheMe.Location = new System.Drawing.Point(201, 8);
            this.btnCacheMe.Name = "btnCacheMe";
            this.btnCacheMe.Size = new System.Drawing.Size(38, 49);
            this.btnCacheMe.TabIndex = 2;
            this.btnCacheMe.Text = "保存";
            this.btnCacheMe.UseVisualStyleBackColor = true;
            this.btnCacheMe.Click += new System.EventHandler(this.btnCacheMe_Click);
            // 
            // btnLoadCache
            // 
            this.btnLoadCache.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnLoadCache.Location = new System.Drawing.Point(201, 58);
            this.btnLoadCache.Name = "btnLoadCache";
            this.btnLoadCache.Size = new System.Drawing.Size(38, 26);
            this.btnLoadCache.TabIndex = 5;
            this.btnLoadCache.Text = "加载";
            this.btnLoadCache.UseVisualStyleBackColor = true;
            this.btnLoadCache.Click += new System.EventHandler(this.btnLoadCache_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "表名:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "系统:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 120);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(285, 435);
            this.dataGridView1.TabIndex = 8;
            // 
            // btnRemoveCache
            // 
            this.btnRemoveCache.ForeColor = System.Drawing.Color.Maroon;
            this.btnRemoveCache.Location = new System.Drawing.Point(200, 90);
            this.btnRemoveCache.Name = "btnRemoveCache";
            this.btnRemoveCache.Size = new System.Drawing.Size(39, 24);
            this.btnRemoveCache.TabIndex = 6;
            this.btnRemoveCache.Text = "删除";
            this.btnRemoveCache.UseVisualStyleBackColor = true;
            this.btnRemoveCache.Click += new System.EventHandler(this.btnRemoveCache_Click);
            // 
            // cbx_systemlist
            // 
            this.cbx_systemlist.FormattingEnabled = true;
            this.cbx_systemlist.Location = new System.Drawing.Point(45, 8);
            this.cbx_systemlist.Name = "cbx_systemlist";
            this.cbx_systemlist.Size = new System.Drawing.Size(130, 20);
            this.cbx_systemlist.TabIndex = 21;
            this.cbx_systemlist.SelectedIndexChanged += new System.EventHandler(this.cbx_systemlist_SelectedIndexChanged_1);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(240, 11);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(51, 100);
            this.listBox1.TabIndex = 22;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(100, 90);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(46, 24);
            this.btnSearch.TabIndex = 23;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(112, 58);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(78, 26);
            this.btnSort.TabIndex = 24;
            this.btnSort.Text = "排序";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnSearch2
            // 
            this.btnSearch2.Location = new System.Drawing.Point(147, 90);
            this.btnSearch2.Name = "btnSearch2";
            this.btnSearch2.Size = new System.Drawing.Size(46, 24);
            this.btnSearch2.TabIndex = 25;
            this.btnSearch2.Text = "搜索2";
            this.btnSearch2.UseVisualStyleBackColor = true;
            this.btnSearch2.Click += new System.EventHandler(this.btnSearch2_Click);
            // 
            // SAPTableField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSearch2);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.cbx_systemlist);
            this.Controls.Add(this.btnRemoveCache);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoadCache);
            this.Controls.Add(this.btnCacheMe);
            this.Controls.Add(this.btnUnSelect);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.txtTableName);
            this.Controls.Add(this.btnReadSAPTable);
            this.Name = "SAPTableField";
            this.Size = new System.Drawing.Size(297, 558);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectCol;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnRemoveCache;
        public System.Windows.Forms.ComboBox cbx_systemlist;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Button btnSearch2;
    }
}
