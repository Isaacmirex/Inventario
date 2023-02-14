using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APISTOCK.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    catid = table.Column<string>(name: "cat_id", type: "text", nullable: false),
                    catnombre = table.Column<string>(name: "cat_nombre", type: "text", nullable: false),
                    catdescripcion = table.Column<string>(name: "cat_descripcion", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.catid);
                });

            migrationBuilder.CreateTable(
                name: "producto",
                columns: table => new
                {
                    prodid = table.Column<string>(name: "prod_id", type: "text", nullable: false),
                    prodnombre = table.Column<string>(name: "prod_nombre", type: "text", nullable: false),
                    proddescripcion = table.Column<string>(name: "prod_descripcion", type: "text", nullable: false),
                    prodiva = table.Column<bool>(name: "prod_iva", type: "boolean", nullable: false),
                    prodcosto = table.Column<double>(name: "prod_costo", type: "double precision", nullable: false),
                    prodpvp = table.Column<double>(name: "prod_pvp", type: "double precision", nullable: false),
                    prodestado = table.Column<bool>(name: "prod_estado", type: "boolean", nullable: false),
                    prodstock = table.Column<int>(name: "prod_stock", type: "integer", nullable: false),
                    Categoriacatid = table.Column<string>(name: "Categoriacat_id", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producto", x => x.prodid);
                    table.ForeignKey(
                        name: "FK_producto_categoria_Categoriacat_id",
                        column: x => x.Categoriacatid,
                        principalTable: "categoria",
                        principalColumn: "cat_id");
                });

            migrationBuilder.CreateTable(
                name: "ajustecabecera",
                columns: table => new
                {
                    cabid = table.Column<string>(name: "cab_id", type: "text", nullable: false),
                    cabdescripcion = table.Column<string>(name: "cab_descripcion", type: "text", nullable: false),
                    cabfecha = table.Column<DateTime>(name: "cab_fecha", type: "timestamp with time zone", nullable: false),
                    productoprodid = table.Column<string>(name: "productoprod_id", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ajustecabecera", x => x.cabid);
                    table.ForeignKey(
                        name: "FK_ajustecabecera_producto_productoprod_id",
                        column: x => x.productoprodid,
                        principalTable: "producto",
                        principalColumn: "prod_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "apis",
                columns: table => new
                {
                    appsid = table.Column<string>(name: "apps_id", type: "text", nullable: false),
                    appsdocumento = table.Column<string>(name: "apps_documento", type: "text", nullable: false),
                    appsdoccodigo = table.Column<string>(name: "apps_doc_codigo", type: "text", nullable: false),
                    appsmodificacion = table.Column<string>(name: "apps_modificacion", type: "text", nullable: false),
                    appsfecha = table.Column<DateOnly>(name: "apps_fecha", type: "date", nullable: false),
                    appsdescripcion = table.Column<string>(name: "apps_descripcion", type: "text", nullable: false),
                    Productoprodid = table.Column<string>(name: "Productoprod_id", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apis", x => x.appsid);
                    table.ForeignKey(
                        name: "FK_apis_producto_Productoprod_id",
                        column: x => x.Productoprodid,
                        principalTable: "producto",
                        principalColumn: "prod_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ajustedetalle",
                columns: table => new
                {
                    detid = table.Column<string>(name: "det_id", type: "text", nullable: false),
                    detfecha = table.Column<DateOnly>(name: "det_fecha", type: "date", nullable: false),
                    detdocumento = table.Column<string>(name: "det_documento", type: "text", nullable: false),
                    detdescripcion = table.Column<string>(name: "det_descripcion", type: "text", nullable: false),
                    detcatidad = table.Column<int>(name: "det_catidad", type: "integer", nullable: false),
                    cabeceracabid = table.Column<string>(name: "cabeceracab_id", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ajustedetalle", x => x.detid);
                    table.ForeignKey(
                        name: "FK_ajustedetalle_ajustecabecera_cabeceracab_id",
                        column: x => x.cabeceracabid,
                        principalTable: "ajustecabecera",
                        principalColumn: "cab_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ajustecabecera_productoprod_id",
                table: "ajustecabecera",
                column: "productoprod_id");

            migrationBuilder.CreateIndex(
                name: "IX_ajustedetalle_cabeceracab_id",
                table: "ajustedetalle",
                column: "cabeceracab_id");

            migrationBuilder.CreateIndex(
                name: "IX_apis_Productoprod_id",
                table: "apis",
                column: "Productoprod_id");

            migrationBuilder.CreateIndex(
                name: "IX_producto_Categoriacat_id",
                table: "producto",
                column: "Categoriacat_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ajustedetalle");

            migrationBuilder.DropTable(
                name: "apis");

            migrationBuilder.DropTable(
                name: "ajustecabecera");

            migrationBuilder.DropTable(
                name: "producto");

            migrationBuilder.DropTable(
                name: "categoria");
        }
    }
}
