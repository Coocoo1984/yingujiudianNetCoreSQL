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
    public class QuoteListAllController : ControllerBase
    {
        // GET: api/QuoteListAll
        [HttpGet]
        public string Get(bool? disable, DateTime? startTime, DateTime? endTime, int PageIndex, int PageSize, string WechatID)
        {
            ////DateTime endTime = DateTime.Now;
            ////DateTime startTime = endTime.AddMonths(-3);
            ////disable = BaseSettines.IsGlobalSelectTableRecordDisableClosed ?
            ////    disable : //关闭 全局查询状态
            ////    (disable == null) ? BaseSettines.DefualtDisableValue : disable;//开启 检查请求是否有该参数 （有则不干预,无则设置为默认值)

            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetQuoteListAll(
                disable,
                DataHelper.GetDateTime(startTime),
                DataHelper.GetDateTime(endTime)),
                PageIndex, PageSize));
        }

        
    }
}