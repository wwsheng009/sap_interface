using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DgvFilterPopup;
using WeifenLuo.WinFormsUI.Docking;
namespace SAPINTGUI
{
    public partial class FormGetTableMeta : DockWindow
    {
        public FormGetTableMeta()
        {
            InitializeComponent();
            this.getTableMetaControl1.eventGetTableInfo += new DelegateGetTableInfo(getTableMetaControl1_eventGetTableInfo);
            new DgvFilterPopup.DgvFilterManager(this.dataGridView1);
            CDataGridViewUtils.CopyPasteDataGridView(this.dataGridView1);
        }
        void getTableMetaControl1_eventGetTableInfo(GetTableMetaControl dataTableInfo)
        {
            //throw new NotImplementedException();
            this.dataGridView1.DataSource = dataTableInfo.DtMetaList;
            this.dataGridView1.AutoResizeColumns();
            new DgvFilterPopup.DgvFilterManager(this.dataGridView1);

            this.Text = "表信息：" + dataTableInfo.TableName;

            //DgvFilterManager fm = new DgvFilterManager();
            //fm.ColumnFilterAdding += fm_ColumnFilterAdding;
            //fm.DataGridView = dataGridView1;
        }

        void fm_ColumnFilterAdding(object sender, ColumnFilterEventArgs e)
        {
            e.ColumnFilter = new DgvComboBoxColumnFilter();
        }
    }
}
