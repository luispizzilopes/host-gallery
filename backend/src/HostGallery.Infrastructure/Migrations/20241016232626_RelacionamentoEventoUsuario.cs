using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HostGallery.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentoEventoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_AspNetUsers_UsuarioId",
                table: "Eventos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventosUsuarios",
                table: "EventosUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_EventosUsuarios_UsuarioId",
                table: "EventosUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_UsuarioId",
                table: "Eventos");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DataAtualizacao",
                table: "EventosUsuarios",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DataCriacao",
                table: "EventosUsuarios",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventosUsuarios",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IpAtualizacao",
                table: "EventosUsuarios",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IpCriacao",
                table: "EventosUsuarios",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Capa",
                table: "Eventos",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventosUsuarios",
                table: "EventosUsuarios",
                columns: new[] { "UsuarioId", "EventoId" });

            migrationBuilder.CreateIndex(
                name: "IX_EventosUsuarios_EventoId",
                table: "EventosUsuarios",
                column: "EventoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EventosUsuarios",
                table: "EventosUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_EventosUsuarios_EventoId",
                table: "EventosUsuarios");

            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                table: "EventosUsuarios");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "EventosUsuarios");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventosUsuarios");

            migrationBuilder.DropColumn(
                name: "IpAtualizacao",
                table: "EventosUsuarios");

            migrationBuilder.DropColumn(
                name: "IpCriacao",
                table: "EventosUsuarios");

            migrationBuilder.DropColumn(
                name: "Capa",
                table: "Eventos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventosUsuarios",
                table: "EventosUsuarios",
                columns: new[] { "EventoId", "UsuarioId" });

            migrationBuilder.CreateIndex(
                name: "IX_EventosUsuarios_UsuarioId",
                table: "EventosUsuarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_UsuarioId",
                table: "Eventos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_AspNetUsers_UsuarioId",
                table: "Eventos",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
