using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace conta_bancaria_api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    saldo = table.Column<decimal>(type: "DECIMAL(18,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "transacoes",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    parent_id = table.Column<long>(nullable: true),
                    conta_corrente_id = table.Column<int>(nullable: false),
                    tipo = table.Column<byte>(nullable: false),
                    data_hora = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    saldo_anterior = table.Column<decimal>(type: "DECIMAL(18,6)", nullable: false),
                    valor = table.Column<decimal>(type: "DECIMAL(18,6)", nullable: false),
                    saldo_final = table.Column<decimal>(type: "DECIMAL(18,6)", nullable: false),
                    descricao = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transacoes", x => x.id);
                    table.ForeignKey(
                        name: "FK_transacoes_contas_conta_corrente_id",
                        column: x => x.conta_corrente_id,
                        principalTable: "contas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transacoes_transacoes_parent_id",
                        column: x => x.parent_id,
                        principalTable: "transacoes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_transacoes_conta_corrente_id",
                table: "transacoes",
                column: "conta_corrente_id");

            migrationBuilder.CreateIndex(
                name: "IX_transacoes_parent_id",
                table: "transacoes",
                column: "parent_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transacoes");

            migrationBuilder.DropTable(
                name: "contas");
        }
    }
}
