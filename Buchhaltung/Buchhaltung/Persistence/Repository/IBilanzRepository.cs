using System.Collections.Generic;
using Buchhaltung.Models;
using Buchhaltung.Persistence.Entity;

namespace Buchhaltung.Persistence.Repository
{
    public interface IBilanzRepository : IRepository<Bilanz>
    {
        IEnumerable<Kontoabschluss> GetKontoAbschlussListOfKontoArtFromBilanz(int bilanzId, int kontoArtId);
    }
}