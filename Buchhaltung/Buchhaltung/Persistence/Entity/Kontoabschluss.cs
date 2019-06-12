using Buchhaltung.Models;

namespace Buchhaltung.Persistence.Entity
{
    public class Kontoabschluss
    {
        public Konto Konto;
        public double Schlussbetrag = 0;
    }
}
