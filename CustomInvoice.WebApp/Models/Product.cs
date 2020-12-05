using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomInvoice.WebApp.Models
{
    public class Product
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [Required(ErrorMessage = "Vnesite ime izdelka ali storitve")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Ime izdelka oz. storitve mora biti dolgo med 2 in 150 znakov.")]
        [Display(Name = "Naziv izdelka / storitve")]
        public string Name { get; set; }

        [StringLength(15, MinimumLength = 2, ErrorMessage = "Kratko ime izdelka oz. storitve mora biti dolgo med 2 in 15 znakov.")]
        [Display(Name = "Kratek naziv / šifra")]
        public string ShortName { get; set; }

        [StringLength(100, ErrorMessage = "Ime proizvajalca je lahko dolgo največ 100 znakov.")]
        [Display(Name = "Izdelovalec")]
        public string Manufacturer { get; set; }

        public Partner Partner { get; set; }

        [Display(Name = "Dobavitelj / partner")]
        public byte PartnerId { get; set; }

        public Category Category { get; set; }

        [Required(ErrorMessage = "Izberi kategorijo.")]
        [Display(Name = "Kategorija")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Neveljavna vrednost.")]
        [Range(0, 200, ErrorMessage = "Vrednost mora biti med 0 in 200")]
        [Display(Name = "Garancija (v mesecih)")]
        public int WarrantyInMonths { get; set; }

        [Display(Name = "Tip artika")]
        public string Type { get; set; } //artikel ali storitev

        [Required(ErrorMessage = "Izberi enoto mere")]
        [Display(Name = "Enota mere")]
        public string UnitOfMeasure { get; set; } //artikel ali storitev

        [Required(ErrorMessage = "Neveljavna vrednost.")]
        [Display(Name = "Nabavna cena")]
        public double PurchasePrice { get; set; }


        [Required(ErrorMessage = "Neveljavna vrednost.")]
        [Display(Name = "Prodajna cena")]
        public double SellingPrice { get; set; }
    }
}
