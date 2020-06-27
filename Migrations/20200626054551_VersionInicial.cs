using Microsoft.EntityFrameworkCore.Migrations;

namespace IkePublicacionesMarketingService.Migrations
{
    public partial class VersionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Publicaciones",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(nullable: true),
                    Imagen = table.Column<string>(nullable: true),
                    Titulo = table.Column<string>(nullable: true),
                    Leyenda = table.Column<string>(nullable: true),
                    BtnCaption = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Http = table.Column<string>(nullable: true),
                    Orden = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicaciones", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Publicaciones");
        }
    }
}
