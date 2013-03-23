namespace SAPINTGUI
{
    partial class ReadTableControl
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
            this.Run = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FieldText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckTable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Option = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rowNum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.loadFields = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btn_saveInfo = new System.Windows.Forms.Button();
            this.btn_loadInfo = new System.Windows.Forms.Button();
            this.btn_refreshInfo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbx_systemlist = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnUnSelect = new System.Windows.Forms.Button();
            this.btnCacheMe = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDelimiter = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Run
            // 
            this.Run.Location = new System.Drawing.Point(192, 3);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(48, 48);
            this.Run.TabIndex = 3;
            this.Run.Text = "开始读取";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.FieldName,
            this.FieldText,
            this.CheckTable});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(235, 263);
            this.dataGridView1.TabIndex = 1;
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
            this.CheckTable.ReadOnly = true;
            this.CheckTable.Width = 60;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Option});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 20;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(235, 260);
            this.dataGridView2.TabIndex = 2;
            this.dataGridView2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView2_KeyDown);
            // 
            // Option
            // 
            this.Option.HeaderText = "条件";
            this.Option.Name = "Option";
            this.Option.Width = 200;
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(63, 30);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(124, 21);
            this.txtTableName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "表名";
            // 
            // rowNum
            // 
            this.rowNum.Location = new System.Drawing.Point(63, 58);
            this.rowNum.Name = "rowNum";
            this.rowNum.Size = new System.Drawing.Size(36, 21);
            this.rowNum.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "行数";
            // 
            // loadFields
            // 
            this.loadFields.Location = new System.Drawing.Point(3, 96);
            this.loadFields.Name = "loadFields";
            this.loadFields.Size = new System.Drawing.Size(47, 23);
            this.loadFields.TabIndex = 9;
            this.loadFields.Text = "加载";
            this.loadFields.UseVisualStyleBackColor = true;
            this.loadFields.Click += new System.EventHandler(this.loadFields_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(55, 96);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(44, 23);
            this.btnSelect.TabIndex = 10;
            this.btnSelect.Text = "选中所选";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.clearFields_Click);
            // 
            // btn_saveInfo
            // 
            this.btn_saveInfo.Location = new System.Drawing.Point(3, 122);
            this.btn_saveInfo.Name = "btn_saveInfo";
            this.btn_saveInfo.Size = new System.Drawing.Size(65, 23);
            this.btn_saveInfo.TabIndex = 11;
            this.btn_saveInfo.Text = "本地保存";
            this.btn_saveInfo.UseVisualStyleBackColor = true;
            this.btn_saveInfo.Click += new System.EventHandler(this.btn_saveInfo_Click);
            // 
            // btn_loadInfo
            // 
            this.btn_loadInfo.Location = new System.Drawing.Point(74, 122);
            this.btn_loadInfo.Name = "btn_loadInfo";
            this.btn_loadInfo.Size = new System.Drawing.Size(63, 23);
            this.btn_loadInfo.TabIndex = 12;
            this.btn_loadInfo.Text = "本地加载";
            this.btn_loadInfo.UseVisualStyleBackColor = true;
            this.btn_loadInfo.Click += new System.EventHandler(this.btn_loadInfo_Click);
            // 
            // btn_refreshInfo
            // 
            this.btn_refreshInfo.Location = new System.Drawing.Point(143, 122);
            this.btn_refreshInfo.Name = "btn_refreshInfo";
            this.btn_refreshInfo.Size = new System.Drawing.Size(43, 23);
            this.btn_refreshInfo.TabIndex = 15;
            this.btn_refreshInfo.Text = "刷新";
            this.btn_refreshInfo.UseVisualStyleBackColor = true;
            this.btn_refreshInfo.Click += new System.EventHandler(this.btn_refreshInfo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "SAP系统";
            // 
            // cbx_systemlist
            // 
            this.cbx_systemlist.FormattingEnabled = true;
            this.cbx_systemlist.Location = new System.Drawing.Point(63, 3);
            this.cbx_systemlist.Name = "cbx_systemlist";
            this.cbx_systemlist.Size = new System.Drawing.Size(124, 20);
            this.cbx_systemlist.TabIndex = 1;
            this.cbx_systemlist.SelectionChangeCommitted += new System.EventHandler(this.cbx_systemlist_SelectionChangeCommitted);
            this.cbx_systemlist.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbx_systemlist_MouseClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(5, 151);
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
            this.splitContainer1.Size = new System.Drawing.Size(235, 527);
            this.splitContainer1.SplitterDistance = 263;
            this.splitContainer1.TabIndex = 19;
            // 
            // btnUnSelect
            // 
            this.btnUnSelect.Location = new System.Drawing.Point(105, 96);
            this.btnUnSelect.Name = "btnUnSelect";
            this.btnUnSelect.Size = new System.Drawing.Size(37, 23);
            this.btnUnSelect.TabIndex = 20;
            this.btnUnSelect.Text = "取消";
            this.btnUnSelect.UseVisualStyleBackColor = true;
            this.btnUnSelect.Click += new System.EventHandler(this.btnUnSelect_Click);
            // 
            // btnCacheMe
            // 
            this.btnCacheMe.Location = new System.Drawing.Point(148, 96);
            this.btnCacheMe.Name = "btnCacheMe";
            this.btnCacheMe.Size = new System.Drawing.Size(38, 23);
            this.btnCacheMe.TabIndex = 21;
            this.btnCacheMe.Text = "缓存";
            this.btnCacheMe.UseVisualStyleBackColor = true;
            this.btnCacheMe.Click += new System.EventHandler(this.btnCacheMe_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(104, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "分隔符";
            // 
            // txtDelimiter
            // 
            this.txtDelimiter.FormattingEnabled = true;
            this.txtDelimiter.Items.AddRange(new object[] {
            "★",
            "☆",
            "♀",
            "卐",
            "※",
            "◆",
            "◇",
            "◣",
            "◢",
            "◥",
            "▲",
            "▼",
            "△",
            "▽",
            "⊿",
            "◤",
            "◥　　　　",
            "▆",
            "▇",
            "█",
            "█",
            "■",
            "▓",
            "〓",
            "≡",
            "╝",
            "╚",
            "╔",
            "╗",
            "╬",
            "═",
            "╓",
            "╩",
            "┠",
            "┯",
            "┷",
            "┏",
            "┓",
            "┗",
            "┛",
            "┳",
            "⊥",
            "﹃",
            "﹄",
            "┐",
            "└",
            "┘",
            "∟",
            "「",
            "」",
            "↑",
            "↓",
            "→",
            "←",
            "↘",
            "↙",
            "♀",
            "♂",
            "┇",
            "┅",
            "﹉",
            "﹊",
            "﹍",
            "﹎",
            "╭"});
            this.txtDelimiter.Location = new System.Drawing.Point(143, 59);
            this.txtDelimiter.Name = "txtDelimiter";
            this.txtDelimiter.Size = new System.Drawing.Size(42, 20);
            this.txtDelimiter.TabIndex = 24;
            this.txtDelimiter.Text = "※";
            // 
            // ReadTableControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtDelimiter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCacheMe);
            this.Controls.Add(this.btnUnSelect);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.cbx_systemlist);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_refreshInfo);
            this.Controls.Add(this.btn_loadInfo);
            this.Controls.Add(this.btn_saveInfo);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.loadFields);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rowNum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTableName);
            this.Controls.Add(this.Run);
            this.Name = "ReadTableControl";
            this.Size = new System.Drawing.Size(248, 679);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox rowNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button loadFields;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btn_saveInfo;
        private System.Windows.Forms.Button btn_loadInfo;
        private System.Windows.Forms.Button btn_refreshInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbx_systemlist;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldText;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckTable;
        private System.Windows.Forms.Button btnUnSelect;
        private System.Windows.Forms.Button btnCacheMe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Option;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox txtDelimiter;
    }
}
