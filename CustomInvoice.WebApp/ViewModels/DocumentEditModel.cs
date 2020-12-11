using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomInvoice.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomInvoice.WebApp.ViewModels
{
    public class DocumentEditModel
    {
        public Document Document { get; set; } // dejanski dokument brez postavk
        public List<Client> ClientsList { get; set; } // seznam strank za v dropdown
        public List<Article> ArticlesList { get; set; } // seznam postavk 
        public List<Product> ProductList { get; set; } //seznam vseh izdelkov
    }
}
