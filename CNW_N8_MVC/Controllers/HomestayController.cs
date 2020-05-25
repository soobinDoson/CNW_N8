﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using CNW_N8_MVC.Models;
using System.Dynamic;

namespace CNW_N8_MVC.Controllers
{
    public class HomestayController : Controller
    {
        Model1 context = new Model1();
        // GET: Homestay
        IPagedList<homestay> model;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(int? page)
        {
            var optionList = context.locations.Where(o => o.id != null).ToList();
            ViewData["optionList"] = optionList;

            var model = context.homestays.OrderByDescending(h => h.id).ToPagedList(page ?? 1, 9);
            ViewData["count"] = model.Count.ToString();

            var minPrice = context.homestays.Min(h => h.sell_price);
            var maxPrice = context.homestays.Max(h => h.sell_price);
            ViewData["minPrice"] = minPrice.ToString();
            ViewData["maxPrice"] = maxPrice.ToString();

            return View(model);
        }

        
        
        [HttpGet]
        public ActionResult SearchEngine(int? page)
        {
            var priceRange = Request["priceRange"];
            var locationSelect = Request["locationSelect"];
            var txtSearch = Request["txtSearch"];

            var optionList = context.locations.Where(o => o.id != null).ToList();
            ViewData["optionList"] = optionList;
            if (priceRange == "Dưới 300.000VNĐ")
            {
                model = context.homestays.OrderByDescending(h => h.id).Where(h => (h.location.location_name == locationSelect && (h.price < 300000) && h.homestay_name.Contains(txtSearch))).ToPagedList(page ?? 1, 9);

            }
            if (priceRange == "300.000- 500.000VNĐ")
            {

                model = context.homestays.OrderByDescending(h => h.id).Where(h => (h.location.location_name == locationSelect && (h.price >= 300000 && h.price < 500000) && h.homestay_name.Contains(txtSearch))).ToPagedList(page ?? 1, 9);
            }
            if (priceRange == "500.000- 1.000.000VNĐ")
            {

                model = context.homestays.OrderByDescending(h => h.id).Where(h => (h.location.location_name == locationSelect && (h.price >= 500000 && h.price < 1000000) && h.homestay_name.Contains(txtSearch))).ToPagedList(page ?? 1, 9);
            }
            var minPrice = model.Min(h => h.sell_price);
            var maxPrice = model.Max(h => h.sell_price);
            ViewData["minPrice"] = minPrice.ToString();
            ViewData["maxPrice"] = maxPrice.ToString();
            ViewData["count"] = model.Count.ToString();
            ViewData["priceRange"] = priceRange.ToString();
            ViewData["locationSelect"] = locationSelect.ToString();
            ViewData["txtSearch"] = txtSearch.ToString();


            return View("List", model);
        }
        public ActionResult Detail(int id)
        {
            dynamic model = new ExpandoObject();
            model.homestays = context.homestays.Where(x => x.id != 0).ToList();
            model.homestay = context.homestays.Where(x => x.id == id).FirstOrDefault();
            return View(model);
        }
    }
}