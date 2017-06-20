using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Repository;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        public IServerRepository ServerInfoRep { get; set; }
        public ValuesController(IServerRepository serverInfoRep)
        {
            ServerInfoRep = serverInfoRep;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var allServers = ServerInfoRep.GetAll();
            return new JsonResult(allServers);
        }

        [HttpGet("{id}", Name = "GetServer")]
        public IActionResult GetById(string id)
        {
            var serverInfo = ServerInfoRep.Find(id);
            if (serverInfo == null)
            {
                return NotFound();
            }
            return new ObjectResult(serverInfo);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] ServerInfo serverInfo)
        {
            if (serverInfo == null || id == null)
            {
                return BadRequest();
            }

            serverInfo.Section = id;

            if (ServerInfoRep.Find(id) == null)
            {
                ServerInfoRep.Add(serverInfo);
                return CreatedAtRoute("GetServer", new { id = serverInfo.Section}, serverInfo);
                //return Ok();
            }

            ServerInfoRep.Update(serverInfo);
            return CreatedAtRoute("GetServer", new { id = serverInfo.Section }, serverInfo);
            //return Ok();
        }
    }
}
