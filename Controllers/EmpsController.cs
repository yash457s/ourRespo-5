using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class EmpsController : Controller
    {
        private EmpsDbContext db = new EmpsDbContext();

        // GET: Emps
        public ActionResult Index()
        {
            return View(db.Emps.ToList());
        }

        // GET: Emps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emps emps = db.Emps.Find(id);
            if (emps == null)
            {
                return HttpNotFound();
            }
            return View(emps);
        }

        // GET: Emps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Emps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EId,EName,EDesignation,EDoj")] Emps emps)
        {
            if (ModelState.IsValid)
            {
                db.Emps.Add(emps);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emps);
        }

        // GET: Emps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emps emps = db.Emps.Find(id);
            if (emps == null)
            {
                return HttpNotFound();
            }
            return View(emps);
        }

        // POST: Emps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EId,EName,EDesignation,EDoj")] Emps emps)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emps).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emps);
        }

        // GET: Emps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emps emps = db.Emps.Find(id);
            if (emps == null)
            {
                return HttpNotFound();
            }
            return View(emps);
        }

        // POST: Emps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emps emps = db.Emps.Find(id);
            db.Emps.Remove(emps);
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
