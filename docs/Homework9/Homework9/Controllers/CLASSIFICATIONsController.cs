﻿using System;
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
            CLASSIFICATION cLASSIFICATION = db.CLASSIFICATIONs.Find(id);
            if (cLASSIFICATION == null)
            {
                return HttpNotFound();
            }
            return View(cLASSIFICATION);
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
        public ActionResult Create([Bind(Include = "ID,ARTWORK,GENRE")] CLASSIFICATION cLASSIFICATION)
        {
            if (ModelState.IsValid)
            {
                db.CLASSIFICATIONs.Add(cLASSIFICATION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ARTWORK = new SelectList(db.ARTWORKs, "ID", "TITLE", cLASSIFICATION.ARTWORK);
            ViewBag.GENRE = new SelectList(db.GENREs, "ID", "NAME", cLASSIFICATION.GENRE);
            return View(cLASSIFICATION);
        }

        // GET: CLASSIFICATIONs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASSIFICATION cLASSIFICATION = db.CLASSIFICATIONs.Find(id);
            if (cLASSIFICATION == null)
            {
                return HttpNotFound();
            }
            ViewBag.ARTWORK = new SelectList(db.ARTWORKs, "ID", "TITLE", cLASSIFICATION.ARTWORK);
            ViewBag.GENRE = new SelectList(db.GENREs, "ID", "NAME", cLASSIFICATION.GENRE);
            return View(cLASSIFICATION);
        }

        // POST: CLASSIFICATIONs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ARTWORK,GENRE")] CLASSIFICATION cLASSIFICATION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLASSIFICATION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ARTWORK = new SelectList(db.ARTWORKs, "ID", "TITLE", cLASSIFICATION.ARTWORK);
            ViewBag.GENRE = new SelectList(db.GENREs, "ID", "NAME", cLASSIFICATION.GENRE);
            return View(cLASSIFICATION);
        }

        // GET: CLASSIFICATIONs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASSIFICATION cLASSIFICATION = db.CLASSIFICATIONs.Find(id);
            if (cLASSIFICATION == null)
            {
                return HttpNotFound();
            }
            return View(cLASSIFICATION);
        }

        // POST: CLASSIFICATIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLASSIFICATION cLASSIFICATION = db.CLASSIFICATIONs.Find(id);
            db.CLASSIFICATIONs.Remove(cLASSIFICATION);
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