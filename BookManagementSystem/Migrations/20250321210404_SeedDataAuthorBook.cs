using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataAuthorBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "BirthDate", "City", "Email", "FullName" },
                values: new object[,]
                {
                    { 1, new DateTime(1927, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aracataca", "gabriel@example.com", "Gabriel García Márquez" },
                    { 2, new DateTime(1947, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Río De Janeiro", "paulo@example.com", "Paulo Coelho" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Genre", "PageCount", "Title", "Year" },
                values: new object[,]
                {
                    { 1, 1, "Realismo mágico", 417, "Cien años de soledad", 1967 },
                    { 2, 2, "Drama", 192, "El Alquimista", 1988 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
