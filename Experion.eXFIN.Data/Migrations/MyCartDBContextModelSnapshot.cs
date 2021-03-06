﻿// <auto-generated />
using System;
using Experion.MyCart.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Experion.MyCart.Data.Migrations
{
    [DbContext(typeof(MyCartDBContext))]
    partial class MyCartDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Experion.MyCart.Data.Entities.Catogory", b =>
                {
                    b.Property<int>("CatogoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Catogories")
                        .IsRequired()
                        .HasColumnName("Catogory")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("CatogoryId");

                    b.ToTable("Catogory");

                    b.HasData(
                        new
                        {
                            CatogoryId = 1,
                            Catogories = "Electronics"
                        },
                        new
                        {
                            CatogoryId = 2,
                            Catogories = "Footwares"
                        },
                        new
                        {
                            CatogoryId = 3,
                            Catogories = "Cloths"
                        },
                        new
                        {
                            CatogoryId = 4,
                            Catogories = "Books"
                        },
                        new
                        {
                            CatogoryId = 5,
                            Catogories = "Gift Items"
                        });
                });

            modelBuilder.Entity("Experion.MyCart.Data.Entities.ProductCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CartProductId")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("ProductCount")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("ProductCart");
                });

            modelBuilder.Entity("Experion.MyCart.Data.Entities.ProductOrders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Add1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Add2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dob")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FName")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("LName")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Terms")
                        .HasColumnType("bit");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int")
                        .HasMaxLength(10);

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProductOrders");
                });

            modelBuilder.Entity("Experion.MyCart.Data.Entities.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CatogoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<bool?>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LaunchDate")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("PhotoUrl")
                        .HasColumnName("Photo_Url")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CatogoryId = 1,
                            Description = "Best mobiles under 50000",
                            IsAvailable = true,
                            IsDeleted = false,
                            LaunchDate = "2020-04-07",
                            PhotoUrl = "assets/1.jpg",
                            Price = 44000.0,
                            ProductId = "mobile1",
                            ProductName = "OnePlus 7 Pro"
                        },
                        new
                        {
                            Id = 2,
                            CatogoryId = 1,
                            Description = "Best mobiles under 50000",
                            IsAvailable = true,
                            IsDeleted = false,
                            LaunchDate = "2020-04-07",
                            PhotoUrl = "assets/2.jpg",
                            Price = 44000.0,
                            ProductId = "mobile2",
                            ProductName = "OnePlus 7 Pro"
                        },
                        new
                        {
                            Id = 3,
                            CatogoryId = 1,
                            Description = "Best mobiles under 50000",
                            IsAvailable = true,
                            IsDeleted = false,
                            LaunchDate = "2020-04-07",
                            PhotoUrl = "assets/3.jpg",
                            Price = 44000.0,
                            ProductId = "mobile3",
                            ProductName = "OnePlus 7 Pro"
                        },
                        new
                        {
                            Id = 4,
                            CatogoryId = 1,
                            Description = "Best mobiles under 50000",
                            IsAvailable = true,
                            IsDeleted = false,
                            LaunchDate = "2020-04-07",
                            PhotoUrl = "assets/4.jpg",
                            Price = 44000.0,
                            ProductId = "mobile4",
                            ProductName = "OnePlus 7 Pro"
                        },
                        new
                        {
                            Id = 5,
                            CatogoryId = 1,
                            Description = "Best mobiles under 50000",
                            IsAvailable = true,
                            IsDeleted = false,
                            LaunchDate = "2020-04-07",
                            PhotoUrl = "assets/5.jpg",
                            Price = 44000.0,
                            ProductId = "mobile5",
                            ProductName = "OnePlus 7 Pro"
                        },
                        new
                        {
                            Id = 6,
                            CatogoryId = 1,
                            Description = "Best mobiles under 50000",
                            IsAvailable = true,
                            IsDeleted = false,
                            LaunchDate = "2020-04-07",
                            PhotoUrl = "assets/6.jpg",
                            Price = 44000.0,
                            ProductId = "mobile6",
                            ProductName = "OnePlus 7 Pro"
                        },
                        new
                        {
                            Id = 7,
                            CatogoryId = 1,
                            Description = "Best mobiles under 50000",
                            IsAvailable = true,
                            IsDeleted = false,
                            LaunchDate = "2020-04-07",
                            PhotoUrl = "assets/7.jpg",
                            Price = 44000.0,
                            ProductId = "mobile7",
                            ProductName = "OnePlus 7 Pro"
                        },
                        new
                        {
                            Id = 8,
                            CatogoryId = 1,
                            Description = "Best mobiles under 50000",
                            IsAvailable = true,
                            IsDeleted = false,
                            LaunchDate = "2020-04-07",
                            PhotoUrl = "assets/8.jpg",
                            Price = 44000.0,
                            ProductId = "mobile8",
                            ProductName = "OnePlus 7 Pro"
                        });
                });

            modelBuilder.Entity("Experion.MyCart.Data.Entities.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnName("F_Name")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsPremium")
                        .HasColumnType("bit");

                    b.Property<string>("LName")
                        .HasColumnName("L_Name")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("MobileNo")
                        .HasColumnType("nchar(20)")
                        .IsFixedLength(true)
                        .HasMaxLength(20);

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
