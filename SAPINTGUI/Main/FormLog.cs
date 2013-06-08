using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAPINTGUI.Main
{
    public partial class FormLog : ToolWindow
    {
        private string _logText;
        public String LogText
        {
            get { return _logText; }
            set
            {
                this._logText = value;
                this.richTextBox1.AppendText(_logText);
            }
        }
        public FormLog()
        {
            InitializeComponent();
        }
        public void Clean()
        {
            this.richTextBox1.Clear();
        }
        public void AppendLogText(string s)
        {
            this.richTextBox1.AppendText(s);
        }
    }
}
