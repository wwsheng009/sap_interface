using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAPINT.Function.Meta;
namespace SAPINT.Gui
{
    public partial class FormTableInput : Form
    {
        private DataTable _dgvSource;
        public DataTable DgvSource
        {
            get
            {
                return _dgvSource;
            }
            set
            {
                _dgvSource = value;
            }
        }
        public String DataType
        {
            get;
            set;
        }
        public FormTableInput()
        {
            InitializeComponent();
        }
        public void InitializeDataSource()
        {
            if (DataType == SAPDataType.STRUCTURE.ToString())
            {
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                if (_dgvSource.Rows.Count == 0)
                {
                    // DataRow row = dgvSource.NewRow();
                    _dgvSource.Rows.Add(_dgvSource.NewRow());
                }
            }
            else if (DataType == SAPDataType.TABLE.ToString())
            {
                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.AllowUserToDeleteRows = true;
            }
            this.Shown += new EventHandler(FormTableInput_Shown);
            dataGridView1.DataSource = _dgvSource;
            
 
        }
        void FormTableInput_Shown(object sender, EventArgs e)
        {
            dataGridView1.AutoResizeColumns();
        }
    }
}
