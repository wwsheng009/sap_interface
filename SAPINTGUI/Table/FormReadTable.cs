using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAPINTDB;
namespace SAPINTGUI
{
    public partial class FormReadTable : Form
    {
        DataTable localdt = null;
        String SystemName = null;
        String TableName = null;

        public FormReadTable()
        {
            InitializeComponent();
            readTableControl1.eventGetTable += new GetSAPTable(readTableControl1_eventGetTable);
        }

        void readTableControl1_eventGetTable(ReadTableControl sender, DataTable resultdt)
        {
            this.SystemName = sender.SystemName;
            this.TableName = sender.TableName;

            if (resultdt != null)
            {
                localdt = resultdt;
                this.dataGridView1.DataSource = resultdt;
                this.dataGridView1.AutoResizeColumns();
            }
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
