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
    
    public partial class Kategorien
    {
        public Kategorien()
        {
            this.AlleRäume = new HashSet<Raum>();
        }
    
        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public bool active { get; set; }
    
        public virtual ICollection<Raum> AlleRäume { get; set; }
    }
}
