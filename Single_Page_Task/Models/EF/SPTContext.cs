using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Single_Page_Task.Models.EF
{
    public class SPTContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProductService> ProductsServices { get; set; }
        public DbSet<MeetingMinutesMaster> MeetingMinutesMasters { get; set; }
        public DbSet<MeetingMinutesDetail> MeetingMinutesDetails { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<MeetingMinutesMaster>()
        //        .HasMany(m => m.MeetingMinutesDetails)
        //        .WithRequired(md => md.MeetingMinutesMaster)
        //        .HasForeignKey(md => md.MeetingMinutesMasterId);

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}