using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CMR.Models;
using System.Threading.Tasks;

namespace CMR.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalesOrder>().HasKey(am => new
            {
                am.SalesOrderHeaderId,
                am.CustomerId,
                am.SalesOrderDetailsId,
                am.ProductId
            });

            modelBuilder.Entity<SalesOrder>().HasOne(m => m.Sales_Order_Header).WithMany(am => am.salesOrder).HasForeignKey(
                m => m.SalesOrderHeaderId);
            modelBuilder.Entity<SalesOrder>().HasOne(m => m.Customer).WithMany(am => am.salesOrder).HasForeignKey(
                m => m.CustomerId);
            modelBuilder.Entity<SalesOrder>().HasOne(m => m.Sales_Order_Details).WithMany(am => am.salesOrder).HasForeignKey(
               m => m.SalesOrderDetailsId);
            modelBuilder.Entity<SalesOrder>().HasOne(m => m.Product).WithMany(am => am.salesOrder).HasForeignKey(
                m => m.ProductId);
            base.OnModelCreating(modelBuilder);
        }

        internal Task GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        internal Task GetAll()
        {
            throw new NotImplementedException();
        }

        public DbSet<CMR.Models.Customer> Customer { get; set; }
        public DbSet<CMR.Models.Product> Product { get; set; }
        public DbSet<CMR.Models.SalesOrderBilling> SalesOrderBilling { get; set; }
        public DbSet<CMR.Models.SalesOrderDetails> SalesOrderDetails { get; set; }
        public DbSet<CMR.Models.SalesOrderHeader> SalesOrderHeader { get; set; }
        public DbSet<CMR.Models.SalesOrderShipping> SalesOrderShipping { get; set; }
        public DbSet<CMR.Models.SalesOrder> SalesOrder { get; set; }

        internal Task UpdateAsync(int id, Customer customer)
        {
            throw new NotImplementedException();
        }

        public object CustomerAddress { get; internal set; }

        public DbSet<CMR.Models.CustomerAddress> CustomerAddress_1 { get; set; }
    }
}
