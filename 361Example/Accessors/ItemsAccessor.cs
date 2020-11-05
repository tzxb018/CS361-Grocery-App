using _361Example.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace _361Example.Accessors
{
    public class ItemsAccessor : DbContext, IDisposable, IItemAccessor
    {
        private DbSet<Item> Items { get; set; }

        // https://stackoverflow.com/questions/58159293/c-sharp-problem-with-dbcontext-argument-1-cannot-convert-string-to-microsof

        //For testing purposes change the connection string to your personal DB's

        public ItemsAccessor() : base(GetOptions("Server=tcp:grocerywebapp.database.windows.net,1433;Initial Catalog=GroceryWebAppDB;Persist Security Info=False;User ID=grociri;Password=#361_Group10_GroceryApp;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))

        {
            Items = Set<Item>();
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }


        public bool Exists(int id)
        {
            return Items.Any(c => c.Id == id);
        }

        public Item Find(int id)
        {
            return Items.Find(id);
        }

        public IEnumerable<Item> GetAllItems()
        {
            return Items;
        }

        public IEnumerable<Item> GetItems(int groceryListId)
        {
            return Items.Where(i => i.GroceryListId == groceryListId).ToArray();
        }

        // https://stackoverflow.com/questions/48363894/where-is-idbsett-in-entity-core
        public Item Insert(Item item)
        {
            return Items.Add(item).Entity;
        }

        public void Update(Item item)
        {
            Entry(item).State = EntityState.Modified;
        }

        public Item Delete(int id)
        {
            if (Exists(id))
            {
                var item = Find(id);
                Items.Remove(item);
                base.SaveChanges();
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
