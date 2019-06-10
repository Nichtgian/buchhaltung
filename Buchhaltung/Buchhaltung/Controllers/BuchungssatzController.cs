using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Buchhaltung;

namespace Buchhaltung.Controllers
{
    public class BuchungssatzController : Controller
    {
        private BuchhaltungDbContext db = new BuchhaltungDbContext();

        // GET: Buchungssatz
        public ActionResult Index()
        {
            var buchungssatz = db.Buchungssatz.Include(b => b.Bilanz1).Include(b => b.Konto).Include(b => b.Konto1);
            return View(buchungssatz.ToList());
        }

        // GET: Buchungssatz/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buchungssatz buchungssatz = db.Buchungssatz.Find(id);
            if (buchungssatz == null)
            {
                return HttpNotFound();
            }
            return View(buchungssatz);
        }

        // GET: Buchungssatz/Create
        public ActionResult Create()
        {
            ViewBag.Bilanz = new SelectList(db.Bilanz, "Id", "Bezeichnung");
            ViewBag.Haben = new SelectList(db.Konto, "Id", "Bezeichnung");
            ViewBag.Soll = new SelectList(db.Konto, "Id", "Bezeichnung");
            return View();
        }

        // POST: Buchungssatz/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Soll,Haben,Betrag,Beschreibung,Bilanz")] Buchungssatz buchungssatz)
        {
            if (ModelState.IsValid)
            {
                db.Buchungssatz.Add(buchungssatz);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Bilanz = new SelectList(db.Bilanz, "Id", "Bezeichnung", buchungssatz.Bilanz);
            ViewBag.Haben = new SelectList(db.Konto, "Id", "Bezeichnung", buchungssatz.Haben);
            ViewBag.Soll = new SelectList(db.Konto, "Id", "Bezeichnung", buchungssatz.Soll);
            return View(buchungssatz);
        }

        // GET: Buchungssatz/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buchungssatz buchungssatz = db.Buchungssatz.Find(id);
            if (buchungssatz == null)
            {
                return HttpNotFound();
            }
            ViewBag.Bilanz = new SelectList(db.Bilanz, "Id", "Bezeichnung", buchungssatz.Bilanz);
            ViewBag.Haben = new SelectList(db.Konto, "Id", "Bezeichnung", buchungssatz.Haben);
            ViewBag.Soll = new SelectList(db.Konto, "Id", "Bezeichnung", buchungssatz.Soll);
            return View(buchungssatz);
        }

        // POST: Buchungssatz/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Soll,Haben,Betrag,Beschreibung,Bilanz")] Buchungssatz buchungssatz)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buchungssatz).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Bilanz = new SelectList(db.Bilanz, "Id", "Bezeichnung", buchungssatz.Bilanz);
            ViewBag.Haben = new SelectList(db.Konto, "Id", "Bezeichnung", buchungssatz.Haben);
            ViewBag.Soll = new SelectList(db.Konto, "Id", "Bezeichnung", buchungssatz.Soll);
            return View(buchungssatz);
        }

        // GET: Buchungssatz/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buchungssatz buchungssatz = db.Buchungssatz.Find(id);
            if (buchungssatz == null)
            {
                return HttpNotFound();
            }
            return View(buchungssatz);
        }

        // POST: Buchungssatz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Buchungssatz buchungssatz = db.Buchungssatz.Find(id);
            db.Buchungssatz.Remove(buchungssatz);
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
