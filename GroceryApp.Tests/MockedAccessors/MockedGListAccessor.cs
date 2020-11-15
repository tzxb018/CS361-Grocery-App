using System.Collections.Generic;
using System.Linq;
using _361Example.Accessors;
using _361Example.Models;

namespace GroceryApp.Tests.MockedAccessors
{
    /**
     * The purpose of this class is to act as a Mock Accessor to be used in the GListEngine during unit testing.
     * The MockedGListAccessor implements the IGListAccessor, so it can be passed as an argument in the
     * GListEngine constructor.
     * The MockedGListAccessor uses a List of GLists to act as the database in the regular GListAccessor.
     **/
    public class MockedGListAccessor : IGListAccessor
    {

        private List<GList> gLists;

        public MockedGListAccessor()
        {
            gLists = new List<GList>();
        }

        //Returns all GLists
        public IEnumerable<GList> GetAllGLists()
        {
            return gLists;
        }

        //Returns all GLists for a specific user
        public IEnumerable<GList> GetGLists(int userId)
        {
            return gLists.FindAll(g => g.AccountId == userId);
        }

        //Returns the GList with the specified id
        public GList Find(int id)
        {
            return gLists.FirstOrDefault(g => g.Id == id);
        }

        //Inserts the specified GList into the List of GLists
        public GList Insert(GList gList)
        {
            var max = gLists.Max(g => g.Id);
            gList.Id = max + 1;
            gLists.Add(gList);
            return gList;
        }

        //Updates the specified GList by removing the original and adding the new GList
        public void Update(GList gList)
        {
            gLists.RemoveAll(g => g.Id == gList.Id);
            gLists.Add(gList);
        }

        //Deletes the GList with the specified id from the List of GLists
        public GList Delete(int id)
        {
            var gList = Find(id);
            gLists.Remove(gList);
            return gList;
        }

        //Returns true if the GList with the specified id exists in the List of GLists, and false if it does not
        public bool Exists(int id)
        {
            return gLists.Any(g => g.Id == id);
        }

        //Helper method for the MockedGListAccessor that sets the List of GLists to a specified new state
        public void SetState(List<GList> newState)
        {
            gLists = newState;
        }

        //Helper method for the MockedGListAccessor that returns the List of GLists
        public List<GList> GetState()
        {
            return gLists;
        }

    }
}
