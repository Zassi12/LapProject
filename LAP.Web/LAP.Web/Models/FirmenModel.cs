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
        public string Companyname { get; set; }

       
        [StringLength(20)]
        public string Street { get; set; }

      
        [StringLength(10)]
        public string Number { get; set; }

       
        [StringLength(50)]
        public string City { get; set; }

       
        [StringLength(10)]
        public string Zip { get; set; }
    }
}
