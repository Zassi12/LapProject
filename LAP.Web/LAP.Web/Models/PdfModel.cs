using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAP.Web.Models
{
    public class PdfModel
    {
        public string Absender { get; set; }
        public string Empfänger { get; set; }
        public string Artikel { get; set; }
        public string Zeitraum { get; set; }
        public string ZuZahlenderBetrag { get; set; }
        public string AustellungsDatum { get; set; }
        public string FortlaufendeNummer { get; set; }
        public string UID { get; set; }
    }
}