using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Server.Models
{
    public class TodoRepository: ITodoRepository
    {
        private static ConcurrentDictionary<string, TodoServer> _server =
              new ConcurrentDictionary<string, TodoServer>();

        public TodoRepository()
        {
            Add(new TodoServer
            {
                NameServer = "Server1",
                NameSection = "Section1",
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
            //_server[server.NameServer] = server;
            _server[server.NameServer] = server;
        }

        public TodoServer Find(string nameServer)
        {
            TodoServer server;
            _server.TryGetValue(nameServer, out server);
            return server;
        }

        public TodoServer Remove(string nameServer)
        {
            TodoServer server;
            _server.TryRemove(nameServer, out server);
            return server;
        }

        public void Update(TodoServer server)
        {
            _server[server.NameServer] = server;
        }
    }
}
