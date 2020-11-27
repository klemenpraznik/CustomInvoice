using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomInvoice.WebApp.Models
{
    public class Partner
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [Required(ErrorMessage = "Vnesite ime partnerja")]
        [Display(Name = "Naziv partnerja")]
        public string Name { get; set; }

        [Display(Name = "Ulica")]
        public string StreetName { get; set; }

        [Display(Name = "Hišna št.")]
        public string StreetNumber { get; set; }

        [Display(Name = "Poštna št.")]
        public string PostNumber { get; set; }

        [Display(Name = "Kraj/mesto")]
        public string City { get; set; }

        [Display(Name = "Država")]
        public string Country { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Vnesite veljaven email.")]
        public string Email { get; set; }

        [Display(Name = "Tel.")]
        public string PhoneNumber { get; set; }
    }
}
