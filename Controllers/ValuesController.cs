using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingstonAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KingstonAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly KingstonTestContext _context;

        public ValuesController(KingstonTestContext context) {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _context.OrderList.ToListAsync();
            return Ok(values);
        }

   

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
