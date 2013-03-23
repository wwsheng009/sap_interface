namespace SAPINTGUI
{
    partial class FormFunctionMetaJson
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFunctionMetaJson));
            this.button2 = new System.Windows.Forms.Button();
            this.cbx_SystemList = new SAPINT.Controls.CboxSystemList();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.txtFunctionName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFuncMeta = new System.Windows.Forms.TextBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(475, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 24;
            this.button2.Text = "调用函数";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbx_SystemList
            // 
            this.cbx_SystemList.DataSource = ((object)(resources.GetObject("cbx_SystemList.DataSource")));
            this.cbx_SystemList.Location = new System.Drawing.Point(61, 12);
            this.cbx_SystemList.Name = "cbx_SystemList";
            this.cbx_SystemList.Size = new System.Drawing.Size(162, 20);
            this.cbx_SystemList.TabIndex = 23;
            // 
            // btnDisplay
            // 
            this.btnDisplay.Location = new System.Drawing.Point(394, 38);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(75, 23);
            this.btnDisplay.TabIndex = 22;
            this.btnDisplay.Text = "显示";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // txtFunctionName
            // 
            this.txtFunctionName.Location = new System.Drawing.Point(61, 38);
            this.txtFunctionName.Name = "txtFunctionName";
            this.txtFunctionName.Size = new System.Drawing.Size(327, 21);
            this.txtFunctionName.TabIndex = 21;
            this.txtFunctionName.Text = "Z_RFC_STORE2_01";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "函数名:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "SAP系统";
            // 
            // txtFuncMeta
            // 
            this.txtFuncMeta.Location = new System.Drawing.Point(10, 79);
            this.txtFuncMeta.Multiline = true;
            this.txtFuncMeta.Name = "txtFuncMeta";
            this.txtFuncMeta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFuncMeta.Size = new System.Drawing.Size(406, 174);
            this.txtFuncMeta.TabIndex = 25;
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(12, 273);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInput.Size = new System.Drawing.Size(406, 174);
            this.txtInput.TabIndex = 25;
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(432, 79);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(406, 368);
            this.txtOutput.TabIndex = 25;
            // 
            // FormFunctionMetaJson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 483);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.txtFuncMeta);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cbx_SystemList);
            this.Controls.Add(this.btnDisplay);
            this.Controls.Add(this.txtFunctionName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormFunctionMetaJson";
            this.Text = "FormFunctionMetaJson";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Button button2;
        private SAPINT.Controls.CboxSystemList cbx_SystemList;
        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.TextBox txtFunctionName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFuncMeta;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtOutput;
    }
}