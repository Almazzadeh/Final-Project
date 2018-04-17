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
    public class TopSellingController : Controller
    {
        private Final_ProjectEntities db = new Final_ProjectEntities();


        // GET: Admin/TopSelling/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopSelling topSelling = db.TopSelling.Find(id);
            if (topSelling == null)
            {
                return HttpNotFound();
            }
            return View(topSelling);
        }


        // GET: Admin/TopSelling/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopSelling topSelling = db.TopSelling.Find(id);
            if (topSelling == null)
            {
                return HttpNotFound();
            }
            return View(topSelling);
        }

        // POST: Admin/TopSelling/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, [Bind(Include = "Id,Header,Content,Span,Button,Image")] TopSelling topSelling, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                TopSelling activeTopSelling = db.TopSelling.Find(id);
                if (activeTopSelling != null)
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

                                activeTopSelling.Image = fileName;
                                activeTopSelling.Header = topSelling.Header;
                                activeTopSelling.Content = topSelling.Content;
                                activeTopSelling.Span = topSelling.Span;
                                activeTopSelling.Button = topSelling.Button;
                                db.SaveChanges();
                                return RedirectToAction("Details/1");
                            }
                            else
                            {
                                ViewBag.EditError = "Photo type is not valid.";
                                return View(activeTopSelling);
                            }
                        }
                        else
                        {
                            ViewBag.EditError = "Photo type should not be more than 3 MB.";
                            return View(activeTopSelling);
                        }
                    }
                    else
                    {
                        activeTopSelling.Header = topSelling.Header;
                        activeTopSelling.Content = topSelling.Content;
                        activeTopSelling.Span = topSelling.Span;
                        activeTopSelling.Button = topSelling.Button;
                        db.SaveChanges();
                        return RedirectToAction("Details/1");
                    }
                }
                else
                {
                    ViewBag.EditError = "Id is not correct.";
                    return View(activeTopSelling);
                }
            }
            return View(topSelling);
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
