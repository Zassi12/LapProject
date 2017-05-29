using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAP.Web.Models
{
    public class RaumFilterModel
    {
        public List<FirmenModel> Firmen { get; set; }

        public List<GebäudeModel> Gebäude { get; set; }
    }
}