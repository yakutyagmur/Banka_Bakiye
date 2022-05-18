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
    public class Bakiye_BankaController : Controller
    {
        private BakiyeEntities db = new BakiyeEntities();

        // GET: Bakiye_Banka
        public ActionResult Index()
        {
            var bakiye_Banka = db.Bakiye_Banka.Include(b => b.Banka);
            return View(bakiye_Banka.ToList());
        }

        // GET: Bakiye_Banka/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bakiye_Banka bakiye_Banka = db.Bakiye_Banka.Find(id);
            if (bakiye_Banka == null)
            {
                return HttpNotFound();
            }
            return View(bakiye_Banka);
        }

        // GET: Bakiye_Banka/Create
        public ActionResult Create()
        {
            ViewBag.BankaID = new SelectList(db.Banka, "ID", "BankaAdi");
            return View();
        }

        // POST: Bakiye_Banka/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BankaID,ParaBirimi,Bakiye")] Bakiye_Banka bakiye_Banka)
        {
            if (ModelState.IsValid)
            {
                db.Bakiye_Banka.Add(bakiye_Banka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BankaID = new SelectList(db.Banka, "ID", "BankaAdi", bakiye_Banka.BankaID);
            return View(bakiye_Banka);
        }

        // GET: Bakiye_Banka/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bakiye_Banka bakiye_Banka = db.Bakiye_Banka.Find(id);
            if (bakiye_Banka == null)
            {
                return HttpNotFound();
            }
            ViewBag.BankaID = new SelectList(db.Banka, "ID", "BankaAdi", bakiye_Banka.BankaID);
            return View(bakiye_Banka);
        }

        // POST: Bakiye_Banka/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BankaID,ParaBirimi,Bakiye")] Bakiye_Banka bakiye_Banka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bakiye_Banka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BankaID = new SelectList(db.Banka, "ID", "BankaAdi", bakiye_Banka.BankaID);
            return View(bakiye_Banka);
        }

        // GET: Bakiye_Banka/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bakiye_Banka bakiye_Banka = db.Bakiye_Banka.Find(id);
            if (bakiye_Banka == null)
            {
                return HttpNotFound();
            }
            return View(bakiye_Banka);
        }

        // POST: Bakiye_Banka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bakiye_Banka bakiye_Banka = db.Bakiye_Banka.Find(id);
            db.Bakiye_Banka.Remove(bakiye_Banka);
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
