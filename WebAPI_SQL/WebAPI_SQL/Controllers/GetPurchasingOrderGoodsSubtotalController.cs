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
    public class GetPurchasingOrderGoodsSubtotalController : ControllerBase
    {
        // GET: api/GetPurchasingOrderGoodsSubtotal
        [HttpGet]
        public string Get(int departmentID, string listBizTypeIDs, string listGoodsClassIDs, string listGoodsIDs, DateTime? startTime, DateTime? endTime)
        {
            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetPurchasingOrderGoodsSubtotal(
                departmentID,
                DataHelper.GetListInt(listBizTypeIDs),
                DataHelper.GetListInt(listGoodsClassIDs),
                DataHelper.GetListInt(listGoodsIDs),
                DataHelper.GetDateTime(startTime),
                DataHelper.GetDateTime(endTime)),
                0, 0));
        }
    }
}
