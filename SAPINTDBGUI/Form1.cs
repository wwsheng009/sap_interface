using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAPINTDB;
using System.Data.Common;
using SAPINTDB;
using System.Data.SQLite;
using System.IO;

namespace SAPINTDBGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (DataTable tbl = DbProviderFactories.GetFactoryClasses())
            {
                foreach (DataRow row in tbl.Rows)
                {
                    string prov = row[2].ToString();
                    if ((prov.IndexOf("SQLite", 0, StringComparison.OrdinalIgnoreCase) != -1) || (prov.IndexOf("SqlClient", 0, StringComparison.OrdinalIgnoreCase) != -1))
                    {
                        //  this._provider.Items.Add(prov);
                    }
                    if (prov == "System.Data.SQLite")
                    {
                        // this._provider.SelectedItem = prov;
                    }
                }
            }

            //   netlib7 net = new netlib7("System.Data.SQLite");



            string providerName = "System.Data.SQLite"; // TODO: 初始化为适当的值

            string connectionString = "Data Source=" + "E:\\wangws\\ZRFC_SRM_SUPPLY_DATA.db" + ";Pooling=False"; // TODO: 初始化为适当的值
            //// DbConnection expected = null; // TODO: 初始化为适当的值
            // DbConnection actual;
            // db = target.CreateConnection(providerName, connectionString);
            // DbCommand cmd = target.CreateCommand(actual);
            // target.DataTableFill
            netlib7 db = new netlib7(); // TODO: 初始化为适当的值
            db.ProviderName = providerName;
            db.ConnectionString = connectionString;

            SAPINTDB.netlib7 db2 = new netlib7(providerName, connectionString);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            createTable();
        }
        private void createTable()
        {
            //SapTable table = new SapTable("RET900000", "MARA");
            //String dbPath = createDb( table.TableName );
            //string providerName = "System.Data.SQLite"; // TODO: 初始化为适当的值

            //string connectionString = "Data Source=" + dbPath + ";Pooling=False"; // TODO: 初始化为适当的值


            //table.ProviderName = providerName;
            //table.ConnectionString = connectionString;
            //table.saveDataTable(new DataTable());
            //  sapTable
        }

        private string createDb(String dbName)
        {
            string _dbFile = "E:\\wangws";
            _dbFile = _dbFile + "\\" + dbName + ".db";
            //if (File.Exists(_dbFile)) {
            //    File.Delete(_dbFile);
            //}
            if (!File.Exists(_dbFile))
            {
                SQLiteConnection.CreateFile(_dbFile);
            }
            return _dbFile;
        }


    }
}
