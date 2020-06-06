using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;

using CNW_N8_MVC.Models;

namespace CNW_N8_MVC.Controllers.Backend
{
    public class BackendUserController : BaseController
    {
        private Model1 context = new Model1();
        static int idAccount;
        // GET: User
        public ActionResult List()
        {
            dynamic model = new ExpandoObject();
            model.users = context.users.Where(x => x.id != 0).ToList();
            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Edit(string id)
        {
            int a;
            bool check = int.TryParse(id.ToString(), out a);
            if(check == true)
            {
                var model = context.users.Find(a);
                if (model == null)
                {
                    return RedirectToAction("List", "BackendUser");
                }
                else
                {
                    idAccount = a;
                    return View(model);
                }
            }
            else
            {
                return RedirectToAction("List", "BackendUser");
            }
            
            
        }
        [HttpPost]
        public ActionResult EditUser(user acc)
        {
            var result = context.users.Find(idAccount);
            context.users.Remove(result);
            context.users.Add(acc);
            context.SaveChanges();
            return RedirectToAction("List", "BackendUser");
        }
        [HttpPost]
        public ActionResult AddUser(user acc)
        {
            context.users.Add(acc);
            context.SaveChanges();
            return RedirectToAction("List", "BackendUser");
        }
        public int checkAddUser(string username, string password, string phone, string email, string address, string role_id, string full_name)
        {
            if (username == "" || password == "" || email == "" || address == "" || role_id == "" || full_name == "" || phone == "")
            {
                return -1;
            }
            else
            {
                var result = context.users.Where(u => (u.username == username)).FirstOrDefault();
                if(result == null)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int checkEditUser(string username, string password, string phone, string email, string address, string role_id, string full_name)
        {
            if (username == "" || password == "" || email == "" || address == "" || role_id == "" || full_name == "" || phone == "")
            {
                return -1;
            }
            else
            {
                var result = context.users.Where(u => (u.username == username)).FirstOrDefault();
                var oldUser = context.users.Where(u => u.id == idAccount).FirstOrDefault();
                if (result == null || result.username == oldUser.username)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }


        public ActionResult DeleteUser(string id)
        {
            int a;
            bool check = int.TryParse(id.ToString(), out a);
            if(check == true)
            {
                var result = context.users.Find(a);
                if(result == null)
                {
                    return RedirectToAction("List", "BackendUser");
                }
                else
                {
                    context.users.Remove(result);
                    context.SaveChanges();
                    return RedirectToAction("List", "BackendUser");
                }

            }
            else
            {
                return RedirectToAction("List", "BackendUser");
            }
            
        }
    }
}