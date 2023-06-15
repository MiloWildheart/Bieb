using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bieb.Migrations
{
    /// <inheritdoc />
    public partial class SeedData3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BiebItems",
                columns: new[] { "Id", "MediaType", "Titel" },
                values: new object[,]
                {
                    { 1, "Book", "WPF is depricated" },
                    { 2, "Book", "How do i seed this correctly for dummies" },
                    { 3, "Book", "WPF is depricated a sequel" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BiebItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BiebItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BiebItems",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
