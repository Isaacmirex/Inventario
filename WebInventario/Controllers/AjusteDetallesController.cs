using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebInventario.Code;
using WebInventario.Data;
using WebInventario.Models;

namespace WebInventario.Controllers
{
    public class AjusteDetallesController : Controller
    {
        private string urlBase;

        public AjusteDetallesController(IConfiguration config)
        {
            urlBase = config["UrlBase"].ToString() + "AjusteDetalles/";
        }

        private List<SelectListItem> listaProducto()
        {
            var productos = ApiConsumer<Producto>.Select(urlBase.Replace("AjusteDetalles", "Productoes"))
                                                                                 .OrderBy(p => p.prod_id);

            var activoProductos = productos.Where(p => p.prod_estado == true);

            var lista = activoProductos.Select(d => new SelectListItem
            {
                Value = d.prod_id.ToString(),
                Text = d.prod_nombre + " - " + d.prod_id
            })
            .ToList();
            return lista;
        }
        
        private List<SelectListItem> listaCabecera()
        {
            var cabeceras = ApiConsumer<AjusteCabecera>.Select(urlBase.Replace("AjusteDetalles", "AjusteCabeceras"));
            var lista = cabeceras.Select(d => new SelectListItem
            {
                Value = d.cab_id.ToString(),
                Text = d.cab_id + " - " + d.cab_descripcion
            })
            .ToList();
            return lista;
        }

        // GET: AjusteDetallesContoller
        public ActionResult Index(string? searchFor)
        {
            ViewBag.searchFor = "" + searchFor;
            if (string.IsNullOrWhiteSpace(searchFor))
            {
                var data = ApiConsumer<AjusteDetalle>.Select(urlBase);
                return View(data);
            }
            else
            {
                var data = ApiConsumer<AjusteDetalle>.Select_SearchFor(urlBase, searchFor);
                return View(data);
            }
        }

        // GET: AjusteDetallesContoller/Details/5
        public ActionResult Details(string id)
        {
            var data = ApiConsumer<AjusteDetalle>.Select_One(urlBase + id.ToString());
            return View(data);
        }

        // GET: AjusteDetallesContoller/Create
        public ActionResult Create()
        {
            ViewBag.ListaProducto = listaProducto();
            ViewBag.ListaAjusCabecera = listaCabecera();
            return View();
        }

        // POST: AjusteDetallesContoller/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AjusteDetalle data)
        {
            try
            {
                ApiConsumer<AjusteDetalle>.Insertar(urlBase, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: AjusteDetallesContoller/Edit/5
        public ActionResult Edit(string id)
        {
            var data = ApiConsumer<AjusteDetalle>.Select_One(urlBase + id.ToString());
            ViewBag.ListaProducto = listaProducto();
            ViewBag.ListaAjusCabecera = listaCabecera();
            return View(data);
        }

        // POST: AjusteDetallesContoller/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, AjusteDetalle data)
        {
            try
            {
                ApiConsumer<AjusteDetalle>.Actualizar(urlBase + id.ToString(), data);
                return RedirectToAction(nameof(Index));                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: AjusteDetallesContoller/Delete/5
        public ActionResult Delete(string id)
        {
            var data = ApiConsumer<AjusteDetalle>.Select_One(urlBase + id.ToString());
            return View(data);
        }

        // POST: AjusteDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, AjusteDetalle data)
        {
            try
            {
                ApiConsumer<AjusteDetalle>.Eliminar(urlBase + id.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        public ActionResult GenerarKardex(string idProducto)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Document doc = new Document(PageSize.A4, 5, 5, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                doc.Open();

                Paragraph p = new Paragraph("Módulo de Inventario", new Font(Font.FontFamily.HELVETICA, 20, Font.BOLD));
                p.Alignment = Element.ALIGN_CENTER;
                doc.Add(p);

                Paragraph p2 = new Paragraph("Reporte Kardex", new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD));
                p2.Alignment = Element.ALIGN_CENTER;
                doc.Add(p2);

                var data = ApiConsumer<AjusteDetalle>.Select(urlBase);
                var data2 = ApiConsumer<Producto>.Select(urlBase.Replace("AjusteDetalles", "Productoes"));
                var data3 = ApiConsumer<Historial>.Select(urlBase.Replace("AjusteDetalles", "Historials"));

                PdfPTable table = new PdfPTable(5);
                table.WidthPercentage = 100;
                table.HorizontalAlignment = Element.ALIGN_CENTER;
                table.SpacingBefore = 10;
                table.SpacingAfter = 10;

                PdfPCell cell = new PdfPCell(new Phrase("Kardex", new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD)));
                cell.Colspan = 5;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                table.AddCell(cell);

                PdfPCell cell2 = new PdfPCell(new Phrase("ID Producto", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
                cell2.Colspan = 4;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.BackgroundColor = BaseColor.LIGHT_GRAY;
                table.AddCell(cell2);
                table.AddCell(idProducto);

                PdfPCell cell3 = new PdfPCell(new Phrase("Nombre Producto", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
                cell3.Colspan = 4;
                cell3.HorizontalAlignment = Element.ALIGN_CENTER;
                cell3.BackgroundColor = BaseColor.LIGHT_GRAY;
                table.AddCell(cell3);

                var filteredProducts = data2.Where(x =>
                                        x.prod_id == idProducto);
                foreach (var item in filteredProducts)
                {
                    table.AddCell(item.prod_nombre.ToString());
                }

                table.AddCell("Fecha");
                table.AddCell("Documento");
                table.AddCell("Descripción");
                table.AddCell("Cantidad");
                table.AddCell("Stock");

                var filterDate = data3.Where(x => x.historial_descripcion == idProducto)
                                               .OrderByDescending(x => x.historial_fecha);
                foreach (var item in filterDate)
                {
                    if (item.historial_descripcion == idProducto)
                    {
                        table.AddCell(item.historial_fecha.ToString("dd/MM/yyyy HH:mm:ss"));
                        table.AddCell(item.historial_documento);
                        table.AddCell(item.historial_cab_descripcion);
                        table.AddCell(item.historial_cantidad.ToString());
                        table.AddCell(item.historial_stock.ToString());
                    }
                }
                doc.Add(table);
                doc.Close();

                return File(ms.ToArray(), "application/pdf", "ReporteKardex.pdf");
            }
            return View();                   
        }

        public ActionResult GenerarKardexFechas(string idProducto, DateTime fechaInicio, DateTime fechaFinal)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Document doc = new Document(PageSize.A4, 5, 5, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                doc.Open();

                Paragraph p = new Paragraph("Módulo de Inventario", new Font(Font.FontFamily.HELVETICA, 20, Font.BOLD));
                p.Alignment = Element.ALIGN_CENTER;
                doc.Add(p);

                Paragraph p2 = new Paragraph("Reporte Kardex", new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD));
                p2.Alignment = Element.ALIGN_CENTER;
                doc.Add(p2);

                var data = ApiConsumer<AjusteDetalle>.Select(urlBase);
                var data2 = ApiConsumer<Producto>.Select(urlBase.Replace("AjusteDetalles", "Productoes"));
                var data3 = ApiConsumer<Historial>.Select(urlBase.Replace("AjusteDetalles", "Historials"));

                int saldoInicial = 0;
                int saldoFinal = 0;

                var filtrarFecha = data3.Where(x => x.historial_descripcion == idProducto)
                                                    .OrderBy(x => x.historial_fecha)
                                                    .ToList();
                foreach (var item in filtrarFecha)
                {
                    if (item.historial_fecha <= fechaInicio)
                    {
                        saldoInicial = item.historial_stock;
                    }

                    if (item.historial_fecha <= fechaFinal)
                    {
                        saldoFinal = item.historial_stock;
                    }
                }

                Paragraph p3 = new Paragraph("Saldo Inicial: " + saldoInicial +" "+ "Fecha Inicio: " + fechaInicio.ToString("dd/MM/yyyy HH:mm:ss"), new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD));               
                p3.Alignment = Element.ALIGN_LEFT;
                doc.Add(p3);

                PdfPTable table = new PdfPTable(5);
                table.WidthPercentage = 100;
                table.HorizontalAlignment = Element.ALIGN_CENTER;
                table.SpacingBefore = 10;
                table.SpacingAfter = 10;

                PdfPCell cell = new PdfPCell(new Phrase("Kardex", new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD)));
                cell.Colspan = 5;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                table.AddCell(cell);

                PdfPCell cell2 = new PdfPCell(new Phrase("ID Producto", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
                cell2.Colspan = 4;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.BackgroundColor = BaseColor.LIGHT_GRAY;
                table.AddCell(cell2);
                table.AddCell(idProducto);

                PdfPCell cell3 = new PdfPCell(new Phrase("Nombre Producto", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
                cell3.Colspan = 4;
                cell3.HorizontalAlignment = Element.ALIGN_CENTER;
                cell3.BackgroundColor = BaseColor.LIGHT_GRAY;
                table.AddCell(cell3);

                var filteredProducts = data2.Where(x =>
                                        x.prod_id == idProducto);
                foreach (var item in filteredProducts)
                {
                    table.AddCell(item.prod_nombre.ToString());
                }

                table.AddCell("Fecha");
                table.AddCell("Documento");
                table.AddCell("Descripción");
                table.AddCell("Cantidad");
                table.AddCell("Stock");

                var filterAjustes = data3.Where(x => x.historial_fecha >= fechaInicio &&
                                     x.historial_fecha <= fechaFinal).OrderByDescending(x => x.historial_fecha);
                
                foreach (var item in filterAjustes)
                {
                    if (item.historial_descripcion == idProducto)
                    {
                        table.AddCell(item.historial_fecha.ToString("dd/MM/yyyy HH:mm:ss"));
                        table.AddCell(item.historial_documento);
                        table.AddCell(item.historial_cab_descripcion);
                        table.AddCell(item.historial_cantidad.ToString());
                        table.AddCell(item.historial_stock.ToString());
                    }
                }

                Paragraph p4 = new Paragraph("Saldo Final: " + saldoFinal + " " + "Fecha Final: " + fechaFinal.ToString("dd/MM/yyyy HH:mm:ss"), new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD));
                p4.Alignment = Element.ALIGN_LEFT;
                doc.Add(p4);
                
                doc.Add(table);
                doc.Close();

                return File(ms.ToArray(), "application/pdf", "ReporteKardex.pdf");
            }
            return View();
        }
    }
}



