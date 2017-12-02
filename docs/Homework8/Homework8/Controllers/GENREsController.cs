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
    public class GENREsController : Controller
    {
        private UserContext db = new UserContext();

        // GET: GENREs
        public ActionResult Index()
        {
            return View(db.GENREs.ToList());
        }

        // GET: GENREs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GENREs gENREs = db.GENREs.Find(id);
            if (gENREs == null)
            {
                return HttpNotFound();
            }
            return View(gENREs);
        }

        // GET: GENREs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GENREs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NAME")] GENREs gENREs)
        {
            if (ModelState.IsValid)
            {
                db.GENREs.Add(gENREs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gENREs);
        }

        // GET: GENREs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GENREs gENREs = db.GENREs.Find(id);
            if (gENREs == null)
            {
                return HttpNotFound();
            }
            return View(gENREs);
        }

        // POST: GENREs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NAME")] GENREs gENREs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gENREs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gENREs);
        }

        // GET: GENREs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GENREs gENREs = db.GENREs.Find(id);
            if (gENREs == null)
            {
                return HttpNotFound();
            }
            return View(gENREs);
        }

        // POST: GENREs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GENREs gENREs = db.GENREs.Find(id);
            db.GENREs.Remove(gENREs);
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
