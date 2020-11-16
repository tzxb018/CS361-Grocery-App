using System;
using System.Collections.Generic;
using System.Linq;
using _361Example.Accessors;
using _361Example.Models;

namespace GroceryApp.Tests.MockedAccessors
{
    /**
     * The purpose of this class is to act as a Mock Accessor to be used in the UserEngine during unit testing
     * in the UserEngineTests class.
     * The MockedUserAccessor implements the IUserAccessor, so it can be passed as an argument in the
     * UserEngine constructor.
     * The MockedUserAccessor uses a List of Users to act in place of the database in the regular UserAccessor.
     **/
    public class MockedUserAccessor : IUserAccessor
    {

        private List<User> users;

        public MockedUserAccessor()
        {
            users = new List<User>();
        }

        //Returns all Users
        public IEnumerable<User> GetAllUsers()
        {
            return users;
        }

        //Returns the User with the specified email
        public User GetUserEmail(string email)
        {
            return users.Find(u => u.email == email);
        }

        //Returns the User with the specified id
        public User Find(int id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

        //Returns the User with the specified username and password
        public User Find(String username, String password)
        {
            return users.FirstOrDefault(u => u.email == username && u.password == password);
        }

        //Inserts the specified User into the List of Users
        public User Insert(User user)
        {
            var max = users.Max(u => u.Id);
            user.Id = max + 1;
            users.Add(user);
            return user;
        }

        //Updates the specified User by removing the original and adding the new User
        public void Update(User user)
        {
            users.RemoveAll(u => u.Id == user.Id);
            users.Add(user);
        }

        //Deletes the User with the specified id from the List of Users
        public User Delete(int id)
        {
            var user = Find(id);
            users.Remove(user);
            return user;
        }

        //Returns true if the User with the specified id exists in the List of Users, and false if it does not
        public bool Exists(int id)
        {
            return users.Any(u => u.Id == id);
        }

        //Method is required by the IUserAccessor; in the regular accessor, saves changes made to the database
        public int SaveChanges()
        {
            return 0;
        }

        //Helper method for the MockedUserAccessor that sets the List of Users to a specified new state
        public void SetState(List<User> newState)
        {
            users = newState;
        }

        //Helper method for the MockedUserAccessor that returns the List of Users
        public List<User> GetState()
        {
            return users;
        }

    }
}
