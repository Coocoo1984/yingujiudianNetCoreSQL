using System;
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

        public static DataTable GetPurchasingPlanCount4Dept()
        {
            DataTable result = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM ");
            sb.Append("view_purchasing_plan_count4dept");
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }
            return result;
        }

        public static DataTable GetBizTypes()
        {
            DataTable result = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM ");
            sb.Append("view_biz_type");
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }
            return result;
        }

        public static DataTable GetGoods()
        {
            DataTable result = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM ");
            sb.Append("view_goods");
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
                sb.Append("SELECT * FROM ");
                switch (state)
                {
                    case 1: sb.Append("view_purchasing_plan_list_4_dept_unconfirm"); break;
                    case 2: sb.Append("view_purchasing_plan_list_4_dept_confirm"); break;
                    case 3: sb.Append("view_purchasing_plan_list_4_dept_need_modify"); break;
                }

                sb.Append(" WHERE department_id = ");
                sb.Append(departmentID);
                try
                {
                    result = DBHelper.ExecuteTable(sb.ToString());
                }
                catch (Exception) { throw; }
            }
            return result;
        }

        public static DataTable GetPOLists4Dept(int departmentID)
        {
            DataTable result = null;
            if (departmentID > 1)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * FROM ");
                sb.Append("view_purchasing_order_list_4_dept");
                sb.Append(" WHERE department_id = ");
                sb.Append(departmentID);
                try
                {
                    result = DBHelper.ExecuteTable(sb.ToString());
                }
                catch (Exception) { throw; }
            }
            return result;
        }

        public static DataTable GetPODetailLists4Dept(int POid)
        {
            DataTable result = null;
            if (POid > 1)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * FROM ");
                sb.Append("view_purchasing_order_detail_list_4_dept");
                sb.Append(" AND pod.purchasing_order_id = ");
                sb.Append(POid);
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
            sb.Append("view_purchasing_plan_count_4_all");
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
            sb.Append("view_purchasing_plan_list_4_audit");
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
        /// <param name="purchasingPlanId"></param>
        /// <returns></returns>
        public static DataTable GetPurchasingPlanDetalGoodsCloassGroupCount(int purchasingPlanId)
        {
            DataTable result = null;
            if (purchasingPlanId > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * FROM ");
                sb.Append("view_purchasing_plan_detail_goods_class_group_count");
                sb.Append(" AND ppd.purchasing_plan_id = ");
                sb.Append(purchasingPlanId);
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
        /// 
        /// </summary>
        /// <param name="purchasingPlanId"></param>
        /// <returns></returns>
        public static DataTable GetPurchasingPlanDetailList(int purchasingPlanId)
        {
            DataTable result = null;
            if (purchasingPlanId > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * FROM ");
                sb.Append("view_purchasing_plan_detail_list");
                sb.Append(" AND ppd.purchasing_plan_id = ");
                sb.Append(purchasingPlanId);
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
        /// 
        /// </summary>
        /// <param name="bizTypeId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static DataTable GetGoodsClassQuoteCount(int bizTypeId, DateTime startTime, DateTime endTime)
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
            if (bizTypeId > 0)
            {
                sb.Append(" AND q.biz_type_id = ");
                sb.Append(bizTypeId);
            }

            if (startTime != null)
            {
                sb.Append(" AND q.create_time > ");
                sb.Append(Convert.ToString(startTime));
            }
            if (endTime != null)
            {
                sb.Append(" AND q.create_time < ");
                sb.Append(Convert.ToString(endTime));
            }
            try
            {
                result = DBHelper.ExecuteTable(sb.ToString());
            }
            catch (Exception) { throw; }
            finally { }

            return result;
        }

        public static DataTable GetGoodsQuoteDetailVendorPriceRange(int bizTypeId, DateTime startTime, DateTime endTime)
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
                ");
            if (bizTypeId > 0)
            {
                sb.Append(" AND q.biz_type_id = ");
                sb.Append(bizTypeId);
            }
            if (startTime != null)
            {
                sb.Append(" AND q.create_time > ");
                sb.Append(Convert.ToString(startTime));
            }
            if (endTime != null)
            {
                sb.Append(" AND q.create_time < ");
                sb.Append(Convert.ToString(endTime));
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

        public static DataTable GetGoodsQuoteDetailVendorList(int bizTypeId, DateTime startTime, DateTime endTime, int goodsId)
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
	qd.unit_price - qd.pre_unit_price AS up_down 
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
                ");

            if (bizTypeId > 0)
            {
                sb.Append(" AND q.biz_type_id = ");
                sb.Append(bizTypeId);
            }
            if (startTime != null)
            {
                sb.Append(" AND q.create_time > ");
                sb.Append(Convert.ToString(startTime));
            }
            if (endTime != null)
            {
                sb.Append(" AND q.create_time < ");
                sb.Append(Convert.ToString(endTime));
            }
            if (goodsId > 0)
            {
                sb.Append(" AND qd.goods_id = ");
                sb.Append(goodsId);
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

        public static DataTable GetQuoteListAll(DateTime startTime, DateTime endTime)
        {
            DataTable result = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM ");
            sb.Append("view_quote_list_all");
            if (startTime != null)
            {
                sb.Append(" AND q.create_time > ");
                sb.Append(Convert.ToString(startTime));
            }
            if (endTime != null)
            {
                sb.Append(" AND q.create_time < ");
                sb.Append(Convert.ToString(endTime));
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
        /// 采购需求部门获取按商品入库盘点数目
        /// </summary>
        /// <param name="bizTypeId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="listGoodsIds">匹配条件 多个商品id</param>
        /// <param name="deparmentId"></param>
        /// <returns></returns>
        public static DataTable GetStockIn4Dept(int bizTypeId, DateTime startTime, DateTime endTime, List<int> listGoodsIds, int deparmentId)
        {
            DataTable result = null;
            StringBuilder sb = new StringBuilder();
            sb.Append(@"
SELECT
	--po.id AS purchasing_order_id,
	--bt.biz_type_id,
	--bt.name AS biz_type_name,
	--po.department_id,
	--d.name AS department_name,
	--po.vendor_id,
	--v.name AS vendor_name,
	--po.create_time,
    --po.update_time,
	--po.purchasing_order_state_id,
	--pos.name AS purchasing_order_state_name,
	--pod.id AS purchasing_order_detail_id,
	pod.goods_class_id,
	gc.name AS goods_class_name,
	pod.goods_id,
	g.name AS goods_name,
	SUM(pod.actual_count) AS actual_count_sum,
    gu.name AS goods_unit_name
FROM
	purchasing_order AS po
	LEFT JOIN purchasing_order_state AS pos ON po.purchasing_order_state_id = pos.id
	LEFT JOIN department AS d ON po.department_id = d.id
	LEFT JOIN vendor AS v ON po.vendor_id = v.id
	LEFT JOIN purchasing_order_detail AS pod ON pod.purchasing_order_id = po.id
	LEFT JOIN goods_class AS gc ON pod.goods_class_id = gc.id
	LEFT JOIN goods AS g ON pod.goods_id = g.id
	LEFT JOIN goods_unit AS gu ON g.goods_unit_id = gc.id
	LEFT JOIN biz_type AS bt ON po.biz_type_id = bt.id 
WHERE
	po.purchasing_order_state_id = 3 
	AND po.purchasing_order_state_id = 4
                ");

            if (bizTypeId > 0)
            {
                sb.Append(" AND po.biz_type_id = ");
                sb.Append(bizTypeId);
            }
            if (startTime != null)
            {
                sb.Append(" AND po.update_time > ");
                sb.Append(Convert.ToString(startTime));
            }
            if (endTime != null)
            {
                sb.Append(" AND po.update_time < ");
                sb.Append(Convert.ToString(endTime));
            }
            if (listGoodsIds != null && listGoodsIds.Count > 0)
            {
                sb.Append(" AND pod.goods_id = ");
                sb.Append(string.Join(',', listGoodsIds.ToArray()));
            }
            sb.Append(" GROUP BY pod.goods_id");
            sb.Append(" ORDER BY g.id");
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
