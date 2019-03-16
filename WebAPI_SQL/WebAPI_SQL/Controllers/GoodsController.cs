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
        public string Get(bool? disable, int PageIndex, int PageSize)
        {
            disable = BaseSettines.IsGlobalSelectTableRecordDisableClosed ?
                        disable : //关闭 全局查询状态
                        (disable == null) ? 
                            BaseSettines.DefualtDisableValue : 
                            disable;//开启 检查请求是否有该参数 （有则不干预,无则设置为默认值)
            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetGoods(disable),
                PageIndex, PageSize));
        }

    }
}
