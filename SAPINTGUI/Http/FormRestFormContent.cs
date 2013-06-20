using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAPINT.Gui.Http
{
    public partial class FormRestFormContent : Form
    {
        public FormRestFormContent()
        {
            InitializeComponent();
        }

        private string _content = string.Empty;

        public String Content
        {

            set
            {
                this._content = value;
                this.txtContent.Text = _content;
            }
            get
            {
                this._content = txtContent.Text;
                return this._content;
            }
        }
    }
}
