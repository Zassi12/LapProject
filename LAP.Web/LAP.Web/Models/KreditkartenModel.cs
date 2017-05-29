using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LAP.Web.Models
{
    public class KreditkartenModel
    {
        public int Id_Buchung { get; set; }
        public bool IsValid { get; set; }
        [Required]
        [MaxLength(19)]
        [MinLength(13)]
        public string KreditKartenNummer { get; set; }
        [Required]
        public string  Vorname { get; set; }
        [Required]
        public string  Nachname { get; set; }
    }
}