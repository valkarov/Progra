using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Progra_Avanzada_Proyecto.Models; 

namespace Progra_Avanzada_Proyecto.Controllers
{
    public class EventosController : Controller
    {
        private HttpClient httpClient = new HttpClient();

        public EventosController()
        {
            
            httpClient.BaseAddress = new Uri("https://localhost:44356/api/");
        }

        // GET: Eventos
        public async Task<ActionResult> Index()
        {
            var response = await httpClient.GetAsync("api/Eventos");
            if (response.IsSuccessStatusCode)
            {
                var eventos = await response.Content.ReadAsAsync<IEnumerable<EmpleadosViewModel>>();
                return View(eventos);
            }
            return View("Error");
        }

        // GET: Eventos/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var response = await httpClient.GetAsync($"api/Eventos/{id}");
            if (response.IsSuccessStatusCode)
            {
                var evento = await response.Content.ReadAsAsync<EmpleadosViewModel>();
                return View(evento);
            }
            return HttpNotFound();
        }

        // GET: Eventos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Eventos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EmpleadosViewModel evento)
        {
            if (ModelState.IsValid)
            {
                var response = await httpClient.PostAsJsonAsync("api/Eventos", evento);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(evento);
        }

        // GET: Eventos/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var response = await httpClient.GetAsync($"api/Eventos/{id}");
            if (response.IsSuccessStatusCode)
            {
                var evento = await response.Content.ReadAsAsync<EmpleadosViewModel>();
                return View(evento);
            }
            return HttpNotFound();
        }

        // POST: Eventos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, EmpleadosViewModel evento)
        {
            if (ModelState.IsValid)
            {
                var response = await httpClient.PutAsJsonAsync($"api/Eventos/{id}", evento);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(evento);
        }

        // GET: Eventos/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var response = await httpClient.GetAsync($"api/Eventos/{id}");
            if (response.IsSuccessStatusCode)
            {
                var evento = await response.Content.ReadAsAsync<EmpleadosViewModel>();
                return View(evento);
            }
            return HttpNotFound();
        }

        // POST: Eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var response = await httpClient.DeleteAsync($"api/Eventos/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }
    }
}
