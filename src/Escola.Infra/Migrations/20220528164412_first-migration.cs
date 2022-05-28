using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Escola.Infra.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Escolaridade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EscolaridadeTipo = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escolaridade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoEscolar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    Formato = table.Column<string>(type: "varchar(20)", nullable: false),
                    HistoricoBase64 = table.Column<string>(type: "varchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoEscolar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    Sobrenome = table.Column<string>(type: "varchar(150)", nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    EscolaridadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HistoricoEscolarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aluno_Escolaridade_EscolaridadeId",
                        column: x => x.EscolaridadeId,
                        principalTable: "Escolaridade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aluno_HistoricoEscolar_HistoricoEscolarId",
                        column: x => x.HistoricoEscolarId,
                        principalTable: "HistoricoEscolar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Escolaridade",
                columns: new[] { "Id", "EscolaridadeTipo" },
                values: new object[,]
                {
                    { new Guid("5ed433bb-5687-4b00-9d1b-84717101ac48"), "Infantil" },
                    { new Guid("ce280415-4d18-4637-9244-7b76b69274a4"), "Fundamental" },
                    { new Guid("ef4565e5-b230-4182-89f1-0ebfc1e26563"), "Medio" },
                    { new Guid("3165c861-851b-4913-8ced-539bcb35af63"), "Superior" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_EscolaridadeId",
                table: "Aluno",
                column: "EscolaridadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_HistoricoEscolarId",
                table: "Aluno",
                column: "HistoricoEscolarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Escolaridade");

            migrationBuilder.DropTable(
                name: "HistoricoEscolar");
        }
    }
}
