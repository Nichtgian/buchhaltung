using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Buchhaltung.Models.Repository
{
    public class BuchungssatzRepository
    {
        private BuchhaltungDbContext ctx = new BuchhaltungDbContext();

        public List<Buchungssatz> GetAllBuchungssatz()
        {
            return ctx.Buchungssatz
                .Include(b => b.Bilanz)
                .Include(b => b.Soll)
                .Include(b => b.Haben)
                .ToList();
        }

        public List<Buchungssatz> GetAllBuchungssatzOfBilanz(int bilanz)
        {
            return ctx.Buchungssatz
                .Include(b => b.Bilanz)
                .Include(b => b.Soll)
                .Include(b => b.Haben)
                .Where(b => b.BilanzId == bilanz)
                .ToList();
        }

        public Buchungssatz GetBuchungssatzById(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return ctx.Buchungssatz.Find(id);
        }

        public void Create(Buchungssatz buchungssatz)
        {
            ctx.Buchungssatz.Add(buchungssatz);
            ctx.SaveChanges();
        }

        public void Edit(Buchungssatz buchungssatz)
        {
            ctx.Entry(buchungssatz).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            Buchungssatz buchungssatz = GetBuchungssatzById(id);

            if (buchungssatz != null)
            {
                ctx.Buchungssatz.Remove(buchungssatz);
                ctx.SaveChanges();
            }
        }

        public void Dispose()
        {
            ctx.Dispose();
        }
    }
}