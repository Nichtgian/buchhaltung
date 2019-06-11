using System.Collections.Generic;
using System.Linq;

namespace Buchhaltung.Models.Repository
{
    public class KontoRepository
    {
        public IEnumerable<Konto> GetAllKontos()
        {
            using (var ctx = new BuchhaltungDbContext())
            {
                return ctx.Konto.ToList();
            }
        }

        public IEnumerable<Konto> GetAllKontosOfKontoArt(KontoArt kontoArt)
        {
            using (var ctx = new BuchhaltungDbContext())
            {
                return ctx.Konto.Where(k => k.KontoArtId == kontoArt.Id).OrderBy(k => k.Reihenfolge);
            }
        }
    }
}