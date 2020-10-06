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

        public IEnumerable<GList> GetAllLists()
        {
            return _gListAccessor.GetAllGLists().ToList();
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
                _gListAccessor.Delete(glist);
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
