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
    public class AnimationSideBottomController : Controller
    {
        private Final_ProjectEntities db = new Final_ProjectEntities();

        // GET: Admin/AnimationSideBottom/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimationSideBottom animationSideBottom = db.AnimationSideBottom.Find(id);
            if (animationSideBottom == null)
            {
                return HttpNotFound();
            }
            return View(animationSideBottom);
        }

        // GET: Admin/AnimationSideBottom/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimationSideBottom animationSideBottom = db.AnimationSideBottom.Find(id);
            if (animationSideBottom == null)
            {
                return HttpNotFound();
            }
            return View(animationSideBottom);
        }

        // POST: Admin/AnimationSideBottom/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, [Bind(Include = "Id,Image,TopText_1,TopText_2,MiddleText,Button")] AnimationSideBottom animationSideBottom, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                AnimationSideBottom activeBottom = db.AnimationSideBottom.Find(id);
                if (activeBottom != null)
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
                                //var path = Path.Combine(Server.MapPath("~/Public/images/"), activeBottom.Image);

                                //if (System.IO.File.Exists(path))
                                //{
                                //    System.IO.File.Delete(path);
                                //}

                                DateTime dt = DateTime.Now;
                                var beforeStr = dt.Year + "_" + dt.Month + "_" + dt.Day + "_" + dt.Hour + "_" + dt.Minute + "_" + dt.Second;
                                fileName = beforeStr + Path.GetFileName(Image.FileName);
                                var newFilePath = Path.Combine(Server.MapPath("~/Public/images/"), fileName);

                                Image.SaveAs(newFilePath);

                                activeBottom.Image = fileName;
                                activeBottom.TopText_1 = animationSideBottom.TopText_1;
                                activeBottom.TopText_2 = animationSideBottom.TopText_2;
                                activeBottom.MiddleText = animationSideBottom.MiddleText;
                                activeBottom.Button = animationSideBottom.Button;
                                db.SaveChanges();
                                return RedirectToAction("Details/2");
                            }
                            else
                            {
                                ViewBag.EditError = "Photo type is not valid.";
                                return View(activeBottom);
                            }
                        }
                        else
                        {
                            ViewBag.EditError = "Photo type should not be more than 3 MB.";
                            return View(activeBottom);
                        }
                    }
                    else
                    {
                        activeBottom.TopText_1 = animationSideBottom.TopText_1;
                        activeBottom.TopText_2 = animationSideBottom.TopText_2;
                        activeBottom.MiddleText = animationSideBottom.MiddleText;
                        activeBottom.Button = animationSideBottom.Button;
                        db.SaveChanges();
                        return RedirectToAction("Details/2");
                    }
                }
                else
                {
                    ViewBag.EditError = "Id is not correct.";
                    return View(activeBottom);
                }
            }
            return View(animationSideBottom);
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
