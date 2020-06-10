using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Dynamic;

using CNW_N8_MVC.Models;


namespace CNW_N8_MVC.Areas.Backend.Controllers
{
    public class BackendBookingController : BaseController
    {
        // GET: BackendBooking
        private Model1 context = new Model1();
        public ActionResult List()
        {
            dynamic model = new ExpandoObject();
            model.hotel_bookings = context.hotel_booking.Where(x => x.id != 0).ToList();
            model.homestay_bookings = context.homestay_booking.Where(x => x.id != 0).ToList();
            return View(model);
        }
    }
}