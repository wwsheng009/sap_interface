namespace SAPINTGUI.Http
{
    partial class FormRestClient
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cbxUrl = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioBtnPATCH = new System.Windows.Forms.RadioButton();
            this.radioBtnHEAD = new System.Windows.Forms.RadioButton();
            this.radioBtnOPTIONS = new System.Windows.Forms.RadioButton();
            this.radioBtnGET = new System.Windows.Forms.RadioButton();
            this.radioBtnPOST = new System.Windows.Forms.RadioButton();
            this.radioBtnDELETE = new System.Windows.Forms.RadioButton();
            this.radioBtnPUT = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvHeadersReq = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cbxCharSet = new System.Windows.Forms.ComboBox();
            this.txtBodyReq = new System.Windows.Forms.TextBox();
            this.cbxAcceptType = new System.Windows.Forms.ComboBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvFormFieldsReq = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtStatusCode = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dgvHeadersRes = new System.Windows.Forms.DataGridView();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.txtBodyRes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeadersReq)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormFieldsReq)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeadersRes)).BeginInit();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.cbxUrl);
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btnGo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtStatusCode);
            this.splitContainer1.Panel2.Controls.Add(this.txtStatus);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.tabControl2);
            this.splitContainer1.Size = new System.Drawing.Size(827, 470);
            this.splitContainer1.SplitterDistance = 234;
            this.splitContainer1.TabIndex = 1;
            // 
            // cbxUrl
            // 
            this.cbxUrl.FormattingEnabled = true;
            this.cbxUrl.Location = new System.Drawing.Point(49, 7);
            this.cbxUrl.Name = "cbxUrl";
            this.cbxUrl.Size = new System.Drawing.Size(685, 20);
            this.cbxUrl.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(812, 203);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(804, 177);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Method";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioBtnPATCH);
            this.groupBox1.Controls.Add(this.radioBtnHEAD);
            this.groupBox1.Controls.Add(this.radioBtnOPTIONS);
            this.groupBox1.Controls.Add(this.radioBtnGET);
            this.groupBox1.Controls.Add(this.radioBtnPOST);
            this.groupBox1.Controls.Add(this.radioBtnDELETE);
            this.groupBox1.Controls.Add(this.radioBtnPUT);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 130);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "HTTP Method";
            // 
            // radioBtnPATCH
            // 
            this.radioBtnPATCH.AutoSize = true;
            this.radioBtnPATCH.Location = new System.Drawing.Point(7, 101);
            this.radioBtnPATCH.Name = "radioBtnPATCH";
            this.radioBtnPATCH.Size = new System.Drawing.Size(53, 16);
            this.radioBtnPATCH.TabIndex = 6;
            this.radioBtnPATCH.TabStop = true;
            this.radioBtnPATCH.Text = "PATCH";
            this.radioBtnPATCH.UseVisualStyleBackColor = true;
            // 
            // radioBtnHEAD
            // 
            this.radioBtnHEAD.AutoSize = true;
            this.radioBtnHEAD.Location = new System.Drawing.Point(6, 78);
            this.radioBtnHEAD.Name = "radioBtnHEAD";
            this.radioBtnHEAD.Size = new System.Drawing.Size(47, 16);
            this.radioBtnHEAD.TabIndex = 4;
            this.radioBtnHEAD.TabStop = true;
            this.radioBtnHEAD.Text = "HEAD";
            this.radioBtnHEAD.UseVisualStyleBackColor = true;
            // 
            // radioBtnOPTIONS
            // 
            this.radioBtnOPTIONS.AutoSize = true;
            this.radioBtnOPTIONS.Location = new System.Drawing.Point(69, 78);
            this.radioBtnOPTIONS.Name = "radioBtnOPTIONS";
            this.radioBtnOPTIONS.Size = new System.Drawing.Size(65, 16);
            this.radioBtnOPTIONS.TabIndex = 5;
            this.radioBtnOPTIONS.TabStop = true;
            this.radioBtnOPTIONS.Text = "OPTIONS";
            this.radioBtnOPTIONS.UseVisualStyleBackColor = true;
            // 
            // radioBtnGET
            // 
            this.radioBtnGET.AutoSize = true;
            this.radioBtnGET.Location = new System.Drawing.Point(6, 33);
            this.radioBtnGET.Name = "radioBtnGET";
            this.radioBtnGET.Size = new System.Drawing.Size(41, 16);
            this.radioBtnGET.TabIndex = 0;
            this.radioBtnGET.TabStop = true;
            this.radioBtnGET.Text = "GET";
            this.radioBtnGET.UseVisualStyleBackColor = true;
            // 
            // radioBtnPOST
            // 
            this.radioBtnPOST.AutoSize = true;
            this.radioBtnPOST.Location = new System.Drawing.Point(69, 33);
            this.radioBtnPOST.Name = "radioBtnPOST";
            this.radioBtnPOST.Size = new System.Drawing.Size(47, 16);
            this.radioBtnPOST.TabIndex = 1;
            this.radioBtnPOST.TabStop = true;
            this.radioBtnPOST.Text = "POST";
            this.radioBtnPOST.UseVisualStyleBackColor = true;
            // 
            // radioBtnDELETE
            // 
            this.radioBtnDELETE.AutoSize = true;
            this.radioBtnDELETE.Location = new System.Drawing.Point(69, 55);
            this.radioBtnDELETE.Name = "radioBtnDELETE";
            this.radioBtnDELETE.Size = new System.Drawing.Size(59, 16);
            this.radioBtnDELETE.TabIndex = 3;
            this.radioBtnDELETE.TabStop = true;
            this.radioBtnDELETE.Text = "DELETE";
            this.radioBtnDELETE.UseVisualStyleBackColor = true;
            // 
            // radioBtnPUT
            // 
            this.radioBtnPUT.AutoSize = true;
            this.radioBtnPUT.Location = new System.Drawing.Point(6, 55);
            this.radioBtnPUT.Name = "radioBtnPUT";
            this.radioBtnPUT.Size = new System.Drawing.Size(41, 16);
            this.radioBtnPUT.TabIndex = 2;
            this.radioBtnPUT.TabStop = true;
            this.radioBtnPUT.Text = "PUT";
            this.radioBtnPUT.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvHeadersReq);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(804, 177);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Headers";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvHeadersReq
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHeadersReq.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHeadersReq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHeadersReq.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHeadersReq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHeadersReq.Location = new System.Drawing.Point(3, 3);
            this.dgvHeadersReq.Name = "dgvHeadersReq";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHeadersReq.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHeadersReq.RowTemplate.Height = 23;
            this.dgvHeadersReq.Size = new System.Drawing.Size(798, 171);
            this.dgvHeadersReq.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.cbxCharSet);
            this.tabPage3.Controls.Add(this.txtBodyReq);
            this.tabPage3.Controls.Add(this.cbxAcceptType);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(804, 177);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Body";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cbxCharSet
            // 
            this.cbxCharSet.FormattingEnabled = true;
            this.cbxCharSet.Location = new System.Drawing.Point(342, 6);
            this.cbxCharSet.Name = "cbxCharSet";
            this.cbxCharSet.Size = new System.Drawing.Size(121, 20);
            this.cbxCharSet.TabIndex = 2;
            // 
            // txtBodyReq
            // 
            this.txtBodyReq.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBodyReq.Location = new System.Drawing.Point(6, 32);
            this.txtBodyReq.Multiline = true;
            this.txtBodyReq.Name = "txtBodyReq";
            this.txtBodyReq.Size = new System.Drawing.Size(792, 128);
            this.txtBodyReq.TabIndex = 1;
            // 
            // cbxAcceptType
            // 
            this.cbxAcceptType.FormattingEnabled = true;
            this.cbxAcceptType.Location = new System.Drawing.Point(89, 6);
            this.cbxAcceptType.Name = "cbxAcceptType";
            this.cbxAcceptType.Size = new System.Drawing.Size(183, 20);
            this.cbxAcceptType.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgvFormFieldsReq);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(804, 177);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Form";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvFormFieldsReq
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFormFieldsReq.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvFormFieldsReq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFormFieldsReq.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvFormFieldsReq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFormFieldsReq.Location = new System.Drawing.Point(3, 3);
            this.dgvFormFieldsReq.Name = "dgvFormFieldsReq";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFormFieldsReq.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvFormFieldsReq.RowTemplate.Height = 23;
            this.dgvFormFieldsReq.Size = new System.Drawing.Size(798, 171);
            this.dgvFormFieldsReq.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "URL:";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(740, 4);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 1;
            this.btnGo.Text = "GO";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtStatusCode
            // 
            this.txtStatusCode.Location = new System.Drawing.Point(68, 4);
            this.txtStatusCode.Name = "txtStatusCode";
            this.txtStatusCode.Size = new System.Drawing.Size(152, 21);
            this.txtStatusCode.TabIndex = 3;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(267, 3);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(548, 21);
            this.txtStatus.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Status:";
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Location = new System.Drawing.Point(12, 30);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(812, 199);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dgvHeadersRes);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(804, 173);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "Headers";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dgvHeadersRes
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHeadersRes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvHeadersRes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHeadersRes.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvHeadersRes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHeadersRes.Location = new System.Drawing.Point(3, 3);
            this.dgvHeadersRes.Name = "dgvHeadersRes";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHeadersRes.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvHeadersRes.RowTemplate.Height = 23;
            this.dgvHeadersRes.Size = new System.Drawing.Size(798, 167);
            this.dgvHeadersRes.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.txtBodyRes);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(804, 173);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "Body";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // txtBodyRes
            // 
            this.txtBodyRes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBodyRes.Location = new System.Drawing.Point(3, 3);
            this.txtBodyRes.Multiline = true;
            this.txtBodyRes.Name = "txtBodyRes";
            this.txtBodyRes.Size = new System.Drawing.Size(798, 167);
            this.txtBodyRes.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "Accept-Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(289, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "Charset";
            // 
            // FormRestClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 470);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormRestClient";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeadersReq)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormFieldsReq)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeadersRes)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxUrl;
        private System.Windows.Forms.RadioButton radioBtnDELETE;
        private System.Windows.Forms.RadioButton radioBtnPUT;
        private System.Windows.Forms.RadioButton radioBtnPOST;
        private System.Windows.Forms.RadioButton radioBtnGET;
        private System.Windows.Forms.RadioButton radioBtnHEAD;
        private System.Windows.Forms.RadioButton radioBtnOPTIONS;
        private System.Windows.Forms.RadioButton radioBtnPATCH;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxAcceptType;
        private System.Windows.Forms.TextBox txtBodyReq;
        private System.Windows.Forms.DataGridView dgvFormFieldsReq;
        private System.Windows.Forms.DataGridView dgvHeadersReq;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dgvHeadersRes;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TextBox txtBodyRes;
        private System.Windows.Forms.TextBox txtStatusCode;
        private System.Windows.Forms.ComboBox cbxCharSet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;

    }
}