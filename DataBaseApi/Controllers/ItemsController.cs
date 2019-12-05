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

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemModel>>> Get()
        {
            return null;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemModel>> Get(int id)
        {
            return null;
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<ItemModel>> Post([FromBody] ItemModel item)
        {
            return null;
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<ActionResult<ItemModel>> Put([FromBody] ItemModel model)
        {
            return null;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return null;
        }
    }
}
