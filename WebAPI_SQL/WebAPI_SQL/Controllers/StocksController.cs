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
    public class StocksController : ControllerBase
    {
        // GET: api/Stocks
        [HttpGet]
        public string Get(int DepartmentID, DateTime? StartTime, DateTime? EndTime, int PageIndex, int PageSize)
        {
            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetStock(
                DepartmentID, 
                DataHelper.GetDateTime(StartTime), 
                DataHelper.GetDateTime(EndTime)),
                PageIndex, PageSize));
        }
    }


}