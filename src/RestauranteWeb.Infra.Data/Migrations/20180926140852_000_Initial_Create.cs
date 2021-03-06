﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestauranteWeb.Infra.Data.Migrations
{
    public partial class _000_Initial_Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurantes",
                columns: table => new
                {
                    IdEntidade = table.Column<Guid>(nullable: false),
                    StatusRegistro = table.Column<byte>(nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(nullable: false),
                    UsuarioCriador = table.Column<Guid>(nullable: false),
                    DataHoraInativacao = table.Column<DateTime>(nullable: false),
                    UsuarioInativacao = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("RestauranteId", x => x.IdEntidade);
                });

            migrationBuilder.CreateTable(
                name: "Pratos",
                columns: table => new
                {
                    IdEntidade = table.Column<Guid>(nullable: false),
                    StatusRegistro = table.Column<byte>(nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(nullable: false),
                    UsuarioCriador = table.Column<Guid>(nullable: false),
                    DataHoraInativacao = table.Column<DateTime>(nullable: false),
                    UsuarioInativacao = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 100, nullable: false),
                    Preco = table.Column<decimal>(nullable: false),
                    RestauranteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PratoId", x => x.IdEntidade);
                    table.ForeignKey(
                        name: "FK_Pratos_Restaurantes_RestauranteId",
                        column: x => x.RestauranteId,
                        principalTable: "Restaurantes",
                        principalColumn: "IdEntidade",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pratos_RestauranteId",
                table: "Pratos",
                column: "RestauranteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pratos");

            migrationBuilder.DropTable(
                name: "Restaurantes");
        }
    }
}
