using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MZWalks.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddDifficultiesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walk_Difficulty_DifficultyId",
                table: "Walk");

            migrationBuilder.DropForeignKey(
                name: "FK_Walk_Regions_RegionId",
                table: "Walk");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Walk",
                table: "Walk");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Difficulty",
                table: "Difficulty");

            migrationBuilder.RenameTable(
                name: "Walk",
                newName: "Walks");

            migrationBuilder.RenameTable(
                name: "Difficulty",
                newName: "Difficulties");

            migrationBuilder.RenameIndex(
                name: "IX_Walk_RegionId",
                table: "Walks",
                newName: "IX_Walks_RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Walk_DifficultyId",
                table: "Walks",
                newName: "IX_Walks_DifficultyId");

            migrationBuilder.AlterColumn<string>(
                name: "RegionImageURL",
                table: "Regions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WalkImageURl",
                table: "Walks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Walks",
                table: "Walks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Difficulties",
                table: "Difficulties",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Difficulties_DifficultyId",
                table: "Walks",
                column: "DifficultyId",
                principalTable: "Difficulties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Regions_RegionId",
                table: "Walks",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Difficulties_DifficultyId",
                table: "Walks");

            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Regions_RegionId",
                table: "Walks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Walks",
                table: "Walks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Difficulties",
                table: "Difficulties");

            migrationBuilder.RenameTable(
                name: "Walks",
                newName: "Walk");

            migrationBuilder.RenameTable(
                name: "Difficulties",
                newName: "Difficulty");

            migrationBuilder.RenameIndex(
                name: "IX_Walks_RegionId",
                table: "Walk",
                newName: "IX_Walk_RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Walks_DifficultyId",
                table: "Walk",
                newName: "IX_Walk_DifficultyId");

            migrationBuilder.AlterColumn<string>(
                name: "RegionImageURL",
                table: "Regions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "WalkImageURl",
                table: "Walk",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Walk",
                table: "Walk",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Difficulty",
                table: "Difficulty",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Walk_Difficulty_DifficultyId",
                table: "Walk",
                column: "DifficultyId",
                principalTable: "Difficulty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Walk_Regions_RegionId",
                table: "Walk",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
