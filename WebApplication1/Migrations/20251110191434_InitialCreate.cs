using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Inventory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookRequests_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookRequests_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Description", "Inventory", "Name" },
                values: new object[,]
                {
                    { 1, "Magic book", 15, "Harry Potter" },
                    { 2, "Fantasy epic", 8, "Lord of the Rings" },
                    { 3, "Dystopian novel", 12, "1984" },
                    { 4, "Romance classic", 5, "Pride and Prejudice" },
                    { 5, "Adventure tale", 20, "The Hobbit" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Age", "Name" },
                values: new object[,]
                {
                    { 1, "Isfahan", 25, "Ali Ahmadi" },
                    { 2, "Isfahan", 15, "Sara Rezaei" },
                    { 3, "Tehran", 30, "Reza Karimi" },
                    { 4, "Isfahan", 12, "Mina Hosseini" },
                    { 5, "Shiraz", 8, "Mohammad Jafari" }
                });

            migrationBuilder.InsertData(
                table: "BookRequests",
                columns: new[] { "Id", "BookId", "CustomerId", "RequestDate" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 1, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, 2, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 3, 3, new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, 4, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookRequests_BookId",
                table: "BookRequests",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookRequests_CustomerId",
                table: "BookRequests",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookRequests");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
