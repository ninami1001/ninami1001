using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RestoranController : Controller
    {
        private TestBEntities db = new TestBEntities();

        // GET: Restoran
        public ActionResult Index()
        {
            return View(db.Restorans.ToList());
        }

        // GET: Restoran/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restoran restoran = db.Restorans.Find(id);
            if (restoran == null)
            {
                return HttpNotFound();
            }
            return View(restoran);
        }

        // GET: Restoran/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restoran/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naziv,Telefon,Adresa")] Restoran restoran)
        {
            if (ModelState.IsValid)
            {
                db.Restorans.Add(restoran);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restoran);
        }

        // GET: Restoran/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restoran restoran = db.Restorans.Find(id);
            if (restoran == null)
            {
                return HttpNotFound();
            }
            return View(restoran);
        }

        // POST: Restoran/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naziv,Telefon,Adresa")] Restoran restoran)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restoran).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restoran);
        }

        // GET: Restoran/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restoran restoran = db.Restorans.Find(id);
            if (restoran == null)
            {
                return HttpNotFound();
            }
            return View(restoran);
        }

        // POST: Restoran/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restoran restoran = db.Restorans.Find(id);
            db.Restorans.Remove(restoran);
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
