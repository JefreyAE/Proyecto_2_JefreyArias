using Front_Proyecto_2.Helpers;
using Front_Proyecto_2.Interfaces;
using Front_Proyecto_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Front_Proyecto_2.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IProtectionRoutesService _protectionRoutesService;
        private IArticleService _articleService;
        private IDispatcherService _dispatcherService;
        private IClientService _clientService;

        public ArticleController(IProtectionRoutesService protectionRoutesService, IArticleService articleService, IDispatcherService dispatcherService, IClientService clientService)
        {
            _protectionRoutesService = protectionRoutesService;
            _articleService = articleService;
            _dispatcherService = dispatcherService;
            _clientService = clientService;
        }

        // GET: ArticleController
        public async Task<ActionResult> Index()
        {
            if (!_protectionRoutesService.ProtectAction())
            {
                return RedirectToAction("Login", "Login");
            }

            List<Article> Model = new List<Article>();
            try
            {
                var response = await this._articleService.GetAllArticles();
                if (response.Data != null)
                {
                    Model = response.Data;
                }
            }
            catch (Exception ex)
            {
                ViewData["Message_error"] = "Ocurrio un error al cargar los datos.";
                return View(Model);
            }

            return View(Model);
        }

        // GET: ArticleController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (!_protectionRoutesService.ProtectAction())
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        // GET: ArticleController/Create
        public async Task<ActionResult> Create()
        {
            if (!_protectionRoutesService.ProtectAction())
            {
                return RedirectToAction("Login", "Login");
            }

            await this.loadSelectValues();

            return View();
        }

        public async Task loadSelectValues()
        {
            var responseDispatcher = await this._dispatcherService.GetAllDispatchers();
            List<Dispatcher> dispatcherList = new List<Dispatcher>();
            if (responseDispatcher.Data != null)
            {
                dispatcherList = responseDispatcher.Data;
            }
            ViewBag.dispatcherList = dispatcherList;

            var responseClient = await this._clientService.GetAllClients();
            List<Client> clientList = new List<Client>();
            if (responseDispatcher.Data != null)
            {
                clientList = responseClient.Data;
            }
            ViewBag.clientList = clientList;

        }

        // POST: ArticleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            if (!_protectionRoutesService.ProtectAction())
            {
                return RedirectToAction("Login", "Login");
            }

            try
            {
                Article article = new Article();
                article.AdmissionDate =Convert.ToDateTime(collection["AdmissionDate"]);
                article.Price = Convert.ToDouble(collection["Price"]);
                article.Weight = Convert.ToDouble(collection["Weight"]);
                article.Description = collection["Description"];
                article.ClientId = Convert.ToInt32(collection["ClientId"]);
                article.DispatcherId = Convert.ToInt32(collection["DispatcherId"]);
                article.State = "Almacenado";
                article.TrackingId = "";

                var response = await this._articleService.AddArticle(article);
                if (response != null)
                {
                    if (response.Success == true)
                    {
                        ViewData["Message_success"] = "El registro se ha efectuado correctamente.";
                        await this.loadSelectValues();
                        return View();
                    }
                    else
                    {
                        ViewData["Message_error"] = response.Message;
                        await this.loadSelectValues();
                        return View();
                    }
                }
                ViewData["Message_error"] = "Ocurrio un error al registrar los datos.";
                await this.loadSelectValues();
                return View();

            }
            catch (Exception ex)
            {
                ViewData["Message_error"] = "Ocurrio un error al registrar los datos.";
                await this.loadSelectValues();
                return View();
            }
        }

        // GET: ArticleController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: ArticleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
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

        // GET: ArticleController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (!_protectionRoutesService.ProtectAction())
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }

        // POST: ArticleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (!_protectionRoutesService.ProtectAction())
            {
                return RedirectToAction("Login", "Login");
            }
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
