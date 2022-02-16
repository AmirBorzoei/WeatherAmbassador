using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherAmbassador.Persistence.EF.Migrations
{
    public partial class InitModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SettingKey = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    SettingValue = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiCallKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ApiCallResult = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    ApiCallDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherLogs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "SettingKey", "SettingValue" },
                values: new object[] { 1, "WeatherApiUrl", "https://webhook.site/17b35eca-2c97-4997-8352-2f0b71e55e83" });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "SettingKey", "SettingValue" },
                values: new object[] { 2, "WeatherApiCallIntervalFormat", "YYYY-MM-dd_HH-mm" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "WeatherLogs");
        }
    }
}
