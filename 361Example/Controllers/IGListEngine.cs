using _361Example.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace _361Example.Controllers
{
    public interface IGListEngine
    {
        IEnumerable<Item> GetAllLists();
        GList GetList(int id);
        IEnumerable<GList> SortLists();
        GList InsertList(GList gList);
        GList UpdateList(int id, GList gList);
        GList DeleteList(int id);
    }
}
