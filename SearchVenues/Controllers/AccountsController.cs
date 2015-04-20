using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SearchVenues.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Username, string Password, string RememberMe, string ReturnUrl)
        {
            if (Username == "admin@admin.com" && Password == "Passwd")
            {
                Session["User"] = Username;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
    }
}