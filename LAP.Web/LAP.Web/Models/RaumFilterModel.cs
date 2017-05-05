using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAP.Web.Models
{
    public class RaumFilterModel
    {
        public List<FirmenModel> Facilities { get; set; }

        public List<GebäudeModel> Buildings { get; set; }
    }
}