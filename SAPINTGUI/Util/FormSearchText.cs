using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAPINT.Gui
{
    public partial class FormSearchText : Form
    {
        public String Result { get; set; }
        public String Title { set { this.Text = value; } }
        public String LableText
        {
          //  get { return ""; }
            set { this.label1.Text = value; }
        }
        public FormSearchText()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Result = textBox1.Text;
            this.Close();
        }
    }
}
