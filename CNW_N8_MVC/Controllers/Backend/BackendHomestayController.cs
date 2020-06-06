using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Dynamic;

using CNW_N8_MVC.Models;

namespace CNW_N8_MVC.Controllers.Backend
{
    public class BackendHomestayController : BaseController
    {
        private Model1 context = new Model1();
        // GET: BackendHomestay
        public ActionResult List()
        {
            dynamic model = new ExpandoObject();
            model.homestays = context.homestays.Where(x => x.id != 0).ToList();
            return View(model);
        }
    }
}