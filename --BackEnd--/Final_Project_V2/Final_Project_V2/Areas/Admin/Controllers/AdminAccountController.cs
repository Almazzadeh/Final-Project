using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final_Project_V2.Models;
using System.Web.Helpers;

namespace Final_Project_V2.Areas.Admin.Controllers
{
    public class AdminAccountController : Controller
    {
        Final_ProjectEntities db = new Final_ProjectEntities();

        // GET: Admin/AdminAccount/Login
        public ActionResult Login()
        {
            return View();
        }


        // POST: Admin/AdminAccount/Login
        [HttpPost]
        public ActionResult Login(string AdminEmail, string AdminPassword)
        {
            Setting st = db.Setting.Find(1);
            if (AdminEmail != "" && AdminPassword != "")
            {
                if (st.AdminEmail == AdminEmail && Crypto.VerifyHashedPassword(st.AdminPassword, AdminPassword))
                {
                    Session["AdminLogged"] = true;
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ViewBag.AdminLoginError = "Email or Password is wrong!";
                }
            }
            else
            {
                ViewBag.AdminLoginError = "Email or Password cannot be empty!";
            }
            return View();
        }


        // GET: Admin/AdminAccount/Logout
        public ActionResult Logout()
        {
            Session["AdminLogged"] = null;
            return RedirectToAction("Login", "AdminAccount");
        }

    }
}