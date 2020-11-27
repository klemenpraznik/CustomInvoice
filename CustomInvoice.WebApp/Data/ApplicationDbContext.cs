using System;
using System.Collections.Generic;
using System.Text;
using CustomInvoice.WebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CustomInvoice.WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Partner> Partners { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        
    }

}
