using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAPINT.Utils;
using SAPINTCODE.Properties;
using System.IO;
using NVelocity;
using NVelocity.App;
using System.Reflection;
using System.Xml;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;

namespace SAPINTCODE
{
    public partial class Form1 : Form
    {

        string filename = "";
        OpenFileDialog openFileDialog1;
        SaveFileDialog saveFileDialog1;

        public Form1()
        {
            InitializeComponent();
            SAPINT.SAPConfigList.InitSystemList();
            LoadHighlighting();
            openFileDialog1 = new OpenFileDialog();

           
        }

        private void tsMChooseTemplate_Click(object sender, EventArgs e)
        {
             try
                {
            

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                    filename = openFileDialog1.FileName;
                    //codeEditorControl1.textEditor1.Load(filename);
                    textTemplate.LoadFile(filename);
            }

            }
             catch (Exception ex)
             {
                 MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
             }

        }

      
        private void tspSaveTemplate_Click(object sender, EventArgs e)
        {
            //string localFilePath, fileNameExt, newFileName, FilePath;  
             saveFileDialog1 = new SaveFileDialog();

            //设置文件类型  
            saveFileDialog1.Filter = " txt files(*.txt)|*.txt|All files(*.*)|*.*";

            //设置默认文件类型显示顺序  
            saveFileDialog1.FilterIndex = 2;

            //保存对话框是否记忆上次打开的目录  
            saveFileDialog1.RestoreDirectory = true;

            //点了保存按钮进入  
            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                //获得文件路径  
                //localFilePath = saveFileDialog1.FileName.ToString();  

                //获取文件名，不带路径  
                //fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1);  

                //获取文件路径，不带文件名  
                //FilePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\"));  

                //给文件名前加上时间  
                //newFileName = DateTime.Now.ToString("yyyyMMdd") + fileNameExt;  

                //在文件名里加字符  
                //saveFileDialog1.FileName.Insert(1,"dameng");  
               // System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();//输出文件  
                this.filename = saveFileDialog1.FileName;
                this.textTemplate.SaveFile(filename);
                MessageBox.Show("保存成功");
                //fs输出带文字或图片的文件，就看需求了  
            }  
        }
        private string ExcuteAbapCode(string Code)
        {
            SAPINT.Utils.ABAPCode abap = new SAPINT.Utils.ABAPCode(this.sapTableField1.SystemName.Trim().ToUpper());
            // abap.AddCodeLine(this.txtAbapCode.Text);
            abap.ResetCode();
            TextBox box = new TextBox();
            box.Text = Code;

            foreach (string line in box.Lines)
            {
                abap.AddCodeLine(line);
            }
            box.Text = "";
            try
            {
                if (abap.Execute())
                {
                    for (int i = 0; i < abap.ResultLineCount; i++)
                    {
                        box.Text += abap.GetResultLine(i) + "\r\n";
                    }
                }
                else
                {
                    box.Text = "ABAP Error: " + abap.LastABAPSyntaxError;
                }
               
                
            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.Message);
            }
            return box.Text;
        }
        private void tspRunAbapCode_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.sapTableField1.SystemName))
            {
                textAbapResult.Text = "请选择系统";
                return;
            }

            textAbapResult.Text = "";
            textAbapResult.Text = ExcuteAbapCode(this.textResultCode.Text);
            
        }

        private void tspProcessTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                VelocityEngine ve = new VelocityEngine();
                ve.Init();
                VelocityContext ct = new VelocityContext();

                AbapCode code = new AbapCode();

                ct.Put("test", this.sapTableField1.TableList);
                System.IO.StringWriter vltWriter = new System.IO.StringWriter();
                ve.Evaluate(ct, vltWriter, null, this.textTemplate.Text);
                textResultCode.Text = vltWriter.GetStringBuilder().ToString();
            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.Message);
            }
        }

        bool  _highlightingProviderLoaded = false;

        private void LoadHighlighting()
        {
            try
            {
                if (!_highlightingProviderLoaded)
                {
                    AppSyntaxModeProvider app = new AppSyntaxModeProvider();

                    // Attach to the text editor.
                    HighlightingManager.Manager.AddSyntaxModeFileProvider(
                        new AppSyntaxModeProvider());
                    _highlightingProviderLoaded = true;
                }
                textResultCode.SetHighlighting("ABAP");
            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.Message);
            }
        }
        private void tspLoadSystax_Click(object sender, EventArgs e)
        {

            // Add the keywords to the list.
             textTemplate.Settings.Keywords.Add("$");
            // textTemplate.Settings.Keywords.Add("if");
            // textTemplate.Settings.Keywords.Add("then");
            //  textTemplate.Settings.Keywords.Add("else");
            //  textTemplate.Settings.Keywords.Add("elseif");
            //  textTemplate.Settings.Keywords.Add("end");

            // Set the comment identifier. For Lua this is two minus-signs after each other (--). 
            // For C++ we would set this property to "//".
            textTemplate.Settings.Comment = "#";

            // Set the colors that will be used.
            textTemplate.Settings.KeywordColor = Color.Blue;
            textTemplate.Settings.CommentColor = Color.Green;
            textTemplate.Settings.StringColor = Color.Gray;
            textTemplate.Settings.IntegerColor = Color.Red;

            // Let's not process strings and integers.
            textTemplate.Settings.EnableStrings = true;
            textTemplate.Settings.EnableIntegers = false;

            // Let's make the settings we just set valid by compiling
            // the keywords to a regular expression.
            textTemplate.CompileKeywords();


            textTemplate.ProcessAllLines();
        }

        private void tspGenerateCode_Click(object sender, EventArgs e)
        {
            AbapCode code = new AbapCode();
            code.Tables = this.sapTableField1.TableList;
            this.textResultCode.Text = code.Excute();
        }

        private void tspNewTemplate_Click(object sender, EventArgs e)
        {
            this.filename = "";
            this.textTemplate.Text = "";
        }


    }
    
}
