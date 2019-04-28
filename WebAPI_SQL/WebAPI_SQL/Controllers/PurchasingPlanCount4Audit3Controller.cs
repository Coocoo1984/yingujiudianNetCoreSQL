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
    public class PurchasingPlanCount4Audit3Controller : ControllerBase
    {
        // GET: api/PurchasingPlanCount4Audit3
        [HttpGet]
        public string Get(int PageIndex, int PageSize, string WechatID)
        {
            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetPurchasingPlanCount4Audit3(),
                PageIndex, PageSize));
        }
    }
}