using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAPINT.Gui.Util
{
    public static class ExcelXMLExportHelperGui
    {
        public static void SaveDt2Excel(DataTable dt)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "results.xls";

            if (sfd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            // export helper needs a dataset in case you want to save
            // multiple worksheets
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            ExcelXMLExportHelper.ToFormattedExcel(ds, sfd.FileName);
            ds.Tables.Remove(dt);
           
            if (MessageBox.Show("数据成功导出到『" + sfd.FileName + "』，是否现在打开？", "导出",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(sfd.FileName);
            }

        }

        public static void SaveDt2Csv(DataTable dt)
        {
            // Exporting to csv is no big deal, we do it anyway
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "results.csv";

            if (sfd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            StreamWriter sw = new StreamWriter(sfd.FileName, false);

            string fileRow = "";
            string cell = "";

            // lets get the dataColumn's titles first
            string titles = "";
            for (int x = 0; x < dt.Columns.Count; x++)
            {
                titles += dt.Columns[x].ColumnName + ",";
            }
            sw.WriteLine(titles);

            // and then we go for the data
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                fileRow = "";
                cell = "";

                for (int j = 0; j < dt.Rows[i].ItemArray.Length; j++)
                {
                    cell = dt.Rows[i][j].ToString();

                    if (cell == null)
                    {
                        cell = "";
                    }

                    // if the data contains a comma,
                    // we enclose that cell with "" so the excel
                    // will understand that comma is not a column separator
                    if (cell.Contains(","))
                    {
                        cell = "\"" + cell + "\"";
                    }

                    fileRow += cell + ",";
                }


                sw.WriteLine(fileRow);
            }

            sw.Close();

            if (MessageBox.Show("数据成功导出到『" + sfd.FileName + "』，是否现在打开？", "导出",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(sfd.FileName);
            }
        }

    }
}
