using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VtOdev.Migrations
{
    /// <inheritdoc />
    public partial class createdAdAndUPdateAd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedAt",
                table: "Siparis",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedAt",
                table: "Siparis",
                type: "TEXT",
                nullable: false,
                defaultValue: "");


            migrationBuilder.AddColumn<string>(
                name: "CreatedAt",
                table: "Product",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedAt",
                table: "Product",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedAt",
                table: "Musteris",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedAt",
                table: "Musteris",
                type: "TEXT",
                nullable: false,
                defaultValue: "");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            



            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Siparis");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Siparis");

            migrationBuilder.DropColumn(
                name: "musteriId",
                table: "Siparis");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Musteris");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Musteris");
        }
    }
}
