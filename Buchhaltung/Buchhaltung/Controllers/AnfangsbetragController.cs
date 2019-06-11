using System.Data.Entity;
using System.Linq;
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

            if (bilanz != null)
            {
                ViewBag.Bilanz = bilanz;
            }

            ViewBag.BilanzId = new SelectList(ctx.Bilanz, "Id", "Bezeichnung", anfangsbetrag.BilanzId);
            ViewBag.KontoId = new SelectList(ctx.Konto, "Id", "Bezeichnung", anfangsbetrag.KontoId);

            return View(anfangsbetrag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,KontoId,Betrag,BilanzId")] Anfangsbetrag anfangsbetrag)
        {
            if (ModelState.IsValid)
            {
                ctx.Entry(anfangsbetrag).State = EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BilanzId = new SelectList(ctx.Bilanz, "Id", "Bezeichnung", anfangsbetrag.BilanzId);
            ViewBag.KontoId = new SelectList(ctx.Konto, "Id", "Bezeichnung", anfangsbetrag.KontoId);
            return View(anfangsbetrag);
        }

        // GET: Anfangsbetrag/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anfangsbetrag anfangsbetrag = ctx.Anfangsbetrag.Find(id);
            if (anfangsbetrag == null)
            {
                return HttpNotFound();
            }
            return View(anfangsbetrag);
        }

        // POST: Anfangsbetrag/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Anfangsbetrag anfangsbetrag = ctx.Anfangsbetrag.Find(id);
            ctx.Anfangsbetrag.Remove(anfangsbetrag);
            ctx.SaveChanges();
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
