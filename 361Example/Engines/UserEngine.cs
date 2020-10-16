using _361Example.Accessors;
using _361Example.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace _361Example.Engines
{
    public class UserEngine
    {
        private readonly IUserAccessor _userAccessor;

        public UserEngine()
        {
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userAccessor.GetAllUsers();
        }

        //GetUser will return null if the User isn't found
        public User GetUser(int id)
        {
            return _userAccessor.Find(id);

        }

        public User InsertUser(User user)
        {
            List<User> allUsers = GetAllUsers().ToList();

            foreach(User u in allUsers)
            {
                if(u.Id == user.Id)
                {
                    throw new DuplicateNameException();
                }
                else if(u.email == user.email)
                {
                    throw new DuplicateNameException();
                }
            }
            return user;
        }

        public User UpdateUser(User user)
        {
            _userAccessor.update(user);

            if(GetUser(user.Id) != user)
            {
                return null;
            }

            return user;
        }

        //Returns null if the User doesn't exist and can't be deleted
        public User DeleteUser(User user)
        {
            return _userAccessor.Delete(user);
        }
    }
}
