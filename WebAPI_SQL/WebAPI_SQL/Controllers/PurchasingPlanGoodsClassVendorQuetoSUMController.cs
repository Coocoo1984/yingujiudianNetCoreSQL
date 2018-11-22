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
    public class PurchasingPlanGoodsClassVendorQuetoSUMController : ControllerBase
    {
        // GET: api/PurchasingPlanGoodsClassVendorQuetoSUM
        [HttpGet]
        public string Get(int purchasingPlanID, int goodsClassID, string listIntGoodsIds, int PageIndex, int PageSize)
        {
            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetPurchasingPlanGoodsClassVendorQuetoSUM(purchasingPlanID, goodsClassID, DataHelper.GetListInt(listIntGoodsIds)),
                PageIndex, PageSize));
        }
    }
}
