using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;

using CNW_N8_MVC.Models;

namespace CNW_N8_MVC.Controllers.Backend
{
    public class BackendHotelController : BaseController
    {
        private Model1 context = new Model1();
        static int id_Old;
        // GET: BackendHotel
        public ActionResult List()
        {
            dynamic model = new ExpandoObject();
            model.hotels = context.hotels.Where(x => x.id != 0).ToList();
            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit(string id)
        {
            if(id == null)
            {
                return RedirectToAction("List", "BackendHotel");
            }
            else
            {
                int a;
                bool check = int.TryParse(id.ToString(), out a);
                if (check == true)
                {
                    var model = context.hotels.Find(a);
                    if (model == null)
                    {
                        return RedirectToAction("List", "BackendHotel");
                    }
                    else
                    {
                        id_Old = a;
                        var listLocations = context.locations.Where(l => l.location_name != null).ToList();
                        ViewData["listLocations"] = listLocations;
                        return View(model);
                    }
                }
                else
                {
                    return RedirectToAction("List", "BackendHotel");
                }
            }
            
        }
        public int checkAddHotel(string location_id,string hotel_name,string description,string more_imformation,string price,string sell_price)
        {
            if (location_id == "" || hotel_name == "" || description == "" || more_imformation == "" || price == "" || sell_price == "")
            {
                return -1;
            }
            else
            {
                int a = int.Parse(location_id);
                //  var listHotel = context.hotels.Where(h => h.location.id == int.Parse(location_id)).ToList();
                var listHotel = context.hotels.Where(h => h.location_id == a).ToList();

                foreach(var it in listHotel)
                {
                    if(it.hotel_name == hotel_name)
                    {
                        return 0;
                    }
                }
                return 1;

            }
        }
        [HttpPost]
        public ActionResult AddHotel(hotel hotel)
        {
            hotel.image_url = "/Content/img/Group 68.png";
            hotel.detail_header_image_url = "/Content/img/hotel-detail.jpg";
            hotel.more_imformation_image_url = "/Content/img/Group 71.png";
            context.hotels.Add(hotel);
            context.SaveChanges();
            return RedirectToAction("List", "BackendHotel");
        }

        [HttpPost]
        public ActionResult EditHotel(hotel hotel)
        {
            hotel.image_url = "/Content/img/Group 68.png";
            hotel.detail_header_image_url = "/Content/img/hotel-detail.jpg";
            hotel.more_imformation_image_url = "/Content/img/Group 71.png";

            context.hotels.Remove(context.hotels.Find(id_Old));
            context.hotels.Add(hotel);
            context.SaveChanges();


            return RedirectToAction("List","BackendHotel");
        }


        public ActionResult DeleteHotel(string id)
        {
            if (id == null)
            {
                return RedirectToAction("List", "BackendHotel");
            }
            else
            {
                int a;
                bool check = int.TryParse(id.ToString(), out a);
                if (check == true)
                {
                    var result = context.hotels.Find(a);
                    if (result == null)
                    {
                        return RedirectToAction("List", "BackendHotel");
                    }
                    else
                    {
                        context.hotels.Remove(result);
                        context.SaveChanges();
                        return RedirectToAction("List", "BackendHotel");

                    }
                }
                else
                {
                    return RedirectToAction("List", "BackendHotel");
                }
            }
            
        }

        public int checkEditHotel(string location_id, string hotel_name, string description, string more_imformation, string price, string sell_price)
        {
            if (location_id == "" || hotel_name == "" || description == "" || more_imformation == "" || price == "" || sell_price == "")
            {
                return -1;
            }
            else
            {
                var result = context.hotels.Where(h => h.hotel_name == hotel_name).FirstOrDefault();
                var hotel_old = context.hotels.Find(id_Old);

                if (result == null || hotel_old.hotel_name == hotel_name)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}