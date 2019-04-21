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
    public class PurchasingPlanDetailController : ControllerBase
    {
        // GET: api/PurchasingPlanDetail
        [HttpGet]
        public string Get(int purchasingPlanId, int PageIndex, int PageSize, string WechatID)
        {
            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetPurchasingPlanDetailList(purchasingPlanId),
                PageIndex, PageSize));
        }
    }
}
