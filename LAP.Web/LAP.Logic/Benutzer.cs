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
    
    public partial class Benutzer
    {
        public Benutzer()
        {
            this.Buchungen = new HashSet<Buchungen>();
            this.Kontakte = new HashSet<Kontakte>();
            this.Rechnungen = new HashSet<Rechnungen>();
            this.Stornierungen = new HashSet<Stornierungen>();
        }
    
        public int Id { get; set; }
        public int BenutzerRolle_Id { get; set; }
        public int Firmen_Id { get; set; }
        public string Email { get; set; }
        public byte[] Passwort { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public bool ist_Mitarbeiter { get; set; }
        public bool active { get; set; }
    
        public virtual BenutzerRollen BenutzerRollen { get; set; }
        public virtual Firmen Firmen { get; set; }
        public virtual ICollection<Buchungen> Buchungen { get; set; }
        public virtual ICollection<Kontakte> Kontakte { get; set; }
        public virtual ICollection<Rechnungen> Rechnungen { get; set; }
        public virtual ICollection<Stornierungen> Stornierungen { get; set; }
    }
}
