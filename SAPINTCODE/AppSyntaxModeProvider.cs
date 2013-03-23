using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.TextEditor.Document;
using ICSharpCode.TextEditor;
using ICSharpCode;
using ICSharpCode.TextEditor.Actions;
using System.Reflection;
using System.IO;
using System.Xml;
using SAPINTCODE.Properties;


namespace SAPINTCODE
{
    public class AppSyntaxModeProvider : ISyntaxModeFileProvider
    {
        List<SyntaxMode> syntaxModes = null;

        public ICollection<SyntaxMode> SyntaxModes
        {
            get
            {
                return syntaxModes;
            }
        }

        public AppSyntaxModeProvider()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            //foreach (string resourceName in assembly.GetManifestResourceNames()){}
            Stream syntaxModeStream = assembly.GetManifestResourceStream("AbapCodeGeneration.Resources.SyntaxModes.xml");
            if (syntaxModeStream != null)
            {
                syntaxModes = SyntaxMode.GetSyntaxModes(syntaxModeStream);
            }
            else
            {
                syntaxModes = new List<SyntaxMode>();
            }
        }

        public XmlTextReader GetSyntaxModeFile(SyntaxMode syntaxMode)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream("AbapCodeGeneration.Resources." + syntaxMode.FileName);
            return new XmlTextReader(stream);

        }

        public void UpdateSyntaxModeList()
        {
            // resources don't change during runtime
        }
    }
}
