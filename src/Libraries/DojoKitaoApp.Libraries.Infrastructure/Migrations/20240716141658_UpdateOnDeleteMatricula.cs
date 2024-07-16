using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DojoKitaoApp.Libraries.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOnDeleteMatricula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Matriculas_MatriculaId",
                table: "Alunos");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Matriculas_MatriculaId",
                table: "Alunos",
                column: "MatriculaId",
                principalTable: "Matriculas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Matriculas_MatriculaId",
                table: "Alunos");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Matriculas_MatriculaId",
                table: "Alunos",
                column: "MatriculaId",
                principalTable: "Matriculas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
