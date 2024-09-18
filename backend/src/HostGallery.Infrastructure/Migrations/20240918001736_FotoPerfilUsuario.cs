using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HostGallery.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FotoPerfilUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Usuarios",
                table: "Eventos");

            migrationBuilder.AddColumn<string>(
                name: "FotoPerfil",
                table: "AspNetUsers",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoPerfil",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string[]>(
                name: "Usuarios",
                table: "Eventos",
                type: "text[]",
                nullable: true);
        }
    }
}
