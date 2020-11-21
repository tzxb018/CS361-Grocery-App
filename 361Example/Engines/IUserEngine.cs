using _361Example.Models;
using System;
using System.Collections.Generic;

namespace _361Example.Engines
{
    /**
     * The IUserEngine interface contains the method declarations for methods that
     * must be defined by any class whose purpose is using an IUserAccessor to access
     * the database's Users and including business logic to access appropriately.
     **/
    public interface IUserEngine
    {
        //Returns all Users
        public IEnumerable<User> GetAllUsers();

        //Returns the User with the specified id
        public User GetUser(int id);

        //Returns the User with the specified email
        public User GetUserEmail(string email);

        //Inserts user, and returns the inserted User
        public User InsertUser(User user);

        //Updates the User with the same id as user to be the new version user, and returns the updated User
        public User UpdateUser(User user);

        //Deletes user, and returns the deleted User
        public User DeleteUser(User user);

        //Returns the User with the specified username and password
        public User VerifyUser(String username, String password);
    }
}
