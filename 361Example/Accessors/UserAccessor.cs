using _361Example.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace _361Example.Accessors
{
    public class UserAccessor : DbContext, IUserAccessor
    {
        private DbSet<User> Account { get; set; }

        //For testing purposes change the connection string to your personal DB's

        public UserAccessor() : base(GetOptions("Data Source=LAPTOP-FSV798M4;Initial Catalog=GroceryWebAppDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))

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
            if (user == null)
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
