using Buchhaltung.Models;
using Buchhaltung.Persistence.Repository;

namespace Buchhaltung.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BuchhaltungDbContext ctx;

        public UnitOfWork(BuchhaltungDbContext ctx)
        {
            this.ctx = ctx;

            BilanzRepository = new BilanzRepository(ctx);
            AnfangsbetragRepository = new AnfangsbetragRepository(ctx);
            BuchungssatzRepository = new BuchungssatzRepository(ctx);
        }

        public IBilanzRepository BilanzRepository { get; }
        public IAnfangsbetragRepository AnfangsbetragRepository { get; }
        public IBuchungssatzRepository BuchungssatzRepository { get; }

        public int Complete()
        {
            return ctx.SaveChanges();
        }

        public void Dispose()
        {
            ctx.Dispose();
        }
    }
}