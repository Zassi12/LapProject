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
    
    public partial class companies
    {
        public companies()
        {
            this.contacts = new HashSet<contacts>();
        }
    
        public int id { get; set; }
        public string companyname { get; set; }
        public string zip { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string number { get; set; }
    
        public virtual ICollection<contacts> contacts { get; set; }
    }
}