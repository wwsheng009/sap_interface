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
            this.syntaxRichTextBox1 = new SyntaxHighlighter.SyntaxRichTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnUpdateDb = new System.Windows.Forms.Button();
            this.sAPConfigFromFileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAPConfigFromFileBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExcute
            // 
            this.btnExcute.Location = new System.Drawing.Point(63, 12);
            this.btnExcute.Name = "btnExcute";
            this.btnExcute.Size = new System.Drawing.Size(142, 45);
            this.btnExcute.TabIndex = 0;
            this.btnExcute.Text = "执行";
            this.btnExcute.UseVisualStyleBackColor = true;
            this.btnExcute.Click += new System.EventHandler(this.btnExcute_Click);
            // 
            // syntaxRichTextBox1
            // 
            this.syntaxRichTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.syntaxRichTextBox1.Location = new System.Drawing.Point(63, 63);
            this.syntaxRichTextBox1.Name = "syntaxRichTextBox1";
            this.syntaxRichTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.syntaxRichTextBox1.Size = new System.Drawing.Size(771, 134);
            this.syntaxRichTextBox1.TabIndex = 1;
            this.syntaxRichTextBox1.Text = "";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(63, 203);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(771, 400);
            this.dataGridView1.TabIndex = 2;
            // 
            // btnUpdateDb
            // 
            this.btnUpdateDb.Location = new System.Drawing.Point(223, 12);
            this.btnUpdateDb.Name = "btnUpdateDb";
            this.btnUpdateDb.Size = new System.Drawing.Size(120, 45);
            this.btnUpdateDb.TabIndex = 3;
            this.btnUpdateDb.Text = "更新修改的值";
            this.btnUpdateDb.UseVisualStyleBackColor = true;
            this.btnUpdateDb.Click += new System.EventHandler(this.btnUpdateDb_Click);
            // 
            // sAPConfigFromFileBindingSource
            // 
            this.sAPConfigFromFileBindingSource.DataSource = typeof(SAPINT.SapConfig.SAPConfigFromFile);
            // 
            // FormDataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 615);
            this.Controls.Add(this.btnUpdateDb);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.syntaxRichTextBox1);
            this.Controls.Add(this.btnExcute);
            this.Name = "FormDataBase";
            this.Text = "FormDataBase";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAPConfigFromFileBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExcute;
        private SyntaxHighlighter.SyntaxRichTextBox syntaxRichTextBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource sAPConfigFromFileBindingSource;
        private System.Windows.Forms.Button btnUpdateDb;
    }
}