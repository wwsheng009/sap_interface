using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAPINTGUI.CodeManager
{
    public partial class FormAbapDoc : DockWindow
    {
        public FormAbapDoc()
        {
            InitializeComponent();
            prettyCode();
        }
        public void OpenFile(String fileName)
        {
            try
            {
                this.syntaxBoxControl1.Open(fileName);
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }
        private void prettyCode()
        {
            Alsing.SourceCode.SyntaxDefinition sl = new Alsing.SourceCode.SyntaxDefinitionLoader().Load("SyntaxFiles\\abap.syn");

            //this.syntaxBoxControl1.Document.Parser.Init(sl);
            this.syntaxBoxControl1.Document.Parser.Init(sl);

        }
    }
}
