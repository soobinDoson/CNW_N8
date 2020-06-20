using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;

using CNW_N8_MVC.Models;
using System.IO;

namespace CNW_N8_MVC.Areas.Backend.Controllers
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
            if (id == null)
            {
                return RedirectToAction("List", "BackendHotel", new { area = "Backend" });
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
                        return RedirectToAction("List", "BackendHotel", new { area = "Backend" });
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
                    return RedirectToAction("List", "BackendHotel", new { area = "Backend" });
                }
            }

        }

        public int CheckNameHotelInLocations(string location_id, string hotel_name)
        {
            int a = int.Parse(location_id);
            var listHotel = context.hotels.Where(h => h.location_id == a).ToList();

            foreach (var it in listHotel)
            {
                if (it.hotel_name == hotel_name)
                {
                    return 0;
                }
            }
            return 1;

        }
        public int checkAddHotel(string location_id, string hotel_name, string description, string more_imformation, string price, string sell_price, string image_url, string detail_header_image_url, string more_imformation_image_url)
        {
            if (location_id == "" || hotel_name == "" || description == "" || more_imformation == "" || price == "" || sell_price == "" || image_url == "" || detail_header_image_url == "" || more_imformation_image_url == "")
            {
                return -1;
            }
            else
            {
                if (CheckNameHotelInLocations(location_id, hotel_name) == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
                //int a = int.Parse(location_id);
                ////  var listHotel = context.hotels.Where(h => h.location.id == int.Parse(location_id)).ToList();
                //var listHotel = context.hotels.Where(h => h.location_id == a).ToList();

                //foreach (var it in listHotel)
                //{
                //    if (it.hotel_name == hotel_name)
                //    {
                //        return 0;
                //    }
                //}
                //return 1;

            }
        }
        [HttpPost]
        public ActionResult AddHotel(hotel hotel, HttpPostedFileBase image_url, HttpPostedFileBase detail_header_image_url, HttpPostedFileBase more_imformation_image_url)
        {
            hotel.image_url = "/Content/img/hotel/hotel_image_url_" + hotel.id;
            hotel.detail_header_image_url = "/Content/img/hotel/hotel_detail_header_image_url_" + hotel.id;
            hotel.more_imformation_image_url = "/Content/img/hotel/hotel_more_imformation_image_url_" + hotel.id;
            context.hotels.Add(hotel);
            context.SaveChanges();
            int value = int.Parse(context.hotels.OrderByDescending(p => p.id).Select(r => r.id).First().ToString());
            string extention1 = Path.GetExtension(image_url.FileName);
            string extention2 = Path.GetExtension(detail_header_image_url.FileName);
            string extention3 = Path.GetExtension(more_imformation_image_url.FileName);
            hotel.image_url = "/Content/img/hotel/hotel_image_url_" + value + "." + extention1;
            hotel.detail_header_image_url = "/Content/img/hotel/hotel_detail_header_image_url_" + value + "." + extention2;
            hotel.more_imformation_image_url = "/Content/img/hotel/hotel_more_imformation_image_url_" + value + "." + extention3;
            context.SaveChanges();
            var path = Path.Combine(Server.MapPath("/Content/img/hotel"), "hotel_image_url_" + value + "." + extention1);
            var path2 = Path.Combine(Server.MapPath("/Content/img/hotel"), "hotel_detail_header_image_url_" + value + "." + extention2);
            var path3 = Path.Combine(Server.MapPath("/Content/img/hotel"), "hotel_more_imformation_image_url_" + value + "." + extention3);
            image_url.SaveAs(path);
            detail_header_image_url.SaveAs(path2);
            more_imformation_image_url.SaveAs(path3);
            return RedirectToAction("List", "BackendHotel", new { area = "Backend" });
        }
        //public void imageAdd(hotel hotel, HttpPostedFileBase image_url, HttpPostedFileBase detail_header_image_url, HttpPostedFileBase more_imformation_image_url)
        //{
        //    hotel.id = int.Parse(context.hotels.OrderByDescending(p => p.id).Select(r => r.id).First().ToString());
        //    var path = Path.Combine(Server.MapPath("~Content/img/hotel"), "hotel_image_url_" + hotel.id);
        //    var path2 = Path.Combine(Server.MapPath("~Content/img/hotel"), "hotel_detail_header_image_url_" + hotel.id);
        //    var path3 = Path.Combine(Server.MapPath("~Content/img/hotel"), "hotel_more_imformation_image_url_" + hotel.id);
        //    image_url.SaveAs(path);
        //    detail_header_image_url.SaveAs(path2);
        //    more_imformation_image_url.SaveAs(path3);
        //}

        [HttpPost]
        public ActionResult EditHotel(hotel hotel)
        {
            hotel.image_url = "/Content/img/Group 68.png";
            hotel.detail_header_image_url = "/Content/img/hotel-detail.jpg";
            hotel.more_imformation_image_url = "/Content/img/Group 71.png";

            context.hotels.Remove(context.hotels.Find(id_Old));
            context.hotels.Add(hotel);
            context.SaveChanges();


            return RedirectToAction("List", "BackendHotel", new { area = "Backend" });
        }


        public ActionResult DeleteHotel(string id)
        {
            if (id == null)
            {
                return RedirectToAction("List", "BackendHotel", new { area = "Backend" });
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
                        return RedirectToAction("List", "BackendHotel", new { area = "Backend" });
                    }
                    else
                    {
                        context.hotels.Remove(result);
                        context.SaveChanges();
                        return RedirectToAction("List", "BackendHotel", new { area = "Backend" });

                    }
                }
                else
                {
                    return RedirectToAction("List", "BackendHotel", new { area = "Backend" });
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
                // var hotel_new = context.hotels.Find(location_id);
                if (result == null || (hotel_old.hotel_name == hotel_name && hotel_old.location_id == int.Parse(location_id)) || CheckNameHotelInLocations(location_id, hotel_name) == 1)
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