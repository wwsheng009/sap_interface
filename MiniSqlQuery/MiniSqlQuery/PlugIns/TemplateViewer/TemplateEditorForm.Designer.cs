namespace MiniSqlQuery.PlugIns.TemplateViewer
{
	partial class TemplateEditorForm : ITemplateEditor
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageTemplateSource = new System.Windows.Forms.TabPage();
            this.txtEdit = new Alsing.Windows.Forms.SyntaxBoxControl();
            this.syntaxDocument1 = new Alsing.SourceCode.SyntaxDocument(this.components);
            this.tabPageHelp = new System.Windows.Forms.TabPage();
            this.rtfHelp = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtErrors = new System.Windows.Forms.TextBox();
            this.formContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPageTemplateSource.SuspendLayout();
            this.tabPageHelp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageTemplateSource);
            this.tabControl1.Controls.Add(this.tabPageHelp);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(547, 346);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPageTemplateSource
            // 
            this.tabPageTemplateSource.Controls.Add(this.txtEdit);
            this.tabPageTemplateSource.Location = new System.Drawing.Point(4, 22);
            this.tabPageTemplateSource.Name = "tabPageTemplateSource";
            this.tabPageTemplateSource.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTemplateSource.Size = new System.Drawing.Size(539, 320);
            this.tabPageTemplateSource.TabIndex = 0;
            this.tabPageTemplateSource.Text = "Template Source";
            this.tabPageTemplateSource.UseVisualStyleBackColor = true;
            // 
            // txtEdit
            // 
            this.txtEdit.ActiveView = Alsing.Windows.Forms.ActiveView.BottomRight;
            this.txtEdit.AutoListPosition = null;
            this.txtEdit.AutoListSelectedText = "a123";
            this.txtEdit.AutoListVisible = false;
            this.txtEdit.BackColor = System.Drawing.Color.White;
            this.txtEdit.BorderStyle = Alsing.Windows.Forms.BorderStyle.None;
            this.txtEdit.CopyAsRTF = false;
            this.txtEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEdit.Document = this.syntaxDocument1;
            this.txtEdit.FontName = "Courier new";
            this.txtEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtEdit.InfoTipCount = 1;
            this.txtEdit.InfoTipPosition = null;
            this.txtEdit.InfoTipSelectedIndex = 1;
            this.txtEdit.InfoTipVisible = false;
            this.txtEdit.Location = new System.Drawing.Point(3, 3);
            this.txtEdit.LockCursorUpdate = false;
            this.txtEdit.Name = "txtEdit";
            this.txtEdit.ShowScopeIndicator = false;
            this.txtEdit.Size = new System.Drawing.Size(533, 314);
            this.txtEdit.SmoothScroll = false;
            this.txtEdit.SplitviewH = -4;
            this.txtEdit.SplitviewV = -4;
            this.txtEdit.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.txtEdit.TabIndex = 0;
            this.txtEdit.Text = "syntaxBoxControl1";
            this.txtEdit.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
            // 
            // syntaxDocument1
            // 
            this.syntaxDocument1.Lines = new string[] {
        ""};
            this.syntaxDocument1.MaxUndoBufferSize = 1000;
            this.syntaxDocument1.Modified = false;
            this.syntaxDocument1.UndoStep = 0;
            // 
            // tabPageHelp
            // 
            this.tabPageHelp.Controls.Add(this.rtfHelp);
            this.tabPageHelp.Location = new System.Drawing.Point(4, 22);
            this.tabPageHelp.Name = "tabPageHelp";
            this.tabPageHelp.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHelp.Size = new System.Drawing.Size(539, 320);
            this.tabPageHelp.TabIndex = 1;
            this.tabPageHelp.Text = "Quick Help";
            this.tabPageHelp.UseVisualStyleBackColor = true;
            // 
            // rtfHelp
            // 
            this.rtfHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtfHelp.Location = new System.Drawing.Point(3, 3);
            this.rtfHelp.Name = "rtfHelp";
            this.rtfHelp.ReadOnly = true;
            this.rtfHelp.ShowSelectionMargin = true;
            this.rtfHelp.Size = new System.Drawing.Size(533, 314);
            this.rtfHelp.TabIndex = 0;
            this.rtfHelp.Text = "";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(4, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtErrors);
            this.splitContainer1.Size = new System.Drawing.Size(547, 437);
            this.splitContainer1.SplitterDistance = 346;
            this.splitContainer1.TabIndex = 2;
            // 
            // txtErrors
            // 
            this.txtErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtErrors.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtErrors.Location = new System.Drawing.Point(0, 0);
            this.txtErrors.Multiline = true;
            this.txtErrors.Name = "txtErrors";
            this.txtErrors.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtErrors.Size = new System.Drawing.Size(547, 87);
            this.txtErrors.TabIndex = 0;
            // 
            // formContextMenuStrip
            // 
            this.formContextMenuStrip.Name = "formContextMenuStrip";
            this.formContextMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // TemplateEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 445);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TemplateEditorForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.TabPageContextMenuStrip = this.formContextMenuStrip;
            this.Text = "TemplateEditorForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TemplateEditorForm_FormClosing);
            this.Load += new System.EventHandler(this.TemplateEditorForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageTemplateSource.ResumeLayout(false);
            this.tabPageHelp.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		//private ICSharpCode.TextEditor.TextEditorControl txtEdit;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPageTemplateSource;
		private System.Windows.Forms.TabPage tabPageHelp;
		private System.Windows.Forms.RichTextBox rtfHelp;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TextBox txtErrors;
		private System.Windows.Forms.ContextMenuStrip formContextMenuStrip;
        private Alsing.Windows.Forms.SyntaxBoxControl txtEdit;
        private Alsing.SourceCode.SyntaxDocument syntaxDocument1;
	}
}
