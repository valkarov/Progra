using Newtonsoft.Json;
using Progra_Avanzada_Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Progra_Avanzada_Proyecto.Controllers
{
    public class ProductosController : Controller
    {
        private readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44356/api/")
        };

        // GET: Productos
        public async Task<ActionResult> Index()
        {

            List<ProductosViewModel> productos = new List<ProductosViewModel>();
            HttpResponseMessage response = await client.GetAsync("Productos");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                productos = JsonConvert.DeserializeObject<List<ProductosViewModel>>(jsonString);
            }
            else
            {
                // Si la API no responde o hay un error, aún devuelves una lista vacía
                productos = new List<ProductosViewModel>();
                ViewBag.ErrorMessage = "Error al cargar los datos.";
            }
            return View(productos); // Pasamos la lista de productos a la vista, que puede ser vacía pero no null
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductosViewModel producto)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("Productos", producto);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(producto);
        }

        // GET: Productos/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ProductosViewModel producto = null;
            HttpResponseMessage response = await client.GetAsync($"Productos/{id}");
            if (response.IsSuccessStatusCode)
            {
                producto = await response.Content.ReadAsAsync<ProductosViewModel>();
            }
            return View(producto);
        }

        // POST: Productos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ProductosViewModel producto)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PutAsJsonAsync($"Productos/{id}", producto);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(producto);
        }

        // GET: Productos/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"Productos/{id}");
            return RedirectToAction("Index");
        }
    }

}