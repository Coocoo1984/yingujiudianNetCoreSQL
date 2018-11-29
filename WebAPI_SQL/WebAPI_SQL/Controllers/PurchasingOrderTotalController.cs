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
    public class PurchasingOrderTotalController : ControllerBase
    {
        // GET: api/PurchasingOrderTotal
        [HttpGet]
        public string Get(int departmentID, List<int> listBizTypeIDs, DateTime? startTime, DateTime? endTime)
        {
            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetPurchasingOrderTotal(
                departmentID, 
                listBizTypeIDs, 
                startTime, 
                endTime),
                0, 0));
        }
    }
}
