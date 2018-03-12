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
    [Route("api/Order")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _repo;

        public OrderController(IOrderRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> GetAllOrder()
        {
            return Ok(await _repo.AllOrder());
        }

        [HttpGet("id/{id}", Name ="OID")]
        public async Task<IActionResult> GetOrderByID(string id)
        {
            return Ok(await _repo.FindOrderID(id));
        }

        [HttpGet("name/{customerName}", Name = "OCName")]
        public async Task<IActionResult> GetOrderByName(string customerName)
        {
            return Ok(await _repo.FindOrderCustomer(customerName));
        }

        [HttpGet("detail")]
        public async Task<IActionResult> GetAllDetail()
        {
            return Ok(await _repo.AllDetail());
        }

        [HttpGet("detail/{id}", Name = "DID")]
        public async Task<IActionResult> GetDetailByID(string id)
        {
            return Ok(await _repo.FindOrderDetail(id));
        }

        [HttpGet("detail/{productName}", Name = "OPName")]
        public async Task<IActionResult> GetByName(string productName)
        {
            return Ok(await _repo.FindOrderProduct(productName));
        }

        [HttpPost("insert")]
        public async Task<IActionResult> Insert([FromBody] OrderList item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            try
            {
                await _repo.InsertOrder(item);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return CreatedAtRoute("id", new { id = item.OId }, item);
        }

        [HttpPost("insert/detail")]
        public async Task<IActionResult> InsertDetail([FromBody] OrderDetail item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            try
            {
                await _repo.InsertDetail(item);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return CreatedAtRoute("id", new { id = item.OId,  }, item);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] OrderList item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var OrderObj = await _repo.FindOrderID(id);

            if (OrderObj == null)
            {
                await _repo.InsertOrder(item);
            }

            try
            {
                await _repo.UpdateOrder(item);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPut("update/detail/{id}")]
        public async Task<IActionResult> UpdateDetail(string id, [FromBody] OrderDetail item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var OrderObj = await _repo.FindOrderDetail(id);
            

            if (OrderObj == null)
            {
                await _repo.InsertDetail(item);
            }

            try
            {
                await _repo.UpdateDetail(item);
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
            await _repo.DeleteOrder(id);
            return NoContent();
        }

        [HttpDelete("delete/detail/{oid}/{pid}")]
        public async Task<IActionResult> DeleteDetail(string oid, string pid)
        {
            await _repo.DeleteDetail(oid, pid);
            return NoContent();
        }

    }
}