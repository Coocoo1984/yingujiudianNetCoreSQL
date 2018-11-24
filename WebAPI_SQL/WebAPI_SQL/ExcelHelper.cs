using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http; //IFormFile
using OfficeOpenXml;
 
namespace WebAPI_SQL
{
    /// <summary>
    /// Excel导入导出助手
    /// NuGet：EPPlus.Core
    /// </summary>
    public sealed class ExcelHelper
    {
        //参考：https://www.jb51.net/article/100509.htm

        private ExcelHelper() { }

        /// <summary>
        /// Excel文件 Content-Type
        /// </summary>
        private const string Excel = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        /// <summary>
        /// Excel导出
        /// </summary>
        /// <param name="keyValuePairs">字典表【名称，数据】</param>
        /// <param name="sWebRootFolder">网站根文件夹</param>
        /// <param name="tuple">item1:The virtual path of the file to be returned.|item2:The Content-Type of the file</param>
        public static void Export(Dictionary<string, DataTable> keyValuePairs, string sWebRootFolder, out Tuple<string, string> tuple, string fileNamePostfix)
        {
            if (string.IsNullOrWhiteSpace(sWebRootFolder))
                tuple = Tuple.Create("", Excel);

            string sFileName = string.Empty;
            if (fileNamePostfix == null || string.IsNullOrWhiteSpace(fileNamePostfix))
            {
                sFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            }
            else
            {
                sFileName = $"{DateTime.Now.ToString("yyyyMMddHHmmssfff")}_{fileNamePostfix}.xlsx";
            }

            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            using (ExcelPackage package = new ExcelPackage(file))
            {
                foreach (var item in keyValuePairs)
                {
                    string worksheetTitle = item.Key; //表名称
                    var dt = item.Value; //数据表

                    // 添加worksheet
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(worksheetTitle);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            if (i == 0)
                            {
                                //添加表头
                                worksheet.Cells[1, j + 1].Value = dt.Columns[j].ColumnName;
                                worksheet.Cells[1, j + 1].Style.Font.Bold = true;
                            }
                            else
                            {
                                //添加值
                                worksheet.Cells[i + 1, j + 1].Value = dt.Rows[i][j].ToString();
                            }
                        }
                    }
                }
                package.Save();
            }
            tuple = Tuple.Create(sFileName, Excel);
        }

        /////// <summary>
        /////// Excel导入
        /////// </summary>
        /////// <param name="excelFile">Excel文件</param>
        /////// <param name="sWebRootFolder">文件存储路径</param>
        ///////  <param name="content">显示内容</param>
        /////// <param name="isShow">是否显示内容</param>
        ////public static void Import(IFormFile excelFile, string sWebRootFolder, out string content, bool isShow = false)
        ////{
        ////    if (string.IsNullOrWhiteSpace(sWebRootFolder))
        ////        content = string.Empty;

        ////    string sFileName = $"{DateTime.Now.ToString("yyyyMMddHHmmssfff")}-{FormatGuid.GetGuid(FormatGuid.GuidType.N)}.xlsx";
        ////    FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));

        ////    using (FileStream fs = new FileStream(file.ToString(), FileMode.Create))
        ////    {
        ////        excelFile.CopyToAsync(fs);
        ////        fs.Flush();
        ////    }

        ////    if (isShow)
        ////    {
        ////        //导出单个工作表sheet
        ////        using (ExcelPackage package = new ExcelPackage(file))
        ////        {
        ////            StringBuilder sb = new StringBuilder();
        ////            ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
        ////            int rowCount = worksheet.Dimension.Rows;
        ////            int colCount = worksheet.Dimension.Columns;
        ////            bool bHeaderRow = true;
        ////            for (int row = 1; row <= rowCount; row++)
        ////            {
        ////                for (int col = 1; col <= colCount; col++)
        ////                {
        ////                    if (bHeaderRow)
        ////                        sb.Append(worksheet.Cells[row, col].Value.ToString() + "\t");
        ////                    else
        ////                        sb.Append(worksheet.Cells[row, col].Value.ToString() + "\t");
        ////                }
        ////                sb.Append(Environment.NewLine);
        ////            }
        ////            content = sb.ToString();
        ////        }
        ////    }
        ////    else
        ////    {
        ////        content = string.Empty;
        ////    }
        ////}

    }
}
