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
    public class PurchasingPlanCount4AuditController : ControllerBase
    {
        // GET: api/PurchasingPlanCount4Audit
        [HttpGet]
        public string Get(int PageIndex, int PageSize, string WechatID)
        {
            if (!string.IsNullOrWhiteSpace(WechatID))
            {
                if (!Common.CheckPermission(WechatID, this.RouteData, null))
                {
                    return BaseSettings.NoPermissionString;
                }
            }
            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetPurchasingPlanCount4Audit(),
                PageIndex, PageSize));
        }
    }
}
