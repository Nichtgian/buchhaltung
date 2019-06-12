using System.Net;
using System.Web.Mvc;
using Buchhaltung.Models;
using Buchhaltung.Persistence;
using Buchhaltung.Persistence.Repository;

namespace Buchhaltung.Controllers
{
    public class BuchungssatzController : Controller
    {
        private BuchhaltungDbContext ctx;
        private UnitOfWork unitOfWork;

        public BuchungssatzController()
        {
            ctx = new BuchhaltungDbContext();
            unitOfWork = new UnitOfWork(ctx);
        }

        public ActionResult Index(int? bilanz)
        {
            ViewBag.Bilanz = null;

            if (bilanz != null)
            {
                ViewBag.Bilanz = bilanz;
                return View(unitOfWork.BuchungssatzRepository.GetBuchungssatzListOfBilanz((int)bilanz));
            }

            return View(unitOfWork.BuchungssatzRepository.GetAll());
        }

        public ActionResult Create(int? bilanz)
        {
            ViewBag.BilanzId = new SelectList(ctx.Bilanz, "Id", "Bezeichnung", bilanz);
            ViewBag.HabenId = new SelectList(ctx.Konto, "Id", "Bezeichnung");
            ViewBag.SollId = new SelectList(ctx.Konto, "Id", "Bezeichnung");

            ViewBag.Bilanz = bilanz;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SollId,HabenId,Betrag,Beschreibung,BilanzId")] Buchungssatz buchungssatz, int? bilanz)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.BuchungssatzRepository.Add(buchungssatz);
                unitOfWork.Complete();

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

            Buchungssatz buchungssatz = unitOfWork.BuchungssatzRepository.Get((int)id);

            if (buchungssatz == null)
            {
                return HttpNotFound();
            }

            ViewBag.BilanzId = new SelectList(ctx.Bilanz, "Id", "Bezeichnung", bilanz);
            ViewBag.HabenId = new SelectList(ctx.Konto, "Id", "Bezeichnung");
            ViewBag.SollId = new SelectList(ctx.Konto, "Id", "Bezeichnung");

            ViewBag.Bilanz = bilanz;

            return View(buchungssatz);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SollId,HabenId,Betrag,Beschreibung,BilanzId")] Buchungssatz buchungssatz, int? bilanz)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.BuchungssatzRepository.Update(buchungssatz);
                unitOfWork.Complete();

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

            Buchungssatz buchungssatz = unitOfWork.BuchungssatzRepository.Get((int)id);

            if (buchungssatz == null)
            {
                return HttpNotFound();
            }

            ViewBag.Bilanz = bilanz;

            return View(buchungssatz);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int? bilanz)
        {
            unitOfWork.BuchungssatzRepository.Remove(unitOfWork.BuchungssatzRepository.Get(id));
            unitOfWork.Complete();

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
                (unitOfWork.BuchungssatzRepository as BuchungssatzRepository)?.BuchhaltungDbContext.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
