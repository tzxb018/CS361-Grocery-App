using _361Example.Models;
using System.Collections.Generic;

namespace _361Example.Accessors
{
    /**
     * The IUserAccessor interface contains the method declarations for methods that must be defined
     * in any class whose purpose is to access Users. Likewise, any class that implements IUserAccessor
     * should be fully capable of accessing Users.
     **/
    public interface IUserAccessor
    {
        //Retrieves all Users
        IEnumerable<User> GetAllUsers();

        //Retrieves the User with the given email
        User GetUserByEmail(string email);

        //Finds and returns the User with the given id, or null if no such User exists
        User Find(int id);

        //Finds and returns the User that matches the given username and password, or null if no such User exists
        User Find(string username, string password);

        //Inserts user into the database and returns the inserted User
        User Insert(User user);

        //Updates the User in the database with the same id as user to be the new version
        void Update(User user);

        //Deletes the User with the given id from the database and returns the deleted User
        User Delete(int id);

        //Returns true if a User with the given id exists in the database, or false if not
        bool Exists(int id);

        //Saves any changes made to the database
        int SaveChanges();
    }
}
