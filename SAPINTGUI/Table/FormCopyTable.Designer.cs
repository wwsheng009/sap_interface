namespace SAPINT.Gui
{
    partial class FormCopyTable
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle157 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle158 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle159 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle160 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle161 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle162 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgvTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCopy = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSourceTableName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRowCount = new System.Windows.Forms.TextBox();
            this.lable4 = new System.Windows.Forms.Label();
            this.btnBatchInput = new System.Windows.Forms.Button();
            this.chkInsert = new System.Windows.Forms.CheckBox();
            this.dgvConditioin = new System.Windows.Forms.DataGridView();
            this.Option = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkModify = new System.Windows.Forms.CheckBox();
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.textBoxTargetTableName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnReadTable = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxImportDelimiter = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupboxImport = new System.Windows.Forms.GroupBox();
            this.textBoxTargetSystem = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDelimiter = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxSourceSystem = new System.Windows.Forms.ComboBox();
            this.btnSaveToDataBase = new System.Windows.Forms.Button();
            this.checkBoxPreView = new System.Windows.Forms.CheckBox();
            this.dgvPreviewTable = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConditioin)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupboxImport.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreviewTable)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle157.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle157.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle157.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle157.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle157.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle157.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle157.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle157;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvTableName,
            this.dgvResult});
            dataGridViewCellStyle158.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle158.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle158.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle158.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle158.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle158.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle158.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle158;
            this.dataGridView1.Location = new System.Drawing.Point(6, 45);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle159.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle159.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle159.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle159.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle159.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle159.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle159.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle159;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(232, 364);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // dgvTableName
            // 
            this.dgvTableName.HeaderText = "TableName";
            this.dgvTableName.Name = "dgvTableName";
            // 
            // dgvResult
            // 
            this.dgvResult.HeaderText = "Result";
            this.dgvResult.Name = "dgvResult";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(361, 47);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(98, 50);
            this.btnCopy.TabIndex = 3;
            this.btnCopy.Text = "直接导出导入(不显示表内容)";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "源系统";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "目标系统";
            // 
            // textBoxSourceTableName
            // 
            this.textBoxSourceTableName.Location = new System.Drawing.Point(71, 45);
            this.textBoxSourceTableName.Name = "textBoxSourceTableName";
            this.textBoxSourceTableName.Size = new System.Drawing.Size(160, 21);
            this.textBoxSourceTableName.TabIndex = 6;
            this.textBoxSourceTableName.Text = "ZFI001";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "数据库表";
            // 
            // txtRowCount
            // 
            this.txtRowCount.Location = new System.Drawing.Point(71, 72);
            this.txtRowCount.Name = "txtRowCount";
            this.txtRowCount.Size = new System.Drawing.Size(52, 21);
            this.txtRowCount.TabIndex = 8;
            this.txtRowCount.Text = "500";
            // 
            // lable4
            // 
            this.lable4.AutoSize = true;
            this.lable4.Location = new System.Drawing.Point(9, 76);
            this.lable4.Name = "lable4";
            this.lable4.Size = new System.Drawing.Size(53, 12);
            this.lable4.TabIndex = 9;
            this.lable4.Text = "最大行数";
            // 
            // btnBatchInput
            // 
            this.btnBatchInput.Location = new System.Drawing.Point(6, 16);
            this.btnBatchInput.Name = "btnBatchInput";
            this.btnBatchInput.Size = new System.Drawing.Size(110, 27);
            this.btnBatchInput.TabIndex = 10;
            this.btnBatchInput.Text = "批量导入";
            this.btnBatchInput.UseVisualStyleBackColor = true;
            this.btnBatchInput.Click += new System.EventHandler(this.btnBatchInput_Click);
            // 
            // chkInsert
            // 
            this.chkInsert.AutoSize = true;
            this.chkInsert.Location = new System.Drawing.Point(6, 93);
            this.chkInsert.Name = "chkInsert";
            this.chkInsert.Size = new System.Drawing.Size(84, 16);
            this.chkInsert.TabIndex = 10;
            this.chkInsert.Text = "是否插入表";
            this.chkInsert.UseVisualStyleBackColor = true;
            // 
            // dgvConditioin
            // 
            this.dgvConditioin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle160.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle160.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle160.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle160.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle160.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle160.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle160.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConditioin.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle160;
            this.dgvConditioin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConditioin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Option});
            dataGridViewCellStyle161.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle161.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle161.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle161.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle161.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle161.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle161.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvConditioin.DefaultCellStyle = dataGridViewCellStyle161;
            this.dgvConditioin.Location = new System.Drawing.Point(11, 109);
            this.dgvConditioin.Name = "dgvConditioin";
            dataGridViewCellStyle162.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle162.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle162.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle162.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle162.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle162.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle162.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConditioin.RowHeadersDefaultCellStyle = dataGridViewCellStyle162;
            this.dgvConditioin.RowHeadersWidth = 20;
            this.dgvConditioin.RowTemplate.Height = 23;
            this.dgvConditioin.Size = new System.Drawing.Size(477, 289);
            this.dgvConditioin.TabIndex = 12;
            this.dgvConditioin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvConditioin_KeyDown);
            // 
            // Option
            // 
            this.Option.HeaderText = "条件";
            this.Option.Name = "Option";
            this.Option.Width = 200;
            // 
            // chkModify
            // 
            this.chkModify.AutoSize = true;
            this.chkModify.Checked = true;
            this.chkModify.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkModify.Location = new System.Drawing.Point(6, 71);
            this.chkModify.Name = "chkModify";
            this.chkModify.Size = new System.Drawing.Size(84, 16);
            this.chkModify.TabIndex = 10;
            this.chkModify.Text = "是否修改表";
            this.chkModify.UseVisualStyleBackColor = true;
            // 
            // chkUpdate
            // 
            this.chkUpdate.AutoSize = true;
            this.chkUpdate.Location = new System.Drawing.Point(6, 49);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(84, 16);
            this.chkUpdate.TabIndex = 10;
            this.chkUpdate.Text = "是否更新表";
            this.chkUpdate.UseVisualStyleBackColor = true;
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Location = new System.Drawing.Point(6, 27);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(120, 16);
            this.chkDelete.TabIndex = 10;
            this.chkDelete.Text = "是否更新前清空表";
            this.chkDelete.UseVisualStyleBackColor = true;
            // 
            // textBoxLog
            // 
            this.textBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLog.Location = new System.Drawing.Point(0, 135);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxLog.Size = new System.Drawing.Size(486, 274);
            this.textBoxLog.TabIndex = 13;
            // 
            // textBoxTargetTableName
            // 
            this.textBoxTargetTableName.Location = new System.Drawing.Point(65, 45);
            this.textBoxTargetTableName.Name = "textBoxTargetTableName";
            this.textBoxTargetTableName.Size = new System.Drawing.Size(163, 21);
            this.textBoxTargetTableName.TabIndex = 6;
            this.textBoxTargetTableName.Text = "ZFI001";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "数据库表";
            // 
            // btnReadTable
            // 
            this.btnReadTable.Location = new System.Drawing.Point(237, 47);
            this.btnReadTable.Name = "btnReadTable";
            this.btnReadTable.Size = new System.Drawing.Size(58, 51);
            this.btnReadTable.TabIndex = 13;
            this.btnReadTable.Text = "读取表";
            this.btnReadTable.UseVisualStyleBackColor = true;
            this.btnReadTable.Click += new System.EventHandler(this.btnReadTable_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(10, 76);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(77, 46);
            this.btnImport.TabIndex = 16;
            this.btnImport.Text = "导入数据库表";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxImportDelimiter);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.chkDelete);
            this.groupBox1.Controls.Add(this.chkModify);
            this.groupBox1.Controls.Add(this.chkUpdate);
            this.groupBox1.Controls.Add(this.chkInsert);
            this.groupBox1.Location = new System.Drawing.Point(234, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 112);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "导入选项";
            // 
            // cbxImportDelimiter
            // 
            this.cbxImportDelimiter.FormattingEnabled = true;
            this.cbxImportDelimiter.Items.AddRange(new object[] {
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
            this.cbxImportDelimiter.Location = new System.Drawing.Point(167, 86);
            this.cbxImportDelimiter.Name = "cbxImportDelimiter";
            this.cbxImportDelimiter.Size = new System.Drawing.Size(44, 20);
            this.cbxImportDelimiter.TabIndex = 27;
            this.cbxImportDelimiter.Text = "※";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(120, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 26;
            this.label6.Text = "分隔符";
            // 
            // groupboxImport
            // 
            this.groupboxImport.Controls.Add(this.textBoxLog);
            this.groupboxImport.Controls.Add(this.textBoxTargetSystem);
            this.groupboxImport.Controls.Add(this.groupBox1);
            this.groupboxImport.Controls.Add(this.btnImport);
            this.groupboxImport.Controls.Add(this.label4);
            this.groupboxImport.Controls.Add(this.label2);
            this.groupboxImport.Controls.Add(this.textBoxTargetTableName);
            this.groupboxImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupboxImport.Location = new System.Drawing.Point(753, 3);
            this.groupboxImport.Name = "groupboxImport";
            this.groupboxImport.Size = new System.Drawing.Size(495, 415);
            this.groupboxImport.TabIndex = 17;
            this.groupboxImport.TabStop = false;
            this.groupboxImport.Text = "导入SAP数据库";
            // 
            // textBoxTargetSystem
            // 
            this.textBoxTargetSystem.FormattingEnabled = true;
            this.textBoxTargetSystem.Location = new System.Drawing.Point(65, 17);
            this.textBoxTargetSystem.Name = "textBoxTargetSystem";
            this.textBoxTargetSystem.Size = new System.Drawing.Size(162, 20);
            this.textBoxTargetSystem.TabIndex = 19;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDelimiter);
            this.groupBox2.Controls.Add(this.btnCopy);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBoxSourceSystem);
            this.groupBox2.Controls.Add(this.btnSaveToDataBase);
            this.groupBox2.Controls.Add(this.checkBoxPreView);
            this.groupBox2.Controls.Add(this.btnReadTable);
            this.groupBox2.Controls.Add(this.textBoxSourceTableName);
            this.groupBox2.Controls.Add(this.lable4);
            this.groupBox2.Controls.Add(this.dgvConditioin);
            this.groupBox2.Controls.Add(this.txtRowCount);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(494, 415);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "从SAP数据库导出数据";
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
            this.txtDelimiter.Location = new System.Drawing.Point(187, 72);
            this.txtDelimiter.Name = "txtDelimiter";
            this.txtDelimiter.Size = new System.Drawing.Size(44, 20);
            this.txtDelimiter.TabIndex = 25;
            this.txtDelimiter.Text = "※";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(140, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "分隔符";
            // 
            // textBoxSourceSystem
            // 
            this.textBoxSourceSystem.FormattingEnabled = true;
            this.textBoxSourceSystem.Location = new System.Drawing.Point(71, 20);
            this.textBoxSourceSystem.Name = "textBoxSourceSystem";
            this.textBoxSourceSystem.Size = new System.Drawing.Size(160, 20);
            this.textBoxSourceSystem.TabIndex = 17;
            // 
            // btnSaveToDataBase
            // 
            this.btnSaveToDataBase.Location = new System.Drawing.Point(301, 48);
            this.btnSaveToDataBase.Name = "btnSaveToDataBase";
            this.btnSaveToDataBase.Size = new System.Drawing.Size(54, 49);
            this.btnSaveToDataBase.TabIndex = 16;
            this.btnSaveToDataBase.Text = "保存到数据库";
            this.btnSaveToDataBase.UseVisualStyleBackColor = true;
            this.btnSaveToDataBase.Click += new System.EventHandler(this.btnSaveToDataBase_Click);
            // 
            // checkBoxPreView
            // 
            this.checkBoxPreView.AutoSize = true;
            this.checkBoxPreView.Location = new System.Drawing.Point(247, 19);
            this.checkBoxPreView.Name = "checkBoxPreView";
            this.checkBoxPreView.Size = new System.Drawing.Size(108, 16);
            this.checkBoxPreView.TabIndex = 14;
            this.checkBoxPreView.Text = "预览倒出的数据";
            this.checkBoxPreView.UseVisualStyleBackColor = true;
            // 
            // dgvPreviewTable
            // 
            this.dgvPreviewTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreviewTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPreviewTable.Location = new System.Drawing.Point(0, 0);
            this.dgvPreviewTable.Name = "dgvPreviewTable";
            this.dgvPreviewTable.RowTemplate.Height = 23;
            this.dgvPreviewTable.Size = new System.Drawing.Size(1251, 306);
            this.dgvPreviewTable.TabIndex = 15;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Controls.Add(this.btnBatchInput);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(503, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(244, 415);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "批量处理";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvPreviewTable);
            this.splitContainer1.Size = new System.Drawing.Size(1251, 731);
            this.splitContainer1.SplitterDistance = 421;
            this.splitContainer1.TabIndex = 20;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.groupboxImport, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1251, 421);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // FormCopyTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1251, 731);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormCopyTable";
            this.Text = "数据导出导入";
            this.TransparencyKey = System.Drawing.Color.Yellow;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConditioin)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupboxImport.ResumeLayout(false);
            this.groupboxImport.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreviewTable)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSourceTableName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRowCount;
        private System.Windows.Forms.Label lable4;
        private System.Windows.Forms.Button btnBatchInput;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvResult;
        private System.Windows.Forms.DataGridView dgvConditioin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Option;
        private System.Windows.Forms.CheckBox chkInsert;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.CheckBox chkUpdate;
        private System.Windows.Forms.CheckBox chkModify;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.TextBox textBoxTargetTableName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnReadTable;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupboxImport;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxPreView;
        private System.Windows.Forms.DataGridView dgvPreviewTable;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSaveToDataBase;
        private System.Windows.Forms.ComboBox textBoxSourceSystem;
        private System.Windows.Forms.ComboBox textBoxTargetSystem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox txtDelimiter;
        private System.Windows.Forms.ComboBox cbxImportDelimiter;
        private System.Windows.Forms.Label label6;
    }
}
