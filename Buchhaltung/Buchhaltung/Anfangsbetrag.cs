//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Buchhaltung
{
    using System;
    using System.Collections.Generic;
    
    public partial class Anfangsbetrag
    {
        public int Id { get; set; }
        public int Konto { get; set; }
        public double Betrag { get; set; }
        public int Bilanz { get; set; }
    
        public virtual Bilanz Bilanz1 { get; set; }
        public virtual Konto Konto1 { get; set; }
    }
}