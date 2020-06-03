using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;

using CNW_N8_MVC.Models;

namespace CNW_N8_MVC.Controllers.Backend
{
    public class BackendUserController : Controller
    {
        private Model1 context = new Model1();
        // GET: User
        public ActionResult List()
        {
            dynamic model = new ExpandoObject();
            model.users = context.users.Where(x => x.id != 0).ToList();
            return View(model);
        }

    }
}