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
    public class ProductController : Controller
    {
        private Final_ProjectEntities db = new Final_ProjectEntities();

        // GET: Admin/Product
        public ActionResult Index()
        {
            var product = db.Product.Include(p => p.Brand).Include(p => p.Category).Include(p => p.Color).Include(p => p.Size);
            return View(product.OrderByDescending(s => s.Date).ToList());
        }

        public ActionResult Index2()
        {
            var product = db.Product.Include(p => p.Brand).Include(p => p.Category).Include(p => p.Color).Include(p => p.Size);
            return View(product.OrderByDescending(s => s.Date).ToList());
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            ViewBag.Brand_Id = new SelectList(db.Brand, "Id", "Name");
            ViewBag.Category_Id = new SelectList(db.Category, "Id", "Name");
            ViewBag.Color_Id = new SelectList(db.Color, "Id", "Name");
            ViewBag.Size_Id = new SelectList(db.Size, "Id", "Name");
            return View();
        }

        // POST: Admin/Product/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Name,Price,Category_Id,Image,Rating,Review_Count,Discount,New,Count,Brand_Id,Color_Id,Size_Id,Featured,Special,Onsale,Top_Selling_Week,Details_1,Details_2,Details_3,Details_4,Details_5")] Product product, HttpPostedFileBase Image)
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
                            product.Image = fileName;
                            product.Status = true;
                            product.Date = DateTime.Now;
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
                    product.Image = "default.jpg";
                    product.Status = true;
                    product.Date = DateTime.Now;
                }
                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Brand_Id = new SelectList(db.Brand, "Id", "Name", product.Brand_Id);
            ViewBag.Category_Id = new SelectList(db.Category, "Id", "Name", product.Category_Id);
            ViewBag.Color_Id = new SelectList(db.Color, "Id", "Name", product.Color_Id);
            ViewBag.Size_Id = new SelectList(db.Size, "Id", "Name", product.Size_Id);
            return View(product);
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.Brand_Id = new SelectList(db.Brand, "Id", "Name", product.Brand_Id);
            ViewBag.Category_Id = new SelectList(db.Category, "Id", "Name", product.Category_Id);
            ViewBag.Color_Id = new SelectList(db.Color, "Id", "Name", product.Color_Id);
            ViewBag.Size_Id = new SelectList(db.Size, "Id", "Name", product.Size_Id);
            return View(product);
        }

        // POST: Admin/Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, [Bind(Include = "Id,Name,Price,Category_Id,Image,Rating,Review_Count,Discount,New,Count,Brand_Id,Color_Id,Size_Id,Featured,Special,Onsale,Top_Selling_Week,Details_1,Details_2,Details_3,Details_4,Details_5")] Product product, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                Product activeProduct = db.Product.Find(id);
                if (activeProduct != null)
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

                                activeProduct.Image = fileName;
                                activeProduct.Name = product.Name;
                                activeProduct.Price = product.Price;
                                activeProduct.Category_Id = product.Category_Id;
                                activeProduct.Rating = product.Rating;
                                activeProduct.Discount = product.Discount;
                                activeProduct.New = product.New;
                                activeProduct.Count = product.Count;
                                activeProduct.Brand_Id = product.Brand_Id;
                                activeProduct.Color_Id = product.Color_Id;
                                activeProduct.Size_Id = product.Size_Id;
                                activeProduct.Featured = product.Featured;
                                activeProduct.Special = product.Special;
                                activeProduct.Onsale = product.Onsale;
                                activeProduct.Top_Selling_Week = product.Top_Selling_Week;
                                activeProduct.Details_1 = product.Details_1;
                                activeProduct.Details_2 = product.Details_2;
                                activeProduct.Details_3 = product.Details_3;
                                activeProduct.Details_4 = product.Details_4;
                                activeProduct.Details_5 = product.Details_5;

                                db.SaveChanges();
                                return RedirectToAction("Index");
                            }
                            else
                            {
                                ViewBag.EditError = "Photo type is not valid.";
                                return View(activeProduct);
                            }
                        }
                        else
                        {
                            ViewBag.EditError = "Photo type should not be more than 3 MB.";
                            return View(activeProduct);
                        }
                    }
                    else
                    {
                        activeProduct.Name = product.Name;
                        activeProduct.Price = product.Price;
                        activeProduct.Category_Id = product.Category_Id;
                        activeProduct.Rating = product.Rating;
                        activeProduct.Discount = product.Discount;
                        activeProduct.New = product.New;
                        activeProduct.Count = product.Count;
                        activeProduct.Brand_Id = product.Brand_Id;
                        activeProduct.Color_Id = product.Color_Id;
                        activeProduct.Size_Id = product.Size_Id;
                        activeProduct.Featured = product.Featured;
                        activeProduct.Special = product.Special;
                        activeProduct.Onsale = product.Onsale;
                        activeProduct.Top_Selling_Week = product.Top_Selling_Week;
                        activeProduct.Details_1 = product.Details_1;
                        activeProduct.Details_2 = product.Details_2;
                        activeProduct.Details_3 = product.Details_3;
                        activeProduct.Details_4 = product.Details_4;
                        activeProduct.Details_5 = product.Details_5;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ViewBag.EditError = "Id is not correct.";
                    return View(activeProduct);
                }
            }
            ViewBag.Brand_Id = new SelectList(db.Brand, "Id", "Name", product.Brand_Id);
            ViewBag.Category_Id = new SelectList(db.Category, "Id", "Name", product.Category_Id);
            ViewBag.Color_Id = new SelectList(db.Color, "Id", "Name", product.Color_Id);
            ViewBag.Size_Id = new SelectList(db.Size, "Id", "Name", product.Size_Id);
            return View(product);
        }

        // GET: Admin/Product/Hide/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Product/Hide/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Product.Find(id);
            product.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Admin/Product/Show/5
        public ActionResult Show(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Product/Hide/5
        [HttpPost, ActionName("Show")]
        [ValidateAntiForgeryToken]
        public ActionResult ShowConfirmed(int id)
        {
            Product product = db.Product.Find(id);
            product.Status = true;
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
