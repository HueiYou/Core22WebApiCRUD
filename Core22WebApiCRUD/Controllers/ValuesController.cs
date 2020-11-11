using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core22WebApiCRUD.Helper;
using Core22WebApiCRUD.Models;
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

        // GET api/values
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

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
