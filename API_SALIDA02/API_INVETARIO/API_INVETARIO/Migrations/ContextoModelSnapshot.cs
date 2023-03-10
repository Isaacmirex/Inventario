// <auto-generated />
using System;
using API_INVETARIO.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace APISTOCK.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("API_INVETARIO.EFCore.APIs", b =>
                {
                    b.Property<string>("apps_id")
                        .HasColumnType("text");

                    b.Property<string>("Productoprod_id")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("apps_descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("apps_doc_codigo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("apps_documento")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("apps_fecha")
                        .HasColumnType("date");

                    b.Property<string>("apps_modificacion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("apps_id");

                    b.HasIndex("Productoprod_id");

                    b.ToTable("apis");
                });

            modelBuilder.Entity("API_INVETARIO.EFCore.AjusteCabecera", b =>
                {
                    b.Property<string>("cab_id")
                        .HasColumnType("text");

                    b.Property<string>("cab_descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("cab_fecha")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("productoprod_id")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("cab_id");

                    b.HasIndex("productoprod_id");

                    b.ToTable("ajustecabecera");
                });

            modelBuilder.Entity("API_INVETARIO.EFCore.AjusteDetalle", b =>
                {
                    b.Property<string>("det_id")
                        .HasColumnType("text");

                    b.Property<string>("cabeceracab_id")
                        .HasColumnType("text");

                    b.Property<int>("det_catidad")
                        .HasColumnType("integer");

                    b.Property<string>("det_descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("det_documento")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("det_fecha")
                        .HasColumnType("date");

                    b.HasKey("det_id");

                    b.HasIndex("cabeceracab_id");

                    b.ToTable("ajustedetalle");
                });

            modelBuilder.Entity("API_INVETARIO.EFCore.Categoria", b =>
                {
                    b.Property<string>("cat_id")
                        .HasColumnType("text");

                    b.Property<string>("cat_descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("cat_nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("cat_id");

                    b.ToTable("categoria");
                });

            modelBuilder.Entity("API_INVETARIO.EFCore.Producto", b =>
                {
                    b.Property<string>("prod_id")
                        .HasColumnType("text");

                    b.Property<string>("Categoriacat_id")
                        .HasColumnType("text");

                    b.Property<double>("prod_costo")
                        .HasColumnType("double precision");

                    b.Property<string>("prod_descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("prod_estado")
                        .HasColumnType("boolean");

                    b.Property<bool>("prod_iva")
                        .HasColumnType("boolean");

                    b.Property<string>("prod_nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("prod_pvp")
                        .HasColumnType("double precision");

                    b.Property<int>("prod_stock")
                        .HasColumnType("integer");

                    b.HasKey("prod_id");

                    b.HasIndex("Categoriacat_id");

                    b.ToTable("producto");
                });

            modelBuilder.Entity("API_INVETARIO.EFCore.APIs", b =>
                {
                    b.HasOne("API_INVETARIO.EFCore.Producto", "Producto")
                        .WithMany("APIs")
                        .HasForeignKey("Productoprod_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("API_INVETARIO.EFCore.AjusteCabecera", b =>
                {
                    b.HasOne("API_INVETARIO.EFCore.Producto", "producto")
                        .WithMany("AjusteCabecera")
                        .HasForeignKey("productoprod_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("producto");
                });

            modelBuilder.Entity("API_INVETARIO.EFCore.AjusteDetalle", b =>
                {
                    b.HasOne("API_INVETARIO.EFCore.AjusteCabecera", "cabecera")
                        .WithMany("AjusteDetalle")
                        .HasForeignKey("cabeceracab_id");

                    b.Navigation("cabecera");
                });

            modelBuilder.Entity("API_INVETARIO.EFCore.Producto", b =>
                {
                    b.HasOne("API_INVETARIO.EFCore.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("Categoriacat_id");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("API_INVETARIO.EFCore.AjusteCabecera", b =>
                {
                    b.Navigation("AjusteDetalle");
                });

            modelBuilder.Entity("API_INVETARIO.EFCore.Producto", b =>
                {
                    b.Navigation("APIs");

                    b.Navigation("AjusteCabecera");
                });
#pragma warning restore 612, 618
        }
    }
}
