using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using System;
using System.Data;
using System.IO;
using System.Linq;

namespace EPPlus
{
    class Program
    {
        static void Main(string[] args)
        {
            string folder = Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(Program)).CodeBase);
            folder = folder.Replace("bin\\Debug", "").Replace("file:\\", "");

            DataTable dt = GetDataTableFromExcel(folder + "Input\\Data.xlsx", true);

            string path = folder + "Output\\Results-" + DateTime.Now.ToString("dd-MM-yyy hh-mm tt") + ".xlsx";

            CreateExcelFile(dt, path);
        }

        public static DataTable GetDataTableFromExcel(string path, bool hasHeader = true)
        {
            using (var pck = new OfficeOpenXml.ExcelPackage())
            {
                using (var stream = File.OpenRead(path))
                {
                    pck.Load(stream);
                }
                var ws = pck.Workbook.Worksheets.First();
                DataTable tbl = new DataTable();
                foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                {
                    tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                }
                var startRow = hasHeader ? 2 : 1;
                for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                {
                    var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                    DataRow row = tbl.Rows.Add();
                    foreach (var cell in wsRow)
                    {
                        row[cell.Start.Column - 1] = cell.Text;
                    }
                }
                return tbl;
            }
        }

        public static void CreateExcelFile(DataTable dt, string path)
        {
            try
            {
                using (ExcelPackage xp = new ExcelPackage())
                {
                    ExcelWorksheet ws = xp.Workbook.Worksheets.Add("Test Results");

                    int rowstart = 1;
                    int colstart = 1;
                    int rowend = rowstart;
                    int colend = colstart + dt.Columns.Count;

                    ws.Cells[rowstart, colstart, rowend, colend].Merge = true;
                    ws.Cells[rowstart, colstart, rowend, colend].Value = "Test Resuls on " + DateTime.Now.ToString("dd MMM yyyy hh:mm tt");
                    ws.Cells[rowstart, colstart, rowend, colend].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[rowstart, colstart, rowend, colend].Style.Font.Bold = true;
                    ws.Cells[rowstart, colstart, rowend, colend].Style.Fill.PatternType = ExcelFillStyle.None;

                    rowstart += 2;
                    rowend = rowstart + dt.Rows.Count;
                    ws.Cells[rowstart, colstart].LoadFromDataTable(dt, true);
                    int i = 1;
                    foreach (DataColumn dc in dt.Columns)
                    {
                        i++;
                        if (dc.DataType == typeof(decimal))
                            ws.Column(i).Style.Numberformat.Format = "#0.00";
                    }
                    ws.Cells[ws.Dimension.Address].AutoFitColumns();

                    ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Top.Style =
                       ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Bottom.Style =
                       ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Left.Style =
                       ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                    FileInfo file = new FileInfo(path);
                    xp.SaveAs(file);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
