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
    public class BlogCommentController : Controller
    {
        private Final_ProjectEntities db = new Final_ProjectEntities();

        // GET: Admin/BlogComment
        public ActionResult Index()
        {
            var blogComment = db.BlogComment.Include(b => b.Blog);
            return View(blogComment.OrderByDescending(s => s.Date).ToList());
        }

        // GET: Admin/BlogComment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogComment blogComment = db.BlogComment.Find(id);
            if (blogComment == null)
            {
                return HttpNotFound();
            }
            return View(blogComment);
        }

        
        // GET: Admin/BlogComment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogComment blogComment = db.BlogComment.Find(id);
            if (blogComment == null)
            {
                return HttpNotFound();
            }
            return View(blogComment);
        }

        // POST: Admin/BlogComment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogComment blogComment = db.BlogComment.Find(id);
            blogComment.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Admin/BlogComment/Delete/5
        public ActionResult Show(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogComment blogComment = db.BlogComment.Find(id);
            if (blogComment == null)
            {
                return HttpNotFound();
            }
            return View(blogComment);
        }

        // POST: Admin/BlogComment/Delete/5
        [HttpPost, ActionName("Show")]
        [ValidateAntiForgeryToken]
        public ActionResult ShowConfirmed(int id)
        {
            BlogComment blogComment = db.BlogComment.Find(id);
            blogComment.Status = true;
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
