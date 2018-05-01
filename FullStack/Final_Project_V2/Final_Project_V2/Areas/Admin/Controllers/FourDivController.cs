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
    public class FourDivController : Controller
    {
        private Final_ProjectEntities db = new Final_ProjectEntities();

        // GET: Admin/FourDiv
        public ActionResult Index()
        {
            return View(db.FourDiv.ToList());
        }

        // GET: Admin/FourDiv/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FourDiv fourDiv = db.FourDiv.Find(id);
            if (fourDiv == null)
            {
                return HttpNotFound();
            }
            return View(fourDiv);
        }

        // GET: Admin/FourDiv/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/FourDiv/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Icon,Header,Content")] FourDiv fourDiv)
        {
            if (ModelState.IsValid)
            {
                fourDiv.Status = true;
                db.FourDiv.Add(fourDiv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fourDiv);
        }

        // GET: Admin/FourDiv/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FourDiv fourDiv = db.FourDiv.Find(id);
            if (fourDiv == null)
            {
                return HttpNotFound();
            }
            return View(fourDiv);
        }

        // POST: Admin/FourDiv/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, [Bind(Include = "Id,Icon,Header,Content")] FourDiv fourDiv)
        {
            if (ModelState.IsValid)
            {
                FourDiv activeIcon = db.FourDiv.Find(id);

                activeIcon.Icon = fourDiv.Icon;
                activeIcon.Header = fourDiv.Header;
                activeIcon.Content = fourDiv.Content;
                //activeIcon.Status = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fourDiv);
        }

        // GET: Admin/FourDiv/Hide/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FourDiv fourDiv = db.FourDiv.Find(id);
            if (fourDiv == null)
            {
                return HttpNotFound();
            }
            return View(fourDiv);
        }

        // POST: Admin/FourDiv/Hide/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FourDiv fourDiv = db.FourDiv.Find(id);
            fourDiv.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Admin/FourDiv/Show/5
        public ActionResult Show(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FourDiv fourDiv = db.FourDiv.Find(id);
            if (fourDiv == null)
            {
                return HttpNotFound();
            }
            return View(fourDiv);
        }

        // POST: Admin/FourDiv/Show/5
        [HttpPost, ActionName("Show")]
        [ValidateAntiForgeryToken]
        public ActionResult ShowConfirmed(int id)
        {
            FourDiv fourDiv = db.FourDiv.Find(id);
            fourDiv.Status = true;
            db.SaveChanges();
            return RedirectToAction("Index");
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
