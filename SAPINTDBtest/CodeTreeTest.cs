using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAPINTDB.CodeManager;

namespace SAPINTDBtest
{
    [TestClass]
    public class CodeTreeTest
    {
        SAPINTDB.CodeManager.Codedb db = new SAPINTDB.CodeManager.Codedb();
        static String id = null;

        [TestMethod]
        public void SetUpTestData()
        {
            db.BeginTransaction();
            for (int i = 0; i < 10; i++)
            {
                CodeTree tree = new CodeTree();
                tree.Text = "Top Folder " + i.ToString();
                var ree = db.SaveTreeNode(tree);

                for (int xx = 0; xx < 10; xx++)
                {
                    Code code1 = new Code();
                    code1.TreeId = ree.Id;
                    code1.Title = tree.Text + " Code " + xx.ToString();
                    db.SaveCode(code1);
                }


                for (int x = 0; x < 10; x++)
                {
                    tree = new CodeTree();

                    tree.Text = tree.Text + " Sub Folder " + x.ToString();
                    tree.ParentId = ree.Id;
                    var treei = db.SaveTreeNode(tree);

                    for (int j = 0; j < 10; j++)
                    {
                        Code code = new Code();
                        code.TreeId = treei.Id;
                        code.Title = tree.Text + " Code " + j.ToString();
                        db.SaveCode(code);
                    }


                }

            }
            db.Commit();


        }
        [TestMethod]
        public void SaveCodeTreeTest()
        {
            SAPINTDB.CodeManager.CodeTree codetree = new SAPINTDB.CodeManager.CodeTree();
            codetree.Text = "Code";
            codetree.Type = "Document";

            db.SaveTreeNode(codetree);
        }
        [TestMethod]
        public void UpdateCodeTreeTest()
        {
            //CodeTree 
            CodeTree codetree = db.GetTree("f8b46c02-90b5-4561-8de3-3973a8cefa4b");
            Assert.AreEqual(codetree.Id, "f8b46c02-90b5-4561-8de3-3973a8cefa4b");
            codetree.Text = "xxxxxxxx";
            db.SaveTreeNode(codetree);
            codetree.ParentId = "﻿﻿982e36e6-4f22-472d-9daf-e361bcfc55a7";
            db.SaveTreeNode(codetree);
            //CodeTree codetree2 = new SAPINTDB.CodeManager.CodeTree();
            //codetree.Text = "Code";
            //codetree.Type = "Document";


        }
        [TestMethod]
        public void GetCodeTreeTest()
        {
            CodeTree codetree = db.GetTree("982e36e6-4f22-472d-9daf-e361bcfc55a7");
            Assert.AreEqual(codetree.SubTreeList.Count, 1);
            Assert.AreEqual(3, codetree.CodeList.Count);
        }
        [TestMethod]
        public void ReadTreeTest()
        {
            var list = db.GetTopLit();
            Assert.AreEqual(10, list.Count);

            var list2 = db.GetTree(list[1].Id);
            Assert.AreEqual(10,list2.SubTreeList.Count);
            Assert.AreEqual(10,list2.CodeList.Count);
        }
    }
}
