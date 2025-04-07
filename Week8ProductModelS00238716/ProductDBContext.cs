
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductModel.CSVMapping;

namespace ProductModel
{
    public class ProductDBContext : DbContext
    {
         public DbSet<Product> Products { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<GRN> GRNs { get; set; }
        public DbSet<GrnLine> GRNLines { get; set; }


        static public bool inProduction;
        public ProductDBContext()
        {
            
        }
        public ProductDBContext(DbContextOptions<ProductDBContext> options)
            : base(options)
        {
            // Ensure Migrations are updated before seeding or using this context
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var myconnectionstring = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Week8ProductCoreDB-2025-S00238716";
            optionsBuilder.UseSqlServer(myconnectionstring)
              .LogTo(Console.WriteLine,
                     new[] { DbLoggerCategory.Database.Command.Name },
                     LogLevel.Information);
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // NOTE: this line is activated from the bin folder whihc is a sub
            // folder of the class library project
            // You must build the project before calling Add-migration
            if (!inProduction)
            {
                Product[] products = DBHelper.Get<Product>(@"..\Week8ProductModelS00238716\Products.csv").ToArray();
                modelBuilder.Entity<Product>().HasData(products);

                GRN[] grns = DBHelper.GetFile<GRN, GrnMap>(@"..\Week8ProductModelS00238716\GRNs.csv").ToArray();
                modelBuilder.Entity<GRN>().HasData(grns);

                GrnLine[] grnLines = DBHelper.GetFile<GrnLine, GrnLineMap>(@"..\Week8ProductModelS00238716\GRNlines.csv").ToArray();
                modelBuilder.Entity<GrnLine>().HasData(grnLines);
            }
            //modelBuilder.Entity<Product>().HasData(
            // new Product
            // {
            //     ID = 46,
            //     Description = "test",
            //     ReorderLevel = 4,
            //     ReorderQuantity = 2,
            //     StockOnHand = 30,
            //     UnitPrice = 10
            // });
            //

            base.OnModelCreating(modelBuilder);
        }


    }
}


