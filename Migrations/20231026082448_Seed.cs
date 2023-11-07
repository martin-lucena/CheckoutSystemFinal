using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CheckoutSystem.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CustomerType", "Email", "LastName", "Name" },
                values: new object[,]
                {
                    { 1, 0, "martin@gmail.com", "Lucena", "Martin" },
                    { 2, 1, "malin@gmail.com", "Andersson", "Malin" }
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "CustomerId", "FilmMediaType", "Price", "Titel" },
                values: new object[,]
                {
                    { 5, null, 0, 29, "The Dark Knight" },
                    { 6, null, 1, 39, "Forrest Gump" },
                    { 7, null, 0, 29, "The Matrix" },
                    { 8, null, 1, 39, "Schindler's List" },
                    { 9, null, 0, 29, "The Silence of the Lambs" },
                    { 10, null, 1, 39, "Fight Club" },
                    { 11, null, 0, 29, "Gladiator" },
                    { 12, null, 1, 39, "The Lord of the Rings: The Fellowship of the Ring" },
                    { 13, null, 0, 29, "Star Wars: Episode IV - A New Hope" },
                    { 14, null, 1, 39, "Inception" },
                    { 15, null, 0, 29, "Interstellar" },
                    { 1, 1, 0, 29, "Titanic" },
                    { 2, 1, 1, 39, "The Shawshank Redemption" },
                    { 3, 2, 0, 29, "The Godfather" },
                    { 4, 2, 1, 39, "Pulp Fiction" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
