using CustomInvoice.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomInvoice.WebApp.ViewModels
{
    public class ProductFormViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Category> CategoriesList { get; set; }
        public IEnumerable<Partner> PartnersList { get; set; }
    }
}
