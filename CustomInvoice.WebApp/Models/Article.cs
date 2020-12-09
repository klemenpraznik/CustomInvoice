using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustomInvoice.WebApp.Models
{
    public class Article
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArticleId { get; set; }

        public Document Document { get; set; }
        public byte DocumentId { get; set; }
        public Product Product { get; set; }
        public byte ProductId { get; set; }

        public double Quantity { get; set; }
        public decimal Price { get; set; } //product.sellingPrice * Quantity
        public decimal Discount { get; set; }
        public decimal TaxRate { get; set; }
    }
}
