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
    public class ConferenceController : Controller
    {
        public IServerRepository ServerInfoRep { get; set; }
        public ConferenceController(IServerRepository serverInfoRep)
        {
            ServerInfoRep = serverInfoRep;
        }

        [HttpGet("Info")]
        public IActionResult GetAll()
        {
            var allServers = ServerInfoRep.GetAll();
            return new JsonResult(allServers);
        }

        [HttpGet("{id}/Info")]
        public IActionResult GetById(string id)
        {
            var serverInfo = ServerInfoRep.Find(id);
            if (serverInfo == null)
            {
                return NotFound();
            }
            return new ObjectResult(serverInfo);
        }

        [HttpPut("{id}/Info")]
        public IActionResult Update(string id, [FromBody] Info info)
        {
            if (info == null || id == null)
            {
                return BadRequest();
            }

            ServerSection serverInfo = new ServerSection();
            serverInfo.Section = id;
            serverInfo.info = info;

            if (ServerInfoRep.Find(id) == null)
            {
                ServerInfoRep.Add(serverInfo);
                return Ok();
            }

            ServerInfoRep.Update(serverInfo);
            return Ok();
        }
    }
}
