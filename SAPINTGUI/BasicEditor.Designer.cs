namespace SAPINT.Gui
{
	partial class BasicEditor
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblEditorInfo = new System.Windows.Forms.Label();
            this.formContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtEdit = new Alsing.Windows.Forms.SyntaxBoxControl();
            this.syntaxDocument1 = new Alsing.SourceCode.SyntaxDocument(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblEditorInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 304);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(381, 21);
            this.panel1.TabIndex = 1;
            // 
            // lblEditorInfo
            // 
            this.lblEditorInfo.AutoSize = true;
            this.lblEditorInfo.Location = new System.Drawing.Point(3, 3);
            this.lblEditorInfo.Name = "lblEditorInfo";
            this.lblEditorInfo.Size = new System.Drawing.Size(62, 13);
            this.lblEditorInfo.TabIndex = 0;
            this.lblEditorInfo.Text = "lblEditorInfo";
            // 
            // formContextMenuStrip
            // 
            this.formContextMenuStrip.Name = "formContextMenuStrip";
            this.formContextMenuStrip.Size = new System.Drawing.Size(61, 4);
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
            this.txtEdit.Location = new System.Drawing.Point(0, 0);
            this.txtEdit.LockCursorUpdate = false;
            this.txtEdit.Name = "txtEdit";
            this.txtEdit.ShowScopeIndicator = false;
            this.txtEdit.Size = new System.Drawing.Size(381, 304);
            this.txtEdit.SmoothScroll = false;
            this.txtEdit.SplitviewH = -4;
            this.txtEdit.SplitviewV = -4;
            this.txtEdit.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.txtEdit.TabIndex = 2;
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
            // BasicEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 325);
            this.Controls.Add(this.txtEdit);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "BasicEditor";
            this.TabPageContextMenuStrip = this.formContextMenuStrip;
            this.Text = "DefaultEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BasicEditor_FormClosing);
            this.Load += new System.EventHandler(this.BasicEditor_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        //private ICSharpCode.TextEditor.TextEditorControl txtEdit;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblEditorInfo;
		private System.Windows.Forms.ContextMenuStrip formContextMenuStrip;
        private Alsing.Windows.Forms.SyntaxBoxControl txtEdit;
        private Alsing.SourceCode.SyntaxDocument syntaxDocument1;
	}
}