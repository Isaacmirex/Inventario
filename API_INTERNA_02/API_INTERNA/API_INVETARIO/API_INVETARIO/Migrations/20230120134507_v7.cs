using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APISTOCK.Migrations
{
    /// <inheritdoc />
    public partial class v7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ajustedetalle_producto_Productoprod_id",
                table: "ajustedetalle");

            migrationBuilder.AlterColumn<string>(
                name: "Productoprod_id",
                table: "ajustedetalle",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "historial",
                columns: table => new
                {
                    historialid = table.Column<string>(name: "historial_id", type: "text", nullable: false),
                    historialfecha = table.Column<DateTime>(name: "historial_fecha", type: "timestamp with time zone", nullable: false),
                    historialdescripcion = table.Column<string>(name: "historial_descripcion", type: "text", nullable: false),
                    historialcantidad = table.Column<int>(name: "historial_cantidad", type: "integer", nullable: false),
                    hostorialstock = table.Column<int>(name: "hostorial_stock", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historial", x => x.historialid);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ajustedetalle_producto_Productoprod_id",
                table: "ajustedetalle",
                column: "Productoprod_id",
                principalTable: "producto",
                principalColumn: "prod_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ajustedetalle_producto_Productoprod_id",
                table: "ajustedetalle");

            migrationBuilder.DropTable(
                name: "historial");

            migrationBuilder.AlterColumn<string>(
                name: "Productoprod_id",
                table: "ajustedetalle",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_ajustedetalle_producto_Productoprod_id",
                table: "ajustedetalle",
                column: "Productoprod_id",
                principalTable: "producto",
                principalColumn: "prod_id");
        }
    }
}
