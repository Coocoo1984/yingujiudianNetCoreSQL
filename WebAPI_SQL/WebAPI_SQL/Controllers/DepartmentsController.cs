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
    public class DepartmentsController : ControllerBase
    {
        // GET: api/Departments
        [HttpGet]
        public string Get(bool? disable)
        {
            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetDepartments(disable), 
                0, 0));
        }
    }
}