using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WardrobeAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Outfits",
                columns: table => new
                {
                    OutfitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Occasion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Season = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Style = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outfits", x => x.OutfitId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Wardrobes",
                columns: table => new
                {
                    WardrobeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wardrobes", x => x.WardrobeId);
                    table.ForeignKey(
                        name: "FK_Wardrobes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dresses",
                columns: table => new
                {
                    DressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Season = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Style = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WardrobeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dresses", x => x.DressId);
                    table.ForeignKey(
                        name: "FK_Dresses_Wardrobes_WardrobeId",
                        column: x => x.WardrobeId,
                        principalTable: "Wardrobes",
                        principalColumn: "WardrobeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OutfitDresses",
                columns: table => new
                {
                    OutfitId = table.Column<int>(type: "int", nullable: false),
                    DressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutfitDresses", x => new { x.OutfitId, x.DressId });
                    table.ForeignKey(
                        name: "FK_OutfitDresses_Dresses_DressId",
                        column: x => x.DressId,
                        principalTable: "Dresses",
                        principalColumn: "DressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutfitDresses_Outfits_OutfitId",
                        column: x => x.OutfitId,
                        principalTable: "Outfits",
                        principalColumn: "OutfitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Outfits",
                columns: new[] { "OutfitId", "Name", "Occasion", "Season", "Style" },
                values: new object[] { 1, "Summer Party", "Party", "Summer", "Casual" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "alice@example.com", "Alice", "pass123", "Admin" },
                    { 2, "bob@example.com", "Bob", "pass456", "User" }
                });

            migrationBuilder.InsertData(
                table: "Wardrobes",
                columns: new[] { "WardrobeId", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "Alice's Wardrobe", 1 },
                    { 2, "Bob's Wardrobe", 2 }
                });

            migrationBuilder.InsertData(
                table: "Dresses",
                columns: new[] { "DressId", "Color", "Name", "Season", "Size", "Style", "WardrobeId" },
                values: new object[,]
                {
                    { 1, "Red", "Red Dress", "Summer", "M", "Casual", 1 },
                    { 2, "Blue", "Blue Dress", "Winter", "L", "Formal", 2 }
                });

            migrationBuilder.InsertData(
                table: "OutfitDresses",
                columns: new[] { "DressId", "OutfitId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Dresses_WardrobeId",
                table: "Dresses",
                column: "WardrobeId");

            migrationBuilder.CreateIndex(
                name: "IX_OutfitDresses_DressId",
                table: "OutfitDresses",
                column: "DressId");

            migrationBuilder.CreateIndex(
                name: "IX_Wardrobes_UserId",
                table: "Wardrobes",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OutfitDresses");

            migrationBuilder.DropTable(
                name: "Dresses");

            migrationBuilder.DropTable(
                name: "Outfits");

            migrationBuilder.DropTable(
                name: "Wardrobes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
