using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Homework8.Models;

namespace Homework8.Controllers
{
    public class CLASSIFICATIONsController : Controller
    {
        private UserContext db = new UserContext();

        // GET: CLASSIFICATIONs
        public ActionResult Index()
        {
            var cLASSIFICATIONs = db.CLASSIFICATIONs.Include(c => c.ARTWORK1).Include(c => c.GENRE1);
            return View(cLASSIFICATIONs.ToList());
        }

        // GET: CLASSIFICATIONs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASSIFICATIONs cLASSIFICATIONs = db.CLASSIFICATIONs.Find(id);
            if (cLASSIFICATIONs == null)
            {
                return HttpNotFound();
            }
            return View(cLASSIFICATIONs);
        }

        // GET: CLASSIFICATIONs/Create
        public ActionResult Create()
        {
            ViewBag.ARTWORK = new SelectList(db.ARTWORKs, "ID", "TITLE");
            ViewBag.GENRE = new SelectList(db.GENREs, "ID", "NAME");
            return View();
        }

        // POST: CLASSIFICATIONs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ARTWORK,GENRE")] CLASSIFICATIONs cLASSIFICATIONs)
        {
            if (ModelState.IsValid)
            {
                db.CLASSIFICATIONs.Add(cLASSIFICATIONs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ARTWORK = new SelectList(db.ARTWORKs, "ID", "TITLE", cLASSIFICATIONs.ARTWORK);
            ViewBag.GENRE = new SelectList(db.GENREs, "ID", "NAME", cLASSIFICATIONs.GENRE);
            return View(cLASSIFICATIONs);
        }

        // GET: CLASSIFICATIONs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASSIFICATIONs cLASSIFICATIONs = db.CLASSIFICATIONs.Find(id);
            if (cLASSIFICATIONs == null)
            {
                return HttpNotFound();
            }
            ViewBag.ARTWORK = new SelectList(db.ARTWORKs, "ID", "TITLE", cLASSIFICATIONs.ARTWORK);
            ViewBag.GENRE = new SelectList(db.GENREs, "ID", "NAME", cLASSIFICATIONs.GENRE);
            return View(cLASSIFICATIONs);
        }

        // POST: CLASSIFICATIONs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ARTWORK,GENRE")] CLASSIFICATIONs cLASSIFICATIONs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLASSIFICATIONs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ARTWORK = new SelectList(db.ARTWORKs, "ID", "TITLE", cLASSIFICATIONs.ARTWORK);
            ViewBag.GENRE = new SelectList(db.GENREs, "ID", "NAME", cLASSIFICATIONs.GENRE);
            return View(cLASSIFICATIONs);
        }

        // GET: CLASSIFICATIONs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASSIFICATIONs cLASSIFICATIONs = db.CLASSIFICATIONs.Find(id);
            if (cLASSIFICATIONs == null)
            {
                return HttpNotFound();
            }
            return View(cLASSIFICATIONs);
        }

        // POST: CLASSIFICATIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLASSIFICATIONs cLASSIFICATIONs = db.CLASSIFICATIONs.Find(id);
            db.CLASSIFICATIONs.Remove(cLASSIFICATIONs);
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
