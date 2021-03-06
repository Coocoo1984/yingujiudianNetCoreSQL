﻿using System;
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
    public class ChargeBackDetailListController : ControllerBase
    {
        // GET: api/ChargeBackDetailList
        [HttpGet]
        public string Get(int PageIndex, int PageSize, int ChargeBackID, int OrderID, int PlanID, string WechatID)
        {
            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetChargeBackDetailList(
                    ChargeBackID,
                    OrderID,
                    PlanID),
                PageIndex, PageSize));
        }
    }
}