using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Server.Models;

namespace Server.Repository
{
    public interface IServerRepository
    {
        void Add(ServerSection serverSection);
        IEnumerable<ServerSection> GetAll();
        ServerInfo Find(string section);
        void Update(ServerSection serverSection);
    }

    public class ServerRepository : IServerRepository
    {
        private static ConcurrentDictionary<string, ServerSection> ServersInfoContainer =
        new ConcurrentDictionary<string, ServerSection>();

        public ServerRepository()
        {
            Add(new ServerSection
            {
                Section = "GIS", 
                Info = new ServerInfo
                {         
                    Name = "Geoinformation Systems",
                    City = "Tomsk",
                    Location = "Lenina, 2, 404"
                }
            });
        }

        public IEnumerable<ServerSection> GetAll()
        {
            return ServersInfoContainer.Values;
        }

        public void Add(ServerSection serverSection)
        {
            ServersInfoContainer[serverSection.Section] = serverSection;
        }

        public ServerInfo Find(string Section)
        {
            ServerSection serverSection;
            ServersInfoContainer.TryGetValue(Section, out serverSection);
            if (serverSection == null)
            {
                return null;
            }
            return serverSection.Info;
        }

        public void Update(ServerSection serverSection)
        {
            ServersInfoContainer[serverSection.Section] = serverSection;
        }
    }
}
