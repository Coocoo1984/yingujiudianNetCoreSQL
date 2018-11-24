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
    public class BizTypesController : ControllerBase
    {
        // GET: api/BizTypes
        [HttpGet]
        public string Get()
        {
            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetBizTypes(), 
                0, 0));
        }
    }
}