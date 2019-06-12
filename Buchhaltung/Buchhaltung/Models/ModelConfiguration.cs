using System;
using System.ComponentModel.DataAnnotations;

namespace Buchhaltung.Models
{
    public class BilanzConfiguration
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Bezeichnung")]
        public string Bezeichnung;

        [Required]
        [StringLength(15)]
        [Display(Name = "Code")]
        public string Code;

        [Required]
        [Display(Name = "Datum")]
        public DateTime Datum;
    }

    public class BuchungssatzConfiguration
    {
        [Required]
        [Display(Name = "SollId")]
        public int SollId;

        [Required]
        [Display(Name = "HabenId")]
        public int HabenId;

        [Required]
        [Display(Name = "Betrag")]
        public double Betrag;

        [Required]
        [Display(Name = "BilanzId")]
        public int BilanzId;
    }

    public class AnfangsbetragConfiguration
    {
        [Required]
        [Display(Name = "KontoId")]
        public int KontoId;

        [Required]
        [Display(Name = "Betrag")]
        public double Betrag;

        [Required]
        [Display(Name = "BilanzId")]
        public int BilanzId;
    }

    [MetadataType(typeof(BilanzConfiguration))]
    public partial class Bilanz
    {
    }

    [MetadataType(typeof(BuchungssatzConfiguration))]
    public partial class Buchungssatz
    {
    }

    [MetadataType(typeof(AnfangsbetragConfiguration))]
    public partial class Anfangsbetrag
    {
    }
}