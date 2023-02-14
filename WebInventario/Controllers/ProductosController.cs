using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Pkcs;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebInventario.Code;
using WebInventario.Data;
using WebInventario.Models;

namespace WebInventario.Controllers
{
    public class ProductosController : Controller
    {
        private string urlBase;

        public ProductosController(IConfiguration config)
        {
            urlBase = config["urlBase"]+ "Productoes/";
        }
                  
        private List<SelectListItem> listaCategoria()
        {
            var categoria = ApiConsumer<Categoria>.Select(urlBase.Replace("Productoes", "Categorias"));
            var lista = categoria.Select(c => new SelectListItem
            {
                Value = c.cat_id.ToString(),
                Text = c.cat_id + " - " + c.cat_nombre
            })
            .ToList();
            return lista;
            
        }

        // GET: ProductoesController
        public ActionResult Index(string? searchFor)
        {
            ViewBag.searchFor = "" + searchFor;
            
            if (string.IsNullOrWhiteSpace(searchFor))
            {
                var data = ApiConsumer<Producto>.Select(urlBase).OrderBy(p => p.prod_id);
                return View(data);
            }
            else
            {
                var data = ApiConsumer<Producto>.Select_SearchFor(urlBase, searchFor);
                return View(data);
            }
        }

        // GET: ProductoesController/Details/5
        public ActionResult Details(string id)
        {
            var data = ApiConsumer<Producto>.Select_One(urlBase + id.ToString());
            return View(data);           
        }

        // GET: ProductoesController/Create
        public ActionResult Create()
        {
            ViewBag.ListaCategoria = listaCategoria();
            return View();
        }

        // POST: ProductoesController/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Producto data)
        {
            try
            {
                
                ApiConsumer<Producto>.Insertar(urlBase, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: ProductoesController/Edit/5
        public ActionResult Edit(string id)
        {
            var data = ApiConsumer<Producto>.Select_One(urlBase + id.ToString());
            ViewBag.ListaCategoria = listaCategoria();
            return View(data);
        }

        // POST: ProductoesController/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Producto data)
        {
            try
            {
                ApiConsumer<Producto>.Actualizar(urlBase + id.ToString(), data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: ProductoesController/Delete/5
        public ActionResult Delete(string id)
        {
            var data = ApiConsumer<Producto>.Select_One(urlBase + id.ToString());
            return View(data);
        }

        // POST: ProductoesController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, Producto data)
        {
            try
            {
                ApiConsumer<Producto>.Eliminar(urlBase + id.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }
        
        public ActionResult PDF()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Document doc = new Document(PageSize.A4, 5, 5, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                doc.Open();

                //agregar un encabezado del reporte
                Paragraph p = new Paragraph("Módulo de Inventario", new Font(Font.FontFamily.HELVETICA, 20, Font.BOLD));
                p.Alignment = Element.ALIGN_CENTER;

                //poner la fecha actual
                var fecha = DateTime.Now;

                //agregar la fecha al documento
                Paragraph p2 = new Paragraph("Fecha: " + fecha.ToString("dd/MM/yyyy"), new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD));
                p2.Alignment = Element.ALIGN_CENTER;

                doc.Add(p);
                doc.Add(p2);

                Paragraph paragraph = new Paragraph("Reporte de Productos con su Stock", new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD));
                paragraph.Alignment = Element.ALIGN_CENTER;
                doc.Add(paragraph);
                Paragraph espacio = new Paragraph("              ");
                doc.Add(espacio);
                doc.AddTitle("Reporte de Productos con su Stock");

                PdfPTable pTable = new PdfPTable(3);

                PdfPCell cell1 = new PdfPCell(new Phrase("ID Producto", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
                cell1.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                cell1.VerticalAlignment = Element.ALIGN_CENTER;
                pTable.AddCell(cell1);

                PdfPCell cell2 = new PdfPCell(new Phrase("Nombre Producto", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
                cell2.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_CENTER;
                pTable.AddCell(cell2);

                PdfPCell cell3= new PdfPCell(new Phrase("Stock", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
                cell3.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell3.HorizontalAlignment = Element.ALIGN_CENTER;
                cell3.VerticalAlignment = Element.ALIGN_CENTER;
                pTable.AddCell(cell3);

                var filterData = ApiConsumer<Producto>.Select(urlBase).OrderBy(x => x.prod_id).ToList();

                foreach (Producto producto in filterData)
                {
                    PdfPCell cell_1 = new PdfPCell(new Phrase(producto.prod_id.ToString(), new Font(Font.FontFamily.HELVETICA, 11, Font.NORMAL)));
                    PdfPCell cell_2 = new PdfPCell(new Phrase(producto.prod_nombre.ToString(), new Font(Font.FontFamily.HELVETICA, 11, Font.NORMAL)));
                    PdfPCell cell_3 = new PdfPCell(new Phrase(producto.prod_stock.ToString(), new Font(Font.FontFamily.HELVETICA, 11, Font.NORMAL)));                   

                    cell_1.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell_2.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell_3.HorizontalAlignment = Element.ALIGN_CENTER;

                    pTable.AddCell(cell_1);
                    pTable.AddCell(cell_2);
                    pTable.AddCell(cell_3);
                }

                doc.Add(pTable);
                doc.Close();
                writer.Close();
                var constant = ms.ToArray();
                return File(constant, "application/vnd", "Report.pdf");
            }
            return View();
        }
    }
}
