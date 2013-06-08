using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAPINT.Linq;
using SAPINT;
using System.IO;

namespace SAPINTGUI.Table
{
    public partial class FormLinqTable : Form
    {
        String connection = string.Empty;
        SAPContext sc = null;

        public FormLinqTable()
        {
            InitializeComponent();
            connection = ConfigFileTool.SAPGlobalSettings.GetDefaultSapCient();
            sc = new SAPContext(connection);
            this.comboBox1.TextChanged += comboBox1_TextChanged;
        }

        void comboBox1_TextChanged(object sender, EventArgs e)
        {
            var MyTexts = from t in sc.MAKTList
                          where t.MATNR.StartsWith(comboBox1.Text) && t.SPRAS.Equals("1")
                          select t;
            MyTexts = MyTexts.Take(10);

            this.comboBox1.DataSource = null;
            this.comboBox1.DataSource = MyTexts.ToList();
            this.comboBox1.DisplayMember = "MATNR";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var MyTexts = (from t in sc.MAKTList
                           where t.MATNR.Equals(this.comboBox1.Text) && t.SPRAS.InList("E", "1")
                           select t).Take(10);
            this.dataGridView1.DataSource = MyTexts.ToList();
            this.textBox1.Text = sc.textWriter.ToString();
        }
    }

    public class SAPContext : SAPDataContext
    {
        public TextWriter textWriter = new StringWriter();
        public SAPContext()
        {

        }

        public SAPContext(string connectionString)
            : base(connectionString)
        {
        }

        public class MAKT
        {

            /// <summary>
            /// Mandant
            /// </summary>
            public string MANDT { get; set; }

            /// <summary>
            /// Materialnummer
            /// </summary>
            public string MATNR { get; set; }

            /// <summary>
            /// Sprachenschlüssel
            /// </summary>
            public string SPRAS { get; set; }

            /// <summary>
            /// Materialkurztext
            /// </summary>
            public string MAKTX { get; set; }

            /// <summary>
            /// Materialkurztext  in Großschreibung für Matchcodes
            /// </summary>
            public string MAKTG { get; set; }
        }

        public SAPTable<MAKT> MAKTList
        {

            get
            {

                return GetTable<MAKT>(textWriter, true);
            }
        }
    }
}
