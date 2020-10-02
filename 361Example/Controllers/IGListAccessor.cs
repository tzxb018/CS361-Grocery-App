using _361Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _361Example.Controllers
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
