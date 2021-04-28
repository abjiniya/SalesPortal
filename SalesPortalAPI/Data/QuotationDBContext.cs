using Microsoft.EntityFrameworkCore;
using SalesPortalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPortalAPI.Data
{
    public class QuotationDBContext : DbContext
    {
        public QuotationDBContext(DbContextOptions<QuotationDBContext> options) : base(options)
        {
        }

        public DbSet<Quotation> Quotations { get;set;}
}

   
}


