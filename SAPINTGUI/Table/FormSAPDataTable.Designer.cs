namespace SAPINT.Gui.Table
{
    partial class FormSAPDataTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSAPDataTable));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.SaveTabletoolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ExportToExceltoolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveTabletoolStripButton1,
            this.ExportToExceltoolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(284, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // SaveTabletoolStripButton1
            // 
            this.SaveTabletoolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveTabletoolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("SaveTabletoolStripButton1.Image")));
            this.SaveTabletoolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveTabletoolStripButton1.Name = "SaveTabletoolStripButton1";
            this.SaveTabletoolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.SaveTabletoolStripButton1.Text = "toolStripButton1";
            this.SaveTabletoolStripButton1.Click += new System.EventHandler(this.SaveTabletoolStripButton1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(284, 237);
            this.dataGridView1.TabIndex = 1;
            // 
            // ExportToExceltoolStripButton1
            // 
            this.ExportToExceltoolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ExportToExceltoolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("ExportToExceltoolStripButton1.Image")));
            this.ExportToExceltoolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExportToExceltoolStripButton1.Name = "ExportToExceltoolStripButton1";
            this.ExportToExceltoolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.ExportToExceltoolStripButton1.Text = "导出到Excel";
            this.ExportToExceltoolStripButton1.Click += new System.EventHandler(this.ExportToExceltoolStripButton1_Click);
            // 
            // FormSAPDataTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormSAPDataTable";
            this.Text = "FormSAPDataTable";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton SaveTabletoolStripButton1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripButton ExportToExceltoolStripButton1;
    }
}