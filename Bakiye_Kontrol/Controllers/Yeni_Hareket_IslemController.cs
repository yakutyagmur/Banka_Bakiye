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
    public class Yeni_Hareket_IslemController : Controller
    {
        private BakiyeEntities db = new BakiyeEntities();

        // GET: Yeni_Hareket_Islem
        public ActionResult Index()
        {
            return View(db.Yeni_Hareket_Islem.ToList());
        }

        // GET: Yeni_Hareket_Islem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yeni_Hareket_Islem yeni_Hareket_Islem = db.Yeni_Hareket_Islem.Find(id);
            if (yeni_Hareket_Islem == null)
            {
                return HttpNotFound();
            }
            return View(yeni_Hareket_Islem);
        }

        // GET: Yeni_Hareket_Islem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Yeni_Hareket_Islem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IslemTipi,IslemNo,Aciklama,ParaBirimi,Tutar,OdemeAlan")] Yeni_Hareket_Islem yeni_Hareket_Islem)
        {
            if (ModelState.IsValid)
            {
                db.Yeni_Hareket_Islem.Add(yeni_Hareket_Islem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yeni_Hareket_Islem);
        }

        // GET: Yeni_Hareket_Islem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yeni_Hareket_Islem yeni_Hareket_Islem = db.Yeni_Hareket_Islem.Find(id);
            if (yeni_Hareket_Islem == null)
            {
                return HttpNotFound();
            }
            return View(yeni_Hareket_Islem);
        }

        // POST: Yeni_Hareket_Islem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IslemTipi,IslemNo,Aciklama,ParaBirimi,Tutar,OdemeAlan")] Yeni_Hareket_Islem yeni_Hareket_Islem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yeni_Hareket_Islem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yeni_Hareket_Islem);
        }

        // GET: Yeni_Hareket_Islem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yeni_Hareket_Islem yeni_Hareket_Islem = db.Yeni_Hareket_Islem.Find(id);
            if (yeni_Hareket_Islem == null)
            {
                return HttpNotFound();
            }
            return View(yeni_Hareket_Islem);
        }

        // POST: Yeni_Hareket_Islem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yeni_Hareket_Islem yeni_Hareket_Islem = db.Yeni_Hareket_Islem.Find(id);
            db.Yeni_Hareket_Islem.Remove(yeni_Hareket_Islem);
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
