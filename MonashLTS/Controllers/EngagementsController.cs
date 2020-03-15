using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MonashLTS.Models;

namespace MonashLTS.Controllers
{
    public class EngagementsController : Controller
    {
        private LTS db = new LTS();

        // GET: Engagements
        public ActionResult Index()
        {
            var engagements = db.Engagements.Include(e => e.TeachingAssistant).Include(e => e.Unit);
            return View(engagements.ToList());
        }

        // GET: Engagements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Engagement engagement = db.Engagements.Find(id);
            if (engagement == null)
            {
                return HttpNotFound();
            }
            return View(engagement);
        }

        // GET: Engagements/Create
        public ActionResult Create()
        {
            ViewBag.teachingAssistant_id = new SelectList(db.TeachingAssistants, "id", "FirstNameTA");
            ViewBag.TAUnit_id = new SelectList(db.Units, "id", "UnitCode");
            return View();
        }

        // POST: Engagements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,TAUnit_id,teachingAssistant_id")] Engagement engagement)
        {
            if (ModelState.IsValid)
            {
                db.Engagements.Add(engagement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.teachingAssistant_id = new SelectList(db.TeachingAssistants, "id", "FirstNameTA", engagement.teachingAssistant_id);
            ViewBag.TAUnit_id = new SelectList(db.Units, "id", "UnitCode", engagement.TAUnit_id);
            return View(engagement);
        }

        // GET: Engagements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Engagement engagement = db.Engagements.Find(id);
            if (engagement == null)
            {
                return HttpNotFound();
            }
            ViewBag.teachingAssistant_id = new SelectList(db.TeachingAssistants, "id", "FirstNameTA", engagement.teachingAssistant_id);
            ViewBag.TAUnit_id = new SelectList(db.Units, "id", "UnitCode", engagement.TAUnit_id);
            return View(engagement);
        }

        // POST: Engagements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,TAUnit_id,teachingAssistant_id")] Engagement engagement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(engagement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.teachingAssistant_id = new SelectList(db.TeachingAssistants, "id", "FirstNameTA", engagement.teachingAssistant_id);
            ViewBag.TAUnit_id = new SelectList(db.Units, "id", "UnitCode", engagement.TAUnit_id);
            return View(engagement);
        }

        // GET: Engagements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Engagement engagement = db.Engagements.Find(id);
            if (engagement == null)
            {
                return HttpNotFound();
            }
            return View(engagement);
        }

        // POST: Engagements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Engagement engagement = db.Engagements.Find(id);
            db.Engagements.Remove(engagement);
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
