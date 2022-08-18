using Front_Proyecto_2.Helpers;
using Front_Proyecto_2.Interfaces;
using Front_Proyecto_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Front_Proyecto_2.Controllers
{
    public class DispatcherController : Controller
    {
        private readonly IProtectionRoutesService _protectionRoutesService;
        private IDispatcherService _dispatcherService;
        public DispatcherController(IProtectionRoutesService protectionRoutesService, IDispatcherService dispatcherService)
        {
            _protectionRoutesService = protectionRoutesService;
            _dispatcherService = dispatcherService;
        }

        // GET: DispatcherController
        public async Task<ActionResult> Index()
        {
            if (!_protectionRoutesService.ProtectAction())
            {
                return RedirectToAction("Login", "Login");
            }

            List<Dispatcher> Model = null;
            try 
            {
                var response = await this._dispatcherService.GetAllDispatchers();
                Model = response.Data;
            }
            catch (Exception ex)
            {
                ViewData["Message_error"] = "Ocurrio un error al cargar los datos.";
                return View(Model);
            }

            return View(Model);
        }

        // GET: DispatcherController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DispatcherController/Create
        public ActionResult Create()
        {
            if (!_protectionRoutesService.ProtectAction())
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }

        // POST: DispatcherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                Dispatcher dispatcher = new Dispatcher();
                dispatcher.Name = collection["Name"];

                var response = await this._dispatcherService.AddDispatcher(dispatcher);
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

        // GET: DispatcherController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DispatcherController/Edit/5
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

        // GET: DispatcherController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DispatcherController/Delete/5
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
