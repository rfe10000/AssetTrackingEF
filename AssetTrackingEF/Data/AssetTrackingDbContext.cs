using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssertTrackingEF.Data;
using AssertTrackingEF.Data.EF;
using AssetTrackingEF.Data;
using AssetTrackingEF.Data.EF;
using Microsoft.EntityFrameworkCore;

namespace AssertTrackingEF.Data
{
    internal class AssetTrackingDbContext : DbContext
    {

        string connectionString = @"Data Source=DESKTOP-U83N4J9\MSSQLSERVER2022;Initial Catalog=AssetTracking;
                                          Integrated Security=True";

        public DbSet<AssetBrand>? Brand { get; set; }
        public DbSet<AssetType>? Type { get; set; }
        public new DbSet<AssetModel>? Model { get; set; }
        public DbSet<Office>? Office { get; set; }
        public DbSet<Asset>? Asset { get; set; }
        public DbSet<ReportGroupTotal>? ReportGroup {  get; set; }
        public DbSet<ReportOffice>? ReportOffice { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // We tell the app to use the connectionstring.
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            //No tale needs to be created for reprting purposes
            ModelBuilder.Entity<ReportGroupTotal>().ToTable("ReportGroup", t => t.ExcludeFromMigrations());
            ModelBuilder.Entity<ReportOffice>().ToTable("ReportOffice", t => t.ExcludeFromMigrations());


            ModelBuilder.Entity<AssetBrand>().HasData(new AssetBrand { Id = 1, Brand = "HP" });
            ModelBuilder.Entity<AssetBrand>().HasData(new AssetBrand { Id = 2, Brand = "Apple" });
            ModelBuilder.Entity<AssetBrand>().HasData(new AssetBrand { Id = 3, Brand = "Lenovo" });
            ModelBuilder.Entity<AssetBrand>().HasData(new AssetBrand { Id = 4, Brand = "Olivetti" });
            ModelBuilder.Entity<AssetBrand>().HasData(new AssetBrand { Id = 5, Brand = "Canon" });
            ModelBuilder.Entity<AssetBrand>().HasData(new AssetBrand { Id = 6, Brand = "Samsung" });
            ModelBuilder.Entity<AssetBrand>().HasData(new AssetBrand { Id = 7, Brand = "Xiaomi" });

            ModelBuilder.Entity<AssetType>().HasData(new AssetType { Id = 1, Type = "Laptop" });
            ModelBuilder.Entity<AssetType>().HasData(new AssetType { Id = 2, Type = "Stationary" });
            ModelBuilder.Entity<AssetType>().HasData(new AssetType { Id = 3, Type = "Phone" });
            ModelBuilder.Entity<AssetType>().HasData(new AssetType { Id = 4, Type = "Printer" });

            ModelBuilder.Entity<AssetModel>().HasData(new AssetModel { Id = 1, Model = "Elitebook", AssetTypeID = 1, AssetBrandID = 1 });
            ModelBuilder.Entity<AssetModel>().HasData(new AssetModel { Id = 2, Model = "Iphone", AssetTypeID = 3, AssetBrandID = 2 });
            ModelBuilder.Entity<AssetModel>().HasData(new AssetModel { Id = 3, Model = "Galaxy", AssetTypeID = 3, AssetBrandID = 6 });
            ModelBuilder.Entity<AssetModel>().HasData(new AssetModel { Id = 4, Model = "Yoga", AssetTypeID = 1, AssetBrandID = 3 });
            ModelBuilder.Entity<AssetModel>().HasData(new AssetModel { Id = 5, Model = "Notebook", AssetTypeID = 1, AssetBrandID = 1 });
            ModelBuilder.Entity<AssetModel>().HasData(new AssetModel { Id = 6, Model = "i-SENSYS MF455dw", AssetTypeID = 4, AssetBrandID = 5 });
            ModelBuilder.Entity<AssetModel>().HasData(new AssetModel { Id = 7, Model = "d-Color P3302", AssetTypeID = 4, AssetBrandID = 4 });
            ModelBuilder.Entity<AssetModel>().HasData(new AssetModel { Id = 8, Model = "MacBook", AssetTypeID = 1, AssetBrandID = 2 });
            ModelBuilder.Entity<AssetModel>().HasData(new AssetModel { Id = 9, Model = "Thinkstation", AssetTypeID = 2, AssetBrandID = 3 });
            ModelBuilder.Entity<AssetModel>().HasData(new AssetModel { Id = 10, Model = "MIUI Global", AssetTypeID = 3, AssetBrandID = 7 });

            ModelBuilder.Entity<Office>().HasData(new Office { Id = 1, Country = "USA", Currency = "USD" });
            ModelBuilder.Entity<Office>().HasData(new Office { Id = 2, Country = "England", Currency = "GBP" });
            ModelBuilder.Entity<Office>().HasData(new Office { Id = 3, Country = "Italy", Currency = "EUR" });
            ModelBuilder.Entity<Office>().HasData(new Office { Id = 4, Country = "Sweden", Currency = "SEK" });
            ModelBuilder.Entity<Office>().HasData(new Office { Id = 5, Country = "Schweiz", Currency = "CHF" });

            ModelBuilder.Entity<Asset>().HasData(new Asset { Id = 1, AssetModelId = 1, OfficeId = 1, Price = 1000, PurchaseDate = new DateTime(2023, 8, 31) });
            ModelBuilder.Entity<Asset>().HasData(new Asset { Id = 2, AssetModelId = 7, OfficeId = 3, Price = 2500, PurchaseDate = new DateTime(2022, 9, 29) });
            ModelBuilder.Entity<Asset>().HasData(new Asset { Id = 3, AssetModelId = 2, OfficeId = 5, Price = 500, PurchaseDate = new DateTime(2023, 8, 7) });
            ModelBuilder.Entity<Asset>().HasData(new Asset { Id = 4, AssetModelId = 9, OfficeId = 2, Price = 400, PurchaseDate = new DateTime(2021, 2, 11) });
            ModelBuilder.Entity<Asset>().HasData(new Asset { Id = 5, AssetModelId = 4, OfficeId = 2, Price = 350, PurchaseDate = new DateTime(2023, 9, 17) });
            ModelBuilder.Entity<Asset>().HasData(new Asset { Id = 6, AssetModelId = 8, OfficeId = 4, Price = 850, PurchaseDate = new DateTime(2022, 12, 12) });
            ModelBuilder.Entity<Asset>().HasData(new Asset { Id = 7, AssetModelId = 2, OfficeId = 1, Price = 550, PurchaseDate = new DateTime(2021, 5, 5) });
            ModelBuilder.Entity<Asset>().HasData(new Asset { Id = 8, AssetModelId = 6, OfficeId = 5, Price = 2250, PurchaseDate = new DateTime(2023, 6, 25) });
            ModelBuilder.Entity<Asset>().HasData(new Asset { Id = 9, AssetModelId = 3, OfficeId = 4, Price = 355, PurchaseDate = new DateTime(2023, 7, 22) });
            ModelBuilder.Entity<Asset>().HasData(new Asset { Id = 10, AssetModelId = 10, OfficeId = 3, Price = 355, PurchaseDate = new DateTime(2023, 1, 14) });

        }
    }
}
