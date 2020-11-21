using _361Example.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _361Example.Accessors
{
    /**
     * 
     **/
    public class UserAccessor : DbContext, IUserAccessor
    {
        private DbSet<User> Account { get; set; }

        public UserAccessor() : base(GetOptions("Server=tcp:grocerywebapp.database.windows.net,1433;Initial Catalog=GroceryWebAppDB;Persist Security Info=False;User ID=grociri;Password=#361_Group10_GroceryApp;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=60;"))

        {
            Account = Set<User>();
        }

        private static DbContextOptions GetOptions(String ConnectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), ConnectionString).Options;
        }

        /**
         * Deletes and returns from the database the User with the given id if that User exists
         * Returns null otherwise
         **/
        public User Delete(int id)
        {
            if (Exists(id))
            {
                var user = Find(id);
                Account.Remove(user);
                SaveChanges();
                return user;
            }

            return null;
        }

        //Returns true if a User with the given id exists in the database, or false if not
        public bool Exists(int id)
        {
            var user = Find(id);
            if (user == null)
            {
                return false;
            }
            return true;
        }

        //Finds and returns the User with the given id, or null if no such User exists
        public User Find(int id)
        {
            return Account.Find(id);
        }

        //Retrieves all Users
        public IEnumerable<User> GetAllUsers()
        {
            return Account;
        }

        //Inserts user into the database and returns the inserted User
        public User Insert(User user)
        {
            Account.Add(user);
            SaveChanges();
            return user;
        }

        //Updates the User in the database with the same id as user to be the new version
        public void Update(User user)
        {
            Entry(user).State = EntityState.Modified;
            SaveChanges();
        }

        //Retrieves User by their email
        public User GetUserByEmail(string email)
        {
            return Account.Where(u => u.Email == email).FirstOrDefault();
        }
        
        //Retrieves user by their email and password
        public User Find(string username, string password)
        {
            return Account.Where(u => u.Email == username && u.Password == password).FirstOrDefault();
        }

        //Saves any changes made to the database by calling the DbContext SaveChanges() method
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
