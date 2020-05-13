using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNW_N8_MVC.Controllers
{
    public class LocationController : Controller
    {
        // GET: Location
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HotelList()
        {
            return View();
        }
        public ActionResult HomestayList()
        {
            return View();
        }
    }
}