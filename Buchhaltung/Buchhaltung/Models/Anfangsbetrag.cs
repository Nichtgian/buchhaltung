//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Buchhaltung.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Anfangsbetrag
    {
        public int Id { get; set; }
        public int KontoId { get; set; }
        public double Betrag { get; set; }
        public int BilanzId { get; set; }
    
        public virtual Bilanz Bilanz { get; set; }
        public virtual Konto Konto { get; set; }
    }
}
