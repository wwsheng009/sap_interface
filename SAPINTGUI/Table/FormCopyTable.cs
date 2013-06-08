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
namespace SAPINTGUI
{
    public delegate void SetPreviewResult(SAPINT.Function.FunctionCopyTable sender, DataTable dt);

    public partial class FormCopyTable : DockWindow
    {
        log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        String TargetSystem;
        String SourceSystem;
        String SourceTableName;
        String TargetTableName;
        String Delimeter;
        private int RowCount = 0;
        private DataTable localDt = null;
        List<String> conditionList = null;

        SAPINT.Function.FunctionCopyTable funcCopyTable;

        private bool check()
        {
            TargetSystem = textBoxTargetSystem.Text.Trim();
            TargetTableName = textBoxTargetTableName.Text.Trim();
            SourceSystem = textBoxSourceSystem.Text.Trim();
            SourceTableName = textBoxSourceTableName.Text.ToUpper().Trim();
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
                    funcCopyTable = new SAPINT.Function.FunctionCopyTable();
                    funcCopyTable.eventCopied += new delegateCopyFinished(funcCopyTable_eventReadTableDone);
                }
                funcCopyTable.SetCondition(getCondition());
                funcCopyTable.RowCount = this.RowCount;
                funcCopyTable.Delimiter = Delimeter;
                funcCopyTable.SourceSystemName = SourceSystem;
                funcCopyTable.SourceTableName = SourceTableName;
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


        private void WriteTable()
        {
            try
            {
                funcCopyTable.TargetSystemName = TargetSystem;
                funcCopyTable.TargetTableName = TargetTableName;
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
                Delimeter = txtDelimiter.Text.Trim();
                SourceSystem = textBoxSourceSystem.Text.Trim();
                SourceTableName = textBoxSourceTableName.Text.ToUpper().Trim();

                this.Text = SourceTableName;
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

        void funcCopyTable_eventReadTableDone(SAPINT.Function.FunctionCopyTable sender, DataTable result)
        {
            setResult(sender, result);
            setLog(sender, null);

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
        private void setLog(FunctionCopyTable sender, DataTable dt)
        {
            if (sender != null && sender.Message != null)
            {
                if (this.textBoxLog.InvokeRequired)
                {
                    this.Invoke(new SetPreviewResult(setLog), new object[] { sender, null });
                }
                else
                {
                    this.textBoxLog.AppendText(sender.Message);
                    this.textBoxLog.AppendText("\r\n");
                    this.textBoxLog.ScrollToCaret();
                }
            }
        }
        private void setResult(FunctionCopyTable sender, DataTable dt)
        {
            localDt = dt;
            if (dt != null)
            {
                if (this.dgvPreviewTable.InvokeRequired)
                {
                    this.Invoke(new SetPreviewResult(setResult), new object[] { sender, dt });
                }
                else
                {
                    this.dgvPreviewTable.DataSource = dt;
                    this.dgvPreviewTable.AutoResizeColumns();
                }
            }




        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            TargetSystem = this.textBoxTargetSystem.Text.Trim();
            TargetTableName = this.textBoxTargetTableName.Text.ToUpper().Trim();
            ImportDelimiter = this.cbxImportDelimiter.Text.Trim();
            funcCopyTable.ImportDelimiter = this.ImportDelimiter;
            funcCopyTable.isDelete = chkDelete.Checked;
            funcCopyTable.isInsert = chkInsert.Checked;
            funcCopyTable.isModify = chkModify.Checked;
            funcCopyTable.isUpdate = chkUpdate.Checked;

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

            saveDataTableToDataBase();

        }
        private void saveDataTableToDataBase()
        {
            if (localDt != null)
            {
                if (SourceSystem != null && SourceTableName != null)
                {
                    try
                    {
                        SapTable table = new SapTable(SourceSystem, SourceTableName, "CHAR8000");
                        table.SaveDataTable(localDt);
                        MessageBox.Show("保存成功！！！");
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                        //  throw;
                    }

                }
            }
        }



        public string ImportDelimiter { get; set; }

        public bool IsBatchRunnig { get; set; }

    }
}
