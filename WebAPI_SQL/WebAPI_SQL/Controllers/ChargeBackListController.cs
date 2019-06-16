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
    public class ChargeBackListController : ControllerBase
    {
        // GET: api/ChargeBackList
        [HttpGet]
        public string Get(int PageIndex, int PageSize, DateTime? startTime, DateTime? endTime, string listBizTypeIDs, string listDepartmentIDs, string WechatID)
        {
            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetChargeBackList(
                    DataHelper.GetListInt(listBizTypeIDs),
                    DataHelper.GetListInt(listDepartmentIDs),
                    DataHelper.GetDateTime(startTime),
                    DataHelper.GetDateTimeAddOneDay(endTime)),
                PageIndex, PageSize));
        }
    }
}