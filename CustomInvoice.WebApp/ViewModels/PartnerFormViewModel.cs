using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CustomInvoice.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomInvoice.WebApp.ViewModels
{
    public class PartnerFormViewModel
    {
        [Key]
        public int Id { get; set; }
        public Partner Partner { get; set; }
    }
}
