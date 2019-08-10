using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VouDeVan.Core.Business.Migrations
{
    public partial class CreateTransportationCompanies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransportationCompanies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: false),
                    CNPJ = table.Column<string>(maxLength: 14, nullable: false),
                    FantasyName = table.Column<string>(maxLength: 50, nullable: false),
                    SocialName = table.Column<string>(maxLength: 100, nullable: false),
                    Address = table.Column<string>(maxLength: 400, nullable: false),
                    RepresentativeName = table.Column<string>(maxLength: 100, nullable: false),
                    RepresentativePhone = table.Column<string>(maxLength: 11, nullable: false),
                    Observation = table.Column<string>(type: "text", maxLength: 1000, nullable: true),
                    Status = table.Column<int>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportationCompanies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransportationCompanies");
        }
    }
}
