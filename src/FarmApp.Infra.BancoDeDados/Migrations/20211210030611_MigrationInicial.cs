using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FarmApp.Infra.BancoDeDados.Migrations
{
    public partial class MigrationInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Certificado",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Telefone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    Token = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: true),
                    Validado = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IX_Certificado_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(255)", maxLength: 100, nullable: true),
                    Cpf = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: true),
                    Telefone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 100, nullable: true),
                    Cep = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IX_Usuario_Id", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificado");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
