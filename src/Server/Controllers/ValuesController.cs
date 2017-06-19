using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        public ITodoRepository TodoServers { get; set; }
        public ValuesController(ITodoRepository todoServer)
        {
            TodoServers = todoServer;
        }
   
        // GET api/values
        [HttpGet]
        public IEnumerable<TodoServer> GetAll()
        {
            // return new string[] { "value1", "value2" };
            var allServers = TodoServers.GetAll();
            return allServers;

        }


        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(string id)
        {
            var server = TodoServers.Find(id);
            if (server == null)
            {
                return NotFound();
            }
            return new ObjectResult(server);
        }


        [HttpPost]
        public IActionResult Create([FromBody] TodoServer server)
        {
            if (server == null)
            {
                return BadRequest();
            }
            TodoServers.Add(server);
            return CreatedAtRoute("GetTodo", new { id = server.NameServer }, server);
        }

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
