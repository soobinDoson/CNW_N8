using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CNW_N8_MVC.Models;

namespace CNW_N8_MVC.Controllers
{
    public class UserController : Controller
    {

        private Model1 context = new Model1();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(user user, string ReturnUrl)
        {
            var result = context.users.Where(a => a.username.Equals(user.username) &&
                                                       a.password.Equals(user.password)).FirstOrDefault();
            if (result != null)
            {
                Session["Login"] = user;
                if (string.IsNullOrEmpty(ReturnUrl))
                {

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Redirect(ReturnUrl);
                }

            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Config()
        {
            return View();
        }

        public ActionResult Booking()
        {
            return View();
        }
    }
}