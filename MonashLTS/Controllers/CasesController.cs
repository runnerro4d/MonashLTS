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
    public class CasesController : Controller
    {
        private LTS db = new LTS();

        // GET: Cases
        public ActionResult Index()
        {
            var cases = db.Cases.Include(a => a.CaseManager).Include(b => b.Student).Include(c => c.TeachingAssistant).Include(d => d.Unit);
            return View(cases.ToList());
        }

        // GET: Cases/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = db.Cases.Find(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            return View(@case);
        }

        // GET: Cases/Create
        public ActionResult Create()
        {
            ViewBag.CaseManager_id = new SelectList(db.CaseManagers, "id", "FullNameCM");
            ViewBag.Student_id = new SelectList(db.Students, "id", "Alias");
            ViewBag.TeachingAssistant_id = new SelectList(db.TeachingAssistants, "id", "FullNameTA");
            ViewBag.Unit_id = new SelectList(db.Units, "id", "UnitCode");
            return View();
        }

        // POST: Cases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,CaseManager_id,Student_id,TeachingAssistant_id,Unit_id")] Case @case)
        {
            if (ModelState.IsValid)
            {
                db.Cases.Add(@case);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CaseManager_id = new SelectList(db.CaseManagers, "id", "FullNameCM", @case.CaseManager_id);
            ViewBag.Student_id = new SelectList(db.Students, "id", "Alias", @case.Student_id);
            ViewBag.TeachingAssistant_id = new SelectList(db.TeachingAssistants, "id", "FullNameTA", @case.TeachingAssistant_id);
            ViewBag.Unit_id = new SelectList(db.Units, "id", "UnitCode", @case.Unit_id);
            return View(@case);
        }

        // GET: Cases/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = db.Cases.Find(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            ViewBag.CaseManager_id = new SelectList(db.CaseManagers, "id", "FullNameCM", @case.CaseManager_id);
            ViewBag.Student_id = new SelectList(db.Students, "id", "Alias", @case.Student_id);
            ViewBag.TeachingAssistant_id = new SelectList(db.TeachingAssistants, "id", "FullNameTA", @case.TeachingAssistant_id);
            ViewBag.Unit_id = new SelectList(db.Units, "id", "UnitCode", @case.Unit_id);
            return View(@case);
        }

        // POST: Cases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,CaseManager_id,Student_id,TeachingAssistant_id,Unit_id")] Case @case)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@case).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CaseManager_id = new SelectList(db.CaseManagers, "id", "FullNameCM", @case.CaseManager_id);
            ViewBag.Student_id = new SelectList(db.Students, "id", "Alias", @case.Student_id);
            ViewBag.TeachingAssistant_id = new SelectList(db.TeachingAssistants, "id", "FullNameTA", @case.TeachingAssistant_id);
            ViewBag.Unit_id = new SelectList(db.Units, "id", "UnitCode", @case.Unit_id);
            return View(@case);
        }

        // GET: Cases/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = db.Cases.Find(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            return View(@case);
        }

        // POST: Cases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Case @case = db.Cases.Find(id);
            db.Cases.Remove(@case);
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
