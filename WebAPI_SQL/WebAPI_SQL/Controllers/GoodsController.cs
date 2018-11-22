using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL;

namespace WebAPI_SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        // GET: api/Goods
        [HttpGet]
        public string Get(int PageIndex, int PageSize)
        {
            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetGoods(), 
                PageIndex, PageSize));
        }

        // GET: api/Goods/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

    }
}
