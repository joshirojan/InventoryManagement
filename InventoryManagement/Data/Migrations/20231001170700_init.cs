using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Laptop" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Desktop" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Accessories" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Printers" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Storage" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Monitors" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "Networking" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 8, "Components" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDateTime", "Description", "ImageUrl", "Name" },
                values: new object[] { 1, 1, new DateTime(2023, 10, 1, 22, 52, 0, 699, DateTimeKind.Local).AddTicks(7539), "Powerful laptop from Dell with great performance.", "https://www.informationq.com/wp-content/uploads/2013/11/Dell-Inspiron-15-3521-15.6-inch-Laptop-Black01.jpg", "Dell Laptop" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDateTime", "Description", "ImageUrl", "Name" },
                values: new object[] { 2, 2, new DateTime(2023, 10, 1, 22, 52, 0, 699, DateTimeKind.Local).AddTicks(7553), "High-end desktop computer from Apple.", "https://images.unsplash.com/photo-1517059224940-d4af9eec41b7?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1000&q=80", "Mac PC" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDateTime", "Description", "ImageUrl", "Name" },
                values: new object[] { 3, 3, new DateTime(2023, 10, 1, 22, 52, 0, 699, DateTimeKind.Local).AddTicks(7554), "Wireless mouse and keyboard combo for convenience.", "https://img.freepik.com/free-vector/print_53876-43658.jpg?t=st=1696176612~exp=1696177212~hmac=92132b1b0cd9692963f9fc6eb1fb61cae00ce7af4161822c24a8429a6fb083c0", "Mouse and Keyboard Combo" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDateTime", "Description", "ImageUrl", "Name" },
                values: new object[] { 4, 4, new DateTime(2023, 10, 1, 22, 52, 0, 699, DateTimeKind.Local).AddTicks(7555), "Versatile printer from HP for all your printing needs.", "https://images.unsplash.com/photo-1612815154858-60aa4c59eaa6?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8aHAlMjBwcmludGVyfGVufDB8fDB8fHww&w=1000&q=80", "HP Printer" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDateTime", "Description", "ImageUrl", "Name" },
                values: new object[] { 5, 5, new DateTime(2023, 10, 1, 22, 52, 0, 699, DateTimeKind.Local).AddTicks(7556), "Large-capacity external hard drive for storage.", "https://media.istockphoto.com/id/496402410/photo/external-hard-drive-for-backup.jpg?s=612x612&w=0&k=20&c=Ul6uXVrMdFEmIC7xH_f54tWfYQSExa1_j70eP-5fuyM=", "External Hard Drive" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDateTime", "Description", "ImageUrl", "Name" },
                values: new object[] { 6, 6, new DateTime(2023, 10, 1, 22, 52, 0, 699, DateTimeKind.Local).AddTicks(7608), "High-refresh-rate gaming monitor for a smooth gaming experience.", "https://img.freepik.com/free-photo/view-computer-monitor-display_23-2150757434.jpg", "Gaming Monitor" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDateTime", "Description", "ImageUrl", "Name" },
                values: new object[] { 7, 7, new DateTime(2023, 10, 1, 22, 52, 0, 699, DateTimeKind.Local).AddTicks(7610), "Fast and reliable wireless router for home networking.", "https://img.freepik.com/premium-vector/vector-wireless-router-free-wifi-zone-concept-modern-flat-illustration_660702-331.jpg?w=2000", "Wireless Router" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDateTime", "Description", "ImageUrl", "Name" },
                values: new object[] { 8, 5, new DateTime(2023, 10, 1, 22, 52, 0, 699, DateTimeKind.Local).AddTicks(7611), "Portable external SSD for quick data access on the go.", "https://i5.walmartimages.com/asr/3daa0c60-384f-4d78-a135-04d74cf70e09.133b2adf608c606c41dd16e3f4afb4fd.jpeg?odnHeight=2000&odnWidth=2000&odnBg=FFFFFF", "External SSD" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDateTime", "Description", "ImageUrl", "Name" },
                values: new object[] { 9, 8, new DateTime(2023, 10, 1, 22, 52, 0, 699, DateTimeKind.Local).AddTicks(7612), "Compact USB flash drive with ample storage capacity.", "https://cdn.pixabay.com/photo/2015/07/20/19/50/usb-853230_1280.png", "USB Flash Drive" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDateTime", "Description", "ImageUrl", "Name" },
                values: new object[] { 10, 8, new DateTime(2023, 10, 1, 22, 52, 0, 699, DateTimeKind.Local).AddTicks(7614), "High-performance graphics card for gaming and content creation.", "https://images.pexels.com/photos/6341789/pexels-photo-6341789.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500", "Graphics Card" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
