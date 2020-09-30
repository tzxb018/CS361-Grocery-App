using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace _361Example.Models
{
    public class ApplicationUser : IdentityUser
    {

        public ApplicationUser(string email, string password, int id)
        {
            base.Email = email;
            string hashedPassword = password; //Here we would do encryption of password
            base.PasswordHash = hashedPassword;
            base.Id = id;
        }


    }
}
