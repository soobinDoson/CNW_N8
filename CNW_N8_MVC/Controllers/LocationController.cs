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
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HotelList(int? page)
        {
            var model = context.hotels.OrderByDescending(m => m.id).ToPagedList(page ?? 1, 9);
            var list = context.hotels.ToList();
            ViewData["count"] = list.Count.ToString();

            var optionList = context.locations.ToList();
            ViewData["optionList"] = optionList;
            return View(model);
        }
        [HttpGet]
        public ActionResult OptionChange(int? page)
        {
            var valueSelect = Request["select"];
            ViewData["location_Name"] = valueSelect;

            var model = context.hotels.OrderByDescending(m => m.id).Where(h => h.location.location_name == valueSelect).ToPagedList(page ?? 1, 9);
            ViewData["count"] = model.Count.ToString();
            var optionList = context.locations.ToList();
            ViewData["optionList"] = optionList;

            return View("HotelList",model);
        }
        [HttpGet]
        public ActionResult SearchEngine(int? page)
        {
            var txtSearch = Request["txtSearch"];
            ViewData["txtSearch"] = txtSearch;

            var model = context.hotels.OrderByDescending(m => m.id).Where(h => h.hotel_name.Contains(txtSearch)).ToPagedList(page ?? 1, 9);
            ViewData["count"] = model.Count.ToString();
            var optionList = context.locations.ToList();
            ViewData["optionList"] = optionList;

            return View("HotelList",model);
        }
        public ActionResult HomestayList()
        {
            return View();
        }
    }
}