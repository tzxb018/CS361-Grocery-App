using _361Example.Models;
using System.Collections.Generic;

namespace _361Example.Accessors
{
    public interface IGListAccessor
    {
        IEnumerable<GList> GetAllGLists();
        IEnumerable<GList> GetGLists(int userId);
        GList Find(int id);
        GList Insert(GList gList);
        void Update(GList gList);
        GList Delete(int id);
        bool Exists(int id);
        int SaveChanges();
    }
}
