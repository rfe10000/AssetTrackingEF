using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetTrackingEF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Office",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Office", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetTypeID = table.Column<int>(type: "int", nullable: false),
                    AssetBrandID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Model_Brand_AssetBrandID",
                        column: x => x.AssetBrandID,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Model_Type_AssetTypeID",
                        column: x => x.AssetTypeID,
                        principalTable: "Type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetModelId = table.Column<int>(type: "int", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asset_Model_AssetModelId",
                        column: x => x.AssetModelId,
                        principalTable: "Model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asset_Office_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Office",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Brand" },
                values: new object[,]
                {
                    { 1, "HP" },
                    { 2, "Apple" },
                    { 3, "Lenovo" },
                    { 4, "Olivetti" },
                    { 5, "Canon" },
                    { 6, "Samsung" },
                    { 7, "Xiaomi" }
                });

            migrationBuilder.InsertData(
                table: "Office",
                columns: new[] { "Id", "Country", "Currency" },
                values: new object[,]
                {
                    { 1, "USA", "USD" },
                    { 2, "England", "GBP" },
                    { 3, "Italy", "EUR" },
                    { 4, "Sweden", "SEK" },
                    { 5, "Schweiz", "CHF" }
                });

            migrationBuilder.InsertData(
                table: "Type",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Laptop" },
                    { 2, "Stationary" },
                    { 3, "Phone" },
                    { 4, "Printer" }
                });

            migrationBuilder.InsertData(
                table: "Model",
                columns: new[] { "Id", "AssetBrandID", "AssetTypeID", "Model" },
                values: new object[,]
                {
                    { 1, 1, 1, "Elitebook" },
                    { 2, 2, 3, "Iphone" },
                    { 3, 6, 3, "Galaxy" },
                    { 4, 3, 1, "Yoga" },
                    { 5, 1, 1, "Notebook" },
                    { 6, 5, 4, "i-SENSYS MF455dw" },
                    { 7, 4, 4, "d-Color P3302" },
                    { 8, 2, 1, "MacBook" },
                    { 9, 3, 2, "Thinkstation" },
                    { 10, 7, 3, "MIUI Global" }
                });

            migrationBuilder.InsertData(
                table: "Asset",
                columns: new[] { "Id", "AssetModelId", "OfficeId", "Price", "PurchaseDate" },
                values: new object[,]
                {
                    { 1, 1, 1, 1000.0, new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 7, 3, 2500.0, new DateTime(2022, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, 5, 500.0, new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 9, 2, 400.0, new DateTime(2021, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 4, 2, 350.0, new DateTime(2023, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 8, 4, 850.0, new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 2, 1, 550.0, new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 6, 5, 2250.0, new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 3, 4, 355.0, new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 10, 3, 355.0, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asset_AssetModelId",
                table: "Asset",
                column: "AssetModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_OfficeId",
                table: "Asset",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Model_AssetBrandID",
                table: "Model",
                column: "AssetBrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Model_AssetTypeID",
                table: "Model",
                column: "AssetTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.DropTable(
                name: "Office");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Type");
        }
    }
}
