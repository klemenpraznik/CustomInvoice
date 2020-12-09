using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomInvoice.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomInvoice.WebApp.ViewModels
{
    public class DocumentDetailsModel
    {
        public Document Document { get; set; }
        public List<Client> ClientsList { get; set; }
        public List<Article> ArticlesList { get; set; }
    }
}
