using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public string Get(int id)
        {
            return "value";
        }

    }
}
