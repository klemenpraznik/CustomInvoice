using CustomInvoice.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomInvoice.WebApp.Dtos
{
    public class DocumentDto
    {
        public byte DocumentId { get; set; }
        public Document Document { get; set; }
    }
}
