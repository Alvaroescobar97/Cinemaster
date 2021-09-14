using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinemaster.Infrastructure.Migrations
{
    public partial class RemovePerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_MovieShow_MovieShowId",
                schema: "mySchema",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "mySchema");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "mySchema");

            migrationBuilder.AlterColumn<Guid>(
                name: "MovieShowId",
                schema: "mySchema",
                table: "Tickets",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_MovieShow_MovieShowId",
                schema: "mySchema",
                table: "Tickets",
                column: "MovieShowId",
                principalSchema: "mySchema",
                principalTable: "MovieShow",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_MovieShow_MovieShowId",
                schema: "mySchema",
                table: "Tickets");

            migrationBuilder.AlterColumn<Guid>(
                name: "MovieShowId",
                schema: "mySchema",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "mySchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "mySchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "mySchema",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_PersonId",
                schema: "mySchema",
                table: "Address",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_MovieShow_MovieShowId",
                schema: "mySchema",
                table: "Tickets",
                column: "MovieShowId",
                principalSchema: "mySchema",
                principalTable: "MovieShow",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
