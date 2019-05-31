using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace WebAPI_SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentExportController : Controller
    {

        private const string XlsxContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        private readonly IHostingEnvironment _hostingEnvironment;

        public DepartmentExportController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// /api/DepartmentExport
        /// </summary>
        [HttpGet]
        public IActionResult DataTableReport(string listBizTypeIDs, string listDepartmentIDs, string listGoodsClassIDs, string listGoodsIDs, string listPOStateIDs, DateTime? startTime, DateTime? endTime, int PageIndex, int PageSize, string WechatID)
        {
            var result = new DataTable("Export");


            result.Columns.Add("采购类型", typeof(string));
            result.Columns.Add("分类", typeof(string));
            result.Columns.Add("采购项", typeof(string));
            result.Columns.Add("数量", typeof(string));//实际数量
            result.Columns.Add("单位", typeof(string));

            if (string.IsNullOrWhiteSpace(listPOStateIDs))
            {
                listPOStateIDs = BaseSettings.listDefualtPOStateIDs;
            }

            DataTable dt = BL.GetPurchasingOrderGoodsCountStatics(
                    DataHelper.GetListInt(listBizTypeIDs),
                    DataHelper.GetListInt(listDepartmentIDs),
                    DataHelper.GetListInt(listGoodsClassIDs),
                    DataHelper.GetListInt(listGoodsIDs),
                    DataHelper.GetListInt(listPOStateIDs),
                    DataHelper.GetDateTime(startTime),
                    DataHelper.GetDateTimeAddOneDay(endTime));

            if (dt == null || dt.Columns.Count == 0)
            {

            }
            else
            {
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    var NewRow = result.NewRow();
                    foreach (DataColumn column in dt.Columns)
                    {
                        if (column.ColumnName == "biz_type_name")
                        {
                            NewRow["采购类型"] = Convert.ToString(dt.Rows[i]["biz_type_name"]);
                        }
                        if (column.ColumnName == "goods_class_name")
                        {
                            NewRow["分类"] = Convert.ToString(dt.Rows[i]["goods_class_name"]);
                        }
                        if (column.ColumnName == "goods_name")
                        {
                            NewRow["采购项"] = Convert.ToString(dt.Rows[i]["goods_name"]);
                        }
                        if (column.ColumnName == "actual_count")
                        {
                            NewRow["数量"] = Convert.ToString(dt.Rows[i]["actual_count"]);
                        }
                        if (column.ColumnName == "goods_unit_name")
                        {
                            NewRow["单位"] = Convert.ToString(dt.Rows[i]["goods_unit_name"]);
                        }

                    }
                    result.Rows.Add(NewRow);
                }
            }


            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");
                worksheet.Cells["A1"].LoadFromDataTable(result, PrintHeaders: true);
                for (var col = 1; col < result.Columns.Count + 1; col++)
                {
                    worksheet.Column(col).AutoFit();
                }
                return File(package.GetAsByteArray(), XlsxContentType, $"DepartmentExport{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}.xlsx");
            }
        }
    }
}