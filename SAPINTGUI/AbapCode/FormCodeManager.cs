using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAPINTDB.CodeManager;

namespace SAPINTGUI.AbapCode
{
    public partial class FormCodeManager : Form
    {
        Codedb db = new Codedb();
        public FormCodeManager()
        {
            InitializeComponent();
            initTree();
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
            }
            treeView1.BeforeExpand += treeView1_BeforeExpand;
            treeView1.Click += treeView1_Click;
            treeView1.NodeMouseClick += treeView1_NodeMouseClick;
            treeView1.AfterSelect += treeView1_AfterSelect;

            this.listBox1.SelectionMode = SelectionMode.MultiExtended;
            this.listBox1.SelectedValueChanged += listBox1_SelectedValueChanged;

        }

        void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listBox1.DataSource = null;
            var codeTree = e.Node.Tag as CodeTree;
            if (codeTree != null)
            {
                this.listBox1.DataSource = codeTree.CodeList;
                this.listBox1.DisplayMember = "Title";
            }
        }

        void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            // listBox1.SelectedItem
            var code = listBox1.SelectedItem as Code;
            if (code != null)
            {
                this.syntaxBoxControl1.Document.Text = code.Content;
            }

            // throw new NotImplementedException();
        }
        private void updateTreeNode(TreeNode node)
        {
            if (node != null)
            {
                node.Nodes.Clear();

                var codeTreeNode = node.Tag as CodeTree;
                //if (codeTreeNode.SubTreeList == null || codeTreeNode.SubTreeList.Count == 0)
                //{
                codeTreeNode = db.GetTree(codeTreeNode.Id);
                node.Tag = codeTreeNode;
                //}

                if (codeTreeNode.CodeList != null)
                {
                    listBox1.DataSource = codeTreeNode.CodeList;
                    listBox1.DisplayMember = "Title";

                }
                //在这里，加载两层nodes
                if (codeTreeNode.SubTreeList != null)
                {
                    var newNodeList = new List<TreeNode>();
                    foreach (var item in codeTreeNode.SubTreeList)
                    {
                        //e.Node.Nodes.Add(new TreeNode() { Text = item.Text, Tag = item });
                        var nodeTree = new TreeNode() { Text = item.Text, Tag = item };
                        var subCodeTree = item;
                        subCodeTree = db.GetTree(item.Id);
                        if (subCodeTree.SubTreeList != null)
                        {
                            var newNodeList2 = new List<TreeNode>();
                            foreach (var item2 in subCodeTree.SubTreeList)
                            {
                                var nodeTree2 = new TreeNode() { Text = item2.Text, Tag = item2 };
                                newNodeList2.Add(nodeTree2);

                            }
                            nodeTree.Nodes.AddRange(newNodeList2.ToArray());

                        }

                        newNodeList.Add(nodeTree);

                    }
                    node.Nodes.AddRange(newNodeList.ToArray());

                }

            }
        }
        void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Node != null)
                {
                    updateTreeNode(e.Node);
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

        private void addNewFolderToTheListViewNode(TreeNode node)
        {
            var treeNode = node;
            CodeTree codeTree = null;
            if (treeNode != null)
            {
                codeTree = treeNode.Tag as CodeTree;
            }


            var folderName = getFolderName();
            if (String.IsNullOrEmpty(folderName))
            {
                return;
            }
            var nodeTree = new CodeTree();
            nodeTree.Text = folderName;
            if (codeTree != null && !String.IsNullOrEmpty(codeTree.Id))
            {
                nodeTree.ParentId = codeTree.Id;
            }
            var newNode = db.SaveTreeNode(nodeTree);
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
        private void addNewCodeToTheLisViewNode()
        {
            var node = this.treeView1.SelectedNode;
            if (node == null)
            {
                MessageBox.Show("请选择一个文件夹");
                return;
            }

            var codeTreeNode = node.Tag as CodeTree;
            codeTreeNode = db.GetTree(codeTreeNode.Id);

            if (codeTreeNode == null)
            {
                MessageBox.Show("节点不是CodeTree");
                return;
            }
            var fileName = getFileName();
            if (String.IsNullOrEmpty(fileName))
            {
                return;
            }
            var code = new Code();
            code.Title = fileName;
            code.TreeId = codeTreeNode.Id;
            var newcode = db.SaveCode(code);
            if (newcode != null)
            {
                if (codeTreeNode.CodeList != null)
                {
                    codeTreeNode.CodeList.Add(newcode);
                    this.listBox1.DataSource = codeTreeNode.CodeList;
                    this.listBox1.DisplayMember = "Title";
                }

            }
        }
        private void newFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addNewFolderToTheListViewNode(this.treeView1.SelectedNode);
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addNewCodeToTheLisViewNode();
        }
        private String getFileName()
        {
            var frm = new FormGetText();
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(Control.MousePosition.X, Control.MousePosition.Y);

            frm.LableText = "文件名：";
            frm.Title = "输入文件名";
            frm.ShowDialog();
            var result = frm.Result;
            frm.Dispose();
            frm = null;
            return result;

        }
        private String getFolderName()
        {
            var frm = new FormGetText();
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(Control.MousePosition.X, Control.MousePosition.Y);


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
            var codeTreeNode = node.Tag as CodeTree;
            if (codeTreeNode == null)
            {
                MessageBox.Show("CodeTree 不正确");
                return;
            }
            codeTreeNode.Text = getFolderName();
            var newCodeNode = db.SaveTreeNode(codeTreeNode);
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
            var selettedCodeList = listBox1.SelectedItems;
            var codelist = listBox1.DataSource as List<Code>;

            var removed = new List<Code>();
            if (selettedCodeList != null)
            {
                foreach (var item in selettedCodeList)
                {
                    removed.Add(item as Code);
                    codelist.Remove(item as Code);
                }
            }
            db.DeleteCodeList(removed);

            listBox1.DataSource = null;
            listBox1.DataSource = codelist;
            listBox1.DisplayMember = "Title";

            var selectedNode = treeView1.SelectedNode.Tag as CodeTree;
            if (selectedNode != null)
            {
                selectedNode.CodeList = codelist;

            }
            //for (int i = 0; i < selettedCodeList.Count; i++)
            //{
            //    //  var item = selettedCodeList[i] as Code;
            //    db.DeleteCode(codelist[i]);
            //}



            //var selectedCode = listBox1.SelectedItem as Code;
            //if (selectedCode != null)
            //{
            //    var DeleteOk = db.DeleteCode(selectedCode);
            //    if (DeleteOk)
            //    {
            //        var codelist = listBox1.DataSource as List<Code>;

            //        codelist.Remove(selectedCode);

            //        //listBox1.Items.Remove(selectedCode);
            //        listBox1.DataSource = null;
            //        listBox1.DataSource = codelist;
            //        listBox1.DisplayMember = "Title";

            //        var selectedNode = treeView1.SelectedNode.Tag as CodeTree;
            //        if (selectedNode != null)
            //        {
            //            selectedNode.CodeList.Remove(selectedCode);

            //        }
            //    }
            //}
        }

        private void toolStripMenuItemImportFile_Click(object sender, EventArgs e)
        {
            var seletedNode = this.treeView1.SelectedNode;
            if (seletedNode == null)
            {
                MessageBox.Show("请先选择文件夹");
                return;
            }
            var codetreeNode = seletedNode.Tag as CodeTree;
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
            var codetreeNode = seletedNode.Tag as CodeTree;
            if (codetreeNode == null)
            {
                MessageBox.Show("无效的节点");
                return;
            }
            var frm = new FormImporSapProgram();
            frm.TreeId = codetreeNode.Id;
            frm.TreePath = seletedNode.FullPath;
            frm.Show();
        }

        private void toolStripMenuItemDeleteFolder_Click(object sender, EventArgs e)
        {
            try
            {
                var treeNode = treeView1.SelectedNode;
                var codeTreeNode = treeNode.Tag as CodeTree;
                if (codeTreeNode == null)
                {
                    MessageBox.Show("请选择文件夹");
                    return;
                }
                if (db.DeleteTreeNode(codeTreeNode))
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
            addNewFolderToTheListViewNode(null);
        }

    }
}
