using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomInvoice.WebApp.Models
{
    public class Category
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [Required(ErrorMessage = "Vnesite ime kategorija")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Ime kategorije mora biti dolgo med 5 in 50 znakov.")]
        [Display(Name = "Naziv kategorije")]
        public string Name { get; set; }

        [Display(Name = "Opis kategorije")]
        public string Description { get; set; }
    }
}
