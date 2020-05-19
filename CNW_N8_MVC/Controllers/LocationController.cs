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

            var minPrice = context.hotels.Min(h => h.sell_price);
            var maxPrice = context.hotels.Max(h => h.sell_price);
            ViewData["minPrice"] = minPrice.ToString();
            ViewData["maxPrice"] = maxPrice.ToString();

            return View(model);
        }
        [HttpGet]
        public ActionResult OptionChangeHotel(int? page)
        {
            var valueSelect = Request["select"];
            ViewData["location_Name"] = valueSelect;

            var model = context.hotels.OrderByDescending(m => m.id).Where(h => h.location.location_name == valueSelect).ToPagedList(page ?? 1, 9);
            ViewData["count"] = model.Count.ToString();
            var optionList = context.locations.ToList();
            ViewData["optionList"] = optionList;

            var minPrice = model.Min(h => h.sell_price);
            var maxPrice = model.Max(h => h.sell_price);
            ViewData["minPrice"] = minPrice.ToString();
            ViewData["maxPrice"] = maxPrice.ToString();

            return View("HotelList",model);
        }
        [HttpGet]
        public ActionResult SearchEngineHotel(int? page)
        {
            var txtSearch = Request["txtSearch"];
            ViewData["txtSearch"] = txtSearch;

            var model = context.hotels.OrderByDescending(m => m.id).Where(h => h.hotel_name.Contains(txtSearch)).ToPagedList(page ?? 1, 9);
            ViewData["count"] = model.Count.ToString();
            var optionList = context.locations.ToList();
            ViewData["optionList"] = optionList;

            var minPrice = model.Min(h => h.sell_price);
            var maxPrice = model.Max(h => h.sell_price);
            ViewData["minPrice"] = minPrice.ToString();
            ViewData["maxPrice"] = maxPrice.ToString();

            return View("HotelList",model);
        }
        public ActionResult HomestayList(int? page)
        {
            var model = context.homestays.OrderByDescending(m => m.id).ToPagedList(page ?? 1, 9);
            var list = context.homestays.ToList();
            ViewData["count"] = list.Count.ToString();

            var optionList = context.locations.ToList();
            ViewData["optionList"] = optionList;

            var minPrice = context.hotels.Min(h => h.sell_price);
            var maxPrice = context.hotels.Max(h => h.sell_price);
            ViewData["minPrice"] = minPrice.ToString();
            ViewData["maxPrice"] = maxPrice.ToString();

            return View(model);
        }
        [HttpGet]
        public ActionResult OptionChangeHomestay(int? page)
        {
            var valueSelect = Request["select"];
            ViewData["location_Name"] = valueSelect;

            var model = context.homestays.OrderByDescending(m => m.id).Where(h => h.location.location_name == valueSelect).ToPagedList(page ?? 1, 9);
            ViewData["count"] = model.Count.ToString();
            var optionList = context.locations.ToList();
            ViewData["optionList"] = optionList;

            var minPrice = model.Min(h => h.sell_price);
            var maxPrice = model.Max(h => h.sell_price);
            ViewData["minPrice"] = minPrice.ToString();
            ViewData["maxPrice"] = maxPrice.ToString();

            return View("HomestayList", model);
        }
        [HttpGet]
        public ActionResult SearchEngineHomestay(int? page)
        {
            var txtSearch = Request["txtSearch"];
            ViewData["txtSearch"] = txtSearch;

            var model = context.homestays.OrderByDescending(m => m.id).Where(h => h.homestay_name.Contains(txtSearch)).ToPagedList(page ?? 1, 9);
            ViewData["count"] = model.Count.ToString();
            var optionList = context.locations.ToList();
            ViewData["optionList"] = optionList;

            var minPrice = model.Min(h => h.sell_price);
            var maxPrice = model.Max(h => h.sell_price);
            ViewData["minPrice"] = minPrice.ToString();
            ViewData["maxPrice"] = maxPrice.ToString();

            return View("HomestayList", model);
        }
    }
}