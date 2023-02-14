using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APISTOCK.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ajustecabecera_producto_productoprod_id",
                table: "ajustecabecera");

            migrationBuilder.DropForeignKey(
                name: "FK_ajustedetalle_ajustecabecera_cabeceracab_id",
                table: "ajustedetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_producto_categoria_Categoriacat_id",
                table: "producto");

            migrationBuilder.DropIndex(
                name: "IX_ajustecabecera_productoprod_id",
                table: "ajustecabecera");

            migrationBuilder.DropColumn(
                name: "det_descripcion",
                table: "ajustedetalle");

            migrationBuilder.DropColumn(
                name: "det_documento",
                table: "ajustedetalle");

            migrationBuilder.DropColumn(
                name: "det_fecha",
                table: "ajustedetalle");

            migrationBuilder.RenameColumn(
                name: "productoprod_id",
                table: "ajustecabecera",
                newName: "cab_doc");

            migrationBuilder.AlterColumn<string>(
                name: "Categoriacat_id",
                table: "producto",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AjusteDetalledet_id",
                table: "producto",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "apps_fecha",
                table: "apis",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "cabeceracab_id",
                table: "ajustedetalle",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_producto_AjusteDetalledet_id",
                table: "producto",
                column: "AjusteDetalledet_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ajustedetalle_ajustecabecera_cabeceracab_id",
                table: "ajustedetalle",
                column: "cabeceracab_id",
                principalTable: "ajustecabecera",
                principalColumn: "cab_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_producto_ajustedetalle_AjusteDetalledet_id",
                table: "producto",
                column: "AjusteDetalledet_id",
                principalTable: "ajustedetalle",
                principalColumn: "det_id");

            migrationBuilder.AddForeignKey(
                name: "FK_producto_categoria_Categoriacat_id",
                table: "producto",
                column: "Categoriacat_id",
                principalTable: "categoria",
                principalColumn: "cat_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ajustedetalle_ajustecabecera_cabeceracab_id",
                table: "ajustedetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_producto_ajustedetalle_AjusteDetalledet_id",
                table: "producto");

            migrationBuilder.DropForeignKey(
                name: "FK_producto_categoria_Categoriacat_id",
                table: "producto");

            migrationBuilder.DropIndex(
                name: "IX_producto_AjusteDetalledet_id",
                table: "producto");

            migrationBuilder.DropColumn(
                name: "AjusteDetalledet_id",
                table: "producto");

            migrationBuilder.RenameColumn(
                name: "cab_doc",
                table: "ajustecabecera",
                newName: "productoprod_id");

            migrationBuilder.AlterColumn<string>(
                name: "Categoriacat_id",
                table: "producto",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "apps_fecha",
                table: "apis",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "cabeceracab_id",
                table: "ajustedetalle",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "det_descripcion",
                table: "ajustedetalle",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "det_documento",
                table: "ajustedetalle",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "det_fecha",
                table: "ajustedetalle",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateIndex(
                name: "IX_ajustecabecera_productoprod_id",
                table: "ajustecabecera",
                column: "productoprod_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ajustecabecera_producto_productoprod_id",
                table: "ajustecabecera",
                column: "productoprod_id",
                principalTable: "producto",
                principalColumn: "prod_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ajustedetalle_ajustecabecera_cabeceracab_id",
                table: "ajustedetalle",
                column: "cabeceracab_id",
                principalTable: "ajustecabecera",
                principalColumn: "cab_id");

            migrationBuilder.AddForeignKey(
                name: "FK_producto_categoria_Categoriacat_id",
                table: "producto",
                column: "Categoriacat_id",
                principalTable: "categoria",
                principalColumn: "cat_id");
        }
    }
}
