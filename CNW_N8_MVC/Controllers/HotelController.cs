﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using CNW_N8_MVC.Models;

namespace CNW_N8_MVC.Controllers
{
    public class HotelController : Controller
    {
        private Model1 context = new Model1();
        IPagedList<hotel> model;
        int quantity;
        
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
        public ActionResult List(int? page)
        {
            setUsername();
            var optionList = context.locations.Where(o => o.id != null).ToList();
            ViewData["optionList"] = optionList;

            var model = context.hotels.OrderByDescending(h => h.id).ToPagedList(page ?? 1, 9);
            ViewData["count"] = model.Count.ToString() ;

            var minPrice = context.hotels.Min(h => h.sell_price);
            var maxPrice = context.hotels.Max(h => h.sell_price);
            ViewData["minPrice"] = minPrice.ToString();
            ViewData["maxPrice"] = maxPrice.ToString();

            return View(model);
        }


        [HttpGet]
        public ActionResult SearchEngine(int? page)
        {
            setUsername();
            var priceRange = Request["priceRange"];
            var locationSelect = Request["locationSelect"];
            var txtSearch = Request["txtSearch"];

            var optionList = context.locations.Where(o => o.id != null).ToList();
            ViewData["optionList"] = optionList;
            if (priceRange == "Dưới 300.000VNĐ")
            {
                model = context.hotels.OrderByDescending(h => h.id).Where(h => (h.location.location_name == locationSelect && (h.price < 300000) && h.hotel_name.Contains(txtSearch))).ToPagedList(page ?? 1, 9);
               
            }
            if(priceRange == "300.000- 500.000VNĐ")
            {
               
                 model = context.hotels.OrderByDescending(h => h.id).Where(h => (h.location.location_name == locationSelect && (h.price >= 300000 && h.price <500000) && h.hotel_name.Contains(txtSearch))).ToPagedList(page ?? 1, 9);
            }
            if(priceRange == "500.000- 1.000.000VNĐ")
            {
        
                  model = context.hotels.OrderByDescending(h => h.id).Where(h => (h.location.location_name == locationSelect && (h.price >= 500000 && h.price < 1000000) && h.hotel_name.Contains(txtSearch))).ToPagedList(page ?? 1, 9);
            }
            var minPrice = model.Min(h => h.sell_price);
            var maxPrice = model.Max(h => h.sell_price);
            ViewData["minPrice"] = minPrice.ToString();
            ViewData["maxPrice"] = maxPrice.ToString();
            ViewData["count"] = model.Count.ToString();
            ViewData["priceRange"] = priceRange.ToString();
            ViewData["locationSelect"] = locationSelect.ToString();
            ViewData["txtSearch"] = txtSearch.ToString();


            return View("List",model);
        }
        public ActionResult Detail(int? id)
        {
            if (id.HasValue)
            {
            setUsername();
            dynamic model = new ExpandoObject();
            model.hotels = context.hotels.Where(x => x.id != 0).ToList();
            model.hotel = context.hotels.Where(x => x.id == id).FirstOrDefault();
            ViewData["id"] = id.ToString();
            return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult AddItemHotel(int id)
        {
            if(Session["Login"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                DateTime checkIn = Convert.ToDateTime(Request["check_in"]);
                DateTime checkOut = Convert.ToDateTime(Request["check_out"]);
                if (checkOut <= checkIn)
                {
                    //Ngày đi lớn hơn ngày về//
                    return RedirectToAction("Detail", "Hotel", new { id = id });
                }
                else
                {
                    TimeSpan t = checkOut - checkIn;
                    quantity = (int)t.TotalDays;
                }

                var hotel = context.hotels.Find(id);
                var cart = (Cart)Session["CartSession"];
                if (cart != null)
                {
                    cart.AddItemHotel(hotel,checkIn.ToShortDateString(), checkOut.ToShortDateString(), quantity);
                }
                else
                {
                    cart = new Cart();
                    cart.AddItemHotel(hotel, checkIn.ToShortDateString(), checkOut.ToShortDateString(), quantity);
                    Session["CartSession"] = cart;
                }

                return RedirectToAction("Booking", "User");
            }
            

        }

        public int checkDate(string checkin, string checkout)
        {
            if(checkin == "" || checkout == "")
            {
                return -1;
            }
            else
            {
                DateTime checkIn = Convert.ToDateTime(checkin);
                DateTime checkOut = Convert.ToDateTime(checkout);

                if(checkOut <= checkIn)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }

            }

        }
    }
}