using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final_Project_V2.Models;

namespace Final_Project_V2.Areas.Admin.Controllers
{
    [AuthorizationFilterController]
    public class MapController : Controller
    {
        Final_ProjectEntities db = new Final_ProjectEntities();
        // GET: Admin/Map
        public ActionResult Index()
        {
            ViewBag.Setting = db.Setting.First();
            return View();
        }

        // POST: Admin/Map
        [HttpPost]
        public ActionResult Index(string mapLocation)
        {
            db.Setting.First().Location = mapLocation;
            db.SaveChanges();
            return RedirectToAction("Index2", "Product");
        }
    }
}