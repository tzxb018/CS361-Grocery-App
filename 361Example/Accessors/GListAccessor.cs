using _361Example.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _361Example.Accessors
{
    /**
     * The purpose of the GListAccessor is to access the GroceryList records of the database
     * and convert them to GList model instances.
     * This class implements the DbContext interface in order to access the database, as well as
     * the IGListAccessor interface for dependency injection purposes.
     **/
    public class GListAccessor : DbContext, IGListAccessor
    {

        private DbSet<GList> GroceryList { get; set; }

        public GListAccessor() : base(GetOptions("Server=tcp:grocerywebapp.database.windows.net,1433;Initial Catalog=GroceryWebAppDB;Persist Security Info=False;User ID=grociri;Password=#361_Group10_GroceryApp;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=60;"))

        {
            GroceryList = Set<GList>();
        }

        private static DbContextOptions GetOptions(String ConnectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), ConnectionString).Options;
        }

        /**
         * Deletes and returns from the database the GList with the given id if that GList exists
         * Returns null otherwise
         **/
        public GList Delete(int id)
        {
            if (Exists(id))
            {
                var gList = Find(id);
                GroceryList.Remove(gList);
                SaveChanges();
                return gList;
            }

            return null;
        }

        //Returns true if the GList with the given id exists in the database, or false if not
        public bool Exists(int id)
        {
            var gList = Find(id);
            if (gList == null)
            {
                return false;
            }
            return true;
        }

        //Finds and returns the GList with the given id, or null if no such GList exists
        public GList Find(int id)
        {
            return GroceryList.Find(id);
        }

        //Retrieves all GLists
        public IEnumerable<GList> GetAllGLists()
        {
            return GroceryList;
        }

        /** 
         * Gathers and returns all of the GLists associated with the indicated User from userId
         * Uses the database's stored procedure 'Find_GroceryLists_For_Given_Account' to do this
         * The use of the DbSet.FromSqlInterpolated() method protects against SQLi attacks
         **/
        public IEnumerable<GList> GetGLists(int userId)
        {
            return GroceryList.FromSqlInterpolated($"EXEC Find_GroceryLists_For_Given_Account @userId = {userId}").ToArray();
        }

        //Inserts gList into the database and returns the inserted GList
        public GList Insert(GList gList)
        {
            GroceryList.Add(gList);
            SaveChanges();
            return gList;
        }

        //Updates the GList in the database with the same id as gList to be the new version
        public void Update(GList gList)
        {
            Entry(gList).State = EntityState.Modified;
            SaveChanges();
        }

        //Saves changes made to the database using the DbContext SaveChanges() method
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

    }
}
