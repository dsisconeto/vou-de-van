using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VouDeVan.Infrastructure.Database.Migrations
{
    public partial class CreateTransportationCompaniesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransportationCompanies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Cnpj = table.Column<string>(maxLength: 14, nullable: true),
                    FantasyName = table.Column<string>(maxLength: 50, nullable: true),
                    SocialName = table.Column<string>(maxLength: 100, nullable: true),
                    Address = table.Column<string>(maxLength: 400, nullable: true),
                    RepresentativeName = table.Column<string>(maxLength: 100, nullable: true),
                    RepresentativePhone = table.Column<string>(maxLength: 11, nullable: true),
                    Observation = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_TransportationCompanies", x => x.Id); });

            migrationBuilder.CreateIndex(
                name: "IX_TransportationCompanies_Status",
                table: "TransportationCompanies",
                column: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransportationCompanies");
        }
    }
}