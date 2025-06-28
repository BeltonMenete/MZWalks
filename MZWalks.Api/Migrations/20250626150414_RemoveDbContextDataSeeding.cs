using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MZWalks.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDbContextDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("07bbe860-ed98-4431-9934-9775d6c2ea1e"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("14a66713-2414-4831-84a4-33a7bcd08b1c"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("e89b2659-7259-46ef-8c09-9b8055ac29e4"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("07bbe860-ed98-4431-9934-9775d6c2ea1e"), "easy" },
                    { new Guid("14a66713-2414-4831-84a4-33a7bcd08b1c"), "Hard" },
                    { new Guid("e89b2659-7259-46ef-8c09-9b8055ac29e4"), "Medium" }
                });
        }
    }
}
