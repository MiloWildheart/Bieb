using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bieb.Migrations
{
    /// <inheritdoc />
    public partial class AddedBiebItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Items",
                table: "Authors");

            migrationBuilder.CreateTable(
                name: "BiebItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MediaType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiebItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBiebItem",
                columns: table => new
                {
                    AuthorsId = table.Column<int>(type: "int", nullable: false),
                    BiebItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBiebItem", x => new { x.AuthorsId, x.BiebItemsId });
                    table.ForeignKey(
                        name: "FK_AuthorBiebItem_Authors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBiebItem_BiebItems_BiebItemsId",
                        column: x => x.BiebItemsId,
                        principalTable: "BiebItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBiebItem_BiebItemsId",
                table: "AuthorBiebItem",
                column: "BiebItemsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBiebItem");

            migrationBuilder.DropTable(
                name: "BiebItems");

            migrationBuilder.AddColumn<string>(
                name: "Items",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Items",
                value: "van Zuilichem");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Items",
                value: "Kozlova");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Items",
                value: "Sievers");
        }
    }
}
