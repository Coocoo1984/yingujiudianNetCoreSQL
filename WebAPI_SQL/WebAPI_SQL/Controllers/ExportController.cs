using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace WebAPI_SQL.Controllers
{
    public class ExportController : Controller
    {
        private const string XlsxContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        /// <summary>
        /// 统表
        /// </summary>
        /// <param name="listDepartmentIDs"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="listPOStateIDs"></param>
        /// <returns></returns>
        [Route("export/PurchasingOrderTotal")]
        [HttpGet]
        public IActionResult PurchasingOrderTotal(string listDepartmentIDs, string listPOStateIDs, DateTime? startTime, DateTime? endTime)
        {
            var result = new DataTable("Export");

            result.Columns.Add("采购部门", typeof(string));
            result.Columns.Add("采购类型", typeof(string));
            result.Columns.Add("采购金额", typeof(string));
            result.Columns.Add("采购时间", typeof(string));//实际数量
            result.Columns.Add("供应商", typeof(string));


            if(string.IsNullOrWhiteSpace(listPOStateIDs))
            {
                listPOStateIDs = BaseSettines.listDefualtPOStateIDs;
            }

            DataTable dt = BL.GetPurchasingOrderTotal(
                DataHelper.GetListInt(listDepartmentIDs),
                null,
                DataHelper.GetListInt(listPOStateIDs),
                DataHelper.GetDateTime(startTime),
                DataHelper.GetDateTime(endTime)
            );

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
                        if (column.ColumnName == "department_name")
                        {
                            NewRow["采购部门"] = Convert.ToString(dt.Rows[i]["department_name"]);
                        }
                        if (column.ColumnName == "biz_type_name")
                        {
                            NewRow["采购类型"] = Convert.ToString(dt.Rows[i]["biz_type_name"]);
                        }
                        if (column.ColumnName == "total")
                        {
                            NewRow["采购金额"] = Convert.ToString(dt.Rows[i]["total"]);
                        }
                        if (column.ColumnName == "create_time")
                        {
                            NewRow["采购时间"] = Convert.ToString(dt.Rows[i]["create_time"]);
                        }
                        if (column.ColumnName == "vendor_name")
                        {
                            NewRow["供应商"] = Convert.ToString(dt.Rows[i]["vendor_name"]);
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
                return File(package.GetAsByteArray(), XlsxContentType, $"PurchasingOrderTotal{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}.xlsx");
            }
        }

        /// <summary>
        /// 明细报表
        /// </summary>
        /// <param name="listDepartmentIDs"></param>
        /// <param name="listBizTypeIDs"></param>
        /// <param name="listGoodsClassIDs"></param>
        /// <param name="listGoodsIDs"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        [Route("export/PurchasingOrderGoodsSubtotal")]
        [HttpGet]
        public IActionResult PurchasingOrderGoodsSubtotal(string listDepartmentIDs, string listBizTypeIDs, string listGoodsClassIDs, string listGoodsIDs, string listPOStateIDs, DateTime? startTime, DateTime? endTime)
        {
            var result = new DataTable("Export");

            result.Columns.Add("采购部门", typeof(string));
            result.Columns.Add("采购类型", typeof(string));
            result.Columns.Add("采购项目", typeof(string));
            result.Columns.Add("采购金额", typeof(string));
            result.Columns.Add("采购时间", typeof(string));//实际数量
            result.Columns.Add("供应商", typeof(string));

            if(string.IsNullOrWhiteSpace(listPOStateIDs))
            {
                listPOStateIDs = BaseSettines.listDefualtPOStateIDs;
            }

            DataTable dt = BL.GetPurchasingOrderGoodsSubtotal(
                DataHelper.GetListInt(listDepartmentIDs),
                DataHelper.GetListInt(listBizTypeIDs),
                DataHelper.GetListInt(listGoodsClassIDs),
                DataHelper.GetListInt(listGoodsIDs),
                DataHelper.GetListInt(listPOStateIDs),
                DataHelper.GetDateTime(startTime),
                DataHelper.GetDateTime(endTime));

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
                        if (column.ColumnName == "department_name")
                        {
                            NewRow["采购部门"] = Convert.ToString(dt.Rows[i]["department_name"]);
                        }
                        if (column.ColumnName == "biz_type_name")
                        {
                            NewRow["采购类型"] = Convert.ToString(dt.Rows[i]["biz_type_name"]);
                        }
                        if (column.ColumnName == "goods_name")
                        {
                            NewRow["采购项目"] = Convert.ToString(dt.Rows[i]["goods_name"]);
                        }
                        if (column.ColumnName == "total")
                        {
                            NewRow["采购金额"] = Convert.ToString(dt.Rows[i]["total"]);
                        }
                        if (column.ColumnName == "create_time")
                        {
                            NewRow["采购时间"] = Convert.ToString(dt.Rows[i]["create_time"]);
                        }
                        if (column.ColumnName == "vendor_name")
                        {
                            NewRow["供应商"] = Convert.ToString(dt.Rows[i]["vendor_name"]);
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
                return File(package.GetAsByteArray(), XlsxContentType, $"PurchasingOrderGoodsSubtotal{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}.xlsx");
            }

        }

        /// <summary>
        /// 供应商报表
        /// </summary>
        /// <param name="listVendorIDs"></param>
        /// <param name="listBizTypeIDs"></param>
        /// <param name="listGoodsClassIDs"></param>
        /// <param name="listGoodsIDs"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        [Route("export/PurchasingOrderVendorSubtotal")]
        [HttpGet]
        public IActionResult PurchasingOrderVendorSubtotal(string listVendorIDs, string listBizTypeIDs, string listGoodsClassIDs, string listGoodsIDs, string listPOStateIDs, DateTime? startTime, DateTime? endTime)
        {
            var result = new DataTable("Export");

            result.Columns.Add("供应商", typeof(string));
            result.Columns.Add("采购类型", typeof(string));
            result.Columns.Add("采购项目", typeof(string));
            result.Columns.Add("单价", typeof(string));
            result.Columns.Add("数量", typeof(string));
            result.Columns.Add("小计金额", typeof(string));
            result.Columns.Add("采购时间", typeof(string));

            if (string.IsNullOrWhiteSpace(listPOStateIDs))
            {
                listPOStateIDs = BaseSettines.listDefualtPOStateIDs;
            }

            DataTable dt = BL.GetPurchasingOrderVendorSubtotal(
                DataHelper.GetListInt(listVendorIDs),
                DataHelper.GetListInt(listBizTypeIDs),
                DataHelper.GetListInt(listGoodsClassIDs),
                DataHelper.GetListInt(listGoodsIDs),
                DataHelper.GetListInt(listPOStateIDs),
                DataHelper.GetDateTime(startTime),
                DataHelper.GetDateTime(endTime));

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
                        if (column.ColumnName == "vendor_name")
                        {
                            NewRow["供应商"] = Convert.ToString(dt.Rows[i]["vendor_name"]);
                        }
                        if (column.ColumnName == "biz_type_name")
                        {
                            NewRow["采购类型"] = Convert.ToString(dt.Rows[i]["biz_type_name"]);
                        }
                        if (column.ColumnName == "goods_name")
                        {
                            NewRow["采购项目"] = Convert.ToString(dt.Rows[i]["goods_name"]);
                        }
                        if (column.ColumnName == "unit_price")
                        {
                            NewRow["单价"] = Convert.ToString(dt.Rows[i]["unit_price"]);
                        }
                        if (column.ColumnName == "count_for_show")
                        {
                            NewRow["数量"] = Convert.ToString(dt.Rows[i]["count_for_show"]);
                        }
                        if (column.ColumnName == "countactual_subtotal_for_show")
                        {
                            NewRow["小计金额"] = Convert.ToString(dt.Rows[i]["countactual_subtotal_for_show"]);
                        }
                        if (column.ColumnName == "create_time")
                        {
                            NewRow["采购时间"] = Convert.ToString(dt.Rows[i]["create_time"]);
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
                return File(package.GetAsByteArray(), XlsxContentType, $"PurchasingOrderGoodsSubtotal{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}.xlsx");
            }

        }

    }
}