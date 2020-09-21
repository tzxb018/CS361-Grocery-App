using _361Example.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _361Example.Accessors
{
	public class UserAccessor : IUserAccessor
	{
		private DbSet<ApplicationUser> Users { get; set; }
		public UserAccessor()
		{
			//Users = DbSet<ApplicationUser>();
		}

        public IEnumerable<GroceryList> GetGroceryLists()
        {
            throw new NotImplementedException();
            //TODO: implement code
        }

        public GroceryList Find(int id)
        {
            throw new NotImplementedException();
            //TODO: implement code

        }

        public GroceryList Insert(GroceryList groceryList)
        {
            throw new NotImplementedException();
            //TODO: implement code

        }

        public void Update(GroceryList groceryList)
        {
            throw new NotImplementedException();
            //TODO: implement code

        }

        public GroceryList Delete(GroceryList groceryList)
        {
            throw new NotImplementedException();
            //TODO: implement code

        }

        public bool ListExists(int id)
        {
            throw new NotImplementedException();
            //TODO: implement code

        }
    }
}


