using System.Collections.Generic;
using System.Linq;
using System.Net;
using Buchhaltung.Models;
using System.Web.Mvc;
using Buchhaltung.Persistence;
using Buchhaltung.Persistence.Entity;
using Buchhaltung.Persistence.Repository;

namespace Buchhaltung.Controllers
{
    public class BilanzController : Controller
    {
        private UnitOfWork unitOfWork;

        public BilanzController()
        {
            unitOfWork = new UnitOfWork(new BuchhaltungDbContext());
        }

        public ActionResult Index()
        {
            return View(unitOfWork.BilanzRepository.GetAll());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Bilanz bilanz = unitOfWork.BilanzRepository.Get((int)id);

            if (bilanz == null)
            {
                return HttpNotFound();
            }

            return View(bilanz);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Bezeichnung,Code,Datum")] Bilanz bilanz)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.BilanzRepository.Add(bilanz);
                unitOfWork.Complete();

                return RedirectToAction("Index");
            }

            return View(bilanz);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Bilanz bilanz = unitOfWork.BilanzRepository.Get((int)id);

            if (bilanz == null)
            {
                return HttpNotFound();
            }

            return View(bilanz);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Bezeichnung,Code,Datum")] Bilanz bilanz)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.BilanzRepository.Update(bilanz);
                unitOfWork.Complete();

                return RedirectToAction("Index");
            }

            return View(bilanz);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Bilanz bilanz = unitOfWork.BilanzRepository.Get((int)id);

            if (bilanz == null)
            {
                return HttpNotFound();
            }

            return View(bilanz);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            unitOfWork.BilanzRepository.Remove(unitOfWork.BilanzRepository.Get(id));
            unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        public List<Kontoabschluss> GetKontoabschlussListOfKontoArt(int bilanzId, int kontoArtId)
        {
            return unitOfWork.BilanzRepository.GetKontoAbschlussListOfKontoArtFromBilanz(bilanzId, kontoArtId).ToList();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                (unitOfWork.BilanzRepository as BilanzRepository)?.BuchhaltungDbContext.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
