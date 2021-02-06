﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SIC.Models;

namespace SIC.Migrations
{
    [DbContext(typeof(SICContext))]
    [Migration("20181012092011_ProductHasDimensionLists")]
    partial class ProductHasDimensionLists
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SIC.Models.Catalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Catalog");
                });

            modelBuilder.Entity("SIC.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("fatherCatCategoryId");

                    b.Property<string>("name");

                    b.HasKey("CategoryId");

                    b.HasIndex("fatherCatCategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("SIC.Models.Dimensions", b =>
                {
                    b.Property<int>("DimensionsId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ProductId");

                    b.Property<int>("depth");

                    b.Property<int>("height");

                    b.Property<int>("width");

                    b.HasKey("DimensionsId");

                    b.HasIndex("ProductId");

                    b.ToTable("Dimensions");
                });

            modelBuilder.Entity("SIC.Models.Finish", b =>
                {
                    b.Property<int>("FinishId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name");

                    b.HasKey("FinishId");

                    b.ToTable("Finish");
                });

            modelBuilder.Entity("SIC.Models.Material", b =>
                {
                    b.Property<int>("MaterialId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FinishId");

                    b.Property<string>("name");

                    b.HasKey("MaterialId");

                    b.HasIndex("FinishId");

                    b.ToTable("Material");
                });

            modelBuilder.Entity("SIC.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CatalogId");

                    b.Property<int?>("CategoryId");

                    b.Property<int?>("MaterialId");

                    b.Property<int?>("ProductId1");

                    b.Property<string>("name");

                    b.HasKey("ProductId");

                    b.HasIndex("CatalogId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("MaterialId");

                    b.HasIndex("ProductId1");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("SIC.Models.Restriction", b =>
                {
                    b.Property<int>("RestrictionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("containedProductProductId");

                    b.Property<int?>("containingProductProductId");

                    b.HasKey("RestrictionId");

                    b.HasIndex("containedProductProductId");

                    b.HasIndex("containingProductProductId");

                    b.ToTable("Restriction");
                });

            modelBuilder.Entity("SIC.Models.Category", b =>
                {
                    b.HasOne("SIC.Models.Category", "fatherCat")
                        .WithMany()
                        .HasForeignKey("fatherCatCategoryId");
                });

            modelBuilder.Entity("SIC.Models.Dimensions", b =>
                {
                    b.HasOne("SIC.Models.Product")
                        .WithMany("dimensions")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("SIC.Models.Material", b =>
                {
                    b.HasOne("SIC.Models.Finish", "finish")
                        .WithMany()
                        .HasForeignKey("FinishId");
                });

            modelBuilder.Entity("SIC.Models.Product", b =>
                {
                    b.HasOne("SIC.Models.Catalog")
                        .WithMany("products")
                        .HasForeignKey("CatalogId");

                    b.HasOne("SIC.Models.Category", "cat")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("SIC.Models.Material", "material")
                        .WithMany()
                        .HasForeignKey("MaterialId");

                    b.HasOne("SIC.Models.Product")
                        .WithMany("listOfProducts")
                        .HasForeignKey("ProductId1");
                });

            modelBuilder.Entity("SIC.Models.Restriction", b =>
                {
                    b.HasOne("SIC.Models.Product", "containedProduct")
                        .WithMany()
                        .HasForeignKey("containedProductProductId");

                    b.HasOne("SIC.Models.Product", "containingProduct")
                        .WithMany()
                        .HasForeignKey("containingProductProductId");
                });
#pragma warning restore 612, 618
        }
    }
}
