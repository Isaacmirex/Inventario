using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APISTOCK.Migrations
{
    /// <inheritdoc />
    public partial class v9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "hostorial_stock",
                table: "historial",
                newName: "historial_stock");

            migrationBuilder.AddColumn<string>(
                name: "historial_cab_descripcion",
                table: "historial",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "historial_nombreprod",
                table: "historial",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "historial_cab_descripcion",
                table: "historial");

            migrationBuilder.DropColumn(
                name: "historial_nombreprod",
                table: "historial");

            migrationBuilder.RenameColumn(
                name: "historial_stock",
                table: "historial",
                newName: "hostorial_stock");
        }
    }
}
