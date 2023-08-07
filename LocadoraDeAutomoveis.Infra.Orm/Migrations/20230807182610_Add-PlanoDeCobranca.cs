using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeAutomoveis.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class AddPlanoDeCobranca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBFuncionario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    DataAdmissao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Salario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBFuncionario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBPlanoDeCobranca",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoDoPlano = table.Column<int>(type: "int", nullable: false),
                    PrecoDiaria = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecoKm = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KmDisponiveis = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPlanoDeCobranca", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBFuncionario");

            migrationBuilder.DropTable(
                name: "TBPlanoDeCobranca");
        }
    }
}
