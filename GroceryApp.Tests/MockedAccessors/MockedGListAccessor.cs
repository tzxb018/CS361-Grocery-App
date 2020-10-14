using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using _361Example.Accessors;
using _361Example.Models;

namespace GroceryApp.Tests.MockedAccessors
{
    public class MockedGListAccessor : IGListAccessor
    {

        private List<GList> gLists;

        public MockedGListAccessor()
        {
            gLists = new List<GList>();
        }

        public IEnumerable<GList> GetAllGLists()
        {
            return gLists;
        }

        public GList Find(int id)
        {
            var gList = gLists.FirstOrDefault(g => g.Id == id);
            return gList;
        }

        public GList Insert(GList gList)
        {
            var max = gLists.Max(g => g.Id);
            gList.Id = max + 1;
            gLists.Add(gList);
            return gList;
        }

        public void Update(GList gList)
        {
            gLists.RemoveAll(g => g.Id == gList.Id);
            gLists.Add(gList);
        }

        public GList Delete(GList gList)
        {
            gLists.Remove(gList);
            return gList;
        }

        public bool Exists(int id)
        {
            for (int i = 0; i < gLists.Count; i = i + 1)
            {
                if (gLists.ElementAt(i).Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public void SetState(List<GList> newState)
        {
            gLists = newState;
        }

        public List<GList> GetState()
        {
            return gLists;
        }

    }
}
