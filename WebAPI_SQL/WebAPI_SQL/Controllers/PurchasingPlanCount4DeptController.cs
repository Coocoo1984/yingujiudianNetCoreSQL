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
    public class PurchasingPlanCount4DeptController : ControllerBase
    {
        // GET: api/PurchasingPlanCount4Dept
        [HttpGet]
        public string Get(int departmentID)
        {
            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetPurchasingPlanCount4Dept(departmentID),
                0, 0));
        }

    }
}
