using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final_Project_V2.Models;

namespace Final_Project_V2.Controllers
{
    public class SmartTechController : Controller
    {
        Final_ProjectEntities db = new Final_ProjectEntities();

        //***** INDEX (HOME PAGE) *****
        public ActionResult Index()
        {
            ViewBag.Animation = db.Animation.ToList();
            ViewBag.AnimationSideTop = db.AnimationSideTop.First();
            ViewBag.AnimationSideBottom = db.AnimationSideBottom.First();
            ViewBag.FourDiv = db.FourDiv.Where(s => s.Status == true).ToList();
            ViewBag.Blog = db.Blog.Where(s => s.Status == true).OrderByDescending(s => s.Date).ToList();
            ViewBag.TopSelling = db.TopSelling.First();
            return View();
        }

        //***** ABOUT *****
        public ActionResult About()
        {
            ViewBag.AboutWallpaper = db.AboutWallpaper.First();
            ViewBag.FourDiv = db.FourDiv.ToList();
            ViewBag.OurTeam = db.OurTeam.ToList();
            return View();
        }

        //***** AUTHENTICATION *****
        public ActionResult Authentication()
        {
            return View();
        }

        // *************************** PRODUCT SECTION **********************************
        //***** PRODUCT - 3 - COLUMNS*****
        public ActionResult Product3()
        {
            ViewBag.Product = db.Product.ToList();
            //Product prd = db.Product.FirstOrDefault();
            //if(prd.Discount != null)
            //{

            //}
            return View();
        }

        //***** PRODUCT - 4 - COLUMNS*****
        public ActionResult Product4()
        {
            ViewBag.Product = db.Product.ToList();
            return View();
        }

        //***** PRODUCT - LIST *****
        public ActionResult ProductList()
        {
            ViewBag.Product = db.Product.ToList();
            return View();
        }

        //***** PRODUCT - DETAILS *****
        public ActionResult ProductDetails()
        {
            ViewBag.Product = db.Product.First();
            ViewBag.MobileOperator = db.MobileOperator.ToList();
            ViewBag.Shipping = db.Shipping.ToList();
            return View();
        }

        // *************************** PAYMENT SECTION **********************************
        //***** SHOPPING CART *****
        public ActionResult ShoppingCart()
        {
            return View();
        }

        //***** PAYMENT METHODS *****
        public ActionResult PaymentMethods()
        {
            return View();
        }

        //***** DELIVERY METHODS *****
        public ActionResult DeliveryMethods()
        {
            return View();
        }

        //***** CONFIRMATION *****
        public ActionResult Confirmation()
        {
            return View();
        }


        // *************************** SUCCESS--ERROR--CONTACT SECTION **********************************
        //***** SUCCESSFUL *****
        public ActionResult Successful()
        {
            return View();
        }

        //***** ERROR *****
        public ActionResult Error()
        {
            return View();
        }

        //***** CONTACT *****
        public ActionResult Contact()
        {
            return View();
        }



        // *************************** BLOG SECTION **********************************
        //***** BLOG *****
        public ActionResult Blog()
        {
            ViewBag.Blog = db.Blog.Where(s => s.Status == true).OrderByDescending(s => s.Date).ToList();
            return View();
        }

        //***** BLOG SINGLE *****
        public ActionResult BlogSingle()
        {
            ViewBag.BlogSingle = db.Blog.First();
            return View();
        }
    }
}