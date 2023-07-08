using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVCFrameworkHandShake.Models;

namespace MVCFrameworkHandShake.Context
{
    public class NorthwindContext : DbContext
    {
        //NorthwindEntities
        public NorthwindContext() : base("NorthWind") { }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Supplier> Suppliers { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasRequired(d => d.Category).WithMany(p => p.Products).Map(m => m.MapKey("FK_Products_Categories"));
            modelBuilder.Entity<Product>()
                .HasRequired(d => d.Supplier).WithMany(p => p.Products).Map(m => m.MapKey("FK_Products_Suppliers"));
        }
    }
}