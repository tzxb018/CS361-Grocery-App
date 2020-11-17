using System;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;


namespace _361Example.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IHttpActionResult Login(string id, string pass)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult NewUser(string email, string pass)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult IncorrectLogin(string email, string pass)
        {
            throw new NotImplementedException();
        }


    }
}
