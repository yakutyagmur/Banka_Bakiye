using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bakiye_Kontrol.Models.Entity;

namespace Bakiye_Kontrol.Controllers
{
    public class Bakiye_KasaController : Controller
    {
        private BakiyeEntities db = new BakiyeEntities();

        // GET: Bakiye_Kasa
        public ActionResult Index()
        {
            var bakiye_Kasa = db.Bakiye_Kasa.Include(b => b.Kasa);
            return View(bakiye_Kasa.ToList());
        }

        // GET: Bakiye_Kasa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bakiye_Kasa bakiye_Kasa = db.Bakiye_Kasa.Find(id);
            if (bakiye_Kasa == null)
            {
                return HttpNotFound();
            }
            return View(bakiye_Kasa);
        }

        // GET: Bakiye_Kasa/Create
        public ActionResult Create()
        {
            ViewBag.KasaID = new SelectList(db.Kasa, "ID", "KasaAdi");
            return View();
        }

        // POST: Bakiye_Kasa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,KasaID,ParaBirimi,Bakiye")] Bakiye_Kasa bakiye_Kasa)
        {
            if (ModelState.IsValid)
            {
                db.Bakiye_Kasa.Add(bakiye_Kasa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KasaID = new SelectList(db.Kasa, "ID", "KasaAdi", bakiye_Kasa.KasaID);
            return View(bakiye_Kasa);
        }

        // GET: Bakiye_Kasa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bakiye_Kasa bakiye_Kasa = db.Bakiye_Kasa.Find(id);
            if (bakiye_Kasa == null)
            {
                return HttpNotFound();
            }
            ViewBag.KasaID = new SelectList(db.Kasa, "ID", "KasaAdi", bakiye_Kasa.KasaID);
            return View(bakiye_Kasa);
        }

        // POST: Bakiye_Kasa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,KasaID,ParaBirimi,Bakiye")] Bakiye_Kasa bakiye_Kasa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bakiye_Kasa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KasaID = new SelectList(db.Kasa, "ID", "KasaAdi", bakiye_Kasa.KasaID);
            return View(bakiye_Kasa);
        }

        // GET: Bakiye_Kasa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bakiye_Kasa bakiye_Kasa = db.Bakiye_Kasa.Find(id);
            if (bakiye_Kasa == null)
            {
                return HttpNotFound();
            }
            return View(bakiye_Kasa);
        }

        // POST: Bakiye_Kasa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bakiye_Kasa bakiye_Kasa = db.Bakiye_Kasa.Find(id);
            db.Bakiye_Kasa.Remove(bakiye_Kasa);
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
