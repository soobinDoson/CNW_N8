using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using CNW_N8_MVC.Models;

namespace CNW_N8_MVC.Controllers
{
    public class LocationController : Controller
    {
        Model1 context = new Model1();
        // GET: Location
        
        

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
            setUsername();
            
            return View();
        }
        public ActionResult HotelList(string locationName, int? page)
        {
            setUsername();
            ViewData["locationName"] = locationName;
            var model = context.hotels.OrderByDescending(m => m.id).Where(h => h.location.location_name == locationName).ToList();
            var list = context.hotels.ToList();
            ViewData["count"] = model.Count.ToString();

            var optionList = context.locations.ToList();
            ViewData["optionList"] = optionList;

            var minPrice = model.Min(h => h.sell_price);
            var maxPrice = model.Max(h => h.sell_price);
            ViewData["minPrice"] = minPrice.ToString();
            ViewData["maxPrice"] = maxPrice.ToString();

            return View(model);
        }
       
        
        public ActionResult HomestayList(string locationName, int? page)
        {
            setUsername();
            ViewData["locationName"] = locationName;
            var model = context.homestays.OrderByDescending(m => m.id).Where(h => h.location.location_name == locationName).ToList();
            var list = context.homestays.ToList();
            ViewData["count"] = model.Count.ToString();

            var optionList = context.locations.ToList();
            ViewData["optionList"] = optionList;

            var minPrice = model.Min(h => h.sell_price);
            var maxPrice = model.Max(h => h.sell_price);
            ViewData["minPrice"] = minPrice.ToString();
            ViewData["maxPrice"] = maxPrice.ToString();

            return View(model);
        }
      
        
    }
}