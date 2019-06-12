using System.Net;
using System.Web.Mvc;
using Buchhaltung.Models;
using Buchhaltung.Models.Repository;

namespace Buchhaltung.Controllers
{
    public class AnfangsbetragController : Controller
    {
        private AnfangsbetragRepository repository = new AnfangsbetragRepository();
        private BuchhaltungDbContext ctx = new BuchhaltungDbContext();

        public ActionResult Index(int? bilanz)
        {
            ViewBag.Bilanz = null;

            if (bilanz != null)
            {
                ViewBag.Bilanz = bilanz;

                return View(repository.GetAllAnfangsbetragOfBilanz((int)bilanz));
            }

            return View(repository.GetAllAnfangsbetrag());
        }

        public ActionResult Create(int? bilanz)
        {
            ViewBag.BilanzId = new SelectList(ctx.Bilanz, "Id", "Bezeichnung", bilanz);
            ViewBag.KontoId = new SelectList(ctx.Konto, "Id", "Bezeichnung");

            ViewBag.Bilanz = bilanz;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,KontoId,Betrag,BilanzId")] Anfangsbetrag anfangsbetrag, int? bilanz)
        {
            if (ModelState.IsValid)
            {
                repository.Create(anfangsbetrag);

                if (bilanz != null)
                {
                    return RedirectToAction("Index", new { bilanz });
                }

                return RedirectToAction("Index");
            }

            ViewBag.BilanzId = new SelectList(ctx.Bilanz, "Id", "Bezeichnung", anfangsbetrag.BilanzId);
            ViewBag.KontoId = new SelectList(ctx.Konto, "Id", "Bezeichnung", anfangsbetrag.KontoId);

            return View(anfangsbetrag);
        }

        public ActionResult Edit(int? id, int? bilanz)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Anfangsbetrag anfangsbetrag = repository.GetAnfangsbetragById(id);

            if (anfangsbetrag == null)
            {
                return HttpNotFound();
            }

            ViewBag.BilanzId = new SelectList(ctx.Bilanz, "Id", "Bezeichnung", anfangsbetrag.BilanzId);
            ViewBag.KontoId = new SelectList(ctx.Konto, "Id", "Bezeichnung", anfangsbetrag.KontoId);

            ViewBag.Bilanz = bilanz;

            return View(anfangsbetrag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,KontoId,Betrag,BilanzId")] Anfangsbetrag anfangsbetrag, int? bilanz)
        {
            if (ModelState.IsValid)
            {
                repository.Edit(anfangsbetrag);

                if (bilanz != null)
                {
                    return RedirectToAction("Index", new { bilanz });
                }

                return RedirectToAction("Index");
            }

            ViewBag.BilanzId = new SelectList(ctx.Bilanz, "Id", "Bezeichnung", anfangsbetrag.BilanzId);
            ViewBag.KontoId = new SelectList(ctx.Konto, "Id", "Bezeichnung", anfangsbetrag.KontoId);

            return View(anfangsbetrag);
        }

        public ActionResult Delete(int? id, int? bilanz)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Anfangsbetrag anfangsbetrag = repository.GetAnfangsbetragById(id);

            if (anfangsbetrag == null)
            {
                return HttpNotFound();
            }

            ViewBag.Bilanz = bilanz;

            return View(anfangsbetrag);
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
