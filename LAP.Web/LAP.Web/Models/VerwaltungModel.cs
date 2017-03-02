using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LAP.Logic;

namespace LAP.Web.Models
{
    public class VerwaltungModel
    {
        public List<company> Companys { get; set; }
        public List<portaluser> Users { get; set; }
    }
}