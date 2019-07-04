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
        public string Get(bool? disable, DateTime? startTime, DateTime? endTime,string listQuoteStateIDs, int PageIndex, int PageSize, string WechatID, string listQueryTypes)
        {
            ////DateTime endTime = DateTime.Now;
            ////DateTime startTime = endTime.AddMonths(-3);
            ////disable = BaseSettines.IsGlobalSelectTableRecordDisableClosed ?
            ////    disable : //关闭 全局查询状态
            ////    (disable == null) ? BaseSettines.DefualtDisableValue : disable;//开启 检查请求是否有该参数 （有则不干预,无则设置为默认值)
            ///


            if (!string.IsNullOrWhiteSpace(WechatID))
            {
                if (!Common.CheckPermission(WechatID, this.RouteData, listQuoteStateIDs))
                {
                    return BaseSettings.NoPermissionString;
                }
            }

            List<int> listIntQuoteStateIDs = DataHelper.GetListInt(listQuoteStateIDs);

            if (!string.IsNullOrWhiteSpace(listQueryTypes))
            {
                List<int> listIntQueryTypes = DataHelper.GetListInt(listQueryTypes);
                
                foreach (int item in listIntQueryTypes)
                {
                    switch(item)
                    {
                        case (int)BaseSettings.QuoteQueryType.Commit: listIntQuoteStateIDs.Add((int)BaseSettings.QuoteState.QuoteAwaitAudit1); break;
                        case (int)BaseSettings.QuoteQueryType.Audit1: listIntQuoteStateIDs.Add((int)BaseSettings.QuoteState.QuoteAudit1Pass); break;
                        case (int)BaseSettings.QuoteQueryType.Audit2: listIntQuoteStateIDs.Add((int)BaseSettings.QuoteState.QuoteAudit2Pass); break;
                    }
                }
            }

            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetQuoteListAll(
                disable,
                //DataHelper.GetListInt(listQuoteStateIDs),
                listIntQuoteStateIDs,
                DataHelper.GetDateTime(startTime),
                DataHelper.GetDateTimeAddOneDay(endTime)),
                PageIndex, PageSize));
        }

        
    }
}