using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAPINTDB;
using SAPINTDB.CodeManager;

namespace SAPINTGUI.AbapCode
{
    public partial class FormImporSapProgram : Form
    {
        DataTable dt = null;
        Dictionary<int, Code> pos = new Dictionary<int, Code>();
        Codedb db = new Codedb();

        public FormImporSapProgram()
        {
            InitializeComponent();

            Alsing.SourceCode.SyntaxDefinition sl = new Alsing.SourceCode.SyntaxDefinitionLoader().Load("abap.syn");

            this.syntaxBoxControl1.Document.Parser.Init(sl);

            dt = new DataTable("SapReport");
            dt.Columns.AddRange(new DataColumn[]{
               new DataColumn("Index",typeof(int)),
               new DataColumn("Select",typeof(Boolean)),
               //new DataColumn("Program",typeof(String)),
               new DataColumn("Header",typeof(String)),
               
               new DataColumn("Length",typeof(String)),
               //new DataColumn("Extension",typeof(String)),
               new DataColumn("CodeId",typeof(String)),
               //new DataColumn("DirectoryName",typeof(String)),
               //new DataColumn("FullName",typeof(String)),
	 	    	//new DataColumn("PGMID",typeof(String)),
	 	    	//new DataColumn("OBJECT",typeof(String)),
	 	    	new DataColumn("OBJ_NAME",typeof(String)),
	 	    //	new DataColumn("KORRNUM",typeof(String)),
	 	    	//new DataColumn("SRCSYSTEM",typeof(String)),
	 	    	new DataColumn("AUTHOR",typeof(String)),
	 	    	new DataColumn("SRCDEP",typeof(String)),
	 	    	new DataColumn("DEVCLASS",typeof(String)),
	 	    //	new DataColumn("GENFLAG",typeof(String)),
	 	    //	new DataColumn("EDTFLAG",typeof(String)),
	 	    //	new DataColumn("CPROJECT",typeof(String)),
	 	    	new DataColumn("MASTERLANG",typeof(String)),
	 	    //	new DataColumn("VERSID",typeof(String)),
	 	    //	new DataColumn("PAKNOCHECK",typeof(String)),
	 	    //	new DataColumn("OBJSTABLTY",typeof(String)),
	 	    //	new DataColumn("COMPONENT",typeof(String)),
	 	    //	new DataColumn("CRELEASE",typeof(String)),
	 	    //	new DataColumn("DELFLAG",typeof(String)),
	 	    //	new DataColumn("TRANSLTTXT",typeof(String)),
               
            });
            // dt.Columns["Index"].AutoIncrement = true;
            dt.Columns["Select"].DefaultValue = false;
            this.dataGridView1.DataSource = dt;
            this.dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            this.dataGridView1.CurrentCellChanged += dataGridView1_CurrentCellChanged;

        }

        void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {

            var cell = dataGridView1.CurrentCell;
            if (cell != null && cell.Value != null)
            {
                if (cell.OwningColumn.Name == "Header")
                {
                    this.syntaxBoxControl1.Document.Text = cell.Value.ToString();
                }

            }
        }

        void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
                    else if (dt.Columns[e.ColumnIndex].ColumnName == "OBJ_NAME")
                    {
                        var x = LoadOneObject(cell.Value.ToString());
                        dataGridView1["Header", e.RowIndex].Value = x;
                        dataGridView1["Length", e.RowIndex].Value = Util.FileUtil.FormatFileSize(x.Length);
                    }
                }
            }
        }


        private string ExcuteAbapCode(string Code)
        {
            SAPINT.Utils.ABAPCode abap = new SAPINT.Utils.ABAPCode(this.cboxSystemList1.Text.Trim().ToUpper());

            abap.ResetCode();
            //使用TEXTBOX转换字符串。
            TextBox box = new TextBox();
            box.Text = Code;

            foreach (string line in box.Lines)
            {
                abap.AddCodeLine(line);
            }
            box.Text = "";
            try
            {
                if (abap.InstallAndRun())
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

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string s = @"
REPORT load_abap_program.

DATA : BEGIN OF dt_program OCCURS 0,
       line TYPE c LENGTH 800,
       END OF dt_program.

DATA : objname TYPE tadir-obj_name.

START-OF-SELECTION.

  objname = '{0}'.


  SELECT COUNT(*) FROM tadir WHERE pgmid = 'R3TR' AND object = 'PROG' AND
        obj_name = objname.

  IF sy-dbcnt = 0.
    WRITE : / 'Can not find the report'.
    EXIT.
  ENDIF.

  READ REPORT objname INTO dt_program.

  LOOP AT dt_program.
    WRITE : / dt_program-line.
  ENDLOOP.";

            string report = string.Format(s, this.txtSapProgram.Text.Trim());
            this.syntaxBoxControl1.Document.Text = ExcuteAbapCode(report);
        }

        private void btnSearchReport_Click(object sender, EventArgs e)
        {
            dt.Clear();
            try
            {
                this.SapSysName = this.cboxSystemList1.Text.Trim().ToUpper();
                SAPINT.Utils.ABAPCode abap = new SAPINT.Utils.ABAPCode(SapSysName);
                var list = abap.SearchProgram(this.txtSapProgram.Text, this.txtDevClass.Text);
                //list.ForEach(x => { });
                int index = 0;
                foreach (var item in list)
                {
                    var r = dt.NewRow();
                    r["Index"] = index;
                    index++;
                    //  r["PGMID"] = item.PGMID;
                    // r["OBJECT"] = item.OBJECT;
                    r["OBJ_NAME"] = item.OBJ_NAME;
                    //  r["KORRNUM"] = item.KORRNUM;
                    // r["SRCSYSTEM"] = item.SRCSYSTEM;
                    r["AUTHOR"] = item.AUTHOR;
                    r["SRCDEP"] = item.SRCDEP;
                    r["DEVCLASS"] = item.DEVCLASS;
                    //   r["GENFLAG"] = item.GENFLAG;
                    //   r["EDTFLAG"] = item.EDTFLAG;
                    //   r["CPROJECT"] = item.CPROJECT;
                    r["MASTERLANG"] = item.MASTERLANG;
                    //   r["VERSID"] = item.VERSID;
                    //   r["PAKNOCHECK"] = item.PAKNOCHECK;
                    //   r["OBJSTABLTY"] = item.OBJSTABLTY;
                    //  r["COMPONENT"] = item.COMPONENT;
                    //   r["CRELEASE"] = item.CRELEASE;
                    //   r["DELFLAG"] = item.DELFLAG;
                    //   r["TRANSLTTXT"] = item.TRANSLTTXT;
                    dt.Rows.Add(r);
                }
                this.dataGridView1.AutoResizeColumns();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                if (LoadObjectFromSap())
                {
                    MessageBox.Show("导入完成");
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

        private string LoadOneObject(String obj)
        {
            this.SapSysName = cboxSystemList1.Text;
            if (String.IsNullOrEmpty(SapSysName))
            {
                MessageBox.Show("请选择系统");
                return "";
            }
            this.AbapCode = new SAPINT.Utils.ABAPCode(SapSysName);
            var codes = AbapCode.GetSourceCode(obj);
            var sb = new StringBuilder();

            codes.ForEach(x => sb.AppendLine(x));
            var s = sb.ToString();
            this.syntaxBoxControl1.Document.Text = s;
            return s;
        }

        private bool ImportPreCheck()
        {

            this.SapSysName = cboxSystemList1.Text;
            if (String.IsNullOrEmpty(SapSysName))
            {
                MessageBox.Show("请选择系统");
                return false;
            }

            int selectedItems = 0;
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

            if (String.IsNullOrEmpty(this.TreeId))
            {
                var codeTree = new CodeTree();
                codeTree.Text = cboxSystemList1.Text + txtSapProgram.Text;
                if (String.IsNullOrEmpty(codeTree.Text))
                {
                    codeTree.Text = "Import SAP OBJECT " + DateTime.Now;
                }
                codeTree = db.SaveTreeNode(codeTree);
                this.TreeId = codeTree.Id;
            }

            return true;

        }

        private bool LoadObjectFromSap()
        {
            if (!ImportPreCheck())
            {
                return false;
            }

            List<Code> list = new List<Code>();
            pos.Clear();
            this.AbapCode = new SAPINT.Utils.ABAPCode(SapSysName);
            foreach (DataRow item in dt.Rows)
            {
                if (String.IsNullOrWhiteSpace(item["Select"].ToString()))
                {
                    continue;
                }
                var isSelect = (bool)item["Select"];
                if (isSelect)
                {
                    var obj = item["OBJ_NAME"].ToString();
                    if (String.IsNullOrEmpty(obj))
                    {
                        continue;
                    }
                    var codes = AbapCode.GetSourceCode(obj);
                    var sb = new StringBuilder();

                    codes.ForEach(x => sb.AppendLine(x));
                    var s = sb.ToString();
                    if (String.IsNullOrEmpty(s))
                    {
                        continue;
                    }

                    Code code = new Code();
                    code.Content = s;
                    code.Title = obj;
                    if (!String.IsNullOrEmpty(this.TreeId))
                    {
                        code.TreeId = TreeId;
                    }
                    list.Add(code);
                    var index = int.Parse(item["Index"].ToString());
                    pos.Add(index, code);
                }

            }
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


        public string SapSysName { get; set; }

        public SAPINT.Utils.ABAPCode AbapCode { get; set; }

        private void btnReadObjectFromSap_Click(object sender, EventArgs e)
        {
            try
            {
                var cell = dataGridView1.CurrentCell;
                if (cell != null && cell.Value != null)
                {
                    LoadOneObject(cell.Value.ToString());
                    MessageBox.Show("读取成功");
                }
                else
                {
                    MessageBox.Show("请选择报表名");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
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

    }
}
