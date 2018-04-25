using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Final_Project_V2.Models;

namespace Final_Project_V2.Areas.Admin.Controllers
{
    public class OurTeamController : Controller
    {
        private Final_ProjectEntities db = new Final_ProjectEntities();

        // GET: Admin/OurTeam
        public ActionResult Index()
        {
            return View(db.OurTeam.ToList());
        }

        // GET: Admin/OurTeam/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OurTeam ourTeam = db.OurTeam.Find(id);
            if (ourTeam == null)
            {
                return HttpNotFound();
            }
            return View(ourTeam);
        }

        // GET: Admin/OurTeam/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/OurTeam/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Image,Name,position,Status")] OurTeam ourTeam, HttpPostedFileBase Image)
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
                            ourTeam.Image = fileName;
                            ourTeam.Status = true;
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
                    ourTeam.Image = "default.jpg";
                    ourTeam.Status = true;
                }
                db.OurTeam.Add(ourTeam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ourTeam);
        }

        // GET: Admin/OurTeam/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OurTeam ourTeam = db.OurTeam.Find(id);
            if (ourTeam == null)
            {
                return HttpNotFound();
            }
            return View(ourTeam);
        }

        // POST: Admin/OurTeam/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, [Bind(Include = "Id,Image,Name,position,Status")] OurTeam ourTeam, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                OurTeam activeMember = db.OurTeam.Find(id);
                if (activeMember != null)
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

                                activeMember.Image = fileName;
                                activeMember.Name = ourTeam.Name;
                                activeMember.position = ourTeam.position;
                                db.SaveChanges();
                                return RedirectToAction("Index");
                            }
                            else
                            {
                                ViewBag.EditError = "Photo type is not valid.";
                                return View(activeMember);
                            }
                        }
                        else
                        {
                            ViewBag.EditError = "Photo type should not be more than 3 MB.";
                            return View(activeMember);
                        }
                    }
                    else
                    {
                        activeMember.Name = ourTeam.Name;
                        activeMember.position = ourTeam.position;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ViewBag.EditError = "Id is not correct.";
                    return View(activeMember);
                }
            }
            return View(ourTeam);
        }

        // GET: Admin/OurTeam/Hide/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OurTeam ourTeam = db.OurTeam.Find(id);
            if (ourTeam == null)
            {
                return HttpNotFound();
            }
            return View(ourTeam);
        }

        // POST: Admin/OurTeam/Hide/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OurTeam ourTeam = db.OurTeam.Find(id);
            ourTeam.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Admin/OurTeam/Show/5
        public ActionResult Show(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OurTeam ourTeam = db.OurTeam.Find(id);
            if (ourTeam == null)
            {
                return HttpNotFound();
            }
            return View(ourTeam);
        }

        // POST: Admin/OurTeam/Show/5
        [HttpPost, ActionName("Show")]
        [ValidateAntiForgeryToken]
        public ActionResult ShowConfirmed(int id)
        {
            OurTeam ourTeam = db.OurTeam.Find(id);
            ourTeam.Status = true;
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
