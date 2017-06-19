using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public interface ITodoRepository
    {
        void Add(TodoServer server);
        IEnumerable<TodoServer> GetAll();
        TodoServer Find(string name);
        TodoServer Remove(string name);
        void Update(TodoServer server);
    }
}
