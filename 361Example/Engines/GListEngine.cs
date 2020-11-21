using _361Example.Accessors;
using _361Example.Models;
using IdentityServer4.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _361Example.Engines
{
    /**
     * The GListEngine class handles the business logic relating to throwing exceptions
     * where appropriate and calling the methods of an IGListAccessor to access the database's GLists.
     **/
    public class GListEngine : IGListEngine
    {
        
        private readonly IGListAccessor _gListAccessor;
        
        public GListEngine(IGListAccessor gListAccessor)
        {
            _gListAccessor = gListAccessor;
        }

        //Returns all GLists
        public IEnumerable<GList> GetAllLists()
        {
            return _gListAccessor.GetAllGLists();
        }

        //This method will retrieve all of the lists attributed to a user
        //Returns list of GLists if successful, null if unsuccessful
        public IEnumerable<GList> GetUserLists(int userId)
        {
            return _gListAccessor.GetGLists(userId);
        }

        //Returns the GList with the given id, or null if no such GList exists
        public GList GetList(int id)
        {
            if (_gListAccessor.Exists(id))
            {
                return _gListAccessor.Find(id);
            }
            return null;
        }

        /**
         * Inserts the given glist.
         * Throws a new NullReferenceException() if glist is null.
         * Throws a new DuplicateNameException() if glist is equal to another GList belonging to
         * the same user, or if glist has the same name as another GList belonging to the same user.
         * Throws a new ArgumentException() if glist.Id is equal to the id of any other GList in the database.
         * Returns the inserted GList.
         **/
        public GList InsertList(GList glist)
        {
            if (glist == null)
            {
                throw new NullReferenceException();
            }

            IEnumerable<GList> allLists = GetAllLists();
            IEnumerable<GList> userLists = allLists.Where(g => g.AccountId == glist.AccountId);

            foreach (GList groceryList in userLists)
            {
                if (glist.Equals(groceryList))
                {
                    throw new DuplicateNameException();
                }
                else if (glist.ListName.Equals(groceryList.ListName))
                {
                    throw new DuplicateNameException();
                }
            }

            if (allLists.Any(g => g.Id == glist.Id))
            {
                throw new ArgumentException();
            }

            _gListAccessor.Insert(glist);

            return glist;
        }

        //Updates a GList in the database with the given glist
        public GList UpdateList(int id, GList glist)
        {
            _gListAccessor.Update(glist);

            return glist;
        }

        //Deletes the GList with the given id if the GList can be found, and returns the deleted GList
        //Otherwise, returns null
        public GList DeleteList(int id)
        {
            var glist = _gListAccessor.Find(id);
            if (glist != null)
            {
                _gListAccessor.Delete(id);
            }
            return glist;
        }

        //Sorts all GLists alphabetically
        //Throws a new ArgumentNullException() if ListName is null or empty for any GList
        public IEnumerable<GList> SortLists()
        {
            IEnumerable<GList> sortedGLists = _gListAccessor.GetAllGLists();
            foreach (GList gList in sortedGLists)
            {
                if (gList.ListName.IsNullOrEmpty())
                {
                    throw new ArgumentNullException();
                }
            }

            sortedGLists = sortedGLists.OrderBy(g => g.ListName);

            return sortedGLists;
        }

    }
}
