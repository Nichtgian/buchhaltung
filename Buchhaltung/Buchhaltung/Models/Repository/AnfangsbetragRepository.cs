using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Buchhaltung.Models.Repository
{
    public class AnfangsbetragRepository
    {
        private BuchhaltungDbContext ctx = new BuchhaltungDbContext();

        public List<Anfangsbetrag> GetAllAnfangsbetrag()
        {
            return ctx.Anfangsbetrag
                .Include(b => b.Bilanz)
                .Include(b => b.Konto)
                .ToList();
        }

        public List<Anfangsbetrag> GetAllAnfangsbetragOfBilanz(int bilanz)
        {
            return ctx.Anfangsbetrag
                .Include(b => b.Bilanz)
                .Include(b => b.Konto)
                .Where(b => b.BilanzId == bilanz)
                .ToList();
        }

        public Anfangsbetrag GetAnfangsbetragById(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return ctx.Anfangsbetrag.Find(id);
        }

        public void Create(Anfangsbetrag anfangsbetrag)
        {
            ctx.Anfangsbetrag.Add(anfangsbetrag);
            ctx.SaveChanges();
        }

        public void Edit(Anfangsbetrag anfangsbetrag)
        {
            ctx.Entry(anfangsbetrag).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            Anfangsbetrag anfangsbetrag = GetAnfangsbetragById(id);

            if (anfangsbetrag != null)
            {
                ctx.Anfangsbetrag.Remove(anfangsbetrag);
                ctx.SaveChanges();
            }
        }

        public void Dispose()
        {
            ctx.Dispose();
        }
    }
}