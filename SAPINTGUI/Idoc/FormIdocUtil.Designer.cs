namespace SAPINTGUI.Idoc
{
    partial class FormIdocUtil
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
            this.txtIdocNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnReadIdocFromDb = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIdocNumber
            // 
            this.txtIdocNumber.Location = new System.Drawing.Point(70, 6);
            this.txtIdocNumber.Name = "txtIdocNumber";
            this.txtIdocNumber.Size = new System.Drawing.Size(226, 21);
            this.txtIdocNumber.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Idoc编号";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 46);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(747, 316);
            this.dataGridView1.TabIndex = 4;
            // 
            // btnReadIdocFromDb
            // 
            this.btnReadIdocFromDb.Location = new System.Drawing.Point(316, 4);
            this.btnReadIdocFromDb.Name = "btnReadIdocFromDb";
            this.btnReadIdocFromDb.Size = new System.Drawing.Size(143, 23);
            this.btnReadIdocFromDb.TabIndex = 5;
            this.btnReadIdocFromDb.Text = "从数据库中读取IDOC";
            this.btnReadIdocFromDb.UseVisualStyleBackColor = true;
            this.btnReadIdocFromDb.Click += new System.EventHandler(this.btnReadIdocFromDb_Click);
            // 
            // FormIdocUtil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 374);
            this.Controls.Add(this.btnReadIdocFromDb);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIdocNumber);
            this.Name = "FormIdocUtil";
            this.Text = "IdocUtil";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIdocNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnReadIdocFromDb;
    }
}
