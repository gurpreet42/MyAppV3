using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MyAppV3.Models;

namespace MyAppV3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,
            IStringLocalizer<SharedResource> stringLocalizer,
            IStringLocalizerFactory factory,
            LocService locService)
        {
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            var _localizer = factory.Create(type);
            var _localizer2 = factory.Create("SharedResource", assemblyName.Name);

            string hello1 = stringLocalizer["About"];
            string hello2 = _localizer["About"];
            string hello3 = _localizer2["About"];

            string hello4 = locService.GetLocalizedHtmlString("About");

            _logger = logger;
        }

        public IActionResult Index()
        {
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
