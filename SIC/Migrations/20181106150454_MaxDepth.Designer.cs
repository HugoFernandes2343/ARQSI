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
    [Migration("20181106150454_MaxDepth")]
    partial class MaxDepth
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SIC.Models.Aggregation", b =>
                {
                    b.Property<int>("AggregationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("containedProductProductId");

                    b.Property<int?>("containingProductProductId");

                    b.HasKey("AggregationId");

                    b.HasIndex("containedProductProductId");

                    b.HasIndex("containingProductProductId");

                    b.ToTable("Aggregation");
                });

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

                    b.Property<double>("depth");

                    b.Property<double>("height");

                    b.Property<double?>("maxDepth");

                    b.Property<double?>("maxHeight");

                    b.Property<double?>("maxWidth");

                    b.Property<double>("width");

                    b.HasKey("DimensionsId");

                    b.HasIndex("ProductId");

                    b.ToTable("Dimensions");
                });

            modelBuilder.Entity("SIC.Models.Finish", b =>
                {
                    b.Property<int>("FinishId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MaterialId");

                    b.Property<string>("name");

                    b.HasKey("FinishId");

                    b.HasIndex("MaterialId");

                    b.ToTable("Finish");
                });

            modelBuilder.Entity("SIC.Models.Material", b =>
                {
                    b.Property<int>("MaterialId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ProductId");

                    b.Property<string>("name");

                    b.HasKey("MaterialId");

                    b.HasIndex("ProductId");

                    b.ToTable("Material");
                });

            modelBuilder.Entity("SIC.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CatalogId");

                    b.Property<int?>("CategoryId");

                    b.Property<string>("name");

                    b.HasKey("ProductId");

                    b.HasIndex("CatalogId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("SIC.Models.Restriction", b =>
                {
                    b.Property<int>("RestrictionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AggregationId");

                    b.HasKey("RestrictionId");

                    b.HasIndex("AggregationId");

                    b.ToTable("Restriction");
                });

            modelBuilder.Entity("SIC.Models.Aggregation", b =>
                {
                    b.HasOne("SIC.Models.Product", "containedProduct")
                        .WithMany()
                        .HasForeignKey("containedProductProductId");

                    b.HasOne("SIC.Models.Product", "containingProduct")
                        .WithMany()
                        .HasForeignKey("containingProductProductId");
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

            modelBuilder.Entity("SIC.Models.Finish", b =>
                {
                    b.HasOne("SIC.Models.Material")
                        .WithMany("finish")
                        .HasForeignKey("MaterialId");
                });

            modelBuilder.Entity("SIC.Models.Material", b =>
                {
                    b.HasOne("SIC.Models.Product")
                        .WithMany("materials")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("SIC.Models.Product", b =>
                {
                    b.HasOne("SIC.Models.Catalog")
                        .WithMany("products")
                        .HasForeignKey("CatalogId");

                    b.HasOne("SIC.Models.Category", "cat")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("SIC.Models.Restriction", b =>
                {
                    b.HasOne("SIC.Models.Aggregation", "aggregation")
                        .WithMany()
                        .HasForeignKey("AggregationId");
                });
#pragma warning restore 612, 618
        }
    }
}
