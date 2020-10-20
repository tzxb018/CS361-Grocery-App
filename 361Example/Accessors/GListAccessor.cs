using _361Example.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace _361Example.Accessors
{
    public class GListAccessor : DbContext, IGListAccessor
    {

        private DbSet<GList> GroceryList { get; set; }

        //For testing purposes change the connection string to your personal DB's

        public GListAccessor() : base(GetOptions("Data Source=LAPTOP-FSV798M4;Initial Catalog=GroceryWebAppDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))

        {
            GroceryList = Set<GList>();
        }

        private static DbContextOptions GetOptions(String ConnectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), ConnectionString).Options;
        }

        public GList Delete(int id)
        {
            if (Exists(id))
            {
                var gList = Find(id);
                GroceryList.Remove(gList);
                base.SaveChanges();
                return gList;
            }

            return null;
        }

        public bool Exists(int id)
        {
            var gList = Find(id);
            if (gList == null)
            {
                return false;
            }
            return true;
        }

        public GList Find(int id)
        {
            return GroceryList.Find(id);
        }

        public IEnumerable<GList> GetAllGLists()
        {
            return GroceryList;
        }

        public GList Insert(GList gList)
        {
            GroceryList.Add(gList);
            base.SaveChanges();
            return gList;
        }

        public void Update(GList gList)
        {
            Entry(gList).State = EntityState.Modified;
        }
    }
}
