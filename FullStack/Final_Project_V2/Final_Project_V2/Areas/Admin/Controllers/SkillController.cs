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
    public class SkillController : Controller
    {
        private Final_ProjectEntities db = new Final_ProjectEntities();

        // GET: Admin/Skill
        public ActionResult Index()
        {
            return View(db.Skill.ToList());
        }


        // GET: Admin/Skill/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Skill/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Value,Div_Id_Name")] Skill skill, string Div_Id_Name)
        {
            if (ModelState.IsValid)
            {
                bool HasSpace = Div_Id_Name.Contains(" ");
                if (!HasSpace)
                {
                    skill.Status = true;
                    db.Skill.Add(skill);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.EditError = "Short Name has space";
                    return View(skill);
                }
            }
            return View(skill);
        }

        // GET: Admin/Skill/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skill skill = db.Skill.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        // POST: Admin/Skill/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, [Bind(Include = "Id,Name,Value,Div_Id_Name")] Skill skill, string Div_Id_Name)
        {
            if (ModelState.IsValid)
            {
                Skill activeSkill = db.Skill.Find(id);
                bool HasSpace = Div_Id_Name.Contains(" ");
                if (!HasSpace)
                {
                    activeSkill.Name = skill.Name;
                    activeSkill.Value = skill.Value;
                    activeSkill.Div_Id_Name = skill.Div_Id_Name;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.EditError = "Short Name has space";
                    return View(activeSkill);
                }
            }
            return View(skill);
        }

        // GET: Admin/Skill/Hide/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skill skill = db.Skill.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        // POST: Admin/Skill/Hide/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Skill skill = db.Skill.Find(id);
            skill.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        // GET: Admin/Skill/Show/5
        public ActionResult Show(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skill skill = db.Skill.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        // POST: Admin/Skill/Show/5
        [HttpPost, ActionName("Show")]
        [ValidateAntiForgeryToken]
        public ActionResult ShowConfirmed(int id)
        {
            Skill skill = db.Skill.Find(id);
            skill.Status = true;
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
