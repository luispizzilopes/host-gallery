using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HostGallery.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EventoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventoId",
                table: "Categorias",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    CodigoConvite = table.Column<Guid>(type: "uuid", nullable: false),
                    DataInicio = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DataFim = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UsuarioId = table.Column<string>(type: "text", nullable: false),
                    Usuarios = table.Column<string[]>(type: "text[]", nullable: true),
                    DataCriacao = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DataAtualizacao = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    IpCriacao = table.Column<string>(type: "text", nullable: true),
                    IpAtualizacao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evento_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventosUsuarios",
                columns: table => new
                {
                    EventoId = table.Column<int>(type: "integer", nullable: false),
                    UsuarioId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventosUsuarios", x => new { x.EventoId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_EventosUsuarios_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventosUsuarios_Evento_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Evento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_EventoId",
                table: "Categorias",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_UsuarioId",
                table: "Evento",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_EventosUsuarios_UsuarioId",
                table: "EventosUsuarios",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Evento_EventoId",
                table: "Categorias",
                column: "EventoId",
                principalTable: "Evento",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Evento_EventoId",
                table: "Categorias");

            migrationBuilder.DropTable(
                name: "EventosUsuarios");

            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_EventoId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "EventoId",
                table: "Categorias");
        }
    }
}
