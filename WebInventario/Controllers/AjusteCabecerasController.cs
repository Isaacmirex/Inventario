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
    public class AjusteCabecerasController : Controller
    {
        private string urlBase;

        public AjusteCabecerasController(IConfiguration config)
        {
            urlBase = config["UrlBase"] + "AjusteCabeceras/";
        }

        // GET: AjusteCabecerasController
        public ActionResult Index(string? searchFor)
        {
            ViewBag.searchFor = "" + searchFor;
            if (string.IsNullOrWhiteSpace(searchFor))
            {
                var data = ApiConsumer<AjusteCabecera>.Select(urlBase);
                return View(data);
            }
            else
            {
                var data = ApiConsumer<AjusteCabecera>.Select_SearchFor(urlBase, searchFor);
                return View(data);
            }
        }

        // GET: AjusteCabecerasController/Details/5
        public ActionResult Details(string id)
        {
            var data = ApiConsumer<AjusteCabecera>.Select_One(urlBase + id.ToString());
            return View(data);
        }

        // GET: AjusteCabecerasController/Create
        public ActionResult Create()
        {            
            return View();
        }

        // POST: AjusteCabeceras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AjusteCabecera data)
        {
            try
            {
                ApiConsumer<AjusteCabecera>.Insertar(urlBase, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
                
        }

        // GET: AjusteCabecerasController/Edit/5
        public ActionResult Edit(string id)
        {
            var data = ApiConsumer<AjusteCabecera>.Select_One(urlBase + id.ToString());
            return View(data);
        }

        // POST: AjusteCabecerasController/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, AjusteCabecera datos)
        {
            try
            {
                ApiConsumer<AjusteCabecera>.Actualizar(urlBase + id.ToString(), datos);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(datos);
            }
        }

        // GET: AjusteCabecerasController/Delete/5
        public ActionResult Delete(string id)
        {
            var data = ApiConsumer<AjusteCabecera>.Select_One(urlBase + id.ToString());
            return View(data);

        }

        // POST: AjusteCabeceras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, AjusteCabecera datos)
        {
            try
            {
                ApiConsumer<AjusteCabecera>.Eliminar(urlBase + id.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(datos);
            }
        }
    }
}
