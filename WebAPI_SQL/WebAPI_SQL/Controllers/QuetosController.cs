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
    public class QuetosController : ControllerBase
    {
        // GET: api/Quetos
        //[HttpGet]
        //public string DetailList4Vendor2Quote(int vendorID, List<int> listBizTypeID, int PageIndex, int PageSize)
        //{
        //    return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetQuoteDetailList4Vendor2Quote(vendorID, listBizTypeID), PageIndex, PageSize));
        //}
    }

    [Route("api/quetodetails/[controller]")]
    [ApiController]
    public class Get4Vendor2QuetoController : ControllerBase
    {
        // GET: api/quetodetails/Get4Vendor2Queto
        [HttpGet]
        public string GetQue(int vendorID, List<int> listBizTypeID, int PageIndex, int PageSize)
        {
            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetQuoteDetailList4Vendor2Quote(vendorID, listBizTypeID), PageIndex, PageSize));
        }
    }
}