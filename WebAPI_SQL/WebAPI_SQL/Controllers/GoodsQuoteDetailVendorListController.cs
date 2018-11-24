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
    public class GoodsQuoteDetailVendorListController : ControllerBase
    {
        // GET: api/GoodsQuoteDetailVendorList
        public string Get(int bizTypeID, DateTime? startTime, DateTime? endTime,int goodsId, int PageIndex, int PageSize)
        {
            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetGoodsQuoteDetailVendorList(bizTypeID, startTime, endTime, goodsId),
                PageIndex, PageSize));
        }
    }
}