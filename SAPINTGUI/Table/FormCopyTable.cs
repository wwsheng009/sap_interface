using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using SAPINT.Function;
using SAPINTDB;
using SAPINT.RFCTable;
using SAPINT.Function.CopyTable;
using System.IO;


namespace SAPINT.Gui
{
    public delegate void SetPreviewResult(FunctionCopyTable sender, List<CopyTableField> fields, List<String> dt);

    public partial class FormCopyTable : DockWindow
    {
        log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        String TargetSystem;
        String SourceSystem;
        String SourceTableName;
        String TargetTableName;
        String Delimeter;
        private int RowCount = 0;


        private List<string> DataList = null;
        List<String> conditionList = null;
        List<CopyTableField> fieldsList = null;

        FunctionCopyTable funcCopyTable;

        private DataTable dt = null;

        private OperationType readOperation = OperationType.read;
        private OperationType writeOperation = OperationType.write;


        public FormCopyTable()
        {
            InitializeComponent();
            conditionList = new List<string>();
            textBoxSourceSystem.Items.Clear();
            textBoxTargetSystem.Items.Clear();
            SAPINT.SAPLogonConfigList.SystemNameList.ForEach(item => { textBoxSourceSystem.Items.Add(item); });
            SAPINT.SAPLogonConfigList.SystemNameList.ForEach(item => { textBoxTargetSystem.Items.Add(item); });
            //textBoxSourceSystem.DataSource = SAPINT.SAPConfigList.SystemNameList;
            //textBoxTargetSystem.DataSource = SAPINT.SAPConfigList.SystemNameList;

            dt = new DataTable();
            dt.Columns.Add(new DataColumn() { ColumnName = "FIELD", DataType = typeof(String) });
            this.dgvPreviewTable.DataSource = dt;

            CDataGridViewUtils.CopyPasteDataGridView(this.dgvPreviewTable);
        }



        private bool check()
        {
            this.TargetSystem = textBoxTargetSystem.Text.Trim();
            this.TargetTableName = textBoxTargetTableName.Text.Trim();
            this.SourceSystem = textBoxSourceSystem.Text.Trim();
            this.SourceTableName = textBoxSourceTableName.Text.ToUpper().Trim();

            this.ImportDelimiter = cbxImportDelimiter.Text;
            this.Delimeter = cbxDelimiter.Text;

            if (String.IsNullOrWhiteSpace(textBoxTargetTableName.Text))
            {
                this.TargetTableName = SourceTableName;

            }
            int _rowCount = 0;
            int.TryParse(txtRowCount.Text.Trim(), out _rowCount);
            RowCount = _rowCount;
            if (string.IsNullOrWhiteSpace(TargetSystem))
            {
                MessageBox.Show("目标系统为空！！");
                return false;
            }
            if (string.IsNullOrWhiteSpace(SourceSystem))
            {
                MessageBox.Show("源系统不能为空！！");
                return false;
            }
            if (string.IsNullOrWhiteSpace(SourceTableName))
            {
                MessageBox.Show("表名不能为空！！");
                return false;
            }

            if (string.IsNullOrWhiteSpace(TargetTableName))
            {
                MessageBox.Show("表名不能为空！！");
                return false;
            }
            return true;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (check())
            {
                try
                {
                    Thread thread = new Thread(batchRun);
                    thread.Start();
                }
                catch (Exception ee)
                {
                    this.textBoxLog.AppendText(ee.Message);
                    this.textBoxLog.AppendText("\r\n");

                    MessageBox.Show(ee.Message);


                }
            }

        }

        private List<String> getCondition()
        {
            conditionList.Clear();
            for (int i = 0; i < dgvConditioin.Rows.Count; i++)
            {
                if (dgvConditioin[0, i].Value != null)
                {
                    string s = dgvConditioin[0, i].Value.ToString();
                    if (!string.IsNullOrEmpty(s))
                    {
                        conditionList.Add(s);
                    }
                }
            }
            return conditionList;
        }
        private void btnBatchInput_Click(object sender, EventArgs e)
        {
            if (!check())
            {
                return;
            }
            IsBatchRunnig = true;

            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (item.Cells["dgvTableName"].Value != null)
                {
                    String table = item.Cells["dgvTableName"].Value.ToString();
                    //String result = "";
                    //if (item.Cells["dgvResult"].Value != null)
                    //{
                    //    result = item.Cells["dgvResult"].Value.ToString();
                    //}
                    //if (result == "Copied")
                    //{
                    //    continue;
                    //}
                    if (!String.IsNullOrWhiteSpace(table))
                    {
                        SourceTableName = table;
                        TargetTableName = table;
                        readOperation = OperationType.direct;
                        writeOperation = OperationType.direct;
                        try
                        {
                            //batchRun();
                            Thread thread = new Thread(batchRun);
                            thread.Start();
                        }
                        catch (Exception ee)
                        {
                            IsBatchRunnig = false;
                            log.Error(ee.Message);
                            this.textBoxLog.AppendText(ee.Message + "\r\n");
                        }
                    }
                }
            }
            IsBatchRunnig = false;
        }
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Modifiers == Keys.Control)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.C:
                            CDataGridViewUtils.CopyToClipboard(dataGridView1);
                            break;
                        case Keys.V:
                            // PasteClipboardValue(dgvBatchInput  ,false);
                            CDataGridViewUtils.Paste(dataGridView1, "", 0, false);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Copy/paste operation failed. " + ex.Message, "Copy/Paste", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvConditioin_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Modifiers == Keys.Control)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.C:
                            CDataGridViewUtils.CopyToClipboard(dgvConditioin);
                            break;
                        case Keys.V:
                            // PasteClipboardValue(dgvBatchInput  ,false);
                            CDataGridViewUtils.Paste(dgvConditioin, "", 0, false);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Copy/paste operation failed. " + ex.Message, "Copy/Paste", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void batchRun()
        {
            this.readOperation = OperationType.direct;
            this.writeOperation = OperationType.direct;


            ReadTable();
            WriteTable();
        }
        private void ReadTable()
        {
            try
            {
                int.TryParse(txtRowCount.Text.Trim(), out this.RowCount);


                if (funcCopyTable == null)
                {
                    funcCopyTable = new FunctionCopyTable();
                    funcCopyTable.EventCopied += new DelegateCopyFinished(funcCopyTable_eventReadTableDone);
                }
                funcCopyTable.readOperation = this.readOperation;
                
                funcCopyTable.Conditions = getCondition();
                funcCopyTable.Fields = getFields();
                funcCopyTable.RowCount = this.RowCount;
                funcCopyTable.Delimiter = Delimeter;
                
                funcCopyTable.SourceSystemName = SourceSystem;
                funcCopyTable.SourceTableName = SourceTableName;
                funcCopyTable.readOperation = this.readOperation;
                funcCopyTable.ReadTable();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                //this.textBoxLog.AppendText(ex.Message);
                //this.textBoxLog.AppendText("\r\n");
                //this.textBoxLog.ScrollToCaret();
                if (!IsBatchRunnig)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private List<CopyTableField> getFields()
        {
            fieldsList = new List<CopyTableField>();
            //fieldsList.Clear();
            for (int i = 0; i < this.dgvFields.Rows.Count; i++)
            {
                if (dgvFields[0, i].Value != null)
                {
                    int offset = 0;
                    int length = 0;
                    string s = dgvFields[0, i].Value.ToString();

                    int.TryParse(dgvFields[1, i].Value.ToString(), out offset);
                    int.TryParse(dgvFields[2, i].Value.ToString(), out length);
                    if (!string.IsNullOrEmpty(s))
                    {
                        var field = new CopyTableField();
                        field.FieldName = s;
                        field.Length = length;
                        field.Offset = offset;
                        fieldsList.Add(field);
                    }
                }
            }


            return fieldsList;
        }

        private List<String> getData()
        {
            this.DataList = new List<string>();
            //this.DataList.Clear();
            for (int i = 0; i < this.dgvPreviewTable.Rows.Count; i++)
            {
                if (dgvPreviewTable[0, i].Value != null)
                {
                    string s = dgvPreviewTable[0, i].Value.ToString();
                    if (!string.IsNullOrEmpty(s))
                    {


                        DataList.Add(s);
                    }
                }
            }


            return DataList;
        }


        private void WriteTable()
        {
            try
            {
                if (this.funcCopyTable == null)
                {
                    this.funcCopyTable = new FunctionCopyTable();
                }
                
                this.funcCopyTable.ImportDelimiter = this.ImportDelimiter;

                this.funcCopyTable.writeOperation = OperationType.write;

                this.funcCopyTable.TargetSystemName = this.TargetSystem;
                this.funcCopyTable.TargetTableName = this.TargetTableName;
                this.funcCopyTable.Fields = this.getFields();
                this.funcCopyTable.writeOperation = this.writeOperation;
                this.funcCopyTable.ExchangeData = this.getData();
                this.funcCopyTable.isDelete = chkDelete.Checked;
                this.funcCopyTable.isInsert = chkInsert.Checked;
                this.funcCopyTable.isModify = chkModify.Checked;
                this.funcCopyTable.isUpdate = chkUpdate.Checked;

                //funcCopyTable.TargetSystemName = this.TargetSystem;
                //funcCopyTable.TargetTableName = this.TargetTableName;
                funcCopyTable.WriteTable();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                //this.textBoxLog.AppendText(ex.Message);
                //this.textBoxLog.AppendText("\r\n");
                //this.textBoxLog.ScrollToCaret();
                if (!IsBatchRunnig)
                {
                    MessageBox.Show(ex.Message);
                }
                //throw new Exception(ex.Message);
            }


        }
        private void btnReadTable_Click(object sender, EventArgs e)
        {
            try
            {
                Delimeter = cbxDelimiter.Text.Trim();
                SourceSystem = textBoxSourceSystem.Text.Trim();
                SourceTableName = textBoxSourceTableName.Text.ToUpper().Trim();

                this.readOperation = OperationType.read;
                this.dt.Clear();
                this.Text = SourceTableName;
                this.textBoxLog.AppendText("开始读取数据\r\n");
                Thread thread = new Thread(ReadTable);
                thread.Start();
            }
            catch (Exception ee)
            {
                this.textBoxLog.AppendText(ee.Message);
                this.textBoxLog.AppendText("\r\n");
                this.textBoxLog.ScrollToCaret();
                //  MessageBox.Show(ee.Message);
            }


        }

        void funcCopyTable_eventReadTableDone(FunctionCopyTable sender, List<CopyTableField> fields, List<String> result)
        {
            if (this.readOperation != OperationType.direct)
            {
                setResult(sender, fields, result);
            }

            setLog(sender, null, null);

            //if (this.dgvPreviewTable.InvokeRequired)
            //{
            //
            //    SetPreviewResult e = new SetPreviewResult(setResult);
            //    BeginInvoke(e, new object[] { result });
            //   // e.BeginInvoke(result,setResult,"");
            //   // IAsyncResult re = e.BeginInvoke(result, "", "");
            //}
            //  MessageBox.Show("读取完毕！");

        }
        private void setLog(FunctionCopyTable sender, List<CopyTableField> fields, List<String> dt)
        {
            if (sender != null && sender.Message != null)
            {
                if (this.textBoxLog.InvokeRequired)
                {
                    this.Invoke(new SetPreviewResult(setLog), new object[] { sender, null, null });
                }
                else
                {
                    this.textBoxLog.AppendText(sender.Message);
                    this.textBoxLog.AppendText("\r\n");
                    this.textBoxLog.ScrollToCaret();
                }
            }
        }
        private void setResult(FunctionCopyTable sender, List<CopyTableField> fields, List<String> data)
        {
            DataList = data;
            if (data != null)
            {
                if (this.dgvPreviewTable.InvokeRequired)
                {
                    this.Invoke(new SetPreviewResult(setResult), new object[] { sender, fields, data });
                }
                else
                {
                    this.dt.Rows.Clear();
                    foreach (var item in data)
                    {
                        this.dt.Rows.Add(item);
                    }

                    this.dgvPreviewTable.DataSource = dt;

                    this.dgvPreviewTable.AutoResizeColumns();

                    this.dgvFields.Rows.Clear();
                    foreach (var item in fields)
                    {
                        this.dgvFields.Rows.Add(item.FieldName, item.Offset, item.Length);
                    }
                }
            }




        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            TargetSystem = this.textBoxTargetSystem.Text.Trim();
            TargetTableName = this.textBoxTargetTableName.Text.ToUpper().Trim();
            ImportDelimiter = this.cbxImportDelimiter.Text.Trim();
            this.writeOperation = OperationType.write;

            try
            {
                if (funcCopyTable != null)
                {

                    // ThreadStart threadStart = new ThreadStart(ReadTable);
                    Thread thread = new Thread(WriteTable);
                    thread.Start();
                }
                else
                {
                    MessageBox.Show("请首先读取数据！");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }


        private void btnSaveToDataBase_Click(object sender, EventArgs e)
        {

            //saveDataTableToDataBase();
            ShowSaveDataTableDialog();
        }

        private void ShowSaveDataTableDialog()
        {
            SAPINT.Gui.DataBase.FormSaveDataTable formSaveDt = new DataBase.FormSaveDataTable();
            formSaveDt.Dt = this.dt;
            formSaveDt.SapSystemName = SourceSystem;
            formSaveDt.SapTableName = SourceTableName;

            formSaveDt.Show();
        }

        private void saveDataTableToDataBase()
        {
            if (this.dt != null)
            {
                if (SourceSystem != null && SourceTableName != null)
                {
                    try
                    {
                        SapTable table = new SapTable(SourceSystem, SourceTableName, "CHAR8000");
                        table.EventLogMessage += table_EventLogMessage;
                        if (table.SaveDataTable(this.dt) == true)
                        {
                            MessageBox.Show("保存成功！！！");
                        }
                        else
                        {
                            MessageBox.Show("保存失败！！！");
                        }



                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                        //  throw;
                    }

                }
            }
        }

        void table_EventLogMessage(string message)
        {
            this.textBoxLog.AppendText(message);
            this.textBoxLog.AppendText("\r\n");
            this.textBoxLog.ScrollToCaret();
            //throw new NotImplementedException();
        }



        public string ImportDelimiter { get; set; }

        public bool IsBatchRunnig { get; set; }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {

            loadDataToColumnOne();
        }
        private void loadDataToColumnOne()
        {
            try
            {
                this.dt.Clear();

                var ldt = this.dgvPreviewTable.DataSource as DataTable;
                if (ldt == null)
                {
                    MessageBox.Show("请先选择表");
                    return;
                }
                else if (ldt.Columns.Count == 0)
                {
                    MessageBox.Show("DT没有列");
                    return;
                }
                OpenFileDialog openFile = new OpenFileDialog();

                openFile.InitialDirectory = Application.ExecutablePath;
                openFile.Filter = "txt files (*.txt)|csv files(*.csv)|All files (*.*)|*.*";
                openFile.FilterIndex = 1;
                openFile.RestoreDirectory = true;
                openFile.Multiselect = false;

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    string fullName = openFile.FileName;


                    FileInfo filein = new FileInfo(fullName);
                    if (!filein.Exists)
                    {
                        MessageBox.Show("没有文件");
                        return;
                    }
                    // FileStream file = File.OpenRead(fullName);

                    //StreamReader sr = new StreamReader(fullName, Encoding.Default);
                    //String s = sr.ReadToEnd();
                    //string[] xx = s.Split(new string[] { "\r\n" }, StringSplitOptions.None);


                    //foreach (var item in xx)
                    //{
                    //    dt.Rows.Add(item);

                    //}
                    StreamReader sr = new StreamReader(fullName, Encoding.Default);
                    string strLine = null;
                    while ((strLine = sr.ReadLine()) != null)
                    {
                        ldt.Rows.Add(strLine);
                        //MessageBox.Show(strLine);
                    }



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            SaveDataToFile();
        }

        private void SaveDataToFile()
        {
            try
            {
                var dt = this.dgvPreviewTable.DataSource as DataTable;
                if (dt == null)
                {
                    MessageBox.Show("请先选择表");
                    return;
                }
                else if (dt.Columns.Count == 0)
                {
                    MessageBox.Show("DT没有列");
                    return;
                }

                SaveFileDialog saveFile = new SaveFileDialog();

                saveFile.InitialDirectory = Application.ExecutablePath;
                saveFile.Filter = "txt files (*.txt)|csv files(*.csv)|All files (*.*)|*.*";
                saveFile.FilterIndex = 1;
                saveFile.RestoreDirectory = true;


                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    string fullName = saveFile.FileName;


                    //FileInfo filein = new FileInfo(fullName);
                    //if (!filein.Exists)
                    //{
                    //    MessageBox.Show("没有文件");
                    //    return;
                    //}
                    // FileStream file = File.OpenRead(fullName);

                    //StreamReader sr = new StreamReader(fullName, Encoding.Default);
                    //String s = sr.ReadToEnd();
                    //string[] xx = s.Split(new string[] { "\r\n" }, StringSplitOptions.None);


                    //foreach (var item in xx)
                    //{
                    //    dt.Rows.Add(item);

                    //}
                    //StreamReader sr = new StreamReader(fullName, Encoding.Default);
                    //string strLine = null;
                    StreamWriter sw = new StreamWriter(fullName, false, Encoding.Default);
                    foreach (DataRow item in dt.Rows)
                    {
                        sw.WriteLine(item[0]);
                    }
                    sw.Close();
                    MessageBox.Show("写入完毕");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
