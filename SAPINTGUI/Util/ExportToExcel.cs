using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAPINT.Gui.Util
{


    //使用数据引擎保存DataTable 成Excel文件，但是有限制，比如数据类型，内容长度不能超过255
    /// <summary>
    /// 使用数据库引擎保存DataTable到Excel文件里。
    /// </summary>
    class ExportToExcel
    {

        public void SaveExcel(DataTable dt, string Filter, string FileName, string SheetName)
        {

            if (FileName == "")
            {
                SaveFileDialog a = new SaveFileDialog();
                a.Filter = "Excel 工作簿 (*.xls)|*.xls";
                if (a.ShowDialog() == DialogResult.OK)
                {
                    FileName = a.FileName;
                }
                else
                {
                    return;
                }
            }

            try
            {
                System.IO.File.Delete(FileName);
            }
            catch (Exception)
            {
                MessageBox.Show("该文件已经存在，删除文件时出错！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string ConnStr;
            ConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"" + FileName + "\";Extended Properties=\"Excel 8.0;HDR=YES\"";
            ConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"" + FileName + "\";Extended Properties=\"Excel 12.0;\"";

            OleDbConnection conn_excel = new OleDbConnection();
            conn_excel.ConnectionString = ConnStr;

            OleDbCommand cmd_excel = new OleDbCommand();

            string sql;
            sql = SqlCreate(dt, SheetName);

            try
            {
                conn_excel.Open();
                cmd_excel.Connection = conn_excel;
                cmd_excel.CommandText = sql;
                cmd_excel.ExecuteNonQuery();

                conn_excel.Close();
            }
            catch (Exception)
            {

                conn_excel.Close();
                throw;
            }


            OleDbDataAdapter da_excel = new OleDbDataAdapter("Select * From [" + SheetName + "$]", conn_excel);


            da_excel.InsertCommand = SqlInsert(SheetName, dt, conn_excel);
            var sqltext = da_excel.InsertCommand.CommandText;



            if (!string.IsNullOrEmpty(Filter))
            {
                DataTable dt_excel = new DataTable();
                da_excel.Fill(dt_excel);

                DataRow dr_excel;
                string ColumnName;

                foreach (DataRow dr in dt.Select(Filter))
                {
                    dr_excel = dt_excel.NewRow();

                    foreach (DataColumn dc in dt.Columns)
                    {
                        ColumnName = dc.ColumnName;
                        dr_excel[ColumnName] = dr[ColumnName];

                    }
                    dt_excel.Rows.Add(dr_excel);

                }

                da_excel.Update(dt_excel);
                conn_excel.Close();
            }
            else
            {
                try
                {
                    // da_excel.Fill(dt);
                    // da_excel.Update(dt);
                    conn_excel.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd = da_excel.InsertCommand;
                   // cmd.CommandText = sqltext;
                    cmd.Connection = conn_excel;
                    OleDbTransaction trans = conn_excel.BeginTransaction();// <-------------------
                    cmd.Transaction = trans;
                    //foreach (DataColumn dc in dt.Columns)
                    //{
                    //    cmd.Parameters.Add(cmd.CreateParameter());

                    //}

                    foreach (DataRow dr in dt.Select(Filter))
                    {
                        int i = 0;
                        foreach (DataColumn dc in dt.Columns)
                        {

                            var type = da_excel.InsertCommand.Parameters["@" + dc.Caption].OleDbType;
                            var type2 = dr[dc.ColumnName].GetType();
                           // cmd.Parameters[i].Value = dr[dc.ColumnName];
                            cmd.Parameters["@" + dc.Caption].Value = dr[dc.ColumnName];
                            var len = dr[dc.ColumnName].ToString().Length;
                            //cmd.Parameters["@" + dc.Caption].Size = dr[dc.ColumnName].ToString().Length;
                            i++;
                        }
                        //长度有255的限制
                        var II = cmd.ExecuteNonQuery();
                    }
                    trans.Commit(); // <-------------------
                    conn_excel.Close();
                }
                catch (Exception)
                {
                    conn_excel.Close();
                    throw;
                }

            }



            if (MessageBox.Show("数据成功导出到『" + FileName + "』，是否现在打开？", "导出",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(FileName);
            }
        }

        private void CheckColumn(DataTable dt, DataTable dt_v)
        {
            foreach (DataRow dr in dt_v.Select())
            {
                if (!dt.Columns.Contains(dr["列名"].ToString()))
                {
                    dr.Delete();
                }
            }
            dt_v.AcceptChanges();
        }

        private string GetDataType(Type i)
        {
            string s;

            switch (i.Name)
            {

                case "String":
                    s = "LongVarWChar";
                    break;
                case "Int32":
                    s = "Int";
                    break;
                case "Int64":
                    s = "Int";
                    break;
                case "Int16":
                    s = "Int";
                    break;
                case "Double":
                    s = "Double";
                    break;
                case "Decimal":
                    s = "Double";
                    break;
                default:
                    s = "LongVarWChar";
                    break;

            }
            return s;
        }

        private OleDbType StringToOleDbType(Type i)
        {
            OleDbType s;

            switch (i.Name)
            {
                case "String":
                    s = OleDbType.LongVarWChar;
                    break;
                case "Int32":
                    s = OleDbType.Integer;
                    break;
                case "Int64":
                    s = OleDbType.Integer;
                    break;
                case "Int16":
                    s = OleDbType.Integer;
                    break;
                case "Double":
                    s = OleDbType.Double;
                    break;
                case "Decimal":
                    s = OleDbType.Decimal;
                    break;
                //case "DateTime":
                //    s = OleDbType.Date;
                //    break;
                default:
                    s = OleDbType.LongVarWChar;
                    break;

            }
            return s;

        }


        private string SqlCreate(DataTable dt, string SheetName)
        {
            string sql;

            sql = "CREATE TABLE " + SheetName + " (";

            foreach (DataColumn dc in dt.Columns)
            {
                //  sql += "[" + dc.ColumnName + "] " + GetDataType(dc.DataType) + " ,";
                sql += "[" + dc.ColumnName + "] " + "VarChar" + " ,";
            }

            //sql = "CREATE TABLE [" + SheetName + "] (";

            //foreach (C1.Win.C1TrueDBGrid.C1DataColumn dc in grid.Columns)
            //{
            //    sql += "[" + dc.Caption + "] " + GetDataType(dc.DataType) + ",";
            //}
            //sql = sql.Substring(0, sql.Length - 1);
            //sql += ")";

            sql = sql.Substring(0, sql.Length - 1);
            sql += ")";

            return sql;
        }


        // 生成 InsertCommand 并设置参数
        private OleDbCommand SqlInsert(string SheetName, DataTable dt, OleDbConnection conn_excel)
        {
            OleDbCommand i;
            string sql;

            sql = "INSERT INTO [" + SheetName + "$] (";
            foreach (DataColumn dc in dt.Columns)
            {
                sql += "[" + dc.ColumnName + "] ";
                sql += ",";
            }
            sql = sql.Substring(0, sql.Length - 1);
            sql += ") VALUES (";
            foreach (DataColumn dc in dt.Columns)
            {
                sql += "?,";
            }
            sql = sql.Substring(0, sql.Length - 1);
            sql += ")";

            i = new OleDbCommand(sql, conn_excel);

            foreach (DataColumn dc in dt.Columns)
            {
                // i.Parameters.Add("@" + dc.Caption, StringToOleDbType(dc.DataType), 0, dc.Caption);
                i.Parameters.Add("@" + dc.Caption, OleDbType.LongVarWChar);

            }

            return i;
        }

    }
}
