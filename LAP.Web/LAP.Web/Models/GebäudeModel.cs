using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAP.Web.Models
{
    public class GebäudeModel
    {
        public int Id { get; set; }
        public string GebäudeBez { get; set; }
        public string Plz { get; set; }
        public string Stadt { get; set; }
        public string Straße { get; set; }
        public string Hausnummer { get; set; }
        public int order { get; set; }
        public bool active { get; set; }
        public string Label
        {
            get
            {
                return $"{Straße} {Hausnummer}";
            }
        }
    }
}