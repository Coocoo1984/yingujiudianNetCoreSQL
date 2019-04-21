using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        /// <summary>
        /// 库存查询（未按照需求部门分库 每次从数据库直接综合查询）
        /// </summary>
        /// <param name="listBizTypeIDs"></param>
        /// <param name="listGoodsClassIDs"></param>
        /// <param name="listGoodsIDs"></param>
        /// <param name="listDeparmentIDs"></param>
        /// <param name="listVendorIDs"></param>
        /// <param name="listPOStateIDs"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        // GET: api/Stock
        [HttpGet]
        public string Get(string listBizTypeIDs, string listGoodsClassIDs, string listGoodsIDs, string listDeparmentIDs, string listVendorIDs, string listPOStateIDs, DateTime? startTime, DateTime? endTime, int PageIndex, int PageSize, string WechatID)
        {
            if (string.IsNullOrWhiteSpace(listPOStateIDs))
            {
                listPOStateIDs = BaseSettines.listDefualtPOStateIDs;
            }
            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetStock(
                DataHelper.GetListInt(listBizTypeIDs),
                DataHelper.GetListInt(listGoodsClassIDs),
                DataHelper.GetListInt(listGoodsIDs),
                DataHelper.GetListInt(listDeparmentIDs),
                DataHelper.GetListInt(listVendorIDs),
                DataHelper.GetListInt(listPOStateIDs),
                DataHelper.GetDateTime(startTime),
                DataHelper.GetDateTime(endTime)), 
                PageIndex, PageSize));
        }
    }
}