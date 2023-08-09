using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeAutomoveis.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class TBAutomovel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBAutomovel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Placa = table.Column<string>(type: "varchar(12)", nullable: false),
                    Marca = table.Column<string>(type: "varchar(20)", nullable: false),
                    Cor = table.Column<string>(type: "varchar(60)", nullable: false),
                    Modelo = table.Column<string>(type: "varchar(60)", nullable: false),
                    TipoCombustivel = table.Column<int>(type: "int", nullable: false),
                    CapacidadeCombustivel = table.Column<double>(type: "float", nullable: false),
                    Ano = table.Column<string>(type: "varchar(15)", nullable: false),
                    KM = table.Column<double>(type: "float", nullable: false),
                    Imagem = table.Column<byte[]>(type: "varbinary(max)", maxLength: 2097152, nullable: false),
                    FK_Automovel_GrupoDeAutomoveis = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAutomovel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBAutomovel_TBGrupoDeAutomoveis_FK_Automovel_GrupoDeAutomoveis",
                        column: x => x.FK_Automovel_GrupoDeAutomoveis,
                        principalTable: "TBGrupoDeAutomoveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBAutomovel_FK_Automovel_GrupoDeAutomoveis",
                table: "TBAutomovel",
                column: "FK_Automovel_GrupoDeAutomoveis");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBAutomovel");
        }
    }
}
