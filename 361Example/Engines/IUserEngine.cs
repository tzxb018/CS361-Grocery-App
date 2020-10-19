using _361Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _361Example.Engines
{
    interface IUserEngine
    {
        public IEnumerable<User> GetAllUsers();
        public User GetUser(int id);
        public User InsertUser(User user);
        public User UpdateUser(User user);
        public User DeleteUser(User user);
    }
}
