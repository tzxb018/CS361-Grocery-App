using _361Example.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace _361Example.Accessors
{
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

        public bool Exists(int id)
        {
            return Item.Any(c => c.Id == id);
        }

        public Item Find(int id)
        {
            return Item.Find(id);
        }

        public IEnumerable<Item> GetAllItems()
        {
            return Item;
        }

        //Gathers all of the items belonging to the indicated grocery list
        public IEnumerable<Item> GetItems(int groceryListId)
        {
            return Item.Where(i => i.GroceryListId == groceryListId).ToArray();
        }

        public Item Insert(Item item)
        {
            Item.Add(item);
            SaveChanges();
            return item;
        }

        public void Update(Item item)
        {
            Entry(item).State = EntityState.Modified;
            SaveChanges();
        }

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

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

    }
}
