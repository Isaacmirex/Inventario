using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebInventario.Code;
using WebInventario.Data;
using WebInventario.Models;

namespace WebInventario.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly string urlBase;

        public CategoriasController(IConfiguration config)
        {
            urlBase = config["urlBase"].ToString() + "Categorias/";
        }

        // GET: CategoriasController
        public ActionResult Index(string? searchFor)
        {
            ViewBag.searchFor = "" + searchFor;
            if (string.IsNullOrWhiteSpace(searchFor))
            {
                var data = ApiConsumer<Categoria>.Select(urlBase).OrderBy(c => c.cat_id);
                return View(data);
            }
            else
            {
                var data = ApiConsumer<Categoria>.Select_SearchFor(urlBase, searchFor);
                return View(data);
            }
        }

        // GET: CategoriasController/Details/5
        public ActionResult Details(string id)
        {
            var data = ApiConsumer<Categoria>.Select_One(urlBase + id.ToString());
            return View(data);
        }

        // GET: CategoriasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriasController/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            try
            {
                ApiConsumer<Categoria>.Insertar(urlBase, categoria);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(categoria);
            }
        }

        // GET: CategoriasController/Edit/5
        public ActionResult Edit(string id)
        {
            var data = ApiConsumer<Categoria>.Select_One(urlBase + id.ToString());
            return View(data);
        }

        // POST: CategoriasController/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Categoria categoria)
        {
            try
            {
                ApiConsumer<Categoria>.Actualizar(urlBase + id.ToString(), categoria);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(categoria);
            }
        }

        // GET: CategoriasController/Delete/5
        public ActionResult Delete(string id)
        {
            var data = ApiConsumer<Categoria>.Select_One(urlBase + id.ToString());
            return View(data);
        }

        // POST: CategoriasController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, Categoria categoria)
        {
            try
            {
                ApiConsumer<Categoria>.Eliminar(urlBase + id.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(categoria);
            }
        }
    }
}
