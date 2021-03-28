using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioBack.Migrations
{
    public partial class DesafioBack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "titulo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuantidadeParcelas = table.Column<int>(type: "int", nullable: false),
                    ValorAtualizado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    numero = table.Column<long>(type: "bigint", nullable: false),
                    nome = table.Column<string>(type: "VARCHAR(80)", nullable: false),
                    cpf = table.Column<string>(type: "CHAR(11)", nullable: false),
                    juros = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    multa = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_titulo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "parcela",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TituloId = table.Column<int>(type: "int", nullable: false),
                    numero = table.Column<int>(type: "int", nullable: false),
                    vencimento = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parcela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_parcela_titulo_TituloId",
                        column: x => x.TituloId,
                        principalTable: "titulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_parcela_TituloId",
                table: "parcela",
                column: "TituloId");

            migrationBuilder.CreateIndex(
                name: "idx_titulo_cpf",
                table: "titulo",
                column: "cpf");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "parcela");

            migrationBuilder.DropTable(
                name: "titulo");
        }
    }
}
