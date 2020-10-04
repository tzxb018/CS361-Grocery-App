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
    public class GListAccessor : DbContext
    {

        private DbSet<GList> GLists { get; set; }

        public GListAccessor(String ConnectionString) : base(GetOptions(ConnectionString))
        {
            GLists = Set<GList>();
        }

        private static DbContextOptions GetOptions(String ConnectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), ConnectionString).Options;
        }

        public GList Delete(GList gList)
        {
            if (Exists(gList.Id))
            {
                GLists.Remove(gList);
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
            return GLists.Find(id);
        }

        public IEnumerable<GList> GetAllGLists()
        {
            return GLists;
        }

        public GList Insert(GList gList)
        {
            GLists.Add(gList);
            base.SaveChanges();
            return gList;
        }

        public void Update(GList gList)
        {
            Entry(gList).State = EntityState.Modified;
        }
    }
}
