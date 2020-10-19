using _361Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _361Example.Accessors
{
    interface IUserAccessor
    {
        IEnumerable<User> GetAllUsers();
        User Find(int id);
        User Insert(User user);
        void Update(User user);
        User Delete(int id);
        bool Exists(int id);
    }
}
