using Front_Proyecto_2.Helpers;
using Front_Proyecto_2.Interfaces;
using Front_Proyecto_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Front_Proyecto_2.Controllers
{
    public class ClientController : Controller
    {
        private readonly IProtectionRoutesService _protectionRoutesService;
        private IClientService _clientService;

        public ClientController(IProtectionRoutesService protectionRoutesService, IClientService clientService)
        {
            _protectionRoutesService = protectionRoutesService;
            _clientService = clientService;
        }

        // GET: ClientController
        public async Task<ActionResult> Index()
        {
            if (!_protectionRoutesService.ProtectAction())
            {
                return RedirectToAction("Login", "Login");
            }

            List<Client> Model = new List<Client>();
            try
            {
                var response = await this._clientService.GetAllClients();
                Model = response.Data;
            }
            catch (Exception ex)
            {
                ViewData["Message_error"] = "Ocurrio un error al cargar los datos.";
                return View(Model);
            }

            return View(Model);
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                Client client = new Client();
                client.Name = collection["Name"];
                client.ClientPersonalId = Convert.ToInt32(collection["ClientPersonalId"]);
                client.Birthday = Convert.ToDateTime(collection["Birthday"]);

                var response = await this._clientService.AddClient(client);
                if (response != null)
                {
                    if (response.Success == true)
                    {
                        ViewData["Message_success"] = "El registro se ha efectuado correctamente.";
                        return View();
                    }
                    else
                    {
                        ViewData["Message_error"] = response.Message;
                        return View();
                    }
                }
                ViewData["Message_error"] = "Ocurrio un error al registrar los datos.";
                return View();

            }
            catch (Exception ex)
            {
                ViewData["Message_error"] = "Ocurrio un error al registrar los datos.";
                return View();
            }
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
