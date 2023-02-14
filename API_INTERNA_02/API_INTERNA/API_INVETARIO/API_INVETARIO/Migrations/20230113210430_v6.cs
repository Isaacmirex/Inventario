using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APISTOCK.Migrations
{
    /// <inheritdoc />
    public partial class v6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_producto_ajustedetalle_AjusteDetalledet_id",
                table: "producto");

            migrationBuilder.DropIndex(
                name: "IX_producto_AjusteDetalledet_id",
                table: "producto");

            migrationBuilder.DropColumn(
                name: "AjusteDetalledet_id",
                table: "producto");

            migrationBuilder.AddColumn<string>(
                name: "Productoprod_id",
                table: "ajustedetalle",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ajustedetalle_Productoprod_id",
                table: "ajustedetalle",
                column: "Productoprod_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ajustedetalle_producto_Productoprod_id",
                table: "ajustedetalle",
                column: "Productoprod_id",
                principalTable: "producto",
                principalColumn: "prod_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ajustedetalle_producto_Productoprod_id",
                table: "ajustedetalle");

            migrationBuilder.DropIndex(
                name: "IX_ajustedetalle_Productoprod_id",
                table: "ajustedetalle");

            migrationBuilder.DropColumn(
                name: "Productoprod_id",
                table: "ajustedetalle");

            migrationBuilder.AddColumn<string>(
                name: "AjusteDetalledet_id",
                table: "producto",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_producto_AjusteDetalledet_id",
                table: "producto",
                column: "AjusteDetalledet_id");

            migrationBuilder.AddForeignKey(
                name: "FK_producto_ajustedetalle_AjusteDetalledet_id",
                table: "producto",
                column: "AjusteDetalledet_id",
                principalTable: "ajustedetalle",
                principalColumn: "det_id");
        }
    }
}
