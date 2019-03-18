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
    public class StockByDeptController : ControllerBase
    {
        // GET: api/StockByDept
        [HttpGet]
        public string Get(string listBizTypeIDs, string listGoodsClassIDs, string listGoodsIDs, string listDeparmentIDs, string listVendorIDs, string listPOStateIDs, DateTime? startTime, DateTime?endTime)
        {
            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetStockByDept(
                DataHelper.GetListInt(listBizTypeIDs),
                DataHelper.GetListInt(listGoodsClassIDs),
                DataHelper.GetListInt(listGoodsIDs),
                DataHelper.GetListInt(listDeparmentIDs),
                DataHelper.GetListInt(listVendorIDs),
                DataHelper.GetListInt(listPOStateIDs),
                DataHelper.GetDateTime(startTime),
                DataHelper.GetDateTime(endTime)),
                0, 0));
        }
    }


}