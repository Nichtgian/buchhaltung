using System.Collections.Generic;
using Buchhaltung.Models;

namespace Buchhaltung.Persistence.Entity
{
    public class Kontoabschluss
    {
        private Kontoabschluss(int kontoId)
        {
            AnfangsbetragList = new HashSet<Anfangsbetrag>();
            BuchunssatzList = new HashSet<Buchungssatz>();
        }

        public Konto Konto;
        public double Schlussbetrag = 0;

        public virtual ICollection<Anfangsbetrag> AnfangsbetragList { get; set; }
        public virtual ICollection<Buchungssatz> BuchunssatzList { get; set; }
    }
}
