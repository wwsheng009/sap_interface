using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using SAPINTDB;
using SAPINTDB.CodeManager;

namespace SAPINTGUI.AbapCode
{
    public partial class FormImportFile : Form
    {
        DataTable dt = null;
        DataTable dtnew = new DataTable();
        int index = 0;
        int headerSize = 500;
        Dictionary<int, Code> pos = new Dictionary<int, Code>();
        //Type type = null;
        //PropertyInfo[] properties = null;

        // private string path = null;
        public string fileName { get; set; }


        public FormImportFile()
        {
            InitializeComponent();

            dt = new DataTable("FileList");
            dt.Columns.AddRange(new DataColumn[]{
               new DataColumn("Index",typeof(int)),
               new DataColumn("Select",typeof(Boolean)),
               new DataColumn("Name",typeof(String)),
               new DataColumn("Header",typeof(String)),
               
               new DataColumn("Length",typeof(String)),
               new DataColumn("Extension",typeof(String)),
               new DataColumn("CodeId",typeof(String)),
               new DataColumn("DirectoryName",typeof(String)),
               new DataColumn("FullName",typeof(String)),
               
               
            });
            dt.Columns["Index"].AutoIncrement = true;
            dt.Columns["Select"].DefaultValue = false;

            this.dataGridView1.DataSource = dt;
            this.dataGridView1.Columns["Index"].Width = 50;
            this.dataGridView1.Columns["Select"].Width = 50;
            this.dataGridView1.Columns["Length"].Width = 80;
            this.dataGridView1.Columns["Extension"].Width = 50;
            this.dataGridView1.Columns["Name"].Width = 300;
            //this.dataGridView1.Columns["Select"].ReadOnly = false;
            //type = typeof(FileInfo);
            //properties = type.GetProperties();

            //dtnew.Columns.Add(new DataColumn("Select", typeof(bool)));

            //foreach (var properinfo in properties)
            //{
            //    dtnew.Columns.Add(properinfo.Name, typeof(String));
            //}

            this.listExtension.Items.AddRange(new object[] { ".cs", ".abap", ".sql" });
            this.dataGridView1.CellClick += dataGridView1_CellClick;
            this.dataGridView1.CurrentCellChanged += dataGridView1_CurrentCellChanged;

        }

        void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {

            var cell = dataGridView1.CurrentCell;
            if (cell != null && cell.Value != null)
            {
                this.syntaxBoxControl1.Document.Text = cell.Value.ToString();
            }
        }

        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }
            var cell = dataGridView1[e.ColumnIndex, e.RowIndex];
            if (cell != null && cell.Value != null)
            {
                this.syntaxBoxControl1.Document.Text = cell.Value.ToString();

                if (!string.IsNullOrWhiteSpace(cell.Value.ToString()))
                {


                    if (dt.Columns[e.ColumnIndex].ColumnName == "CodeId")
                    {
                        try
                        {
                            Code code = new Codedb().getCodebyId(cell.Value.ToString());
                            if (code != null)
                            {
                                FormCodeEditor frm = new FormCodeEditor();
                                frm.code = code;
                                frm.Show();
                            }
                        }
                        catch (Exception ee)
                        {

                            MessageBox.Show(ee.Message);
                        }
                    }
                }
            }
        }

        private void loadFileList(String folderName)
        {
            if (String.IsNullOrEmpty(folderName))
            {
                return;
            }
            DirectoryInfo folderFullName = new DirectoryInfo(folderName);
            if (!folderFullName.Exists)
            {
                throw new DirectoryNotFoundException("文件夹不存在: " + folderFullName);

            }
            
            dt.Clear();
            //dt.AcceptChanges();
            loadFileList(folderFullName);
            index = 0;

            //  this.dataGridView1.AutoResizeColumns();
            MessageBox.Show("读取完成");
            // this.dataGridView1.DataSource = dt;
        }

        private void loadFileList(DirectoryInfo folderFullName)
        {

            FileSystemInfo[] subFiles = folderFullName.GetFiles();
            foreach (FileInfo item in subFiles)
            {
                loadFile(item);

            }
            if (!this.chxSubFolder.Checked)
            {
                return;
            }
            var subDirectories = folderFullName.GetDirectories();

            if (subDirectories.Count() > 0)
            {
                foreach (var item in subDirectories)
                {
                    loadFileList(item);
                }
            }
        }
        private void loadFile(FileInfo file)
        {
            if (!file.Exists)
            {
                return;
            }
            if (!IsTextFile(file.FullName))
            {
                return;
            }
            if (!this.listExtension.Items.Contains(file.Extension))
            {
                this.listExtension.Items.Add(file.Extension);
            }

            if (this.chxFilter.Checked)
            {
                if (!this.listExtension.SelectedItems.Contains(file.Extension))
                {
                    return;
                }
            }
            if (chkReadHeader.Checked == true)
            {
                headerSize = int.Parse(this.numericSize.Value.ToString());
            }
            //PropertyInfo[] properties = item.GetType().GetProperties();
            DataRow row = dt.NewRow();
            row["Index"] = index;
            index += 1;
            row["Name"] = file.Name;
            row["FullName"] = file.FullName;
            row["Extension"] = file.Extension;
            row["DirectoryName"] = file.DirectoryName;
            row["Length"] = Util.FileUtil.FormatFileSize(file.Length);
            if (this.chkReadHeader.Checked == true)
            {
                StreamReader sr = new StreamReader(file.FullName);
                char[] buffer = new char[headerSize];
                sr.Read(buffer, 0, headerSize);
                sr.Close();
                var s = new string(buffer);

                row["Header"] = s;
            }



            dt.Rows.Add(row);
            //for (int i = 0; i < properties.Length; i++)
            //{
            //    object o = properties[i].GetValue(item, null);
            //    row[properties[i].Name] = o.ToString();
            //}
            //dtnew.Rows.Add(row);

        }
        public string path { get; set; }


        /// <summary>
        /// Checks the file is textfile or not.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public static bool CheckIsTextFile(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            bool isTextFile = true;
            try
            {
                int i = 0;
                int length = (int)fs.Length;
                byte data;
                while (i < length && isTextFile)
                {
                    data = (byte)fs.ReadByte();
                    isTextFile = (data != 0);
                    i++;
                }
                return isTextFile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

        public static bool IsTextFile(string fileName)
        {
            //要比对的字节,越大,正确度越高,但32个只够了.
            char[] buf = new char[32];
            //实际读到的字符数
            int readint = 0;

            try
            {
                StreamReader reader = new StreamReader(fileName);
                //最多读 buf.Length 个字符
                readint = reader.ReadBlock(buf, 0, buf.Length);
                reader.Close();
                //比对是否存在 '\0' 这个字符
                for (int i = 0; i < readint; i++)
                {
                    if (buf[i] == '\0')
                    {
                        //存在：这个就不是文本文件
                        return false;
                    }
                }
                //没找到，那么很大概率是文本文件
                return true;

            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }


        private void btnListFile_Click(object sender, EventArgs e)
        {
            try
            {
                //if (String.IsNullOrWhiteSpace(path))
                //{
                path = this.txtFolder.Text;
                //}
                if (String.IsNullOrWhiteSpace(path))
                {

                    MessageBox.Show("请选择文件");
                    return;
                }

                this.loadFileList(path);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnChooseFolder_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.ShowDialog();
                this.txtFolder.Text = dialog.SelectedPath;
                path = dialog.SelectedPath;
                this.loadFileList(path);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (ReadFile())
                {
                    MessageBox.Show("导入成功");
                }
                else
                {
                    MessageBox.Show("导入失败");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private bool ReadFile()
        {
            List<Code> list = new List<Code>();

            foreach (DataRow item in dt.Rows)
            {
                if (String.IsNullOrWhiteSpace(item["Select"].ToString()))
                {
                    continue;
                }
                var isSelect = (bool)item["Select"];
                if (isSelect)
                {
                    fileName = item["FullName"].ToString();
                    FileInfo file = new FileInfo(fileName);
                    if (!file.Exists)
                    {
                        continue;
                    }
                    StreamReader sr = new StreamReader(fileName);
                    String s = sr.ReadToEnd();
                    sr.Close();
                    if (String.IsNullOrEmpty(s))
                    {
                        continue;
                    }

                    SAPINTDB.CodeManager.Code code = new Code();
                    code.Content = s;
                    code.Title = file.Name.Replace(file.Extension, "");
                    code.Desc = fileName;
                    list.Add(code);
                    index = int.Parse(item["Index"].ToString());
                    pos.Add(index, code);


                }

            }

            Codedb db = new Codedb();
            if (db.SaveCodeList(list))
            {
                foreach (var item in pos)
                {
                    dt.Rows[item.Key]["CodeId"] = item.Value.Id;
                }
                return true;
            }
            else
            {
                return false;
            }
        }



        private void btnSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected)
                {
                    row.Cells["Select"].Value = true;
                }
            }
        }

        private void btnCancelSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected)
                {
                    row.Cells["Select"].Value = false;
                }

            }
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.CheckFileExists = true;
            dialog.CheckPathExists = true;
            dialog.ReadOnlyChecked = true;
            dialog.AddExtension = true;
            dialog.ShowDialog();


            var files = dialog.FileNames;
            var file = dialog.FileName;
            FileInfo fileinfo;
            foreach (var item in files)
            {
                if (String.IsNullOrEmpty(item))
                {
                    continue;
                }
                fileinfo = new FileInfo(item);
                loadFile(fileinfo);
            }
            if (String.IsNullOrEmpty(file))
            {
                return;
            }
            //this.dataGridView1.AutoResizeColumns();
            //fileinfo = new FileInfo(file);
            //loadFile(fileinfo);
        }

        private void btnAddExtension_Click(object sender, EventArgs e)
        {
            if (!this.listExtension.Items.Contains(this.txtExtension.Text))
            {
                this.listExtension.Items.Add(this.txtExtension.Text);
            }

        }

        // public string isSelect { get; set; }
    }
}