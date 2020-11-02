using _361Example.Models;
using System.Collections.Generic;

namespace _361Example.Engines
{
    public interface IGListEngine
    {
        IEnumerable<GList> GetAllLists();
        IEnumerable<GList> GetUserLists(int userId);
        GList GetList(int id);
        IEnumerable<GList> SortLists();
        GList InsertList(GList gList);
        GList UpdateList(int id, GList gList);
        GList DeleteList(int id);
    }
}
