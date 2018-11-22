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
    public class PurchasingPlanLists4DeptController : ControllerBase
    {
        // GET: api/PurchasingPlanLists4Dept
        [HttpGet]
        public string Get(int departmentID, int state, int PageIndex, int PageSize)
        {
            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetPurchasingPlanLists4Dept(departmentID, state),
                PageIndex, PageSize));
        }
    }
}
