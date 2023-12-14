using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Progra_Avanzada_Proyecto.Models;
using System.Web.Mvc;
using System.Collections.Generic;
using System;

namespace Progra_Avanzada_Proyecto.Controllers
{
    public class ClientesController : Controller
    {
        private readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44356/api/")
        };

        // GET: Clientes
        public async Task<ActionResult> Index()
        {
            List<ClientesViewModel> clientes = new List<ClientesViewModel>();
            HttpResponseMessage response = await client.GetAsync("Clientes");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                clientes = JsonConvert.DeserializeObject<List<ClientesViewModel>>(jsonString);
            }
            return View(clientes);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ClientesViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("Clientes", cliente);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ClientesViewModel cliente = null;
            HttpResponseMessage response = await client.GetAsync($"Clientes/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                cliente = JsonConvert.DeserializeObject<ClientesViewModel>(jsonString);
               
                var editViewModel = new ClientesEditViewModel
                {
                    ID = cliente.ID,
                    Nombre = cliente.Nombre,
                    Direccion = cliente.Direccion,
                    Telefono = cliente.Telefono,
                    Email = cliente.Email,
                    PreferenciasDieteticas = cliente.PreferenciasDieteticas
                };
                return View(editViewModel);
            }
            return HttpNotFound();
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ClientesEditViewModel clienteEditViewModel)
        {
            if (ModelState.IsValid)
            {
                var clienteToUpdate = new ClientesViewModel
                {
                    ID = clienteEditViewModel.ID,
                    Nombre = clienteEditViewModel.Nombre,
                    Direccion = clienteEditViewModel.Direccion,
                    Telefono = clienteEditViewModel.Telefono,
                    Email = clienteEditViewModel.Email,
                    PreferenciasDieteticas = clienteEditViewModel.PreferenciasDieteticas

                   
                };
                HttpResponseMessage response = await client.PutAsJsonAsync($"Clientes/{clienteEditViewModel.ID}", clienteToUpdate);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(clienteEditViewModel);
        }

        // GET: Clientes/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"Clientes/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
