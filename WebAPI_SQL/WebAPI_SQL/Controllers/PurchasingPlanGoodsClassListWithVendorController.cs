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
    public class PurchasingPlanGoodsClassListWithVendorController : ControllerBase
    {
        // GET: api/PurchasingPlanGoodsClassListWithVendor
        [HttpGet]
        public string Get(int PurchasingPalnID, string WechatID)
        {
            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetPurchasingPlanGoodsClassListWithVendor(PurchasingPalnID),
                0, 0));
        }
    }
}
