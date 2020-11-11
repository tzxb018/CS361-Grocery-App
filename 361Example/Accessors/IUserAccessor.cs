using _361Example.Models;
using System.Collections.Generic;

namespace _361Example.Accessors
{
    public interface IUserAccessor
    {
        IEnumerable<User> GetAllUsers();
        User Find(int id);

        User GetUserEmail(string email);

        User Find(String username, String password);

        User Insert(User user);
        void Update(User user);
        User Delete(int id);
        bool Exists(int id);
    }
}
