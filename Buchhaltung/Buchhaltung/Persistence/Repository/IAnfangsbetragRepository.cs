using System.Collections.Generic;
using Buchhaltung.Models;

namespace Buchhaltung.Persistence.Repository
{
    public interface IAnfangsbetragRepository : IRepository<Anfangsbetrag>
    {
        IEnumerable<Anfangsbetrag> GetAnfangsbetragListOfBilanz(int bilanzId);
    }
}