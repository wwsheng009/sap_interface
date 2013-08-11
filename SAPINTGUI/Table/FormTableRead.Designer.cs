namespace SAPINT.Gui.Table
{
    partial class FormTableRead
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbx_systemlist = new System.Windows.Forms.ComboBox();
            this.txtDelimiter = new System.Windows.Forms.ComboBox();
            this.btnUnSelect = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FieldText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckTable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Option = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.loadFields = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.rowNum = new System.Windows.Forms.TextBox();
            this.btRun = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FieldCondtionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BackupFieldInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RestoreFieldsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.FieldInfoSaveAs_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadFiledInfoFromFile_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缓存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CacheFieldsConToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadFieldsFromCache_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveFieldsConFromCache_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnAddFieldsToCache = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbx_systemlist
            // 
            this.cbx_systemlist.FormattingEnabled = true;
            this.cbx_systemlist.Location = new System.Drawing.Point(41, 28);
            this.cbx_systemlist.Name = "cbx_systemlist";
            this.cbx_systemlist.Size = new System.Drawing.Size(143, 20);
            this.cbx_systemlist.TabIndex = 42;
            // 
            // txtDelimiter
            // 
            this.txtDelimiter.FormattingEnabled = true;
            this.txtDelimiter.Location = new System.Drawing.Point(130, 76);
            this.txtDelimiter.Name = "txtDelimiter";
            this.txtDelimiter.Size = new System.Drawing.Size(36, 20);
            this.txtDelimiter.TabIndex = 41;
            this.txtDelimiter.Text = "※";
            // 
            // btnUnSelect
            // 
            this.btnUnSelect.Location = new System.Drawing.Point(54, 128);
            this.btnUnSelect.Name = "btnUnSelect";
            this.btnUnSelect.Size = new System.Drawing.Size(37, 23);
            this.btnUnSelect.TabIndex = 38;
            this.btnUnSelect.Text = "取消";
            this.btnUnSelect.UseVisualStyleBackColor = true;
            this.btnUnSelect.Click += new System.EventHandler(this.btnUnSelect_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 158);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView2);
            this.splitContainer1.Size = new System.Drawing.Size(271, 511);
            this.splitContainer1.SplitterDistance = 255;
            this.splitContainer1.TabIndex = 37;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.FieldName,
            this.FieldText,
            this.CheckTable});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(271, 255);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // Select
            // 
            this.Select.HeaderText = "";
            this.Select.Name = "Select";
            this.Select.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Select.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Select.Width = 20;
            // 
            // FieldName
            // 
            this.FieldName.HeaderText = "字段";
            this.FieldName.Name = "FieldName";
            this.FieldName.Width = 60;
            // 
            // FieldText
            // 
            this.FieldText.HeaderText = "描述";
            this.FieldText.Name = "FieldText";
            // 
            // CheckTable
            // 
            this.CheckTable.HeaderText = "检查表";
            this.CheckTable.Name = "CheckTable";
            this.CheckTable.Width = 60;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 230);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(271, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel1.Text = "状态:";
            // 
            // dataGridView2
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Option});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 20;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(271, 252);
            this.dataGridView2.TabIndex = 2;
            // 
            // Option
            // 
            this.Option.HeaderText = "条件";
            this.Option.Name = "Option";
            this.Option.Width = 200;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 36;
            this.label3.Text = "系统";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(8, 129);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(42, 23);
            this.btnSelect.TabIndex = 32;
            this.btnSelect.Text = "选中所选";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // loadFields
            // 
            this.loadFields.Location = new System.Drawing.Point(8, 102);
            this.loadFields.Name = "loadFields";
            this.loadFields.Size = new System.Drawing.Size(85, 23);
            this.loadFields.TabIndex = 31;
            this.loadFields.Text = "加载字段列表";
            this.loadFields.UseVisualStyleBackColor = true;
            this.loadFields.Click += new System.EventHandler(this.loadFields_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 30;
            this.label2.Text = "行数";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 28;
            this.label1.Text = "表名";
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(41, 51);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(143, 21);
            this.txtTableName.TabIndex = 26;
            // 
            // rowNum
            // 
            this.rowNum.Location = new System.Drawing.Point(41, 75);
            this.rowNum.Name = "rowNum";
            this.rowNum.Size = new System.Drawing.Size(36, 21);
            this.rowNum.TabIndex = 29;
            // 
            // btRun
            // 
            this.btRun.Location = new System.Drawing.Point(97, 102);
            this.btRun.Name = "btRun";
            this.btRun.Size = new System.Drawing.Size(48, 48);
            this.btRun.TabIndex = 27;
            this.btRun.Text = "开始读取";
            this.btRun.UseVisualStyleBackColor = true;
            this.btRun.Click += new System.EventHandler(this.btRun_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(190, 28);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(84, 124);
            this.listBox1.TabIndex = 43;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FieldCondtionToolStripMenuItem,
            this.缓存ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(281, 25);
            this.menuStrip1.TabIndex = 45;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FieldCondtionToolStripMenuItem
            // 
            this.FieldCondtionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BackupFieldInfoToolStripMenuItem,
            this.RestoreFieldsToolStripMenuItem,
            this.toolStripSeparator2,
            this.FieldInfoSaveAs_MenuItem,
            this.LoadFiledInfoFromFile_MenuItem});
            this.FieldCondtionToolStripMenuItem.Name = "FieldCondtionToolStripMenuItem";
            this.FieldCondtionToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.FieldCondtionToolStripMenuItem.Text = "备份";
            // 
            // BackupFieldInfoToolStripMenuItem
            // 
            this.BackupFieldInfoToolStripMenuItem.Name = "BackupFieldInfoToolStripMenuItem";
            this.BackupFieldInfoToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.BackupFieldInfoToolStripMenuItem.Text = "备份字段清单";
            this.BackupFieldInfoToolStripMenuItem.Click += new System.EventHandler(this.BackupFieldInfoToolStripMenuItem_Click);
            // 
            // RestoreFieldsToolStripMenuItem
            // 
            this.RestoreFieldsToolStripMenuItem.Name = "RestoreFieldsToolStripMenuItem";
            this.RestoreFieldsToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.RestoreFieldsToolStripMenuItem.Text = "从本地文件恢复";
            this.RestoreFieldsToolStripMenuItem.Click += new System.EventHandler(this.RestoreFieldsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(157, 6);
            // 
            // FieldInfoSaveAs_MenuItem
            // 
            this.FieldInfoSaveAs_MenuItem.Name = "FieldInfoSaveAs_MenuItem";
            this.FieldInfoSaveAs_MenuItem.Size = new System.Drawing.Size(160, 22);
            this.FieldInfoSaveAs_MenuItem.Text = "另存为";
            this.FieldInfoSaveAs_MenuItem.Click += new System.EventHandler(this.FieldInfoSaveAs_MenuItem_Click);
            // 
            // LoadFiledInfoFromFile_MenuItem
            // 
            this.LoadFiledInfoFromFile_MenuItem.Name = "LoadFiledInfoFromFile_MenuItem";
            this.LoadFiledInfoFromFile_MenuItem.Size = new System.Drawing.Size(160, 22);
            this.LoadFiledInfoFromFile_MenuItem.Text = "加载文件";
            this.LoadFiledInfoFromFile_MenuItem.Click += new System.EventHandler(this.LoadFiledInfoFromFile_MenuItem_Click);
            // 
            // 缓存ToolStripMenuItem
            // 
            this.缓存ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CacheFieldsConToolStripMenuItem,
            this.LoadFieldsFromCache_MenuItem,
            this.RemoveFieldsConFromCache_MenuItem});
            this.缓存ToolStripMenuItem.Name = "缓存ToolStripMenuItem";
            this.缓存ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.缓存ToolStripMenuItem.Text = "缓存";
            // 
            // CacheFieldsConToolStripMenuItem
            // 
            this.CacheFieldsConToolStripMenuItem.Name = "CacheFieldsConToolStripMenuItem";
            this.CacheFieldsConToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.CacheFieldsConToolStripMenuItem.Text = "加入缓存";
            // 
            // LoadFieldsFromCache_MenuItem
            // 
            this.LoadFieldsFromCache_MenuItem.Name = "LoadFieldsFromCache_MenuItem";
            this.LoadFieldsFromCache_MenuItem.Size = new System.Drawing.Size(148, 22);
            this.LoadFieldsFromCache_MenuItem.Text = "从缓存中加载";
            // 
            // RemoveFieldsConFromCache_MenuItem
            // 
            this.RemoveFieldsConFromCache_MenuItem.Name = "RemoveFieldsConFromCache_MenuItem";
            this.RemoveFieldsConFromCache_MenuItem.Size = new System.Drawing.Size(148, 22);
            this.RemoveFieldsConFromCache_MenuItem.Text = "从缓存中删除";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(83, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 30;
            this.label4.Text = "分隔符";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnAddFieldsToCache
            // 
            this.btnAddFieldsToCache.Location = new System.Drawing.Point(148, 101);
            this.btnAddFieldsToCache.Name = "btnAddFieldsToCache";
            this.btnAddFieldsToCache.Size = new System.Drawing.Size(39, 49);
            this.btnAddFieldsToCache.TabIndex = 46;
            this.btnAddFieldsToCache.Text = "加入缓存";
            this.btnAddFieldsToCache.UseVisualStyleBackColor = true;
            this.btnAddFieldsToCache.Click += new System.EventHandler(this.btnAddFieldsToCache_Click);
            // 
            // FormTableRead
            // 
            this.AcceptButton = this.btRun;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 673);
            this.Controls.Add(this.btnAddFieldsToCache);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.cbx_systemlist);
            this.Controls.Add(this.txtDelimiter);
            this.Controls.Add(this.btnUnSelect);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.loadFields);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTableName);
            this.Controls.Add(this.rowNum);
            this.Controls.Add(this.btRun);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormTableRead";
            this.Text = "读取SAP表内容";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbx_systemlist;
        private System.Windows.Forms.ComboBox txtDelimiter;
        private System.Windows.Forms.Button btnUnSelect;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldText;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckTable;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Option;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button loadFields;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.TextBox rowNum;
        private System.Windows.Forms.Button btRun;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FieldCondtionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BackupFieldInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RestoreFieldsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem FieldInfoSaveAs_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadFiledInfoFromFile_MenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnAddFieldsToCache;
        private System.Windows.Forms.ToolStripMenuItem 缓存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CacheFieldsConToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadFieldsFromCache_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveFieldsConFromCache_MenuItem;

    }
}