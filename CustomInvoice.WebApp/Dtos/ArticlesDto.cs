using CustomInvoice.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomInvoice.WebApp.Dtos
{
    public class ArticlesDto
    {
        public byte DocumentId { get; set; }
        public List<Article> Articles { get; set; }
    }
}
