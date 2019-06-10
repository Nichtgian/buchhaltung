using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Buchhaltung.Models
{
    public class BilanzRepository
    {
        private BuchhaltungDbContext ctx = new BuchhaltungDbContext();

        // GET: Bilanz
        public List<Bilanz> Index()
        {
            return ctx.Bilanz.ToList();
        }

        // GET: Bilanz/Details/Id
        public Bilanz Details(int? id)
        {
            return FindBilanz(id);
        }

        // POST: Bilanz/Create
        [HttpPost]
        public void Create(Bilanz bilanz)
        {
            ctx.Bilanz.Add(bilanz);
            ctx.SaveChanges();
        }

        // GET: Bilanz/Edit/Id
        public Bilanz Edit(int? id)
        {
            return FindBilanz(id);
        }

        // POST: Bilanz/Edit/Id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Edit(Bilanz bilanz)
        {
            ctx.Entry(bilanz).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        // GET: Bilanz/Delete/Id
        public Bilanz Delete(int? id)
        {
            return FindBilanz(id);
        }

        // POST: Bilanz/Delete/Id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public void DeleteConfirmed(int id)
        {
            Bilanz bilanz = FindBilanz(id);
            if (bilanz != null)
            {
                ctx.Bilanz.Remove(bilanz);
                ctx.SaveChanges();
            }
        }

        private Bilanz FindBilanz(int? id)
        {
            if (id == null)
            {
                return null;
            }

            Bilanz bilanz = ctx.Bilanz.Find(id);

            if (bilanz == null)
            {
                return null;
            }

            return bilanz;
        }

        public void Dispose()
        {
            ctx.Dispose();
        }
    }
}