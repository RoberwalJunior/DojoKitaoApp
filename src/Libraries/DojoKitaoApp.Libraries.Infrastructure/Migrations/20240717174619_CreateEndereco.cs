using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DojoKitaoApp.Libraries.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateEndereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Matriculas_MatriculaId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Matriculas");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Aulas");

            migrationBuilder.RenameColumn(
                name: "MatriculaId",
                table: "Alunos",
                newName: "EnderecoId");

            migrationBuilder.RenameIndex(
                name: "IX_Alunos_MatriculaId",
                table: "Alunos",
                newName: "IX_Alunos_EnderecoId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Treinos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "Matriculas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Alunos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Sobrenome",
                table: "Alunos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CEP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_AlunoId",
                table: "Matriculas",
                column: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Enderecos_EnderecoId",
                table: "Alunos",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_Alunos_AlunoId",
                table: "Matriculas",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Enderecos_EnderecoId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_Alunos_AlunoId",
                table: "Matriculas");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Matriculas_AlunoId",
                table: "Matriculas");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Treinos");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Matriculas");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "Sobrenome",
                table: "Alunos");

            migrationBuilder.RenameColumn(
                name: "EnderecoId",
                table: "Alunos",
                newName: "MatriculaId");

            migrationBuilder.RenameIndex(
                name: "IX_Alunos_EnderecoId",
                table: "Alunos",
                newName: "IX_Alunos_MatriculaId");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Matriculas",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Aulas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Matriculas_MatriculaId",
                table: "Alunos",
                column: "MatriculaId",
                principalTable: "Matriculas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
