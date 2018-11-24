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
    public class PurchasingOrderGoodsCountStaticsController : ControllerBase
    {
        // GET: api/PurchasingOrderGoodsCountStatics
        public string Get(string listBizTypeIDs, string listDepartmentIDs, string listGoodsClassIDs, string listGoodsIDs, int PageIndex, int PageSize)
        {
            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetPurchasingOrderGoodsCountStatics(
                    DataHelper.GetListInt(listBizTypeIDs),
                    DataHelper.GetListInt(listDepartmentIDs),
                    DataHelper.GetListInt(listGoodsClassIDs),
                    DataHelper.GetListInt(listGoodsIDs)),
                PageIndex, PageSize));
        }
    }
}
