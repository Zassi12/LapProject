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
    
    public partial class RechnungsDetail
    {
        public int Id { get; set; }
        public int Buchung_Id { get; set; }
        public System.DateTime Datum { get; set; }
        public int Rechnung_Id { get; set; }
    
        public virtual Buchung Buchung { get; set; }
        public virtual Rechnung Rechnung { get; set; }
    }
}