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
    
    public partial class Gebäude
    {
        public Gebäude()
        {
            this.Räume = new HashSet<Raum>();
        }
    
        public int Id { get; set; }
        public string Plz { get; set; }
        public string Stadt { get; set; }
        public string Straße { get; set; }
        public string Hausnummer { get; set; }
        public int order { get; set; }
        public bool active { get; set; }
        public string GebäudeBez { get; set; }
    
        public virtual ICollection<Raum> Räume { get; set; }
    }
}
