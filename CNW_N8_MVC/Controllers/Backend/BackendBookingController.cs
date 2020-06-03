using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Dynamic;

using CNW_N8_MVC.Models;

namespace CNW_N8_MVC.Controllers.Backend
{
    public class BackendBookingController : Controller
    {
        // GET: BackendBooking
        private Model1 context = new Model1();
        // GET: BackendHomestaya
        public ActionResult List()
        {
            dynamic model = new ExpandoObject();
            model.hotel_bookings = context.hotel_booking.Where(x => x.id != 0).ToList();
            model.homestay_bookings = context.homestay_booking.Where(x => x.id != 0).ToList();
            return View(model);
        }
    }
}