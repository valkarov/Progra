using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Progra_Avanzada_Proyecto.Models;
using System.Web.Mvc;
using System.Collections.Generic;
using System;

namespace Progra_Avanzada_Proyecto.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44356/api/")
        };

        // GET: Usuarios
        public async Task<ActionResult> Index()
        {
            List<UsuariosViewModel> usuarios = new List<UsuariosViewModel>();
            HttpResponseMessage response = await client.GetAsync("Usuarios");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                usuarios = JsonConvert.DeserializeObject<List<UsuariosViewModel>>(jsonString);
            }
            return View(usuarios);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UsuariosViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("Usuarios", usuario);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            UsuariosViewModel usuario = null;
            HttpResponseMessage response = await client.GetAsync($"Usuarios/{id}");
            if (response.IsSuccessStatusCode)
            {
                usuario = await response.Content.ReadAsAsync<UsuariosViewModel>();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UsuariosViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PutAsJsonAsync($"Usuarios/{id}", usuario);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"Usuarios/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
