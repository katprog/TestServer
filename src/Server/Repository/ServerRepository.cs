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
        void Add(TodoServer server);
        IEnumerable<TodoServer> GetAll();
        TodoServer Find(string name);
        void Update(TodoServer server);
    }

    public class ServerRepository : IServerRepository
    {
        private static ConcurrentDictionary<string, TodoServer> _server =
        new ConcurrentDictionary<string, TodoServer>();

        public ServerRepository()
        {
            Add(new TodoServer
            {
                NameServer = "Server1", // Section
                Name = "Name1",
                City = "City1",
                Location = "Location1"

            });
        }

        public IEnumerable<TodoServer> GetAll()
        {
            return _server.Values;
        }

        public void Add(TodoServer server)
        {
            //server.NameServer = Guid.NewGuid().ToString();
            _server[server.NameServer] = server;
        }

        public TodoServer Find(string nameServer)
        {
            TodoServer server;
            _server.TryGetValue(nameServer, out server);
            return server;
        }

        public void Update(TodoServer server)
        {
            _server[server.NameServer] = server;
        }
    }
}
