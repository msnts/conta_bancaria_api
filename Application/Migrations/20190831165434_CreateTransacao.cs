using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace conta_bancaria_api.Migrations
{
    public partial class CreateTransacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "transacoes",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContaCorrenteId = table.Column<int>(nullable: false),
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
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transacoes");
        }
    }
}
