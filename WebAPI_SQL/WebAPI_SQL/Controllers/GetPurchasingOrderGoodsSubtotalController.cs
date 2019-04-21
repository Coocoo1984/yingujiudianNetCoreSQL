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
        public string Get(string listDepartmentIDs, string listBizTypeIDs, string listGoodsClassIDs, string listGoodsIDs, string listPOStateIDs, DateTime? startTime, DateTime? endTime, string WechatID)
        {
            if (string.IsNullOrWhiteSpace(listPOStateIDs))
            {
                listPOStateIDs = BaseSettines.listDefualtPOStateIDs;
            }

            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetPurchasingOrderGoodsSubtotal(
                DataHelper.GetListInt(listDepartmentIDs),
                DataHelper.GetListInt(listBizTypeIDs),
                DataHelper.GetListInt(listGoodsClassIDs),
                DataHelper.GetListInt(listGoodsIDs),
                DataHelper.GetListInt(listPOStateIDs),
                DataHelper.GetDateTime(startTime),
                DataHelper.GetDateTime(endTime)),
                0, 0));
        }
    }
}
