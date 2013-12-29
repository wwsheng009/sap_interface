using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SAPINTDB.CodeManager;
using WeifenLuo.WinFormsUI.Docking;
namespace SAPINT.Gui.CodeManager
{
    public delegate void DeleGateSetNode(TreeNode node);

    public partial class FormCodeManager : DockWindow
    {

        private Codedb db = null;

        public string m_dbName = null;

        private bool loaded = false;

        public CodeFolder SelectedFolder { get; set; }


        private CodeFolder m_TempFolder = null;

        public CodeFolder TempFolder
        {
            get { return this.m_TempFolder; }
            set
            {
                this.m_TempFolder = value;
                NotifyListener();
            }
        }
        public Code SelectedCode { get; set; }
        public Code TemplateCode { get; set; }
        public Code TempAbapRunCode { get; set; }

        public event EventHandler EventCodeManagerChange = null;

        private void NotifyListener()
        {
            if (EventCodeManagerChange != null)
            {
                EventCodeManagerChange(this, null);
            }
        }


        public FormCodeManager(String dbName = null, bool pick = false)
        {


            InitializeComponent();

            if (String.IsNullOrEmpty(dbName))
            {
                m_dbName = ConfigFileTool.SAPGlobalSettings.GetDefaultCodeManagerDb();
            }
            else
            {
                m_dbName = dbName;
            }





            if (pick)
            {
                //this.cbxDbSources.Visible = false;
                this.cbxDbSources.DataSource = null;
                this.cbxDbSources.Text = m_dbName;
                this.cbxDbSources.Enabled = false;
            }
            else
            {
                this.cbxDbSources.Text = m_dbName;
                //this.cbxDbSources.SelectedText = m_dbName;


                this.cbxDbSources.DataSource = ConfigFileTool.SAPGlobalSettings.GetManagerDbList();
                this.cbxDbSources.SelectedIndexChanged += cbxDbSources_SelectedIndexChanged;
            }

            updateDbConnect();

            //一定要在初始化后再加上事件监听。否则控件会被循环引用，整个窗体会被卡死。
            treeView1.BeforeExpand += treeView1_BeforeExpand;
            treeView1.Click += treeView1_Click;
            treeView1.NodeMouseClick += treeView1_NodeMouseClick;
            treeView1.AfterSelect += treeView1_AfterSelect;
            treeView1.AfterExpand += treeView1_AfterExpand;
            treeView1.AfterCollapse += treeView1_AfterCollapse;


            this.listBox1.SelectionMode = SelectionMode.MultiExtended;


            this.listBox1.SelectedValueChanged += listBox1_SelectedValueChanged;
            this.listBox1.DoubleClick += listBox1_DoubleClick;

            this.Disposed += FormCodeManager_Disposed;


            //drag and drop
            this.listBox1.AllowDrop = true;
            this.treeView1.AllowDrop = true;
            this.listBox1.MouseDown += listBox1_MouseDown;
            this.listBox1.DragOver += listBox1_DragOver;

            this.treeView1.DragEnter += treeView1_DragEnter;
            this.treeView1.DragDrop += treeView1_DragDrop;
            this.treeView1.MouseDown += treeView1_MouseDown;
            this.treeView1.DragOver += treeView1_DragOver;


            this.Shown += FormCodeManager_Shown;




        }

        void updateDbConnect()
        {
            try
            {

                db = new Codedb(m_dbName);
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message + e.Source + e.StackTrace);
                return;
            }



            initTree();
            loaded = true;


            if (this.TempFolder == null)
            {
                var tempFolderId = "b3dc4971-935c-49fb-a061-c9e01956d41d";

                TempFolder = db.GetFolder(tempFolderId);
                var v_root = db.GetRootFolder();
                if (v_root != null)
                {
                    if (TempFolder == null && !string.IsNullOrEmpty(v_root.Id))
                    {
                        TempFolder = db.SaveTree(new CodeFolder(tempFolderId, db.GetRootFolder().Id, "Temp", ""));
                    }
                }

            }
        }

        void cbxDbSources_SelectedIndexChanged(object sender, EventArgs e)
        {
            var chk = sender as ComboBox;
            m_dbName = chk.Text;
            this.treeView1.Nodes.Clear();
            listBox1.DataSource = null;
            this.TempFolder = null;
            this.updateDbConnect();


            //throw new NotImplementedException();
        }

        void treeView1_DragOver(object sender, DragEventArgs e)
        {
            //throw new NotImplementedException();
            e.Effect = DragDropEffects.Move;
        }

        void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.treeView1.SelectedNode != null)
            {
                if (ModifierKeys.HasFlag(Keys.Control))
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        this.treeView1.DoDragDrop(this.treeView1.SelectedNode, DragDropEffects.Move);
                    }
                }
            }

            //throw new NotImplementedException();
        }

        void FormCodeManager_Shown(object sender, EventArgs e)
        {
            if (this.DockPanel != null)
            {
                this.splitContainer3.Panel2Collapsed = true;
                this.listBox1.SelectedIndexChanged -= listBox1_SelectedValueChanged;
            }
            else
            {

            }
        }

        void listBox1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            //  throw new NotImplementedException();
        }

        void listBox1_MouseDown(object sender, MouseEventArgs e)
        {

            if (this.listBox1.SelectedItem != null)
            {
                if (ModifierKeys.HasFlag(Keys.Control))
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        this.listBox1.DoDragDrop(this.listBox1.SelectedItem, DragDropEffects.Move);
                    }
                }
            }
        }

        void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode nodeToDropIn = this.treeView1.GetNodeAt(this.treeView1.PointToClient(new Point(e.X, e.Y)));
            CodeFolder codeFolderToDropIn = null;
            if (nodeToDropIn == null)
            {
                return;
            }
            else
            {
                codeFolderToDropIn = nodeToDropIn.Tag as CodeFolder;
            }
            var formats = e.Data.GetFormats();
            //if (sourceType == typeof(Code))
            //{
            var code = e.Data.GetData(typeof(Code)) as Code;
            if (code == null)
            { //return;
            }
            else
            {
                if (codeFolderToDropIn != null)
                {
                    code.TreeId = codeFolderToDropIn.Id;
                    db.SaveCode(code);
                    if (codeFolderToDropIn.CodeList == null)
                    {

                        codeFolderToDropIn.CodeList = new List<Code>();
                    }
                    codeFolderToDropIn.CodeList.Add(code);
                }
                var codelist = listBox1.DataSource as List<Code>;
                if (codelist != null)
                {
                    if (codelist.Contains(code))
                    {
                        codelist.Remove(code);
                    }
                }
                listBox1.DataSource = null;
                listBox1.DataSource = codelist;
                listBox1.DisplayMember = "Title";
            }

            var treeNode = e.Data.GetData(typeof(TreeNode)) as TreeNode;
            if (treeNode == null)
            {
                //  return;
            }
            else
            {
                var folder = treeNode.Tag as CodeFolder;
                if (codeFolderToDropIn != null && folder != null)
                {
                    folder.ParentId = codeFolderToDropIn.Id;
                    folder = db.SaveTree(folder);

                    var newTreeNode = this.treeView1.SelectedNode;
                    newTreeNode.Tag = folder;
                    newTreeNode.Parent.Nodes.Remove(newTreeNode);
                    // this.treeView1.SelectedNode.Remove();
                    nodeToDropIn.Nodes.Add(newTreeNode);
                }
            }




        }

        void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            //  throw new NotImplementedException();
        }

        void FormCodeManager_Disposed(object sender, EventArgs e)
        {
            //  GC.Collect();
            //throw new NotImplementedException();
        }

        void treeView1_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                if (e.Node.Tag != null)
                {
                    //  e.Node.Tag = null;


                    foreach (TreeNode item in e.Node.Nodes)
                    {
                        foreach (TreeNode item2 in item.Nodes)
                        {
                            item2.Nodes.Clear();
                            //     item2.Tag = null;

                        }
                        item.Nodes.Clear();
                        //   item.Tag = null;

                    }
                    e.Node.Nodes.Clear();
                    // GC.Collect();
                }
            }
            //throw new NotImplementedException();
        }

        void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                //  var thread = new Thread(new ThreadStart(voidUpdateNode));
                //  thread.Start();
                //updateTreeNode(e.Node);
            }
        }

        private void initTree()
        {
            var list = db.GetTopLit();
            foreach (var item in list)
            {
                TreeNode node = new TreeNode();
                node.Text = item.Text;
                node.Tag = item;
                node.ImageIndex = 0;

                if (item.SubTreeList != null)
                {
                    foreach (var subItem in item.SubTreeList)
                    {
                        var subNode = new TreeNode();
                        subNode.Text = subItem.Text;
                        subNode.Tag = subItem;
                        subNode.ImageIndex = 0;
                        node.Nodes.Add(subNode);
                    }
                }
                this.treeView1.Nodes.Add(node);

                this.UpdateTreeNode(node);
            }

        }
        public void ShowCode(Code _selectCode)
        {
            if (_selectCode == null)
            {
                return;
            }
            var frm = new FormCodeEditor(this.m_dbName);
            frm.code = _selectCode;
            frm.Text = _selectCode.Title;
            if (!String.IsNullOrEmpty(_selectCode.TreeId))
            {
                var codeTree = db.GetFolder(_selectCode.TreeId);
                if (codeTree == null)
                {
                    codeTree = SelectedFolder;
                }
                if (codeTree != null)
                {
                    frm.TreeId = codeTree.Id;
                    frm.TreeText = codeTree.Text;
                }
            }

            //frm.Show();
            if (this.DockPanel != null)
            {
                frm.Show(this.DockPanel);
            }
        }

        private IDockContent FindDocument(string text)
        {
            if (this.DockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                    if (form.Text == text)
                        return form as IDockContent;

                return null;
            }
            else
            {
                foreach (IDockContent content in DockPanel.Documents)
                    if (content.DockHandler.TabText == text)
                        return content;

                return null;
            }
        }

        void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 0)
            {
                return;
            }

            CodeFolder _codeFolder = null;
            if (treeView1.SelectedNode != null)
            {
                _codeFolder = treeView1.SelectedNode.Tag as CodeFolder;

                if (_codeFolder != null)
                {
                    this.SelectedFolder = _codeFolder;
                }


            }

            if (this.SelectedFolder == null)
            {
                MessageBox.Show("没有选中的文件夹");
                return;
            }
            _codeFolder = SelectedFolder;

            var _selectCode = listBox1.SelectedItem as Code;


            var list = listBox1.DataSource as List<Code>;

            if (_selectCode != null)
            {
                this.SelectedCode = _selectCode;
                IDockContent content = FindDocument(_selectCode.Title);
                if (content == null)
                {
                    var frm = new FormCodeEditor(this.m_dbName);

                    frm.code = _selectCode;
                    frm.Text = _selectCode.Title;
                    if (_codeFolder != null)
                    {
                        frm.TreeId = _codeFolder.Id;
                        frm.TreeText = _codeFolder.Text;
                    }
                    //frm.Show();
                    if (this.DockPanel != null)
                    {
                        frm.Show(this.DockPanel);
                    }
                }
                else
                {
                    content.DockHandler.Activate();
                }

            }
            var newCode = db.GetCode(_selectCode.Id);
            if (newCode != null)
            {
                this.toolStripStatusLabel1.Text = string.Empty;
                if (newCode.Content.Length > 3 * 1024 * 1024)
                {
                    this.toolStripStatusLabel1.Text = "文件太大，无法显示";
                    // MessageBox.Show("文件太大，无法显示");
                    return;
                }
                if (this.splitContainer3.Panel2Collapsed == false)
                {
                    syntaxBoxControl1.Document.Text = newCode.Content;
                    // this.textBox1.Text = newCode.Content;
                    webBrowser1.DocumentText = newCode.Content;
                }

            }
            else
            {
                //updateTreeNode(treeView1.SelectedNode);
                list.Remove(_selectCode);
                listBox1.DataSource = null;
                listBox1.DataSource = list;
                listBox1.DisplayMember = "Title";

                syntaxBoxControl1.Document.Text = string.Empty;
                //  this.textBox1.Text = string.Empty;
                webBrowser1.DocumentText = string.Empty;
            }

        }

        void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                if (e.Node.Tag != null)
                {
                    var codetree = e.Node.Tag as CodeFolder;
                    this.SelectedFolder = codetree;
                    // codetree.Id;
                }

                //if (!e.Node.IsExpanded)
                //{
                var thread = new Thread(new ThreadStart(UpdateNode));
                thread.Start();
                //updateTreeNode(e.Node);
                //}

            }

        }

        void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            // listBox1.SelectedItem
            var code = listBox1.SelectedItem as Code;

            if (code != null)
            {
                this.SelectedCode = code;

                this.toolStripStatusLabel1.Text = string.Empty;
                if (code.Content.Length > 3 * 1024 * 1024)
                {
                    this.toolStripStatusLabel1.Text = "文件太大，无法显示";
                    // MessageBox.Show("文件太大，无法显示");
                    return;
                }
                if (this.splitContainer3.Panel2Collapsed == false)
                {
                    this.syntaxBoxControl1.Document.Text = code.Content;
                    // this.textBox1.Text = code.Content;
                    webBrowser1.DocumentText = code.Content;
                }

            }

            // throw new NotImplementedException();
        }

        private void UpdateNode()
        {
            try
            {
                if (this.treeView1.InvokeRequired)
                {
                    // var node = this.treeView1.SelectedNode;
                    this.Invoke(new DeleGateSetNode(UpdateTreeNode), new object[] { null });
                }
                else
                {
                    UpdateTreeNode();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }

        }
        private void UpdateTreeNode(TreeNode node = null)
        {
            if (node == null)
            {
                node = this.treeView1.SelectedNode;
            }
            if (node != null)
            {
                node.Nodes.Clear();

                var codeTreeNode = node.Tag as CodeFolder;
                //if (codeTreeNode.SubTreeList == null || codeTreeNode.SubTreeList.Count == 0)
                //{
                // this.txtStatus.Text = codeTreeNode.Id;
                toolStripStatusLabel2.Text = codeTreeNode.Id;
                codeTreeNode = db.GetFolder(codeTreeNode.Id);


                node.Tag = codeTreeNode;

                //}

                if (codeTreeNode.CodeList != null)
                {
                    listBox1.DataSource = codeTreeNode.CodeList;
                    listBox1.DisplayMember = "Title";

                }
                //在这里，加载两层nodes
                if (codeTreeNode.SubTreeList != null && codeTreeNode.SubTreeList.Count > 0)
                {
                    var newNodeList = new List<TreeNode>();
                    this.progressBar1.Value = 0;
                    this.progressBar1.Maximum = codeTreeNode.SubTreeList.Count;

                    foreach (var item in codeTreeNode.SubTreeList)
                    {
                        //e.Node.Nodes.Add(new TreeNode() { Text = item.Text, Tag = item });
                        var nodeTree = new TreeNode() { Text = item.Text, Tag = item };
                        //不要加载两层，有严重的性能问题
                        //var subCodeTree = item;
                        //subCodeTree = db.GetTree(item.Id);
                        //progressBar2.Value = 0;
                        //if (subCodeTree.SubTreeList != null && subCodeTree.SubTreeList.Count > 0)
                        //{
                        //    var newNodeList2 = new List<TreeNode>();
                        //    this.progressBar2.Maximum = subCodeTree.SubTreeList.Count;
                        //    foreach (var item2 in subCodeTree.SubTreeList)
                        //    {
                        //        var nodeTree2 = new TreeNode() { Text = item2.Text, Tag = item2 };
                        //        newNodeList2.Add(nodeTree2);

                        //    }
                        //    nodeTree.Nodes.AddRange(newNodeList2.ToArray());
                        //    progressBar2.Value++;
                        //}

                        newNodeList.Add(nodeTree);
                        progressBar1.Value++;
                    }
                    node.Nodes.AddRange(newNodeList.ToArray());

                }

                listBox1.DataSource = null;
                var codeTree = node.Tag as CodeFolder;

                if (codeTree != null)
                {
                    this.SelectedFolder = codeTree;
                    this.listBox1.DataSource = codeTree.CodeList;
                    this.listBox1.DisplayMember = "Title";
                }
            }
        }
        void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Node != null)
                {
                    if (!e.Node.IsExpanded)
                    {
                        var thread = new Thread(new ThreadStart(UpdateNode));
                        thread.Start();
                    }

                    //updateTreeNode(e.Node);
                    //updateTreeNode(e.Node);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            //throw new NotImplementedException();
        }

        void treeView1_Click(object sender, EventArgs e)
        {

            // throw new NotImplementedException();
        }

        void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            // throw new NotImplementedException();
        }

        private void AddNewFolderToTheListViewNode(TreeNode node)
        {
            var treeNode = node;
            CodeFolder codeTree = null;
            if (treeNode != null)
            {
                codeTree = treeNode.Tag as CodeFolder;
            }


            var folderName = GetFolderName();
            if (String.IsNullOrEmpty(folderName))
            {
                return;
            }
            var nodeTree = new CodeFolder();
            nodeTree.Text = folderName;
            if (codeTree != null && !String.IsNullOrEmpty(codeTree.Id))
            {
                nodeTree.ParentId = codeTree.Id;
            }
            var newNode = db.SaveTree(nodeTree);
            if (newNode != null)
            {

                var treeNode1 = new TreeNode();
                treeNode1.Text = newNode.Text;
                treeNode1.Tag = newNode;
                if (treeNode != null)
                {
                    treeNode.Nodes.Add(treeNode1);
                }
                else
                {
                    this.treeView1.Nodes.Add(treeNode1);
                }
            }


        }
        public bool AddNewCodeToTempFolder(Code code, bool show = false)
        {
            if (TempFolder == null)
            {
                MessageBox.Show("请选择一个临时文件夹");
                return false;
            }
            code.TreeId = this.TempFolder.Id;
            var newcode = db.SaveCode(code);
            if (newcode != null)
            {
                if (TempFolder.CodeList != null)
                {
                    if (SelectedFolder.Id == TempFolder.Id)
                    {
                        TempFolder.CodeList.Add(newcode);
                        this.listBox1.DataSource = SelectedFolder.CodeList;
                        this.listBox1.DisplayMember = "Title";
                    }
                }
                if (show == true)
                {
                    this.ShowCode(newcode);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        private void AddNewCodeToTheLisViewNode()
        {

            var node = this.treeView1.SelectedNode;
            if (node == null)
            {
                MessageBox.Show("请选择一个文件夹");
                return;
            }

            var codeFolderNode = node.Tag as CodeFolder;
            codeFolderNode = db.GetFolder(codeFolderNode.Id);

            if (codeFolderNode == null)
            {
                MessageBox.Show("节点不是CodeFolder");
                return;
            }
            var fileName = GetFileName();
            if (String.IsNullOrEmpty(fileName))
            {
                return;
            }
            var code = new Code();
            code.Title = fileName;
            code.TreeId = codeFolderNode.Id;
            var newcode = db.SaveCode(code);
            if (newcode != null)
            {
                if (codeFolderNode.CodeList != null)
                {
                    codeFolderNode.CodeList.Add(newcode);
                    this.listBox1.DataSource = codeFolderNode.CodeList;
                    this.listBox1.DisplayMember = "Title";
                }

            }
        }
        private void newFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewFolderToTheListViewNode(this.treeView1.SelectedNode);
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewCodeToTheLisViewNode();
        }
        private String GetFileName(String oldName = "")
        {
            var frm = new FormGetText();
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(Control.MousePosition.X, Control.MousePosition.Y);
            frm.Result = oldName;
            frm.LableText = "文件名：";
            frm.Title = "输入文件名";
            frm.ShowDialog();
            var result = frm.Result;
            frm.Dispose();
            frm = null;
            return result;

        }
        private String GetFolderName(String oldName = "")
        {
            var frm = new FormGetText();
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(Control.MousePosition.X, Control.MousePosition.Y);
            frm.Result = oldName;

            frm.LableText = "文件夹名：";
            frm.Title = "输入文件夹名";
            frm.ShowDialog();
            var result = frm.Result;
            frm.Dispose();
            frm = null;
            return result;

        }

        private void reNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = this.treeView1.SelectedNode;
            if (node == null)
            {
                MessageBox.Show("请选择文件夹");
                return;
            }
            var codeTreeNode = node.Tag as CodeFolder;
            if (codeTreeNode == null)
            {
                MessageBox.Show("CodeTree 不正确");
                return;
            }
            codeTreeNode.Text = GetFolderName(codeTreeNode.Text);
            var newCodeNode = db.SaveTree(codeTreeNode);
            if (newCodeNode != null)
            {
                node.Text = newCodeNode.Text;
                node.Tag = newCodeNode;
            }
        }

        private void toolStripMenuItemEditCode_Click(object sender, EventArgs e)
        {
            var selectItem = listBox1.SelectedItem as Code;
            if (selectItem != null)
            {
                var frm = new FormCodeEditor();
                frm.code = selectItem;
                frm.Show();
            }
        }

        private void toolStripMenuItemDeleteCode_Click(object sender, EventArgs e)
        {
            var selectedCodeList = listBox1.SelectedItems;
            var codelist = listBox1.DataSource as List<Code>;

            var removed = new List<Code>();
            if (selectedCodeList != null)
            {
                foreach (var item in selectedCodeList)
                {
                    removed.Add(item as Code);
                    codelist.Remove(item as Code);
                }
            }
            db.DeleteCodeList(removed);

            listBox1.DataSource = null;
            listBox1.DataSource = codelist;
            listBox1.DisplayMember = "Title";

            var selectedNode = treeView1.SelectedNode.Tag as CodeFolder;
            if (selectedNode != null)
            {
                selectedNode.CodeList = codelist;

            }

        }

        private void toolStripMenuItemImportFile_Click(object sender, EventArgs e)
        {
            var seletedNode = this.treeView1.SelectedNode;
            if (seletedNode == null)
            {
                MessageBox.Show("请先选择文件夹");
                return;
            }
            var codetreeNode = seletedNode.Tag as CodeFolder;
            if (codetreeNode == null)
            {
                MessageBox.Show("无效的节点");
                return;
            }
            var frm = new FormImportFile();
            frm.TreeId = codetreeNode.Id;
            frm.TreePath = seletedNode.FullPath;
            frm.Show();
        }

        private void toolStripMenuItemImportFromSap_Click(object sender, EventArgs e)
        {
            var seletedNode = this.treeView1.SelectedNode;
            if (seletedNode == null)
            {
                MessageBox.Show("请先选择文件夹");
                return;
            }
            var codetreeNode = seletedNode.Tag as CodeFolder;
            if (codetreeNode == null)
            {
                MessageBox.Show("无效的节点");
                return;
            }
            var frm = new FormImportSapProgram();
            frm.TreeId = codetreeNode.Id;
            frm.TreePath = seletedNode.FullPath;
            frm.Show();
        }

        private void toolStripMenuItemDeleteFolder_Click(object sender, EventArgs e)
        {
            try
            {
                var treeNode = treeView1.SelectedNode;
                var codeFolder = treeNode.Tag as CodeFolder;
                if (codeFolder == null)
                {
                    MessageBox.Show("请选择文件夹");
                    return;
                }
                if (db.DeleteFolder(codeFolder))
                {
                    //  updateTreeNode(treeNode);
                }
                if (treeNode.Parent != null)
                {
                    treeNode.Parent.Nodes.Remove(treeNode);
                }
                else
                {
                    treeView1.Nodes.Remove(treeNode);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }


        private void ToolStripMenuItemAddTopFolder_Click_1(object sender, EventArgs e)
        {
            AddNewFolderToTheListViewNode(null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel1Collapsed = !this.splitContainer1.Panel1Collapsed;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2Collapsed = !this.splitContainer1.Panel2Collapsed;
        }


        private void reNameCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                var code = listBox1.SelectedItem as Code;
                if (code != null)
                {
                    //var newName = GetFileName(code.Title);
                    var formName = new FormGetText();
                    formName.Title = "请输入代码名称";
                    formName.LableText = "代码名:";
                    formName.Result = code.Title;
                    formName.ShowDialog();
                    if (!string.IsNullOrEmpty(formName.Result))
                    {
                        var list = listBox1.DataSource as List<Code>;
                        list.Remove(code);
                        code.Title = formName.Result;
                        code = db.SaveCode(code);

                        list.Add(code);
                        listBox1.DataSource = null;
                        listBox1.DataSource = list;
                        listBox1.DisplayMember = "Title";
                    }

                }
            }
        }
        public Code GetLatestCode(Code _code)
        {
            return db.GetCode(_code.Id);
        }
        private void lockCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TemplateCode = SelectedCode;
            NotifyListener();
        }

        private void SetRunCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TempAbapRunCode = SelectedCode;
            NotifyListener();
        }

        private void SetTempFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TempFolder = SelectedFolder;

        }

        private void chFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void NewCodeStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                var fileName = GetFileName();
                if (String.IsNullOrEmpty(fileName))
                {
                    return;
                }
                var code = new Code();
                code.Title = fileName;
                code.TreeId = this.SelectedFolder.Id;
                var newcode = db.SaveCode(code);
                if (newcode != null)
                {
                    SelectedFolder = db.GetFolder(SelectedFolder.Id);
                    if (SelectedFolder.CodeList != null)
                    {
                        // SelectedFolder.CodeList.Add(newcode);
                        this.listBox1.DataSource = SelectedFolder.CodeList;
                        this.listBox1.DisplayMember = "Title";
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            this.splitContainer1.Panel1Collapsed = !this.splitContainer1.Panel1Collapsed;
        }

        private void toolStripSplitButton2_ButtonClick(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2Collapsed = !this.splitContainer1.Panel2Collapsed;
        }

    }
}
