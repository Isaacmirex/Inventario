using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APISTOCK.Migrations
{
    /// <inheritdoc />
    public partial class v10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "prod_pvp",
                table: "producto",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "prod_costo",
                table: "producto",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "prod_pvp",
                table: "producto",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "prod_costo",
                table: "producto",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }
    }
}
