using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;


class ExcelXMLExportHelper
{
    // Get a string with excel's XML headers     
    private static string getXMLWorkbookTemplate()
    {
        StringBuilder sb = new StringBuilder(818);

        sb.AppendFormat(@"<?xml version=""1.0""?>{0}", Environment.NewLine);
        sb.AppendFormat(@"<?mso-application progid=""Excel.Sheet""?>{0}", Environment.NewLine);
        sb.AppendFormat(@"<Workbook xmlns=""urn:schemas-microsoft-com:office:spreadsheet""{0}", Environment.NewLine);
        sb.AppendFormat(@" xmlns:o=""urn:schemas-microsoft-com:office:office""{0}", Environment.NewLine);
        sb.AppendFormat(@" xmlns:x=""urn:schemas-microsoft-com:office:excel""{0}", Environment.NewLine);
        sb.AppendFormat(@" xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet""{0}", Environment.NewLine);
        sb.AppendFormat(@" xmlns:html=""http://www.w3.org/TR/REC-html40"">{0}", Environment.NewLine);
        sb.AppendFormat(@" <ss:Styles>{0}", Environment.NewLine);
        sb.AppendFormat(@"  <ss:Style ss:ID=""Default"" ss:Name=""Normal"">{0}", Environment.NewLine);
        sb.AppendFormat(@"   <ss:Alignment ss:Vertical=""Bottom""/>{0}", Environment.NewLine);

        sb.AppendFormat(@"   <ss:Font ss:FontName=""Calibri"" x:Family=""Swiss"" ss:Size=""11"" ss:Color=""#000000""/>{0}", Environment.NewLine);
        sb.AppendFormat(@"   <ss:Interior/>{0}", Environment.NewLine);
        sb.AppendFormat(@"   <ss:NumberFormat/>{0}", Environment.NewLine);
        sb.AppendFormat(@"   <ss:Protection/>{0}", Environment.NewLine);
        sb.AppendFormat(@"  </ss:Style>{0}", Environment.NewLine);

        sb.AppendFormat(@"  <ss:Style ss:ID=""s62"">{0}", Environment.NewLine);

        sb.AppendFormat(@"   <ss:Borders>{0}", Environment.NewLine);
        sb.AppendFormat(@"   <ss:Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />{0}", Environment.NewLine);
        sb.AppendFormat(@"   <ss:Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />{0}", Environment.NewLine);
        sb.AppendFormat(@"   <ss:Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />{0}", Environment.NewLine);
        sb.AppendFormat(@"   <ss:Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />{0}", Environment.NewLine);
        sb.AppendFormat(@"   </ss:Borders>{0}", Environment.NewLine);

        sb.AppendFormat(@"   <ss:Font ss:FontName=""Calibri"" x:Family=""Swiss"" ss:Size=""11"" ss:Color=""#000000""{0}", Environment.NewLine);
        sb.AppendFormat(@"    ss:Bold=""1""/>{0}", Environment.NewLine);
        sb.AppendFormat(@"  </ss:Style>{0}", Environment.NewLine);
        sb.AppendFormat(@"  <ss:Style ss:ID=""s63"">{0}", Environment.NewLine);
        sb.AppendFormat(@"   <ss:NumberFormat ss:Format=""Short Date""/>{0}", Environment.NewLine);
        sb.AppendFormat(@"  </ss:Style>{0}", Environment.NewLine);


        sb.AppendFormat(@"  <ss:Style ss:ID=""s60"">{0}", Environment.NewLine);
        sb.AppendFormat(@"   <ss:Alignment ss:Vertical=""Bottom""/>{0}", Environment.NewLine);

        sb.AppendFormat(@"   <ss:Borders>{0}", Environment.NewLine);
        sb.AppendFormat(@"   <ss:Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />{0}", Environment.NewLine);
        sb.AppendFormat(@"   <ss:Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />{0}", Environment.NewLine);
        sb.AppendFormat(@"   <ss:Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />{0}", Environment.NewLine);
        sb.AppendFormat(@"   <ss:Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />{0}", Environment.NewLine);
        sb.AppendFormat(@"   </ss:Borders>{0}", Environment.NewLine);

        sb.AppendFormat(@"  </ss:Style>{0}", Environment.NewLine);


        sb.AppendFormat(@" </ss:Styles>{0}", Environment.NewLine);

        sb.Append(@"{0}\r\n</Workbook>");
        return sb.ToString();
    }

    // some special characters replacement (escaping)
    private static string replaceXmlChar(string input)
    {
        input = input.Replace("&", "&amp");
        input = input.Replace("<", "&lt;");
        input = input.Replace(">", "&gt;");
        input = input.Replace("\"", "&quot;");
        input = input.Replace("'", "&apos;");
        return input;
    }

    // get the xml formatted string for an specific data cell,
    // we translate c# types to excel data types and fix the nulls
    // plus the option to give border to the cell
    private static string getCellXml(Type type, object cellData, bool hasBorder)
    {
        object data = (cellData is DBNull) ? "" : cellData;

        string border = "";
        if (hasBorder) { border = @" ss:StyleID=""s60"""; }

        if (type.Name.Contains("Int") || type.Name.Contains("Double") || type.Name.Contains("Decimal") || type.Name.Contains("decimal"))
        {
            return string.Format("<Cell" + border + "><Data ss:Type=\"Number\">{0}</Data></Cell>", data);
        }


        if (type.Name.Contains("Date") && data.ToString() != string.Empty)
        {
            return string.Format("<Cell ss:StyleID=\"s63\"><Data ss:Type=\"DateTime\">{0}</Data></Cell>", Convert.ToDateTime(data).ToString("yyyy-MM-dd"));
        }

        decimal nad = 0;
        if (decimal.TryParse(cellData.ToString(), out nad))
        {
            return string.Format("<Cell" + border + "><Data ss:Type=\"Number\">{0}</Data></Cell>", data);
        }

        return string.Format("<Cell" + border + "><Data ss:Type=\"String\">{0}</Data></Cell>", replaceXmlChar(data.ToString()));
    }

    // Input Dataset, or the tables we want to export to excel
    // the Filename
    public static void ToFormattedExcel(DataSet dsInput, string filename)
    {
        // we get the xml headers first
        string excelTemplate = getXMLWorkbookTemplate();


        string tablas = "<Worksheet ss:Name=\"Result\">";

        tablas += "\r\n<Table>\r\n";

        foreach (DataTable dt in dsInput.Tables)
        {
            tablas += GetExcelTableXml(dt, true);
        }
        tablas += "\r\n</Table>\r\n";
        tablas += "\r\n</Worksheet>";

        string excelXml = string.Format(excelTemplate, tablas);

        // now we write the file
        try
        {
            File.Delete(filename);
            StreamWriter sw = new StreamWriter(filename);

            sw.Write(excelXml);

            sw.Flush();
            sw.Close();

            sw.Dispose();
            sw = null;


        }
        catch (Exception ex)
        {
        }
    }

    // loop the datatable and make the excel xml for the titles
    // and the data cells
    public static string GetExcelTableXml(DataTable dt, bool hasBorder)
    {
        string result = "";

        //write column name row
        result = "\r\n<Row>";

        foreach (DataColumn dc in dt.Columns)
        {
            result += string.Format("<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">{0}</Data></Cell>", replaceXmlChar(dc.ColumnName));
        }
        result += "\r\n</Row>";

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            result += "\r\n<Row>";

            foreach (DataColumn dc in dt.Columns)
            {
                result += getCellXml(dc.DataType, dt.Rows[i][dc.ColumnName], hasBorder);
            }

            result += "</Row>";
        }

        return result;
    }

}

