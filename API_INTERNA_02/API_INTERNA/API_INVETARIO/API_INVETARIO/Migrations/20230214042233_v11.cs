using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APISTOCK.Migrations
{
    /// <inheritdoc />
    public partial class v11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "prod_pvp",
                table: "producto",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "prod_costo",
                table: "producto",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "prod_pvp",
                table: "producto",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "prod_costo",
                table: "producto",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");
        }
    }
}
