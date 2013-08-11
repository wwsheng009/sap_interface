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


    public partial class FormImportSapProgram : DockWindow
    {
        private DataTable dt = null;
        private Codedb db = new Codedb();
        public string SapSysName { get; set; }
        public SAPINT.Utils.ABAPCode AbapCode { get; set; }

        public FormImportSapProgram()
        {
            InitializeComponent();
            this.cboxSystemList1.DataSource = ConfigFileTool.SAPGlobalSettings.GetSAPClientList();
            this.cboxSystemList1.Text = ConfigFileTool.SAPGlobalSettings.GetDefaultSapCient();
            Alsing.SourceCode.SyntaxDefinition sl = new Alsing.SourceCode.SyntaxDefinitionLoader().Load("SyntaxFiles\\abap.syn");

            //this.txtObject.Text = "PROG";
            
            this.syntaxBoxControl1.Document.Parser.Init(sl);
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            this.backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            this.backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;


            // DataTable dt = null;
            dt = new DataTable("TRDIR");
            dt.Columns.AddRange(new DataColumn[]{
            new DataColumn("Index",typeof(int)),
            new DataColumn("Select",typeof(bool)),
            new DataColumn("CodeId",typeof(String)),
            new DataColumn("Header",typeof(String)),
            new DataColumn("Length",typeof(String)),
            new DataColumn("Lines",typeof(String)),
 			new DataColumn("NAME",typeof(String)),// ABAP Program Name
            //new DataColumn("PROG",typeof(String)),// ABAP 程序名
            new DataColumn("CLAS",typeof(String)),// 程序类别
            new DataColumn("SUBC",typeof(String)),//   程序类型
            new DataColumn("APPL",typeof(String)),// 应用程序
            new DataColumn("CDAT",typeof(String)),// 创建日期
            new DataColumn("VERN",typeof(String)),// 版本号
            new DataColumn("RMAND",typeof(String)),// 集团
            new DataColumn("RLOAD",typeof(String)),// 主语言
            new DataColumn("UNAM",typeof(String)),// 最后修改人
            new DataColumn("UDAT",typeof(String)),// 更改日期
            new DataColumn("UTIME",typeof(String)),// 字典: 最后修改时间
            new DataColumn("DATALG",typeof(Int32)),// ABAP/4： 程序组件的长度
            new DataColumn("VARCL",typeof(String)),// 区分大小写
         });
            // dt.Columns["Index"].AutoIncrement = true;
            dt.Columns["Select"].DefaultValue = false;
            this.dataGridView1.DataSource = dt;
            this.dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            this.dataGridView1.CurrentCellChanged += dataGridView1_CurrentCellChanged;

        }

        void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // throw new NotImplementedException();
            MessageBox.Show("处理完成");
        }

        void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //  throw new NotImplementedException();
            progressBar1.Value = (int)e.ProgressPercentage;
            ImportMessage m = e.UserState as ImportMessage;

            this.txtCurrentProg.Text = m.progName;
            this.txtProgress.Text = m.current + "/" + m.total;
        }

        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            Form form = e.Argument as Form;



            LoadObjectFromSap(bw);


            //throw new NotImplementedException();
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
                            var arr = x.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                            dataGridView1["Header", e.RowIndex].Value = x;
                            dataGridView1["Lines", e.RowIndex].Value = arr.Count();
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
                var list = abap.SearchProgram(this.txtSapProgram.Text,this.txtObject.Text,this.txtDevClass.Text);
                //list.ForEach(x => { });
                int index = 0;
                foreach (var item in list)
                {
                    var r = dt.NewRow();
                    r["Index"] = index;
                    index++;
                    r["NAME"] = item.prog;// ABAP Program Name
                    //r["PROG"] = item.prog;// ABAP 程序名
                    r["CLAS"] = item.clas;// 程序类别
                    r["SUBC"] = item.subc;//   程序类型
                    r["APPL"] = item.appl;// 应用程序
                    r["CDAT"] = item.cdat;// 创建日期
                    r["VERN"] = item.vern;// 版本号
                    r["RMAND"] = item.rmand;// 集团
                    r["RLOAD"] = item.rload;// 主语言
                    r["UNAM"] = item.unam;// 最后修改人
                    r["UDAT"] = item.udat;// 更改日期
                    r["UTIME"] = item.utime;// 字典: 最后修改时间
                    r["DATALG"] = item.datalg;// ABAP/4： 程序组件的长度
                    r["VARCL"] = item.varcl;// 区分大小写
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
                if (!ImportPreCheck())
                {
                    return;
                }


                if (String.IsNullOrEmpty(this.TreeId))
                {
                    var codeTree = new CodeFolder();
                    codeTree.Text = cboxSystemList1.Text + txtSapProgram.Text;
                    if (String.IsNullOrEmpty(codeTree.Text))
                    {
                        codeTree.Text = "Imported_SAP_OBJECT " + DateTime.Now;
                    }
                    codeTree = db.SaveTree(codeTree);
                    this.TreeId = codeTree.Id;
                }

                this.progressBar1.Value = 0;
                this.progressBar1.Maximum = selectedItems;

                //  backgroundWorker1.RunWorkerAsync();
                this.backgroundWorker1.RunWorkerAsync(this);
                //if ()
                //{
                //    MessageBox.Show("导入完成");
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
        private int selectedItems = 0;

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
                    MessageBox.Show("请选择!");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            return false;
        }



        private bool LoadObjectFromSap(BackgroundWorker bw, bool Saved = true)
        {

            List<Code> list = new List<Code>();
            Dictionary<int, Code> pos = new Dictionary<int, Code>();
            this.AbapCode = new SAPINT.Utils.ABAPCode(SapSysName);
            var itemCount = 0;
            var processed = 0;

            var m_isCacelling = false;

            foreach (DataRow item in dt.Rows)
            {

                if (this.backgroundWorker1.CancellationPending)
                {
                    m_isCacelling = true;
                }
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
                    item["Lines"] = codes.Count;


                    var abapCode = sb.ToString();
                    item["Length"] = Util.FileUtil.FormatFileSize(abapCode.Length);
                    item["Header"] = abapCode;

                    if (String.IsNullOrEmpty(abapCode))
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

                    code.Content = abapCode;
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
                    //每100行保存一次
                    itemCount++;
                    if (itemCount == 100 && dt.Rows.Count >= 100 && m_isCacelling == false)
                    {
                        if (true == Saved)
                        {
                            db.SaveCodeList(list);


                        }
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
                        if (true == Saved)
                        {
                            db.SaveCodeList(list);

                        }

                        foreach (var positem in pos)
                        {
                            dt.Rows[positem.Key]["CodeId"] = positem.Value.Id;
                            dt.Rows[positem.Key]["Select"] = false;
                        }
                        pos.Clear();
                        list.Clear();
                        itemCount = 0;
                    }
                    processed++;
                    ImportMessage m = new ImportMessage() { current = processed, total = selectedItems, progName = obj };
                    bw.ReportProgress(processed, m);
                    //如果要取消,保存后退出.
                    if (m_isCacelling == true)
                    {
                        break;
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


        class ImportMessage
        {
            public int total;
            public int current;
            public string progName;
        }

        private void btnCancelImport_Click(object sender, EventArgs e)
        {
            this.backgroundWorker1.CancelAsync();
        }
    }
}
