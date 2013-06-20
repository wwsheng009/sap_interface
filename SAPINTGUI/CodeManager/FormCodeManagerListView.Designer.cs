namespace SAPINT.Gui.CodeManager
{
    partial class FormCodeManagerListView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCodeManagerListView));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAddTopFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.reNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDeleteFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemImportFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemImportFromSap = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.SetTempFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NewCodeStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reNameCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEditCode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDeleteCode = new System.Windows.Forms.ToolStripMenuItem();
            this.chFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.SetTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SetRunCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syntaxDocument1 = new Alsing.SourceCode.SyntaxDocument(this.components);
            this.syntaxDocument2 = new Alsing.SourceCode.SyntaxDocument(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new SAPINT.Gui.TreeViewNF();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFolderToolStripMenuItem,
            this.newFileToolStripMenuItem,
            this.ToolStripMenuItemAddTopFolder,
            this.toolStripSeparator1,
            this.reNameToolStripMenuItem,
            this.toolStripMenuItemDeleteFolder,
            this.toolStripSeparator2,
            this.toolStripMenuItemImportFile,
            this.toolStripMenuItemImportFromSap,
            this.toolStripSeparator4,
            this.SetTempFolderToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 198);
            // 
            // newFolderToolStripMenuItem
            // 
            this.newFolderToolStripMenuItem.Name = "newFolderToolStripMenuItem";
            this.newFolderToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.newFolderToolStripMenuItem.Text = "新建文件夹";
            this.newFolderToolStripMenuItem.Click += new System.EventHandler(this.newFolderToolStripMenuItem_Click);
            // 
            // newFileToolStripMenuItem
            // 
            this.newFileToolStripMenuItem.Name = "newFileToolStripMenuItem";
            this.newFileToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.newFileToolStripMenuItem.Text = "新建代码";
            this.newFileToolStripMenuItem.Click += new System.EventHandler(this.newFileToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemAddTopFolder
            // 
            this.ToolStripMenuItemAddTopFolder.Name = "ToolStripMenuItemAddTopFolder";
            this.ToolStripMenuItemAddTopFolder.Size = new System.Drawing.Size(160, 22);
            this.ToolStripMenuItemAddTopFolder.Text = "新建顶层文件夹";
            this.ToolStripMenuItemAddTopFolder.Click += new System.EventHandler(this.ToolStripMenuItemAddTopFolder_Click_1);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // reNameToolStripMenuItem
            // 
            this.reNameToolStripMenuItem.Name = "reNameToolStripMenuItem";
            this.reNameToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.reNameToolStripMenuItem.Text = "重命名";
            this.reNameToolStripMenuItem.Click += new System.EventHandler(this.reNameToolStripMenuItem_Click);
            // 
            // toolStripMenuItemDeleteFolder
            // 
            this.toolStripMenuItemDeleteFolder.Name = "toolStripMenuItemDeleteFolder";
            this.toolStripMenuItemDeleteFolder.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItemDeleteFolder.Text = "删除文件夹";
            this.toolStripMenuItemDeleteFolder.Click += new System.EventHandler(this.toolStripMenuItemDeleteFolder_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(157, 6);
            // 
            // toolStripMenuItemImportFile
            // 
            this.toolStripMenuItemImportFile.Name = "toolStripMenuItemImportFile";
            this.toolStripMenuItemImportFile.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItemImportFile.Text = "导入代码文件";
            this.toolStripMenuItemImportFile.Click += new System.EventHandler(this.toolStripMenuItemImportFile_Click);
            // 
            // toolStripMenuItemImportFromSap
            // 
            this.toolStripMenuItemImportFromSap.Name = "toolStripMenuItemImportFromSap";
            this.toolStripMenuItemImportFromSap.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItemImportFromSap.Text = "从SAP导入代码";
            this.toolStripMenuItemImportFromSap.Click += new System.EventHandler(this.toolStripMenuItemImportFromSap_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(157, 6);
            // 
            // SetTempFolderToolStripMenuItem
            // 
            this.SetTempFolderToolStripMenuItem.Name = "SetTempFolderToolStripMenuItem";
            this.SetTempFolderToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.SetTempFolderToolStripMenuItem.Text = "设置临时文件夹";
            this.SetTempFolderToolStripMenuItem.Click += new System.EventHandler(this.SetTempFolderToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "21.ico");
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewCodeStripMenuItem1,
            this.reNameCodeToolStripMenuItem,
            this.toolStripMenuItemEditCode,
            this.toolStripMenuItemDeleteCode,
            this.chFolderToolStripMenuItem,
            this.toolStripSeparator3,
            this.SetTemplateToolStripMenuItem,
            this.SetRunCodeToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(173, 164);
            // 
            // NewCodeStripMenuItem1
            // 
            this.NewCodeStripMenuItem1.Name = "NewCodeStripMenuItem1";
            this.NewCodeStripMenuItem1.Size = new System.Drawing.Size(172, 22);
            this.NewCodeStripMenuItem1.Text = "新建代码";
            this.NewCodeStripMenuItem1.Click += new System.EventHandler(this.NewCodeStripMenuItem1_Click);
            // 
            // reNameCodeToolStripMenuItem
            // 
            this.reNameCodeToolStripMenuItem.Name = "reNameCodeToolStripMenuItem";
            this.reNameCodeToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.reNameCodeToolStripMenuItem.Text = "重命名";
            this.reNameCodeToolStripMenuItem.Click += new System.EventHandler(this.reNameCodeToolStripMenuItem_Click);
            // 
            // toolStripMenuItemEditCode
            // 
            this.toolStripMenuItemEditCode.Name = "toolStripMenuItemEditCode";
            this.toolStripMenuItemEditCode.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItemEditCode.Text = "编辑代码";
            this.toolStripMenuItemEditCode.Click += new System.EventHandler(this.toolStripMenuItemEditCode_Click);
            // 
            // toolStripMenuItemDeleteCode
            // 
            this.toolStripMenuItemDeleteCode.Name = "toolStripMenuItemDeleteCode";
            this.toolStripMenuItemDeleteCode.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItemDeleteCode.Text = "删除代码";
            this.toolStripMenuItemDeleteCode.Click += new System.EventHandler(this.toolStripMenuItemDeleteCode_Click);
            // 
            // chFolderToolStripMenuItem
            // 
            this.chFolderToolStripMenuItem.Name = "chFolderToolStripMenuItem";
            this.chFolderToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.chFolderToolStripMenuItem.Text = "修改文件夹";
            this.chFolderToolStripMenuItem.Click += new System.EventHandler(this.chFolderToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(169, 6);
            // 
            // SetTemplateToolStripMenuItem
            // 
            this.SetTemplateToolStripMenuItem.Name = "SetTemplateToolStripMenuItem";
            this.SetTemplateToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.SetTemplateToolStripMenuItem.Text = "设定为模板";
            this.SetTemplateToolStripMenuItem.Click += new System.EventHandler(this.lockCodeToolStripMenuItem_Click);
            // 
            // SetRunCodeToolStripMenuItem
            // 
            this.SetRunCodeToolStripMenuItem.Name = "SetRunCodeToolStripMenuItem";
            this.SetRunCodeToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.SetRunCodeToolStripMenuItem.Text = "设定为待运行代码";
            this.SetRunCodeToolStripMenuItem.Click += new System.EventHandler(this.SetRunCodeToolStripMenuItem_Click);
            // 
            // syntaxDocument1
            // 
            this.syntaxDocument1.Lines = new string[] {
        ""};
            this.syntaxDocument1.MaxUndoBufferSize = 1000;
            this.syntaxDocument1.Modified = false;
            this.syntaxDocument1.UndoStep = 0;
            // 
            // syntaxDocument2
            // 
            this.syntaxDocument2.Lines = new string[] {
        ""};
            this.syntaxDocument2.MaxUndoBufferSize = 1000;
            this.syntaxDocument2.Modified = false;
            this.syntaxDocument2.UndoStep = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer2.Size = new System.Drawing.Size(569, 430);
            this.splitContainer2.SplitterDistance = 269;
            this.splitContainer2.TabIndex = 24;
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.ItemHeight = 25;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(269, 430);
            this.treeView1.TabIndex = 0;
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
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip2;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(296, 430);
            this.dataGridView1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel3,
            this.progressBar1,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel2,
            this.toolStripSplitButton1,
            this.toolStripSplitButton2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 430);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(569, 22);
            this.statusStrip1.TabIndex = 32;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel3.Text = "加载进度:";
            // 
            // progressBar1
            // 
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusLabel1.Text = "状态";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(96, 17);
            this.toolStripStatusLabel4.Text = "选中的文件夹ID:";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(93, 17);
            this.toolStripStatusLabel2.Text = "选中的文件夹ID";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 20);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            this.toolStripSplitButton1.ButtonClick += new System.EventHandler(this.toolStripSplitButton1_ButtonClick);
            // 
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton2.Image")));
            this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Size = new System.Drawing.Size(32, 20);
            this.toolStripSplitButton2.Text = "toolStripSplitButton2";
            this.toolStripSplitButton2.ButtonClick += new System.EventHandler(this.toolStripSplitButton2_ButtonClick);
            // 
            // FormCodeManagerListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 452);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FormCodeManagerListView";
            this.Text = "代码管理";
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TreeViewNF treeView1;
        private Alsing.SourceCode.SyntaxDocument syntaxDocument1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem reNameToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEditCode;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDeleteCode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemImportFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemImportFromSap;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDeleteFolder;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddTopFolder;
        private Alsing.SourceCode.SyntaxDocument syntaxDocument2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripMenuItem chFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reNameCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SetTemplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem SetRunCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem SetTempFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewCodeStripMenuItem1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar progressBar1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}