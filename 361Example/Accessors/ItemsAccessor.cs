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
    public class ItemsAccessor : DbContext, IDisposable, IItemAccessor
    {
        private DbSet<Item> Item { get; set; }

        public ItemsAccessor() : base(GetOptions("Server=tcp:grocerywebapp.database.windows.net,1433;Initial Catalog=GroceryWebAppDB;Persist Security Info=False;User ID=grociri;Password=#361_Group10_GroceryApp;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=60;"))

        {
            Item = Set<Item>();
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        //Returns true if an Item with the given id exists in the database, or false if not
        public bool Exists(int id)
        {
            return Item.Any(it => it.Id == id);
        }

        //Finds and returns the Item with the given id, or null if no such Item exists
        public Item Find(int id)
        {
            return Item.Find(id);
        }

        //Retrieves all Items
        public IEnumerable<Item> GetAllItems()
        {
            return Item;
        }

        //Gathers all of the items belonging to the indicated grocery list
        public IEnumerable<Item> GetItems(int groceryListId)
        {
            return Item.Where(it => it.GroceryListId == groceryListId).ToArray();
        }

        //Inserts item into the database and returns the inserted Item
        public Item Insert(Item item)
        {
            Item.Add(item);
            SaveChanges();
            return item;
        }

        //Updates the Item in the database with the same id as item to be the new version
        public void Update(Item item)
        {
            Entry(item).State = EntityState.Modified;
            SaveChanges();
        }

        /**
         * Deletes and returns from the database the Item with the given id if that Item exists
         * Returns null otherwise
         **/
        public Item Delete(int id)
        {
            if (Exists(id))
            {
                var item = Find(id);
                Item.Remove(item);
                SaveChanges();
                return item;
            }

            return null;
        }

        //Saves any changes made to the database by calling the DbContext SaveChanges() method
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

    }
}
