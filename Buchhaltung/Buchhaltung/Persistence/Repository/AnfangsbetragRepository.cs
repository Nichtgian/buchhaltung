using System.Collections.Generic;
using System.Linq;
using Buchhaltung.Models;

namespace Buchhaltung.Persistence.Repository
{
    public class AnfangsbetragRepository : Repository<Anfangsbetrag>, IAnfangsbetragRepository
    {
        public AnfangsbetragRepository(BuchhaltungDbContext ctx) : base(ctx)
        {
        }

        public BuchhaltungDbContext BuchhaltungDbContext => ctx as BuchhaltungDbContext;

        public IEnumerable<Anfangsbetrag> GetAnfangsbetragListOfBilanz(int bilanzId)
        {
            return BuchhaltungDbContext.Anfangsbetrag
                .Where(b => b.BilanzId == bilanzId);
        }
    }
}