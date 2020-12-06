using System;
using System.Collections.Generic;
using System.Text;
using CustomInvoice.WebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CustomInvoice.WebApp.ViewModels;

namespace CustomInvoice.WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<CustomInvoice.WebApp.ViewModels.PartnerFormViewModel> PartnerFormViewModel { get; set; }
        
    }

}
