using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAP.Web.Models
{
    public class RaumFirmaModel
    {
        public int ID_Room { get; set; }
        public int ID_Facility { get; set; }

        public int Quantity { get; set; }

        public FirmenModel Facility { get; set; }
    }
}