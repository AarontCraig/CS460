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
    public class ARTISTsController : Controller
    {
        private UserContext db = new UserContext();

        // GET: ARTISTs
        public ActionResult Index()
        {
            return View(db.ARTISTs.ToList());
        }

        // GET: ARTISTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTISTs aRTISTs = db.ARTISTs.Find(id);
            if (aRTISTs == null)
            {
                return HttpNotFound();
            }
            return View(aRTISTs);
        }

        // GET: ARTISTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ARTISTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NAME,DOB,BIRTHCITY")] ARTISTs aRTISTs)
        {
            //Don't allow time beyond or long names
            if (aRTISTs.NAME.Length > 50 ||aRTISTs.DOB > DateTime.Now)
                return View(aRTISTs);

            if (ModelState.IsValid)
            {
                db.ARTISTs.Add(aRTISTs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aRTISTs);
        }

        // GET: ARTISTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTISTs aRTISTs = db.ARTISTs.Find(id);
            if (aRTISTs == null)
            {
                return HttpNotFound();
            }
            return View(aRTISTs);
        }

        // POST: ARTISTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NAME,DOB,BIRTHCITY")] ARTISTs aRTISTs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aRTISTs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aRTISTs);
        }

        // GET: ARTISTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTISTs aRTISTs = db.ARTISTs.Find(id);
            if (aRTISTs == null)
            {
                return HttpNotFound();
            }
            return View(aRTISTs);
        }

        // POST: ARTISTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ARTISTs aRTISTs = db.ARTISTs.Find(id);
            db.ARTISTs.Remove(aRTISTs);
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
