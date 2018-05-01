using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            ViewBag.Product = db.Product.OrderByDescending(s => s.Date).Where(s => s.Status == true).ToList();
            ViewBag.Blog = db.Blog.Where(s => s.Status == true).OrderByDescending(s => s.Date).ToList();
            ViewBag.TopSelling = db.TopSelling.First();

            //PRODUCT TYPES STARTS
            ViewBag.SpecialProduct = db.Product.OrderByDescending(s => s.Date).Where(s => s.Status == true && s.Special == true).Take(5);
            ViewBag.OnsaleProduct = db.Product.OrderByDescending(s => s.Date).Where(s => s.Status == true && s.Onsale == true).Take(5);
            ViewBag.WeeklySaleProduct = db.Product.OrderByDescending(s => s.Date).Where(s => s.Status == true && s.Top_Selling_Week == true).Take(8);
            //PRODUCT TYPES END

            //PRODUCT CATEGORIES STARTS
            ViewBag.TV = db.Product.OrderByDescending(s => s.Date).Where(s => s.Status == true && s.Category_Id == 2).ToList();
            ViewBag.Phone = db.Product.OrderByDescending(s => s.Date).Where(s => s.Status == true && s.Category_Id == 13).Take(5);
            ViewBag.PC = db.Product.OrderByDescending(s => s.Date).Where(s => s.Status == true && s.Category_Id == 8).Take(5);
            ViewBag.GameConsole = db.Product.OrderByDescending(s => s.Date).Where(s => s.Status == true && s.Category_Id == 7).Take(5);
            ViewBag.Watch = db.Product.OrderByDescending(s => s.Date).Where(s => s.Status == true && s.Category_Id == 12).Take(5);
            ViewBag.Headphone = db.Product.OrderByDescending(s => s.Date).Where(s => s.Status == true && s.Category_Id == 4).Take(5);
            //PRODUCT CATEGORIES END

            // FOOTER STARTS
            ViewBag.Support = db.Support.Where(s => s.Status == true).ToList();
            ViewBag.Newsletter = db.Newsletter.First();
            ViewBag.Address = db.Address.First();
            ViewBag.SocialNetwork = db.SocialNetwork.Where(s => s.Status == true).ToList();
            //FOOTER ENDS
            return View();
        }

        //***** ABOUT *****
        public ActionResult About()
        {
            ViewBag.AboutWallpaper = db.AboutWallpaper.First();
            ViewBag.FourDiv = db.FourDiv.Where(s => s.Status == true).ToList();
            ViewBag.OurTeam = db.OurTeam.Where(s => s.Status == true).ToList();
            ViewBag.Skill = db.Skill.Where(s => s.Status == true).ToList();

            // FOOTER STARTS
            ViewBag.Support = db.Support.Where(s => s.Status == true).ToList();
            ViewBag.Newsletter = db.Newsletter.First();
            ViewBag.Address = db.Address.First();
            ViewBag.SocialNetwork = db.SocialNetwork.Where(s => s.Status == true).ToList();
            //FOOTER ENDS
            return View();
        }

        //***** AUTHENTICATION *****
        public ActionResult Authentication()
        {
            // FOOTER STARTS
            ViewBag.Support = db.Support.Where(s => s.Status == true).ToList();
            ViewBag.Newsletter = db.Newsletter.First();
            ViewBag.Address = db.Address.First();
            ViewBag.SocialNetwork = db.SocialNetwork.Where(s => s.Status == true).ToList();
            //FOOTER ENDS
            return View();
        }

        // *************************** PRODUCT SECTION **********************************
        //***** PRODUCT - 3 - COLUMNS*****
        public ActionResult Product3()
        {
            ViewBag.Product = db.Product.OrderByDescending(s => s.Date).Where(s => s.Status == true).ToList();

            // FOOTER STARTS
            ViewBag.Support = db.Support.Where(s => s.Status == true).ToList();
            ViewBag.Newsletter = db.Newsletter.First();
            ViewBag.Address = db.Address.First();
            ViewBag.SocialNetwork = db.SocialNetwork.Where(s => s.Status == true).ToList();
            //FOOTER ENDS
            return View();
        }

        //***** PRODUCT - 4 - COLUMNS*****
        public ActionResult Product4()
        {
            ViewBag.Product = db.Product.OrderByDescending(s => s.Date).Where(s => s.Status == true).ToList();

            // FOOTER STARTS
            ViewBag.Support = db.Support.Where(s => s.Status == true).ToList();
            ViewBag.Newsletter = db.Newsletter.First();
            ViewBag.Address = db.Address.First();
            ViewBag.SocialNetwork = db.SocialNetwork.Where(s => s.Status == true).ToList();
            //FOOTER ENDS
            return View();
        }

        //***** PRODUCT - LIST *****
        public ActionResult ProductList()
        {
            ViewBag.Product = db.Product.OrderByDescending(s => s.Date).Where(s => s.Status == true).ToList();

            // FOOTER STARTS
            ViewBag.Support = db.Support.Where(s => s.Status == true).ToList();
            ViewBag.Newsletter = db.Newsletter.First();
            ViewBag.Address = db.Address.First();
            ViewBag.SocialNetwork = db.SocialNetwork.Where(s => s.Status == true).ToList();
            //FOOTER ENDS
            return View();
        }

        //***** PRODUCT - DETAILS WITHOUT ID*****
        public ActionResult ProductDetails()
        {
            ViewBag.Product = db.Product.Where(s => s.Status == true).First();
            ViewBag.MobileOperator = db.MobileOperator.ToList();
            ViewBag.Shipping = db.Shipping.ToList();

            // FOOTER STARTS
            ViewBag.Support = db.Support.Where(s => s.Status == true).ToList();
            ViewBag.Newsletter = db.Newsletter.First();
            ViewBag.Address = db.Address.First();
            ViewBag.SocialNetwork = db.SocialNetwork.Where(s => s.Status == true).ToList();
            //FOOTER ENDS
            return View();
        }

        //***** PRODUCT - DETAILS WITH ID*****
        public ActionResult ProductSingle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            ViewBag.MobileOperator = db.MobileOperator.ToList();
            ViewBag.Shipping = db.Shipping.ToList();
            if (product == null)
            {
                return HttpNotFound();
            }

            // FOOTER STARTS
            ViewBag.Support = db.Support.Where(s => s.Status == true).ToList();
            ViewBag.Newsletter = db.Newsletter.First();
            ViewBag.Address = db.Address.First();
            ViewBag.SocialNetwork = db.SocialNetwork.Where(s => s.Status == true).ToList();
            //FOOTER ENDS
            return View(product);
        }


        // *************************** PAYMENT SECTION **********************************
        //***** SHOPPING CART *****
        public ActionResult ShoppingCart()
        {
            // FOOTER STARTS
            ViewBag.Support = db.Support.Where(s => s.Status == true).ToList();
            ViewBag.Newsletter = db.Newsletter.First();
            ViewBag.Address = db.Address.First();
            ViewBag.SocialNetwork = db.SocialNetwork.Where(s => s.Status == true).ToList();

            //FOOTER ENDS
            return View();
        }

        //***** PAYMENT METHODS *****
        public ActionResult PaymentMethods()
        {
            // FOOTER STARTS
            ViewBag.Support = db.Support.Where(s => s.Status == true).ToList();
            ViewBag.Newsletter = db.Newsletter.First();
            ViewBag.Address = db.Address.First();
            ViewBag.SocialNetwork = db.SocialNetwork.Where(s => s.Status == true).ToList();

            //FOOTER ENDS
            return View();
        }

        //***** DELIVERY METHODS *****
        public ActionResult DeliveryMethods()
        {
            // FOOTER STARTS
            ViewBag.Support = db.Support.Where(s => s.Status == true).ToList();
            ViewBag.Newsletter = db.Newsletter.First();
            ViewBag.Address = db.Address.First();
            ViewBag.SocialNetwork = db.SocialNetwork.Where(s => s.Status == true).ToList();

            //FOOTER ENDS
            return View();
        }

        //***** CONFIRMATION *****
        public ActionResult Confirmation()
        {
            // FOOTER STARTS
            ViewBag.Support = db.Support.Where(s => s.Status == true).ToList();
            ViewBag.Newsletter = db.Newsletter.First();
            ViewBag.Address = db.Address.First();
            ViewBag.SocialNetwork = db.SocialNetwork.Where(s => s.Status == true).ToList();

            //FOOTER ENDS
            return View();
        }


        // *************************** SUCCESS--ERROR--CONTACT SECTION **********************************
        //***** SUCCESSFUL *****
        public ActionResult Successful()
        {
            // FOOTER STARTS
            ViewBag.Support = db.Support.Where(s => s.Status == true).ToList();
            ViewBag.Newsletter = db.Newsletter.First();
            ViewBag.Address = db.Address.First();
            ViewBag.SocialNetwork = db.SocialNetwork.Where(s => s.Status == true).ToList();

            //FOOTER ENDS
            return View();
        }

        //***** ERROR *****
        public ActionResult Error()
        {
            // FOOTER STARTS
            ViewBag.Support = db.Support.Where(s => s.Status == true).ToList();
            ViewBag.Newsletter = db.Newsletter.First();
            ViewBag.Address = db.Address.First();
            ViewBag.SocialNetwork = db.SocialNetwork.Where(s => s.Status == true).ToList();

            //FOOTER ENDS
            return View();
        }

        //***** CONTACT *****
        public ActionResult Contact()
        {
            ViewBag.Address = db.Address.First();
            ViewBag.Setting = db.Setting.First();

            // FOOTER STARTS
            ViewBag.Support = db.Support.Where(s => s.Status == true).ToList();
            ViewBag.Newsletter = db.Newsletter.First();
            ViewBag.SocialNetwork = db.SocialNetwork.Where(s => s.Status == true).ToList();

            //FOOTER ENDS
            return View();
        }



        // *************************** BLOG SECTION **********************************
        //***** BLOG *****
        public ActionResult Blog()
        {
            ViewBag.Blog = db.Blog.Where(s => s.Status == true).OrderByDescending(s => s.Date).ToList();

            // FOOTER STARTS
            ViewBag.Support = db.Support.Where(s => s.Status == true).ToList();
            ViewBag.Newsletter = db.Newsletter.First();
            ViewBag.Address = db.Address.First();
            ViewBag.SocialNetwork = db.SocialNetwork.Where(s => s.Status == true).ToList();

            //FOOTER ENDS
            return View();
        }

        //***** BLOG SINGLE *****
        public ActionResult BlogSingle()
        {
            ViewBag.BlogSingle = db.Blog.First();

            // FOOTER STARTS
            ViewBag.Support = db.Support.Where(s => s.Status == true).ToList();
            ViewBag.Newsletter = db.Newsletter.First();
            ViewBag.Address = db.Address.First();
            ViewBag.SocialNetwork = db.SocialNetwork.Where(s => s.Status == true).ToList();

            //FOOTER ENDS
            return View();
        }

        //***** BLOG DETAILS *****
        public ActionResult BlogDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blog.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }

            // FOOTER STARTS
            ViewBag.Support = db.Support.Where(s => s.Status == true).ToList();
            ViewBag.Newsletter = db.Newsletter.First();
            ViewBag.Address = db.Address.First();
            ViewBag.SocialNetwork = db.SocialNetwork.Where(s => s.Status == true).ToList();

            //FOOTER ENDS
            return View(blog);
        }
    }
}