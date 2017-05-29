using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LAP.Logic;
using System.ComponentModel.DataAnnotations;

namespace LAP.Web.Models
{

    public class FirmenModel
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string FirmenName { get; set; }

        [StringLength(10)]
        public string Plz { get; set; }

        [StringLength(50)]
        public string Stadt { get; set; }

        [StringLength(20)]
        public string Straße { get; set; }
     
        [StringLength(10)]
        public string HausNummer { get; set; }

    }
}
