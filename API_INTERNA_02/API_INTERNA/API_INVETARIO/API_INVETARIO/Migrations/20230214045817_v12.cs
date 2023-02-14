using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APISTOCK.Migrations
{
    /// <inheritdoc />
    public partial class v12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "prod_pvp",
                table: "producto",
                type: "text",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "prod_costo",
                table: "producto",
                type: "text",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "prod_pvp",
                table: "producto",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<decimal>(
                name: "prod_costo",
                table: "producto",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
