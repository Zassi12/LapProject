using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAP.Web.Models
{
    public class RaumModel : GebäudeModel
    {
        public int Raum_id { get; set; }
        public List<object> RaumEinrichtungen { get; set; }
        public string RaumBeschreibung { get; set; }
    }
}