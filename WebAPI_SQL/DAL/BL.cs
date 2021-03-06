﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
    public static class BL
    {
        public static DataTable QuerySQL(string SQL)
        {
            DataTable result = null;
            try
            {
                if (!string.IsNullOrWhiteSpace(SQL))
                {
                    result = DBHelper.ExecuteTable(SQL);
                }
            }
            catch (Exception) { throw; }
            finally { }
            return result;
        }

        #region 采购需求部门

        /// <summary>
        /// 采购需求部门 首页统计
        /// </summary>
        /// <returns></returns>
        public static DataTable GetPurchasingPlanCount4Dept()
        {
            DataTable result = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM ");
            sb.Append(" view_purchasing_plan_count_4_dept");
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }
            return result;
        }

        /// <summary>
        /// 采购需求部门 首页统计
        /// </summary>
        /// <returns></returns>
        public static DataTable GetPurchasingPlanCount4Dept(int departmentID)
        {
            DataTable result = null;
            StringBuilder sb = new StringBuilder();
            if(departmentID >0)
            {
                sb.Append(
@"
SELECT 
    '未确认' AS [description], 
    COUNT ([pp1].[id]) AS [count], 
    [pp1].[purchasing_state_id] AS [state],
    [pp1].[department_id] AS [department_id] 
FROM
    [purchasing_plan] AS [pp1] 
WHERE 
    [pp1].[purchasing_state_id] = 1 ");

                sb.Append($"    AND [pp1].[department_id] = {departmentID}");
                sb.Append(
@"
UNION
SELECT 
    '采购成功' AS [description],  
    COUNT ([pp2].[id]) AS [count], 
    [pp2].[purchasing_state_id] AS [state], 
    [pp2].[department_id] AS [department_id] 
FROM
    [purchasing_plan] AS [pp2] 
WHERE
    [pp2].[purchasing_state_id] = 6 ");
                sb.Append($"    AND [pp2].[department_id] = {departmentID}");
            }
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }
            return result;
        }




        #endregion



        public static DataTable GetBizTypes(bool? disable)
        {
            DataTable result = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM ");
            sb.Append(" view_biz_type");
            if (disable != null)
            {
                sb.Append($" WHERE disable = { disable.Value }");
            }
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }
            return result;
        }

        public static DataTable GetDepartments(bool? disable)
        {
            DataTable result = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM ");
            sb.Append(" view_department");
            if (disable != null)
            {
                sb.Append($" WHERE disable = { disable.Value }");
            }
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }
            return result;
        }

        public static DataTable GetUsrs(bool? disable)
        {
            DataTable result = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM ");
            sb.Append(" usr ");
            if (disable != null)
            {
                sb.Append($" WHERE disable = { disable.Value }");
            }
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }
            return result;
        }

        public static DataTable GetVendors(bool? disable)
        {
            DataTable result = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM");
            sb.Append(" vendor ");
            if (disable != null)
            {
                sb.Append($" WHERE disable = { disable.Value }");
            }
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }
            return result;
        }

        public static DataTable GetGoods(bool? disable)
        {
            DataTable result = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM");
            sb.Append(" view_goods ");
            if (disable != null)
            {
                sb.Append($" WHERE disable = { disable.Value }");
            }
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }
            return result;
        }

        public static DataTable GetGoodsClass(bool? disable)
        {
            DataTable result = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM");
            sb.Append(" view_goods_class ");
            if (disable != null)
            {
                sb.Append($" WHERE disable = { disable.Value }");
            }
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }
            return result;
        }

        /// <summary>
        /// 需求部门获取采购单列表
        /// </summary>
        /// <param name="departmentID">部门id</param>
        /// <param name="state">1：未确认;2:待审核;3:需要修改</param>
        /// <returns></returns>
        public static DataTable GetPurchasingPlanLists4Dept(int departmentID, int state)
        {
            DataTable result = null;
            if (state == 1 || state == 2 || state == 3)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * FROM    ");
                switch (state)
                {
                    case 1: sb.Append(" view_purchasing_plan_list_4_dept_unconfirm"); break;
                    case 2: sb.Append(" view_purchasing_plan_list_4_dept_confirm"); break;
                    case 3: sb.Append(" view_purchasing_plan_list_4_dept_need_modify"); break;
                }
                if (departmentID > 0)
                {
                    sb.Append(string.Format(" WHERE department_id = {0}", departmentID));
                }
                try
                {
                    result = DBHelper.ExecuteTable(sb.ToString());
                }
                catch (Exception) { throw; }
            }
            return result;
        }

        public static DataTable GetPurchasingOrderList4Dept(int departmentID)
        {
            DataTable result = null;
            if (departmentID > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * FROM");
                sb.Append(" view_purchasing_order_list_4_dept");
                sb.Append($" WHERE department_id = {departmentID}");
                try
                {
                    result = DBHelper.ExecuteTable(sb.ToString());
                }
                catch (Exception) { throw; }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTable GetPurchasingOrderGoodsCountStatics(List<int> listBizTypeIDs, List<int> listDepartmentIDs, List<int> listGoodsClassIDs, List<int> listGoodsIDs, List<int> listPOStateIDs, DateTime? startTime, DateTime? endTime)
        {
            DataTable result = null;
            StringBuilder sb = new StringBuilder();
            sb.Append(@"
SELECT
	goods_class_name,
	goods_name,
	SUM( count ),
	SUM( actual_count ),
	goods_unit_name 
FROM
(
    SELECT
        *
    FROM
        view_statics_po_goods_count
)
WHERE
    1=1
");
            if (listPOStateIDs != null && listPOStateIDs.Count > 0)
            {
                sb.Append($"    AND po_purchasing_order_state_id in ({ string.Join(',', listPOStateIDs.ToArray()) }) ");
            }
            if (listBizTypeIDs != null && listBizTypeIDs.Count > 0)
            {
                sb.Append($"    AND biz_type_id in ({ string.Join(',', listBizTypeIDs.ToArray()) }) ");
            }
            if (listDepartmentIDs != null && listDepartmentIDs.Count > 0)
            {
                sb.Append($"    AND department_id in ({ string.Join(',', listDepartmentIDs.ToArray()) }) ");
            }
            if (listGoodsClassIDs != null && listGoodsClassIDs.Count > 0)
            {
                sb.Append($"    AND goods_class_id in ({ string.Join(',', listGoodsClassIDs.ToArray()) }) ");
            }
            if (listGoodsIDs != null && listGoodsIDs.Count > 0)
            {
                sb.Append($"    AND goods_id in ({ string.Join(',', listGoodsIDs.ToArray()) }) ");
            }
            if (startTime != null)
            {
                sb.Append($"    AND create_time > '{ startTime.Value.ToString("yyyy-MM-dd HH:mm:ss") }' \r\n");
            }
            if (endTime != null)
            {
                sb.Append($"    AND create_time < '{ endTime.Value.ToString("yyyy-MM-dd HH:mm:ss") }' ");
            }
            sb.Append(@"
GROUP BY
	goods_id
");

            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }

            return result;
        }

        public static DataTable GetPurchasingOrderTotal(List<int> listDepartmentIDs, List<int> listBizTypeIDs, List<int> listPOStateIDs, DateTime? startTime, DateTime? endTime)
        {
            DataTable result = null;



            StringBuilder sb = new StringBuilder();
            sb.Append(@"
SELECT
    department_name,
    biz_type_name,
    total,
    create_time,
    vendor_name
FROM
    view_statics_po_dept_total
WHERE
    1=1
");

            if (listPOStateIDs != null && listPOStateIDs.Count > 0)
            {
                sb.Append($"    AND po_purchasing_order_state_id in ({ string.Join(',', listPOStateIDs.ToArray()) }) ");
            }
            if (listDepartmentIDs != null && listDepartmentIDs.Count > 0)
            {
                sb.Append($"    AND department_id in ({ string.Join(',', listDepartmentIDs.ToArray()) }) ");
            }
            if (listBizTypeIDs != null && listBizTypeIDs.Count > 0)
            {
                sb.Append($"    AND biz_type_id in ({ string.Join(',', listBizTypeIDs.ToArray()) }) ");
            }
            if (startTime != null)
            {
                sb.Append($"    AND create_time > '{ startTime.Value.ToString("yyyy-MM-dd HH:mm:ss") }' ");
            }
            if (endTime != null)
            {
                sb.Append($"    AND create_time < '{ endTime.Value.ToString("yyyy-MM-dd HH:mm:ss") }' ");
            }
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            return result;
        }

        public static DataTable GetPurchasingOrderGoodsSubtotal(List<int> listDepartmentIDs, List<int> listBizTypeIDs, List<int> listGoodsClassIDs, List<int> listGoodsIDs, List<int> listPOStateIDs, DateTime? startTime, DateTime? endTime)
        {
            DataTable result = null;

            StringBuilder sb = new StringBuilder();
            sb.Append(@"
SELECT
    department_name,
    biz_type_name,
    goods_class_name,
    goods_name,
    subtotal,
    create_time,
    vendor_name
FROM
    view_statics_dept_goods_subtotal
WHERE
    1=1
");
            if (listPOStateIDs != null && listPOStateIDs.Count > 0)
            {
                sb.Append($"    AND po_purchasing_order_state_id in ({ string.Join(',', listPOStateIDs.ToArray()) }) ");
            }
            if (listDepartmentIDs != null && listDepartmentIDs.Count > 0)
            {
                sb.Append($"    AND department_id in ({ string.Join(',', listDepartmentIDs.ToArray()) }) ");
            }
            if (listBizTypeIDs != null && listBizTypeIDs.Count > 0)
            {
                sb.Append($"    AND biz_type_id in ({ string.Join(',', listBizTypeIDs.ToArray()) }) ");
            }
            if (listGoodsClassIDs != null && listGoodsClassIDs.Count > 0)
            {
                sb.Append($"    AND goods_class_id in ({ string.Join(',', listGoodsClassIDs.ToArray()) }) ");
            }
            if (listGoodsIDs != null && listGoodsIDs.Count > 0)
            {
                sb.Append($"    AND goods_id in ({ string.Join(',', listGoodsIDs.ToArray()) }) ");
            }
            if (startTime != null)
            {
                sb.Append($"    AND create_time > '{ startTime.Value.ToString("yyyy-MM-dd HH:mm:ss") }' ");
            }
            if (endTime != null)
            {
                sb.Append($"    AND create_time < '{ endTime.Value.ToString("yyyy-MM-dd HH:mm:ss") }' ");
            }

            sb.Append($"    ORDER BY  department_id");

            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            return result;
        }

        public static DataTable GetPurchasingOrderVendorSubtotal(List<int> listVendorIDs, List<int> listBizTypeIDs, List<int> listGoodsClassIDs, List<int> listGoodsIDs, List<int> listPOStateIDs, DateTime? startTime, DateTime? endTime)
        {
            DataTable result = null;

            StringBuilder sb = new StringBuilder();
            sb.Append(@"
SELECT
    vendor_name,
    biz_type_name,
    goods_class_name,
    goods_name,
    unit_price,
    count_for_show,
    actual_subtotal,
    create_time
FROM
    view_statics_vendor_goods_subtotal
WHERE
    1=1
");
            if (listPOStateIDs != null && listPOStateIDs.Count > 0)
            {
                sb.Append($"    AND po_purchasing_order_state_id in ({ string.Join(',', listPOStateIDs.ToArray()) }) ");
            }
            if (listVendorIDs != null && listVendorIDs.Count > 0)
            {
                sb.Append($"    AND vendor_id in ({ string.Join(',', listVendorIDs.ToArray()) }) ");
            }

            if (listBizTypeIDs != null && listBizTypeIDs.Count > 0)
            {
                sb.Append($"    AND biz_type_id in ({ string.Join(',', listBizTypeIDs.ToArray()) }) ");
            }
            if (listGoodsClassIDs != null && listGoodsClassIDs.Count > 0)
            {
                sb.Append($"    AND goods_class_id in ({ string.Join(',', listGoodsClassIDs.ToArray()) }) ");
            }
            if (listGoodsIDs != null && listGoodsIDs.Count > 0)
            {
                sb.Append($"    AND goods_id in ({ string.Join(',', listGoodsIDs.ToArray()) }) ");
            }
            if (startTime != null)
            {
                sb.Append($"    AND create_time > '{ startTime.Value.ToString("yyyy-MM-dd HH:mm:ss") }' \r\n");
            }
            if (endTime != null)
            {
                sb.Append($"    AND create_time < '{ endTime.Value.ToString("yyyy-MM-dd HH:mm:ss") }' ");
            }
            sb.Append($"    ORDER BY  [vendor_id]");
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }

            catch (Exception) { throw; }
            return result;
        }

        public static DataTable GetPurchasingOrderDetailList4Dept(int purchasingOrderID)
        {
            DataTable result = null;
            if (purchasingOrderID > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * FROM ");
                sb.Append(" view_purchasing_order_detail_list_4_dept");
                sb.Append(" WHERE purchasing_order_id = ");
                sb.Append(purchasingOrderID);
                try
                {
                    result = DBHelper.ExecuteTable(sb.ToString());
                }
                catch (Exception) { throw; }
            }
            return result;
        }

        public static DataTable GetPurchasingPlanCount4All()
        {
            DataTable result = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM ");
            sb.Append(" view_purchasing_plan_count_4_all");
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }
            return result;
        }

        public static DataTable GetPurchasingPlanCount4Audit()
        {
            DataTable result = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM ");
            sb.Append(" view_purchasing_plan_list_4_audit");
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }
            return result;
        }

        /// <summary>
        /// 待复审采购计划列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetPurchasingPlanCount4Audit2()
        {
            DataTable result = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM ");
            sb.Append(" view_purchasing_plan_list_4_audit2");
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }
            return result;
        }

        /// <summary>
        /// 待三审采购计划列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetPurchasingPlanCount4Audit3()
        {
            DataTable result = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM ");
            sb.Append(" view_purchasing_plan_list_4_audit3");
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }
            return result;
        }

        /// <summary>
        /// 待复审采购计划列表外层分组结构
        /// </summary>
        /// <param name="purchasingPlanID">必须</param>
        /// <returns></returns>
        public static DataTable GetPurchasingPlanGoodsClassListWithVendor(int purchasingPlanID)
        {
            DataTable result = null;
            if (purchasingPlanID > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * FROM ");
                sb.Append(" view_purchasing_plan_goods_class_list_with_vendor");
                sb.Append($" WHERE purchasing_plan_id = { purchasingPlanID }");
                try
                {
                    result = DBHelper.ExecuteTable(sb.ToString());
                }
                catch (Exception) { throw; }
                finally { }
            }
            return result;
        }

        /// <summary>
        /// 通过采购计划ID获取采购计划、供应商报价选择、采购计划明细
        /// </summary>
        /// <param name="purchasingPlanID">必须</param>
        /// <returns></returns>
        public static DataTable GetPurchasingPlanDetailList(int purchasingPlanID)
        {
            DataTable result = null;
            if (purchasingPlanID > 0)
            {
                StringBuilder sb = new StringBuilder();
                ////sb.Append("SELECT * FROM ");
                ////sb.Append(" view_purchasing_plan_detail_list WHERE ");
                ////sb.Append($" purchasing_plan_id = {purchasingPlanID}");
                ////sb.Append(" ORDER BY goods_id");
                ///
                sb.Append(@"
SELECT 
       [ppd].[purchasing_plan_id] AS [purchasing_plan_id], 
       [pp].code AS [purchasing_plan_code],
       [ppd].[goods_class_id], 
       [gc].[name] AS [goods_class_name], 
       [ppd].[goods_id] AS [goods_id], 
       [g].[name] AS [goods_name], 
       [g].[specification] AS [specification],
       [ppd].[count], 
       [gu].[name] AS [goods_unit_name],
       [ppd].[vendor_id] is not null AS [is_quote_relation],
       CASE WHEN [v].[name] IS NULL THEN '' ELSE [v].[name] END AS [vendor_name],
       CASE WHEN [qd].[unit_price] IS NULL THEN 0 ELSE [qd].[unit_price] END AS [unit_price],
       CASE WHEN [qd].[unit_price] IS NULL THEN 0 ELSE [qd].[unit_price]*[ppd].[count] END AS [subtotal]  
FROM   
       [purchasing_plan] AS [pp]
       LEFT JOIN [purchasing_plan_detail] AS [ppd] ON [ppd].[purchasing_plan_id] = [pp].[id]
       LEFT JOIN [goods_class] AS [gc] ON [ppd].[goods_class_id] = [gc].[id]
       LEFT JOIN [goods] AS [g] ON [ppd].[goods_id] = [g].[id]
       LEFT JOIN [goods_unit] AS [gu] ON [g].[goods_unit_id] = [gu].[id]
       LEFT JOIN [vendor] AS [v] ON [v].[id] = [ppd].[vendor_id]
       LEFT JOIN [quote_detail] AS [qd] ON [qd].[id] = [ppd].[quote_detail_id]
WHERE  1=1
"
);              sb.Append($"	AND purchasing_plan_id = {purchasingPlanID}");

                try
                {
                    result = DBHelper.ExecuteTable(sb.ToString());
                }
                catch (Exception) { throw; }
                finally { }
            }
            return result;
        }


        /// <summary>
        /// 采购计划复审时 1对1指定供应商 获取对应供应商列表
        /// </summary>
        /// <param name="purchasingPlanID"></param>
        /// <returns></returns>
        public static DataTable GetPurchasingPlanVendorQuetoSUM(int purchasingPlanID)
        {
            DataTable result = null;

            if (purchasingPlanID > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(@"
SELECT
-- 	pp.id AS purchasing_plan_id,
-- 	ppd.id AS purchasing_plan_detail_id,
-- 	ppd.goods_class_id,
-- 	ppd.goods_id,
-- 	ppd.quote_detail_id,
-- 	ppd.count,
-- 	qd.id,
-- 	qd.goods_class_id,
-- 	qd.goods_id,
-- 	qd.unit_price,
	q.vendor_id AS vendor_id,
	v.name AS vendor_name,
 	SUM( ppd.count * qd.unit_price ) AS subtotal
FROM
	purchasing_plan AS pp
	LEFT JOIN purchasing_plan_detail AS ppd ON ppd.purchasing_plan_id = pp.id
	LEFT JOIN quote_detail AS qd ON ppd.goods_id = qd.goods_id
	LEFT JOIN quote AS q ON qd.quote_id = q.id
	LEFT JOIN vendor AS v ON q.vendor_id = v.id 
WHERE
	q.disable = 0 
	AND qd.disable = 0
                ");
                sb.Append($"	AND ppd.purchasing_plan_id = {purchasingPlanID}");
                sb.Append(@"
GROUP BY
	v.id");
                sb.Append(@"
ORDER BY
	subtotal");
                try
                {
                    result = DBHelper.ExecuteTable(sb.ToString());
                }
                catch (Exception) { throw; }
                finally { }
            }
            return result;
        }

        /// <summary>
        /// 采购计划复审时 1对1指定供应商 获取对应供应商列表
        /// </summary>
        /// <param name="purchasingPlanID"></param>
        /// <returns></returns>
        public static DataTable GetPurchasingPlanVendorQuetoSUM(int purchasingPlanID, List<int> listGoodsID)
        {
            DataTable result = null;

            if (purchasingPlanID > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(@"
SELECT
-- 	pp.id AS purchasing_plan_id,
-- 	ppd.id AS purchasing_plan_detail_id,
-- 	ppd.goods_class_id,
-- 	ppd.goods_id,
-- 	ppd.quote_detail_id,
-- 	ppd.count,
-- 	qd.id,
-- 	qd.goods_class_id,
-- 	qd.goods_id,
-- 	qd.unit_price,
	q.vendor_id AS vendor_id,
	v.name AS vendor_name,
 	SUM( ppd.count * qd.unit_price ) AS subtotal
FROM
	purchasing_plan AS pp
	LEFT JOIN purchasing_plan_detail AS ppd ON ppd.purchasing_plan_id = pp.id
	LEFT JOIN quote_detail AS qd ON ppd.goods_id = qd.goods_id
	LEFT JOIN quote AS q ON qd.quote_id = q.id
	LEFT JOIN vendor AS v ON q.vendor_id = v.id 
WHERE
	q.disable = 0 
	AND qd.disable = 0
                ");
                sb.Append($"	AND ppd.purchasing_plan_id = {purchasingPlanID}");
                sb.Append($"    AND qd.goods_id in ( {string.Join(',', listGoodsID.ToArray())} )");
                sb.Append(@"
GROUP BY
	v.id");
                sb.Append(@"
ORDER BY
	subtotal");
                try
                {
                    result = DBHelper.ExecuteTable(sb.ToString());
                }
                catch (Exception) { throw; }
                finally { }
            }
            return result;
        }

        /// <summary>
        /// 选中采购中的某一商品类目，计算出对应类目的供应商的小计价格列表
        /// </summary>
        /// <param name="purchasingPlanID">必须</param>
        /// <param name="goodsClassID">必须</param>
        /// <param name="listGoodsID">必须</param>
        /// <returns></returns>
        public static DataTable GetPurchasingPlanGoodsClassVendorQuetoSUM(int purchasingPlanID, int goodsClassID, List<int> listGoodsID)
        {
            DataTable result = null;

            if (goodsClassID > 0 && listGoodsID != null && listGoodsID.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(@"
SELECT
-- 	pp.id AS purchasing_plan_id,
-- 	ppd.id AS purchasing_plan_detail_id,
-- 	ppd.goods_class_id,
-- 	ppd.goods_id,
-- 	ppd.quote_detail_id,
-- 	ppd.count,
-- 	qd.id,
-- 	qd.goods_class_id,
-- 	qd.goods_id,
-- 	qd.unit_price,
	q.vendor_id AS vendor_id,
	v.name AS vendor_name,
 	SUM( ppd.count * qd.unit_price ) AS subtotal
FROM
	purchasing_plan AS pp
	LEFT JOIN purchasing_plan_detail AS ppd ON ppd.purchasing_plan_id = pp.id
	LEFT JOIN quote_detail AS qd ON ppd.goods_id = qd.goods_id
	LEFT JOIN quote AS q ON qd.quote_id = q.id
	LEFT JOIN vendor AS v ON q.vendor_id = v.id 
WHERE
	q.disable = 0 
	AND qd.disable = 0
    AND q.quote_state_id = 6
                ");
                sb.Append($"	AND ppd.purchasing_plan_id = {purchasingPlanID}");
                sb.Append($"	AND ppd.goods_class_id = {goodsClassID}");
                sb.Append($"    AND qd.goods_id in ( {string.Join(',', listGoodsID.ToArray())} )");
                sb.Append(@"
GROUP BY
	v.id");
                sb.Append(@"
ORDER BY
	subtotal");
                //quote_state_id = 6 供应商报价二审通过
                try
                {
                    result = DBHelper.ExecuteTable(sb.ToString());
                }
                catch (Exception) { throw; }
                finally { }
            }
            return result;
        }
 
        /// <summary>
        /// 采购进度 - 取得所有订单
        /// </summary>
        /// <returns></returns>
        public static DataTable GetPurchasingOrderList()
        {
            DataTable result = null;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM ");
            sb.Append(" view_purchasing_order_list");
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }
            return result;
        }

        /// <summary>
        /// 采购进度 - 通过订单ID获取订单收货详情
        /// </summary>
        /// <param name="purchasingOrderID">必须</param>
        /// <returns></returns>
        public static DataTable GetPurchasingOrderDetailList(int purchasingOrderID)
        {
            DataTable result = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM ");
            sb.Append(" view_purchasing_order_detail_list WHERE 1=1 ");
            if (purchasingOrderID > 0)
            {
                sb.Append($" AND purchasing_order_id = {purchasingOrderID}");
            }
            sb.Append(" ORDER BY goods_id");
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }
            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="bizTypeID">0</param>
        /// <param name="startTime">null</param>
        /// <param name="endTime">null</param>
        /// <returns></returns>
        public static DataTable GetGoodsClassQuoteCount(int bizTypeID, DateTime? startTime, DateTime? endTime)
        {
            DataTable result = null;
            StringBuilder sb = new StringBuilder();
            sb.Append(@"
SELECT
    gc.name AS goods_class_name,
	COUNT(qd.id) AS quote_detail_count
FROM
    quote AS q
    LEFT JOIN quote_detail AS qd ON qd.quote_id = q.id
    LEFT JOIN goods_class AS gc ON qd.goods_class_id = gc.id
    LEFT JOIN biz_type AS bt ON q.biz_type_id = bt.id
WHERE
    q.disable = 0
    AND qd.disable = 0
                ");
            if (bizTypeID > 0)
            {
                sb.Append($" AND q.biz_type_id = {bizTypeID}");
            }

            if (startTime != null)
            {
                sb.Append($" AND q.create_time > '{ startTime.Value.ToString("yyyy-MM-dd HH:mm:ss") }' \r\n");
            }
            if (endTime != null)
            {
                sb.Append($" AND q.create_time < '{ endTime.Value.ToString("yyyy-MM-dd HH:mm:ss") }' ");
            }
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bizTypeID">0</param>
        /// <param name="startTime">null</param>
        /// <param name="endTime">null</param>
        /// <returns></returns>
        public static DataTable GetGoodsQuoteDetailVendorPriceRange(int bizTypeID, DateTime? startTime, DateTime? endTime)
        {
            DataTable result = null;
            StringBuilder sb = new StringBuilder();
            sb.Append(@"
SELECT
	qd.goods_class_id,
	gc.name AS goods_class_name,
	qd.goods_id,
	g.name AS goods_name,
	count( q.vendor_id ) AS vendor_count,
	MIN( qd.unit_price ) AS min_unit_price,
	MAX( qd.unit_price ) AS max_unit_price 
FROM
	quote AS q
	LEFT JOIN quote_detail AS qd ON qd.quote_id = q.id
	LEFT JOIN goods_class AS gc ON qd.goods_class_id = gc.id
	LEFT JOIN vendor AS v ON q.vendor_id = v.id
	LEFT JOIN biz_type AS bt ON q.biz_type_id = bt.id
	LEFT JOIN goods AS g ON qd.goods_id = g.id 
WHERE
	q.disable = 0 
    AND qd.disable = 0
	AND gc.disable = 0
    AND v.disable = 0
                ");
            if (bizTypeID > 0)
            {
                sb.Append($" AND q.biz_type_id = ");
                sb.Append(bizTypeID);
            }
            if (startTime != null)
            {
                sb.Append($" AND q.create_time > '{ startTime.Value.ToString("yyyy-MM-dd HH:mm:ss") }' ");
            }
            if (endTime != null)
            {
                sb.Append($"    AND q.create_time < '{ endTime.Value.ToString("yyyy-MM-dd HH:mm:ss") }' ");
            }
            sb.Append(" GROUP BY goods_id");
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bizTypeID">0</param>
        /// <param name="startTime">null</param>
        /// <param name="endTime">null</param>
        /// <param name="goodsID">0</param>
        /// <returns></returns>
        public static DataTable GetGoodsQuoteDetailVendorList(int bizTypeID, DateTime? startTime, DateTime? endTime, int goodsID)
        {
            DataTable result = null;
            StringBuilder sb = new StringBuilder();
            sb.Append(@"
SELECT
	q.id AS quote_id,
	q.create_time AS quote_create_time,
	q.vendor_id,
	v.name AS vendor_name,
	qd.id AS quote_detail_id,
	qd.goods_class_id,
	qd.goods_id,
	qd.unit_price,
	qd.pre_unit_price,
	g.name AS goods_name,
	qd.unit_price - 0.00 AS up_down 
FROM
	quote AS q
	LEFT JOIN quote_detail AS qd ON qd.quote_id = q.id
	LEFT JOIN goods_class AS gc ON qd.goods_class_id = gc.id
	LEFT JOIN vendor AS v ON q.vendor_id = v.id
	LEFT JOIN biz_type AS bt ON q.biz_type_id = bt.id
	LEFT JOIN goods AS g ON qd.goods_id = g.id 
WHERE
	q.disable = 0
    AND v.disable = 0
                ");

            if (bizTypeID > 0)
            {
                sb.Append(" AND q.biz_type_id = ");
                sb.Append(bizTypeID);
            }
            if (startTime != null)
            {
                sb.Append($" AND q.create_time > '{ startTime.Value.ToString("yyyy-MM-dd HH:mm:ss") }' ");
            }
            if (endTime != null)
            {
                sb.Append($" AND q.create_time < '{ endTime.Value.ToString("yyyy-MM-dd HH:mm:ss") }' ");
            }
            if (goodsID > 0)
            {
                sb.Append($" AND qd.goods_id = {goodsID} ");
            }
            sb.Append(" ORDER BY unit_price");
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }

            return result;
        }

        /// <summary>
        /// 采购计划复审中 查看供应商报价明细（对应采购计划的商品）
        /// </summary>
        /// <param name="purchasiongPlanID">采购计划ID</param>
        /// <param name="vendorID">供应商ID</param>
        /// <returns></returns>
        public static DataTable GetPurchasingPlanVendorQuoteDetail(int purchasiongPlanID, int vendorID)
        {
            DataTable result = null;
            StringBuilder sb = new StringBuilder();
            sb.Append(@"
SELECT
 	pp.id AS purchasing_plan_id,
 	ppd.id AS purchasing_plan_detail_id,
 	ppd.quote_detail_id,
 	ppd.count AS purchasing_plan_detail_count,
 	qd.id AS quote_id,
 	qd.goods_class_id,
 	qd.goods_id,
 	qd.unit_price,
	q.vendor_id AS vendor_id,
    q.create_time,
	v.name AS vendor_name
FROM
	purchasing_plan AS pp
	LEFT JOIN purchasing_plan_detail AS ppd ON ppd.purchasing_plan_id = pp.id
	LEFT JOIN quote_detail AS qd ON ppd.goods_id = qd.goods_id
	LEFT JOIN quote AS q ON qd.quote_id = q.id
	LEFT JOIN vendor AS v ON q.vendor_id = v.id 
WHERE
	q.disable = 0 
	AND qd.disable = 0
");
            if (purchasiongPlanID > 0)
            {
                sb.Append(" AND pp.id = '{ purchasiongPlanID }'");
            }
            if(vendorID > 0)
            {
                sb.Append(" AND v.id = '{ vendorID }'");
            }
            sb.Append(" ORDER BY q.create_time DESC");
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disable">null:无该条件 默认为0:启用</param>
        /// <param name="startTime">null:无该条件</param>
        /// <param name="endTime">null:无该条件</param>
        /// <returns></returns>
        public static DataTable GetQuoteListAll(bool? disable, List<int> listquoteStateIDs, DateTime? startTime, DateTime? endTime)
        {
            DataTable result = null;
            StringBuilder sb = new StringBuilder();

            sb.Append(
@"
SELECT 
       [q].[id] AS [quote_id], 
       [q].[vendor_id] AS [vendor_id], 
       [v].[name] AS [vendor_name], 
       [q].[create_time] AS [quote_create_time], 
       [q].[biz_type_id] AS [quote_biz_type_id], 
       [bt].[name] AS [biz_type_name], 
       [q].[disable] AS [disable],
       [q].[quote_state_id] AS [quote_state_id],
       [qs].[name] AS [quote_state_name]
FROM   [quote] AS [q]
       LEFT JOIN [vendor] AS [v] ON [q].[vendor_id] = [v].[id]
       LEFT JOIN [biz_type] AS [bt] ON [q].[biz_type_id] = [bt].[id]
       LEFT JOIN [quote_state] AS [qs] ON [q].[quote_state_id] = [qs].[id]
WHERE
       1=1 AND quote_state_id > 0
        
"
);
            if (disable != null)
            {
                sb.Append($" AND q.disable = { disable.Value }");
            }
            if (startTime != null)
            {
                sb.Append($" AND quote_create_time > '{ startTime.Value.ToString("yyyy-MM-dd HH:mm:ss") }' ");
            }
            if (endTime != null)
            {
                sb.Append($" AND quote_create_time < '{ endTime.Value.ToString("yyyy-MM-dd HH:mm:ss") }' ");
            }
            if (listquoteStateIDs != null && listquoteStateIDs.Count > 0)
            {
                sb.Append($" AND quote_state_id in ({ string.Join(',', listquoteStateIDs.ToArray()) }) ");
            }
            sb.Append(" ORDER BY  quote_create_time DESC");
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }

            return result;
        }



       /// <summary>
       /// 库存综合查询
       /// </summary>
       /// <param name="listBizTypeIDs"></param>
       /// <param name="listGoodsClassIDs"></param>
       /// <param name="listGoodsIDs"></param>
       /// <param name="listDeparmentIDs"></param>
       /// <param name="listVendorIDs"></param>
       /// <param name="listPOStateIDs"></param>
       /// <param name="startTime"></param>
       /// <param name="endTime"></param>
       /// <returns></returns>
        public static DataTable GetStock(List<int> listBizTypeIDs, List<int> listGoodsClassIDs, List<int> listGoodsIDs, List<int> listDeparmentIDs, List<int> listVendorIDs, List<int> listPOStateIDs, DateTime? startTime, DateTime? endTime)
        {
            DataTable result = null;
            StringBuilder sb = new StringBuilder();
            sb.Append(@"
SELECT
	pod.goods_class_id AS goods_class_id,
	gc.name AS goods_class_name,
	pod.goods_id AS goods_id,
	g.name AS goods_name,
	SUM(pod.actual_count) AS actual_count_sum,
    gu.name AS goods_unit_name
FROM
	purchasing_order_detail AS pod
	LEFT JOIN goods_class AS gc ON pod.goods_class_id = gc.id
	LEFT JOIN goods AS g ON pod.goods_id = g.id
	LEFT JOIN goods_unit AS gu ON g.goods_unit_id = gu.id
	LEFT JOIN purchasing_order AS po ON pod.purchasing_order_id = po.id
    LEFT JOIN purchasing_order_state AS pos ON po.purchasing_order_state_id = pos.id
	LEFT JOIN department AS d ON po.department_id = d.id
	LEFT JOIN vendor AS v ON po.vendor_id = v.id
	LEFT JOIN biz_type AS bt ON po.biz_type_id = bt.id 
WHERE
	1=1
");

            if (startTime != null)
            {
                sb.Append($" AND po.update_time > '{ startTime.Value.ToString("yyyy-MM-dd HH:mm:ss") }' ");
            }
            if (endTime != null)
            {
                sb.Append($" AND po.update_time < '{endTime.Value.ToString("yyyy-MM-dd HH:mm:ss")}' ");
            }
            if (listPOStateIDs != null && listPOStateIDs.Count > 0)
            {
                sb.Append($" AND pos.id in ({ string.Join(',', listPOStateIDs.ToArray()) }) ");
            }
            if (listDeparmentIDs != null && listDeparmentIDs.Count > 0)
            {
                sb.Append($" AND po.department_id in ({ string.Join(',', listDeparmentIDs.ToArray()) }) ");
            }
            if (listVendorIDs != null && listVendorIDs.Count > 0)
            {
                sb.Append($" AND po.vendor_id in ({ string.Join(',', listVendorIDs.ToArray()) }) ");
            }
            if (listBizTypeIDs != null && listBizTypeIDs.Count > 0)
            {
                sb.Append($" AND po.biz_type_id in ({ string.Join(',', listBizTypeIDs.ToArray()) }) ");
            }
            if (listGoodsClassIDs != null && listGoodsClassIDs.Count > 0)
            {
                sb.Append($" AND pod.goods_class_id in ({ string.Join(',', listGoodsClassIDs.ToArray()) }) ");
            }
            if (listGoodsIDs != null && listGoodsIDs.Count > 0)
            {
                sb.Append($" AND pod.goods_id in ({ string.Join(',', listGoodsIDs.ToArray()) }) ");
            }

            sb.Append(" GROUP BY pod.goods_class_id,pod.goods_id");
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }
            return result;
        }

        /// <summary>
        /// 按部门盘存
        /// </summary>
        /// <param name="listBizTypeIDs"></param>
        /// <param name="listGoodsClassIDs"></param>
        /// <param name="listGoodsIDs"></param>
        /// <param name="listDeparmentIDs"></param>
        /// <param name="listVendorIDs"></param>
        /// <param name="listPOStateIDs"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static DataTable GetStockByDept(List<int> listBizTypeIDs, List<int> listGoodsClassIDs, List<int> listGoodsIDs, List<int> listDeparmentIDs, List<int> listVendorIDs, List<int> listPOStateIDs, DateTime? startTime, DateTime? endTime)
        {
            DataTable result = null;
            StringBuilder sb = new StringBuilder();
            sb.Append(@"
---------库存报表(用于按部门盘存)--------
SELECT
	d.name AS department_name,
	bt.name AS biz_type_name,
	g.name AS goods_name,
    SUM(pod.actual_count) AS actual_count_sum,
    gu.name AS goods_unit_name,
	pod.update_time AS stockin_time
FROM
	purchasing_order_detail AS pod
	LEFT JOIN goods_class AS gc ON pod.goods_class_id = gc.id
	LEFT JOIN goods AS g ON pod.goods_id = g.id
	LEFT JOIN goods_unit AS gu ON g.goods_unit_id = gu.id
	LEFT JOIN purchasing_order AS po ON pod.purchasing_order_id = po.id
    LEFT JOIN purchasing_order_state AS pos ON po.purchasing_order_state_id = pos.id
	LEFT JOIN department AS d ON po.department_id = d.id
	LEFT JOIN vendor AS v ON po.vendor_id = v.id
	LEFT JOIN biz_type AS bt ON po.biz_type_id = bt.id 
WHERE 1=1
                ");

            if (startTime != null)
            {
                sb.Append($" AND po.update_time > '{ startTime.Value.ToString("yyyy-MM-dd HH:mm:ss") }' ");
            }
            if (endTime != null)
            {
                sb.Append($" AND po.update_time < '{endTime.Value.ToString("yyyy-MM-dd HH:mm:ss")}' ");
            }
            if (listPOStateIDs != null && listPOStateIDs.Count > 0)
            {
                sb.Append($" AND pos.id in ({ string.Join(',', listPOStateIDs.ToArray()) }) ");
            }
            if (listDeparmentIDs != null && listDeparmentIDs.Count > 0)
            {
                sb.Append($" AND po.department_id in ({ string.Join(',', listDeparmentIDs.ToArray()) }) ");
            }
            if (listVendorIDs != null && listVendorIDs.Count > 0)
            {
                sb.Append($" AND po.vendor_id in ({ string.Join(',', listVendorIDs.ToArray()) }) ");
            }
            if (listBizTypeIDs != null && listBizTypeIDs.Count > 0)
            {
                sb.Append($" AND po.biz_type_id in ({ string.Join(',', listBizTypeIDs.ToArray()) }) ");
            }
            if (listGoodsClassIDs != null && listGoodsClassIDs.Count > 0)
            {
                sb.Append($" AND pod.goods_class_id in ({ string.Join(',', listGoodsClassIDs.ToArray()) }) ");
            }
            if (listGoodsIDs != null && listGoodsIDs.Count > 0)
            {
                sb.Append($" AND pod.goods_id in ({ string.Join(',', listGoodsIDs.ToArray()) }) ");
            }
            sb.Append(" GROUP BY po.department_id, pod.goods_id");
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }

            return result;
        }

        /// <summary>
        /// 获取供应商对应的报价单结构
        /// </summary>
        /// <param name="vendorID"></param>
        /// <param name="bizTypeID">null</param>
        /// <returns></returns>
        public static DataTable GetQuoteDetailList4Vendor2Quote(int vendorID, List<int> listBizTypeIDs)
        {
            DataTable result = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM");
            sb.Append(" view_quote_detail_list_4_vendor_quote WHERE 1=1 ");
            if (vendorID > 0)
            {
                sb.Append($" AND vendor_id = {vendorID}");
            }
            if (listBizTypeIDs != null && listBizTypeIDs.Count > 0)
            {
                sb.Append($" AND biz_type_id in ({ string.Join(',', listBizTypeIDs.ToArray()) }) ");
            }
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }

            return result;
        }


        /// <summary>
        /// 获取报价明细
        /// </summary>
        /// <param name="quoteID"></param>
        /// <returns></returns>
        public static DataTable GetQuoteDetailListByQuoteID(int quoteID)
        {
            DataTable result = null;
            StringBuilder sb = new StringBuilder();
            ////sb.Append("SELECT * FROM");
            ////sb.Append(" view_goods_quote_list WHERE 1=1 ");
            if (quoteID > 0)
            {
                sb.Append(
$@"
SELECT 
       g.name AS goods_name, 
       g.specification AS goods_specification,
       qd.unit_price AS unit_price, 
       gu.name AS goods_unit,
       qd.id, 
       qd.goods_class_id, 
       qd.goods_id, 
       q.id AS quote_id, 
       q.vendor_id AS vendor_id, 
       gc.name AS goods_class_name
FROM   quote AS q
       left join quote_detail AS qd on q.id = qd.quote_id
       left join goods AS g on qd.goods_id = g.id
       LEFT JOIN goods_unit AS gu on g.goods_unit_id = gu.id
       left join goods_class AS gc on qd.goods_class_id = gc.id
WHERE
       q.id = {quoteID}
");
            }

            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }

            return result;
        }

        /// <summary>
        /// 获取供应商的订单列表(按状态排序)
        /// </summary>
        /// <param name="bizTypeID">0</param>
        /// <param name="startTime">0</param>
        /// <param name="endTime">0</param>
        /// <param name="vendorID">0</param>
        /// <returns></returns>
        public static DataTable GetPurchasingOrderList4Vendor(int bizTypeID, DateTime? startTime, DateTime? endTime, int vendorID)
        {
            DataTable result = null;
            StringBuilder sb = new StringBuilder();
            sb.Append(@"
SELECT
	po.id AS po_id,
	po.code AS po_code,
	po.item_count AS po_item_count,
	po.department_id,
	d.name AS department_name,
	po.create_time AS purchasing_order_create_time,
	d.id,
	d.mobile,
	d.tel,
	d.addr,
	po.purchasing_order_state_id,
	pos.name AS purchasing_order_state_name 
FROM
	purchasing_order AS po
	LEFT JOIN purchasing_order_state AS pos ON po.purchasing_order_state_id = pos.id
	LEFT JOIN department AS d ON po.department_id = d.id
	LEFT JOIN vendor AS v ON po.vendor_id = v.id 
WHERE
    1=1
");
            if (vendorID > 0)
            {
                sb.Append($" AND po.vendor_id = {vendorID} ");
            }
            if (bizTypeID > 0)
            {
                sb.Append($" AND po.biz_type_id = {bizTypeID} ");
            }
            if (startTime != null)
            {
                sb.Append($" AND po.create_time > '{startTime.Value.ToString("yyyy-MM-dd HH:mm:ss")}'");
            }
            if (endTime != null)
            {
                sb.Append($" AND po.create_time < '{ endTime.Value.ToString("yyyy-MM-dd HH:mm:ss") }' ");
            }
            sb.Append($"    AND po.purchasing_order_state_id in (1,3,4,5,6,10,11) ");
            sb.Append(" ORDER BY po.purchasing_order_state_id");
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }
            return result;
        }

        /// <summary>
        /// 通过订单ID获取订单详情
        /// </summary>
        /// <param name="purchasingOrderID">0</param>
        /// <returns></returns>
        public static DataTable GetPurchasingOrderDetailList4Vendor(int purchasingOrderID)
        {
            DataTable result = null;
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT * FROM");
            sb.Append(" view_purchasing_order_detail_list_4_vendor WHERE 1=1 ");
            if (purchasingOrderID > 0)
            {
                sb.Append($" AND purchasing_order_id = {purchasingOrderID} ");
            }
            sb.Append(" ORDER BY goods_id");
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }
            return result;
        }

        /// <summary>
        /// 通过订单ID、采购计划ID 获取采购流程状态
        /// </summary>
        /// <param name="purchasingOrderID">0</param>
        /// <returns></returns>
        public static DataTable GetPurchasingStates(int purchasingOrderID)
        {
            DataTable result = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM");
            sb.Append(" view_purchasing_order_detail_list_4_vendor WHERE 1=1 ");
            if (purchasingOrderID > 0)
            {
                sb.Append($" AND purchasing_order_id = {purchasingOrderID} ");
            }
            sb.Append(" ORDER BY goods_id");
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }
            return result;
        }

        /// <summary>
        /// 获取权限
        /// </summary>
        /// <param name="usrWechatID">可不传</param>
        /// <param name="listPermissonIDs">可不传</param>
        /// <returns></returns>
        public static DataTable GetPermissionsByWechatID(string usrWechatID,  List<int> listPermissonIDs)
        {
            DataTable result = null;
            StringBuilder sb = new StringBuilder();
            sb.Append(@"
SELECT 
       [rs].[id] AS [id], 
       [rs].[usr_wechat_id] AS [usr_wechat_id], 
       [rs].[permission_id] AS [permission_id], 
       [rs].[disable] AS [disable], 
       [p].[name] AS [permission_name]
FROM   [rs_permission] [rs]
       LEFT JOIN [permission] [p] ON [rs].[permission_id] = [p].[id]
WHERE 
       1=1 AND 
       Disable = 0
");
            if (string.IsNullOrWhiteSpace(usrWechatID))
            {
                sb.Append($" AND biz_type_id = '{usrWechatID}'");
            }
            if (listPermissonIDs != null && listPermissonIDs.Count > 0)
            {
                sb.Append($" AND permission_id in ({ string.Join(',', listPermissonIDs.ToArray()) }) ");
            }
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }
            return result;
        }


        /// <summary>
        /// 获取退货按部门
        /// </summary>
        /// <returns></returns>
        public static DataTable GetChargeBackList(List<int> listStateIds, List<int> listBizTypeIDs, List<int> listDepartmentIDs, List<int> listVendorIDs, DateTime? startTime, DateTime? endTime)
        {
            DataTable result = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM ");
            sb.Append(" view_charge_back_list");
            sb.Append(" WHERE 1=1");
            if (listStateIds?.Count > 0)
            {
                sb.Append($" AND purchasing_order_state_id in ({ string.Join(',', listStateIds.ToArray()) }) ");
            }
            if (listDepartmentIDs?.Count > 0)
            {
                sb.Append($" AND department_id in ({ string.Join(',', listDepartmentIDs.ToArray()) }) ");
            }
            if (listVendorIDs?.Count > 0)
            {
                sb.Append($" AND vendor_id in ({ string.Join(',', listVendorIDs.ToArray()) }) ");
            }
            if (startTime != null)
            {
                sb.Append($"    AND create_time > '{ startTime.Value.ToString("yyyy-MM-dd HH:mm:ss") }' \r\n");
            }
            if (endTime != null)
            {
                sb.Append($"    AND create_time < '{ endTime.Value.ToString("yyyy-MM-dd HH:mm:ss") }' ");
            }
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }
            return result;
        }


        /// <summary>
        /// 取得所有退货
        /// </summary>
        /// <returns></returns>
        public static DataTable GetChargeBackList()
        {
            DataTable result = null;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM ");
            sb.Append(" view_charge_back_list");
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }
            return result;
        }

        /// <summary>
        /// 取得退货明细
        /// </summary>
        /// <returns></returns>
        public static DataTable GetChargeBackDetailList(int ChargeBackID, int OrderID, int PlanID)
        {
            DataTable result = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM ");
            sb.Append(" view_charge_back_detail_list");
            sb.Append(" WHERE 1=1");

            if (ChargeBackID > 0)
            {
                sb.Append($" AND charge_back_id = { ChargeBackID } ");
            }
            if (OrderID > 0)
            {
                sb.Append($" AND purchasing_order_id = { OrderID } ");
            }
            if (PlanID > 0)
            {
                sb.Append($" AND purchasing_plan_id = { PlanID } ");
            }
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }
            return result;
        }

        /// <summary>
        /// 取得采购计划/采购订单的审核记录
        /// </summary>
        /// <returns></returns>
        public static DataTable GetPAPOAuditList(int purchasingPlanID, int purchasingOrderID)
        {
            DataTable result = null;

                StringBuilder sb = new StringBuilder();
            sb.Append(@"
SELECT 
       [pa].[id],
       [pa].[audit_usr_id],
       [pa].[audit_time],
       [pa].[audit_type],
       CASE [pa].[audit_type] 
       WHEN 1 THEN '初审驳回' 
       WHEN 2 THEN '初审通过' 
       WHEN 3 THEN '复审驳回' 
       WHEN 4 THEN '复审通过' 
       WHEN 5 THEN '三审驳回' 
       WHEN 6 THEN '三审通过' 
       WHEN 7 THEN '订单被供应商否定' 
       WHEN 8 THEN '订单被供应商确认' 
       WHEN 9 THEN '供应商已发货' 
       WHEN 10 THEN '需求部门收货中' 
       WHEN 11 THEN '需求部门已完整收货'
       WHEN 12 THEN '需求部门发起退货'
       WHEN 13 THEN '采购中心驳回退货'
       WHEN 14 THEN '采购中心退货审核通过'
       WHEN 15 THEN '供应商确认退货'
       WHEN 16 THEN '需求部门确认退货完成'
       END AS [audit_type_name],
       [pa].[audit_desc],
       [pa].[purchasing_plan_id] AS [purchasing_plan_id],
       [pp].[department_id] AS [department_id],
       [d].[name] AS [department_name],
       [po].[id] AS [purchasing_order_id],
       [v].[id] AS [vendor_id],
       [d].[name] AS [vendor_name]
FROM
       purchasing_audit AS [pa]
       LEFT JOIN [purchasing_plan] AS [pp] ON [pa].[purchasing_plan_id] = [pp].[id]
       LEFT JOIN [department] AS [d] ON [pp].[department_id] = [d].[id]
       LEFT JOIN [purchasing_order] AS [po] ON [po].[purchasing_plan_id] = [pp].[id]
       LEFT JOIN [vendor] AS [v] ON [po].[vendor_id] = [v].[id]
WHERE
    1=1 
");
            if(purchasingPlanID >0)
            {
                sb.Append($" AND purchasing_plan_id = { purchasingPlanID } ");
            }
            else if(purchasingOrderID >0)
            {
                sb.Append($" AND purchasing_order_id = { purchasingOrderID } ");
            }
            sb.Append(@"
ORDER BY 
      [pa].[audit_time]
"
);
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }
            return result;
        }

    }
}
