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
    public class AnimationSideTopController : Controller
    {
        private Final_ProjectEntities db = new Final_ProjectEntities();

        // GET: Admin/AnimationSideTop/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimationSideTop animationSideTop = db.AnimationSideTop.Find(id);
            if (animationSideTop == null)
            {
                return HttpNotFound();
            }
            return View(animationSideTop);
        }

       
        // GET: Admin/AnimationSideTop/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimationSideTop animationSideTop = db.AnimationSideTop.Find(id);
            if (animationSideTop == null)
            {
                return HttpNotFound();
            }
            return View(animationSideTop);
        }

        // POST: Admin/AnimationSideTop/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, [Bind(Include = "Id,Image,TopText,MiddleText,Price")] AnimationSideTop animationSideTop, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                AnimationSideTop activeTop = db.AnimationSideTop.Find(id);
                if (activeTop != null)
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
                                //var path = Path.Combine(Server.MapPath("~/Public/images/"), activeTop.Image);

                                //if (System.IO.File.Exists(path))
                                //{
                                //    System.IO.File.Delete(path);
                                //}

                                DateTime dt = DateTime.Now;
                                var beforeStr = dt.Year + "_" + dt.Month + "_" + dt.Day + "_" + dt.Hour + "_" + dt.Minute + "_" + dt.Second;
                                fileName = beforeStr + Path.GetFileName(Image.FileName);
                                var newFilePath = Path.Combine(Server.MapPath("~/Public/images/"), fileName);

                                Image.SaveAs(newFilePath);

                                activeTop.Image = fileName;
                                activeTop.TopText = animationSideTop.TopText;
                                activeTop.MiddleText = animationSideTop.MiddleText;
                                activeTop.Price = animationSideTop.Price;
                                db.SaveChanges();
                                return RedirectToAction("Details/1");
                            }
                            else
                            {
                                ViewBag.EditError = "Photo type is not valid.";
                                return View(activeTop);
                            }
                        }
                        else
                        {
                            ViewBag.EditError = "Photo type should not be more than 3 MB.";
                            return View(activeTop);
                        }
                    }
                    else
                    {
                        activeTop.TopText = animationSideTop.TopText;
                        activeTop.MiddleText = animationSideTop.MiddleText;
                        activeTop.Price = animationSideTop.Price;
                        db.SaveChanges();
                        return RedirectToAction("Details/1");
                    }
                }
                else
                {
                    ViewBag.EditError = "Id is not correct.";
                    return View(activeTop);
                }
            }
            return View(animationSideTop);
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
