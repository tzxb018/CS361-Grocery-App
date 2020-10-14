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
        private DbSet<User> Users { get; set; }
        public UserAccessor() : base(GetOptions("ApplicationDBContext"))
        {
            Users = Set<User>();
        }
        private static DbContextOptions GetOptions(String ConnectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), ConnectionString).Options;
        }
        public User Delete(User user)
        {
            if (Exists(user.Id))
            {
                Users.Remove(user);
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
            return Users.Find(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return Users;
        }

        public User Insert(User user)
        {
            Users.Add(user);
            base.SaveChanges();
            return user;
        }

        public void update(User user)
        {
            Entry(user).State = EntityState.Modified;
        }
    }
}
