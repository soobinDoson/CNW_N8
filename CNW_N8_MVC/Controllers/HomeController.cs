using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;

using CNW_N8_MVC.Models;

namespace CNW_N8_MVC.Controllers
{
    public class HomeController : Controller
    {
        private Model1 context = new Model1();
        private void setUsername()
        {
            if (Session["Login"] == null)
            {
                ViewData["username"] = null;
            }
            else
            {
                ViewData["username"] = UserController.userName;
            }
        }
        public ActionResult Index()
        {
            dynamic model = new ExpandoObject();
            model.hotels = context.hotels.Where(x => x.id != 0).ToList();
            model.homestays = context.homestays.Where(x => x.id != 0).ToList();
            model.locations = context.locations.Where(x => x.id != 0).ToList();
            setUsername();
            return View(model);
        }
    }
}