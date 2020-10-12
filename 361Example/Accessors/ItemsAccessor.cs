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

        public ItemsAccessor() : base(GetOptions("ApplicationDBContext"))
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

        // https://stackoverflow.com/questions/48363894/where-is-idbsett-in-entity-core
        public Item Insert(Item item)
        {
            return Items.Add(item).Entity;
        }

        public void Update(Item item)
        {
            Entry(item).State = EntityState.Modified;
        }

        public Item Delete(Item item)
        {
            return Items.Remove(item).Entity;
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
