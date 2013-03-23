using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAPINTCODE
{
    public partial class FormControlPanel : Form
    {
        public FormControlPanel()
        {
            InitializeComponent();
        }

        private void btnGenerateClass_Click(object sender, EventArgs e)
        {
            FormGenerateTableClass formGenerateTableClass = new FormGenerateTableClass();
            formGenerateTableClass.Show();
        }

        private void btnAbapCode_Click(object sender, EventArgs e)
        {
            FormAbapCode formAbapCode = new FormAbapCode();
            formAbapCode.Show();
        }
    }
}
