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
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
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
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    isDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IssueProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueProducts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
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
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "User" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDateTime", "Description", "ImageUrl", "Name", "Stock", "isDeleted" },
                values: new object[] { 1, 1, new DateTime(2023, 10, 4, 14, 21, 55, 209, DateTimeKind.Local).AddTicks(4778), "Powerful laptop from Dell with great performance.", "https://www.informationq.com/wp-content/uploads/2013/11/Dell-Inspiron-15-3521-15.6-inch-Laptop-Black01.jpg", "Dell Laptop", 0, false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDateTime", "Description", "ImageUrl", "Name", "Stock", "isDeleted" },
                values: new object[] { 2, 2, new DateTime(2023, 10, 4, 14, 21, 55, 209, DateTimeKind.Local).AddTicks(4792), "High-end desktop computer from Apple.", "https://images.unsplash.com/photo-1517059224940-d4af9eec41b7?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1000&q=80", "Mac PC", 0, false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDateTime", "Description", "ImageUrl", "Name", "Stock", "isDeleted" },
                values: new object[] { 3, 3, new DateTime(2023, 10, 4, 14, 21, 55, 209, DateTimeKind.Local).AddTicks(4793), "Wireless mouse and keyboard combo for convenience.", "https://img.freepik.com/free-vector/print_53876-43658.jpg?t=st=1696176612~exp=1696177212~hmac=92132b1b0cd9692963f9fc6eb1fb61cae00ce7af4161822c24a8429a6fb083c0", "Mouse and Keyboard Combo", 0, false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDateTime", "Description", "ImageUrl", "Name", "Stock", "isDeleted" },
                values: new object[] { 4, 4, new DateTime(2023, 10, 4, 14, 21, 55, 209, DateTimeKind.Local).AddTicks(4794), "Versatile printer from HP for all your printing needs.", "https://images.unsplash.com/photo-1612815154858-60aa4c59eaa6?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8aHAlMjBwcmludGVyfGVufDB8fDB8fHww&w=1000&q=80", "HP Printer", 0, false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDateTime", "Description", "ImageUrl", "Name", "Stock", "isDeleted" },
                values: new object[] { 5, 5, new DateTime(2023, 10, 4, 14, 21, 55, 209, DateTimeKind.Local).AddTicks(4795), "Large-capacity external hard drive for storage.", "https://media.istockphoto.com/id/496402410/photo/external-hard-drive-for-backup.jpg?s=612x612&w=0&k=20&c=Ul6uXVrMdFEmIC7xH_f54tWfYQSExa1_j70eP-5fuyM=", "External Hard Drive", 0, false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDateTime", "Description", "ImageUrl", "Name", "Stock", "isDeleted" },
                values: new object[] { 6, 6, new DateTime(2023, 10, 4, 14, 21, 55, 209, DateTimeKind.Local).AddTicks(4798), "High-refresh-rate gaming monitor for a smooth gaming experience.", "https://img.freepik.com/free-photo/view-computer-monitor-display_23-2150757434.jpg", "Gaming Monitor", 0, false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDateTime", "Description", "ImageUrl", "Name", "Stock", "isDeleted" },
                values: new object[] { 7, 7, new DateTime(2023, 10, 4, 14, 21, 55, 209, DateTimeKind.Local).AddTicks(4799), "Fast and reliable wireless router for home networking.", "https://img.freepik.com/premium-vector/vector-wireless-router-free-wifi-zone-concept-modern-flat-illustration_660702-331.jpg?w=2000", "Wireless Router", 0, false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDateTime", "Description", "ImageUrl", "Name", "Stock", "isDeleted" },
                values: new object[] { 8, 5, new DateTime(2023, 10, 4, 14, 21, 55, 209, DateTimeKind.Local).AddTicks(4800), "Portable external SSD for quick data access on the go.", "https://i5.walmartimages.com/asr/3daa0c60-384f-4d78-a135-04d74cf70e09.133b2adf608c606c41dd16e3f4afb4fd.jpeg?odnHeight=2000&odnWidth=2000&odnBg=FFFFFF", "External SSD", 0, false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDateTime", "Description", "ImageUrl", "Name", "Stock", "isDeleted" },
                values: new object[] { 9, 8, new DateTime(2023, 10, 4, 14, 21, 55, 209, DateTimeKind.Local).AddTicks(4801), "Compact USB flash drive with ample storage capacity.", "https://cdn.pixabay.com/photo/2015/07/20/19/50/usb-853230_1280.png", "USB Flash Drive", 0, false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDateTime", "Description", "ImageUrl", "Name", "Stock", "isDeleted" },
                values: new object[] { 10, 8, new DateTime(2023, 10, 4, 14, 21, 55, 209, DateTimeKind.Local).AddTicks(4803), "High-performance graphics card for gaming and content creation.", "https://images.pexels.com/photos/6341789/pexels-photo-6341789.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500", "Graphics Card", 0, false });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "PasswordHash", "RoleId" },
                values: new object[] { 1, "ram.doe@example.com", "Ram Doe", "$2a$11$XxNdWXeHeEEIxVjQ98eJCOYlFB6tPaEZJAU85S/fphTkTmTOHKBxe", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "PasswordHash", "RoleId" },
                values: new object[] { 2, "shyam.doe@example.com", "Shyam Doe", "$2a$11$pMVuC24kuwheIxXyBgYapuBBvKYBg8hDzAeVv5eldKDUTWzOx04.a", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_IssueProducts_ProductId",
                table: "IssueProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueProducts_UserId",
                table: "IssueProducts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssueProducts");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
