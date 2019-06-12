using System.Collections.Generic;
using System.Linq;
using Buchhaltung.Models;
using Buchhaltung.Persistence.Entity;

namespace Buchhaltung.Persistence.Repository
{
    public class BilanzRepository : Repository<Bilanz>, IBilanzRepository
    {
        public BilanzRepository(BuchhaltungDbContext ctx) : base(ctx)
        {
        }

        public BuchhaltungDbContext BuchhaltungDbContext => ctx as BuchhaltungDbContext;

        public IEnumerable<Kontoabschluss> GetKontoAbschlussListOfKontoArtFromBilanz(int bilanzId, int kontoArtId)
        {
            Bilanz bilanz = BuchhaltungDbContext.Bilanz.Find(bilanzId);
            KontoArt kontoArt = BuchhaltungDbContext.KontoArt.Find(kontoArtId);

            var kontoAbschlussList = new List<Kontoabschluss>();

            if (bilanz == null || kontoArt == null)
            {
                return kontoAbschlussList;
            }

            foreach (var konto in kontoArt.Konto)
            {
                double betrag = 0;
                Kontoabschluss ka = new Kontoabschluss {Konto = konto, Schlussbetrag = 0};

                if (kontoArt.IsPositive)
                {
                    foreach (var anfangsbetrag in bilanz.Anfangsbetrag.Where(a => a.KontoId == konto.Id))
                    {
                        betrag += anfangsbetrag.Betrag;
                    }
                    foreach (var buchungssatzSoll in bilanz.Buchungssatz.Where(a => a.SollId == konto.Id))
                    {
                        betrag += buchungssatzSoll.Betrag;
                    }
                    foreach (var buchungssatzHaben in bilanz.Buchungssatz.Where(a => a.HabenId == konto.Id))
                    {
                        betrag -= buchungssatzHaben.Betrag;
                    }
                }
                else
                {
                    foreach (var anfangsbetrag in bilanz.Anfangsbetrag.Where(a => a.KontoId == konto.Id))
                    {
                        betrag -= anfangsbetrag.Betrag;
                    }
                    foreach (var buchungssatzSoll in bilanz.Buchungssatz.Where(a => a.SollId == konto.Id))
                    {
                        betrag -= buchungssatzSoll.Betrag;
                    }
                    foreach (var buchungssatzHaben in bilanz.Buchungssatz.Where(a => a.HabenId == konto.Id))
                    {
                        betrag += buchungssatzHaben.Betrag;
                    }

                    betrag *= -1;
                }

                if (betrag != 0)
                {
                    ka.Schlussbetrag = betrag;
                    kontoAbschlussList.Add(ka);
                }
            }

            return kontoAbschlussList;
        }
    }
}