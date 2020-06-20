using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Dynamic;

using CNW_N8_MVC.Models;

namespace CNW_N8_MVC.Areas.Backend.Controllers
{
    public class BackendHomestayController : BaseController
    {
        private Model1 context = new Model1();
        static int id_old;
        // GET: BackendHomestay
        public ActionResult List()
        {
            dynamic model = new ExpandoObject();
            model.homestays = context.homestays.Where(x => x.id != 0).ToList();
            return View(model);
        }

        public ActionResult Add()
        {
            var listLocation = context.locations.ToList();
            ViewData["listLocation"] = listLocation;
            return View();
        }

        [HttpPost]
        public ActionResult AddHomestay(homestay acc)
        {
            acc.detail_header_image_url = "/Content/img/Group 65.png";
            acc.image_url = "/Content/img/Group 65.png";
            acc.more_imformation_image_url = "/Content/img/Group 65.png";
            acc.description = "This is Description";
            context.homestays.Add(acc);
            context.SaveChanges();
            return RedirectToAction("List", "BackendHomestay", new { area = "Backend" });
        }
        [HttpPost]
        public int checkAddHomeStay(string homestay_name, string location_id, string price, string sell_price)
        {
            if (homestay_name == "" || location_id == "" || price == "" || sell_price == "")
            {
                return -1;
            }
            else
            {
                var result = context.homestays.Where(u => (u.homestay_name == homestay_name)).FirstOrDefault();
                if (result == null)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return RedirectToAction("List", "BackendHomestay", new { area = "Backend" });
            }
            else
            {
                int a;
                bool check = int.TryParse(id.ToString(), out a);
                if (check == true)
                {
                    var model = context.homestays.Find(a);
                    if (model == null)
                    {
                        return RedirectToAction("List", "BackendHomestay", new { area = "Backend" });
                    }
                    else
                    {
                        id_old = a;
                        //lay danh sach location sang ben view Edit//

                        var listLocation = context.locations.ToList();
                        ViewData["listLocation"] = listLocation;

                        return View(model);
                    }
                }
                else
                {
                    return RedirectToAction("List", "BackendHomestay", new { area = "Backend" });
                }
            }

        }


        [HttpPost]
        public ActionResult EditHomestay(homestay acc)
        {
            var result = context.homestays.Find(id_old);
            acc.detail_header_image_url = "/Content/img/Group 65.png";
            acc.image_url = "/Content/img/Group 65.png";
            acc.more_imformation_image_url = "/Content/img/Group 65.png";
            acc.description = "This is Description";

            context.homestays.Remove(result);
            context.homestays.Add(acc);
            context.SaveChanges();
            return RedirectToAction("List", "BackendHomestay", new { area = "Backend" });
        }
        public int checkEditHomestay(string homestay_name, string location_id, string price, string sell_price)
        {
            if (homestay_name == "" || location_id == "" || price == "" || sell_price == "")
            {
                return -1;
            }
            else
            {
                var result = context.homestays.Where(u => (u.homestay_name == homestay_name)).FirstOrDefault();
                var userOld = context.homestays.Find(id_old);

                if (result == null || (result.homestay_name == userOld.homestay_name))
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }

        /*
                public ActionResult DeleteHomestay(string id)
                {
                    if (id == null)
                    {
                        return RedirectToAction("List", "BackendHomestay", new { area = "Backend" });
                    }
                    else
                    {
                        int a;
                        bool check = int.TryParse(id.ToString(), out a);
                        if (check == true)
                        {
                            var result = context.homestays.Find(a);
                            if (result == null)
                            {
                                return RedirectToAction("List", "BackendHomestay", new { area = "Backend" });
                            }
                            else
                            {
                                context.homestays.Remove(result);
                                context.SaveChanges();
                                return RedirectToAction("List", "BackendHomestay", new { area = "Backend" });
                            }

                        }
                        else
                        {
                            return RedirectToAction("List", "BackendHomestay", new { area = "Backend" });
                        }
                    }

                }
        */
        public void DeleteHomestay(string id)
        {
            try
            {
                int ID = int.Parse(id);
                var result = context.homestays.Find(ID);
                context.homestays.Remove(result);
                context.SaveChanges();
            }
            catch(Exception)
            {

            }
        }
        public ActionResult LogoutBackend()
        {
            Session["LoginBackend"] = null;

            return RedirectToAction("Index", "Home", new { area = "Backend" });
        }
    }
}