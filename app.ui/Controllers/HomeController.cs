using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using app.ui.Models;
using app.service.Anonymous.Command;
using app.service;

namespace app.ui.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAnonymousService _anonymousService;

        public HomeController(ILogger<HomeController> logger,
            IAnonymousService anonymousService)
        {
            _logger = logger;
            _anonymousService = anonymousService;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("RoleReroute", "Authenticate", new { area = "Identity" });
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error404()
        {
            return View();
        }

        public IActionResult Error401()
        {
            return View();
        }

        public IActionResult FAQs()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FAQs(string email, string name, string message)
        {
            var command = new SendFaqCommand
            {
                Email = email,
                Name = name,
                Message = message
            };

            var result = await _anonymousService.SendFaq(command);

            return View();
        }

        public IActionResult Fare()
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
