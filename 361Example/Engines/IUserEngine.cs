using _361Example.Models;
using System;
using System.Collections.Generic;

namespace _361Example.Engines
{
    public interface IUserEngine
    {
        public IEnumerable<User> GetAllUsers();
        public User GetUser(int id);
        public User GetUserEmail(string email);
        public User InsertUser(User user);
        public User UpdateUser(User user);
        public User DeleteUser(User user);
        public User VerifyUser(String username, String password);
    }
}
