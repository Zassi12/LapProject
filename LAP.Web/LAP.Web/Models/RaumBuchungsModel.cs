using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAP.Web.Models
{
    public class RaumBuchungsModel
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime Enddatum { get; set; }
        public string GebäudeBezeichnung { get; set; }
        public string Plz { get; set; }
        public string MyProperty { get; set; }
    }
}