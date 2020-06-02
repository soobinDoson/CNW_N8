using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNW_N8_MVC.Models;

namespace CNW_N8_MVC.Controllers
{
    public class UserController : Controller
    {
        Model1 context = new Model1();
        public static int idAccount=0;
        public static string userName=null;
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Login()
        {
            return View();
        }
        
        public ActionResult Logout()
        {
            Session["Login"] = null;
            idAccount = 0;
            userName = null;
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult LoginCenter(user acc)
        {
            var result = context.users.Where(a => (a.username == acc.username && a.password == acc.password)).FirstOrDefault();
            if(result != null)
            {
                Session["Login"] = acc;
                idAccount = result.id;
                userName = result.username.ToString();
                ViewData["username"] = result.username.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {

                return View("Login");
            }
            
        }

        public ActionResult checkMK()
        {
            var result = context.users.Where(a => (a.username == Request["user"] && a.password == Request["pass"])).FirstOrDefault();
            string thongbao = "";
            if (result != null)
            {
                thongbao = "Tai khoan dc di tiep";
            }
            else
            {

                thongbao = "Tai khoan ko dc di tiep";
            }
            return Json(new { thongbao });
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterCenter(user acc)
        {
            var result = context.users.Where(a => (a.username == acc.username)).FirstOrDefault();
            if(result != null)
            {
                //Tài Khoản bị trùng//
                return View("Register");

            }
            else
            {
                //Tài Khoản ko bị trùng//
                try
                {
                    user newAcc = new user();
                    newAcc.username = acc.username;
                    newAcc.password = acc.password;
                    newAcc.full_name = acc.full_name;
                    newAcc.phone = acc.phone;
                    newAcc.address = acc.address;
                    newAcc.email = acc.email;
                    newAcc.role_id = 1;
                    context.users.Add(newAcc);
                    context.SaveChanges();
                    return View("Login");
                }
                catch
                {
                    return View();
                }
                
            }
            
        }

        public ActionResult Config()
        {
            if (Session["Login"] == null)
            {
                return View("Login");
            }
            else
            {
                var acc = context.users.Find(idAccount);
                ViewData["username"] = userName;
                ViewData["acc"] = acc;
                return View();
            }
            
        }

        public ActionResult Booking()
        {
            Cart cart;
            ViewData["username"] = userName;
            if (Session["Login"] == null)
            {
                return View("Login");
            }
            else
            {
                cart = (Cart)Session["CartSession"];
                if(cart == null)
                {
                    cart = new Cart();
                }
                return View(cart);
            }
        }

        [HttpGet]
        public ActionResult UserChanges(user acc)
        {
            var obj = context.users.Find(idAccount);
            obj.full_name = acc.full_name;
            obj.phone = acc.phone;
            obj.email = acc.email;
            obj.address = acc.address;

            context.SaveChanges();

            return RedirectToAction("Config", "User");
        }

        [HttpGet]
        public ActionResult PasswordChanges(string password, string newPassword1, string newPassword2)
        {
            var obj = context.users.Find(idAccount);
            if (password == "" || newPassword1 == "" || newPassword2 == "")
            {
                //Điền Thiếu thông tin//
                return RedirectToAction("Config", "User");
            }
            else
            {
              
                if(obj.password == password)
                {
                    if (newPassword1 == newPassword2)
                    {
                        obj.password = newPassword1;
                        context.SaveChanges();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {

                        //Thông tin chưa chính xác
                        return RedirectToAction("Config", "User");
                    }
                }
                else
                {
                    //Thông tin chưa chính xác
                    return RedirectToAction("Config", "User");
                }
            }
            
        }

        

        
    }
}