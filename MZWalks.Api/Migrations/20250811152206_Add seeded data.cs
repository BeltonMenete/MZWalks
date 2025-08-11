using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MZWalks.Api.Migrations
{
    /// <inheritdoc />
    public partial class Addseededdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "01HZX0J5ZWGFA1D9S3H4HMGWVD", "Easy" },
                    { "01HZX0J5ZX9Y9S9TCS59R3KH9J", "Medium" },
                    { "01HZX0J60AZK3D9R9YFMC2DJMD", "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageURL" },
                values: new object[,]
                {
                    { "01HZX0J60B8J1A8RPX1M0XQJ3N", "AKL", "Auckland", "https://images.nzregions.com/auckland.jpg" },
                    { "01HZX0J60C1J1A8RPX2N1YQJ3P", "WGN", "Wellington", "https://images.nzregions.com/wellington.jpg" },
                    { "01HZX0J60D1J1A8RPX3Z2ZQJ3Q", "CAN", "Canterbury", "https://images.nzregions.com/canterbury.jpg" },
                    { "01HZX0J60E1J1A8RPX4P3AQJ3R", "STL", "Southland", "https://images.nzregions.com/southland.jpg" },
                    { "01HZX0J60F1J1A8RPX5D4BQJ3S", "OTA", "Otago", "https://images.nzregions.com/otago.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: "01HZX0J5ZWGFA1D9S3H4HMGWVD");

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: "01HZX0J5ZX9Y9S9TCS59R3KH9J");

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: "01HZX0J60AZK3D9R9YFMC2DJMD");

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: "01HZX0J60B8J1A8RPX1M0XQJ3N");

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: "01HZX0J60C1J1A8RPX2N1YQJ3P");

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: "01HZX0J60D1J1A8RPX3Z2ZQJ3Q");

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: "01HZX0J60E1J1A8RPX4P3AQJ3R");

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: "01HZX0J60F1J1A8RPX5D4BQJ3S");
        }
    }
}
