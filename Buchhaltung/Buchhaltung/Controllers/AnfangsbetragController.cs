using System.Net;
using System.Web.Mvc;
using Buchhaltung.Models;
using Buchhaltung.Persistence;
using Buchhaltung.Persistence.Repository;

namespace Buchhaltung.Controllers
{
    public class AnfangsbetragController : Controller
    {
        private BuchhaltungDbContext ctx;
        private UnitOfWork unitOfWork;

        public AnfangsbetragController()
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

                return View(unitOfWork.AnfangsbetragRepository.GetAnfangsbetragListOfBilanz((int)bilanz));
            }

            return View(unitOfWork.AnfangsbetragRepository.GetAll());
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
                unitOfWork.AnfangsbetragRepository.Add(anfangsbetrag);
                unitOfWork.Complete();

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

            Anfangsbetrag anfangsbetrag = unitOfWork.AnfangsbetragRepository.Get((int)id);

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
                unitOfWork.AnfangsbetragRepository.Update(anfangsbetrag);
                unitOfWork.Complete();

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

            Anfangsbetrag anfangsbetrag = unitOfWork.AnfangsbetragRepository.Get((int)id);

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
            unitOfWork.AnfangsbetragRepository.Remove(unitOfWork.AnfangsbetragRepository.Get(id));
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
                (unitOfWork.AnfangsbetragRepository as AnfangsbetragRepository)?.BuchhaltungDbContext.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
