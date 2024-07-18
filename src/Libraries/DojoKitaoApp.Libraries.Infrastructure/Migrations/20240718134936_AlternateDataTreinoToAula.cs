using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DojoKitaoApp.Libraries.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlternateDataTreinoToAula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Treinos");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Aulas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Aulas");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Treinos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
