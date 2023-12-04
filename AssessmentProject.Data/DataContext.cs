using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssessmentProject.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace AssessmentProject.Data
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("exampleDatabase");
        }

        public DbSet<UserRepository> Users { get; set; }
        public DbSet<InvoiceRepository> Invoices { get; set; }
        public DbSet<StoreRepository> Stores { get; set; }
        public DbSet<DiscountRepository> Discounts { get; set; }
    }
}
