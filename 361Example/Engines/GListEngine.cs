using _361Example.Accessors;
using _361Example.Models;
using IdentityServer4.Extensions;
using System;
using System.Collections.Generic;
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


        public GList DeleteList(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetAllLists()
        {
            throw new NotImplementedException();
        }

        public GList GetList(int id)
        {
            throw new NotImplementedException();
        }

        public GList InsertList(GList gList)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GList> SortLists()
        {
            IEnumerable<GList> sortedGLists = _gListAccessor.GetAllGLists();
            foreach(GList gList in sortedGLists)
            {
                if (gList.ListName.IsNullOrEmpty())
                {
                    throw new ArgumentNullException();
                }
            }

            sortedGLists = sortedGLists.OrderBy(g => g.ListName);
         
            return sortedGLists;
        }

        public GList UpdateList(int id, GList gList)
        {
            throw new NotImplementedException();
        }

        IEnumerable<GList> IGListEngine.GetAllLists()
        {
            throw new NotImplementedException();
        }
    }
}
