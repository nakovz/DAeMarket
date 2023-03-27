using DAeMarket.Models;
using DAeMarket.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DAeMarket.Controllers
{
    public class UsersController : Controller
    {
        private readonly DAeMarketContext _context;

        public UsersController() {
            _context = new DAeMarketContext();
        }

        protected override void Dispose(bool disposing) {
            _context.Dispose();
        }

        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUpNewUser(UsersViewModel user) {

            if (!ModelState.IsValid) {
                user.Store = _context.Stores.FirstOrDefault(s => s.Id == user.Store.Id);
                return View("SignUpUser", user);
            }
            var isEmailAdmin = _context.Stores.FirstOrDefault(s => s.SuperUser == user.Email);
            if (isEmailAdmin == null) {
                var isUser = _context.Users.FirstOrDefault(u => u.Store.Id == user.Store.Id && u.Email == user.Email && u.Password == user.Password);
                if (isUser == null) {
                    user.Store = _context.Stores.SingleOrDefault(s => s.Id == user.Store.Id);
                    user.Credit = 0;
                    _context.Users.Add(new Users(user));
                    _context.SaveChanges();
                    return Content($"Congratulation! { user.Email } is succesfuly signUp!");
                } else {
                    return Content($"{ user.Email } is already used!");
                }
            }
            return Content($"{ isEmailAdmin.SuperUser } is forbiden to use as username!");
        }
    }
}