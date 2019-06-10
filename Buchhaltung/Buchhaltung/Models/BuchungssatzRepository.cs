namespace Buchhaltung.Models
{
    public class BuchungssatzRepository
    {
        public void Insert(Buchungssatz buchungssatz)
        {
            using (var ctx = new BuchhaltungDbContext())
            {
                ctx.Buchungssatz.Add(buchungssatz);
                ctx.SaveChanges();
            }
        }
    }
}