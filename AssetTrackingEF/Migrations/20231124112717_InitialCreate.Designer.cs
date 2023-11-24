﻿// <auto-generated />
using System;
using AssertTrackingEF.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AssetTrackingEF.Migrations
{
    [DbContext(typeof(AssetTrackingDbContext))]
    [Migration("20231124112717_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AssertTrackingEF.Data.EF.AssetBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brand");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "HP"
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Apple"
                        },
                        new
                        {
                            Id = 3,
                            Brand = "Lenovo"
                        },
                        new
                        {
                            Id = 4,
                            Brand = "Olivetti"
                        },
                        new
                        {
                            Id = 5,
                            Brand = "Canon"
                        },
                        new
                        {
                            Id = 6,
                            Brand = "Samsung"
                        },
                        new
                        {
                            Id = 7,
                            Brand = "Xiaomi"
                        });
                });

            modelBuilder.Entity("AssertTrackingEF.Data.EF.AssetModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AssetBrandID")
                        .HasColumnType("int");

                    b.Property<int>("AssetTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AssetBrandID");

                    b.HasIndex("AssetTypeID");

                    b.ToTable("Model");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AssetBrandID = 1,
                            AssetTypeID = 1,
                            Model = "Elitebook"
                        },
                        new
                        {
                            Id = 2,
                            AssetBrandID = 2,
                            AssetTypeID = 3,
                            Model = "Iphone"
                        },
                        new
                        {
                            Id = 3,
                            AssetBrandID = 6,
                            AssetTypeID = 3,
                            Model = "Galaxy"
                        },
                        new
                        {
                            Id = 4,
                            AssetBrandID = 3,
                            AssetTypeID = 1,
                            Model = "Yoga"
                        },
                        new
                        {
                            Id = 5,
                            AssetBrandID = 1,
                            AssetTypeID = 1,
                            Model = "Notebook"
                        },
                        new
                        {
                            Id = 6,
                            AssetBrandID = 5,
                            AssetTypeID = 4,
                            Model = "i-SENSYS MF455dw"
                        },
                        new
                        {
                            Id = 7,
                            AssetBrandID = 4,
                            AssetTypeID = 4,
                            Model = "d-Color P3302"
                        },
                        new
                        {
                            Id = 8,
                            AssetBrandID = 2,
                            AssetTypeID = 1,
                            Model = "MacBook"
                        },
                        new
                        {
                            Id = 9,
                            AssetBrandID = 3,
                            AssetTypeID = 2,
                            Model = "Thinkstation"
                        },
                        new
                        {
                            Id = 10,
                            AssetBrandID = 7,
                            AssetTypeID = 3,
                            Model = "MIUI Global"
                        });
                });

            modelBuilder.Entity("AssertTrackingEF.Data.EF.AssetType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Type");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Laptop"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Stationary"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Phone"
                        },
                        new
                        {
                            Id = 4,
                            Type = "Printer"
                        });
                });

            modelBuilder.Entity("AssetTrackingEF.Data.EF.Asset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AssetModelId")
                        .HasColumnType("int");

                    b.Property<int>("OfficeId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AssetModelId");

                    b.HasIndex("OfficeId");

                    b.ToTable("Asset");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AssetModelId = 1,
                            OfficeId = 1,
                            Price = 1000.0,
                            PurchaseDate = new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            AssetModelId = 7,
                            OfficeId = 3,
                            Price = 2500.0,
                            PurchaseDate = new DateTime(2022, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            AssetModelId = 2,
                            OfficeId = 5,
                            Price = 500.0,
                            PurchaseDate = new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            AssetModelId = 9,
                            OfficeId = 2,
                            Price = 400.0,
                            PurchaseDate = new DateTime(2021, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            AssetModelId = 4,
                            OfficeId = 2,
                            Price = 350.0,
                            PurchaseDate = new DateTime(2023, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            AssetModelId = 8,
                            OfficeId = 4,
                            Price = 850.0,
                            PurchaseDate = new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 7,
                            AssetModelId = 2,
                            OfficeId = 1,
                            Price = 550.0,
                            PurchaseDate = new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 8,
                            AssetModelId = 6,
                            OfficeId = 5,
                            Price = 2250.0,
                            PurchaseDate = new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 9,
                            AssetModelId = 3,
                            OfficeId = 4,
                            Price = 355.0,
                            PurchaseDate = new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 10,
                            AssetModelId = 10,
                            OfficeId = 3,
                            Price = 355.0,
                            PurchaseDate = new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("AssetTrackingEF.Data.EF.Office", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Office");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Country = "USA",
                            Currency = "USD"
                        },
                        new
                        {
                            Id = 2,
                            Country = "England",
                            Currency = "GBP"
                        },
                        new
                        {
                            Id = 3,
                            Country = "Italy",
                            Currency = "EUR"
                        },
                        new
                        {
                            Id = 4,
                            Country = "Sweden",
                            Currency = "SEK"
                        },
                        new
                        {
                            Id = 5,
                            Country = "Schweiz",
                            Currency = "CHF"
                        });
                });

            modelBuilder.Entity("AssertTrackingEF.Data.EF.AssetModel", b =>
                {
                    b.HasOne("AssertTrackingEF.Data.EF.AssetBrand", "AssetBrand")
                        .WithMany("Model")
                        .HasForeignKey("AssetBrandID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssertTrackingEF.Data.EF.AssetType", "AssetType")
                        .WithMany("AssetModel")
                        .HasForeignKey("AssetTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssetBrand");

                    b.Navigation("AssetType");
                });

            modelBuilder.Entity("AssetTrackingEF.Data.EF.Asset", b =>
                {
                    b.HasOne("AssertTrackingEF.Data.EF.AssetModel", "AssetModel")
                        .WithMany("Assets")
                        .HasForeignKey("AssetModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssetTrackingEF.Data.EF.Office", "Office")
                        .WithMany()
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssetModel");

                    b.Navigation("Office");
                });

            modelBuilder.Entity("AssertTrackingEF.Data.EF.AssetBrand", b =>
                {
                    b.Navigation("Model");
                });

            modelBuilder.Entity("AssertTrackingEF.Data.EF.AssetModel", b =>
                {
                    b.Navigation("Assets");
                });

            modelBuilder.Entity("AssertTrackingEF.Data.EF.AssetType", b =>
                {
                    b.Navigation("AssetModel");
                });
#pragma warning restore 612, 618
        }
    }
}
