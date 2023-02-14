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
    public class HistorialsController : Controller
    {
        private string urlBase;

        public HistorialsController(IConfiguration config)
        {
            urlBase = config["UrlBase"].ToString() + "Historials/";
        }

        // GET: Historials
        public ActionResult Index(string? searchFor)
        {
            ViewBag.searchFor = "" + searchFor;

            if (string.IsNullOrWhiteSpace(searchFor))
            {
                var data = ApiConsumer<Historial>.Select(urlBase)
                                                .OrderByDescending(x => x.historial_fecha).ToList();
                return View(data);
            }
            else
            {
                var data = ApiConsumer<Historial>.Select_SearchFor(urlBase, searchFor);
                return View(data);
            }
        }

        // GET: Historials/Details/5
        public ActionResult Details(string id)
        {
            var data = ApiConsumer<Historial>.Select_One(urlBase + id.ToString());
            return View(data);
        }

        // GET: Historials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Historials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Historial data)
        {
            try
            {
                ApiConsumer<Historial>.Insertar(urlBase, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: Historials/Edit/5
        public ActionResult Edit(string id)
        {
            var data = ApiConsumer<Historial>.Select_One(urlBase + id.ToString());
            return View(data);
        }

        // POST: Historials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Historial data)
        {
            try
            {
                ApiConsumer<Historial>.Actualizar(urlBase + id.ToString(), data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: Historials/Delete/5
        public ActionResult Delete(string id)
        {
            var data = ApiConsumer<Historial>.Select_One(urlBase + id.ToString());
            return View(data);
        }

        // POST: Historials/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, Historial data)
        {
            try
            {
                ApiConsumer<Historial>.Eliminar(urlBase + id.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }
    }
}
