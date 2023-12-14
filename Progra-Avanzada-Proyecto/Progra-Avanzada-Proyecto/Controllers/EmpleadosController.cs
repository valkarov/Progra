using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Progra_Avanzada_Proyecto.Models;
using System.Web.Mvc;
using System.Collections.Generic;
using System;

namespace Progra_Avanzada_Proyecto.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44356/api/")
        };

        // GET: Empleados
        public async Task<ActionResult> Index()
        {
            List<EmpleadosViewModel> empleados = new List<EmpleadosViewModel>();
            HttpResponseMessage response = await client.GetAsync("Empleados");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                empleados = JsonConvert.DeserializeObject<List<EmpleadosViewModel>>(jsonString);
            }
            return View(empleados);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleados/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EmpleadosViewModel empleado)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("Empleados", empleado);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            EmpleadosViewModel empleado = null;
            HttpResponseMessage response = await client.GetAsync($"Empleados/{id}");
            if (response.IsSuccessStatusCode)
            {
                empleado = await response.Content.ReadAsAsync<EmpleadosViewModel>();
            }
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, EmpleadosViewModel empleado)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PutAsJsonAsync($"Empleados/{id}", empleado);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"Empleados/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
           
            return RedirectToAction("Index");
        }
    }
}
