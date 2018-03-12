using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using KingstonAPI.Interfaces;
using KingstonAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KingstonAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _repo;

        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repo.All());
        }

        [HttpGet("id/{id}", Name ="ID")]
        public async Task<IActionResult> GetByID(string id)
        {
            return Ok(await _repo.FindID(id));
        }

        [HttpGet("name/{name}", Name = "Name")]
        public async Task<IActionResult> GetByName(string name)
        {
            return Ok(await _repo.FindName(name));
        }

        [HttpPost("insert")]
        public async Task<IActionResult> Insert([FromBody] ProductList item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            try
            {
                await _repo.Insert(item);
            }
            catch (Exception) {
                return BadRequest();
            }
            return CreatedAtRoute("id", new { id = item.PId }, item);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] ProductList item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var productObj = await _repo.FindID(id);
            if (productObj == null)
            {
                await _repo.Insert(item);
            }

            try
            {
                await _repo.Update(item);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _repo.Delete(id);
            return NoContent();
        }

    }
}