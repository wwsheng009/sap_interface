using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAPINTDB;
using SAPINTDB.CodeManager;

namespace SAPINTGUI.CodeManager
{
    public partial class FormCodeEditor : DockWindow
    {
        private Code _code = null;
        Codedb db = new Codedb();

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
        public FormCodeEditor()
        {
            InitializeComponent();
            if (_code == null)
            {
                code = new Code();
            }
            this.txtTreeText.DoubleClick += txtTreeText_DoubleClick;
            DirectoryInfo directory = new DirectoryInfo("SyntaxFiles\\");
            FileInfo[] files = directory.GetFiles();
            foreach (var item in files)
            {
                var newName = item.Name.Replace(".syn", "");
                newName = newName.Replace(".Syn", "");
                this.cbxCategory.Items.Add(newName);
            }
        }

        private void freshDisplay()
        {
            try
            {
                if (_code == null)
                {
                    this.txtVersion.Text = string.Empty;
                    this.txtDesc.Text = string.Empty;
                    this.syntaxBoxControl1.Document.Text = string.Empty;
                    this.txtTitle.Text = string.Empty;
                    this.cbxCategory.Text = string.Empty;
                    this.txtLastChangeTime.Text = string.Empty;
                    this.txtCreateTime.Text = string.Empty;

                }
                else
                {
                    this.txtVersion.Text = _code.Version;
                    this.txtDesc.Text = _code.Desc;
                    this.syntaxBoxControl1.Document.Text = _code.Content;
                    this.txtTitle.Text = _code.Title;
                    this.cbxCategory.Text = _code.Categery;
                    this.txtLastChangeTime.Text = _code.LastChangeTime.ToShortDateString() + " " + _code.LastChangeTime.ToShortTimeString();
                    this.txtCreateTime.Text = _code.CreateTime.ToShortDateString() + " " + _code.CreateTime.ToShortTimeString();
                    loadSynFile(this.cbxCategory.Text);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }



        void txtTreeText_DoubleClick(object sender, EventArgs e)
        {
            FormCodeManager form = new FormCodeManager();
            form.ShowDialog();
            this.TreeId = form.SelectedTree.Id;
            this.txtTreeText.Text = form.SelectedTree.Text;

            // throw new NotImplementedException();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _code.Title = this.txtTitle.Text;
                _code.Content = this.syntaxBoxControl1.Document.Text;
                if (!String.IsNullOrEmpty(TreeId))
                {
                    _code.TreeId = this.TreeId;
                }
                else
                {
                    var newTree = new CodeTree();
                    newTree.Text = this.txtTreeText.Text;
                    newTree = db.SaveTree(newTree);
                    _code.TreeId = newTree.Id;
                }

                _code.Categery = this.cbxCategory.Text;
                _code.Desc = this.txtDesc.Text;

                if (db.SaveCode(_code) != null)
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
            _code.Version = "1.0.0";
            freshDisplay();

        }

        public string TreeId { get; set; }
        private string _treeText;
        public string TreeText
        {
            get { return _treeText; }
            set
            {
                _treeText = value;
                this.txtTreeText.Text = _treeText;
            }
        }

        private void btnDeleteCode_Click(object sender, EventArgs e)
        {
            if (this.code != null)
            {
                if (db.DeleteCode(code))
                {
                    code = null;
                    MessageBox.Show("删除成功");
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
            else
            {
                MessageBox.Show("无法删除");
            }
        }
        private void loadSynFile(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                return;
            }
            try
            {
                Alsing.SourceCode.SyntaxDefinition sl;
                var fileName = string.Empty;
                fileName = "SyntaxFiles\\" + text + ".syn";
                sl = new Alsing.SourceCode.SyntaxDefinitionLoader().Load(fileName);
                this.syntaxBoxControl1.Document.Parser.Init(sl);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            var text = cbxCategory.Text;
            text = text.ToUpper().Trim();
            loadSynFile(text);


        }
    }
}
