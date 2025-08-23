using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WardrobeAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddWardrobeIdToDress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WardrobeId",
                table: "Outfits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "WardrobeId",
                table: "Dresses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Outfits",
                keyColumn: "OutfitId",
                keyValue: 1,
                column: "WardrobeId",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WardrobeId",
                table: "Outfits");

            migrationBuilder.AlterColumn<int>(
                name: "WardrobeId",
                table: "Dresses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
