using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect.Migrations
{
    public partial class Arrival : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Arrival",
                table: "Bus");

            migrationBuilder.AddColumn<int>(
                name: "ArrivalID",
                table: "Bus",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Arrival",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArrivalName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arrival", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bus_ArrivalID",
                table: "Bus",
                column: "ArrivalID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bus_Arrival_ArrivalID",
                table: "Bus",
                column: "ArrivalID",
                principalTable: "Arrival",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bus_Arrival_ArrivalID",
                table: "Bus");

            migrationBuilder.DropTable(
                name: "Arrival");

            migrationBuilder.DropIndex(
                name: "IX_Bus_ArrivalID",
                table: "Bus");

            migrationBuilder.DropColumn(
                name: "ArrivalID",
                table: "Bus");

            migrationBuilder.AddColumn<string>(
                name: "Arrival",
                table: "Bus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
