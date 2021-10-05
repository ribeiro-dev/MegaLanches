using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaLanches.Migrations
{
    public partial class EditaPreferidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Lanches SET IsPreferido = 1 WHERE CategoriaId = 4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Lanches SET IsPreferido = 0 WHERE CategoriaId = 4");

        }
    }
}
