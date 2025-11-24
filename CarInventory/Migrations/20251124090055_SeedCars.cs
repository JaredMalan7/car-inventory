using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarInventory.Migrations
{
    /// <inheritdoc />
    public partial class SeedCars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "ImageFileName", "ImageUrl", "Make", "Model", "Price", "Year" },
                values: new object[,]
                {
                    { 1, null, "no-image", "Toyota", "Camry", 22000m, 2020 },
                    { 2, null, "no-image", "Ford", "Mustang", 28000m, 2019 },
                    { 3, null, "no-image", "Honda", "Civic", 21500m, 2021 },
                    { 4, null, "no-image", "Tesla", "Model 3", 39000m, 2022 },
                    { 5, null, "no-image", "Chevrolet", "Silverado", 31000m, 2018 },
                    { 6, null, "no-image", "Subaru", "Outback", 27800m, 2020 },
                    { 7, null, "no-image", "BMW", "330i", 33500m, 2019 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
