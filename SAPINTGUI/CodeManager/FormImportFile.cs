using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SAPINTDB;
using SAPINTDB.CodeManager;

namespace SAPINTGUI.CodeManager
{
    public delegate void deletegateSetProcessBar(int total, int value, String folder, String file);

    public partial class FormImportFile : DockWindow
    {
        DataTable dt = null;
        DataTable dtnew = new DataTable();
        int index = 0;
        int headerSize = 500;
        Dictionary<int, Code> pos = new Dictionary<int, Code>();
        public string fileName { get; set; }
        Codedb db = new Codedb();

        Thread thread = null;

        public FormImportFile()
        {
            InitializeComponent();

            dt = new DataTable("FileList");
            dt.Columns.AddRange(new DataColumn[]{
               new DataColumn("Index",typeof(int)),
               new DataColumn("Select",typeof(Boolean)),
               new DataColumn("Name",typeof(String)),
               new DataColumn("Header",typeof(String)),
               new DataColumn("Size",typeof(int)),
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
            this.btnStopImport.Enabled = false; 
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
                            Code code = new Codedb().GetCode(cell.Value.ToString());
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
            // listExtension.Items.Clear();
            dt.Clear();
            //dt.AcceptChanges();
            loadFileList(folderFullName);
            index = 0;

            //  this.dataGridView1.AutoResizeColumns();
            MessageBox.Show("读取完成");
            // this.dataGridView1.DataSource = dt;
        }

        Dictionary<String, CodeFolder> copyFolderList = new Dictionary<string, CodeFolder>();
        List<Code> copyCodeList = new List<Code>();

        /// <summary>
        /// 这个方法会被递归调用，所以要小心调用。
        /// </summary>
        /// <param name="folderFullName"></param>
        /// <param name="parentTree"></param>
        private void CopyAndImportLocalDirectory(DirectoryInfo folderFullName, CodeFolder parentTree = null)
        {

            var codeTree = new CodeFolder();
            codeTree.Id = Guid.NewGuid().ToString();
            codeTree.Text = folderFullName.Name;
            if (parentTree != null)
            {
                codeTree.ParentId = parentTree.Id;
            }
            copyFolderList.Add(folderFullName.FullName, codeTree);

            FileSystemInfo[] subFiles = folderFullName.GetFiles();


            var count = 0;
            foreach (FileInfo item in subFiles)
            {
                if (!item.Exists)
                {
                    continue;
                }

                if (!SAPINTGUI.Util.FileUtil.IsTextFile(item.FullName))
                {
                    continue;
                }
                StreamReader sr = new StreamReader(item.FullName, Encoding.Default);
                String s = sr.ReadToEnd();
                sr.Close();
                //if (s.Length > 3*1024 * 1024)
                //{
                //    continue;
                //}
                var code = new Code();
                code.Title = item.Name;
                code.Content = s;
                // code.Content = s.Replace("UTF-8", "GB2312");
                code.TreeId = codeTree.Id;
                copyCodeList.Add(code);
                count++;
                setProcessBar(subFiles.Count(), count, folderFullName.FullName, item.Name);

                //为了提高性能，每超过100个文档就保存一次。
                //因为每个文档内容都包含内容，如果文档的大小超过1M，那100
                //个文档会就100M的内存消耗。
                //如果没有超过100个文档在方法递归完成后再保存。
                if (copyCodeList.Count == 100)
                {
                    db.SaveCodeList(copyCodeList);
                    db.SaveFolderList(copyFolderList);
                    copyCodeList.Clear();
                    copyFolderList.Clear();
                }

            }

            var subDirectories = folderFullName.GetDirectories();

            if (subDirectories.Count() > 0)
            {

                foreach (var item in subDirectories)
                {
                    if (item.Exists)
                    {
                        CopyAndImportLocalDirectory(item, codeTree);

                    }


                }
            }

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
            if (!SAPINTGUI.Util.FileUtil.IsTextFile(file.FullName))
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
            row["Size"] = file.Length;
            row["Length"] = Util.FileUtil.FormatFileSize(file.Length);
            if (this.chkReadHeader.Checked == true)
            {
                StreamReader sr = new StreamReader(file.FullName, Encoding.Default);
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

                    MessageBox.Show("请选择文件夹");
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



                // this.loadFileList(path);
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
                ReadFile();
                ////ReadFiles();
                //if (ReadFile())
                //{
                //    MessageBox.Show("导入成功");
                //}
                //else
                //{
                //    MessageBox.Show("导入失败");
                //}
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        int selectedItems = 0;
        private bool ImportPreCheck()
        {
            selectedItems = 0;
            foreach (DataRow item in dt.Rows)
            {
                if (String.IsNullOrWhiteSpace(item["Select"].ToString()))
                {
                    continue;
                }
                var isSelect = (bool)item["Select"];
                if (isSelect)
                {
                    selectedItems++;
                }
            }
            if (selectedItems == 0)
            {
                MessageBox.Show("请选择需要需要导入的代码");
                return false;
            }
            this.progressBar1.Maximum = selectedItems;
            this.txtFilesCount.Text = selectedItems.ToString();
            this.progressBar1.Value = 0;

            if (String.IsNullOrEmpty(this.TreeId))
            {
                var codeTree = new CodeFolder();
                codeTree.Text = this.txtFolder.Text;
                if (String.IsNullOrEmpty(codeTree.Text))
                {
                    codeTree.Text = "Import File " + DateTime.Now;
                }

                codeTree = db.SaveTree(codeTree);
                this.TreeId = codeTree.Id;
            }
            return true;

        }
        private void ImportFile()
        {
            List<Code> list = new List<Code>();
            pos.Clear();

            var itemCount = 0;

            foreach (DataRow item in dt.Rows)
            {
                if (String.IsNullOrWhiteSpace(item["Select"].ToString()))
                {
                    continue;
                }
                var isSelect = (bool)item["Select"];
                if (isSelect)
                {
                    var tempFile = item["FullName"].ToString();
                    FileInfo file = new FileInfo(tempFile);
                    if (!file.Exists)
                    {
                        continue;
                    }
                    StreamReader sr = new StreamReader(tempFile, Encoding.Default);
                    String s = sr.ReadToEnd();
                    sr.Close();
                    if (String.IsNullOrEmpty(s))
                    {
                        continue;
                    }
                    Code code = new Code();
                    code.Content = s;
                    if (!String.IsNullOrEmpty(TreeId))
                    {
                        code.TreeId = TreeId;
                    }
                    code.Title = file.Name.Replace(file.Extension, "");
                    code.Desc = tempFile;
                    list.Add(code);
                    index = int.Parse(item["Index"].ToString());
                    pos.Add(index, code);

                    itemCount++;
                    setProcessBar(selectedItems, 0, item["DirectoryName"].ToString(), item["Name"].ToString());
                    if (itemCount == 100 && dt.Rows.Count >= 100)
                    {
                        db.SaveCodeList(list);
                        foreach (var positem in pos)
                        {
                            dt.Rows[positem.Key]["CodeId"] = positem.Value.Id;
                            dt.Rows[positem.Key]["Select"] = false;
                        }
                        pos.Clear();
                        list.Clear();
                        itemCount = 0;
                    }
                    else if (dt.Rows.Count < 100)
                    {
                        db.SaveCodeList(list);
                        foreach (var positem in pos)
                        {
                            dt.Rows[positem.Key]["CodeId"] = positem.Value.Id;
                            dt.Rows[positem.Key]["Select"] = false;
                        }
                        pos.Clear();
                        list.Clear();
                        itemCount = 0;
                    }

                }
            }


            if (db.SaveCodeList(list))
            {
                foreach (var item in pos)
                {
                    dt.Rows[item.Key]["CodeId"] = item.Value.Id;
                }
            }

        }
        private bool ReadFile()
        {
            if (!ImportPreCheck())
            {
                return false;
            }
            thread = new Thread(new ThreadStart(ImportFile));
            thread.Start();
            btnStopImport.Enabled = true;
            btnStartImport.Enabled = false;
            return true;
        }
        //private void ReadFiles()
        //{
        //    var _folderList = new Dictionary<String, String>();
        //    var _directoryInfoList = new List<DirectoryInfo>();

        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (String.IsNullOrWhiteSpace(item["Select"].ToString()))
        //        {
        //            continue;
        //        }
        //        var isSelect = (bool)item["Select"];
        //        if (isSelect)
        //        {
        //            var tmpFile = item["FullName"].ToString();
        //            var _fileInfo = new FileInfo(tmpFile);
        //            if (!_fileInfo.Exists)
        //            {
        //                continue;
        //            }

        //            var _folder = item["DirectoryName"].ToString();
        //            var _folderInfo = new DirectoryInfo(_folder);
        //            if (_folderInfo.Exists)
        //            {
        //                if (!_directoryInfoList.Contains(_folderInfo))
        //                {
        //                    _directoryInfoList.Add(_folderInfo);
        //                }
        //            }
        //        }

        //    }

        //    var topFolderInfoList = new List<DirectoryInfo>();
        //    foreach (var item in _directoryInfoList)
        //    {
        //        var parentFolder = item.Parent;

        //        var x = item;
        //        do
        //        {
        //            x = x.Parent;
        //        } while (_directoryInfoList.Contains(x));

        //        if (!_directoryInfoList.Contains(parentFolder))
        //        {
        //            topFolderInfoList.Add(item);
        //        }
        //    }
        //    var treeNodeList = new Dictionary<DirectoryInfo, CodeTree>();
        //    //foreach (var item in topFolderInfoList)
        //    //{
        //    //    var codetree = new CodeTree();
        //    //    codetree.Text = item.Name;
        //    //    codetree.Type = "Folder";
        //    //    var newCodeTree = db.SaveTreeNode(codetree);
        //    //    treeNodeList.Add(item, newCodeTree);

        //    //}



        //}
        //private void SaveFiles()
        //{


        //}

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
        }

        private void btnAddExtension_Click(object sender, EventArgs e)
        {
            if (!this.listExtension.Items.Contains(this.txtExtension.Text))
            {
                this.listExtension.Items.Add(this.txtExtension.Text);
            }

        }

        // public string isSelect { get; set; }

        private string _treeId;
        private string _treePath;
        public string TreeId
        {
            get
            {
                return _treeId;
            }
            set
            {
                this._treeId = value;
                this.txtTreeId.Text = _treeId;
            }
        }
        public string TreePath
        {
            get
            {
                return _treePath;
            }
            set
            {
                this._treePath = value;
                this.txtTreePath.Text = _treePath;
            }
        }

        /// <summary>
        /// 按本地文件夹的结构，复制导入文件夹下的所有文件。
        /// </summary>
        private void copyTheWholeLocalFolder()
        {
            if (String.IsNullOrEmpty(path))
            {
                MessageBox.Show("请选择文件夹");
                return;
            }
            DirectoryInfo folderFullName = new DirectoryInfo(path);
            if (!folderFullName.Exists)
            {
                throw new DirectoryNotFoundException("文件夹不存在: " + folderFullName);

            }

            copyFolderList.Clear();
            copyCodeList.Clear();
            progressBar1.Value = 0;

            if (String.IsNullOrEmpty(this.TreeId))
            {
                CopyAndImportLocalDirectory(folderFullName);
            }
            else
            {
                var tree = new CodeFolder();
                tree.Id = this.TreeId;
                CopyAndImportLocalDirectory(folderFullName, tree);
            }


            db.SaveCodeList(copyCodeList);
            db.SaveFolderList(copyFolderList);
            MessageBox.Show("保存成功");

        }
        private void setProcessBar(int total, int value, String folder, String file)
        {
            if (this.progressBar1.InvokeRequired || txtFolder.InvokeRequired || txtFileName.InvokeRequired)
            {
                this.Invoke(new deletegateSetProcessBar(setProcessBar), new object[] { total, value, folder, file });

            }
            else
            {
                this.txtFolderName.Text = folder;
                this.txtFileName.Text = file;
                this.txtFoldersFileCount.Text = total.ToString();
                //   this.progressBar1.Maximum = total;

                //this.txtFileCount.Text = total.ToString();
                //  this.txtSavedFiles.Text = total.ToString();
                if (String.IsNullOrEmpty(txtSavedFiles.Text))
                {
                    txtSavedFiles.Text = "0";
                }
                var totalSavedFiles = int.Parse(txtSavedFiles.Text) + 1;
                this.txtSavedFiles.Text = totalSavedFiles.ToString();

                this.progressBar1.Value++;

            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.TotalFileCount = SAPINTGUI.Util.FileUtil.GetFilesCount(path);
            this.txtFilesCount.Text = TotalFileCount.ToString();
            this.progressBar1.Value = 0;
            this.progressBar1.Maximum = TotalFileCount ;
            txtSavedFiles.Text = string.Empty;

            thread = new Thread(new ThreadStart(this.copyTheWholeLocalFolder));
            thread.Start();
            btnStopImport.Enabled = true;
            btnStartImport.Enabled = false;
            // copyTheWholeLocalFolder();

        }

        private void btnClearExtension_Click(object sender, EventArgs e)
        {
            this.listExtension.Items.Clear();

        }


        public int TotalFileCount { get; set; }

        private void btnStopImport_Click(object sender, EventArgs e)
        {
            if (thread !=null)
            {
                if (thread.IsAlive)
                {
                    thread.Abort();
                }
            }
        }
    }
}
