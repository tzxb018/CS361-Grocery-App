using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using _361Example.Accessors;
using _361Example.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GroceryApp.Tests.MockedAccessors
{
    public class MockedItemsAccessor : IItemAccessor
    {

        private List<Item> items;

        public MockedItemsAccessor()
        {
            items = new List<Item>();
        }

        public IEnumerable<Item> GetAllItems()
        {
            return items;
        }

        public IEnumerable<Item> GetItems(int groceryListId)
        {
            List<Item> itemList = new List<Item>();
            for(int i = 0; i < items.Count(); i++)
            {
                if(items[i].GroceryListId == groceryListId)
                {
                    itemList.Add(items[i]);
                }
            }
            return itemList;
        }

        public Item Find(int id)
        {
            var item = items.FirstOrDefault(it => it.Id == id);
            return item;
        }

        public Item Insert(Item item)
        {
            var max = items.Max(it => it.Id);
            item.Id = max + 1;
            items.Add(item);
            return item;
        }

        public void Update(Item item)
        {
            items.RemoveAll(it => it.Id == item.Id);
            items.Add(item);
        }

        public Item Delete(int id)
        {
            var item = Find(id);
            items.Remove(item);
            return item;
        }

        public bool Exists(int id)
        {
            for (int i = 0; i < items.Count; i = i + 1)
            {
                if (items.ElementAt(i).Id == id)
                {
                    return true;
                }
            }
            return false;
        }


        public void SetState(List<Item> newState)
        {
            items = newState;
        }

        public List<Item> GetState()
        {
            return items;
        }

        int IItemAccessor.SaveChanges()
        {
            return 0;
        }
    }
}
