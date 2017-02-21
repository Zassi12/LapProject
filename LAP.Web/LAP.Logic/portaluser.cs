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
    
    public partial class portaluser
    {
        public portaluser()
        {
            this.bills = new HashSet<bill>();
            this.bookingreversals = new HashSet<bookingreversal>();
            this.bookings = new HashSet<booking>();
            this.contacts = new HashSet<contact>();
        }
    
        public int id { get; set; }
        public int role_id { get; set; }
        public string email { get; set; }
        public byte[] password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public Nullable<bool> Ist_Mitarbeiter { get; set; }
    
        public virtual ICollection<bill> bills { get; set; }
        public virtual ICollection<bookingreversal> bookingreversals { get; set; }
        public virtual ICollection<booking> bookings { get; set; }
        public virtual ICollection<contact> contacts { get; set; }
        public virtual portalrole portalrole { get; set; }
    }
}
