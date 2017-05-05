using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAP.Web.Models
{
    public class GebäudeModel
    {
        public int Id { get; set; }
        public string GebäudeName { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Label
        {
            get
            {
                return $"{Street} {Number}";
            }
        }
    }
}