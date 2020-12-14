using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreDepartman2.Migrations
{
    public partial class ilkMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Birims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ad = table.Column<string>(nullable: true),
                    Soyad = table.Column<string>(nullable: true),
                    Sehir = table.Column<string>(nullable: true),
                    BirimId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personels_Birims_BirimId",
                        column: x => x.BirimId,
                        principalTable: "Birims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personels_BirimId",
                table: "Personels",
                column: "BirimId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personels");

            migrationBuilder.DropTable(
                name: "Birims");
        }
    }
}
