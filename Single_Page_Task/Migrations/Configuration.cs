namespace Single_Page_Task.Migrations
{
    using Single_Page_Task.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Single_Page_Task.Models.EF.SPTContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        //protected override void Seed(Single_Page_Task.Models.EF.SPTContext context)
        //{
        //    //  This method will be called after migrating to the latest version.

        //    //  You can use the DbSet<T>.AddOrUpdate() helper extension method
        //    //  to avoid creating duplicate seed data.

        //    var customers = new List<Customer>
        //{
        //    new Customer { CustomerName = "John Doe", Type = "Individual"},
        //    new Customer { CustomerName = "Nazmul Hasan", Type = "Corporate"},
        //    new Customer { CustomerName = "Jane Doe", Type = "Individual"},
        //    new Customer { CustomerName = "Tasrif Ahmed", Type = "Corporate"}
        //};

        //    context.Customers.AddRange(customers);
        //    context.SaveChanges();

        //    var ProductsServices = new List<ProductService>
        //    {
        //        new ProductService { Name = "Product A", Unit = "Unit A" },
        //        new ProductService { Name = "Product B", Unit = "Unit B" },
        //        new ProductService { Name = "Product C", Unit = "Unit C" }
        //    };

        //    context.ProductsServices.AddRange(ProductsServices);
        //    context.SaveChanges();
        //}
    }
}
