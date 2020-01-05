using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_SQL
{
    public class BaseSettings
    {
        //是否需要关闭全局SQL检索时的表记录启用标志位判断 如果启用 Controller自动添加 disable = value 的查询条件
        public static bool IsGlobalSelectTableRecordDisableClosed = false;
        //value 默认值
        public static bool DefualtDisableValue = false;
        //导出订单的默认值状态值
        public static string listDefualtPOStateIDs = "6,7,8,9,10,11";

        public static string NoPermissionString = "没有访问权限";

        public enum PermissionDefine
        {
            QuoteDetailRead = 1,
            QuoteAudit = 2,
            QuoteAudit2 = 3,
            PurchaceAudit = 4,
            PurchaceAudit2 = 5,
            PurchaceAudit3 = 6,
            ChargeBack = 7,
            DepotAdmin = 8
        }

        /// <summary>
        /// 采购计划阶段状态定义
        /// </summary>
        public enum EnumPurchasingPlanState
        {
            /// <summary>
            /// 需求草稿
            /// </summary>
            PlanDraft = 1,

            /// <summary>
            /// 等待初审
            /// </summary>
            PlanAwaitAudit1 = 2,

            /// <summary>
            /// 初审驳回
            /// </summary>
            PlanAudit1Rejected = 3,

            /// <summary>
            /// 初审通过
            /// </summary>
            PlanAudit1Pass = 4,

            /// <summary>
            /// 复审驳回
            /// </summary>
            PlanAudit2Rejected = 5,

            /// <summary>
            /// 复审通过
            /// </summary>
            PlanAudit2Pass = 6,

            /// <summary>
            /// 三审驳回
            /// </summary>
            PlanAudit3Rejected = 7,

            /// <summary>
            /// 三审通过
            /// </summary>
            PlanAudit3Pass = 8,

            /// <summary>
            /// 供应商驳回
            /// </summary>
            OrderVendorRejected = 9,

            /// <summary>
            /// 供应商确认
            /// </summary>
            OrderVendorConfirm = 10,

            /// <summary>
            /// 废除
            /// </summary>
            Cancelled = 10,

        }

        /// <summary>
        /// 订单阶段状态定义
        /// </summary>
        public enum EnumPurchasingOrderState
        {
            /// <summary>
            /// 订单等待供应商确认
            /// </summary>
            AwaitVendorConfirm = 1,

            /// <summary>
            /// 订单被供应商否定
            /// </summary>
            VendorNegative = 2,

            /// <summary>
            /// 订单被供应商已确认
            /// </summary>
            VendorConfirmed = 3,

            /// <summary>
            /// 供应商已发货
            /// </summary>
            VendorShipped = 4,

            /// <summary>
            /// 需求部门收货中
            /// </summary>
            DeparmentCheckIn = 5,

            /// <summary>
            /// 需求部门已完整收货
            /// </summary>
            ConfirmReceipt = 6,

            /// <summary>
            /// 需求部门发起退货
            /// </summary>
            DepartmentChargeBack = 7,

            /// <summary>
            /// 采购中心驳回退货
            /// </summary>
            ChargeBackAuditRejected = 8,

            /// <summary>
            /// 采购中心退货审核通过
            /// </summary>
            ChargeBackAudit = 9,

            /// <summary>
            /// 供应商确认退货
            /// </summary>
            VendorChargeBackComfirm = 10,

            /// <summary>
            /// 需求部门确认退货完成
            /// </summary>
            ChargeBackFinish = 11,
        }

        /// <summary>
        /// 采购的环节操作定义
        /// </summary>
        public enum EnumPurchasingAuditType
        {
            /// <summary>
            /// 初审驳回
            /// </summary>
            PlanAudit1Rejected = 1,

            /// <summary>
            /// 初审通过
            /// </summary>
            PlanAudit1Pass = 2,

            /// <summary>
            /// 复审驳回
            /// </summary>
            PlanAudit2Rejected = 3,

            /// <summary>
            /// 复审通过
            /// </summary>
            PlanAudit2Pass = 4,

            /// <summary>
            /// 三审驳回
            /// </summary>
            PlanAudit3Rejected = 5,

            /// <summary>
            /// 三审通过
            /// </summary>
            PlanAudit3Pass = 6,

            /// <summary>
            /// 订单被供应商否定
            /// </summary>
            VendorNegative = 7,

            /// <summary>
            /// 订单被供应商确认
            /// </summary>
            VendorConfirmed = 8,

            /// <summary>
            /// 供应商已发货
            /// </summary>
            VendorShipped = 9,

            /// <summary>
            /// 需求部门收货中
            /// </summary>
            DeparmentCheckIn = 10,

            /// <summary>
            /// 需求部门已完整收货
            /// </summary>
            ConfirmReceipt = 11,

            /// <summary>
            /// 需求部门发起退货
            /// </summary>
            DepartmentChargeBack = 12,

            /// <summary>
            /// 采购中心驳回退货
            /// </summary>
            ChargeBackAuditRejected = 13,

            /// <summary>
            /// 采购中心退货审核通过
            /// </summary>
            ChargeBackAudit = 14,

            /// <summary>
            /// 供应商确认退货
            /// </summary>
            VendorChargeBackComfirm = 15,

            /// <summary>
            /// 需求部门确认退货完成
            /// </summary>
            ChargeBackFinish = 16,

        }


        /// <summary>
        /// 报价状态定义
        /// </summary>
        public enum QuoteState
        {
            //草稿
            QuoteDraft = 1,
            //待初审
            QuoteAwaitAudit1 = 2,
            //初审驳回
            QuoteAudit1Rejected = 3,
            //初审通过
            QuoteAudit1Pass = 4,
            //复审驳回
            QuoteAudit2Rejected = 5,
            //复审通过
            QuoteAudit2Pass = 6
        }

        public enum QuoteAuditType
        {
            /// <summary>
            /// 初审驳回
            /// </summary>
            Audit1Rejected = 1,

            /// <summary>
            /// 初审通过
            /// </summary>
            Audit1Pass = 2,

            /// <summary>
            /// 复审驳回
            /// </summary>
            Audit2Rejected = 3,

            /// <summary>
            /// 复审通过，报价生效
            /// </summary>
            Audit2Pass = 4,

        }


        public enum QuoteQueryType
        {
            Commit = 1,
            Audit1 = 2,
            Audit2 = 3
        }

        public enum ChargeBackQueryType
        {
            Commit = 1,
            Audit = 2
        }

    }

}
