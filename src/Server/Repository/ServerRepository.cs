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
        void Add(ServerInfo serverInfo);
        IEnumerable<ServerInfo> GetAll();
        ServerInfo Find(string section);
        void Update(ServerInfo serverInfo);
    }

    public class ServerRepository : IServerRepository
    {
        private static ConcurrentDictionary<string, ServerInfo> ServersInfoContainer =
        new ConcurrentDictionary<string, ServerInfo>();

        public ServerRepository()
        {
            Add(new ServerInfo
            {
                Section = "Section", 
                Name = "Name1",
                City = "City1",
                Location = "Location1"
            });
        }

        public IEnumerable<ServerInfo> GetAll()
        {
            return ServersInfoContainer.Values;
        }

        public void Add(ServerInfo serverInfo)
        {
            ServersInfoContainer[serverInfo.Section] = serverInfo;
        }

        public ServerInfo Find(string Section)
        {
            ServerInfo serverInfo;
            ServersInfoContainer.TryGetValue(Section, out serverInfo);
            return serverInfo;
        }

        public void Update(ServerInfo serverInfo)
        {
            ServersInfoContainer[serverInfo.Section] = serverInfo;
        }
    }
}
