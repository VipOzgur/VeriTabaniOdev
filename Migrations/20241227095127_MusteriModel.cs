using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VtOdev.Migrations
{
    /// <inheritdoc />
    public partial class MusteriModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Musteris",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteris", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        //    migrationBuilder.DropTable(
        //        name: "Musteris");

        //    migrationBuilder.DropTable(
        //        name: "Siparis");

        //    migrationBuilder.DropTable(
        //        name: "Product");
        }
    }
}
