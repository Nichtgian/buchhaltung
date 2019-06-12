using System.Data.Entity.ModelConfiguration;
using Buchhaltung.Models;

namespace Buchhaltung.Persistence.Configuration
{
    public class BilanzConfiguration : EntityTypeConfiguration<Bilanz>
    {
        public BilanzConfiguration()
        {
            Property(c => c.Bezeichnung)
                .IsRequired()
                .HasMaxLength(60);

            Property(c => c.Code)
                .IsRequired()
                .HasMaxLength(10);

            Property(c => c.Datum)
                .IsRequired();
        }
    }
}