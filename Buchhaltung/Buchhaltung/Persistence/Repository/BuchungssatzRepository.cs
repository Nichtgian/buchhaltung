using System.Collections.Generic;
using System.Linq;
using Buchhaltung.Models;

namespace Buchhaltung.Persistence.Repository
{
    public class BuchungssatzRepository : Repository<Buchungssatz>, IBuchungssatzRepository
    {
        public BuchungssatzRepository(BuchhaltungDbContext ctx) : base(ctx)
        {
        }

        public BuchhaltungDbContext BuchhaltungDbContext => ctx as Models.BuchhaltungDbContext;

        public IEnumerable<Buchungssatz> GetBuchungssatzListOfBilanz(int bilanzId)
        {
            return BuchhaltungDbContext.Buchungssatz
                .Where(b => b.BilanzId == bilanzId);
        }
    }
}