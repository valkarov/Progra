using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Progra_Avanzada_Proyecto.Models;
using System.Web.Mvc;
using System.Collections.Generic;
using System;

namespace Progra_Avanzada_Proyecto.Controllers
{
    public class InventarioController : Controller
    {
        private readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44356/api/")
        };

        // GET: Inventario
        public async Task<ActionResult> Index()
        {
            List<InventarioViewModel> inventario = new List<InventarioViewModel>();
            HttpResponseMessage response = await client.GetAsync("Inventarios");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                inventario = JsonConvert.DeserializeObject<List<InventarioViewModel>>(jsonString);
            }
            return View(inventario);
        }

        // GET: Inventario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(InventarioViewModel inventario)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("Inventarios", inventario);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(inventario);
        }

        // GET: Inventario/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            InventarioViewModel inventario = null;
            HttpResponseMessage response = await client.GetAsync($"Inventarios/{id}");
            if (response.IsSuccessStatusCode)
            {
                inventario = await response.Content.ReadAsAsync<InventarioViewModel>();
            }
            return View(inventario);
        }

        // POST: Inventario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, InventarioViewModel inventario)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PutAsJsonAsync($"Inventarios/{id}", inventario);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(inventario);
        }

        // GET: Inventario/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"Inventarios/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
