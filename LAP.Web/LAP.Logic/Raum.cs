//------------------------------------------------------------------------------
// <auto-generated>
//    Dieser Code wurde aus einer Vorlage generiert.
//
//    Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten Ihrer Anwendung.
//    Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LAP.Logic
{
    using System;
    using System.Collections.Generic;
    
    public partial class Raum
    {
        public Raum()
        {
            this.AlleBuchungen = new HashSet<Buchung>();
            this.AlleRaumEinrichtungen = new HashSet<RaumEinrichtung>();
        }
    
        public int Id { get; set; }
        public int Gebäude_Id { get; set; }
        public string Beschreibung { get; set; }
    
        public virtual ICollection<Buchung> AlleBuchungen { get; set; }
        public virtual ICollection<RaumEinrichtung> AlleRaumEinrichtungen { get; set; }
        public virtual Gebäude Gebäude { get; set; }
    }
}