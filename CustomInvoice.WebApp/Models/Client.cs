using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomInvoice.WebApp.Models
{
    public class Client
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [Required(ErrorMessage = "Vnesite ime stranke")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Ime stranke mora biti dolgo med 2 in 50 znakov.")]
        [Display(Name = "Ime in priimek / naziv")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Izberi tip")]
        [Display(Name = "Tip osebe")]
        public string Type { get; set; } //pravna oseba, fizična oseba, s.p.

        [Display(Name = "Matična številka")]
        public string RegistrationNumber { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Vnesite veljaven email.")]
        public string Email { get; set; }

        [Display(Name = "Telefonska številka")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Telefonska številka mora biti dolga med 8 in 20 znakov.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Davčna številka")]
        public string taxNumber { get; set; }

        [Display(Name = "Davčni zavezanec")]
        public bool taxPayer { get; set; }

        [Display(Name = "Ulica")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Ime ulice mora biti dolgo med 5 in 50 znakov.")]
        public string StreetName { get; set; }

        [Display(Name = "Hišna št.")]
        [StringLength(10, ErrorMessage = "Hišna številka je lahko dolga največ 5 znakov")]
        public string StreetNumber { get; set; }

        [Display(Name = "Poštna št.")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Poštna je lahko dolga med 4 in 8 znakov")]
        public string PostNumber { get; set; }

        [Display(Name = "Kraj/mesto")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Ime kraja mora biti dolgo med 3 in 30 znakov.")]
        public string City { get; set; }

        [Display(Name = "Država")]
        public string Country { get; set; }

    }
}
