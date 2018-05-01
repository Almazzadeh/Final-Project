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
    public class AnimationController : Controller
    {
        private Final_ProjectEntities db = new Final_ProjectEntities();

        // GET: Admin/Animation
        public ActionResult Index()
        {
            return View(db.Animation.ToList());
        }

        // GET: Admin/Animation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animation animation = db.Animation.Find(id);
            if (animation == null)
            {
                return HttpNotFound();
            }
            return View(animation);
        }

        // GET: Admin/Animation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animation animation = db.Animation.Find(id);
            if (animation == null)
            {
                return HttpNotFound();
            }
            return View(animation);
        }

        // POST: Admin/Animation/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, [Bind(Include = "Id,Image,Top_Text,Middle_Text,Bottom_Text,Price")] Animation animation, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                Animation activeAnimation = db.Animation.Find(id);
                if (activeAnimation != null)
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
                                //var path = Path.Combine(Server.MapPath("~/Public/images/"), activeAnimation.Image);

                                //if (System.IO.File.Exists(path))
                                //{
                                //    System.IO.File.Delete(path);
                                //}

                                DateTime dt = DateTime.Now;
                                var beforeStr = dt.Year + "_" + dt.Month + "_" + dt.Day + "_" + dt.Hour + "_" + dt.Minute + "_" + dt.Second;
                                fileName = beforeStr + Path.GetFileName(Image.FileName);
                                var newFilePath = Path.Combine(Server.MapPath("~/Public/images/"), fileName);

                                Image.SaveAs(newFilePath);

                                activeAnimation.Image = fileName;
                                activeAnimation.Top_Text = animation.Top_Text;
                                activeAnimation.Middle_Text = animation.Middle_Text;
                                activeAnimation.Bottom_Text = animation.Bottom_Text;
                                activeAnimation.Price = animation.Price;
                                db.SaveChanges();
                                return RedirectToAction("Index");
                            }
                            else
                            {
                                ViewBag.EditError = "Photo type is not valid.";
                                return View(activeAnimation);
                            }
                        }
                        else
                        {
                            ViewBag.EditError = "Photo type should not be more than 3 MB.";
                            return View(activeAnimation);
                        }
                    }
                    else
                    {
                        activeAnimation.Top_Text = animation.Top_Text;
                        activeAnimation.Middle_Text = animation.Middle_Text;
                        activeAnimation.Bottom_Text = animation.Bottom_Text;
                        activeAnimation.Price = animation.Price;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ViewBag.EditError = "Id is not correct.";
                    return View(activeAnimation);
                }
            }
            return View(animation);
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
