using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class addedRoomAndClimate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Climate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemperatureUnit = table.Column<string>(nullable: true),
                    CurrentTemperature = table.Column<float>(nullable: false),
                    CurrentHumidity = table.Column<float>(nullable: false),
                    TargetTemperature = table.Column<float>(nullable: false),
                    TargetHumidity = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Climate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Light",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LightId = table.Column<int>(nullable: false),
                    Brightness = table.Column<int>(nullable: false),
                    ColorTemp = table.Column<int>(nullable: false),
                    Effect = table.Column<string>(nullable: true),
                    Color = table.Column<int>(nullable: false),
                    IsOn = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Light", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Climate");

            migrationBuilder.DropTable(
                name: "Light");

            migrationBuilder.DropTable(
                name: "Room");
        }
    }
}
