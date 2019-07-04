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
        public string Get(int PageIndex, int PageSize, DateTime? startTime, DateTime? endTime, string listStateIds, string listBizTypeIDs, string listDepartmentIDs, string listVendorIDs, string WechatID, string listQueryTypes)
        {
            if(!string.IsNullOrWhiteSpace(listStateIds))
            {
                //前端参数传错了 特殊处理
                if (listStateIds == "11,12,13,14,15")
                {
                    listStateIds = "7,8,9,10";
                }
                else if (listStateIds == "11")
                {
                    listStateIds = "7";
                }
                else if (listStateIds == "16")
                {
                    listStateIds = "11";
                }
            }

            List<int> listIntChargeBackStateIDs = DataHelper.GetListInt(listStateIds);

            if (!string.IsNullOrWhiteSpace(listQueryTypes))
            {
                List<int> listIntQueryTypes = DataHelper.GetListInt(listQueryTypes);

                foreach (int item in listIntQueryTypes)
                {
                    switch (item)
                    {
                        case (int)BaseSettings.QuoteQueryType.Commit: listIntChargeBackStateIDs.Add((int)BaseSettings.QuoteState.QuoteAwaitAudit1); break;
                        case (int)BaseSettings.QuoteQueryType.Audit1: listIntChargeBackStateIDs.Add((int)BaseSettings.QuoteState.QuoteAudit1Pass); break;
                        case (int)BaseSettings.QuoteQueryType.Audit2: listIntChargeBackStateIDs.Add((int)BaseSettings.QuoteState.QuoteAudit2Pass); break;
                    }
                }
            }

            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetChargeBackList(
                    DataHelper.GetListInt(listStateIds),
                    DataHelper.GetListInt(listBizTypeIDs),
                    DataHelper.GetListInt(listDepartmentIDs),
                     DataHelper.GetListInt(listVendorIDs),
                    DataHelper.GetDateTime(startTime),
                    DataHelper.GetDateTimeAddOneDay(endTime)),
                PageIndex, PageSize));
        }
    }
}