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
        private Codedb db = new Codedb();

        public Code code
        {
            set
            {
                _code = value;
                RefreshDisplay();
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
                _code = new Code();
                _code.Title = "新建文档*";
            }
            RefreshDisplay();
            this.txtTreeText.DoubleClick += txtTreeText_DoubleClick;
            DirectoryInfo directory = new DirectoryInfo("SyntaxFiles\\");
            FileInfo[] files = directory.GetFiles();
            foreach (var item in files)
            {
                var newName = item.Name.Replace(".syn", "");
                newName = newName.Replace(".Syn", "");
                this.cbxCategory.Items.Add(newName);
            }
            this.syntaxBoxControl1.Document.Change += Document_Change;
            this.syntaxBoxControl1.Document.ModifiedChanged += Document_ModifiedChanged;
        }

        void Document_ModifiedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void Document_Change(object sender, EventArgs e)
        {
            this.SatustoolStripLabel1.Text = "未保存*";
            this.Text = this.Text + "*";
            //throw new NotImplementedException();
        }

        private void RefreshDisplay()
        {
            try
            {
                if (_code == null)
                {
                    this.toolStripStatusLabel4.Text = string.Empty;
                    this.toolStripStatusLabel5.Text = string.Empty;
                    this.toolStripStatusLabel6.Text = string.Empty;
                    this.txtDesc.Text = string.Empty;
                    this.syntaxBoxControl1.Document.Text = string.Empty;
                    this.txtTitle.Text = string.Empty;
                    this.cbxCategory.Text = string.Empty;
                }
                else
                {
                    this.toolStripStatusLabel6.Text = _code.Version;
                    this.toolStripStatusLabel5.Text = _code.LastChangeTime.ToShortDateString() + " " + _code.LastChangeTime.ToShortTimeString();
                    this.toolStripStatusLabel4.Text = _code.CreateTime.ToShortDateString() + " " + _code.CreateTime.ToShortTimeString();
                    this.txtDesc.Text = _code.Desc;
                    this.syntaxBoxControl1.Document.Text = _code.Content;
                    this.txtTitle.Text = _code.Title;
                    if (!string.IsNullOrEmpty(_code.TreeId))
                    {
                        var codeFolder = db.GetFolder(_code.TreeId);
                        this.txtTreeText.Text = codeFolder.Text;
                        this.TreeId = codeFolder.Id;
                    }
                    if (String.IsNullOrEmpty(_code.Categery))
                    {
                        _code.Categery = "abap";
                        
                    }
                    this.cbxCategory.Text = _code.Categery;
                    loadSynFile(_code.Categery);
                    this.Text = _code.Title;
                    this.SatustoolStripLabel1.Text = "保存成功";
                    
                    
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
            this.TreeId = form.SelectedFolder.Id;
            this.txtTreeText.Text = form.SelectedFolder.Text;
        }

        private void SaveCode()
        {
            try
            {
                _code.Title = this.txtTitle.Text;
                _code.Content = this.syntaxBoxControl1.Document.Text;
                if (String.IsNullOrEmpty(_code.TreeId))
                {
                    if (!String.IsNullOrEmpty(this.TreeId))
                    {

                        _code.TreeId = this.TreeId;
                    }
                    else
                    {
                        var newFolder = new CodeFolder();
                        newFolder.Text = this.txtTreeText.Text;
                        newFolder = db.SaveTree(newFolder);
                        _code.TreeId = newFolder.Id;
                    }
                }

                _code.Categery = this.cbxCategory.Text;
                _code.Desc = this.txtDesc.Text;

                if (db.SaveCode(_code) != null)
                {
                    this.toolStripStatusLabel7.Text = "保存成功!";
                    this.SatustoolStripLabel1.Text = this.toolStripStatusLabel7.Text;
                    RefreshDisplay();
                }
                else
                {
                    MessageBox.Show("保存失败");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void NewCode()
        {
            var _code_new = new Code();
            _code_new.Version = "1.0.0";
            _code_new.Title = "NewCode*";
            var codeEditor = new FormCodeEditor();
            if (this.DockPanel != null)
            {
                codeEditor.Show(this.DockPanel);
            }
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
        private void DeleteCode()
        {
            if (this.code != null)
            {
                if (db.DeleteCode(code))
                {
                    code = null;
                    SatustoolStripLabel1.Text = "删除成功";
                    //MessageBox.Show("删除成功");
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


        private void DeletetoolStripButton3_Click(object sender, EventArgs e)
        {
            DeleteCode();
        }

        private void syntaxBoxControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                SaveCode();
            }
            else if (e.Control && e.KeyCode == Keys.N)
            {
                NewCode();
            }
        }

        private void CopytoolStripButton2_Click(object sender, EventArgs e)
        {
            if (_code != null)
            {
                var _code_copy = new Code();
                _code_copy = _code;
                _code_copy.Id = "";
                //_code_copy.TreeId = _code.TreeId;

                var codeEditor = new FormCodeEditor();
                codeEditor.code = _code_copy;
                if (this.DockPanel != null)
                {
                    codeEditor.Show(this.DockPanel);
                }
            }


        }

        private void SaveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveCode();
        }

        private void NewToolStripButton_Click(object sender, EventArgs e)
        {
            NewCode();
        }
    }
}
