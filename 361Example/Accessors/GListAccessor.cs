using _361Example.Data;
using _361Example.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _361Example.Accessors
{
    public class GListAccessor : DbContext, IGListAccessor
    {

        private DbSet<GList> GroceryList { get; set; }

        //For testing purposes change the connection string to your personal DB's
        public GListAccessor() : base(GetOptions("Data Source=DESKTOP-5G4TK7O\\SQLEXPRESS;Initial Catalog=GroceryWebAppDB;Integrated Security=True"))
        {
            GroceryList = Set<GList>();
        }

        private static DbContextOptions GetOptions(String ConnectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), ConnectionString).Options;
        }

        public GList Delete(GList gList)
        {
            if (Exists(gList.Id))
            {
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
