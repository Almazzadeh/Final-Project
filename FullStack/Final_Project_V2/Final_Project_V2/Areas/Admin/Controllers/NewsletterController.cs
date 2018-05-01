using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Final_Project_V2.Models;

namespace Final_Project_V2.Areas.Admin.Controllers
{
    [AuthorizationFilterController]
    public class NewsletterController : Controller
    {
        private Final_ProjectEntities db = new Final_ProjectEntities();


        // GET: Admin/Newsletter/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Newsletter newsletter = db.Newsletter.Find(id);
            if (newsletter == null)
            {
                return HttpNotFound();
            }
            return View(newsletter);
        }


        // GET: Admin/Newsletter/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Newsletter newsletter = db.Newsletter.Find(id);
            if (newsletter == null)
            {
                return HttpNotFound();
            }
            return View(newsletter);
        }

        // POST: Admin/Newsletter/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Header,Content")] Newsletter newsletter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsletter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/1");
            }
            return View(newsletter);
        }
        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
