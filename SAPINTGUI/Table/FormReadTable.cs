using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DgvFilterPopup;
using SAPINTDB;
using SAPINT.Utils;
using SAPINT.RFCTable;
using WeifenLuo.WinFormsUI.Docking;

namespace SAPINTGUI
{
    public partial class FormReadTable : DockWindow
    {
        DataTable localdt = null;
        String SystemName = null;
        String TableName = null;

        public FormReadTable()
        {
            InitializeComponent();
            this.readTableControl1.EventMessage += readTableControl1_EventMessage;
            this.readTableControl1.EventGetTable += readTableControl1_EventGetTable;

            DgvFilterManager fm = new DgvFilterManager();
            fm.ColumnFilterAdding += fm_ColumnFilterAdding;
            fm.DataGridView = dataGridView1;

            this.textboxLog.KeyDown += textboxLog_KeyDown;
        }

        void textboxLog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control == true)
            {
                this.textboxLog.SelectAll();
            }
            //throw new NotImplementedException();
        }

        void readTableControl1_EventGetTable(ReadTableControl sender, DataTable resultdt)
        {
            if (resultdt == null)
            {
                return;
            }
            localdt = resultdt;
            this.SystemName = sender.SystemName;
            this.TableName = sender.TableName;
            this.Text = "表：" + TableName;
            if (this.dataGridView1.InvokeRequired)
            {
                this.Invoke(new EventGetSAPTable(readTableControl1_EventGetTable), new object[] { sender, resultdt });
            }
            else
            {
                if (chxNotShow.Checked)
                {

                }
                else
                {
                    this.dataGridView1.DataSource = resultdt;
                    this.dataGridView1.AutoResizeColumns();
                }


            }
        }

        void readTableControl1_EventMessage(string message)
        {
            if (this.textboxLog.InvokeRequired)
            {
                this.Invoke(new delegateMessage(readTableControl1_EventMessage), new object[] { message });
            }
            else
            {
                var m = DateTime.Now.ToLocalTime() + "==>" + message + "\r\n";
                this.textboxLog.AppendText(m);
            }
        }

        void fm_ColumnFilterAdding(object sender, ColumnFilterEventArgs e)
        {
            e.ColumnFilter = new DgvComboBoxColumnFilter();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // readTableControl1.
        }

        private void btnSaveToDb_Click(object sender, EventArgs e)
        {
            // saveDataTableToDataBase();
            ShowSaveDataTableDialog();
        }
        private void ShowSaveDataTableDialog()
        {
            SAPINTGUI.DataBase.FormSaveDataTable formSaveDt = new DataBase.FormSaveDataTable();
            formSaveDt.Dt = localdt;
            formSaveDt.SapSystemName = SystemName;
            formSaveDt.SapTableName = TableName;

            formSaveDt.Show();
        }
        private void saveDataTableToDataBase()
        {
            if (localdt != null)
            {
                if (TableName != null && SystemName != null)
                {
                    try
                    {
                        SapTable table = new SapTable(SystemName, TableName);
                        if (table.saveDataTable(localdt))
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
    }
}
