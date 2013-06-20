using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
namespace SAPINT.Gui
{
    public partial class FormSAPQuery : DockWindow
    {
        public FormSAPQuery()
        {
            InitializeComponent();
            this.sapQueryControl1.eventQueryExuteDone += new QueryExcuteDone(sapQueryControl1_eventQueryExuteDone);
        }
        void sapQueryControl1_eventQueryExuteDone(DataTable resultDataTable)
        {
            //throw new NotImplementedException();
            this.dataGridView1.DataSource = resultDataTable;
            this.dataGridView1.AutoResizeColumns();
        }
    }
}
