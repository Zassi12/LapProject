using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LAP.Web.Models
{
    public class KreditkartenModel
    {
        public bool IsValid { get; set; }
        [Required]
        [MaxLength(19)]
        [MinLength(13)]
        public string KKNumber { get; set; }
        [Required]
        public string  Vorname { get; set; }
        [Required]
        public string  Nachname { get; set; }
    }
}