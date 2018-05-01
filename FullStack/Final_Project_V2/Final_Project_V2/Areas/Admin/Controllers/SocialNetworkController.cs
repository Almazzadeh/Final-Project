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
    public class SocialNetworkController : Controller
    {
        private Final_ProjectEntities db = new Final_ProjectEntities();

        // GET: Admin/SocialNetwork
        public ActionResult Index()
        {
            return View(db.SocialNetwork.ToList());
        }

        // GET: Admin/SocialNetwork/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialNetwork socialNetwork = db.SocialNetwork.Find(id);
            if (socialNetwork == null)
            {
                return HttpNotFound();
            }
            return View(socialNetwork);
        }

        // GET: Admin/SocialNetwork/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SocialNetwork/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Url,Icon,Status")] SocialNetwork socialNetwork)
        {
            if (ModelState.IsValid)
            {
                socialNetwork.Status = true;
                db.SocialNetwork.Add(socialNetwork);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(socialNetwork);
        }

        // GET: Admin/SocialNetwork/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialNetwork socialNetwork = db.SocialNetwork.Find(id);
            if (socialNetwork == null)
            {
                return HttpNotFound();
            }
            return View(socialNetwork);
        }

        // POST: Admin/SocialNetwork/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, [Bind(Include = "Id,Url,Icon,Status")] SocialNetwork socialNetwork)
        {
            if (ModelState.IsValid)
            {
                SocialNetwork activeNetwork = db.SocialNetwork.Find(id);
                activeNetwork.Url = socialNetwork.Url;
                activeNetwork.Icon = socialNetwork.Icon;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(socialNetwork);
        }

        // GET: Admin/SocialNetwork/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialNetwork socialNetwork = db.SocialNetwork.Find(id);
            if (socialNetwork == null)
            {
                return HttpNotFound();
            }
            return View(socialNetwork);
        }

        // POST: Admin/SocialNetwork/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SocialNetwork socialNetwork = db.SocialNetwork.Find(id);
            socialNetwork.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Admin/SocialNetwork/Show/5
        public ActionResult Show(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialNetwork socialNetwork = db.SocialNetwork.Find(id);
            if (socialNetwork == null)
            {
                return HttpNotFound();
            }
            return View(socialNetwork);
        }

        // POST: Admin/SocialNetwork/Delete/5
        [HttpPost, ActionName("Show")]
        [ValidateAntiForgeryToken]
        public ActionResult ShowConfirmed(int id)
        {
            SocialNetwork socialNetwork = db.SocialNetwork.Find(id);
            socialNetwork.Status = true;
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
