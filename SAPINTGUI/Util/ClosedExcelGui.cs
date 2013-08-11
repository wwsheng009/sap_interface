using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML;
using ClosedXML.Excel;


namespace SAPINT.Gui.Util
{
    public static class ClosedExcelGui
    {
        public static void SaveDt2Excel(DataTable dt,String pTableName = "")
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "results.xlsx";
            sfd.Filter = "Excel 工作簿 (*.xlsx)|*.xlsx";
            if (sfd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            // export helper needs a dataset in case you want to save
            // multiple worksheets

            var wb = new XLWorkbook();
            if (String.IsNullOrEmpty(pTableName))
            {
                if (!String.IsNullOrEmpty(dt.TableName))
                {
                    pTableName = dt.TableName;
                }
                else
                {
                    pTableName = "Sheet1";
                }
            }
            wb.Worksheets.Add(dt, pTableName);
            wb.SaveAs(sfd.FileName);

            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            //ExcelXMLExportHelper.ToFormattedExcel(ds, sfd.FileName);
            //ds.Tables.Remove(dt);

            if (MessageBox.Show("数据成功导出到『" + sfd.FileName + "』，是否现在打开？", "导出",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(sfd.FileName);
            }

        }
    }
}
