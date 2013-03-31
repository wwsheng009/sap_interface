namespace SAPINTGUI.DataBase
{
    partial class FormDataBase
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
            this.btnExcute = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnUpdateDb = new System.Windows.Forms.Button();
            this.syntaxBoxControl1 = new Alsing.Windows.Forms.SyntaxBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExcute
            // 
            this.btnExcute.Location = new System.Drawing.Point(13, 12);
            this.btnExcute.Name = "btnExcute";
            this.btnExcute.Size = new System.Drawing.Size(142, 45);
            this.btnExcute.TabIndex = 0;
            this.btnExcute.Text = "执行";
            this.btnExcute.UseVisualStyleBackColor = true;
            this.btnExcute.Click += new System.EventHandler(this.btnExcute_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 203);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(822, 400);
            this.dataGridView1.TabIndex = 2;
            // 
            // btnUpdateDb
            // 
            this.btnUpdateDb.Location = new System.Drawing.Point(175, 12);
            this.btnUpdateDb.Name = "btnUpdateDb";
            this.btnUpdateDb.Size = new System.Drawing.Size(120, 45);
            this.btnUpdateDb.TabIndex = 3;
            this.btnUpdateDb.Text = "更新修改的值";
            this.btnUpdateDb.UseVisualStyleBackColor = true;
            this.btnUpdateDb.Click += new System.EventHandler(this.btnUpdateDb_Click);
            // 
            // syntaxBoxControl1
            // 
            this.syntaxBoxControl1.ActiveView = Alsing.Windows.Forms.ActiveView.BottomRight;
            this.syntaxBoxControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.syntaxBoxControl1.AutoListPosition = null;
            this.syntaxBoxControl1.AutoListSelectedText = "";
            this.syntaxBoxControl1.AutoListVisible = false;
            this.syntaxBoxControl1.BackColor = System.Drawing.Color.White;
            this.syntaxBoxControl1.BorderStyle = Alsing.Windows.Forms.BorderStyle.None;
            this.syntaxBoxControl1.CopyAsRTF = false;
            this.syntaxBoxControl1.FontName = "Courier new";
            this.syntaxBoxControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.syntaxBoxControl1.InfoTipCount = 1;
            this.syntaxBoxControl1.InfoTipPosition = null;
            this.syntaxBoxControl1.InfoTipSelectedIndex = 0;
            this.syntaxBoxControl1.InfoTipVisible = false;
            this.syntaxBoxControl1.Location = new System.Drawing.Point(13, 66);
            this.syntaxBoxControl1.LockCursorUpdate = false;
            this.syntaxBoxControl1.Name = "syntaxBoxControl1";
            this.syntaxBoxControl1.ShowScopeIndicator = false;
            this.syntaxBoxControl1.Size = new System.Drawing.Size(821, 131);
            this.syntaxBoxControl1.SmoothScroll = false;
            this.syntaxBoxControl1.SplitviewH = -4;
            this.syntaxBoxControl1.SplitviewV = -4;
            this.syntaxBoxControl1.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.syntaxBoxControl1.TabIndex = 4;
            this.syntaxBoxControl1.Text = "syntaxBoxControl1";
            this.syntaxBoxControl1.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
            // 
            // FormDataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 615);
            this.Controls.Add(this.syntaxBoxControl1);
            this.Controls.Add(this.btnUpdateDb);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnExcute);
            this.Name = "FormDataBase";
            this.Text = "FormDataBase";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExcute;

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnUpdateDb;
        private Alsing.Windows.Forms.SyntaxBoxControl syntaxBoxControl1;
    }
}