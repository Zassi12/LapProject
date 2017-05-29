using LAP.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAP.Web.Models
{
    public class RechnungModel
    {
        public Benutzer Absender  { get; set; }
        public Benutzer Empfänger { get; set; }
        public DateTime LieferDatum { get; set; }
        public DateTime AustellungsDatum { get; set; }
        public string Bezeichnung { get; set; }
        public int Betrag { get; set; }
        public int Ust { get; set; }
        public string ZuZahlenderBetrag { get; set; }
        public string UidLiefernder { get; set; }
        public string UidEmpfänger { get; set; }
        public int RechnungsNummer { get; set; }
    }
}