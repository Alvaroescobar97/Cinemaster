using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinemaster.Infrastructure.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieShow",
                schema: "mySchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Pelicula = table.Column<string>(nullable: true),
                    Sala = table.Column<int>(nullable: false),
                    Hora = table.Column<DateTime>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    LastModifiedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieShow", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                schema: "mySchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Silla = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    LastModifiedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    MovieShowId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_MovieShow_MovieShowId",
                        column: x => x.MovieShowId,
                        principalSchema: "mySchema",
                        principalTable: "MovieShow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_MovieShowId",
                schema: "mySchema",
                table: "Tickets",
                column: "MovieShowId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets",
                schema: "mySchema");

            migrationBuilder.DropTable(
                name: "MovieShow",
                schema: "mySchema");
        }
    }
}
