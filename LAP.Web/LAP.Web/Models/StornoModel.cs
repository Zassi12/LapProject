using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LAP.Logic;

namespace LAP.Web.Models
{
    public class StornoModel
    {

        public Benutzer User { get; set; }
        public string Firma { get; set; }
        public string Benutzername { get; set; }
        public string Gebäude { get; set; }
        public string Raum { get; set; }
        public DateTime Datum { get; set; }
        public string Grund { get; set; }
    }
}