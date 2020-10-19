using _361Example.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _361Example.Accessors
{
    public class UserAccessor : DbContext, IUserAccessor
    {
        private DbSet<User> Account { get; set; }

        //For testing purposes change the connection string to your personal DB's
<<<<<<< HEAD
        public UserAccessor() : base(GetOptions("Data Source=LAPTOP-33INMG0M\\SQLEXPRESS;Initial Catalog=GroceryWebAppDB;Integrated Security=True"))
=======
        public UserAccessor() : base(GetOptions("Data Source=DESKTOP-5G4TK7O\\SQLEXPRESS;Initial Catalog=GroceryWebAppDB;Integrated Security=True"))
>>>>>>> 5660c945e3a2dad94099f8ecbc2379c180bc21e1
        {
            Account = Set<User>();
        }
        private static DbContextOptions GetOptions(String ConnectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), ConnectionString).Options;
        }
        public User Delete(int id)
        {
            if (Exists(id))
            {
                var user = Find(id);
                Account.Remove(user);
                base.SaveChanges();
                return user;
            }

            return null;
        }

        public bool Exists(int id)
        {
            var user = Find(id);
            if(user == null)
            {
                return false;
            }
            return true;
        }

        public User Find(int id)
        {
            return Account.Find(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return Account;
        }

        public User Insert(User user)
        {
            Account.Add(user);
            base.SaveChanges();
            return user;
        }

        public void Update(User user)
        {
            Entry(user).State = EntityState.Modified;
            base.SaveChanges();
        }
    }
}
