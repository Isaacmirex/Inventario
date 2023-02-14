using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APISTOCK.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AjusteDetalleProducto");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "AjusteDetalleProducto",
                columns: table => new
                {
                    AjusteDetalledetid = table.Column<string>(name: "AjusteDetalledet_id", type: "text", nullable: false),
                    Productoprodid = table.Column<string>(name: "Productoprod_id", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AjusteDetalleProducto", x => new { x.AjusteDetalledetid, x.Productoprodid });
                    table.ForeignKey(
                        name: "FK_AjusteDetalleProducto_ajustedetalle_AjusteDetalledet_id",
                        column: x => x.AjusteDetalledetid,
                        principalTable: "ajustedetalle",
                        principalColumn: "det_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AjusteDetalleProducto_producto_Productoprod_id",
                        column: x => x.Productoprodid,
                        principalTable: "producto",
                        principalColumn: "prod_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AjusteDetalleProducto_Productoprod_id",
                table: "AjusteDetalleProducto",
                column: "Productoprod_id");
        }
    }
}
