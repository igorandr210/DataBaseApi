using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBaseApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataBaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private ApplicationContext _applicationContext;

        public ItemsController(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemModel>>> Get()
        {
            return Ok(_applicationContext.GetAllItems());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemModel>> Get(int id)
        {
            var item = await _applicationContext.GetItem(id);
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound($"Item with id:{id} is not found.");
        }

        [HttpPost]
        public async Task<ActionResult<ItemModel>> Post([FromBody] ItemModel item)
        {
            if (await _applicationContext.AddItem(item))
            {
                return Ok(item);
            }

            return StatusCode(400, "Invalid parameters.");
        }

        [HttpPut]
        public async Task<ActionResult<ItemModel>> Put([FromBody] ItemModel item)
        {
            if (await _applicationContext.UpdateItem(item))
            {
                return Ok(item);
            }

            return StatusCode(400, "Invalid parameters.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (await _applicationContext.DeleteItem(id))
            {
                return Ok(id);
            }

            return StatusCode(400, "Invalid parameters.");
        }
    }
}
