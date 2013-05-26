using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAPINT.Utils;
using System.IO;
using NVelocity;
using NVelocity.App;
using SAPINTDB.CodeManager;
using SAPINTGUI.CodeManager;
using SAPINTGUI;

namespace SAPINTCODE
{
    public partial class FormAbapCode2 : DockWindow
    {
        private List<string> NVelocityKeyWordList = new List<string>();
        private List<string> ABAPKeyWordList = new List<string>();
        private string DB_NAME = null;

        DataGridViewCell dgvSelectedCell = null;
        DataGridViewRow dgvSelectedRow = null;

        CodeTmeplateManager codeManager = null;
        private CodeTemplate _codeTemplate = null;

        DataTable dt = null;

        Code _abapCode = null;
        Codedb db = new Codedb();

        private bool newTemplate = false;
        public FormAbapCode2()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            //this.sapTableField1.cbx_systemlist.DataSource = ConfigFileTool.SAPGlobalSettings.getSAPClientList();
            //this.sapTableField1.cbx_systemlist.Text = ConfigFileTool.SAPGlobalSettings.GetDefaultSapCient();
            prettyCode();
            DB_NAME = ConfigFileTool.SAPGlobalSettings.GetCodeTemplateDb();
            codeManager = new CodeTmeplateManager();
            this.textTemplate.KeyDown += textTemplate_KeyDown;
            this.textResultCode.KeyDown += textResultCode_KeyDown;
        }

        void textResultCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Control)
            {
                SaveCode();
            }
            if (e.KeyCode == Keys.N && e.Control)
            {
                CreateNewAbapCode();
            }
        }

        void textTemplate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Control)
            {
                SaveTemplate2();
            }
            if (e.KeyCode == Keys.N && e.Control)
            {
                CreateNewTemplate();
            }
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 执行ABAP代码。
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        private string ExcuteAbapCode(string Code)
        {
            SAPINT.Utils.ABAPCode abap = new SAPINT.Utils.ABAPCode(this.sapTableField1.SystemName.Trim().ToUpper());
            var result = string.Empty;
            try
            {
                result = abap.InstallAndRun(Code);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            return result;
        }

        /// <summary>
        /// 在SAP系统中执行生成的ABAP代码，并返回执行结果。
        /// </summary>
        private void ExcuteCode()
        {
            if (string.IsNullOrEmpty(this.sapTableField1.SystemName))
            {
                textResult.Document.Text = "请选择系统";
                return;
            }

            textResult.Document.Text = "";
            textResult.Document.Text = ExcuteAbapCode(this.textResultCode.Document.Text);
        }
        private void tspRunAbapCode_Click(object sender, EventArgs e)
        {
            ExcuteCode();

        }


        /// <summary>
        /// 使用模板引擎进行处理。
        /// </summary>
        private void processTemplate()
        {
            if (this.sapTableField1.TableList == null)
            {
                MessageBox.Show("没有选中的字段");
                return;
            }
            if (this.sapTableField1.TableList.Count == 0)
            {
                MessageBox.Show("没有选中的字段");
                return;
            }
            try
            {
                VelocityEngine ve = new VelocityEngine();
                ve.Init();
                VelocityContext ct = new VelocityContext();

                ct.Put("tables", this.sapTableField1.TableList);
                System.IO.StringWriter vltWriter = new System.IO.StringWriter();
                ve.Evaluate(ct, vltWriter, null, this.textTemplate.Document.Text);
                textResultCode.Document.Text = vltWriter.GetStringBuilder().ToString();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        private void tspProcessTemplate_Click(object sender, EventArgs e)
        {
            processTemplate();
        }


        private void tspGenerateCode_Click(object sender, EventArgs e)
        {
        }

        private void prettyCode()
        {
            Alsing.SourceCode.SyntaxDefinition sl = new Alsing.SourceCode.SyntaxDefinitionLoader().Load("SyntaxFiles\\abap.syn");

            this.textResultCode.Document.Parser.Init(sl);
            this.textTemplate.Document.Parser.Init(sl);

        }
        private void tspLoadSystax_Click(object sender, EventArgs e)
        {
            prettyCode();

        }

        private void btnOpenDb_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DB_NAME))
            {
                openSqliteDbfile();
                // btnOpenDb.Text = "关闭模板文件";
            }
            else
            {

                closeSqliteDbfile();
                //  btnOpenDb.Text = "打开模板文件";
            }


        }

        private void closeSqliteDbfile()
        {
            //lblconnected.Text = "Disconnected";

            //DB_NAME = string.Empty;
            //userDataGridView.DataSource = null;
            //dataAdapter = null;
            //tablecombobox.Items.Clear();
        }

        private void openSqliteDbfile()
        {
            //try
            //{
            //    DataSet ds = new DataSet();
            //    opnfiledlg.CheckPathExists = true;
            //    opnfiledlg.CheckFileExists = true;
            //    opnfiledlg.Filter = "DB Files (*.db)|*.db|All Files(*.*)|*.*";
            //    opnfiledlg.Multiselect = false;
            //    opnfiledlg.Title = "Select SQLite Database File";

            //    if (opnfiledlg.ShowDialog() == DialogResult.OK)
            //    {
            //        //Connects To SQLiteDatabase

            //      //  lblconnected.Text = "Connected";

            //        DB_NAME = opnfiledlg.FileName;

            //        reload_tables();
            //    }
            //}
            //catch (SQLiteException sqliteex)
            //{
            //    MessageBox.Show(sqliteex.Message);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void tablecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (DB_NAME == null)
            //    {
            //        MessageBox.Show("Open an existing database or Create a new database");
            //        return;
            //    }

            //    this.dataSet = new DataSet();
            //    string connString = String.Format("Data Source={0};New=False;Version=3", DB_NAME);

            //    SQLiteConnection sqlconn = new SQLiteConnection(connString);
            //    sqlconn.Open();

            //    string CommandText = String.Format("Select * from {0};", tablecombobox.Text);

            //    this.dataAdapter = new SQLiteDataAdapter(CommandText, sqlconn);
            //    SQLiteCommandBuilder builder = new SQLiteCommandBuilder(this.dataAdapter);

            //    this.dataAdapter.Fill(this.dataSet, tablecombobox.Text);

            //    userDataGridView.DataSource = this.dataSet;
            //    userDataGridView.DataMember = tablecombobox.Text;

            //}
            //catch (SQLiteException sqlex)
            //{
            //    MessageBox.Show(sqlex.Message);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        //加载数据库中所有的数据。
        private void reload_tables()
        {
            //try
            //{
            //    tablecombobox.Items.Clear();

            //    DataSet ds = new DataSet();

            //    if (DB_NAME == null)
            //    {
            //        MessageBox.Show("Open an existing database or Create a new database");
            //        return;
            //    }

            //    string connString = String.Format("Data Source={0};New=False;Version=3", DB_NAME);

            //    SQLiteConnection sqlconn = new SQLiteConnection(connString);

            //    sqlconn.Open();

            //    string CommandText = "Select name from sqlite_master;";

            //    SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(CommandText, sqlconn);
            //    dataAdapter.Fill(ds);

            //    DataRowCollection dataRowCol = ds.Tables[0].Rows;

            //    foreach (DataRow dr in dataRowCol)
            //    {
            //        tablecombobox.Items.Add(dr["name"]);
            //    }

            //    if (tablecombobox.Items.Count > 0)
            //    {
            //        tablecombobox.SelectedIndex = 0;
            //       // btnDelete.Enabled = true;
            //    }
            //    else
            //    {
            //        tablecombobox.Text = " ";
            //      //  btnDelete.Enabled = false;
            //    }

            //    sqlconn.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            return;
        }



        private void btnOpenTemplateTable_Click(object sender, EventArgs e)
        {
            //dt = new DataTable();
            //SAPINTDB.netlib7 dbhelper = new SAPINTDB.netlib7(DB_NAME);
            //dbhelper.LogEvents = true;

            //dbhelper.DataTableFill(dt, "Select * from codeTemplate");
            //this.userDataGridView.DataSource = null;
            //this.userDataGridView.DataSource = dt;

            dt = codeManager.getDt();
            this.userDataGridView.DataSource = dt;
            this.userDataGridView.AutoResizeColumns();
        }

        //private void btnUpdateTemplate_Click(object sender, EventArgs e)
        //{

        //SAPINTDB.netlib7 dbhelper = new SAPINTDB.netlib7(DB_NAME);
        //dbhelper.LogEvents = true;

        //dbhelper.DataTableUpdate(dt, "Select * from codeTemplate");
        //dt.AcceptChanges();
        //this.userDataGridView.DataSource = dt;
        //MessageBox.Show("更新成功");
        //}

        private void btnInserTemplate_Click(object sender, EventArgs e)
        {

            SaveTemplate2();
        }

        private void btnGenerateCode_Click(object sender, EventArgs e)
        {
            this.processTemplate();
        }

        private void btnExcuteCode_Click(object sender, EventArgs e)
        {
            ExcuteCode();
        }

        // SAPINTGUI.AbapCode.Codedb codedb = null;
        private void userDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }
            if (dt == null || dt.Rows.Count == 0)
            {
                return;
            }
            dgvSelectedCell = userDataGridView[e.ColumnIndex, e.RowIndex];
            dgvSelectedRow = userDataGridView.Rows[e.RowIndex];


            if (dgvSelectedRow.Cells["id"].Value != null)
            {
                int id = 0;

                int.TryParse(dgvSelectedRow.Cells["id"].Value.ToString(), out id);

                _codeTemplate = codeManager.get(id);
            }


            if (_codeTemplate == null || _codeTemplate.Id == 0)
            {
                MessageBox.Show("无法读取代码");
                return;
            }
            else
            {
                label2.Text = _codeTemplate.Id.ToString();
                textCodeDesc.Text = _codeTemplate.Desc;
            }

            try
            {
                //if (checkboxAuto.Checked == true)
                //{

                if (this.textResultCode.Focused)
                {

                    this.textResultCode.Document.Text = _codeTemplate.Content;
                }
                else
                {
                    this.textTemplate.Document.Text = _codeTemplate.Content;
                }
                //}
            }
            catch (Exception E)
            {

                MessageBox.Show(E.Message);
            }
        }

        private void userDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }
            dgvSelectedCell = userDataGridView[e.ColumnIndex, e.RowIndex];
            try
            {
                if (checkboxAuto.Checked == true)
                {
                    // this.textTemplate.Document.Text = dgvSelectedCell.Value.ToString();
                    this.userDataGridView_CellMouseDoubleClick(sender, e);
                }
            }
            catch (Exception E)
            {

                MessageBox.Show(E.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = !splitContainer1.Panel1Collapsed;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = !splitContainer1.Panel2Collapsed;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            splitContainer3.Panel1Collapsed = !splitContainer3.Panel1Collapsed;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            splitContainer3.Panel2Collapsed = !splitContainer3.Panel2Collapsed;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel1Collapsed = !splitContainer2.Panel1Collapsed;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2Collapsed = !splitContainer2.Panel2Collapsed;
        }

        private void btnSaveTemplate_Click(object sender, EventArgs e)
        {
            SaveTemplate2();
        }

        private void CreateNewTemplate()
        {
            this._codeTemplate = new CodeTemplate();
            newTemplate = true;
            this.label2.Text = "";
            this.textCodeDesc.Text = "";
            this.textTemplate.Document.Text = "";
            //var row = dt.NewRow();

            //dgvSelectedRow = userDataGridView.Rows[userDataGridView.RowCount - 1];
            // dgvSelectedRow.Selected = true;
        }
        private void btnNewTemplate_Click(object sender, EventArgs e)
        {
            CreateNewTemplate();
        }

        private void SaveTemplate2()
        {
            if (String.IsNullOrEmpty(this.textCodeDesc.Text))
            {
                MessageBox.Show("请填写代码描述");
                return;
            }
            if (_codeTemplate == null)
            {
                _codeTemplate = new CodeTemplate();
                newTemplate = true;
            }
            else
            {
                newTemplate = false;
            }

            _codeTemplate.Content = this.textTemplate.Document.Text;
            _codeTemplate.Desc = this.textCodeDesc.Text;

            _codeTemplate = codeManager.save(_codeTemplate);
            MessageBox.Show("模板保存成功: " + _codeTemplate.Desc);
            label2.Text = _codeTemplate.Id.ToString();
            textCodeDesc.Text = _codeTemplate.Desc;

            DataRow row = null;
            if (dt != null && newTemplate == true)
            {
                row = dt.NewRow();
                row["id"] = _codeTemplate.Id;
                row["Desc"] = _codeTemplate.Desc;
                dt.Rows.Add(row);
            }
            else if (dgvSelectedRow != null)
            {
                var view = dgvSelectedRow.DataBoundItem as DataRowView;
                row = view.Row;
                if (row != null)
                {
                    row["id"] = _codeTemplate.Id;
                    row["Desc"] = _codeTemplate.Desc;

                }
            }



        }
        private void SaveTemplate()
        {

            var index = -1;


            if (userDataGridView.SelectedCells[0] != null)
            {
                index = userDataGridView.SelectedCells[0].RowIndex;
            }
            if (index < 0 || _codeTemplate == null || index >= dt.Rows.Count)
            {
                _codeTemplate = new CodeTemplate();
            }
            else
            {
                int id;
                int.TryParse(userDataGridView["id", index].Value.ToString(), out id);
                _codeTemplate.Desc = userDataGridView["desc", index].Value.ToString();
                _codeTemplate.Id = id;
            }
            _codeTemplate.Content = textTemplate.Document.Text;
            _codeTemplate = codeManager.save(_codeTemplate);

            label2.Text = _codeTemplate.Id.ToString();
            textCodeDesc.Text = _codeTemplate.Desc;

            if (dt != null)
            {
                if (index >= dt.Rows.Count || index < 0)
                {
                    dt.Rows.Add(_codeTemplate.Id, _codeTemplate.Content, _codeTemplate.Desc);
                    //userDataGridView.Rows.Add(_code.Id, _code.Content, _code.Desc);
                }
                else
                {
                    dgvSelectedRow = userDataGridView.Rows[index];
                    //if (dgvSelectedRow != null)
                    //{
                    dgvSelectedRow.Cells["id"].Value = _codeTemplate.Id;
                    //  dgvSelectedRow.Cells["content"].Value = _code.Content;
                    dgvSelectedRow.Cells["Desc"].Value = _codeTemplate.Desc;
                    //}
                }
            }


            MessageBox.Show("保存成功");
        }

        private void btnDeleteTemplate_Click(object sender, EventArgs e)
        {
            if (userDataGridView.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow item in userDataGridView.SelectedRows)
                {
                    var id = item.Cells["id"].Value.ToString();
                    var intId = 0;
                    int.TryParse(id, out intId);
                    if (codeManager.deleteById(intId))
                    {
                        userDataGridView.Rows.Remove(item);
                    }


                }
            }
        }
        private void SaveCode()
        {
            if (_abapCode == null)
            {
                _abapCode = new Code();
            }
            if (string.IsNullOrEmpty(_abapCode.TreeId))
            {
                var formManager = new FormCodeManager();
                formManager.ShowDialog();
                if (formManager.SelectedTree != null)
                {
                    _abapCode.TreeId = formManager.SelectedTree.Id;
                }
                else
                {
                    return;
                }

            }
            _abapCode.Content = this.textResultCode.Document.Text;
            _abapCode.Title = this.textAbapCodeTitle.Text;
            db.SaveCode(_abapCode);
            MessageBox.Show("保存成功");
            //FormCodeEditor form = new FormCodeEditor();
            //form.code = _abapCode;
            //form.Show();
        }
        private void btnSaveCode_Click(object sender, EventArgs e)
        {
            SaveCode();

        }
        private void CreateNewAbapCode()
        {
            _abapCode = new Code();
            _abapCode.Categery = "ABAP";
            var formManager = new FormCodeManager();
            formManager.ShowDialog();
            _abapCode.TreeId = formManager.SelectedTree.Id;
            textResultCode.Document.Text = "";
        }
        private void btnNewAbapCode_Click(object sender, EventArgs e)
        {
            CreateNewAbapCode();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            splitContainer4.Panel2Collapsed = !splitContainer4.Panel2Collapsed;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            splitContainer4.Panel1Collapsed = !splitContainer4.Panel1Collapsed;
        }

        private void 保存运行结果ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textResult.Document.Text))
            {
                MessageBox.Show("结果为空");
                return;
            }
            var result = new Code();
            result.Title = "_result" + DateTime.Now.ToString();
            var frm = new FormCodeManager();
            frm.Text = "请选择文件夹";
            frm.ShowDialog();
            result.TreeId = frm.SelectedTree.Id;
            result.Content = textResult.Document.Text;
            db.SaveCode(result);
            MessageBox.Show("结果保存成功： " + result.Title);
        }

        private void 保存ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveTemplate2();
        }

        private void 新建ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateNewTemplate();
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewAbapCode();
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCode();
        }
    }

}
