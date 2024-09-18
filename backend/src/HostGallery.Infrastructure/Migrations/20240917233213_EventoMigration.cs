using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HostGallery.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EventoMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Evento_EventoId",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Evento_AspNetUsers_UsuarioId",
                table: "Evento");

            migrationBuilder.DropForeignKey(
                name: "FK_EventosUsuarios_Evento_EventoId",
                table: "EventosUsuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Evento",
                table: "Evento");

            migrationBuilder.RenameTable(
                name: "Evento",
                newName: "Eventos");

            migrationBuilder.RenameIndex(
                name: "IX_Evento_UsuarioId",
                table: "Eventos",
                newName: "IX_Eventos_UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Eventos",
                table: "Eventos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Eventos_EventoId",
                table: "Categorias",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_AspNetUsers_UsuarioId",
                table: "Eventos",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventosUsuarios_Eventos_EventoId",
                table: "EventosUsuarios",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Eventos_EventoId",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_AspNetUsers_UsuarioId",
                table: "Eventos");

            migrationBuilder.DropForeignKey(
                name: "FK_EventosUsuarios_Eventos_EventoId",
                table: "EventosUsuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Eventos",
                table: "Eventos");

            migrationBuilder.RenameTable(
                name: "Eventos",
                newName: "Evento");

            migrationBuilder.RenameIndex(
                name: "IX_Eventos_UsuarioId",
                table: "Evento",
                newName: "IX_Evento_UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Evento",
                table: "Evento",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Evento_EventoId",
                table: "Categorias",
                column: "EventoId",
                principalTable: "Evento",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Evento_AspNetUsers_UsuarioId",
                table: "Evento",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventosUsuarios_Evento_EventoId",
                table: "EventosUsuarios",
                column: "EventoId",
                principalTable: "Evento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
