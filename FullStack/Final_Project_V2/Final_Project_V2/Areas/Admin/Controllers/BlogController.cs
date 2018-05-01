using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Final_Project_V2.Models;
using System.IO;

namespace Final_Project_V2.Areas.Admin.Controllers
{
    [AuthorizationFilterController]
    public class BlogController : Controller
    {
        private Final_ProjectEntities db = new Final_ProjectEntities();

        // GET: Admin/Blog
        public ActionResult Index()
        {
            return View(db.Blog.OrderByDescending(s => s.Date).ToList());
        }

        // GET: Admin/Blog/Details/5
        public ActionResult Details(int? id)
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
            return View(blog);
        }

        // GET: Admin/Blog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Blog/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Image,Header,Paragraph_1,StrongText,Author,Date,Status")] Blog blog, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    string fileName = null;
                    string today = DateTime.Now.ToString("yyyy-MM-dd");
                    if (Image.ContentLength > 0 && Image.ContentLength <= 3 * 1024 * 1024)
                    {
                        if (Image.ContentType.ToLower() == "image/jpeg" ||
                            Image.ContentType.ToLower() == "image/jpg" ||
                            Image.ContentType.ToLower() == "image/png" ||
                            Image.ContentType.ToLower() == "image/gif"
                        )
                        {
                            DateTime dt = DateTime.Now;
                            var beforeStr = dt.Year + "_" + dt.Month + "_" + dt.Day + "_" + dt.Hour + "_" + dt.Minute + "_" + dt.Second;
                            fileName = beforeStr + Path.GetFileName(Image.FileName);
                            var newFilePath = Path.Combine(Server.MapPath("~/Public/images/"), fileName);

                            Image.SaveAs(newFilePath);
                            blog.Image = fileName;
                            blog.Date = dt;
                            blog.Status = true;
                        }
                        else
                        {
                            ViewBag.EditError = "Photo type is not valid.";
                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.EditError = "Photo type should not be more than 3 MB.";
                        return View();
                    }
                }
                else
                {
                    blog.Image = "default.jpg";
                    blog.Date = DateTime.Now;
                    blog.Status = true;
                }
                db.Blog.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: Admin/Blog/Edit/5
        public ActionResult Edit(int? id)
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
            return View(blog);
        }

        // POST: Admin/Blog/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, [Bind(Include = "Id,Image,Header,Paragraph_1,StrongText,Author,Date,Status")] Blog blog, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                Blog activeBlog = db.Blog.Find(id);
                if (activeBlog != null)
                {
                    string fileName = null;
                    if (Image != null)
                    {
                        if (Image.ContentLength > 0 && Image.ContentLength <= 3 * 1024 * 1024)
                        {
                            if (Image.ContentType.ToLower() == "image/jpeg" ||
                                Image.ContentType.ToLower() == "image/jpg" ||
                                Image.ContentType.ToLower() == "image/png" ||
                                Image.ContentType.ToLower() == "image/gif"
                            )
                            {
                                //var path = Path.Combine(Server.MapPath("~/Public/images/"), activeBlog.Image);

                                //if (System.IO.File.Exists(path))
                                //{
                                //    System.IO.File.Delete(path);
                                //}

                                DateTime dt = DateTime.Now;
                                var beforeStr = dt.Year + "_" + dt.Month + "_" + dt.Day + "_" + dt.Hour + "_" + dt.Minute + "_" + dt.Second;
                                fileName = beforeStr + Path.GetFileName(Image.FileName);
                                var newFilePath = Path.Combine(Server.MapPath("~/Public/images/"), fileName);

                                Image.SaveAs(newFilePath);

                                activeBlog.Image = fileName;
                                activeBlog.Header = blog.Header;
                                activeBlog.Paragraph_1 = blog.Paragraph_1;
                                activeBlog.StrongText = blog.StrongText;
                                activeBlog.Author = blog.Author;
                                activeBlog.Date = blog.Date;
                                db.SaveChanges();
                                return RedirectToAction("Index");
                            }
                            else
                            {
                                ViewBag.EditError = "Photo type is not valid.";
                                return View(activeBlog);
                            }
                        }
                        else
                        {
                            ViewBag.EditError = "Photo type should not be more than 3 MB.";
                            return View(activeBlog);
                        }
                    }
                    else
                    {
                        activeBlog.Header = blog.Header;
                        activeBlog.Paragraph_1 = blog.Paragraph_1;
                        activeBlog.StrongText = blog.StrongText;
                        activeBlog.Author = blog.Author;
                        activeBlog.Date = blog.Date;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ViewBag.EditError = "Id is not correct.";
                    return View(activeBlog);
                }
            }
            return View(blog);
        }

        // GET: Admin/Blog/Delete/5
        public ActionResult Delete(int? id)
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
            return View(blog);
        }

        // POST: Admin/Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blog.Find(id);
            blog.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Admin/Blog/Show/6
        public ActionResult Show(int? id)
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
            return View(blog);
        }

        // POST: Admin/Blog/Show/6
        [HttpPost, ActionName("Show")]
        [ValidateAntiForgeryToken]
        public ActionResult ShowConfirmed(int id)
        {
            Blog blog = db.Blog.Find(id);
            blog.Status = true;
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
