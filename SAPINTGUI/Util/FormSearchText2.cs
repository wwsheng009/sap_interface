using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAPINTGUI;
using DgvFilterPopup;
namespace SAPINTGUI
{
    public partial class FormSearchText2 : Form
    {
        public String Result { get; set; }
        public String Title { set { this.Text = value; } }

        public DataTable dt
        {
            set
            {

                this.dataGridView1.DataSource = value;
                if (value != null)
                {
                    try
                    {
                        DgvFilterManager fm = new DgvFilterManager(this.dataGridView1);
                    }
                    catch (Exception e)
                    {

                        MessageBox.Show(e.Message);
                    }
                }
            }
        }

        public String LableText
        {
            //  get { return ""; }
            set { this.label1.Text = value; }
        }
        public FormSearchText2()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Result = textBox1.Text;
            this.dataGridView1.SearchDataGridView(this.Result);

        }
    }
}
