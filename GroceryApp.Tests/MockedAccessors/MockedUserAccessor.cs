using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using _361Example.Accessors;
using _361Example.Models;

namespace GroceryApp.Tests.MockedAccessors
{
    public class MockedUserAccessor : IUserAccessor
    {

        private List<User> users;

        public MockedUserAccessor()
        {
            users = new List<User>();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return users;
        }

        public User Find(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            return user;
        }

        public User Insert(User user)
        {
            var max = users.Max(u => u.Id);
            user.Id = max + 1;
            users.Add(user);
            return user;
        }

        public void Update(User user)
        {
            users.RemoveAll(u => u.Id == user.Id);
            users.Add(user);
        }

        public User Delete(int id)
        {
            var user = Find(id);
            users.Remove(user);
            return user;
        }

        public bool Exists(int id)
        {
            for (int i = 0; i < users.Count; i = i + 1)
            {
                if (users.ElementAt(i).Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public User Find(String username, String password)
        {
            throw new NotImplementedException();
        }

        public void SetState(List<User> newState)
        {
            users = newState;
        }

        public List<User> GetState()
        {
            return users;
        }

        public User GetUserEmail(string email)
        {
            return users.Where(u => u.email == email).ToArray()[0];

        }
        int IUserAccessor.SaveChanges()
        {
            return 0;
        }

    }
}
