using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoAcmeAp.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Numero = table.Column<long>(type: "bigint", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Uf = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnderecoCobrancaId = table.Column<long>(type: "bigint", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_Endereco_EnderecoCobrancaId",
                        column: x => x.EnderecoCobrancaId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Instalacao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<long>(type: "bigint", nullable: true),
                    EnderecoInstalacaoId = table.Column<long>(type: "bigint", nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataInstalacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instalacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instalacao_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Instalacao_Endereco_EnderecoInstalacaoId",
                        column: x => x.EnderecoInstalacaoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fatura",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstalacaoId = table.Column<long>(type: "bigint", nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataLeitura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroLeitura = table.Column<int>(type: "int", nullable: false),
                    ValorConta = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fatura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fatura_Instalacao_InstalacaoId",
                        column: x => x.InstalacaoId,
                        principalTable: "Instalacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_EnderecoCobrancaId",
                table: "Cliente",
                column: "EnderecoCobrancaId");

            migrationBuilder.CreateIndex(
                name: "IX_Fatura_InstalacaoId",
                table: "Fatura",
                column: "InstalacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Instalacao_ClienteId",
                table: "Instalacao",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Instalacao_EnderecoInstalacaoId",
                table: "Instalacao",
                column: "EnderecoInstalacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fatura");

            migrationBuilder.DropTable(
                name: "Instalacao");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
