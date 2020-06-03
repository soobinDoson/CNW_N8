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
            Session["CartSession"] = null;
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
            return View();
            
        }

        public int checkMK(string user, string pass)
        {
            var result = context.users.Where(a => (a.username == user && a.password == pass)).FirstOrDefault();
            
            if (result != null)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int checkDangKy(string user, string pass)
        {
            if(user == "" || pass == "")
            {
                return -1;
            }
            else
            {
                var result = context.users.Where(a => a.username == user).FirstOrDefault();
                if (result != null)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
        
        public int checkNewPassword(string nowPassword, string newPassword, string NewPassword2)
        {
            
            var result = context.users.Find(idAccount);
            if(result.password == nowPassword && newPassword != "" && NewPassword2 != "")
            {
                if(newPassword == NewPassword2)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return -1;
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterCenter(user acc)
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
            return RedirectToAction("Login","User");

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