using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAPINTDB;
using SAPINTDB.CodeManager;

namespace SAPINTGUI.AbapCode
{
    public partial class FormCodeEditor : Form
    {
        private Code _code = null;

        public Code code
        {
            set
            {
                _code = value;
                freshDisplay();
            }
            get
            {
                return _code;

            }


        }
        private void freshDisplay()
        {
            try
            {
                this.txtVersion.Text = _code.Version;
                this.txtDesc.Text = _code.Desc;
                this.syntaxBoxControl1.Document.Text = _code.Content;
                this.txtTitle.Text = _code.Title;
                this.cbxCategory.Text = _code.Categery;
                this.txtLastChangeTime.Text = _code.LastChangeTime.ToShortDateString() + " " + _code.LastChangeTime.ToShortTimeString();
                this.txtCreateTime.Text = _code.CreateTime.ToShortDateString() + " " + _code.CreateTime.ToShortTimeString();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        public FormCodeEditor()
        {
            InitializeComponent();
            if (_code == null)
            {
                code = new Code();
            }
        }
        Codedb cocddb = new Codedb();

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _code.Title = this.txtTitle.Text;
                _code.Content = this.syntaxBoxControl1.Document.Text;
                _code.Categery = this.cbxCategory.Text;
                _code.Desc = this.txtDesc.Text;

                if (cocddb.SaveCode(_code)!=null)
                {
                    MessageBox.Show("SAVE OK");
                    freshDisplay();
                }
                else
                {
                    MessageBox.Show("SAVE FAILED");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            _code = new Code();
            freshDisplay();

        }
    }
}
