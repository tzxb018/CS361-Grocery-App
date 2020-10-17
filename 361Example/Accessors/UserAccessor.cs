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
        public UserAccessor() : base(GetOptions("Data Source=SHEILA;Initial Catalog=GroceryWebAppDB;Integrated Security=True"))
        {
            Account = Set<User>();
        }
        private static DbContextOptions GetOptions(String ConnectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), ConnectionString).Options;
        }
        public User Delete(User user)
        {
            if (Exists(user.Id))
            {
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
