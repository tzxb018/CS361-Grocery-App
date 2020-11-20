using _361Example.Accessors;
using _361Example.Models;
using IdentityServer4.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _361Example.Engines
{
    public class GListEngine : IGListEngine
    {
        
        private readonly IGListAccessor _gListAccessor;
        
        public GListEngine(IGListAccessor gListAccessor)
        {
            _gListAccessor = gListAccessor;
        }

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

        public GList GetList(int id)
        {
            if (_gListAccessor.Exists(id))
            {
                return _gListAccessor.Find(id);
            }
            return null;
        }

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

        public GList UpdateList(int id, GList glist)
        {
            _gListAccessor.Update(glist);

            return glist;
        }

        public GList DeleteList(int id)
        {
            var glist = _gListAccessor.Find(id);
            if (glist != null)
            {
                _gListAccessor.Delete(id);
            }
            return glist;
        }

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
