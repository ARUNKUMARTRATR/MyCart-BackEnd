﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Experion.MyCart.Data.Entities
{
    public partial class MyCartDBContext : DbContext
    {
        public MyCartDBContext()
        {
        }

        public MyCartDBContext(DbContextOptions<MyCartDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Catogory> Catogory { get; set; }
        public virtual DbSet<ProductCart> ProductCart { get; set; }
        public virtual DbSet<ProductOrders> ProductOrders { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Users> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catogory>(entity =>
            {
                entity.Property(e => e.CatogoryId).ValueGeneratedOnAdd();

                entity.Property(e => e.Catogories)
                    .IsRequired()
                    .HasColumnName("Catogory")
                    .HasMaxLength(50);
                entity.HasData(
                    new Catogory
                    {
                        CatogoryId = 1,
                        Catogories = "electronics"
                    }
                    );
            });

            modelBuilder.Entity<ProductCart>(entity =>
            {

                entity.HasIndex(e => e.UserId);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CartProductId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.ProductCart)
                    .HasForeignKey<ProductCart>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductCart_Products");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProductCart)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductCart_Users");
            });

            modelBuilder.Entity<ProductOrders>(entity =>
            {
                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.LaunchDate).HasMaxLength(20);

                entity.Property(e => e.PhotoUrl)
                    .HasColumnName("Photo_Url")
                    .HasMaxLength(100);

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Catogory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CatogoryId)
                    .HasConstraintName("FK_Products_Catogory");
                entity.HasData(
                       new Products
                       {
                           Id = 1,
                           ProductId = "mobile1",
                           ProductName = "OnePlus 7 Pro",
                           Description = "Best mobiles under 50000",
                           PhotoUrl = "assets/1.jpg",
                           Price = 44000,
                           LaunchDate = "2020-04-07",
                           IsAvailable = true,
                           IsDeleted = false,
                           CatogoryId = 1

                       },
                       new Products
                       {
                           Id = 2,

                           ProductId = "mobile2",
                           ProductName = "OnePlus 7 Pro",
                           Description = "Best mobiles under 50000",
                           PhotoUrl = "assets/2.jpg",
                           Price = 44000,
                           LaunchDate = "2020-04-07",
                           IsAvailable = true,
                           IsDeleted = false,
                           CatogoryId = 1

                       },
                       new Products
                       {
                           Id = 3,

                           ProductId = "mobile3",
                           ProductName = "OnePlus 7 Pro",
                           Description = "Best mobiles under 50000",
                           PhotoUrl = "assets/3.jpg",
                           Price = 44000,
                           LaunchDate = "2020-04-07",
                           IsAvailable = true,
                           IsDeleted = false,
                           CatogoryId = 1

                       },
                       new Products
                       {
                           Id = 4,

                           ProductId = "mobile4",
                           ProductName = "OnePlus 7 Pro",
                           Description = "Best mobiles under 50000",
                           PhotoUrl = "assets/4.jpg",
                           Price = 44000,
                           LaunchDate = "2020-04-07",
                           IsAvailable = true,
                           IsDeleted = false,
                           CatogoryId = 1

                       },
                       new Products
                       {
                           Id = 5,

                           ProductId = "mobile5",
                           ProductName = "OnePlus 7 Pro",
                           Description = "Best mobiles under 50000",
                           PhotoUrl = "assets/5.jpg",
                           Price = 44000,
                           LaunchDate = "2020-04-07",
                           IsAvailable = true,
                           IsDeleted = false,
                           CatogoryId = 1

                       },
                       new Products
                       {
                           Id = 6,

                           ProductId = "mobile6",
                           ProductName = "OnePlus 7 Pro",
                           Description = "Best mobiles under 50000",
                           PhotoUrl = "assets/6.jpg",
                           Price = 44000,
                           LaunchDate = "2020-04-07",
                           IsAvailable = true,
                           IsDeleted = false,
                           CatogoryId = 1

                       },
                       new Products
                       {
                           Id = 7,
                           ProductId = "mobile7",
                           ProductName = "OnePlus 7 Pro",
                           Description = "Best mobiles under 50000",
                           PhotoUrl = "assets/7.jpg",
                           Price = 44000,
                           LaunchDate = "2020-04-07",
                           IsAvailable = true,
                           IsDeleted = false,
                           CatogoryId = 1

                       },
                       new Products
                       {
                           Id = 8,
                           ProductId = "mobile8",
                           ProductName = "OnePlus 7 Pro",
                           Description = "Best mobiles under 50000",
                           PhotoUrl = "assets/8.jpg",
                           Price = 44000,
                           LaunchDate = "2020-04-07",
                           IsAvailable = true,
                           IsDeleted = false,
                           CatogoryId = 1
                       }

               );
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FName)
                    .IsRequired()
                    .HasColumnName("F_Name")
                    .HasMaxLength(20);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LName)
                    .HasColumnName("L_Name")
                    .HasMaxLength(20);

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.PhotoUrl).HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
