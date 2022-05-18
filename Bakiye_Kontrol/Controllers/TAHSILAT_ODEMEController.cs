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
    public class TAHSILAT_ODEMEController : Controller
    {
        private BakiyeEntities db = new BakiyeEntities();

        // GET: TAHSILAT_ODEME
        public ActionResult Index()
        {
            var tAHSILAT_ODEME = db.TAHSILAT_ODEME.Include(t => t.Banka).Include(t => t.Kasa);
            return View(tAHSILAT_ODEME.ToList());
        }

        // GET: TAHSILAT_ODEME/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAHSILAT_ODEME tAHSILAT_ODEME = db.TAHSILAT_ODEME.Find(id);
            if (tAHSILAT_ODEME == null)
            {
                return HttpNotFound();
            }
            return View(tAHSILAT_ODEME);
        }

        // GET: TAHSILAT_ODEME/Create
        public ActionResult Create()
        {
            ViewBag.BankaID = new SelectList(db.Banka, "ID", "BankaAdi");
            ViewBag.KasaID = new SelectList(db.Kasa, "ID", "KasaAdi");
            return View();
        }

        // POST: TAHSILAT_ODEME/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IslemTipi,IslemNo,IslemTarih,KasaID,BankaID,Aciklama,ParaBirimi,Tutar")] TAHSILAT_ODEME tAHSILAT_ODEME)
        {
            if (ModelState.IsValid)
            {
                db.TAHSILAT_ODEME.Add(tAHSILAT_ODEME);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BankaID = new SelectList(db.Banka, "ID", "BankaAdi", tAHSILAT_ODEME.BankaID);
            ViewBag.KasaID = new SelectList(db.Kasa, "ID", "KasaAdi", tAHSILAT_ODEME.KasaID);
            return View(tAHSILAT_ODEME);
        }

        // GET: TAHSILAT_ODEME/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAHSILAT_ODEME tAHSILAT_ODEME = db.TAHSILAT_ODEME.Find(id);
            if (tAHSILAT_ODEME == null)
            {
                return HttpNotFound();
            }
            ViewBag.BankaID = new SelectList(db.Banka, "ID", "BankaAdi", tAHSILAT_ODEME.BankaID);
            ViewBag.KasaID = new SelectList(db.Kasa, "ID", "KasaAdi", tAHSILAT_ODEME.KasaID);
            return View(tAHSILAT_ODEME);
        }

        // POST: TAHSILAT_ODEME/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IslemTipi,IslemNo,IslemTarih,KasaID,BankaID,Aciklama,ParaBirimi,Tutar")] TAHSILAT_ODEME tAHSILAT_ODEME)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tAHSILAT_ODEME).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BankaID = new SelectList(db.Banka, "ID", "BankaAdi", tAHSILAT_ODEME.BankaID);
            ViewBag.KasaID = new SelectList(db.Kasa, "ID", "KasaAdi", tAHSILAT_ODEME.KasaID);
            return View(tAHSILAT_ODEME);
        }

        // GET: TAHSILAT_ODEME/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAHSILAT_ODEME tAHSILAT_ODEME = db.TAHSILAT_ODEME.Find(id);
            if (tAHSILAT_ODEME == null)
            {
                return HttpNotFound();
            }
            return View(tAHSILAT_ODEME);
        }

        // POST: TAHSILAT_ODEME/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TAHSILAT_ODEME tAHSILAT_ODEME = db.TAHSILAT_ODEME.Find(id);
            db.TAHSILAT_ODEME.Remove(tAHSILAT_ODEME);
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
