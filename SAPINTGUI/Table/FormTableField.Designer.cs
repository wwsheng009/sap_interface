namespace SAPINT.Gui.Table
{
    partial class FormTableField
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnReadSAPTable = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSearch2 = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cbx_systemlist = new System.Windows.Forms.ComboBox();
            this.btnRemoveCache = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoadCache = new System.Windows.Forms.Button();
            this.btnCacheMe = new System.Windows.Forms.Button();
            this.btnUnSelect = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReadSAPTable
            // 
            this.btnReadSAPTable.Location = new System.Drawing.Point(6, 57);
            this.btnReadSAPTable.Name = "btnReadSAPTable";
            this.btnReadSAPTable.Size = new System.Drawing.Size(100, 26);
            this.btnReadSAPTable.TabIndex = 26;
            this.btnReadSAPTable.Text = "读取";
            this.btnReadSAPTable.UseVisualStyleBackColor = true;
            this.btnReadSAPTable.Click += new System.EventHandler(this.btnReadSAPTable_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 452);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(298, 22);
            this.statusStrip1.TabIndex = 41;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel1.Text = "状态：";
            // 
            // btnSearch2
            // 
            this.btnSearch2.Location = new System.Drawing.Point(147, 89);
            this.btnSearch2.Name = "btnSearch2";
            this.btnSearch2.Size = new System.Drawing.Size(46, 24);
            this.btnSearch2.TabIndex = 40;
            this.btnSearch2.Text = "搜索2";
            this.btnSearch2.UseVisualStyleBackColor = true;
            this.btnSearch2.Click += new System.EventHandler(this.btnSearch2_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(100, 89);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(46, 24);
            this.btnSearch.TabIndex = 38;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(240, 10);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(55, 100);
            this.listBox1.TabIndex = 37;
            // 
            // cbx_systemlist
            // 
            this.cbx_systemlist.FormattingEnabled = true;
            this.cbx_systemlist.Location = new System.Drawing.Point(45, 7);
            this.cbx_systemlist.Name = "cbx_systemlist";
            this.cbx_systemlist.Size = new System.Drawing.Size(130, 20);
            this.cbx_systemlist.TabIndex = 36;
            this.cbx_systemlist.SelectedIndexChanged += new System.EventHandler(this.cbx_systemlist_SelectedIndexChanged_1);
            // 
            // btnRemoveCache
            // 
            this.btnRemoveCache.ForeColor = System.Drawing.Color.Maroon;
            this.btnRemoveCache.Location = new System.Drawing.Point(200, 89);
            this.btnRemoveCache.Name = "btnRemoveCache";
            this.btnRemoveCache.Size = new System.Drawing.Size(39, 24);
            this.btnRemoveCache.TabIndex = 32;
            this.btnRemoveCache.Text = "删除";
            this.btnRemoveCache.UseVisualStyleBackColor = true;
            this.btnRemoveCache.Click += new System.EventHandler(this.btnRemoveCache_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 35;
            this.label3.Text = "系统:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Location = new System.Drawing.Point(6, 119);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(289, 330);
            this.dataGridView1.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 33;
            this.label1.Text = "表名:";
            // 
            // btnLoadCache
            // 
            this.btnLoadCache.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnLoadCache.Location = new System.Drawing.Point(201, 57);
            this.btnLoadCache.Name = "btnLoadCache";
            this.btnLoadCache.Size = new System.Drawing.Size(38, 26);
            this.btnLoadCache.TabIndex = 31;
            this.btnLoadCache.Text = "加载";
            this.btnLoadCache.UseVisualStyleBackColor = true;
            this.btnLoadCache.Click += new System.EventHandler(this.btnLoadCache_Click);
            // 
            // btnCacheMe
            // 
            this.btnCacheMe.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCacheMe.Location = new System.Drawing.Point(201, 7);
            this.btnCacheMe.Name = "btnCacheMe";
            this.btnCacheMe.Size = new System.Drawing.Size(38, 49);
            this.btnCacheMe.TabIndex = 28;
            this.btnCacheMe.Text = "保存";
            this.btnCacheMe.UseVisualStyleBackColor = true;
            this.btnCacheMe.Click += new System.EventHandler(this.btnCacheMe_Click);
            // 
            // btnUnSelect
            // 
            this.btnUnSelect.Location = new System.Drawing.Point(53, 89);
            this.btnUnSelect.Name = "btnUnSelect";
            this.btnUnSelect.Size = new System.Drawing.Size(46, 24);
            this.btnUnSelect.TabIndex = 30;
            this.btnUnSelect.Text = "取消";
            this.btnUnSelect.UseVisualStyleBackColor = true;
            this.btnUnSelect.Click += new System.EventHandler(this.btnUnSelect_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(6, 89);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(46, 24);
            this.btnSelect.TabIndex = 29;
            this.btnSelect.Text = "选中";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(44, 31);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(131, 21);
            this.txtTableName.TabIndex = 27;
            // 
            // FormTableField
            // 
            this.AcceptButton = this.btnReadSAPTable;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 474);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnSearch2);
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
            this.Name = "FormTableField";
            this.Text = "FormTableField";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListBox listBox1;
        public System.Windows.Forms.ComboBox cbx_systemlist;
        private System.Windows.Forms.Button btnRemoveCache;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoadCache;
        private System.Windows.Forms.Button btnCacheMe;
        private System.Windows.Forms.Button btnUnSelect;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Button btnReadSAPTable;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;

    }
}