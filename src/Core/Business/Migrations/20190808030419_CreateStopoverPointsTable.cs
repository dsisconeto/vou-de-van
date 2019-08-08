using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace VouDeVan.Core.Business.Migrations
{
    public partial class CreateStopoverPointsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "StopoverPoints",
               columns: table => new
               {
                   Id = table.Column<Guid>(nullable: false),
                   CreatedAt = table.Column<DateTime>(nullable: false),
                   UpdateAt = table.Column<DateTime>(nullable: false),
                   Name = table.Column<string>(nullable: false, maxLength: 255),
                   Latitude = table.Column<decimal>(nullable: false),
                   Longitude = table.Column<decimal>(nullable: false),
                   CityId = table.Column<Guid>(nullable: false),
                   Status = table.Column<int>(maxLength: 40, nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_StopoverPoints", x => x.Id);
               });

            migrationBuilder.CreateIndex(
                name: "IX_StopoverPoints_CityId",
                table: "StopoverPoints",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StopoverPoints");
        }
    }
}
