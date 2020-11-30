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
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Ime partnerja mora biti dolgo med 2 in 150 znakov.")]
        [Display(Name = "Naziv partnerja")]
        public string Name { get; set; }

        [Display(Name = "Ulica")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Ime ulice mora biti dolgo med 5 in 50 znakov.")]
        public string StreetName { get; set; }

        [Display(Name = "Hišna št.")]
        [StringLength(5, ErrorMessage = "Hišna številka je lahko dolga največ 5 znakov")]
        public string StreetNumber { get; set; }

        [Display(Name = "Poštna št.")]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Poštna je lahko dolga med 4 in 8 znakov")]
        public string PostNumber { get; set; }

        [Display(Name = "Kraj/mesto")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Ime kraja mora biti dolgo med 3 in 30 znakov.")]
        public string City { get; set; }

        [Display(Name = "Država")]
        public string Country { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Vnesite veljaven email.")]
        public string Email { get; set; }

        [Display(Name = "Telefonska številka")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Telefonska številka mora biti dolga med 8 in 20 znakov.")]
        public string PhoneNumber { get; set; }
    }
}
