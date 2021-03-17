using Microsoft.EntityFrameworkCore.Migrations;

namespace CherFanPage.Migrations
{
    public partial class LastDM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OutfitYear",
                columns: table => new
                {
                    OutfitYearID = table.Column<string>(nullable: false),
                    Decade = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutfitYear", x => x.OutfitYearID);
                });

            migrationBuilder.CreateTable(
                name: "Outfits",
                columns: table => new
                {
                    OutfitID = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    DecadeOutfitYearID = table.Column<string>(nullable: true),
                    LogoImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outfits", x => x.OutfitID);
                    table.ForeignKey(
                        name: "FK_Outfits_OutfitYear_DecadeOutfitYearID",
                        column: x => x.DecadeOutfitYearID,
                        principalTable: "OutfitYear",
                        principalColumn: "OutfitYearID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Outfits_DecadeOutfitYearID",
                table: "Outfits",
                column: "DecadeOutfitYearID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Outfits");

            migrationBuilder.DropTable(
                name: "OutfitYear");
        }
    }
}
