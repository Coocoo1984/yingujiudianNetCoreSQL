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
            if(state==1 || state== 2 || state == 3)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * FROM ");
                switch (state)
                {
                    case 1: sb.Append("view_purchasing_plan_list_4_dept_unconfirm"); break;
                    case 2: sb.Append("view_purchasing_plan_list_4_dept_confirm"); break;
                    case 3: sb.Append("view_purchasing_plan_list_4_dept_need_modify"); break;
                }

                sb.Append(" WHERE department_id=");
                sb.Append(departmentID);
                try
                {
                    result = DBHelper.ExecuteTable(sb.ToString());
                }
                catch (Exception) { throw; }
                finally { }
            }
            return result;
        }

    }
}
