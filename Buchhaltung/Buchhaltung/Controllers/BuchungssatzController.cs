using System.Net;
using System.Web.Mvc;
using Buchhaltung.Models;
using Buchhaltung.Models.Repository;

namespace Buchhaltung.Controllers
{
    public class BuchungssatzController : Controller
    {
        private BuchungssatzRepository repository = new BuchungssatzRepository();
        private BuchhaltungDbContext ctx = new BuchhaltungDbContext();

        public ActionResult Index(int? bilanz)
        {
            ViewBag.Bilanz = null;

            if (bilanz != null)
            {
                ViewBag.Bilanz = bilanz;
                return View(repository.GetAllBuchungssatzOfBilanz((int)bilanz));
            }

            return View(repository.GetAllBuchungssatz());
        }

        public ActionResult Create(int? bilanz)
        {
            ViewBag.BilanzId = new SelectList(ctx.Bilanz, "Id", "Bezeichnung", bilanz);
            ViewBag.HabenId = new SelectList(ctx.Konto, "Id", "Bezeichnung");
            ViewBag.SollId = new SelectList(ctx.Konto, "Id", "Bezeichnung");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SollId,HabenId,Betrag,Beschreibung,BilanzId")] Buchungssatz buchungssatz, int? bilanz)
        {
            if (ModelState.IsValid)
            {
                repository.Create(buchungssatz);

                if (bilanz != null)
                {
                    return RedirectToAction("Index", new { bilanz });
                }

                return RedirectToAction("Index");
            }

            ViewBag.BilanzId = new SelectList(ctx.Bilanz, "Id", "Bezeichnung");
            ViewBag.HabenId = new SelectList(ctx.Konto, "Id", "Bezeichnung");
            ViewBag.SollId = new SelectList(ctx.Konto, "Id", "Bezeichnung");

            return View(buchungssatz);
        }

        public ActionResult Edit(int? id, int? bilanz)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Buchungssatz buchungssatz = repository.GetBuchungssatzById(id);

            if (buchungssatz == null)
            {
                return HttpNotFound();
            }

            if (bilanz != null)
            {
                ViewBag.Bilanz = bilanz;
            }

            ViewBag.BilanzId = new SelectList(ctx.Bilanz, "Id", "Bezeichnung", bilanz);
            ViewBag.HabenId = new SelectList(ctx.Konto, "Id", "Bezeichnung");
            ViewBag.SollId = new SelectList(ctx.Konto, "Id", "Bezeichnung");

            return View(buchungssatz);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SollId,HabenId,Betrag,Beschreibung,BilanzId")] Buchungssatz buchungssatz, int? bilanz)
        {
            if (ModelState.IsValid)
            {
                repository.Edit(buchungssatz);

                if (bilanz != null)
                {
                    return RedirectToAction("Index", new { bilanz });
                }

                return RedirectToAction("Index");
            }

            ViewBag.BilanzId = new SelectList(ctx.Bilanz, "Id", "Bezeichnung");
            ViewBag.HabenId = new SelectList(ctx.Konto, "Id", "Bezeichnung");
            ViewBag.SollId = new SelectList(ctx.Konto, "Id", "Bezeichnung");

            return View(buchungssatz);
        }

        public ActionResult Delete(int? id, int? bilanz)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Buchungssatz buchungssatz = repository.GetBuchungssatzById(id);

            if (buchungssatz == null)
            {
                return HttpNotFound();
            }

            if (bilanz != null)
            {
                ViewBag.Bilanz = bilanz;
            }

            return View(buchungssatz);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int? bilanz)
        {
            repository.Delete(id);
            if (bilanz != null)
            {
                return RedirectToAction("Index", new { bilanz });
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
