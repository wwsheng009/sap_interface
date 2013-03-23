using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace SAPINTGUI
{
    public partial class FormGetTableMeta : Form
    {
        public FormGetTableMeta()
        {
            InitializeComponent();
            this.getTableMetaControl1.eventGetTableInfo += new delegateGetTableInfo(getTableMetaControl1_eventGetTableInfo);
        }
        void getTableMetaControl1_eventGetTableInfo(DataTable dataTableInfo)
        {
            //throw new NotImplementedException();
            this.dataGridView1.DataSource = dataTableInfo;
            this.dataGridView1.AutoResizeColumns();
        }
    }
}
