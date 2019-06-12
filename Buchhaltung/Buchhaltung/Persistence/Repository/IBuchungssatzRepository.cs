using System.Collections.Generic;
using Buchhaltung.Models;

namespace Buchhaltung.Persistence.Repository
{
    public interface IBuchungssatzRepository : IRepository<Buchungssatz>
    {
        IEnumerable<Buchungssatz> GetBuchungssatzListOfBilanz(int bilanzId);
    }
}