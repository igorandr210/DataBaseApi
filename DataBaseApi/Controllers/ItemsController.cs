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
