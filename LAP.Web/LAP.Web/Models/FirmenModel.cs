using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LAP.Logic;

namespace LAP.Web.Models
{
    /// <summary>
    /// Class for showing gathering all the data for the partial views
    /// </summary>
    public class FirmenModel
    {
        public company Companys { get; set; }
        public List<portaluser> Users { get; set; }
    }
}