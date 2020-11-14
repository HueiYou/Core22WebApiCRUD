using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core22WebApiCRUD.Helper;
using Core22WebApiCRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Core22WebApiCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private NorthwindContext _context;

        public ValuesController(NorthwindContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// 取得10筆顧客資料
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult Get()
        {
            var result = _context.Customers.Select(x => new
            {
                x.CustomerId,
                x.CompanyName
            }).Take(10).ToList();

            return new JsonResult(result);
        }

        /// <summary>
        /// 顯示value = 傳入值
        /// </summary>
        /// <remarks>
        /// id須為整數
        /// </remarks>
        /// <param name="id">傳入值</param>
        /// <returns>value = 傳入值</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<string> Get(int id)
        {
            return "value=" + id.ToString();
        }

        // POST api/values
        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)] //不產生該Api的swagger說明，但還是可以被呼叫
        public void Post([FromBody] string value)
        {
        }

        /// <summary>
        /// 更新資料
        /// PUT api/values/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        /// 刪除資料
        /// DELETE api/values/5
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
