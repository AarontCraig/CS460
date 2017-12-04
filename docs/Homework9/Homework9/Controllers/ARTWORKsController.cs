using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Homework9.Models;

namespace Homework9.Controllers
{
    public class ARTWORKsController : Controller
    {
        private UserContext db = new UserContext();

        // GET: ARTWORKs
        public ActionResult Index()
        {
            var aRTWORKs = db.ARTWORKs.Include(a => a.ARTIST1);
            return View(aRTWORKs.ToList());
        }

        // GET: ARTWORKs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTWORK aRTWORK = db.ARTWORKs.Find(id);
            if (aRTWORK == null)
            {
                return HttpNotFound();
            }
            return View(aRTWORK);
        }

        // GET: ARTWORKs/Create
        public ActionResult Create()
        {
            ViewBag.ARTIST = new SelectList(db.ARTISTs, "ID", "NAME");
            return View();
        }

        // POST: ARTWORKs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TITLE,ARTIST")] ARTWORK aRTWORK)
        {
            if (ModelState.IsValid)
            {
                db.ARTWORKs.Add(aRTWORK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ARTIST = new SelectList(db.ARTISTs, "ID", "NAME", aRTWORK.ARTIST);
            return View(aRTWORK);
        }

        // GET: ARTWORKs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTWORK aRTWORK = db.ARTWORKs.Find(id);
            if (aRTWORK == null)
            {
                return HttpNotFound();
            }
            ViewBag.ARTIST = new SelectList(db.ARTISTs, "ID", "NAME", aRTWORK.ARTIST);
            return View(aRTWORK);
        }

        // POST: ARTWORKs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TITLE,ARTIST")] ARTWORK aRTWORK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aRTWORK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ARTIST = new SelectList(db.ARTISTs, "ID", "NAME", aRTWORK.ARTIST);
            return View(aRTWORK);
        }

        // GET: ARTWORKs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTWORK aRTWORK = db.ARTWORKs.Find(id);
            if (aRTWORK == null)
            {
                return HttpNotFound();
            }
            return View(aRTWORK);
        }

        // POST: ARTWORKs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ARTWORK aRTWORK = db.ARTWORKs.Find(id);
            db.ARTWORKs.Remove(aRTWORK);
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
