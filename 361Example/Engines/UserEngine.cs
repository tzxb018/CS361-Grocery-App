using _361Example.Accessors;
using _361Example.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace _361Example.Engines
{
    /**
     * The UserEngine class handles the business logic relating to throwing exceptions
     * where appropriate and calling the methods of an IUserAccessor to access the database's Users.
     **/
    public class UserEngine : IUserEngine
    {
        private readonly IUserAccessor _userAccessor;

        public UserEngine(IUserAccessor userAccessor)
        {
            _userAccessor = userAccessor;
        }

        //Returns all Users
        public IEnumerable<User> GetAllUsers()
        {
            return _userAccessor.GetAllUsers();
        }

        //GetUser will return null if the User isn't found
        public User GetUser(int id)
        {
            return _userAccessor.Find(id);

        }

        //Returns User if one is found under the provided credentials, null if unsucessful
        public User VerifyUser(String username, String password)
        {
            return _userAccessor.Find(username, password);
        }

        /**
         * Inserts the given user if user.Email does not exist within the database already
         * Otherwise, throws a new DuplicateNameException()
         **/
        public User InsertUser(User user)
        {
            if(GetUserEmail(user.Email) == null)
            {
                return _userAccessor.Insert(user);
            }

            throw new DuplicateNameException();
        }

        //Updates a User in the database with a given user
        public User UpdateUser(User user)
        {
            _userAccessor.Update(user);

            if (GetUser(user.Id) != user)
            {
                return null;
            }

            return user;
        }

        //Returns null if the User doesn't exist and can't be deleted
        public User DeleteUser(User user)
        {
            return _userAccessor.Delete(user.Id);
        }

        //Retrieves the User given their email
        //Returns User if succesfully found, null if not
        public User GetUserEmail(string email)
        {
            return _userAccessor.GetUserByEmail(email);
        }

    }
}

