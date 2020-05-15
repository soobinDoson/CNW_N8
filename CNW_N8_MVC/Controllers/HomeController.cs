using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CNW_N8_MVC.Models;

namespace CNW_N8_MVC.Controllers
{
    public class HomeController : Controller
    {
        private Model1 context = new Model1();
        public ActionResult Index()
        {
            var model = context.hotels.Where(x => x.id != 0).ToList();
            return View(model);
        }
    }
}