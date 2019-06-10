using Buchhaltung.Models;
using System.Web.Mvc;

namespace Buchhaltung.Controllers
{
    public class BilanzController : Controller
    {
        BilanzRepository repository = new BilanzRepository();

        public ActionResult Index()
        {
            return View(repository.Index());
        }

        public ActionResult Details(int? id)
        {
            return View(repository.Details(id));
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
            return View(repository.Edit(id));
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
            return View(repository.Delete(id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repository.DeleteConfirmed(id);
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
