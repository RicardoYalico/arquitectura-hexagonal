using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using My_API.Domain.Entities;

namespace My_API.Infrastructure.DataSource.Context
{
    public class AppDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) {}


   //     protected override void OnConfiguring(DbContextOptionsBuilder options) 
   //     { 
   ////options.UseSqlServer("Server=tcp:serverappventa.database.windows.net,1433;Initial Catalog=app-venta;Persist Security Info=False;User ID=adminappventa;Password=Channel321*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
   //     }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Users
            builder.Entity<User>().ToTable("user");
            builder.Entity<User>().Property(u => u.Name).IsRequired().HasMaxLength(50);
            builder.Entity<User>().HasKey(u => u.UserID);

            //Order
            builder.Entity<Order>().ToTable("order");
            builder.Entity<Order>().HasKey(p => p.OrderId);
            builder.Entity<Order>().HasOne(p => p.User).WithMany(u => u.Orders).HasForeignKey(u => u.UserId).IsRequired();

            //OrderDetail
            builder.Entity<OrderDetail>().ToTable("order_detail");
            builder.Entity<OrderDetail>().HasKey(p => p.OrderId);
            builder.Entity<OrderDetail>().HasOne(p => p.Product).WithOne(u => u.OrderDetail).HasForeignKey<OrderDetail>(u => u.ProductId).IsRequired();

            //Product
            builder.Entity<Product>().ToTable("product");
            builder.Entity<Product>().HasKey(p => p.ProductId);
            builder.Entity<Product>().HasOne(p => p.OrderDetail).WithOne(u => u.Product).HasForeignKey<Product>(u => u.OrderDetailID).IsRequired();

            //builder.Entity<User>().Property(u => u.UserID).IsRequired().ValueGeneratedOnAdd();

            //var user = new User()
            //{
            //    Name = "admin",
            //    UserID = 1
            //};

            //builder.Entity<User>().HasData(user);
        }
    }
}
