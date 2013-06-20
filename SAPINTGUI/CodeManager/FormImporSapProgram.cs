using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SAPINTDB;
using SAPINTDB.CodeManager;

namespace SAPINT.Gui.CodeManager
{
    public partial class FormImporSapProgram : DockWindow
    {
        private DataTable dt = null;
        private Codedb db = new Codedb();
        public string SapSysName { get; set; }
        public SAPINT.Utils.ABAPCode AbapCode { get; set; }

        public FormImporSapProgram()
        {
            InitializeComponent();
            this.cboxSystemList1.DataSource = ConfigFileTool.SAPGlobalSettings.GetSAPClientList();
            this.cboxSystemList1.Text = ConfigFileTool.SAPGlobalSettings.GetDefaultSapCient();
            Alsing.SourceCode.SyntaxDefinition sl = new Alsing.SourceCode.SyntaxDefinitionLoader().Load("SyntaxFiles\\abap.syn");

            this.syntaxBoxControl1.Document.Parser.Init(sl);

            // DataTable dt = null;
            dt = new DataTable("TRDIR");
            dt.Columns.AddRange(new DataColumn[]{
            new DataColumn("Index",typeof(int)),
            new DataColumn("Select",typeof(bool)),
            new DataColumn("CodeId",typeof(String)),
            new DataColumn("Header",typeof(String)),
            new DataColumn("Length",typeof(String)),
 			new DataColumn("NAME",typeof(String)),// ABAP Program Name
    		new DataColumn("SQLX",typeof(String)),// Source code protection
    		new DataColumn("EDTX",typeof(String)),// Editor lock flag
    		new DataColumn("VARCL",typeof(String)),// Case-Sensitive
    		new DataColumn("DBAPL",typeof(String)),// Application database
    		new DataColumn("DBNA",typeof(String)),// Logical database
    		new DataColumn("CLAS",typeof(String)),// Program class
    		new DataColumn("TYPE",typeof(String)),// Selection screen version
    		new DataColumn("OCCURS",typeof(String)),// Automatically generated program
    		new DataColumn("SUBC",typeof(String)),// Program type
    		new DataColumn("APPL",typeof(String)),// Application
    		new DataColumn("SECU",typeof(String)),// Authorization Group
    		new DataColumn("CNAM",typeof(String)),// Author
    		new DataColumn("CDAT",typeof(String)),// Created on
    		new DataColumn("UNAM",typeof(String)),// Last changed by
    		new DataColumn("UDAT",typeof(String)),// Changed On
    		new DataColumn("VERN",typeof(String)),// Version number
    		new DataColumn("LEVL",typeof(String)),// Level
    		new DataColumn("RSTAT",typeof(String)),// Status
    		new DataColumn("RMAND",typeof(String)),// Client
    		new DataColumn("RLOAD",typeof(String)),// Master Language
    		new DataColumn("FIXPT",typeof(String)),// Fixed point arithmetic
    		new DataColumn("SSET",typeof(String)),// Start only via variant
    		new DataColumn("SDATE",typeof(String)),// Standard selection screen generation: Date
    		new DataColumn("STIME",typeof(String)),// Standard selection screen generation: Time
    		new DataColumn("IDATE",typeof(String)),// Selection screen generation: Date
    		new DataColumn("ITIME",typeof(String)),// Selection screen generation: Time
    		new DataColumn("LDBNAME",typeof(String)),// LDB name
    		new DataColumn("UCCHECK",typeof(String)),// Flag, if unicode check was performed
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
            try
            {
                if (e.ColumnIndex < 0 || e.RowIndex < 0)
                {
                    return;
                }
                var cell = dataGridView1[e.ColumnIndex, e.RowIndex];
                var cell2 = dataGridView1["NAME", e.RowIndex];
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
                        else if (dt.Columns[e.ColumnIndex].ColumnName == "NAME")
                        {
                            var x = LoadOneObject(cell.Value.ToString());
                            dataGridView1["Header", e.RowIndex].Value = x;
                            dataGridView1["Length", e.RowIndex].Value = Util.FileUtil.FormatFileSize(x.Length);
                            this.syntaxBoxControl1.Document.Text = x;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
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
            
            try
            {
                dt.Clear();
                this.SapSysName = this.cboxSystemList1.Text.Trim().ToUpper();
                SAPINT.Utils.ABAPCode abap = new SAPINT.Utils.ABAPCode(SapSysName);
                var list = abap.SearchProgram(this.txtSapProgram.Text);
                //list.ForEach(x => { });
                int index = 0;
                foreach (var item in list)
                {
                    var r = dt.NewRow();
                    r["Index"] = index;
                    index++;
                    r["NAME"] = item.name;// ABAP Program Name
                    r["SQLX"] = item.sqlx;// Source code protection
                    r["EDTX"] = item.edtx;// Editor lock flag
                    r["VARCL"] = item.varcl;// Case-Sensitive
                    r["DBAPL"] = item.dbapl;// Application database
                    r["DBNA"] = item.dbna;// Logical database
                    r["CLAS"] = item.clas;// Program class
                    r["TYPE"] = item.type;// Selection screen version
                    r["OCCURS"] = item.occurs;// Automatically generated program
                    r["SUBC"] = item.subc;// Program type
                    r["APPL"] = item.appl;// Application
                    r["SECU"] = item.secu;// Authorization Group
                    r["CNAM"] = item.cnam;// Author
                    r["CDAT"] = item.cdat;// Created on
                    r["UNAM"] = item.unam;// Last changed by
                    r["UDAT"] = item.udat;// Changed On
                    r["VERN"] = item.vern;// Version number
                    r["LEVL"] = item.levl;// Level
                    r["RSTAT"] = item.rstat;// Status
                    r["RMAND"] = item.rmand;// Client
                    r["RLOAD"] = item.rload;// Master Language
                    r["FIXPT"] = item.fixpt;// Fixed point arithmetic
                    r["SSET"] = item.sset;// Start only via variant
                    r["SDATE"] = item.sdate;// Standard selection screen generation: Date
                    r["STIME"] = item.stime;// Standard selection screen generation: Time
                    r["IDATE"] = item.idate;// Selection screen generation: Date
                    r["ITIME"] = item.itime;// Selection screen generation: Time
                    r["LDBNAME"] = item.ldbname;// LDB name
                    r["UCCHECK"] = item.uccheck;// Flag, if unicode check was performed
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
            try
            {
                this.SapSysName = cboxSystemList1.Text;
                if (String.IsNullOrEmpty(SapSysName))
                {
                    MessageBox.Show("请选择系统");
                    return string.Empty;
                }
                else
                {

                    this.AbapCode = new SAPINT.Utils.ABAPCode(SapSysName);
                    var codes = AbapCode.GetSourceCode(obj);
                    var sb = new StringBuilder();

                    codes.ForEach(x => sb.AppendLine(x));
                    var s = sb.ToString();
                    //   this.syntaxBoxControl1.Document.Text = s;
                    return s;

                }
            }


            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return string.Empty;

        }

        private bool ImportPreCheck()
        {
            try
            {
                this.SapSysName = cboxSystemList1.Text;
                this.pauseTime = int.Parse(this.numPauseTime.Value.ToString());

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
                    var codeTree = new CodeFolder();
                    codeTree.Text = cboxSystemList1.Text + txtSapProgram.Text;
                    if (String.IsNullOrEmpty(codeTree.Text))
                    {
                        codeTree.Text = "Import SAP OBJECT " + DateTime.Now;
                    }
                    codeTree = db.SaveTree(codeTree);
                    this.TreeId = codeTree.Id;
                }

                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            return false;
        }

        private bool LoadObjectFromSap()
        {
            if (!ImportPreCheck())
            {
                return false;
            }

            List<Code> list = new List<Code>();
            Dictionary<int, Code> pos = new Dictionary<int, Code>();
            this.AbapCode = new SAPINT.Utils.ABAPCode(SapSysName);
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
                    var obj = item["NAME"].ToString();
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
                    var comments = new StringBuilder();
                    foreach (var comment in codes)
                    {
                        if (comment.StartsWith("*"))
                        {
                            comments.AppendLine(comment);
                        }
                        if (comments.ToString().ToList().Count > 10)
                        {
                            break;
                        }
                    }
                    Code code = new Code();
                    code.Content = s;
                    code.Desc = comments.ToString();
                    code.Title = obj;
                    if (!String.IsNullOrEmpty(this.TreeId))
                    {
                        code.TreeId = TreeId;
                    }
                    list.Add(code);
                    var index = int.Parse(item["Index"].ToString());
                    pos.Add(index, code);
                    var pTime = new System.TimeSpan(pauseTime);
                    Thread.Sleep(pTime);//必须暂停，因为在SAP系统中读取程序不会那么快。
                    //每50行保存一次
                    itemCount++;
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
                    else
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
            return true;
            //if (db.SaveCodeList(list))
            //{
            //    foreach (var item in pos)
            //    {
            //        dt.Rows[item.Key]["CodeId"] = item.Value.Id;
            //    }
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}


        }


        private void btnReadObjectFromSap_Click(object sender, EventArgs e)
        {
            try
            {
                var cell = dataGridView1.CurrentCell;
                String objectName = string.Empty;

                if (cell != null && cell.Value != null)
                {
                    objectName = cell.Value.ToString();
                }
                else
                {
                    objectName = this.txtSapProgram.Text;
                }
                if (String.IsNullOrEmpty(objectName))
                {
                    MessageBox.Show("请选择报表名");
                }
                else
                {
                    var x = LoadOneObject(objectName);
                    this.syntaxBoxControl1.Document.Text = x;

                    //if (String.IsNullOrEmpty(x))
                    //{
                    //    MessageBox.Show("读取失败");
                    //}
                    //else
                    //{
                    //    MessageBox.Show("读取成功");
                    //}
                    MessageBox.Show("读取完成");
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

        private void button5_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = !splitContainer1.Panel1Collapsed;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = !splitContainer1.Panel2Collapsed;
        }


        public int pauseTime { get; set; }
    }
}
