using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_SQL
{

    public static class ExcelUtil
    {
        //PurchasingOrderTotal 统表 按部门统表
        public const string PurchasingOrderTotalModelName = "PurchasingOrderTotal";
        public const string PurchasingOrderTotalDataTableName = "PurchasingOrderTotal";
        public const int PurchasingOrderTotalRowStarIndex = 2;
        public const int PurchasingOrderTotalColumnStarIndex = 0;
        public static readonly string[] PurchasingOrderTotalSheetHeader = { "采购部门", "采购类型", "采购金额", "采购时间", "供应商" };
        public static readonly string[] PurchasingOrderTotalModelOnlyMappedPropertyArray = { "department_name", "biz_type_name", "total", "create_time", "vendor_name" };
        public static readonly string[] PurchasingOrderTotalModelPropertyArray = { "department_name", "biz_type_name", "total", "create_time", "vendor_name" };
        //未隐射属性名, <DB隐射属性名, excel列名>
        public static Dictionary<string, Tuple<string, string>> GoodsDictionary = new Dictionary<string, Tuple<string, string>>(){
            { PurchasingOrderTotalModelPropertyArray[0], new Tuple<string, string>(PurchasingOrderTotalModelOnlyMappedPropertyArray[0], PurchasingOrderTotalSheetHeader[0]) },
            { PurchasingOrderTotalModelPropertyArray[1], new Tuple<string, string>(PurchasingOrderTotalModelOnlyMappedPropertyArray[1], PurchasingOrderTotalSheetHeader[1]) },
            { PurchasingOrderTotalModelPropertyArray[2], new Tuple<string, string>(PurchasingOrderTotalModelOnlyMappedPropertyArray[2], PurchasingOrderTotalSheetHeader[2]) },
            { PurchasingOrderTotalModelPropertyArray[3], new Tuple<string, string>(PurchasingOrderTotalModelOnlyMappedPropertyArray[3], PurchasingOrderTotalSheetHeader[3]) },
            { PurchasingOrderTotalModelPropertyArray[4], new Tuple<string, string>(PurchasingOrderTotalModelOnlyMappedPropertyArray[4], PurchasingOrderTotalSheetHeader[4]) }
        };

        //PurchasingOrderGoodsSubtotal 明细表 按部门明细表
        public const string PurchasingOrderGoodsSubtotalModelName = "PurchasingOrderGoodsSubtotal";
        public const string PurchasingOrderGoodsSubtotalDataTableName = "PurchasingOrderGoodsSubtotal";
        public const int PurchasingOrderGoodsSubtotalRowStarIndex = 2;
        public const int PurchasingOrderGoodsSubtotalColumnStarIndex = 0;
        public static readonly string[] PurchasingOrderGoodsSubtotalSheetHeader = { "采购部门", "采购类型", "采购项目", "采购金额", "采购时间", "供应商" };
        public static readonly string[] PurchasingOrderGoodsSubtotalModelOnlyMappedPropertyArray = { "department_name", "biz_type_name", "goods_name", "subtotal", "create_time", "vendor_name" };
        public static readonly string[] PurchasingOrderGoodsSubtotalModelPropertyArray = { "department_name", "biz_type_name", "goods_name", "subtotal", "create_time", "vendor_name" };
        //未隐射属性名, <DB隐射属性名, excel列名>
        public static Dictionary<string, Tuple<string, string>> PurchasingOrderGoodsSubtotalDictionary = new Dictionary<string, Tuple<string, string>>(){
            { PurchasingOrderGoodsSubtotalModelPropertyArray[0], new Tuple<string, string>(PurchasingOrderGoodsSubtotalModelOnlyMappedPropertyArray[0], PurchasingOrderGoodsSubtotalSheetHeader[0]) },
            { PurchasingOrderGoodsSubtotalModelPropertyArray[1], new Tuple<string, string>(PurchasingOrderGoodsSubtotalModelOnlyMappedPropertyArray[1], PurchasingOrderGoodsSubtotalSheetHeader[1]) },
            { PurchasingOrderGoodsSubtotalModelPropertyArray[2], new Tuple<string, string>(PurchasingOrderGoodsSubtotalModelOnlyMappedPropertyArray[2], PurchasingOrderGoodsSubtotalSheetHeader[2]) },
            { PurchasingOrderGoodsSubtotalModelPropertyArray[3], new Tuple<string, string>(PurchasingOrderGoodsSubtotalModelOnlyMappedPropertyArray[3], PurchasingOrderGoodsSubtotalSheetHeader[3]) },
            { PurchasingOrderGoodsSubtotalModelPropertyArray[4], new Tuple<string, string>(PurchasingOrderGoodsSubtotalModelOnlyMappedPropertyArray[4], PurchasingOrderGoodsSubtotalSheetHeader[4]) },
            { PurchasingOrderGoodsSubtotalModelPropertyArray[5], new Tuple<string, string>(PurchasingOrderGoodsSubtotalModelOnlyMappedPropertyArray[5], PurchasingOrderGoodsSubtotalSheetHeader[5]) }
        };

        //PurchasingOrderVendorSubtotal 供应商统表
        public const string PurchasingOrderVendorSubtotalModelName = "PurchasingOrderVendorSubtotal";        
        public const string PurchasingOrderVendorSubtotalDataTableName = "PurchasingOrderVendorSubtotal";
        public const int PurchasingOrderVendorSubtotalRowStarIndex = 2;
        public const int PurchasingOrderVendorSubtotalColumnStarIndex = 0;
        public static readonly string[] PurchasingOrderVendorSubtotalSheetHeader = { "商品类目名称", "采购类型", "采购项目", "单价", "数量", "小计金额", "采购时间" };
        public static readonly string[] PurchasingOrderVendorSubtotalModelOnlyMappedPropertyArray = { "vendor_name", "biz_type_name", "goods_name", "unit_price", "count_for_show", "actual_subtotal", "create_time" };
        public static readonly string[] PurchasingOrderVendorSubtotalModelPropertyArray = { "vendor_name", "biz_type_name", "goods_name", "unit_price", "count_for_show", "actual_subtotal", "create_time" };
        //未隐射属性名, <DB隐射属性名, excel列名>
        public static Dictionary<string, Tuple<string, string>> PurchasingOrderVendorSubtotalDictionary = new Dictionary<string, Tuple<string, string>>(){
            { PurchasingOrderVendorSubtotalModelPropertyArray[0], new Tuple<string,string>(PurchasingOrderVendorSubtotalModelOnlyMappedPropertyArray[0], PurchasingOrderVendorSubtotalSheetHeader[0]) },
            { PurchasingOrderVendorSubtotalModelPropertyArray[1], new Tuple<string,string>(PurchasingOrderVendorSubtotalModelOnlyMappedPropertyArray[1], PurchasingOrderVendorSubtotalSheetHeader[1]) },
            { PurchasingOrderVendorSubtotalModelPropertyArray[2], new Tuple<string,string>(PurchasingOrderVendorSubtotalModelOnlyMappedPropertyArray[2], PurchasingOrderVendorSubtotalSheetHeader[2]) },
            { PurchasingOrderVendorSubtotalModelPropertyArray[3], new Tuple<string,string>(PurchasingOrderVendorSubtotalModelOnlyMappedPropertyArray[3], PurchasingOrderVendorSubtotalSheetHeader[3]) },
            { PurchasingOrderVendorSubtotalModelPropertyArray[4], new Tuple<string,string>(PurchasingOrderVendorSubtotalModelOnlyMappedPropertyArray[4], PurchasingOrderVendorSubtotalSheetHeader[4]) },
            { PurchasingOrderVendorSubtotalModelPropertyArray[5], new Tuple<string,string>(PurchasingOrderVendorSubtotalModelOnlyMappedPropertyArray[5], PurchasingOrderVendorSubtotalSheetHeader[5]) }
        };



        /// <summary>
        /// 从文件流读取DataTable数据源
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(Stream stream)
        {
            XSSFWorkbook workbook;
            try
            {
                workbook = new XSSFWorkbook(stream);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            ISheet sheetAt = workbook.GetSheetAt(0);
            IEnumerator rowEnumerator = sheetAt.GetRowEnumerator();
            DataTable table = new DataTable();
            IRow row = sheetAt.GetRow(0);
            if (row != null)
            {
                for (int j = 0; j < row.LastCellNum; j++)
                {
                    ICell cell = row.GetCell(j);
                    if (cell == null)
                    {
                        table.Columns.Add("cell" + j.ToString());
                    }
                    else
                    {
                        table.Columns.Add(cell.ToString());
                    }
                }
            }
            int count = table.Columns.Count;
            for (int i = 0; rowEnumerator.MoveNext(); i++)
            {
                if (i > 0)
                {
                    IRow current = (IRow)rowEnumerator.Current;
                    DataRow row3 = table.NewRow();
                    for (int k = 0; k < count; k++)
                    {
                        ICell cell2 = current.GetCell(k);
                        if (cell2 == null)
                        {
                            row3[k] = null;
                        }
                        else
                        {
                            row3[k] = cell2.ToString();
                        }
                    }
                    table.Rows.Add(row3);
                }
            }
            return table;
        }

        /// <summary>
        /// 从Sheet按照位置读取表格返回DataTable
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="rowStartIndex">内容开始行index[0-n]</param>
        /// <param name="columnsStartIndex">内容开始列index[0-n]</param>
        /// <param name="headers">表头(一维)</param>
        /// <returns></returns>
        public static DataTable GetDataTable(ISheet sheet, int rowStartIndex, int columnsStartIndex, IEnumerable<string> headers, string dataTableName)
        {
            DataTable result;
            if (string.IsNullOrWhiteSpace(dataTableName))
            {
                result = new DataTable();
            }
            else
            {
                result = new DataTable(dataTableName);
            }
             

            if (headers != null && headers.Count() > 0)
            {
                if (rowStartIndex < 0)
                {
                    rowStartIndex = 0;
                }
                foreach (var item in headers)
                {
                    result.Columns.Add(item, item.GetType());
                }

                IEnumerator rowEnumerator = sheet.GetRowEnumerator();
                for (int i = 0; rowEnumerator.MoveNext(); i++)
                {
                    if (i >= sheet.FirstRowNum + rowStartIndex - 1)
                    {
                        IRow currentRow = (IRow)rowEnumerator.Current;
                        if (currentRow.Cells.Count >= result.Columns.Count)
                        {
                            DataRow dataRow = result.NewRow();
                            for (int j = 0; j < columnsStartIndex + result.Columns.Count; j++)
                            {
                                if (j >= columnsStartIndex)
                                {
                                    ICell cell = currentRow.GetCell(j);
                                    cell?.SetCellType(CellType.String);
                                    if (cell != null &&  cell.StringCellValue.Length > 0)
                                    {
                                        dataRow[j - columnsStartIndex] = cell.StringCellValue;
                                    }
                                    else
                                    {
                                        dataRow = null;
                                    }
                                }
                            }
                            if (dataRow != null)
                            {
                                result.Rows.Add(dataRow);
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 从文件流按照固定规则读取出DataSet集合
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(Stream stream)
        {
            DataSet result = new DataSet();
            XSSFWorkbook workbook;
            try
            {
                workbook = new XSSFWorkbook(stream);
            }
            catch (Exception exception)
            {
                throw exception;
            }

            ////result.Tables.Add(ExcelUtil.GetDataTable(workbook.GetSheet(BizTypeDataTableName), BizTypeRowStarIndex, BizTypeColumnStarIndex, BizTypeSheetHeader, BizTypeDataTableName));
            ////result.Tables.Add(ExcelUtil.GetDataTable(workbook.GetSheet(GoodsClassDataTableName), GoodsClassRowStarIndex, GoodsClassColumnStarIndex, GoodsClassSheetHeader, GoodsClassDataTableName));
            ////result.Tables.Add(ExcelUtil.GetDataTable(workbook.GetSheet(GoodsUnitDataTableName), GoodsUnitRowStarIndex, GoodsUnitColumnStarIndex, GoodsUnitSheetHeader, GoodsUnitDataTableName));
            ////result.Tables.Add(ExcelUtil.GetDataTable(workbook.GetSheet(GoodsDataTableName), GoodsRowStarIndex, GoodsColumnStarIndex, GoodsSheetHeader, GoodsDataTableName));

            return result;
        }

        /// <summary>
        /// 从DataSet按照固定规则写入文件模板
        /// </summary>
        /// <param name="data">DataSet数据（预定的格式）</param>
        /// <param name="stream">模板excel对象（从预定的格式模板生成）</param>
        /// <returns></returns>
        public static int SetDataSet2Workbook(DataSet data, XSSFWorkbook workbook)
        {
            int result = 0;
            if (data != null && data.Tables.Count >  0) 
            {
                IEnumerator sheetEnumerator = workbook.GetEnumerator();
                for (int i = 0; sheetEnumerator.MoveNext(); i++)
                {
                    //Sheet循环写入
                    ISheet sheet = (ISheet)sheetEnumerator.Current;
                    if (data.Tables.Contains(sheet.SheetName))
                    {
                        switch (sheet.SheetName)
                        {

                            case PurchasingOrderTotalDataTableName:
                                result += ExcelUtil.SetDataTable2Sheet(sheet, PurchasingOrderTotalRowStarIndex, PurchasingOrderTotalColumnStarIndex, PurchasingOrderTotalSheetHeader, data.Tables[PurchasingOrderTotalDataTableName]);
                                break;
                            case PurchasingOrderGoodsSubtotalDataTableName:
                                result += ExcelUtil.SetDataTable2Sheet(sheet, PurchasingOrderGoodsSubtotalRowStarIndex, PurchasingOrderGoodsSubtotalColumnStarIndex, PurchasingOrderGoodsSubtotalSheetHeader, data.Tables[PurchasingOrderGoodsSubtotalDataTableName]);
                                break;
                            case PurchasingOrderVendorSubtotalDataTableName:
                                result += ExcelUtil.SetDataTable2Sheet(sheet, PurchasingOrderVendorSubtotalRowStarIndex, PurchasingOrderVendorSubtotalColumnStarIndex, PurchasingOrderVendorSubtotalSheetHeader, data.Tables[PurchasingOrderVendorSubtotalDataTableName]);
                                break;
                                ////case GoodsUnitDataTableName:
                                ////    result += ExcelUtil.SetDataTable2Sheet(sheet, GoodsUnitRowStarIndex, GoodsUnitColumnStarIndex, GoodsUnitSheetHeader, data.Tables[GoodsUnitDataTableName]);
                                ////    break;
                        }
                    }

                }
            }

            return result;
        }

        /// <summary>
        /// 从DataTable写入到Sheet固定区域
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="rowStartIndex">内容开始行index[0-n]</param>
        /// <param name="columnsStartIndex">内容开始列index[0-n]</param>
        /// <param name="headers">表头(一维)</param>
        /// <returns>导出的行数量</returns>
        public static int SetDataTable2Sheet(ISheet sheet, int rowStartIndex, int columnsStartIndex, IEnumerable<string> headers, DataTable dataTable)
        {
            int result = 0;
            int xStart = sheet.FirstRowNum + rowStartIndex - 1;
            
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                int x = 0;
                foreach(DataRow dr in dataTable.Rows)
                {
                    int y = 0;
                    foreach (DataColumn dc in dataTable.Columns)
                    {
                        ICell cell = sheet.GetRow(xStart+x).GetCell(columnsStartIndex + y);
                        cell.SetCellValue(dr[dc.ColumnName].ToString());
                        y++;
                    }
                    x++;
                }
                result++;
            }

            return result;
        }

    }
}
