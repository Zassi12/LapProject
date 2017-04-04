using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LAP.Logic;

namespace LAP.Web.Models
{
    public class StornoModel
    {
        public portaluser User { get; set; }
        public string Firma { get; set; }
        public string Benutzername { get; set; }
        public string Building { get; set; }
        public string Room { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }

    }
}