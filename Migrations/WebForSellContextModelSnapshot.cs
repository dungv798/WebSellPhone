﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebForSell.Data;

#nullable disable

namespace WebForSell.Migrations
{
    [DbContext(typeof(WebForSellContext))]
    partial class WebForSellContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebForSell.Models.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrandId"), 1L, 1);

                    b.Property<string>("BrandDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("BrandOrder")
                        .HasColumnType("int");

                    b.HasKey("BrandId");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("WebForSell.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("WebForSell.Models.Dofweek", b =>
                {
                    b.Property<int>("DofweekId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DofweekId"), 1L, 1);

                    b.Property<string>("DofweekDescription")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("DofweekImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DofweekName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("DofweekPrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<bool?>("isDoTW")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.HasKey("DofweekId");

                    b.ToTable("Dofweek");
                });

            modelBuilder.Entity("WebForSell.Models.HomeProduct", b =>
                {
                    b.Property<int>("HomeProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HomeProductId"), 1L, 1);

                    b.Property<int>("DofweekId")
                        .HasColumnType("int");

                    b.Property<string>("HomeProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("LastestProductId")
                        .HasColumnType("int");

                    b.Property<int>("NewArrId")
                        .HasColumnType("int");

                    b.Property<int>("OnSaleId")
                        .HasColumnType("int");

                    b.Property<int>("TopSellId")
                        .HasColumnType("int");

                    b.HasKey("HomeProductId");

                    b.HasIndex("DofweekId");

                    b.HasIndex("LastestProductId");

                    b.HasIndex("NewArrId");

                    b.HasIndex("OnSaleId");

                    b.HasIndex("TopSellId");

                    b.ToTable("HomeProduct");
                });

            modelBuilder.Entity("WebForSell.Models.LastestProduct", b =>
                {
                    b.Property<int>("LastestProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LastestProductId"), 1L, 1);

                    b.Property<string>("LastestProductImage")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("LastestProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("LastestProductPrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<bool?>("isLasted")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.HasKey("LastestProductId");

                    b.ToTable("LastestProduct");
                });

            modelBuilder.Entity("WebForSell.Models.NewArr", b =>
                {
                    b.Property<int>("NewArrId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NewArrId"), 1L, 1);

                    b.Property<string>("NewArrImage")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("NewArrName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("NewArrPrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<bool?>("isArr")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.HasKey("NewArrId");

                    b.ToTable("NewArr");
                });

            modelBuilder.Entity("WebForSell.Models.OnSale", b =>
                {
                    b.Property<int>("OnSaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OnSaleId"), 1L, 1);

                    b.Property<string>("OnSaleImage")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("OnSaleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("OnSalePrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<bool?>("isOnSale")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.HasKey("OnSaleId");

                    b.ToTable("OnSale");
                });

            modelBuilder.Entity("WebForSell.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("DofweekId")
                        .HasColumnType("int");

                    b.Property<int?>("LastestProductId")
                        .HasColumnType("int");

                    b.Property<int?>("NewArrId")
                        .HasColumnType("int");

                    b.Property<int?>("OnSaleId")
                        .HasColumnType("int");

                    b.Property<string>("ProductDescription")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ProductImage")
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductImage2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("ProductPrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int");

                    b.Property<int?>("TopSellId")
                        .HasColumnType("int");

                    b.Property<bool>("isArr")
                        .HasColumnType("bit");

                    b.Property<bool>("isDoTW")
                        .HasColumnType("bit");

                    b.Property<bool>("isLasted")
                        .HasColumnType("bit");

                    b.Property<bool>("isOnSale")
                        .HasColumnType("bit");

                    b.Property<bool>("isTop")
                        .HasColumnType("bit");

                    b.HasKey("ProductId");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DofweekId");

                    b.HasIndex("LastestProductId");

                    b.HasIndex("NewArrId");

                    b.HasIndex("OnSaleId");

                    b.HasIndex("TopSellId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("WebForSell.Models.TopSell", b =>
                {
                    b.Property<int>("TopSellId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TopSellId"), 1L, 1);

                    b.Property<string>("TopSellImage")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("TopSellName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("TopSellPrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<bool?>("isTop")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.HasKey("TopSellId");

                    b.ToTable("TopSell");
                });

            modelBuilder.Entity("WebForSell.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("WebForSell.Models.HomeProduct", b =>
                {
                    b.HasOne("WebForSell.Models.Dofweek", "Dofweek")
                        .WithMany("HomeProducts")
                        .HasForeignKey("DofweekId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebForSell.Models.LastestProduct", "LastestProduct")
                        .WithMany("HomeProducts")
                        .HasForeignKey("LastestProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebForSell.Models.NewArr", "NewArr")
                        .WithMany("HomeProducts")
                        .HasForeignKey("NewArrId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebForSell.Models.OnSale", "OnSale")
                        .WithMany("HomeProducts")
                        .HasForeignKey("OnSaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebForSell.Models.TopSell", "TopSell")
                        .WithMany("HomeProducts")
                        .HasForeignKey("TopSellId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dofweek");

                    b.Navigation("LastestProduct");

                    b.Navigation("NewArr");

                    b.Navigation("OnSale");

                    b.Navigation("TopSell");
                });

            modelBuilder.Entity("WebForSell.Models.Product", b =>
                {
                    b.HasOne("WebForSell.Models.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebForSell.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebForSell.Models.Dofweek", "Dofweek")
                        .WithMany("Products")
                        .HasForeignKey("DofweekId");

                    b.HasOne("WebForSell.Models.LastestProduct", "LastestProduct")
                        .WithMany("Products")
                        .HasForeignKey("LastestProductId");

                    b.HasOne("WebForSell.Models.NewArr", "NewArr")
                        .WithMany("Products")
                        .HasForeignKey("NewArrId");

                    b.HasOne("WebForSell.Models.OnSale", "OnSale")
                        .WithMany("Products")
                        .HasForeignKey("OnSaleId");

                    b.HasOne("WebForSell.Models.TopSell", "TopSell")
                        .WithMany("Products")
                        .HasForeignKey("TopSellId");

                    b.Navigation("Brand");

                    b.Navigation("Category");

                    b.Navigation("Dofweek");

                    b.Navigation("LastestProduct");

                    b.Navigation("NewArr");

                    b.Navigation("OnSale");

                    b.Navigation("TopSell");
                });

            modelBuilder.Entity("WebForSell.Models.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("WebForSell.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("WebForSell.Models.Dofweek", b =>
                {
                    b.Navigation("HomeProducts");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("WebForSell.Models.LastestProduct", b =>
                {
                    b.Navigation("HomeProducts");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("WebForSell.Models.NewArr", b =>
                {
                    b.Navigation("HomeProducts");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("WebForSell.Models.OnSale", b =>
                {
                    b.Navigation("HomeProducts");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("WebForSell.Models.TopSell", b =>
                {
                    b.Navigation("HomeProducts");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
