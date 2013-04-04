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

            this.listBox1.SelectedValueChanged += listBox1_SelectedValueChanged;

        }

        void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            // listBox1.SelectedItem
            var code = listBox1.SelectedItem as Code;
            this.syntaxBoxControl1.Document.Text = code.Content + code.Title;
            // throw new NotImplementedException();
        }
        void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node != null)
            {
                e.Node.Nodes.Clear();

                var codeTreeNode = e.Node.Tag as CodeTree;
                //if (codeTreeNode.SubTreeList == null || codeTreeNode.SubTreeList.Count == 0)
                //{
                codeTreeNode = db.GetTree(codeTreeNode.Id);
                e.Node.Tag = codeTreeNode;
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
                    e.Node.Nodes.AddRange(newNodeList.ToArray());

                }

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

        private void addNewFolderToTheListViewNode()
        {
            var node = this.treeView1.SelectedNode;
            if (node != null)
            {
                var parentNodeTree = node.Tag as CodeTree;
                if (parentNodeTree == null)
                {
                    MessageBox.Show("节点不是CodeTree");
                    return;
                }
                var folderName = getFolderName();
                if (String.IsNullOrEmpty(folderName))
                {
                    return;
                }
                var nodeTree = new CodeTree();
                nodeTree.Text = folderName;
                if (String.IsNullOrEmpty(parentNodeTree.Id))
                {
                    nodeTree.ParentId = string.Empty;
                }
                else
                {
                    nodeTree.ParentId = parentNodeTree.Id;
                }
                var newNode = db.SaveTreeNode(nodeTree);
                if (newNode != null)
                {
                    parentNodeTree.SubTreeList.Add(newNode);
                    var treeNode = new TreeNode();
                    treeNode.Text = newNode.Text;
                    treeNode.Tag = newNode;
                    node.Nodes.Add(treeNode);
                }
                node.Tag = parentNodeTree;
                this.treeView1.SelectedNode = node;

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
            addNewFolderToTheListViewNode();
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

    }
}
