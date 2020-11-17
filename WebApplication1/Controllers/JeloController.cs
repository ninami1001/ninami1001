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
    public class JeloController : Controller
    {
        private TestBEntities db = new TestBEntities();

        // GET: Jelo
        public ActionResult Index()
        {
            var jeloes = db.Jeloes.Include(j => j.Restoran);
            return View(jeloes.ToList());
        }

        public ActionResult Random()
        {

            var jeloDBs = db.Jeloes
                  .OrderBy(c => Guid.NewGuid())
                  .FirstOrDefault();

            return View(jeloDBs);
        }


        // GET: Jelo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jelo jelo = db.Jeloes.Find(id);
            if (jelo == null)
            {
                return HttpNotFound();
            }
            return View(jelo);
        }

        // GET: Jelo/Create
        public ActionResult Create()
        {
            ViewBag.RestoranID = new SelectList(db.Restorans, "Id", "Naziv");
            return View();
        }

        // POST: Jelo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naziv,Cijena,RestoranID")] Jelo jelo)
        {
            if (ModelState.IsValid)
            {
                db.Jeloes.Add(jelo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RestoranID = new SelectList(db.Restorans, "Id", "Naziv", jelo.RestoranID);
            return View(jelo);
        }

        // GET: Jelo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jelo jelo = db.Jeloes.Find(id);
            if (jelo == null)
            {
                return HttpNotFound();
            }
            ViewBag.RestoranID = new SelectList(db.Restorans, "Id", "Naziv", jelo.RestoranID);
            return View(jelo);
        }

        // POST: Jelo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naziv,Cijena,RestoranID")] Jelo jelo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jelo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RestoranID = new SelectList(db.Restorans, "Id", "Naziv", jelo.RestoranID);
            return View(jelo);
        }

        // GET: Jelo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jelo jelo = db.Jeloes.Find(id);
            if (jelo == null)
            {
                return HttpNotFound();
            }
            return View(jelo);
        }

        // POST: Jelo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jelo jelo = db.Jeloes.Find(id);
            db.Jeloes.Remove(jelo);
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
