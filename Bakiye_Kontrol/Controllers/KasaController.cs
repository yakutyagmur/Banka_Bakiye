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
    public class KasaController : Controller
    {
        private BakiyeEntities db = new BakiyeEntities();

        // GET: Kasa
        public ActionResult Index()
        {
            return View(db.Kasa.ToList());
        }

        // GET: Kasa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kasa kasa = db.Kasa.Find(id);
            if (kasa == null)
            {
                return HttpNotFound();
            }
            return View(kasa);
        }

        // GET: Kasa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kasa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,KasaKodu,KasaAdi")] Kasa kasa)
        {
            if (ModelState.IsValid)
            {
                db.Kasa.Add(kasa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kasa);
        }

        // GET: Kasa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kasa kasa = db.Kasa.Find(id);
            if (kasa == null)
            {
                return HttpNotFound();
            }
            return View(kasa);
        }

        // POST: Kasa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,KasaKodu,KasaAdi")] Kasa kasa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kasa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kasa);
        }

        // GET: Kasa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kasa kasa = db.Kasa.Find(id);
            if (kasa == null)
            {
                return HttpNotFound();
            }
            return View(kasa);
        }

        // POST: Kasa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kasa kasa = db.Kasa.Find(id);
            db.Kasa.Remove(kasa);
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
