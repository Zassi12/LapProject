using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LAP.Logic;
using System.ComponentModel.DataAnnotations;

namespace LAP.Web.Models
{
    public class RaumFilterModel
    {
        [DataType(DataType.Date)]
        public string Von { get; set; }

        public string Bis { get; set; }

        public int? Id_Kategorie { get; set; }

        public int? Id_Gebäude { get; set; }

        public List<Raum> Räume { get; set; }

        public List<Kategorien> Kategorien { get; set; }

        public List<Gebäude> Gebäude { get; set; }
    }
}