using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAP.Logic
{
    public class Buchung
    {
        public int ID { get; set; }
        public string Passnummer { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public System.DateTime Geburtsdatum { get; set; }
        public System.DateTime ErstelltAm { get; set; }

        //public virtual Benutzer Benutzer { get; set; }
        //public virtual Reisedatum Reisedatum { get; set; }
        //public virtual Buchung_Zahlung Buchung_Zahlung { get; set; }
        //public virtual BuchungStorniert BuchungStorniert { get; set; }
    }
}
