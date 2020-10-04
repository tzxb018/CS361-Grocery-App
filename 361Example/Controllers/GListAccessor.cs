using _361Example.Data;
using _361Example.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _361Example.Controllers
{
    public class GListAccessor : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        GListAccessor(ApplicationDbContext context)
        {
            _context = context;
        }

        public GList Delete(GList gList)
        {
            if(Exists(gList.Id))
            {
                _context.GList.Remove(gList);
                _context.SaveChanges();
                return gList;
            }

            return null;
        }

        public bool Exists(int id)
        {
            var gList = Find(id);
            if(gList == null)
            {
                return false;
            }
            return true;
        }

        public GList Find(int id)
        {
            return _context.GList.Find(id);
        }

        public IEnumerable<GList> GetAllGLists()
        {
            return _context.GList;
        }

        public GList Insert(GList gList)
        {
            _context.GList.Add(gList);
            _context.SaveChanges();
            return gList;
        }

        public void Update(GList gList)
        {
            throw new NotImplementedException();
        }

        //don't test until database is connected
        public IEnumerable<Item> GetGListItems(int id)
        {
            return _context.Item.FromSqlRaw("SELECT * FROM Item WHERE ListId = @id", id).ToList();
        }
    }
}
