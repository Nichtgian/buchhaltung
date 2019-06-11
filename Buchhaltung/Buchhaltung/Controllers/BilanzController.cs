using System.Net;
using Buchhaltung.Models;
using System.Web.Mvc;
using Buchhaltung.Models.Repository;

namespace Buchhaltung.Controllers
{
    public class BilanzController : Controller
    {
        BilanzRepository repository = new BilanzRepository();

        public ActionResult Index()
        {
            return View(repository.GetAllBilanz());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Bilanz bilanz = repository.GetBilanzById(id);

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
                repository.Create(bilanz);
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

            Bilanz bilanz = repository.GetBilanzById(id);

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
                repository.Edit(bilanz);
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

            Bilanz bilanz = repository.GetBilanzById(id);

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
            repository.Delete(id);
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
