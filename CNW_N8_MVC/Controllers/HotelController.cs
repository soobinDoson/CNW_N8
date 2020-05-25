using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CNW_N8_MVC.Models;

namespace CNW_N8_MVC.Controllers
{
    public class HotelController : Controller
    {
        private Model1 context = new Model1();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            dynamic model = new ExpandoObject();
            model.hotels = context.hotels.Where(x => x.id != 0).ToList();
            return View(model);
        }
        public ActionResult Detail(int id)
        {
            dynamic model = new ExpandoObject();
            model.hotels = context.hotels.Where(x => x.id != 0).ToList();
            model.hotel = context.hotels.Where(x => x.id == id).FirstOrDefault();
            return View(model);
        }
    }
}