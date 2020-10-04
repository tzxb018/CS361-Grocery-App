using _361Example.Models;
using System.Collections.Generic;

namespace _361Example.Accessors
{
    public interface IGListAccessor
    {
        IEnumerable<GList> GetAllGLists();
        GList Find(int id);
        GList Insert(GList gList);
        void Update(GList gList);
        GList Delete(GList gList);
        bool Exists(int id);
    }
}
