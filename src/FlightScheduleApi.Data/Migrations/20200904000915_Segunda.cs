using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightScheduleApi.Data.Migrations
{
    public partial class Segunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aeronaves",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Matricula = table.Column<string>(type: "varchar(5)", nullable: false),
                    Fabricante = table.Column<string>(type: "varchar(30)", nullable: false),
                    Categoria = table.Column<string>(type: "varchar(30)", nullable: false),
                    Modelo = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeronaves", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aeronaves");
        }
    }
}
