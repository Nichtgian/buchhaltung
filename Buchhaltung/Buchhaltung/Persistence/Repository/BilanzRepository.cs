using Buchhaltung.Models;

namespace Buchhaltung.Persistence.Repository
{
    public class BilanzRepository : Repository<Bilanz>, IBilanzRepository
    {
        public BilanzRepository(BuchhaltungDbContext ctx) : base(ctx)
        {
        }

        public BuchhaltungDbContext BuchhaltungDbContext => ctx as BuchhaltungDbContext;
    }
}