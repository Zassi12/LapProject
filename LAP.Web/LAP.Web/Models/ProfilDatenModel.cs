
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace LAP.Web.Models
{
    public class ProfilDatenModel
    {

        //[Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.Username))]
        [StringLength(20)]
        [Editable(false)]
        public string Email { get; set; }

        [StringLength(16, ErrorMessage = "8-16 Zeichen", MinimumLength = 8)]
        [Required(ErrorMessage = "Pflichtfeld", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Passwort { get; set; }

        [Required(ErrorMessage = "Pflichtfeld", AllowEmptyStrings = false)]
        
        public string Vorname { get; set; }

        [Required(ErrorMessage = "Pflichtfeld", AllowEmptyStrings = false)]
        
        public string Nachname { get; set; }

        [Editable(false)]
        public int ID { get; set; }

        public bool Active { get; set; }


    }
}