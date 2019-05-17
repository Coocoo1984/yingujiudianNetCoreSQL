using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetDetailByQuoteIDController : Controller
    {

        [HttpGet]
        public string GetDetailByQuoteID(int quoteID, int PageIndex, int PageSize, string WechatID)
        {
            if (!string.IsNullOrWhiteSpace(WechatID))
            {
                if (!Common.CheckPermission(WechatID, this.RouteData, null))
                {
                    return BaseSettings.NoPermissionString;
                }
            }

            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetQuoteDetailListByQuoteID(quoteID),
                 PageIndex, PageSize));
        }
            
    }
}