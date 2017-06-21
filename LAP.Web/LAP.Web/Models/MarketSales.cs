using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAP.Web.Models
{
    public class MarketSales
    {
        public string Market { get; set; }
        public int Year { get; set; }
        public decimal TotalSales { get; set; }
    }
}