using System;
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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(int? page)
        {
            var model = context.homestays.OrderByDescending(m => m.id).ToPagedList(page ?? 1, 9);
            var list = context.homestays.ToList();
            var optionList = context.homestays.ToList();
            ViewData["count"] = list.Count.ToString();
            ViewData["optionList"] = optionList;
            return View(model);
        }

        [HttpGet]
        public ActionResult OptionChange(int? page)
        {
            var valueSelect = Request["select"];
            ViewData["homestays_Name"] = valueSelect;

            var model = context.homestays.OrderByDescending(m => m.id).Where(h =>h.homestay_name == valueSelect).ToPagedList(page ?? 1, 9);
            ViewData["count"] = model.Count.ToString();
            var optionList = context.locations.ToList();
            ViewData["optionList"] = optionList;

            return View("HomestayList", model);
        }
        [HttpGet]
        public ActionResult SearchEngine(int? page)
        {
            var txtSearch = Request["txtSearch"];
            ViewData["txtSearch"] = txtSearch;

            var model = context.homestays.OrderByDescending(m => m.id).Where(h => h.homestay_name.Contains(txtSearch)).ToPagedList(page ?? 1, 9);
            ViewData["count"] = model.Count.ToString();
            var optionList = context.homestays.ToList();
            ViewData["optionList"] = optionList;

            return View("HomestayList", model);
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