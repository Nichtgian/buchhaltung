using System;
using Buchhaltung.Persistence.Repository;

namespace Buchhaltung.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IBilanzRepository BilanzRepository { get; }
        IAnfangsbetragRepository AnfangsbetragRepository { get; }
        IBuchungssatzRepository BuchungssatzRepository { get; }

        int Complete();
    }
}