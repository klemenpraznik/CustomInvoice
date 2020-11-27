using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomInvoice.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomInvoice.WebApp.ViewModels
{
    public class PartnersViewModel
    {
        public List<Partner> PartnerList { get; set; }
    }
}
