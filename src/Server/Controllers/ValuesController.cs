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
   
        [HttpGet]
        public IEnumerable<TodoServer> GetAll()
        {
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

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] TodoServer server)
        {
            if (server == null || server.NameServer != id)
            {
                return BadRequest();
            }

            var todo = TodoServers.Find(id);
            if (todo == null)
            {
                TodoServers.Add(server);
                //return Ok();
                return CreatedAtRoute("GetTodo", new { id = server.NameServer }, server);
            }
            TodoServers.Update(server);
            //return Ok();
            return CreatedAtRoute("GetTodo", new { id = server.NameServer }, server);
        }


    }
}
