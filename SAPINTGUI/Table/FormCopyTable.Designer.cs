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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.btnSaveToFile = new System.Windows.Forms.Button();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.dgvFields = new System.Windows.Forms.DataGridView();
            this.Field = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OFFSET = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LENGTH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbxDelimiter = new System.Windows.Forms.ComboBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvFields)).BeginInit();
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
            this.dgvTableName,
            this.dgvResult});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(6, 44);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(266, 365);
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
            this.btnCopy.Location = new System.Drawing.Point(527, 43);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(106, 50);
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
            this.label2.Location = new System.Drawing.Point(6, 17);
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
            this.textBoxSourceTableName.Text = "ZVI_MAKT1";
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
            this.btnBatchInput.Text = "批量整表导入";
            this.btnBatchInput.UseVisualStyleBackColor = true;
            this.btnBatchInput.Click += new System.EventHandler(this.btnBatchInput_Click);
            // 
            // chkInsert
            // 
            this.chkInsert.AutoSize = true;
            this.chkInsert.Location = new System.Drawing.Point(6, 93);
            this.chkInsert.Name = "chkInsert";
            this.chkInsert.Size = new System.Drawing.Size(96, 16);
            this.chkInsert.TabIndex = 10;
            this.chkInsert.Text = "插入表INSERT";
            this.chkInsert.UseVisualStyleBackColor = true;
            // 
            // dgvConditioin
            // 
            this.dgvConditioin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConditioin.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvConditioin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConditioin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Option});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvConditioin.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvConditioin.Location = new System.Drawing.Point(11, 109);
            this.dgvConditioin.Name = "dgvConditioin";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConditioin.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvConditioin.RowHeadersWidth = 20;
            this.dgvConditioin.RowTemplate.Height = 23;
            this.dgvConditioin.Size = new System.Drawing.Size(245, 306);
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
            this.chkModify.Size = new System.Drawing.Size(96, 16);
            this.chkModify.TabIndex = 10;
            this.chkModify.Text = "修改表MODIFY";
            this.chkModify.UseVisualStyleBackColor = true;
            // 
            // chkUpdate
            // 
            this.chkUpdate.AutoSize = true;
            this.chkUpdate.Location = new System.Drawing.Point(6, 49);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(96, 16);
            this.chkUpdate.TabIndex = 10;
            this.chkUpdate.Text = "更新表UPDATE";
            this.chkUpdate.UseVisualStyleBackColor = true;
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Checked = true;
            this.chkDelete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDelete.Location = new System.Drawing.Point(6, 27);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(96, 16);
            this.chkDelete.TabIndex = 10;
            this.chkDelete.Text = "清空表DELETE";
            this.chkDelete.UseVisualStyleBackColor = true;
            // 
            // textBoxLog
            // 
            this.textBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLog.Location = new System.Drawing.Point(8, 241);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxLog.Size = new System.Drawing.Size(223, 168);
            this.textBoxLog.TabIndex = 13;
            // 
            // textBoxTargetTableName
            // 
            this.textBoxTargetTableName.Location = new System.Drawing.Point(64, 44);
            this.textBoxTargetTableName.Name = "textBoxTargetTableName";
            this.textBoxTargetTableName.Size = new System.Drawing.Size(163, 21);
            this.textBoxTargetTableName.TabIndex = 6;
            this.textBoxTargetTableName.Text = "ZVI_MAKT2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 47);
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
            this.btnImport.Location = new System.Drawing.Point(7, 189);
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
            this.groupBox1.Location = new System.Drawing.Point(7, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 112);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "导入选项";
            // 
            // cbxImportDelimiter
            // 
            this.cbxImportDelimiter.FormattingEnabled = true;
            this.cbxImportDelimiter.Items.AddRange(new object[] {
            "",
            "\\t",
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
            this.cbxImportDelimiter.Location = new System.Drawing.Point(155, 25);
            this.cbxImportDelimiter.Name = "cbxImportDelimiter";
            this.cbxImportDelimiter.Size = new System.Drawing.Size(44, 20);
            this.cbxImportDelimiter.TabIndex = 27;
            this.cbxImportDelimiter.Text = "※";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(108, 28);
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
            this.groupboxImport.Location = new System.Drawing.Point(1011, 3);
            this.groupboxImport.Name = "groupboxImport";
            this.groupboxImport.Size = new System.Drawing.Size(237, 415);
            this.groupboxImport.TabIndex = 17;
            this.groupboxImport.TabStop = false;
            this.groupboxImport.Text = "导入SAP数据库";
            // 
            // textBoxTargetSystem
            // 
            this.textBoxTargetSystem.FormattingEnabled = true;
            this.textBoxTargetSystem.Location = new System.Drawing.Point(65, 12);
            this.textBoxTargetSystem.Name = "textBoxTargetSystem";
            this.textBoxTargetSystem.Size = new System.Drawing.Size(162, 20);
            this.textBoxTargetSystem.TabIndex = 19;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSaveToFile);
            this.groupBox2.Controls.Add(this.btnLoadFile);
            this.groupBox2.Controls.Add(this.dgvFields);
            this.groupBox2.Controls.Add(this.cbxDelimiter);
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
            this.groupBox2.Size = new System.Drawing.Size(677, 415);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "从SAP数据库导出数据";
            // 
            // btnSaveToFile
            // 
            this.btnSaveToFile.Location = new System.Drawing.Point(372, 72);
            this.btnSaveToFile.Name = "btnSaveToFile";
            this.btnSaveToFile.Size = new System.Drawing.Size(75, 23);
            this.btnSaveToFile.TabIndex = 28;
            this.btnSaveToFile.Text = "保存到文件";
            this.btnSaveToFile.UseVisualStyleBackColor = true;
            this.btnSaveToFile.Click += new System.EventHandler(this.btnSaveToFile_Click);
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(372, 48);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(75, 23);
            this.btnLoadFile.TabIndex = 27;
            this.btnLoadFile.Text = "加载文件";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // dgvFields
            // 
            this.dgvFields.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFields.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Field,
            this.OFFSET,
            this.LENGTH});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFields.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvFields.Location = new System.Drawing.Point(262, 109);
            this.dgvFields.Name = "dgvFields";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFields.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvFields.RowTemplate.Height = 23;
            this.dgvFields.Size = new System.Drawing.Size(371, 305);
            this.dgvFields.TabIndex = 26;
            // 
            // Field
            // 
            this.Field.HeaderText = "字段";
            this.Field.Name = "Field";
            this.Field.Width = 150;
            // 
            // OFFSET
            // 
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = null;
            this.OFFSET.DefaultCellStyle = dataGridViewCellStyle8;
            this.OFFSET.HeaderText = "偏移";
            this.OFFSET.Name = "OFFSET";
            // 
            // LENGTH
            // 
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.NullValue = null;
            this.LENGTH.DefaultCellStyle = dataGridViewCellStyle9;
            this.LENGTH.HeaderText = "长度";
            this.LENGTH.Name = "LENGTH";
            // 
            // cbxDelimiter
            // 
            this.cbxDelimiter.FormattingEnabled = true;
            this.cbxDelimiter.Items.AddRange(new object[] {
            "",
            "\\t",
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
            this.cbxDelimiter.Location = new System.Drawing.Point(187, 72);
            this.cbxDelimiter.Name = "cbxDelimiter";
            this.cbxDelimiter.Size = new System.Drawing.Size(44, 20);
            this.cbxDelimiter.TabIndex = 25;
            this.cbxDelimiter.Text = "※";
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
            this.groupBox3.Location = new System.Drawing.Point(686, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(319, 415);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "批量处理";
            // 
            // splitContainer1
            // 
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.59632F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.97922F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.33502F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupboxImport, 2, 0);
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
            this.ClientSize = new System.Drawing.Size(1251, 564);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvFields)).EndInit();
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
        private System.Windows.Forms.ComboBox cbxDelimiter;
        private System.Windows.Forms.ComboBox cbxImportDelimiter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvFields;
        private System.Windows.Forms.DataGridViewTextBoxColumn Field;
        private System.Windows.Forms.DataGridViewTextBoxColumn OFFSET;
        private System.Windows.Forms.DataGridViewTextBoxColumn LENGTH;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.Button btnSaveToFile;
    }
}
