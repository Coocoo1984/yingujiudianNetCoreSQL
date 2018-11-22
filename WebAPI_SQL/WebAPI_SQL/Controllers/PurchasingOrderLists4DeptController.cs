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
    public class PurchasingOrderLists4DeptController : ControllerBase
    {
        // GET: api/PurchasingOrderLists4Dept
        public string Get(int departmentID,int PageIndex, int PageSize)
        {
            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetPurchasingOrderList4Dept(departmentID),
                PageIndex, PageSize));
        }
    }
}
