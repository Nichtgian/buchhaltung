using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Buchhaltung.Models.Repository
{
    public class BilanzRepository
    {
        private BuchhaltungDbContext ctx = new BuchhaltungDbContext();

        public List<Bilanz> GetAllBilanz()
        {
            return ctx.Bilanz.ToList();
        }

        public Bilanz GetBilanzById(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return ctx.Bilanz.Find(id);
        }

        public void Create(Bilanz bilanz)
        {
            ctx.Bilanz.Add(bilanz);
            ctx.SaveChanges();
        }

        public void Edit(Bilanz bilanz)
        {
            ctx.Entry(bilanz).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            Bilanz bilanz = GetBilanzById(id);

            if (bilanz != null)
            {
                ctx.Bilanz.Remove(bilanz);
                ctx.SaveChanges();
            }
        }

        public void Dispose()
        {
            ctx.Dispose();
        }
    }
}