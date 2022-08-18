using Front_Proyecto_2.Helpers;
using Front_Proyecto_2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Front_Proyecto_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProtectionRoutesService _protectionRoutesService;

        public HomeController(ILogger<HomeController> logger, IProtectionRoutesService protectionRoutesService)
        {
            _logger = logger;
            _protectionRoutesService = protectionRoutesService;
        }

        public IActionResult Index()
        {
            if (!_protectionRoutesService.ProtectAction())
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}