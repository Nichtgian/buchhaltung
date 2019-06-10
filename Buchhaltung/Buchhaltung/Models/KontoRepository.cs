using System.Collections.Generic;
using System.Linq;

namespace Buchhaltung.Models
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
    }
}