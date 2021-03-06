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
    public class GetPAPOAuditListController : ControllerBase
    {
        [HttpGet]
        public string Get(int purchasingPlanID, int purchasingOrderID)
        {
            //if (!string.IsNullOrWhiteSpace(WechatID))
            //{
            //    if (!Common.CheckPermission(WechatID, this.RouteData, null))
            //    {
            //        return BaseSettings.NoPermissionString;
            //    }
            //}

            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetPAPOAuditList(purchasingPlanID, purchasingOrderID),
                 0, 0));
        }
    }
}