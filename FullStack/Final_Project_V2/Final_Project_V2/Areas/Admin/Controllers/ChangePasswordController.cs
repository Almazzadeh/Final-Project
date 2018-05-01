using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Final_Project_V2.Models;

namespace Final_Project_V2.Areas.Admin.Controllers
{
    [AuthorizationFilterController]
    public class ChangePasswordController : Controller
    {
        Final_ProjectEntities db = new Final_ProjectEntities();

        // GET: Admin/ChangePassword
        public ActionResult Index()
        {
            ViewBag.Password = db.Setting.First();
            return View();
        }


        // POST: Admin/ChangePassword
        [HttpPost]
        public ActionResult Index( string oldPassword, string newPassword, string confirmPassword)
        {
            Setting st = db.Setting.Find(1);

            if(oldPassword != null && newPassword != null && confirmPassword != null)
            {
                if(Crypto.VerifyHashedPassword(st.AdminPassword, oldPassword))
                {
                    if(newPassword == confirmPassword)
                    {
                        st.AdminPassword = Crypto.HashPassword(newPassword);
                        db.SaveChanges();
                        return RedirectToAction("Index2", "Product");

                    }
                    else
                    {
                        ViewBag.PasswordError = "New Password not match with Confirm Password";
                    }
                }
                else
                {
                    ViewBag.PasswordError = "Current Password not match.";
                }
            }
            else
            {
                ViewBag.PasswordError = "Fill all fields.";
            }
            return View();
        }
    }
}